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
    public partial class frmSelectFinanceType : Form
    {
        public frmSelectFinanceType()
        {
            InitializeComponent();
        }
        BllHandler _bllHandler;
        private void frmFinanceType_Load(object sender, EventArgs e)
        {
            _bllHandler = new BllHandler();
            var list = _bllHandler.GetFinanceTypes();

            //递归加载树形菜单
            AddNode(0, trvFinanceType.Nodes, list);
            //展开树形控件
            trvFinanceType.ExpandAll();
        }
        /// <summary>
        /// 递归加载树形菜单
        /// </summary>
        /// <param name="pid">父ID</param>
        /// <param name="list">菜单集合</param>
        void AddNode(int pid, TreeNodeCollection nodes, List<dynamic> list)
        {
            foreach (var item in list.Where(w => w.pid == pid))
            {
                TreeNode node = nodes.Add(item.id.ToString(), item.typename);
                AddNode(item.id, node.Nodes, list);
            }
        }

        private void 删除类型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //获取选中的节点的名称作为id
            var id = Convert.ToInt32(trvFinanceType.SelectedNode.Name);
            if (_bllHandler.DeleteFinanceType(id))
            {
                trvFinanceType.SelectedNode.Remove();
            }
        }

        private void trvFinanceType_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //判断双击是否为最底级菜单
            if (e.Node.Nodes.Count > 0)
            {
                return;
            }
            FinaceTypeID = Convert.ToInt32(e.Node.Name);
            FinaceTypeName = e.Node.Text;
            this.Close();
        }
        /// <summary>
        /// 类型编号
        /// </summary>
        public int FinaceTypeID
        {
            get;
            private set;
        }
        /// <summary>
        /// 类开名称
        /// </summary>
        public string FinaceTypeName
        {
            get;
            private set;
        }
    }
}
