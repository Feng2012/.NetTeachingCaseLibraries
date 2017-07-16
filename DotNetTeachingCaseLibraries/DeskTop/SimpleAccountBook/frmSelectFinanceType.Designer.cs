namespace SimpleAccountBook
{
    partial class frmSelectFinanceType
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
            this.trvFinanceType = new System.Windows.Forms.TreeView();
            this.cmsNodeOpt = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除类型ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsNodeOpt.SuspendLayout();
            this.SuspendLayout();
            // 
            // trvFinanceType
            // 
            this.trvFinanceType.ContextMenuStrip = this.cmsNodeOpt;
            this.trvFinanceType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvFinanceType.Location = new System.Drawing.Point(0, 0);
            this.trvFinanceType.Name = "trvFinanceType";
            this.trvFinanceType.Size = new System.Drawing.Size(362, 340);
            this.trvFinanceType.TabIndex = 0;
            this.trvFinanceType.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvFinanceType_NodeMouseDoubleClick);
            // 
            // cmsNodeOpt
            // 
            this.cmsNodeOpt.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除类型ToolStripMenuItem});
            this.cmsNodeOpt.Name = "cmsNodeOpt";
            this.cmsNodeOpt.Size = new System.Drawing.Size(125, 26);
            // 
            // 删除类型ToolStripMenuItem
            // 
            this.删除类型ToolStripMenuItem.Name = "删除类型ToolStripMenuItem";
            this.删除类型ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除类型ToolStripMenuItem.Text = "删除类型";
            this.删除类型ToolStripMenuItem.Click += new System.EventHandler(this.删除类型ToolStripMenuItem_Click);
            // 
            // frmSelectFinanceType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 340);
            this.Controls.Add(this.trvFinanceType);
            this.Name = "frmSelectFinanceType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择财务类型";
            this.Load += new System.EventHandler(this.frmFinanceType_Load);
            this.cmsNodeOpt.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView trvFinanceType;
        private System.Windows.Forms.ContextMenuStrip cmsNodeOpt;
        private System.Windows.Forms.ToolStripMenuItem 删除类型ToolStripMenuItem;
    }
}