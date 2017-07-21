namespace SQLTrace.Controls
{
    partial class EventTracePropertiesControl
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
            this.captionLabel = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.selectUnSelectCheckBox = new System.Windows.Forms.CheckBox();
            this.Des_Lab = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // captionLabel
            // 
            this.captionLabel.AutoSize = true;
            this.captionLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.captionLabel.Location = new System.Drawing.Point(0, 0);
            this.captionLabel.Name = "captionLabel";
            this.captionLabel.Size = new System.Drawing.Size(53, 12);
            this.captionLabel.TabIndex = 0;
            this.captionLabel.Text = "事件选择";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 12);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(423, 265);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellMouseEnter);
            this.dataGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridView_CurrentCellDirtyStateChanged);
            // 
            // selectUnSelectCheckBox
            // 
            this.selectUnSelectCheckBox.AutoSize = true;
            this.selectUnSelectCheckBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.selectUnSelectCheckBox.Location = new System.Drawing.Point(0, 309);
            this.selectUnSelectCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.selectUnSelectCheckBox.Name = "selectUnSelectCheckBox";
            this.selectUnSelectCheckBox.Size = new System.Drawing.Size(423, 16);
            this.selectUnSelectCheckBox.TabIndex = 2;
            this.selectUnSelectCheckBox.Text = "全选/反选 事件";
            this.selectUnSelectCheckBox.UseVisualStyleBackColor = true;
            this.selectUnSelectCheckBox.CheckedChanged += new System.EventHandler(this.selectUnSelectCheckBox_CheckedChanged);
            // 
            // Des_Lab
            // 
            this.Des_Lab.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Des_Lab.Location = new System.Drawing.Point(0, 277);
            this.Des_Lab.Name = "Des_Lab";
            this.Des_Lab.Size = new System.Drawing.Size(423, 32);
            this.Des_Lab.TabIndex = 5;
            this.Des_Lab.Text = "说明";
            // 
            // EventTracePropertiesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.Des_Lab);
            this.Controls.Add(this.selectUnSelectCheckBox);
            this.Controls.Add(this.captionLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "EventTracePropertiesControl";
            this.Size = new System.Drawing.Size(423, 325);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label captionLabel;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.CheckBox selectUnSelectCheckBox;
        private System.Windows.Forms.Label Des_Lab;
    }
}
