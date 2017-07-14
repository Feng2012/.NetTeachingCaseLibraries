namespace SimpleAccountBook
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sstBar = new System.Windows.Forms.StatusStrip();
            this.tslLoginName = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsbDateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.sstBar.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1483, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sstBar
            // 
            this.sstBar.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.sstBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbDateTime,
            this.toolStripStatusLabel1,
            this.tslLoginName});
            this.sstBar.Location = new System.Drawing.Point(0, 930);
            this.sstBar.Name = "sstBar";
            this.sstBar.Size = new System.Drawing.Size(1483, 40);
            this.sstBar.TabIndex = 1;
            this.sstBar.Text = "statusStrip1";
            // 
            // tslLoginName
            // 
            this.tslLoginName.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tslLoginName.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            this.tslLoginName.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tslLoginName.Name = "tslLoginName";
            this.tslLoginName.Size = new System.Drawing.Size(66, 35);
            this.tslLoginName.Text = "张三";
            // 
            // tsbDateTime
            // 
            this.tsbDateTime.Name = "tsbDateTime";
            this.tsbDateTime.Size = new System.Drawing.Size(118, 35);
            this.tsbDateTime.Text = "2017-1-1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1284, 35);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1483, 906);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(48, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1431, 898);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "收入";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(48, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1431, 898);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "支出";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1483, 970);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.sstBar);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Simaple小帐本";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.sstBar.ResumeLayout(false);
            this.sstBar.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip sstBar;
        private System.Windows.Forms.ToolStripStatusLabel tslLoginName;
        private System.Windows.Forms.ToolStripStatusLabel tsbDateTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

