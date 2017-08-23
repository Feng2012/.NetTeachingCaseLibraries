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
    public partial class frmLogin : Form
    {
        /// <summary>
        /// 班级考试对象
        /// </summary>
        IClassTestRepository _classTestRepository;
        /// <summary>
        /// 学生
        /// </summary>
        IStudentRepository _studentRepository;
        /// <summary>
        /// 教师
        /// </summary>
        ITeacherRepository _teacherRepository;   

        public frmLogin(IClassTestRepository classTestRepository, IStudentRepository studentRepository, ITeacherRepository teacherRepository)
        {
            InitializeComponent();
            _classTestRepository = classTestRepository;
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;    
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            cmbClass.DataSource = _classTestRepository.GetClassTests();
            cmbClass.DisplayMember = "班级名称";
            cmbClass.ValueMember = "班级编号";
        }
        /// <summary>
        /// 登录学生
        /// </summary>
        public Student Student
        { get; private set; }

        private void btnTest_Click(object sender, EventArgs e)
        {
            var student = _studentRepository.GetStudent(txbStudentNo.Text, txbCardID.Text);
            if (student == null)
            {
                MessageBox.Show("用户名或密码失败！");
            }
            else
            {
                Student = student;
                DialogResult = DialogResult.OK;
            }
        }
        /// <summary>
        /// 登录教师
        /// </summary>
        public Teacher Teacher
        { get; private set; }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var teacher = _teacherRepository.Login(txbUserName.Text, txbPassword.Text);
            if (teacher == null)
            {
                MessageBox.Show("用户名或密码失败！");
            }
            else
            {
                Teacher = teacher;
            }
        }
    }
}
