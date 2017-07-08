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
        IClassRepository _classRepository;
        public frmClassSetting(IClassRepository classRepository)
        {
            InitializeComponent();
            _classRepository = classRepository;

        }

        private void frmClassSetting_Load(object sender, EventArgs e)
        {
            dgvData.DataSource = _classRepository.GetClasses();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var cls = new Class();
            cls.ClassName = txbClassName.Text;
            cls.Memo = txbMemo.Text;
            _classRepository.AddClass(cls);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }
    }
}
