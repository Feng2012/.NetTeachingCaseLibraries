using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleAccountBook
{
    public partial class frmMain : Form
    {
        /// <summary>
        /// 登录名
        /// </summary>
        string _loginName;
        public frmMain(string loginName)
        {
            _loginName = loginName;
            InitializeComponent();
        }
        //业务处理类型
        BllHandler _bllHandler;
        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                tslLoginName.Text = _loginName;
                _bllHandler = new BllHandler();
                //加载用户下拉列表
                cmbSpendUser.DataSource = _bllHandler.GetUsers();
                cmbSpendUser.DisplayMember = "name";
                cmbSpendUser.ValueMember = "id";
                cmbSpendUser.Text = _loginName;
                //查询财务信息
                dgvIncome.DataSource = _bllHandler.GetAccounts();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void 财务类型设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var finaceTypeForm = new frmFinanceType();
            finaceTypeForm.ShowDialog();
        }
        /// <summary>
        /// 记帐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSava_Click(object sender, EventArgs e)
        {
            try
            {
                if (txbFinanceType.Text.Trim() == "")
                {
                    MessageBox.Show("财务类型不能为空！");
                    return;
                }
                decimal amout;
                if (!decimal.TryParse(txbAmout.Text, out amout))
                {
                    MessageBox.Show("金额值不正确！");
                }
                else
                {
                    if (!_bllHandler.AddAccount(_finaceTypeID, amout, cmbSpendUser.Text, _loginName, txbMemo.Text))
                    {
                        MessageBox.Show("保存失败！");
                    }
                    else
                    {
                        //查询财务信息
                        dgvIncome.DataSource = _bllHandler.GetAccounts();
                    }
                }
                ClearText();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        /// <summary>
        /// 财务类型ID
        /// </summary>
        int _finaceTypeID = 0;
        private void btnSelectFinanceType_Click(object sender, EventArgs e)
        {
            try
            {
                //选择财务类型
                var selectFinanceType = new frmSelectFinanceType(FinceTypeSelect.MinLevel);
                selectFinanceType.ShowDialog();
                txbFinanceType.Text = selectFinanceType.FinaceTypeName;
                _finaceTypeID = selectFinanceType.FinaceTypeID;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        //修改
        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                if(_id==0)
                {
                    MessageBox.Show("请先择要修改的数据！");
                    return;
                }
                if(txbFinanceType.Text.Trim()=="")
                {
                    MessageBox.Show("财务类型不能为空！");
                    return;
                }
                decimal amout;
                if (!decimal.TryParse(txbAmout.Text, out amout))
                {
                    MessageBox.Show("金额值不正确！");
                }
                else
                {
                    if (!_bllHandler.UpdateAccount(_id,_finaceTypeID, amout, cmbSpendUser.Text,  txbMemo.Text))
                    {
                        MessageBox.Show("修改失败！");
                    }
                    else
                    {
                        //查询财务信息
                        dgvIncome.DataSource = _bllHandler.GetAccounts();
                    }
                }
                ClearText();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }       
        /// <summary>
        /// 选择修改或删除的财务ID
        /// </summary>
        int _id;
        private void dgvIncome_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //判断是否点击的帐务数据，表头为-1
                if (e.RowIndex > -1)
                {
                    _id = Convert.ToInt32(dgvIncome.Rows[e.RowIndex].Cells["编号"].Value);
                    txbFinanceType.Text = dgvIncome.Rows[e.RowIndex].Cells["财务类型名称"].Value.ToString();
                    _finaceTypeID = Convert.ToInt32(dgvIncome.Rows[e.RowIndex].Cells["财务类型编号"].Value);
                    txbAmout.Text = dgvIncome.Rows[e.RowIndex].Cells["金额"].Value.ToString();
                    cmbSpendUser.Text = dgvIncome.Rows[e.RowIndex].Cells["财务人"].Value.ToString();
                    txbMemo.Text = dgvIncome.Rows[e.RowIndex].Cells["备注"].Value.ToString();

                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        //清空选择数据
        void ClearText()
        {
            _id = 0;
            txbFinanceType.Clear();
            _finaceTypeID = 0;
            txbAmout.Clear();
            txbMemo.Clear();
        }
        //删除帐务
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (_id == 0)
                {
                    MessageBox.Show("请先择要修改的数据！");
                    return;
                }
                if (!_bllHandler.RemoveAccount(_id))
                {
                    MessageBox.Show("删除失败！");
                }
                else
                {
                    //查询财务信息
                    dgvIncome.DataSource = _bllHandler.GetAccounts();
                    ClearText();
                }
                
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void 查询统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var queryForm = new frmQueryMain();
            queryForm.ShowDialog();
        }
    }
}
