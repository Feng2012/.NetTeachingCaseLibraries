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
            this.components = new System.ComponentModel.Container();
            this.labSubject = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txbQuestion = new System.Windows.Forms.TextBox();
            this.labQuestion = new System.Windows.Forms.Label();
            this.txbScore = new System.Windows.Forms.TextBox();
            this.labScore = new System.Windows.Forms.Label();
            this.txbNo = new System.Windows.Forms.TextBox();
            this.labNo = new System.Windows.Forms.Label();
            this.cmbTest = new System.Windows.Forms.ComboBox();
            this.cmbSujbect = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.labTest = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.cmsAddAnswer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加答案ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.cmsAddAnswer.SuspendLayout();
            this.SuspendLayout();
            // 
            // labSubject
            // 
            this.labSubject.AutoSize = true;
            this.labSubject.Location = new System.Drawing.Point(11, 15);
            this.labSubject.Name = "labSubject";
            this.labSubject.Size = new System.Drawing.Size(65, 12);
            this.labSubject.TabIndex = 7;
            this.labSubject.Text = "科目名称：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txbQuestion);
            this.panel1.Controls.Add(this.labQuestion);
            this.panel1.Controls.Add(this.txbScore);
            this.panel1.Controls.Add(this.labScore);
            this.panel1.Controls.Add(this.txbNo);
            this.panel1.Controls.Add(this.labNo);
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
            this.panel1.Size = new System.Drawing.Size(758, 156);
            this.panel1.TabIndex = 1;
            // 
            // txbQuestion
            // 
            this.txbQuestion.Location = new System.Drawing.Point(76, 64);
            this.txbQuestion.Multiline = true;
            this.txbQuestion.Name = "txbQuestion";
            this.txbQuestion.Size = new System.Drawing.Size(670, 50);
            this.txbQuestion.TabIndex = 16;
            // 
            // labQuestion
            // 
            this.labQuestion.AutoSize = true;
            this.labQuestion.Location = new System.Drawing.Point(35, 67);
            this.labQuestion.Name = "labQuestion";
            this.labQuestion.Size = new System.Drawing.Size(41, 12);
            this.labQuestion.TabIndex = 15;
            this.labQuestion.Text = "题目：";
            // 
            // txbScore
            // 
            this.txbScore.Location = new System.Drawing.Point(470, 37);
            this.txbScore.Name = "txbScore";
            this.txbScore.Size = new System.Drawing.Size(276, 21);
            this.txbScore.TabIndex = 13;
            // 
            // labScore
            // 
            this.labScore.AutoSize = true;
            this.labScore.Location = new System.Drawing.Point(426, 41);
            this.labScore.Name = "labScore";
            this.labScore.Size = new System.Drawing.Size(41, 12);
            this.labScore.TabIndex = 14;
            this.labScore.Text = "分值：";
            // 
            // txbNo
            // 
            this.txbNo.Location = new System.Drawing.Point(76, 37);
            this.txbNo.Name = "txbNo";
            this.txbNo.Size = new System.Drawing.Size(276, 21);
            this.txbNo.TabIndex = 11;
            // 
            // labNo
            // 
            this.labNo.AutoSize = true;
            this.labNo.Location = new System.Drawing.Point(35, 41);
            this.labNo.Name = "labNo";
            this.labNo.Size = new System.Drawing.Size(41, 12);
            this.labNo.TabIndex = 12;
            this.labNo.Text = "编号：";
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
            this.cmbTest.SelectedIndexChanged += new System.EventHandler(this.cmbTest_SelectedIndexChanged);
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
            this.cmbSujbect.SelectedIndexChanged += new System.EventHandler(this.cmbSujbect_SelectedIndexChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.ImageIndex = 0;
            this.btnDelete.Location = new System.Drawing.Point(681, 120);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(65, 31);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "删除";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.ImageIndex = 2;
            this.btnEdit.Location = new System.Drawing.Point(612, 120);
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
            this.btnAdd.Location = new System.Drawing.Point(543, 120);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(65, 31);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "添加";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // labTest
            // 
            this.labTest.AutoSize = true;
            this.labTest.Location = new System.Drawing.Point(402, 15);
            this.labTest.Name = "labTest";
            this.labTest.Size = new System.Drawing.Size(65, 12);
            this.labTest.TabIndex = 2;
            this.labTest.Text = "试卷名称：";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.ContextMenuStrip = this.cmsAddAnswer;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 156);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(758, 354);
            this.dgvData.TabIndex = 2;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            // 
            // cmsAddAnswer
            // 
            this.cmsAddAnswer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加答案ToolStripMenuItem});
            this.cmsAddAnswer.Name = "cmsAddAnswer";
            this.cmsAddAnswer.Size = new System.Drawing.Size(153, 48);
            // 
            // 添加答案ToolStripMenuItem
            // 
            this.添加答案ToolStripMenuItem.Name = "添加答案ToolStripMenuItem";
            this.添加答案ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.添加答案ToolStripMenuItem.Text = "添加答案";
            this.添加答案ToolStripMenuItem.Click += new System.EventHandler(this.添加答案ToolStripMenuItem_Click);
            // 
            // frmTestEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 510);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmTestEdit";
            this.Text = "试卷录入";
            this.Load += new System.EventHandler(this.frmTestEdit_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.cmsAddAnswer.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox txbQuestion;
        private System.Windows.Forms.Label labQuestion;
        private System.Windows.Forms.TextBox txbScore;
        private System.Windows.Forms.Label labScore;
        private System.Windows.Forms.TextBox txbNo;
        private System.Windows.Forms.Label labNo;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.ContextMenuStrip cmsAddAnswer;
        private System.Windows.Forms.ToolStripMenuItem 添加答案ToolStripMenuItem;
    }
}