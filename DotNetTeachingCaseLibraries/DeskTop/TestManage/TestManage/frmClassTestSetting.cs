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
    public partial class frmClassTestSetting : Form
    {
        /// <summary>
        /// 班级考试对象
        /// </summary>
        IClassTestRepository _classTestRepository;
        /// <summary>
        /// 编辑ID
        /// </summary>
        int _selectID;
        /// <summary>
        /// 科目对象
        /// </summary>
        ISubjectRepository _subjectRepository;
        /// <summary>
        /// 班级对象
        /// </summary>
        IClassRepository _classRepository;
        /// <summary>
        /// 试卷对象
        /// </summary>
        ITestRepository _testRepository;
        public frmClassTestSetting(IClassTestRepository classTestRepository, ISubjectRepository subjectRepository, IClassRepository classRepository, ITestRepository testRepository)
        {
            InitializeComponent();
            _classTestRepository = classTestRepository;
            _classRepository = classRepository;
            _subjectRepository = subjectRepository;
            _testRepository = testRepository;
        }

        private void frmClassSetting_Load(object sender, EventArgs e)
        {

            cmbClass.DataSource = _classRepository.GetClasses();
            cmbClass.ValueMember = "编号";
            cmbClass.DisplayMember = "班级名称";

            cmbSujbect.DataSource = _subjectRepository.GetSubjects();
            cmbSujbect.ValueMember = "编号";
            cmbSujbect.DisplayMember = "科目名称";



            dgvData.DataSource = _classTestRepository.GetClassTests();

        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var clsTest = new ClassTest();
                clsTest.ClassID = Convert.ToInt32(cmbClass.SelectedValue);
                clsTest.TestID =Convert.ToInt32(cmbTest.SelectedValue);
                clsTest.IsValidate = chbIsValidate.Checked;
                if (_classTestRepository.AddClassTest(clsTest))
                {
                    ClearData();
                    dgvData.DataSource = _classTestRepository.GetClassTests();
                }
                else
                {
                    MessageBox.Show("添加失败！");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectID > 0)
                {
                    var clsTest = new ClassTest();
                    clsTest.ID = _selectID;
                    clsTest.ClassID = Convert.ToInt32(cmbClass.SelectedValue);
                    clsTest.TestID = Convert.ToInt32(cmbTest.SelectedValue);
                    clsTest.IsValidate = chbIsValidate.Checked;
                 
                    if (_classTestRepository.ModifyClassTest(clsTest))
                    {
                        ClearData();
                        dgvData.DataSource = _classTestRepository.GetClassTests();
                    }
                    else
                    {
                        MessageBox.Show("修改失败！");
                    }
                }
                else
                {
                    MessageBox.Show("请双击选择！");

                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        /// <summary>
        /// 双击获取选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                _selectID = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["编号"].Value);
                cmbClass.SelectedValue = dgvData.Rows[e.RowIndex].Cells["班级编号"].Value.ToString();
                cmbTest.SelectedValue = dgvData.Rows[e.RowIndex].Cells["试卷编号"].Value.ToString();
                chbIsValidate.Checked = Convert.ToBoolean(dgvData.Rows[e.RowIndex].Cells["是否有效"].Value.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectID > 0)
                {
                    if (MessageBox.Show("你确定要删除吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (_classTestRepository.RemoveClassTest(_selectID))
                        {
                            ClearData();
                            dgvData.DataSource = _classTestRepository.GetClassTests();
                        }
                        else
                        {
                            MessageBox.Show("删除失败！");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请双击选择！");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        /// <summary>
        /// 清空窗体数据
        /// </summary>
        void ClearData()
        {
            _selectID = 0;

        }

        private void cmbSujbect_SelectedIndexChanged(object sender, EventArgs e)
        {
            var subjectID = Convert.ToInt32(cmbSujbect.SelectedValue);
            cmbTest.DataSource = _testRepository.GetTests(subjectID);
            cmbTest.DisplayMember = "试卷名称";
            cmbTest.ValueMember = "ID";
        }
    }
}
