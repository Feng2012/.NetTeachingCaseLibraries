using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestManage
{
    public partial class frmMain : Form
    {
        frmClassSetting _frmClass;
        frmTest _frmTest;
        public frmMain(frmClassSetting frmClass,frmTest frmTest)
        {
            InitializeComponent();
            _frmClass = frmClass;
            _frmTest = frmTest;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void 班级管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _frmClass.ShowDialog();
        }
    }
}
