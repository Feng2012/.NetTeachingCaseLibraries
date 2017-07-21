using Kevin.SyntaxTextBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SQLTrace.Controls
{
    public partial class SQLQueryForm : Form
    {

        string _constr;
        SyntaxTextBox _sqlTB;
        public SQLQueryForm(string sql, string constr)
        {
            _constr = constr;
            InitializeComponent();
            AddSQLExeText(sql);
            ExecSQL(sql);
        
        }

        void AddSQLExeText(string sql="")
        {
            var item = new FarsiLibrary.Win.FATabStripItem();
            item.Title = $"查询{ SQL_TS.Items.Count}";
            _sqlTB = new SyntaxTextBox () { Dock = DockStyle.Fill };
            _sqlTB.ConfigFile = "sql.xml";
            _sqlTB.Text = sql;
            item.Controls.Add(_sqlTB);
            SQL_TS.Items.Add(item);
            _sqlTB.Refresh();
        }

        private void tabStrip_TabStripItemSelectionChanged(FarsiLibrary.Win.TabStripItemChangedEventArgs e)
        {

        }
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql"></param>
        void ExecSQL(string sql)
        {
            try
            {
                using (var con = new SqlConnection(_constr))
                {
                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = sql;
                        con.Open();
                        var reader = cmd.ExecuteReader();
                        var table = new DataTable();
                        table.Load(reader);
                        Grid_DTV.DataSource = table;
                    }
                }
            }
            catch (Exception exc)
            {
                Message_TB.Text = exc.Message;
                tabStrip.SelectedItem = Message_FTSI;
            }
        }

 

        private void SQLQueryForm_Load(object sender, EventArgs e)
        {
           
        }

        private void startToolStripButton_Click(object sender, EventArgs e)
        {
            ExecSQL(_sqlTB.Text);
            tabStrip.SelectedItem = Result_FTSI;
        }

        private void SQLQueryForm_Shown(object sender, EventArgs e)
        {
            
        }
    }
}
