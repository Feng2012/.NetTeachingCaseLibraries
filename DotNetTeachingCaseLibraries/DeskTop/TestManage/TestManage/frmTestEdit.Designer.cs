namespace TestManage
{
    partial class frmTestEdit
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
            this.labSubject = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbTest = new System.Windows.Forms.ComboBox();
            this.cmbSujbect = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.labTest = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labSubject
            // 
            this.labSubject.AutoSize = true;
            this.labSubject.Location = new System.Drawing.Point(11, 13);
            this.labSubject.Name = "labSubject";
            this.labSubject.Size = new System.Drawing.Size(65, 12);
            this.labSubject.TabIndex = 7;
            this.labSubject.Text = "科目名称：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbTest);
            this.panel1.Controls.Add(this.cmbSujbect);
            this.panel1.Controls.Add(this.labSubject);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.labTest);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(810, 85);
            this.panel1.TabIndex = 1;
            // 
            // cmbTest
            // 
            this.cmbTest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTest.FormattingEnabled = true;
            this.cmbTest.Location = new System.Drawing.Point(470, 11);
            this.cmbTest.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTest.Name = "cmbTest";
            this.cmbTest.Size = new System.Drawing.Size(276, 20);
            this.cmbTest.TabIndex = 10;
            // 
            // cmbSujbect
            // 
            this.cmbSujbect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSujbect.FormattingEnabled = true;
            this.cmbSujbect.Location = new System.Drawing.Point(76, 11);
            this.cmbSujbect.Margin = new System.Windows.Forms.Padding(2);
            this.cmbSujbect.Name = "cmbSujbect";
            this.cmbSujbect.Size = new System.Drawing.Size(276, 20);
            this.cmbSujbect.TabIndex = 9;
            // 
            // btnDelete
            // 
            this.btnDelete.ImageIndex = 0;
            this.btnDelete.Location = new System.Drawing.Point(691, 36);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(65, 31);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "删除";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.ImageIndex = 2;
            this.btnEdit.Location = new System.Drawing.Point(622, 36);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(65, 31);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "修改";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.ImageIndex = 0;
            this.btnAdd.Location = new System.Drawing.Point(553, 36);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(65, 31);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "添加";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // labTest
            // 
            this.labTest.AutoSize = true;
            this.labTest.Location = new System.Drawing.Point(405, 13);
            this.labTest.Name = "labTest";
            this.labTest.Size = new System.Drawing.Size(65, 12);
            this.labTest.TabIndex = 2;
            this.labTest.Text = "试卷名称：";
            // 
            // frmTestEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 510);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmTestEdit";
            this.Text = "试卷录入";
            this.Load += new System.EventHandler(this.frmTestEdit_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labSubject;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbTest;
        private System.Windows.Forms.ComboBox cmbSujbect;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label labTest;
    }
}