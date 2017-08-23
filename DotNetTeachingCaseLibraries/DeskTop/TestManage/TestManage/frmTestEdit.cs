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
    public partial class frmTestEdit : Form
    {
        int _selectID;
        /// <summary>
        /// 科目对象
        /// </summary>
        ISubjectRepository _subjectRepository;

        /// <summary>
        /// 试卷对象
        /// </summary>
        ITestRepository _testRepository;
        /// <summary>
        /// 题目对象
        /// </summary>
        IQuestionRepository _questionRepository;
        public frmTestEdit( ISubjectRepository subjectRepository, ITestRepository testRepository,IQuestionRepository questionRepository)
        {
            InitializeComponent();
        
            _subjectRepository = subjectRepository;
            _testRepository = testRepository;
            _questionRepository = questionRepository;
        }

        private void frmTestEdit_Load(object sender, EventArgs e)
        {
            cmbSujbect.DataSource = _subjectRepository.GetSubjects();
            cmbSujbect.DisplayMember = "科目名称";
            cmbSujbect.ValueMember = "编号";
           
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var question = new Question();
                question.No = txbNo.Text;
                question.FullScore = Convert.ToDouble(txbScore.Text);
                question.Question1 = txbQuestion.Text;
                question.TestID = Convert.ToInt32(cmbTest.Text);             

                if (_questionRepository.AddQuestion(question))
                {
                    ClearData();
                    dgvData.DataSource = _questionRepository.GetQuestionsByTestID(Convert.ToInt32(cmbTest.SelectedValue));
                }
                else
                {
                    MessageBox.Show("添加失败！");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectID > 0)
                {
                   
                    var question = new Question();
                    question.ID = _selectID;
                    question.No = txbNo.Text;
                    question.FullScore = Convert.ToDouble(txbScore.Text);
                    question.Question1 = txbQuestion.Text;
                    question.TestID = Convert.ToInt32(cmbTest.Text);

                    if (_questionRepository.ModifyQuestion(question))
                    {
                        ClearData();
                        dgvData.DataSource = _questionRepository.GetQuestionsByTestID(Convert.ToInt32(cmbTest.SelectedValue));
                    }
                    else
                    {
                        MessageBox.Show("修改失败！");
                    }
                }
                else
                {
                    MessageBox.Show("请双击选择！");

                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        /// <summary>
        /// 双击获取选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                _selectID = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["编号"].Value);
                txbNo.Text = dgvData.Rows[e.RowIndex].Cells["题目编号"].Value.ToString();
                txbQuestion.Text= dgvData.Rows[e.RowIndex].Cells["题目名称"].Value.ToString();
                txbScore.Text = dgvData.Rows[e.RowIndex].Cells["满分"].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectID > 0)
                {
                    if (MessageBox.Show("你确定要删除吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (_questionRepository.RemoveQuestion(_selectID))
                        {
                            ClearData();
                            dgvData.DataSource = _subjectRepository.GetSubjects();
                        }
                        else
                        {
                            MessageBox.Show("删除失败！");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请双击选择！");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        /// <summary>
        /// 清空窗体数据
        /// </summary>
        void ClearData()
        {
            _selectID = 0;
            txbNo.Clear();
            txbQuestion.Clear();
            txbScore.Clear();
        }

        private void cmbSujbect_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbTest.DataSource = _testRepository.GetTests(Convert.ToInt32(cmbSujbect.SelectedValue));
            cmbTest.DisplayMember = "试卷名称";
            cmbTest.ValueMember = "编号";
         
        }

        private void cmbTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvData.DataSource = _questionRepository.GetQuestionsByTestID(Convert.ToInt32(cmbTest.SelectedValue));
        }
    }
}
