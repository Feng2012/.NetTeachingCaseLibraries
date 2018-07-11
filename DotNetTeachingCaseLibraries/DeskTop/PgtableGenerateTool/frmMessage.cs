using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PgtableGenerateTool
{
    public partial class frmMessage : Form
    {
        public frmMessage()
        {
            InitializeComponent();
            count = 1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            MigrationThread?.Abort();
            Close();
        }

        public Thread MigrationThread { get; set; }

        long count;
        private void tmrCount_Tick(object sender, EventArgs e)
        {
            labTimes.Text = "用时" +count++.ToString("000000000000") + "秒";
        }
    }
}
