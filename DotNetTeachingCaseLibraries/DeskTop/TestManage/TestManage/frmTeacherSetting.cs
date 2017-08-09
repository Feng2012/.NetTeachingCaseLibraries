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
    public partial class frmTeacherSetting : Form
    {
        /// <summary>
        /// 仓储对象
        /// </summary>
        ITeacherRepository _teacherRepository;
        /// <summary>
        /// 编辑ID
        /// </summary>
        int _selectID;
        public frmTeacherSetting(ITeacherRepository teacherRepository)
        {
            InitializeComponent();
            _teacherRepository = teacherRepository;

        }

        private void frmClassSetting_Load(object sender, EventArgs e)
        {
            dgvData.DataSource = _teacherRepository.GetTeachers();
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
                var teacher = new Teacher();
                teacher.Name = txbTeacherName.Text;
                teacher.TeaacherNo = txbTeacherNo.Text;
                teacher.Password = txbPassword.Text;
                if (_teacherRepository.AddTeacher(teacher))
                {
                    ClearData();
                    dgvData.DataSource = _teacherRepository.GetTeachers();
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
                    var teacher = new Teacher();
                    teacher.ID = _selectID;
                    teacher.Name = txbTeacherName.Text;
                    teacher.TeaacherNo = txbTeacherNo.Text;
                    teacher.Password = txbPassword.Text;
                    if (_teacherRepository.ModifyTeacher(teacher))
                    {
                        ClearData();
                        dgvData.DataSource = _teacherRepository.GetTeachers();
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
                txbTeacherName.Text = dgvData.Rows[e.RowIndex].Cells["名称"].Value.ToString();
                txbTeacherNo.Text = dgvData.Rows[e.RowIndex].Cells["教师编码"].Value.ToString();
                txbPassword.Text = dgvData.Rows[e.RowIndex].Cells["密码"].Value.ToString();
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectID > 0)
                {
                    if (MessageBox.Show("你确定要删除吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (_teacherRepository.RemoveTeacher(_selectID))
                        {
                            ClearData();
                            dgvData.DataSource = _teacherRepository.GetTeachers();
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
            txbTeacherName.Clear();
            txbTeacherNo.Clear();
            txbPassword.Clear();
        }
    }
}
