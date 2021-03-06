﻿namespace ExeManager
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.label1 = new System.Windows.Forms.Label();
            this.txbProcessName = new System.Windows.Forms.TextBox();
            this.txbExePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mtxtRestartTime = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSetting = new System.Windows.Forms.Button();
            this.notfBar = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnFindExe = new System.Windows.Forms.Button();
            this.fileOpen = new System.Windows.Forms.OpenFileDialog();
            this.labMessage = new System.Windows.Forms.Label();
            this.menuRight = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "进程名字：";
            // 
            // txbProcessName
            // 
            this.txbProcessName.Location = new System.Drawing.Point(74, 26);
            this.txbProcessName.Name = "txbProcessName";
            this.txbProcessName.Size = new System.Drawing.Size(263, 21);
            this.txbProcessName.TabIndex = 1;
            // 
            // txbExePath
            // 
            this.txbExePath.Location = new System.Drawing.Point(74, 66);
            this.txbExePath.Name = "txbExePath";
            this.txbExePath.Size = new System.Drawing.Size(233, 21);
            this.txbExePath.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "应用路径：";
            // 
            // mtxtRestartTime
            // 
            this.mtxtRestartTime.Location = new System.Drawing.Point(74, 107);
            this.mtxtRestartTime.Mask = "90:00";
            this.mtxtRestartTime.Name = "mtxtRestartTime";
            this.mtxtRestartTime.Size = new System.Drawing.Size(100, 21);
            this.mtxtRestartTime.TabIndex = 4;
            this.mtxtRestartTime.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "重启时间：";
            // 
            // btnSetting
            // 
            this.btnSetting.Location = new System.Drawing.Point(272, 154);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(79, 35);
            this.btnSetting.TabIndex = 6;
            this.btnSetting.Text = "设置";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // notfBar
            // 
            this.notfBar.ContextMenuStrip = this.menuRight;
            this.notfBar.Icon = ((System.Drawing.Icon)(resources.GetObject("notfBar.Icon")));
            this.notfBar.Text = "notifyIcon1";
            this.notfBar.Visible = true;
            // 
            // btnFindExe
            // 
            this.btnFindExe.Location = new System.Drawing.Point(306, 65);
            this.btnFindExe.Name = "btnFindExe";
            this.btnFindExe.Size = new System.Drawing.Size(32, 23);
            this.btnFindExe.TabIndex = 8;
            this.btnFindExe.Text = "…";
            this.btnFindExe.UseVisualStyleBackColor = true;
            this.btnFindExe.Click += new System.EventHandler(this.btnFindExe_Click);
            // 
            // fileOpen
            // 
            this.fileOpen.Filter = "EXE文件|*.exe";
            // 
            // labMessage
            // 
            this.labMessage.ForeColor = System.Drawing.Color.Red;
            this.labMessage.Location = new System.Drawing.Point(2, 139);
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(264, 53);
            this.labMessage.TabIndex = 9;
            this.labMessage.Text = "提示:";
            // 
            // menuRight
            // 
            this.menuRight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator1,
            this.toolStripMenuItem3});
            this.menuRight.Name = "menuRight";
            this.menuRight.Size = new System.Drawing.Size(181, 76);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "显示窗体";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem3.Text = "退出";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 201);
            this.Controls.Add(this.labMessage);
            this.Controls.Add(this.btnFindExe);
            this.Controls.Add(this.mtxtRestartTime);
            this.Controls.Add(this.txbExePath);
            this.Controls.Add(this.txbProcessName);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.menuRight.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbProcessName;
        private System.Windows.Forms.TextBox txbExePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mtxtRestartTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.NotifyIcon notfBar;
        private System.Windows.Forms.Button btnFindExe;
        private System.Windows.Forms.OpenFileDialog fileOpen;
        private System.Windows.Forms.Label labMessage;
        private System.Windows.Forms.ContextMenuStrip menuRight;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

