namespace SQLTrace.Controls
{
    partial class SQLQueryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SQLQueryForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.SQL_TS = new FarsiLibrary.Win.FATabStrip();
            this.faTabStripItem2 = new FarsiLibrary.Win.FATabStripItem();
            this.tabStrip = new FarsiLibrary.Win.FATabStrip();
            this.Result_FTSI = new FarsiLibrary.Win.FATabStripItem();
            this.Grid_DTV = new System.Windows.Forms.DataGridView();
            this.Message_FTSI = new FarsiLibrary.Win.FATabStripItem();
            this.Message_TB = new System.Windows.Forms.TextBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.newTraceToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.startToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.faTabStripItem1 = new FarsiLibrary.Win.FATabStripItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SQL_TS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabStrip)).BeginInit();
            this.tabStrip.SuspendLayout();
            this.Result_FTSI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_DTV)).BeginInit();
            this.Message_FTSI.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.SQL_TS);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabStrip);
            this.splitContainer1.Size = new System.Drawing.Size(1096, 704);
            this.splitContainer1.SplitterDistance = 247;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // SQL_TS
            // 
            this.SQL_TS.AlwaysShowClose = false;
            this.SQL_TS.AlwaysShowMenuGlyph = false;
            this.SQL_TS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SQL_TS.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.SQL_TS.Location = new System.Drawing.Point(0, 0);
            this.SQL_TS.Name = "SQL_TS";
            this.SQL_TS.SelectedItem = this.faTabStripItem2;
            this.SQL_TS.Size = new System.Drawing.Size(1096, 247);
            this.SQL_TS.TabIndex = 2;
            // 
            // faTabStripItem2
            // 
            this.faTabStripItem2.IsDrawn = true;
            this.faTabStripItem2.Name = "faTabStripItem2";
            this.faTabStripItem2.Selected = true;
            this.faTabStripItem2.Size = new System.Drawing.Size(906, 153);
            this.faTabStripItem2.TabIndex = 1;
            this.faTabStripItem2.Title = "消息";
            // 
            // tabStrip
            // 
            this.tabStrip.AlwaysShowClose = false;
            this.tabStrip.AlwaysShowMenuGlyph = false;
            this.tabStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabStrip.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tabStrip.Items.AddRange(new FarsiLibrary.Win.FATabStripItem[] {
            this.Result_FTSI,
            this.Message_FTSI});
            this.tabStrip.Location = new System.Drawing.Point(0, 0);
            this.tabStrip.Name = "tabStrip";
            this.tabStrip.SelectedItem = this.Result_FTSI;
            this.tabStrip.Size = new System.Drawing.Size(1096, 454);
            this.tabStrip.TabIndex = 1;
            this.tabStrip.TabStripItemSelectionChanged += new FarsiLibrary.Win.TabStripItemChangedHandler(this.tabStrip_TabStripItemSelectionChanged);
            // 
            // Result_FTSI
            // 
            this.Result_FTSI.Controls.Add(this.Grid_DTV);
            this.Result_FTSI.IsDrawn = true;
            this.Result_FTSI.Name = "Result_FTSI";
            this.Result_FTSI.Selected = true;
            this.Result_FTSI.Size = new System.Drawing.Size(1094, 433);
            this.Result_FTSI.TabIndex = 0;
            this.Result_FTSI.Title = "结果";
            // 
            // Grid_DTV
            // 
            this.Grid_DTV.AllowUserToAddRows = false;
            this.Grid_DTV.AllowUserToDeleteRows = false;
            this.Grid_DTV.BackgroundColor = System.Drawing.Color.White;
            this.Grid_DTV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_DTV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid_DTV.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Grid_DTV.Location = new System.Drawing.Point(0, 0);
            this.Grid_DTV.Margin = new System.Windows.Forms.Padding(2);
            this.Grid_DTV.Name = "Grid_DTV";
            this.Grid_DTV.ReadOnly = true;
            this.Grid_DTV.RowTemplate.Height = 27;
            this.Grid_DTV.Size = new System.Drawing.Size(1094, 433);
            this.Grid_DTV.TabIndex = 0;
            // 
            // Message_FTSI
            // 
            this.Message_FTSI.Controls.Add(this.Message_TB);
            this.Message_FTSI.IsDrawn = true;
            this.Message_FTSI.Name = "Message_FTSI";
            this.Message_FTSI.Size = new System.Drawing.Size(1094, 433);
            this.Message_FTSI.TabIndex = 1;
            this.Message_FTSI.Title = "消息";
            // 
            // Message_TB
            // 
            this.Message_TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Message_TB.Location = new System.Drawing.Point(0, 0);
            this.Message_TB.Margin = new System.Windows.Forms.Padding(2);
            this.Message_TB.Multiline = true;
            this.Message_TB.Name = "Message_TB";
            this.Message_TB.Size = new System.Drawing.Size(1094, 433);
            this.Message_TB.TabIndex = 0;
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTraceToolStripButton,
            this.toolStripSeparator1,
            this.startToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1096, 27);
            this.toolStrip.TabIndex = 5;
            this.toolStrip.Text = "toolStrip1";
            // 
            // newTraceToolStripButton
            // 
            this.newTraceToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newTraceToolStripButton.Image = global::SQLTrace.Properties.Resources._new;
            this.newTraceToolStripButton.ImageTransparentColor = System.Drawing.Color.White;
            this.newTraceToolStripButton.Name = "newTraceToolStripButton";
            this.newTraceToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.newTraceToolStripButton.Text = "新建";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // startToolStripButton
            // 
            this.startToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.startToolStripButton.Image = global::SQLTrace.Properties.Resources.play;
            this.startToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.startToolStripButton.ImageTransparentColor = System.Drawing.Color.White;
            this.startToolStripButton.Name = "startToolStripButton";
            this.startToolStripButton.Size = new System.Drawing.Size(23, 24);
            this.startToolStripButton.Text = "开始";
            this.startToolStripButton.Click += new System.EventHandler(this.startToolStripButton_Click);
            // 
            // faTabStripItem1
            // 
            this.faTabStripItem1.IsDrawn = true;
            this.faTabStripItem1.Name = "faTabStripItem1";
            this.faTabStripItem1.Size = new System.Drawing.Size(906, 153);
            this.faTabStripItem1.TabIndex = 0;
            this.faTabStripItem1.Title = "结果";
            // 
            // SQLQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 731);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SQLQueryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SQL查询器";
            this.Load += new System.EventHandler(this.SQLQueryForm_Load);
            this.Shown += new System.EventHandler(this.SQLQueryForm_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SQL_TS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabStrip)).EndInit();
            this.tabStrip.ResumeLayout(false);
            this.Result_FTSI.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_DTV)).EndInit();
            this.Message_FTSI.ResumeLayout(false);
            this.Message_FTSI.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private FarsiLibrary.Win.FATabStrip tabStrip;
        private FarsiLibrary.Win.FATabStripItem Result_FTSI;
        private FarsiLibrary.Win.FATabStripItem Message_FTSI;
        private System.Windows.Forms.DataGridView Grid_DTV;
        private System.Windows.Forms.TextBox Message_TB;
        private FarsiLibrary.Win.FATabStrip SQL_TS;
        private FarsiLibrary.Win.FATabStripItem faTabStripItem2;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton newTraceToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton startToolStripButton;
        private FarsiLibrary.Win.FATabStripItem faTabStripItem1;
 
    }
}