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

namespace TestManage
{
    public partial class frmLogin : Form
    {
        /// <summary>
        /// 仓储对象
        /// </summary>
        IClassTestRepository _classTestRepository;
        /// <summary>
        /// 学生
        /// </summary>
        IStudentRepository _studentRepository;
        public frmLogin(IClassTestRepository classTestRepository, IStudentRepository studentRepository)
        {
            InitializeComponent();
            _classTestRepository = classTestRepository;
            _studentRepository = studentRepository;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            cmbClass.DataSource = _classTestRepository.GetClassTests();
            cmbClass.DisplayMember = "班级名称";
            cmbClass.ValueMember = "班级编号";
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            var student = _studentRepository.GetStudent(txbStudentNo.Text, txbCardID.Text);
            if(student!=null)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
