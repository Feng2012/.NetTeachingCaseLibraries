namespace SQLTrace.Controls
{
    partial class TraceViewControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.ExeSql_CMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.∏¥÷∆ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ºÙ«–ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.’≥Ã˘ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.÷¥––SQL”Ôæ‰ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridStyledPanel = new Attech.FlightMonitor.UI.Controls.StyledPanel();
            this.traceDataGridView = new System.Windows.Forms.DataGridView();
            this.detailsStyledPanel = new Attech.FlightMonitor.UI.Controls.StyledPanel();
            this.detailsTextBox = new System.Windows.Forms.TextBox();
            this.ExeSql_CMS.SuspendLayout();
            this.dataGridStyledPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.traceDataGridView)).BeginInit();
            this.detailsStyledPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 243);
            this.splitter1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1000, 3);
            this.splitter1.TabIndex = 10;
            this.splitter1.TabStop = false;
            // 
            // ExeSql_CMS
            // 
            this.ExeSql_CMS.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ExeSql_CMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.∏¥÷∆ToolStripMenuItem,
            this.ºÙ«–ToolStripMenuItem,
            this.’≥Ã˘ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.÷¥––SQL”Ôæ‰ToolStripMenuItem});
            this.ExeSql_CMS.Name = "contextMenuStrip1";
            this.ExeSql_CMS.Size = new System.Drawing.Size(182, 142);
            // 
            // ∏¥÷∆ToolStripMenuItem
            // 
            this.∏¥÷∆ToolStripMenuItem.Name = "∏¥÷∆ToolStripMenuItem";
            this.∏¥÷∆ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.∏¥÷∆ToolStripMenuItem.Text = "∏¥÷∆";
            this.∏¥÷∆ToolStripMenuItem.Click += new System.EventHandler(this.∏¥÷∆ToolStripMenuItem_Click);
            // 
            // ºÙ«–ToolStripMenuItem
            // 
            this.ºÙ«–ToolStripMenuItem.Name = "ºÙ«–ToolStripMenuItem";
            this.ºÙ«–ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.ºÙ«–ToolStripMenuItem.Text = "ºÙ«–";
            this.ºÙ«–ToolStripMenuItem.Click += new System.EventHandler(this.ºÙ«–ToolStripMenuItem_Click);
            // 
            // ’≥Ã˘ToolStripMenuItem
            // 
            this.’≥Ã˘ToolStripMenuItem.Name = "’≥Ã˘ToolStripMenuItem";
            this.’≥Ã˘ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.’≥Ã˘ToolStripMenuItem.Text = "’≥Ã˘";
            this.’≥Ã˘ToolStripMenuItem.Click += new System.EventHandler(this.’≥Ã˘ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(178, 6);
            // 
            // ÷¥––SQL”Ôæ‰ToolStripMenuItem
            // 
            this.÷¥––SQL”Ôæ‰ToolStripMenuItem.Name = "÷¥––SQL”Ôæ‰ToolStripMenuItem";
            this.÷¥––SQL”Ôæ‰ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.÷¥––SQL”Ôæ‰ToolStripMenuItem.Text = "÷¥––SQL”Ôæ‰";
            this.÷¥––SQL”Ôæ‰ToolStripMenuItem.Click += new System.EventHandler(this.÷¥––SQL”Ôæ‰ToolStripMenuItem_Click);
            // 
            // dataGridStyledPanel
            // 
            this.dataGridStyledPanel.BorderColor = System.Drawing.Color.Gray;
            this.dataGridStyledPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataGridStyledPanel.Controls.Add(this.traceDataGridView);
            this.dataGridStyledPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridStyledPanel.GradientColor1 = System.Drawing.Color.Empty;
            this.dataGridStyledPanel.GradientColor2 = System.Drawing.Color.Empty;
            this.dataGridStyledPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.dataGridStyledPanel.Location = new System.Drawing.Point(0, 0);
            this.dataGridStyledPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridStyledPanel.Name = "dataGridStyledPanel";
            this.dataGridStyledPanel.Size = new System.Drawing.Size(1000, 243);
            this.dataGridStyledPanel.TabIndex = 9;
            this.dataGridStyledPanel.UseGradientBackColor = false;
            // 
            // traceDataGridView
            // 
            this.traceDataGridView.AllowUserToAddRows = false;
            this.traceDataGridView.AllowUserToDeleteRows = false;
            this.traceDataGridView.AllowUserToOrderColumns = true;
            this.traceDataGridView.AllowUserToResizeRows = false;
            this.traceDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.traceDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.traceDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.traceDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.traceDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.traceDataGridView.Location = new System.Drawing.Point(1, 1);
            this.traceDataGridView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.traceDataGridView.Name = "traceDataGridView";
            this.traceDataGridView.ReadOnly = true;
            this.traceDataGridView.RowHeadersVisible = false;
            this.traceDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.traceDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.traceDataGridView.Size = new System.Drawing.Size(998, 241);
            this.traceDataGridView.TabIndex = 5;
            this.traceDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.traceDataGridView_RowsAdded);
            this.traceDataGridView.SelectionChanged += new System.EventHandler(this.traceDataGridView_SelectionChanged);
            // 
            // detailsStyledPanel
            // 
            this.detailsStyledPanel.BorderColor = System.Drawing.Color.Gray;
            this.detailsStyledPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.detailsStyledPanel.Controls.Add(this.detailsTextBox);
            this.detailsStyledPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.detailsStyledPanel.GradientColor1 = System.Drawing.Color.Empty;
            this.detailsStyledPanel.GradientColor2 = System.Drawing.Color.Empty;
            this.detailsStyledPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.detailsStyledPanel.Location = new System.Drawing.Point(0, 246);
            this.detailsStyledPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.detailsStyledPanel.Name = "detailsStyledPanel";
            this.detailsStyledPanel.Size = new System.Drawing.Size(1000, 257);
            this.detailsStyledPanel.TabIndex = 8;
            this.detailsStyledPanel.Text = "styledPanel1";
            this.detailsStyledPanel.UseGradientBackColor = false;
            // 
            // detailsTextBox
            // 
            this.detailsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.detailsTextBox.ContextMenuStrip = this.ExeSql_CMS;
            this.detailsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailsTextBox.Location = new System.Drawing.Point(1, 1);
            this.detailsTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.detailsTextBox.MaxLength = 327679999;
            this.detailsTextBox.Multiline = true;
            this.detailsTextBox.Name = "detailsTextBox";
            this.detailsTextBox.ReadOnly = true;
            this.detailsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.detailsTextBox.Size = new System.Drawing.Size(998, 255);
            this.detailsTextBox.TabIndex = 0;
            // 
            // TraceViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridStyledPanel);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.detailsStyledPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "TraceViewControl";
            this.Size = new System.Drawing.Size(1000, 503);
            this.ExeSql_CMS.ResumeLayout(false);
            this.dataGridStyledPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.traceDataGridView)).EndInit();
            this.detailsStyledPanel.ResumeLayout(false);
            this.detailsStyledPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView traceDataGridView;
        private Attech.FlightMonitor.UI.Controls.StyledPanel detailsStyledPanel;
        private Attech.FlightMonitor.UI.Controls.StyledPanel dataGridStyledPanel;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TextBox detailsTextBox;
        private System.Windows.Forms.ContextMenuStrip ExeSql_CMS;
        private System.Windows.Forms.ToolStripMenuItem ÷¥––SQL”Ôæ‰ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ∏¥÷∆ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ºÙ«–ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ’≥Ã˘ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    }
}
