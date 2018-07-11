namespace PgtableGenerateTool
{
    partial class frmMessage
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
            this.components = new System.ComponentModel.Container();
            this.labMessage = new System.Windows.Forms.Label();
            this.picLoad = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.labTimes = new System.Windows.Forms.Label();
            this.tmrCount = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picLoad)).BeginInit();
            this.SuspendLayout();
            // 
            // labMessage
            // 
            this.labMessage.AutoSize = true;
            this.labMessage.BackColor = System.Drawing.Color.White;
            this.labMessage.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.labMessage.ForeColor = System.Drawing.Color.Red;
            this.labMessage.Location = new System.Drawing.Point(8, 178);
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(109, 19);
            this.labMessage.TabIndex = 0;
            this.labMessage.Text = "正在搬运XXX表";
            // 
            // picLoad
            // 
            this.picLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picLoad.Image = global::PgtableGenerateTool.Properties.Resources.migration;
            this.picLoad.Location = new System.Drawing.Point(5, 5);
            this.picLoad.Name = "picLoad";
            this.picLoad.Size = new System.Drawing.Size(420, 203);
            this.picLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLoad.TabIndex = 1;
            this.picLoad.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("华文细黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(397, 182);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(25, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "╳";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // labTimes
            // 
            this.labTimes.AutoSize = true;
            this.labTimes.BackColor = System.Drawing.Color.White;
            this.labTimes.Location = new System.Drawing.Point(148, 135);
            this.labTimes.Name = "labTimes";
            this.labTimes.Size = new System.Drawing.Size(113, 12);
            this.labTimes.TabIndex = 3;
            this.labTimes.Text = "用时000000000000秒";
            // 
            // tmrCount
            // 
            this.tmrCount.Interval = 1000;
            this.tmrCount.Tick += new System.EventHandler(this.tmrCount_Tick);
            // 
            // frmMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(430, 213);
            this.Controls.Add(this.labTimes);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.labMessage);
            this.Controls.Add(this.picLoad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMessage";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMessage";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.picLoad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label labMessage;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label labTimes;
        public System.Windows.Forms.Timer tmrCount;
        public System.Windows.Forms.PictureBox picLoad;
    }
}