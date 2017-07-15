using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleAccountBook
{
    public partial class frmMain : Form
    {
        string _loginName;
        public frmMain(string loginName)
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            tslLoginName.Text = _loginName;

        }

        private void 财务类型设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
