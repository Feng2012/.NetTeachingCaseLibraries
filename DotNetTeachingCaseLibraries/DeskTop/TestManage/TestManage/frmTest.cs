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
    public partial class frmTest : Form
    {
        /// <summary>
        /// 试卷对象
        /// </summary>
        ITestRepository _testRepository;
        /// <summary>
        /// 班级考试对象
        /// </summary>
        IClassTestRepository _classTestRepository;
        public frmTest(ITestRepository testRepository, IClassTestRepository classTestRepository)
        {
            InitializeComponent();
            _testRepository = testRepository;
            _classTestRepository = classTestRepository;
        }
        /// <summary>
        /// 考试学生
        /// </summary>
        public Student TestStudent
        { get; set; }
        private void frmTest_Load(object sender, EventArgs e)
        {

        }
    }
}
