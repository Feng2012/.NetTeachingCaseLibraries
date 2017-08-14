namespace TestManage
{
    partial class frmClassTestSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClassTestSetting));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbTest = new System.Windows.Forms.ComboBox();
            this.cmbSujbect = new System.Windows.Forms.ComboBox();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.labSubject = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.ilistOpt = new System.Windows.Forms.ImageList(this.components);
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.labTest = new System.Windows.Forms.Label();
            this.labClassName = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.chbIsValidate = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chbIsValidate);
            this.panel1.Controls.Add(this.cmbTest);
            this.panel1.Controls.Add(this.cmbSujbect);
            this.panel1.Controls.Add(this.cmbClass);
            this.panel1.Controls.Add(this.labSubject);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.labTest);
            this.panel1.Controls.Add(this.labClassName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(780, 271);
            this.panel1.TabIndex = 0;
            // 
            // cmbTest
            // 
            this.cmbTest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTest.FormattingEnabled = true;
            this.cmbTest.Location = new System.Drawing.Point(154, 112);
            this.cmbTest.Name = "cmbTest";
            this.cmbTest.Size = new System.Drawing.Size(547, 32);
            this.cmbTest.TabIndex = 10;
            // 
            // cmbSujbect
            // 
            this.cmbSujbect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSujbect.FormattingEnabled = true;
            this.cmbSujbect.Location = new System.Drawing.Point(154, 64);
            this.cmbSujbect.Name = "cmbSujbect";
            this.cmbSujbect.Size = new System.Drawing.Size(547, 32);
            this.cmbSujbect.TabIndex = 9;
            this.cmbSujbect.SelectedIndexChanged += new System.EventHandler(this.cmbSujbect_SelectedIndexChanged);
            // 
            // cmbClass
            // 
            this.cmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(154, 17);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(547, 32);
            this.cmbClass.TabIndex = 8;
            // 
            // labSubject
            // 
            this.labSubject.AutoSize = true;
            this.labSubject.Location = new System.Drawing.Point(24, 68);
            this.labSubject.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labSubject.Name = "labSubject";
            this.labSubject.Size = new System.Drawing.Size(130, 24);
            this.labSubject.TabIndex = 7;
            this.labSubject.Text = "科目名称：";
            // 
            // btnDelete
            // 
            this.btnDelete.ImageIndex = 0;
            this.btnDelete.ImageList = this.ilistOpt;
            this.btnDelete.Location = new System.Drawing.Point(628, 198);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(130, 62);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "删除";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ilistOpt
            // 
            this.ilistOpt.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilistOpt.ImageStream")));
            this.ilistOpt.TransparentColor = System.Drawing.Color.Transparent;
            this.ilistOpt.Images.SetKeyName(0, "Add.png");
            this.ilistOpt.Images.SetKeyName(1, "Del.png");
            this.ilistOpt.Images.SetKeyName(2, "Edit.png");
            // 
            // btnEdit
            // 
            this.btnEdit.ImageIndex = 2;
            this.btnEdit.ImageList = this.ilistOpt;
            this.btnEdit.Location = new System.Drawing.Point(490, 198);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(6);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(130, 62);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "修改";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.ImageIndex = 0;
            this.btnAdd.ImageList = this.ilistOpt;
            this.btnAdd.Location = new System.Drawing.Point(352, 198);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(130, 62);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "添加";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // labTest
            // 
            this.labTest.AutoSize = true;
            this.labTest.Location = new System.Drawing.Point(24, 116);
            this.labTest.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labTest.Name = "labTest";
            this.labTest.Size = new System.Drawing.Size(130, 24);
            this.labTest.TabIndex = 2;
            this.labTest.Text = "试卷名称：";
            // 
            // labClassName
            // 
            this.labClassName.AutoSize = true;
            this.labClassName.Location = new System.Drawing.Point(24, 21);
            this.labClassName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labClassName.Name = "labClassName";
            this.labClassName.Size = new System.Drawing.Size(130, 24);
            this.labClassName.TabIndex = 0;
            this.labClassName.Text = "班级名称：";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 271);
            this.dgvData.Margin = new System.Windows.Forms.Padding(6);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(780, 491);
            this.dgvData.TabIndex = 1;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            // 
            // chbIsValidate
            // 
            this.chbIsValidate.AutoSize = true;
            this.chbIsValidate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbIsValidate.Location = new System.Drawing.Point(24, 160);
            this.chbIsValidate.Name = "chbIsValidate";
            this.chbIsValidate.Size = new System.Drawing.Size(162, 28);
            this.chbIsValidate.TabIndex = 11;
            this.chbIsValidate.Text = "是否有效：";
            this.chbIsValidate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbIsValidate.UseVisualStyleBackColor = true;
            // 
            // frmClassTestSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 762);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmClassTestSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "班级管理";
            this.Load += new System.EventHandler(this.frmClassSetting_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label labTest;
        private System.Windows.Forms.Label labClassName;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ImageList ilistOpt;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ComboBox cmbTest;
        private System.Windows.Forms.ComboBox cmbSujbect;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Label labSubject;
        private System.Windows.Forms.CheckBox chbIsValidate;
    }
}