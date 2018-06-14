using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ExeManager
{
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            txbProcessName.Text = ConfigManage.GetSettingValue("processname");
            txbExePath.Text = ConfigManage.GetSettingValue("exepath");
            mtxtRestartTime.Text = ConfigManage.GetSettingValue("restarttime");

            new Thread(StartTimer).Start();
        }

        void StartTimer()
        {
            while (true)
            {
                var dateString = ConfigManage.GetSettingValue("date").Trim();
                try
                {                  
                    if (!string.IsNullOrEmpty(dateString) && dateString == DateTime.Now.ToString("yyyy-MM-dd") && DateTime.Now.ToString("HH:mm") == mtxtRestartTime.Text)
                    {
                        foreach (var process in Process.GetProcesses())
                        {
                            if (process.ProcessName.ToLower() == txbProcessName.Text.ToLower())
                            {
                                process.Kill();
                            }
                        }
                        Process.Start(txbExePath.Text);
                        var settings = new Dictionary<string, string>();
                        settings.Add("date", DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"));
                        ConfigManage.AddSetings(settings);
                    }

                    this.BeginInvoke(new Action(() =>
                    {
                        labMessage.Text = "";
                    }));
                }
                catch (Exception exc)
                {

                    this.BeginInvoke(new Action(() =>
                    {
                        labMessage.Text = exc.Message;
                    }));

                }
                finally
                {
                    System.Threading.Thread.Sleep(1000 * 20);
                }
            }
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            var settings = new Dictionary<string, string>();
            settings.Add("processname", txbProcessName.Text.Trim());
            settings.Add("exepath", txbExePath.Text.Trim());
            settings.Add("restarttime", mtxtRestartTime.Text.Trim());
            ConfigManage.AddSetings(settings);
        }

        private void btnFindExe_Click(object sender, EventArgs e)
        {
            if (fileOpen.ShowDialog() == DialogResult.OK)
            {
                txbExePath.Text = fileOpen.FileName;
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }
    }
}
