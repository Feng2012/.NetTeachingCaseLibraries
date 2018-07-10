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
            try
            {
                var allSqlBuilder = new StringBuilder();
                foreach (ListViewItem item in lvTable.Items)
                {
                    if (item.Checked)
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
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }


}
