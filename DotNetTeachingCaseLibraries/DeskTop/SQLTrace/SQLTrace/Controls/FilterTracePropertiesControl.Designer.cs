namespace SQLTrace.Controls
{
    partial class FilterTracePropertiesControl
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.captionLabel = new System.Windows.Forms.Label();
            this.Des_Lab = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 12);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(400, 251);
            this.dataGridView.TabIndex = 3;
            this.dataGridView.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellMouseEnter);
            this.dataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellValueChanged);
            // 
            // captionLabel
            // 
            this.captionLabel.AutoSize = true;
            this.captionLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.captionLabel.Location = new System.Drawing.Point(0, 0);
            this.captionLabel.Name = "captionLabel";
            this.captionLabel.Size = new System.Drawing.Size(53, 12);
            this.captionLabel.TabIndex = 2;
            this.captionLabel.Text = "过滤设置";
            // 
            // Des_Lab
            // 
            this.Des_Lab.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Des_Lab.Location = new System.Drawing.Point(0, 263);
            this.Des_Lab.Name = "Des_Lab";
            this.Des_Lab.Size = new System.Drawing.Size(400, 32);
            this.Des_Lab.TabIndex = 4;
            this.Des_Lab.Text = "说明";
            // 
            // FilterTracePropertiesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.Des_Lab);
            this.Controls.Add(this.captionLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FilterTracePropertiesControl";
            this.Size = new System.Drawing.Size(400, 295);
            this.Load += new System.EventHandler(this.FilterTracePropertiesControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label captionLabel;
        private System.Windows.Forms.Label Des_Lab;
    }
}
