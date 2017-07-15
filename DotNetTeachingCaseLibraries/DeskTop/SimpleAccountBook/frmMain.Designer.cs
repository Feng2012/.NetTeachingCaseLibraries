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
            this.tsbDateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslLoginName = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvIncome = new System.Windows.Forms.DataGridView();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.财务类型设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.sstBar.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncome)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(742, 24);
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
            this.sstBar.Location = new System.Drawing.Point(0, 459);
            this.sstBar.Name = "sstBar";
            this.sstBar.Padding = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.sstBar.Size = new System.Drawing.Size(742, 26);
            this.sstBar.TabIndex = 1;
            this.sstBar.Text = "statusStrip1";
            // 
            // tsbDateTime
            // 
            this.tsbDateTime.Name = "tsbDateTime";
            this.tsbDateTime.Size = new System.Drawing.Size(60, 21);
            this.tsbDateTime.Text = "2017-1-1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(639, 21);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // tslLoginName
            // 
            this.tslLoginName.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tslLoginName.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            this.tslLoginName.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tslLoginName.Name = "tslLoginName";
            this.tslLoginName.Size = new System.Drawing.Size(36, 21);
            this.tslLoginName.Text = "张三";
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(742, 435);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvIncome);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(28, 4);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(710, 427);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "收入";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(28, 4);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(710, 427);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "支出";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(706, 86);
            this.panel1.TabIndex = 0;
            // 
            // dgvIncome
            // 
            this.dgvIncome.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIncome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIncome.Location = new System.Drawing.Point(2, 88);
            this.dgvIncome.Name = "dgvIncome";
            this.dgvIncome.RowTemplate.Height = 23;
            this.dgvIncome.Size = new System.Drawing.Size(706, 337);
            this.dgvIncome.TabIndex = 1;
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.财务类型设置ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 财务类型设置ToolStripMenuItem
            // 
            this.财务类型设置ToolStripMenuItem.Name = "财务类型设置ToolStripMenuItem";
            this.财务类型设置ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.财务类型设置ToolStripMenuItem.Text = "财务类型设置";
            this.财务类型设置ToolStripMenuItem.Click += new System.EventHandler(this.财务类型设置ToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 485);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.sstBar);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simaple小帐本";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.sstBar.ResumeLayout(false);
            this.sstBar.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncome)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 财务类型设置ToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvIncome;
        private System.Windows.Forms.Panel panel1;
    }
}

