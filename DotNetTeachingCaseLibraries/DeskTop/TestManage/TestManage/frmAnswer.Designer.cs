namespace TestManage
{
    partial class frmAnswer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAnswer));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.ilistOpt = new System.Windows.Forms.ImageList(this.components);
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txbAnswer = new System.Windows.Forms.TextBox();
            this.labSubjectName = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.labQuestion = new System.Windows.Forms.Label();
            this.labQuestionContent = new System.Windows.Forms.Label();
            this.labIsAnswer = new System.Windows.Forms.Label();
            this.chbIsAnswer = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chbIsAnswer);
            this.panel1.Controls.Add(this.labIsAnswer);
            this.panel1.Controls.Add(this.labQuestionContent);
            this.panel1.Controls.Add(this.labQuestion);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.txbAnswer);
            this.panel1.Controls.Add(this.labSubjectName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(504, 199);
            this.panel1.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.ImageIndex = 0;
            this.btnDelete.ImageList = this.ilistOpt;
            this.btnDelete.Location = new System.Drawing.Point(427, 161);
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
            this.btnEdit.Location = new System.Drawing.Point(358, 161);
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
            this.btnAdd.Location = new System.Drawing.Point(289, 161);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(65, 31);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "添加";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txbAnswer
            // 
            this.txbAnswer.Location = new System.Drawing.Point(59, 93);
            this.txbAnswer.Multiline = true;
            this.txbAnswer.Name = "txbAnswer";
            this.txbAnswer.Size = new System.Drawing.Size(433, 61);
            this.txbAnswer.TabIndex = 1;
            // 
            // labSubjectName
            // 
            this.labSubjectName.AutoSize = true;
            this.labSubjectName.Location = new System.Drawing.Point(12, 97);
            this.labSubjectName.Name = "labSubjectName";
            this.labSubjectName.Size = new System.Drawing.Size(41, 12);
            this.labSubjectName.TabIndex = 0;
            this.labSubjectName.Text = "答案：";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 199);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(504, 247);
            this.dgvData.TabIndex = 1;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            // 
            // labQuestion
            // 
            this.labQuestion.AutoSize = true;
            this.labQuestion.Location = new System.Drawing.Point(13, 13);
            this.labQuestion.Name = "labQuestion";
            this.labQuestion.Size = new System.Drawing.Size(41, 12);
            this.labQuestion.TabIndex = 7;
            this.labQuestion.Text = "题目：";
            // 
            // labQuestionContent
            // 
            this.labQuestionContent.Location = new System.Drawing.Point(57, 13);
            this.labQuestionContent.Name = "labQuestionContent";
            this.labQuestionContent.Size = new System.Drawing.Size(435, 78);
            this.labQuestionContent.TabIndex = 8;
            this.labQuestionContent.Text = "题目内容";
            // 
            // labIsAnswer
            // 
            this.labIsAnswer.AutoSize = true;
            this.labIsAnswer.Location = new System.Drawing.Point(13, 169);
            this.labIsAnswer.Name = "labIsAnswer";
            this.labIsAnswer.Size = new System.Drawing.Size(89, 12);
            this.labIsAnswer.TabIndex = 9;
            this.labIsAnswer.Text = "是否正确答案：";
            // 
            // chbIsAnswer
            // 
            this.chbIsAnswer.AutoSize = true;
            this.chbIsAnswer.Location = new System.Drawing.Point(104, 168);
            this.chbIsAnswer.Name = "chbIsAnswer";
            this.chbIsAnswer.Size = new System.Drawing.Size(15, 14);
            this.chbIsAnswer.TabIndex = 10;
            this.chbIsAnswer.UseVisualStyleBackColor = true;
            // 
            // frmAnswer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 446);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAnswer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "答案管理";
            this.Load += new System.EventHandler(this.frmSetting_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txbAnswer;
        private System.Windows.Forms.Label labSubjectName;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ImageList ilistOpt;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.CheckBox chbIsAnswer;
        private System.Windows.Forms.Label labIsAnswer;
        private System.Windows.Forms.Label labQuestionContent;
        private System.Windows.Forms.Label labQuestion;
    }
}