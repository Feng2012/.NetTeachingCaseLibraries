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
        /// 仓储对象
        /// </summary>
        ISubjectRepository _subjectRepository;
        /// <summary>
        /// 编辑ID
        /// </summary>
        int _selectID;
        public frmAnswer(ISubjectRepository subjectRepository)
        {
            InitializeComponent();
            _subjectRepository = subjectRepository;

        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            dgvData.DataSource = _subjectRepository.GetSubjects();
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
                var subject = new Subject();
                subject.Name = txbAnswer.Text;
               
                if (_subjectRepository.AddSubject(subject))
                {
                    ClearData();
                    dgvData.DataSource = _subjectRepository.GetSubjects();
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
                    var subject = new Subject();
                    subject.ID = _selectID;
                    subject.Name = txbAnswer.Text;

                    if (_subjectRepository.ModifySubject(subject))
                    {
                        ClearData();
                        dgvData.DataSource = _subjectRepository.GetSubjects();
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
                txbAnswer.Text = dgvData.Rows[e.RowIndex].Cells["科目名称"].Value.ToString();              
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
                        if (_subjectRepository.RemoveSubject(_selectID))
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
            txbAnswer.Clear();       
        }
    }
}
