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
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.财务类型设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sstBar = new System.Windows.Forms.StatusStrip();
            this.tsbDateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslLoginName = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgvIncome = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnSava = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txbMemo = new System.Windows.Forms.TextBox();
            this.labSpendUser = new System.Windows.Forms.Label();
            this.cmbSpendUser = new System.Windows.Forms.ComboBox();
            this.labAmout = new System.Windows.Forms.Label();
            this.txbAmout = new System.Windows.Forms.TextBox();
            this.txbFinanceType = new System.Windows.Forms.TextBox();
            this.btnSelectFinanceType = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.sstBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncome)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(683, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
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
            this.财务类型设置ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.财务类型设置ToolStripMenuItem.Text = "财务类型设置";
            this.财务类型设置ToolStripMenuItem.Click += new System.EventHandler(this.财务类型设置ToolStripMenuItem_Click);
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
            this.sstBar.Size = new System.Drawing.Size(683, 26);
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
            // dgvIncome
            // 
            this.dgvIncome.AllowUserToAddRows = false;
            this.dgvIncome.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIncome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIncome.Location = new System.Drawing.Point(0, 151);
            this.dgvIncome.Name = "dgvIncome";
            this.dgvIncome.ReadOnly = true;
            this.dgvIncome.RowTemplate.Height = 23;
            this.dgvIncome.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIncome.Size = new System.Drawing.Size(683, 308);
            this.dgvIncome.TabIndex = 4;
            this.dgvIncome.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIncome_CellDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRemove);
            this.panel1.Controls.Add(this.btnModify);
            this.panel1.Controls.Add(this.btnSava);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txbMemo);
            this.panel1.Controls.Add(this.labSpendUser);
            this.panel1.Controls.Add(this.cmbSpendUser);
            this.panel1.Controls.Add(this.labAmout);
            this.panel1.Controls.Add(this.txbAmout);
            this.panel1.Controls.Add(this.txbFinanceType);
            this.panel1.Controls.Add(this.btnSelectFinanceType);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(683, 127);
            this.panel1.TabIndex = 3;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(427, 99);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 10;
            this.btnRemove.Text = "删除";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(508, 99);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 9;
            this.btnModify.Text = "修改";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnSava
            // 
            this.btnSava.Location = new System.Drawing.Point(589, 99);
            this.btnSava.Name = "btnSava";
            this.btnSava.Size = new System.Drawing.Size(75, 23);
            this.btnSava.TabIndex = 8;
            this.btnSava.Text = "添加";
            this.btnSava.UseVisualStyleBackColor = true;
            this.btnSava.Click += new System.EventHandler(this.btnSava_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "金额：";
            // 
            // txbMemo
            // 
            this.txbMemo.Location = new System.Drawing.Point(26, 48);
            this.txbMemo.Multiline = true;
            this.txbMemo.Name = "txbMemo";
            this.txbMemo.Size = new System.Drawing.Size(638, 45);
            this.txbMemo.TabIndex = 6;
            // 
            // labSpendUser
            // 
            this.labSpendUser.AutoSize = true;
            this.labSpendUser.Location = new System.Drawing.Point(490, 13);
            this.labSpendUser.Name = "labSpendUser";
            this.labSpendUser.Size = new System.Drawing.Size(53, 12);
            this.labSpendUser.TabIndex = 5;
            this.labSpendUser.Text = "花费人：";
            // 
            // cmbSpendUser
            // 
            this.cmbSpendUser.FormattingEnabled = true;
            this.cmbSpendUser.Location = new System.Drawing.Point(543, 8);
            this.cmbSpendUser.Name = "cmbSpendUser";
            this.cmbSpendUser.Size = new System.Drawing.Size(121, 20);
            this.cmbSpendUser.TabIndex = 4;
            // 
            // labAmout
            // 
            this.labAmout.AutoSize = true;
            this.labAmout.Location = new System.Drawing.Point(278, 13);
            this.labAmout.Name = "labAmout";
            this.labAmout.Size = new System.Drawing.Size(41, 12);
            this.labAmout.TabIndex = 3;
            this.labAmout.Text = "金额：";
            // 
            // txbAmout
            // 
            this.txbAmout.Location = new System.Drawing.Point(319, 9);
            this.txbAmout.Name = "txbAmout";
            this.txbAmout.Size = new System.Drawing.Size(127, 21);
            this.txbAmout.TabIndex = 2;
            // 
            // txbFinanceType
            // 
            this.txbFinanceType.Location = new System.Drawing.Point(26, 9);
            this.txbFinanceType.Name = "txbFinanceType";
            this.txbFinanceType.Size = new System.Drawing.Size(127, 21);
            this.txbFinanceType.TabIndex = 1;
            // 
            // btnSelectFinanceType
            // 
            this.btnSelectFinanceType.Location = new System.Drawing.Point(156, 8);
            this.btnSelectFinanceType.Name = "btnSelectFinanceType";
            this.btnSelectFinanceType.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFinanceType.TabIndex = 0;
            this.btnSelectFinanceType.Text = "选择财务类型";
            this.btnSelectFinanceType.UseVisualStyleBackColor = true;
            this.btnSelectFinanceType.Click += new System.EventHandler(this.btnSelectFinanceType_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 485);
            this.Controls.Add(this.dgvIncome);
            this.Controls.Add(this.panel1);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncome)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip sstBar;
        private System.Windows.Forms.ToolStripStatusLabel tslLoginName;
        private System.Windows.Forms.ToolStripStatusLabel tsbDateTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 财务类型设置ToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvIncome;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnSava;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbMemo;
        private System.Windows.Forms.Label labSpendUser;
        private System.Windows.Forms.ComboBox cmbSpendUser;
        private System.Windows.Forms.Label labAmout;
        private System.Windows.Forms.TextBox txbAmout;
        private System.Windows.Forms.TextBox txbFinanceType;
        private System.Windows.Forms.Button btnSelectFinanceType;
    }
}

