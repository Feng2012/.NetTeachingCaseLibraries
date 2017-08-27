namespace TestManage
{
    partial class frmTest
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
            this.labTestName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labStudentCardID = new System.Windows.Forms.Label();
            this.labStudentName = new System.Windows.Forms.Label();
            this.labClassName = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.palAnswer = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.labMessage = new System.Windows.Forms.Label();
            this.butNext = new System.Windows.Forms.Button();
            this.butPrevious = new System.Windows.Forms.Button();
            this.labQuestionName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // labTestName
            // 
            this.labTestName.Dock = System.Windows.Forms.DockStyle.Top;
            this.labTestName.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTestName.Location = new System.Drawing.Point(10, 10);
            this.labTestName.Name = "labTestName";
            this.labTestName.Size = new System.Drawing.Size(928, 22);
            this.labTestName.TabIndex = 0;
            this.labTestName.Text = "试卷名称";
            this.labTestName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.labTestName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(948, 77);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labStudentCardID);
            this.panel2.Controls.Add(this.labStudentName);
            this.panel2.Controls.Add(this.labClassName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(10, 32);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(928, 40);
            this.panel2.TabIndex = 1;
            // 
            // labStudentCardID
            // 
            this.labStudentCardID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labStudentCardID.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labStudentCardID.Location = new System.Drawing.Point(388, 10);
            this.labStudentCardID.Name = "labStudentCardID";
            this.labStudentCardID.Size = new System.Drawing.Size(530, 20);
            this.labStudentCardID.TabIndex = 3;
            this.labStudentCardID.Text = "身份证";
            this.labStudentCardID.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labStudentName
            // 
            this.labStudentName.Dock = System.Windows.Forms.DockStyle.Left;
            this.labStudentName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labStudentName.Location = new System.Drawing.Point(248, 10);
            this.labStudentName.Name = "labStudentName";
            this.labStudentName.Size = new System.Drawing.Size(140, 20);
            this.labStudentName.TabIndex = 2;
            this.labStudentName.Text = "学生名称";
            this.labStudentName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labClassName
            // 
            this.labClassName.Dock = System.Windows.Forms.DockStyle.Left;
            this.labClassName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labClassName.Location = new System.Drawing.Point(10, 10);
            this.labClassName.Name = "labClassName";
            this.labClassName.Size = new System.Drawing.Size(238, 20);
            this.labClassName.TabIndex = 1;
            this.labClassName.Text = "班级名称";
            this.labClassName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.palAnswer);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.labQuestionName);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 77);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10);
            this.panel3.Size = new System.Drawing.Size(948, 573);
            this.panel3.TabIndex = 2;
            // 
            // palAnswer
            // 
            this.palAnswer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palAnswer.Location = new System.Drawing.Point(10, 226);
            this.palAnswer.Name = "palAnswer";
            this.palAnswer.Size = new System.Drawing.Size(928, 278);
            this.palAnswer.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.labMessage);
            this.panel5.Controls.Add(this.butNext);
            this.panel5.Controls.Add(this.butPrevious);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(10, 504);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(928, 59);
            this.panel5.TabIndex = 3;
            // 
            // labMessage
            // 
            this.labMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labMessage.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labMessage.ForeColor = System.Drawing.Color.Red;
            this.labMessage.Location = new System.Drawing.Point(248, 0);
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(432, 59);
            this.labMessage.TabIndex = 2;
            this.labMessage.Text = "已解答10道题目。";
            // 
            // butNext
            // 
            this.butNext.Dock = System.Windows.Forms.DockStyle.Right;
            this.butNext.Font = new System.Drawing.Font("宋体", 16F);
            this.butNext.Location = new System.Drawing.Point(680, 0);
            this.butNext.Name = "butNext";
            this.butNext.Size = new System.Drawing.Size(248, 59);
            this.butNext.TabIndex = 1;
            this.butNext.Text = "下一题";
            this.butNext.UseVisualStyleBackColor = true;
            this.butNext.Click += new System.EventHandler(this.butNext_Click);
            // 
            // butPrevious
            // 
            this.butPrevious.Dock = System.Windows.Forms.DockStyle.Left;
            this.butPrevious.Enabled = false;
            this.butPrevious.Font = new System.Drawing.Font("宋体", 16F);
            this.butPrevious.Location = new System.Drawing.Point(0, 0);
            this.butPrevious.Name = "butPrevious";
            this.butPrevious.Size = new System.Drawing.Size(248, 59);
            this.butPrevious.TabIndex = 0;
            this.butPrevious.Text = "上一题";
            this.butPrevious.UseVisualStyleBackColor = true;
            this.butPrevious.Click += new System.EventHandler(this.butPrevious_Click);
            // 
            // labQuestionName
            // 
            this.labQuestionName.Dock = System.Windows.Forms.DockStyle.Top;
            this.labQuestionName.Font = new System.Drawing.Font("宋体", 12F);
            this.labQuestionName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labQuestionName.Location = new System.Drawing.Point(10, 10);
            this.labQuestionName.Name = "labQuestionName";
            this.labQuestionName.Size = new System.Drawing.Size(928, 216);
            this.labQuestionName.TabIndex = 1;
            this.labQuestionName.Text = "题目名称";
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 650);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "考试";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTest_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labTestName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labStudentName;
        private System.Windows.Forms.Label labClassName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labQuestionName;
        private System.Windows.Forms.Panel palAnswer;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label labMessage;
        private System.Windows.Forms.Button butNext;
        private System.Windows.Forms.Button butPrevious;
        private System.Windows.Forms.Label labStudentCardID;
    }
}