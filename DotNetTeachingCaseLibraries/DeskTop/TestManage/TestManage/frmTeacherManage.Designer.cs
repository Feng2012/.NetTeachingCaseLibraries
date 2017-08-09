namespace TestManage
{
    partial class frmTeacherManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTeacherManage));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.labPassword = new System.Windows.Forms.Label();
            this.txbTeacherNo = new System.Windows.Forms.TextBox();
            this.labTeacheNo = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.ilistOpt = new System.Windows.Forms.ImageList(this.components);
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txbTeacherName = new System.Windows.Forms.TextBox();
            this.labTeacherName = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txbPassword);
            this.panel1.Controls.Add(this.labPassword);
            this.panel1.Controls.Add(this.txbTeacherNo);
            this.panel1.Controls.Add(this.labTeacheNo);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.txbTeacherName);
            this.panel1.Controls.Add(this.labTeacherName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 114);
            this.panel1.TabIndex = 0;
            // 
            // txbPassword
            // 
            this.txbPassword.Location = new System.Drawing.Point(76, 55);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.Size = new System.Drawing.Size(302, 21);
            this.txbPassword.TabIndex = 10;
            // 
            // labPassword
            // 
            this.labPassword.AutoSize = true;
            this.labPassword.Location = new System.Drawing.Point(12, 59);
            this.labPassword.Name = "labPassword";
            this.labPassword.Size = new System.Drawing.Size(65, 12);
            this.labPassword.TabIndex = 9;
            this.labPassword.Text = "密    码：";
            // 
            // txbTeacherNo
            // 
            this.txbTeacherNo.Location = new System.Drawing.Point(76, 30);
            this.txbTeacherNo.Name = "txbTeacherNo";
            this.txbTeacherNo.Size = new System.Drawing.Size(302, 21);
            this.txbTeacherNo.TabIndex = 8;
            // 
            // labTeacheNo
            // 
            this.labTeacheNo.AutoSize = true;
            this.labTeacheNo.Location = new System.Drawing.Point(12, 34);
            this.labTeacheNo.Name = "labTeacheNo";
            this.labTeacheNo.Size = new System.Drawing.Size(65, 12);
            this.labTeacheNo.TabIndex = 7;
            this.labTeacheNo.Text = "教师名称：";
            // 
            // btnDelete
            // 
            this.btnDelete.ImageIndex = 0;
            this.btnDelete.ImageList = this.ilistOpt;
            this.btnDelete.Location = new System.Drawing.Point(314, 80);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(65, 31);
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
            this.btnEdit.Location = new System.Drawing.Point(245, 80);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(65, 31);
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
            this.btnAdd.Location = new System.Drawing.Point(176, 80);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(65, 31);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "添加";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txbTeacherName
            // 
            this.txbTeacherName.Location = new System.Drawing.Point(76, 6);
            this.txbTeacherName.Name = "txbTeacherName";
            this.txbTeacherName.Size = new System.Drawing.Size(302, 21);
            this.txbTeacherName.TabIndex = 1;
            // 
            // labTeacherName
            // 
            this.labTeacherName.AutoSize = true;
            this.labTeacherName.Location = new System.Drawing.Point(12, 10);
            this.labTeacherName.Name = "labTeacherName";
            this.labTeacherName.Size = new System.Drawing.Size(65, 12);
            this.labTeacherName.TabIndex = 0;
            this.labTeacherName.Text = "教师名称：";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 114);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(390, 267);
            this.dgvData.TabIndex = 1;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            // 
            // frmTeacherManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 381);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTeacherManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "教师管理";
            this.Load += new System.EventHandler(this.frmClassSetting_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txbTeacherName;
        private System.Windows.Forms.Label labTeacherName;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ImageList ilistOpt;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox txbPassword;
        private System.Windows.Forms.Label labPassword;
        private System.Windows.Forms.TextBox txbTeacherNo;
        private System.Windows.Forms.Label labTeacheNo;
    }
}