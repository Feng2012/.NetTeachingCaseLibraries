namespace SimpleAccountBook
{
    partial class frmQueryMain
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
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labCount = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.labEndTime = new System.Windows.Forms.Label();
            this.dtpBeginTime = new System.Windows.Forms.DateTimePicker();
            this.labBeginTime = new System.Windows.Forms.Label();
            this.cmbSpendUser = new System.Windows.Forms.ComboBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.labSpendUser = new System.Windows.Forms.Label();
            this.txbFinanceType = new System.Windows.Forms.TextBox();
            this.btnSelectFinanceType = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 92);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(873, 393);
            this.dgvData.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labCount);
            this.panel1.Controls.Add(this.dtpEndTime);
            this.panel1.Controls.Add(this.labEndTime);
            this.panel1.Controls.Add(this.dtpBeginTime);
            this.panel1.Controls.Add(this.labBeginTime);
            this.panel1.Controls.Add(this.cmbSpendUser);
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Controls.Add(this.labSpendUser);
            this.panel1.Controls.Add(this.txbFinanceType);
            this.panel1.Controls.Add(this.btnSelectFinanceType);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(873, 92);
            this.panel1.TabIndex = 3;
            // 
            // labCount
            // 
            this.labCount.AutoSize = true;
            this.labCount.Location = new System.Drawing.Point(30, 74);
            this.labCount.Name = "labCount";
            this.labCount.Size = new System.Drawing.Size(41, 12);
            this.labCount.TabIndex = 13;
            this.labCount.Text = "总计：";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Location = new System.Drawing.Point(381, 9);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(200, 21);
            this.dtpEndTime.TabIndex = 11;
            // 
            // labEndTime
            // 
            this.labEndTime.AutoSize = true;
            this.labEndTime.Location = new System.Drawing.Point(322, 13);
            this.labEndTime.Name = "labEndTime";
            this.labEndTime.Size = new System.Drawing.Size(65, 12);
            this.labEndTime.TabIndex = 12;
            this.labEndTime.Text = "开始日期：";
            // 
            // dtpBeginTime
            // 
            this.dtpBeginTime.Location = new System.Drawing.Point(89, 9);
            this.dtpBeginTime.Name = "dtpBeginTime";
            this.dtpBeginTime.Size = new System.Drawing.Size(200, 21);
            this.dtpBeginTime.TabIndex = 9;
            // 
            // labBeginTime
            // 
            this.labBeginTime.AutoSize = true;
            this.labBeginTime.Location = new System.Drawing.Point(30, 13);
            this.labBeginTime.Name = "labBeginTime";
            this.labBeginTime.Size = new System.Drawing.Size(65, 12);
            this.labBeginTime.TabIndex = 10;
            this.labBeginTime.Text = "开始日期：";
            // 
            // cmbSpendUser
            // 
            this.cmbSpendUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpendUser.FormattingEnabled = true;
            this.cmbSpendUser.Location = new System.Drawing.Point(381, 40);
            this.cmbSpendUser.Name = "cmbSpendUser";
            this.cmbSpendUser.Size = new System.Drawing.Size(200, 20);
            this.cmbSpendUser.TabIndex = 4;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(602, 37);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 8;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnSava_Click);
            // 
            // labSpendUser
            // 
            this.labSpendUser.AutoSize = true;
            this.labSpendUser.Location = new System.Drawing.Point(332, 44);
            this.labSpendUser.Name = "labSpendUser";
            this.labSpendUser.Size = new System.Drawing.Size(53, 12);
            this.labSpendUser.TabIndex = 5;
            this.labSpendUser.Text = "花费人：";
            // 
            // txbFinanceType
            // 
            this.txbFinanceType.Location = new System.Drawing.Point(32, 41);
            this.txbFinanceType.Name = "txbFinanceType";
            this.txbFinanceType.Size = new System.Drawing.Size(182, 21);
            this.txbFinanceType.TabIndex = 1;
            // 
            // btnSelectFinanceType
            // 
            this.btnSelectFinanceType.Location = new System.Drawing.Point(217, 40);
            this.btnSelectFinanceType.Name = "btnSelectFinanceType";
            this.btnSelectFinanceType.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFinanceType.TabIndex = 0;
            this.btnSelectFinanceType.Text = "选择财务类型";
            this.btnSelectFinanceType.UseVisualStyleBackColor = true;
            this.btnSelectFinanceType.Click += new System.EventHandler(this.btnSelectFinanceType_Click);
            // 
            // frmQueryMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 485);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmQueryMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查询统计";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label labSpendUser;
        private System.Windows.Forms.ComboBox cmbSpendUser;
        private System.Windows.Forms.TextBox txbFinanceType;
        private System.Windows.Forms.Button btnSelectFinanceType;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label labEndTime;
        private System.Windows.Forms.DateTimePicker dtpBeginTime;
        private System.Windows.Forms.Label labBeginTime;
        private System.Windows.Forms.Label labCount;
    }
}

