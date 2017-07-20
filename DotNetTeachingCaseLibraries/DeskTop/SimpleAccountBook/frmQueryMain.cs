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
    public partial class frmQueryMain : Form
    {

        public frmQueryMain()
        {
            InitializeComponent();
        }       
        /// <summary>
        /// 业务处理类型
        /// </summary>
        BllHandler _bllHandler;
        /// <summary>
        /// 全部财务类型
        /// </summary>
        List<dynamic> financeTypes;
        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                _bllHandler = new BllHandler();
                //加载用户下拉列表
                var table = _bllHandler.GetUsers();
                //添加一个全部
                var newRow = table.NewRow();
                newRow["name"] = "全部";
                newRow["id"] = 0;
                table.Rows.InsertAt(newRow, 0);
                cmbSpendUser.DataSource = table;
                cmbSpendUser.DisplayMember = "name";
                cmbSpendUser.ValueMember = "id";

                //获取全部财务类型
                var financeTypes = _bllHandler.GetFinanceTypes();
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
                //获取选择财务类型下的全部无下级ID
                var ids = GetChildFinceTypeID(_finaceTypeID, financeTypes).TrimEnd(',');

                dgvData.DataSource = _bllHandler.QueryAccount(dtpBeginTime.Value, dtpEndTime.Value, ids, cmbSpendUser.Text);
                //统计合计
                var sum = 0m;
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    sum += Convert.ToDecimal(row.Cells["金额"].Value);
                }
                labCount.Text = $"合计：{sum}元";
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        /// <summary>
        /// 根据父id获取下面的所有最底级子id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string GetChildFinceTypeID(int id, List<dynamic> financeTypes)
        {
            //financeTypes中元素字段id,typename,pid
            var ids = "";
            if (financeTypes.Where(w => w.pid == id).Count() > 0)
            {
                foreach (var item in financeTypes.Where(w => w.pid == id))
                {
                    ids += GetChildFinceTypeID(item.id, financeTypes);
                }
            }
            else
            {
                ids += id + ",";
            }
            return ids;
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
                var selectFinanceType = new frmSelectFinanceType(FinceTypeSelect.None);
                selectFinanceType.ShowDialog();
                txbFinanceType.Text = selectFinanceType.FinaceTypeName;
                _finaceTypeID = selectFinanceType.FinaceTypeID;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
