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
        string _loginName;
        public frmMain(string loginName)
        {
            InitializeComponent();
        }
        //业务处理类型
        BllHandler _bllHandler;
        private void frmMain_Load(object sender, EventArgs e)
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
            decimal amout;
            if (!decimal.TryParse(txbAmout.Text, out amout))
            {
                MessageBox.Show("金额值不正确！");
            }
            else
            {
                _bllHandler.AddAccount(_finaceTypeID, amout, cmbSpendUser.SelectedText, _loginName, txbMemo.Text);
            }
        }
        /// <summary>
        /// 财务类型ID
        /// </summary>
        int _finaceTypeID = 0;
        private void btnSelectFinanceType_Click(object sender, EventArgs e)
        {
            //选择财务类型
            var selectFinanceType = new frmSelectFinanceType();
            selectFinanceType.ShowDialog();
            txbFinanceType.Text = selectFinanceType.FinaceTypeName;
            _finaceTypeID = selectFinanceType.FinaceTypeID;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {

        }

        int _financeTypeID;
        int _id;
        private void dgvIncome_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                _id = Convert.ToInt32(dgvIncome.Rows[e.RowIndex].Cells["编号"].Value);
                txbFinanceType.Text = dgvIncome.Rows[e.RowIndex].Cells["财务类型名称"].Value.ToString();
                _financeTypeID= Convert.ToInt32(dgvIncome.Rows[e.RowIndex].Cells["财务类型编号"].Value);
                txbAmout.Text= dgvIncome.Rows[e.RowIndex].Cells["金额"].Value.ToString();
                cmbSpendUser.Text= dgvIncome.Rows[e.RowIndex].Cells["财务人"].Value.ToString();
                txbMemo.Text = dgvIncome.Rows[e.RowIndex].Cells["备注"].Value.ToString(); 

            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

        }
    }
}
