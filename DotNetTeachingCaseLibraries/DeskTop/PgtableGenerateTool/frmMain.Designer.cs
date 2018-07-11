namespace PgtableGenerateTool
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
            this.iconList = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sqlWebBrowser = new System.Windows.Forms.WebBrowser();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvTable = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cheCommon = new System.Windows.Forms.CheckBox();
            this.chbAllSelect = new System.Windows.Forms.CheckBox();
            this.btnCreateSql = new System.Windows.Forms.Button();
            this.btnCreateTable = new System.Windows.Forms.Button();
            this.btnMigration = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // iconList
            // 
            this.iconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconList.ImageStream")));
            this.iconList.TransparentColor = System.Drawing.Color.Transparent;
            this.iconList.Images.SetKeyName(0, "table.ico");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sqlWebBrowser);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1163, 398);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "生成PostgreSql语句";
            // 
            // sqlWebBrowser
            // 
            this.sqlWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqlWebBrowser.Location = new System.Drawing.Point(3, 17);
            this.sqlWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.sqlWebBrowser.Name = "sqlWebBrowser";
            this.sqlWebBrowser.Size = new System.Drawing.Size(1157, 378);
            this.sqlWebBrowser.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvTable);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1163, 624);
            this.splitContainer1.SplitterDistance = 220;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 2;
            // 
            // lvTable
            // 
            this.lvTable.CheckBoxes = true;
            this.lvTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTable.LargeImageList = this.iconList;
            this.lvTable.Location = new System.Drawing.Point(0, 0);
            this.lvTable.Name = "lvTable";
            this.lvTable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lvTable.Size = new System.Drawing.Size(1163, 176);
            this.lvTable.SmallImageList = this.iconList;
            this.lvTable.TabIndex = 1;
            this.lvTable.UseCompatibleStateImageBehavior = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cheCommon);
            this.panel1.Controls.Add(this.chbAllSelect);
            this.panel1.Controls.Add(this.btnCreateSql);
            this.panel1.Controls.Add(this.btnCreateTable);
            this.panel1.Controls.Add(this.btnMigration);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 176);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(1163, 44);
            this.panel1.TabIndex = 2;
            // 
            // cheCommon
            // 
            this.cheCommon.AutoSize = true;
            this.cheCommon.Dock = System.Windows.Forms.DockStyle.Left;
            this.cheCommon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cheCommon.Location = new System.Drawing.Point(53, 3);
            this.cheCommon.Name = "cheCommon";
            this.cheCommon.Size = new System.Drawing.Size(50, 38);
            this.cheCommon.TabIndex = 3;
            this.cheCommon.Text = "常用";
            this.cheCommon.UseVisualStyleBackColor = true;
            this.cheCommon.CheckedChanged += new System.EventHandler(this.cheCommon_CheckedChanged);
            // 
            // chbAllSelect
            // 
            this.chbAllSelect.AutoSize = true;
            this.chbAllSelect.Dock = System.Windows.Forms.DockStyle.Left;
            this.chbAllSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.chbAllSelect.Location = new System.Drawing.Point(3, 3);
            this.chbAllSelect.Name = "chbAllSelect";
            this.chbAllSelect.Size = new System.Drawing.Size(50, 38);
            this.chbAllSelect.TabIndex = 2;
            this.chbAllSelect.Text = "全选";
            this.chbAllSelect.UseVisualStyleBackColor = true;
            this.chbAllSelect.CheckedChanged += new System.EventHandler(this.chbAllSelect_CheckedChanged);
            // 
            // btnCreateSql
            // 
            this.btnCreateSql.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnCreateSql.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCreateSql.Location = new System.Drawing.Point(639, 3);
            this.btnCreateSql.Name = "btnCreateSql";
            this.btnCreateSql.Size = new System.Drawing.Size(153, 38);
            this.btnCreateSql.TabIndex = 1;
            this.btnCreateSql.Text = "生成Postgre语句";
            this.btnCreateSql.UseVisualStyleBackColor = true;
            this.btnCreateSql.Click += new System.EventHandler(this.btnCreateSql_Click);
            // 
            // btnCreateTable
            // 
            this.btnCreateTable.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnCreateTable.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCreateTable.Enabled = false;
            this.btnCreateTable.Location = new System.Drawing.Point(792, 3);
            this.btnCreateTable.Name = "btnCreateTable";
            this.btnCreateTable.Size = new System.Drawing.Size(153, 38);
            this.btnCreateTable.TabIndex = 0;
            this.btnCreateTable.Text = "生成Postgre表";
            this.btnCreateTable.UseVisualStyleBackColor = true;
            this.btnCreateTable.Click += new System.EventHandler(this.btnCreateTable_Click);
            // 
            // btnMigration
            // 
            this.btnMigration.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnMigration.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMigration.Enabled = false;
            this.btnMigration.Location = new System.Drawing.Point(945, 3);
            this.btnMigration.Name = "btnMigration";
            this.btnMigration.Size = new System.Drawing.Size(215, 38);
            this.btnMigration.TabIndex = 4;
            this.btnMigration.Text = "从SQL Server导到PostgreSql";
            this.btnMigration.UseVisualStyleBackColor = true;
            this.btnMigration.Click += new System.EventHandler(this.btnMigration_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 624);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL Server生成PostgreSql表工具";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList iconList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lvTable;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCreateTable;
        private System.Windows.Forms.Button btnCreateSql;
        private System.Windows.Forms.WebBrowser sqlWebBrowser;
        private System.Windows.Forms.CheckBox chbAllSelect;
        private System.Windows.Forms.CheckBox cheCommon;
        private System.Windows.Forms.Button btnMigration;
    }
}

