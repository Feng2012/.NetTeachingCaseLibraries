using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestManage.BLL;
using TestManage.DDL;

namespace TestManage
{
    public partial class frmTest : Form
    {
        /// <summary>
        /// 试卷对象
        /// </summary>
        ITestRepository _testRepository;
        /// <summary>
        /// 班级考试对象
        /// </summary>
        IClassTestRepository _classTestRepository;
        public frmTest(ITestRepository testRepository, IClassTestRepository classTestRepository)
        {
            InitializeComponent();
            _testRepository = testRepository;
            _classTestRepository = classTestRepository;
        }
        /// <summary>
        /// 考试学生
        /// </summary>
        public Student TestStudent
        { get; set; }


        /// <summary>
        /// 当前问题
        /// </summary>
        List<Question> questions;
        /// <summary>
        /// 当前问题
        /// </summary>
        int questionIndex = 0;

        private void frmTest_Load(object sender, EventArgs e)
        {
            var test = _classTestRepository.GetTestByClassID(TestStudent.ClassID.Value);
            labTestName.Text = test.TestName;
            labClassName.Text = TestStudent.Class.ClassName;
            labStudentName.Text = TestStudent.Name;
            labStudentCardID.Text = TestStudent.CardID;

            questions = test.Questions.ToList();
            SetQuestion(questionIndex);
        }
        /// <summary>
        /// 设置题目和答案
        /// </summary>
        /// <param name="questionIndex">题目索引</param>
        void SetQuestion(int questionIndex)
        {
            var question = questions[questionIndex];
            labQuestionName.Text = $"{question.No}、{question.Question1}(满分：{question.FullScore})";
            foreach (var answer in question.Answers)
            {
                var radAnswer = new RadioButton() { AutoSize = false, Dock = DockStyle.Top, Padding = new Padding() { Top = 5 }, Text = $"{answer.Answer1}", Tag = answer.ID };
                palAnswer.Controls.Add(radAnswer);
            }
        }

        private void butNext_Click(object sender, EventArgs e)
        {
            if (questionIndex < questions.Count - 1)
            {
                questionIndex++;
                butNext.Enabled = true;
            }
            else
            {
                butNext.Enabled = false;
                questionIndex = questions.Count - 1;
            }
            SetQuestion(questionIndex);
            labMessage.Text = $"已解答{questionIndex}道题！";
        }

        private void butPrevious_Click(object sender, EventArgs e)
        {
            if (questionIndex > 0)
            {
                questionIndex--;
                butPrevious.Enabled = true;
            }
            else
            {
                butPrevious.Enabled = false;
                questionIndex = 0;
            }
            SetQuestion(questionIndex);
        }
    }
}
