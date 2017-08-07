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
        IClassRepository _classBll;
        //public frmClassSetting(IClassRepository classBll = null)
        //{
        //    InitializeComponent();
        //    _classBll = CreateInt.Create(classBll);

        //}
        public frmClassSetting(IClassRepository classBll)
        {
            InitializeComponent();
            _classBll = classBll;

        }

        private void frmClassSetting_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var cls = new Class();
            cls.ClassName = txbClassName.Text;
            cls.Memo = txbMemo.Text;
            _classBll.AddClass(cls);
        }
    }
}
