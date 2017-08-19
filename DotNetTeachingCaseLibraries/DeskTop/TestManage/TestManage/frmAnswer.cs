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
    public partial class frmAnswer : Form
    {

        /// <summary>
        /// 试卷对象
        /// </summary>
        IAnswerRepository _answerRepository;
        /// <summary>
        /// 编辑ID
        /// </summary>
        int _selectID;

        int _questionID;
        public frmAnswer(IAnswerRepository answerRepository, int questionID)
        {
            InitializeComponent();

            _answerRepository = answerRepository;
            _questionID = questionID;
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            dgvData.DataSource = _answerRepository.GetAnswers(_questionID);
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
                var answer = new Answer();
                answer.Answer1 = txbAnswer.Text;
                answer.IsAnswer = chbIsAnswer.Checked;
                answer.QuestionID = _questionID;

                if (_answerRepository.AddAnswer(answer))
                {
                    ClearData();
                    dgvData.DataSource = _answerRepository.GetAnswers(_questionID);
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
                    var answer = new Answer();
                    answer.ID = _selectID;
                    answer.Answer1 = txbAnswer.Text;
                    answer.IsAnswer = chbIsAnswer.Checked;
                    answer.QuestionID = _questionID;
                    if (_answerRepository.ModifyAnswer(answer))
                    {
                        ClearData();
                        dgvData.DataSource = _answerRepository.GetAnswers(_questionID);
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
                txbAnswer.Text = dgvData.Rows[e.RowIndex].Cells["答案"].Value.ToString();
                chbIsAnswer.Checked = Convert.ToBoolean(dgvData.Rows[e.RowIndex].Cells["是否正确答案"].Value);
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
                        if (_answerRepository.RemoveAnswer(_selectID))
                        {
                            ClearData();
                            dgvData.DataSource = _answerRepository.GetAnswers(_questionID);
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
            txbAnswer.Clear();
        }
    }
}
