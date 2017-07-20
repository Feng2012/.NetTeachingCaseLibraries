using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace SimpleAccountBook
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //清空输入框，把焦点设在用户名上
            txbUserName.Clear();
            txbPassword.Clear();
            txbUserName.Focus();
        }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string LoginName
        {
            get;
            private set;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }
        /// <summary>
        /// 登录
        /// </summary>
        void Login()
        {
            var bllHandler = new BllHandler();
            LoginName = bllHandler.Login(txbUserName.Text, txbPassword.Text);
            if (LoginName != null)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("用户名或密码不正确！");
            }
        }

        private void txbUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //回车焦点跳转
            if (e.KeyChar == 13)
            {
                txbPassword.Focus();
            }
        }

        private void txbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            //回车登录
            if (e.KeyChar == 13)
            {
                Login();
            }
        }
    }
}
