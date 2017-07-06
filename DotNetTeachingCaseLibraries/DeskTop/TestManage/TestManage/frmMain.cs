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
        public frmMain()
        {
            InitializeComponent();
        }
        public frmMain(IService server)
        {
            InitializeComponent();
            server.F();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
