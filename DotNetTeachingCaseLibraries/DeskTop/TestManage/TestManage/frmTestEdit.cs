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
    public partial class frmTestEdit : Form
    {
        /// <summary>
        /// 科目对象
        /// </summary>
        ISubjectRepository _subjectRepository;

        /// <summary>
        /// 试卷对象
        /// </summary>
        ITestRepository _testRepository;
        public frmTestEdit( ISubjectRepository subjectRepository, ITestRepository testRepository)
        {
            InitializeComponent();
        
            _subjectRepository = subjectRepository;
            _testRepository = testRepository;
        }
       
        private void frmTestEdit_Load(object sender, EventArgs e)
        {

        }
    }
}
