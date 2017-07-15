namespace SimpleAccountBook
{
    partial class frmFinanceType
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
            this.txbFinanceTypeName = new System.Windows.Forms.TextBox();
            this.btnAddChild = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmsNodeOpt = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除类型ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.cmsNodeOpt.SuspendLayout();
            this.SuspendLayout();
            // 
            // trvFinanceType
            // 
            this.trvFinanceType.ContextMenuStrip = this.cmsNodeOpt;
            this.trvFinanceType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvFinanceType.Location = new System.Drawing.Point(0, 36);
            this.trvFinanceType.Name = "trvFinanceType";
            this.trvFinanceType.Size = new System.Drawing.Size(362, 304);
            this.trvFinanceType.TabIndex = 0;
            // 
            // txbFinanceTypeName
            // 
            this.txbFinanceTypeName.Location = new System.Drawing.Point(5, 7);
            this.txbFinanceTypeName.Name = "txbFinanceTypeName";
            this.txbFinanceTypeName.Size = new System.Drawing.Size(265, 21);
            this.txbFinanceTypeName.TabIndex = 1;
            // 
            // btnAddChild
            // 
            this.btnAddChild.Location = new System.Drawing.Point(276, 6);
            this.btnAddChild.Name = "btnAddChild";
            this.btnAddChild.Size = new System.Drawing.Size(75, 23);
            this.btnAddChild.TabIndex = 2;
            this.btnAddChild.Text = "添加子项";
            this.btnAddChild.UseVisualStyleBackColor = true;
            this.btnAddChild.Click += new System.EventHandler(this.btnAddChild_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txbFinanceTypeName);
            this.panel1.Controls.Add(this.btnAddChild);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(362, 36);
            this.panel1.TabIndex = 3;
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
            this.删除类型ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.删除类型ToolStripMenuItem.Text = "删除类型";
            this.删除类型ToolStripMenuItem.Click += new System.EventHandler(this.删除类型ToolStripMenuItem_Click);
            // 
            // frmFinanceType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 340);
            this.Controls.Add(this.trvFinanceType);
            this.Controls.Add(this.panel1);
            this.Name = "frmFinanceType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "财务类型设置";
            this.Load += new System.EventHandler(this.frmFinanceType_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.cmsNodeOpt.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView trvFinanceType;
        private System.Windows.Forms.TextBox txbFinanceTypeName;
        private System.Windows.Forms.Button btnAddChild;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip cmsNodeOpt;
        private System.Windows.Forms.ToolStripMenuItem 删除类型ToolStripMenuItem;
    }
}