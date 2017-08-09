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
    public partial class frmClassSetting : Form
    {
        /// <summary>
        /// 班级仓储对象
        /// </summary>
        IClassRepository _classRepository;
        /// <summary>
        /// 编辑ID
        /// </summary>
        int _selectID;
        public frmClassSetting(IClassRepository classRepository)
        {
            InitializeComponent();
            _classRepository = classRepository;

        }

        private void frmClassSetting_Load(object sender, EventArgs e)
        {
            dgvData.DataSource = _classRepository.GetClasses();
        }
        /// <summary>
        /// 添加班级
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var cls = new Class();
                cls.ClassName = txbClassName.Text;
                cls.Memo = txbMemo.Text;
                if (_classRepository.AddClass(cls))
                {
                    ClearData();
                    dgvData.DataSource = _classRepository.GetClasses();
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
        /// 修改班级
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectID > 0)
                {
                    var cls = new Class();
                    cls.ID = _selectID;
                    cls.ClassName = txbClassName.Text;
                    cls.Memo = txbMemo.Text;
                    if (_classRepository.ModifyClass(cls))
                    {
                        ClearData();
                        dgvData.DataSource = _classRepository.GetClasses();
                    }
                    else
                    {
                        MessageBox.Show("修改失败！");
                    }
                }
                else
                {
                    MessageBox.Show("请双击先择班级！");

                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        /// <summary>
        /// 双击获取选择的班级
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                _selectID = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["编号"].Value);
                txbClassName.Text = dgvData.Rows[e.RowIndex].Cells["班级名称"].Value.ToString();
                txbMemo.Text = dgvData.Rows[e.RowIndex].Cells["备注"].Value.ToString();
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
                        if (_classRepository.RemoveClass(_selectID))
                        {
                            ClearData();
                            dgvData.DataSource = _classRepository.GetClasses();
                        }
                        else
                        {
                            MessageBox.Show("删除失败！");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请双击先择班级！");
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
            txbClassName.Clear();
            txbMemo.Clear();
        }
    }
}
