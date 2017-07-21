namespace SQLTrace.Controls
{
    partial class NewIssueForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewIssueForm));
            this.exceptionLabel = new System.Windows.Forms.Label();
            this.exceptionTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // exceptionLabel
            // 
            this.exceptionLabel.AutoSize = true;
            this.exceptionLabel.Location = new System.Drawing.Point(14, 14);
            this.exceptionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.exceptionLabel.Name = "exceptionLabel";
            this.exceptionLabel.Size = new System.Drawing.Size(75, 15);
            this.exceptionLabel.TabIndex = 2;
            this.exceptionLabel.Text = "异常信息:";
            // 
            // exceptionTextBox
            // 
            this.exceptionTextBox.Location = new System.Drawing.Point(21, 37);
            this.exceptionTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.exceptionTextBox.MaxLength = 9327679;
            this.exceptionTextBox.Multiline = true;
            this.exceptionTextBox.Name = "exceptionTextBox";
            this.exceptionTextBox.ReadOnly = true;
            this.exceptionTextBox.Size = new System.Drawing.Size(508, 281);
            this.exceptionTextBox.TabIndex = 3;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(221, 325);
            this.okButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(100, 27);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "继续";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // NewIssueForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 359);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.exceptionTextBox);
            this.Controls.Add(this.exceptionLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewIssueForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "发生异常！";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label exceptionLabel;
        private System.Windows.Forms.TextBox exceptionTextBox;
        private System.Windows.Forms.Button okButton;
    }
}