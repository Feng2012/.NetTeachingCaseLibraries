using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using Dapper;
using System.Text;
using System.Windows.Forms;
using ColorCode;
using System.Reflection;
using System.Threading;
using PgtableGenerateTool.Properties;

namespace PgtableGenerateTool
{
    public partial class frmMain : Form
    {
        readonly string _sqlconnectionstring;
        readonly string _pgconnectionstring;
        readonly Dictionary<string, string> _typeDic;

        string _pgsql;
        public frmMain()
        {
            InitializeComponent();
            _sqlconnectionstring = ConfigurationManager.ConnectionStrings["sqlconnectionstring"].ConnectionString;
            _pgconnectionstring = ConfigurationManager.ConnectionStrings["pgconnectionstring"].ConnectionString;
            _typeDic = new Dictionary<string, string>();
            _typeDic.Add("nvarchar", "character varying({0})");
            _typeDic.Add("decimal", "numeric({1},{2})");
            _typeDic.Add("datetime", "timestamp without time zone");
            _typeDic.Add("int", "integer");
            _typeDic.Add("text", "text");
            _typeDic.Add("bit", "boolean");
        }
        /// <summary>
        /// 查询库中所有表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(_sqlconnectionstring))
                {
                    using (var con = new SqlConnection(_sqlconnectionstring))
                    {
                        var tableNames = con.Query<string>("select [name] from sysobjects where xtype='U' order by [name]");
                        foreach (var tableName in tableNames)
                        {
                            lvTable.Items.Add(tableName, 0);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 生成pg sql
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateSql_Click(object sender, EventArgs e)
        {
            if (lvTable.CheckedItems.Count == 0)
            {
                MessageBox.Show("请选择要生成的表", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var allSqlBuilder = new StringBuilder();
                foreach (ListViewItem item in lvTable.CheckedItems)
                {
                    allSqlBuilder.AppendLine($"--{item.Text}");
                    using (var con = new SqlConnection(_sqlconnectionstring))
                    {
                        var fields = con.Query<dynamic>($@"select  st.name as 'typename',sc.name,sc.length,sc.xprec,sc.xscale,sc.isnullable
from syscolumns sc,systypes st 
where sc.xtype=st.xtype and st.status=0
and sc.id in(
select id from sysobjects where xtype='U' and name='{item.Text}') ");
                        var sqlBuilder = new StringBuilder($"drop table if exists {item.Text};");
                        sqlBuilder.AppendLine("\r\n");
                        sqlBuilder.AppendLine($"create table {item.Text}(");
                        foreach (var field in fields)
                        {
                            if (field.length != -1)
                            {
                                sqlBuilder.AppendLine($"{field.name} {string.Format(_typeDic[field.typename], field.length, field.xprec, field.xscale)} {(field.isnullable == 1 ? "null" : "not null")},");
                            }
                            else
                            {
                                sqlBuilder.AppendLine($"{field.name} text {(field.isnullable == 1 ? "null" : "not null")},");
                            }
                        }
                        //查询外键和唯一键
                        var constraintsSql = $@"select b.column_name,a.constraint_type,b.constraint_name from information_schema.table_constraints a
inner join information_schema.constraint_column_usage b on a.constraint_name = b.constraint_name where  a.table_name = '{item.Text}'";
                        var constraints = con.Query<dynamic>(constraintsSql);
                        foreach (var constraint in constraints)
                        {
                            if (constraint.constraint_type == "UNIQUE" || constraint.constraint_type == "PRIMARY KEY")
                            {
                                sqlBuilder.AppendLine($"CONSTRAINT {constraint.constraint_name} {constraint.constraint_type} ({constraint.column_name}),");
                            }
                        }
                        var tableSql = sqlBuilder.ToString().ToLower().TrimEnd('\r', '\n', ',') + ");";
                        allSqlBuilder.AppendLine(tableSql);
                        allSqlBuilder.AppendLine();
                    }

                }
                _pgsql = allSqlBuilder.ToString();
                var colorizedSourceCode = new CodeColorizer().Colorize(allSqlBuilder.ToString(), Languages.Sql);
                var path = AppDomain.CurrentDomain.BaseDirectory + @"a.html";
                var writer = new System.IO.StreamWriter(path);
                writer.Write(colorizedSourceCode);
                writer.Close();
                sqlWebBrowser.Url = new Uri(path);
                btnCreateTable.Enabled = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void chbAllSelect_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvTable.Items)
            {
                if (chbAllSelect.Checked)
                {
                    item.Checked = true;
                }
                else
                {
                    item.Checked = false;
                }
            }
        }

        private void cheCommon_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvTable.Items)
            {
                item.Checked = false;
            }
            var tables = ConfigurationManager.AppSettings["commontable"].ToLower().Split(',');
            if (cheCommon.Checked)
            {
                foreach (ListViewItem item in lvTable.Items)
                {
                    if (tables.Contains(item.Text.ToLower()))
                    {
                        item.Checked = true;
                    }
                }
            }
        }

        /// <summary>
        /// 执行pg sql
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateTable_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("执行此语句会把原表删除并重新创建，你确定吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (var con = new Npgsql.NpgsqlConnection(_pgconnectionstring))
                    {
                        if (string.IsNullOrEmpty(_pgsql))
                        {
                            MessageBox.Show("请先选择表生成PostgreSql语句后再执行！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            con.Execute(_pgsql);
                        }
                    }
                }
                MessageBox.Show("执行成功！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnMigration.Enabled = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnMigration_Click(object sender, EventArgs e)
        {

            var tablenames = new List<string>();
            foreach (ListViewItem item in lvTable.CheckedItems)
            {
                tablenames.Add(item.Text);
            }
            var frmMessage = new frmMessage();
            var thread = new Thread(delegate ()
              {
                  foreach (var item in tablenames)
                  {
                      this.BeginInvoke(new ThreadStart(delegate ()
                      {
                          frmMessage.labMessage.Text = $"正在查询{item}表……";
                      }));

                      var pagesize = 5000;
                      var pageindex = 1;
                      while (true)
                      {
                          List<dynamic> list = null;
                          string pgsql = null;
                          List<string> keyfields = null;
                          int recordCount = 0;
                          using (var con = new SqlConnection(_sqlconnectionstring))
                          {
                               keyfields = con.Query<string>($@"SELECT c.name Cname FROM sys.objects T INNER JOIN sys.objects P ON t.object_id=p.parent_object_id AND t.type='U' AND p.type='PK' INNER JOIN sys.SysColumns C ON c.id=t.object_id INNER JOIN sysindexes i ON i.name=p.name INNER JOIN sysindexkeys k ON k.id=c.id AND k.colid=c.colid AND k.indid=i.indid where t.name='{item}'").ToList();
                              if (keyfields.Count() > 0)
                              {
                                  list = con.Query<dynamic>($@"SELECT TOP {pagesize} * FROM (SELECT ROW_NUMBER() OVER (ORDER BY {keyfields[0]}) AS RowNo,* FROM {item})querytable WHERE RowNo > {(pageindex - 1) * pagesize} ").ToList();
                             
                                  if (list.Count == 0)
                                  {
                                      break;
                                  }
                              }
                              else
                              {
                                  list = con.Query<dynamic>($@"SELECT * from {item}").ToList();
                              }
                              recordCount=con.ExecuteScalar<int>($@"SELECT count(1) as sl from {item}");

                              //生成pg的insert into 语句
                              var fields = con.Query<string>($@"select sc.name from syscolumns sc,systypes st where sc.xtype=st.xtype and st.status=0 and sc.id in(select id from sysobjects where xtype='U' and name='{item}')");
                              var pgsqlField = new StringBuilder();
                              var pgsqlPar = new StringBuilder();
                              foreach (var field in fields)
                              {
                                  pgsqlField.Append($"{field},");
                                  pgsqlPar.Append($"@{field},");
                              }
                              pgsql = $"insert into {item}({pgsqlField.ToString().TrimEnd(',')}) values({pgsqlPar.ToString().TrimEnd(',')})";
                          }

                          using (var pgcon = new Npgsql.NpgsqlConnection(_pgconnectionstring))
                          {
                              this.BeginInvoke(new ThreadStart(delegate ()
                              {
                                  frmMessage.labMessage.Text = $"正在搬运{item}表，{pageindex * pagesize}/{recordCount}条记录……";
                              }));
                              pgcon.Execute(pgsql, list);
                          }
                          //没有关键了，就退出
                          if (keyfields.Count() == 0)
                          {
                              break;
                          }
                          pageindex++;
                      }
                  }
                  this.BeginInvoke(new ThreadStart(delegate ()
                  {
                      frmMessage.picLoad.Image = Resources.migration1;
                      frmMessage.labMessage.Text = $"全部搬运完成！";
                      frmMessage.tmrCount.Stop();
                  }));
              });
            frmMessage.MigrationThread = thread;
            frmMessage.tmrCount.Start();
            thread.Start();
            frmMessage.ShowDialog();

        }



        private void btnMigration_Click1(object sender, EventArgs e)
        {

            var tablenames = new List<string>();
            foreach (ListViewItem item in lvTable.CheckedItems)
            {
                tablenames.Add(item.Text);
            }
            var frmMessage = new frmMessage();
            var thread = new Thread(delegate ()
            {
                foreach (var item in tablenames)
                {
                    this.BeginInvoke(new ThreadStart(delegate ()
                    {
                        frmMessage.labMessage.Text = $"正在查询{item}表……";
                    }));

                    List<dynamic> list = null;
                    string pgsql = null;
                    using (var con = new SqlConnection(_sqlconnectionstring))
                    {
                        list = con.Query<dynamic>($@"select  * from {item}").ToList();
                        this.BeginInvoke(new ThreadStart(delegate ()
                        {
                            frmMessage.labMessage.Text = $"正在搬运{item}表，总共{list.Count()}条记录……";
                        }));
                        var fields = con.Query<string>($@"select sc.name from syscolumns sc,systypes st where sc.xtype=st.xtype and st.status=0 and sc.id in(select id from sysobjects where xtype='U' and name='{item}')");
                        var pgsqlField = new StringBuilder();
                        var pgsqlPar = new StringBuilder();
                        foreach (var field in fields)
                        {
                            pgsqlField.Append($"{field},");
                            pgsqlPar.Append($"@{field},");
                        }

                        pgsql = $"insert into {item}({pgsqlField.ToString().TrimEnd(',')}) values({pgsqlPar.ToString().TrimEnd(',')})";
                    }
                    var index = 0;
                    var count = 1000;
                    using (var pgcon = new Npgsql.NpgsqlConnection(_pgconnectionstring))
                    {
                        while (index * count < list.Count)
                        {
                            this.BeginInvoke(new ThreadStart(delegate ()
                            {
                                frmMessage.labMessage.Text = $"正在搬运{item}表，{index * count}/{list.Count()}……";
                            }));
                            var newlist = new List<dynamic>();
                            newlist.AddRange(list.Skip(index * count).Take(count));
                            pgcon.Execute(pgsql, newlist);
                            index++;
                        }
                    }
                }
                this.BeginInvoke(new ThreadStart(delegate ()
                {
                    frmMessage.picLoad.Image = Resources.migration1;
                    frmMessage.labMessage.Text = $"全部搬运完成！";
                    frmMessage.tmrCount.Stop();
                }));
            });
            frmMessage.MigrationThread = thread;
            frmMessage.tmrCount.Start();
            thread.Start();
            frmMessage.ShowDialog();

        }
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }


}
