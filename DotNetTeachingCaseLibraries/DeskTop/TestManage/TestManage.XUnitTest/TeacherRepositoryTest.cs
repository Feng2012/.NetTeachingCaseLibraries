using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManage.BLL;
using TestManage.DDL;
using Xunit;
using TestManage.XUnitTest;
using System.Linq.Expressions;

namespace TestManage.XUnitTest
{
    /// <summary>
    /// TeacherRepository测试类
    /// </summary>
    [Trait("TestManage", "TeacherRepository测试")]
    public class TeacherRepositoryTest
    {
        /// <summary>
        /// DB Mock对象
        /// </summary>
        Mock<IDBModel> _dbMock;
        /// <summary>
        /// 被测试对象
        /// </summary>
        ITeacherRepository _teacherRepository;
        public TeacherRepositoryTest()
        {
            _dbMock = new Mock<IDBModel>();
            _teacherRepository = new TeacherRepository(_dbMock.Object);
        }
        
        /// <summary>
        /// Login正常返回
        /// </summary>
        [Fact]
  
        public void Login_Default_ReturnTeacher()
        {
            var teacher = new Teacher { ID = 1, TeaacherNo = "0001", Password = "111111" };
            var data = new List<Teacher> { teacher };
            var teacherSet = new Mock<DbSet<Teacher>>()
                .SetupData(data);
            _dbMock.Setup(db => db.Teachers).Returns(teacherSet.Object);
            var backTeacher = _teacherRepository.Login("0001","111111");
            Assert.Same(teacher, backTeacher);
        }

        /// <summary>
        /// 错误密码测试
        /// </summary>
        [Fact]

        public void Login_ErrorPassword_ReturnNull()
        {
            var teacher = new Teacher { ID = 1, TeaacherNo = "0001", Password = "111111" };
            var data = new List<Teacher> { teacher };
            var teacherSet = new Mock<DbSet<Teacher>>()
                .SetupData(data);
            _dbMock.Setup(db => db.Teachers).Returns(teacherSet.Object);
            var backTeacher = _teacherRepository.Login("0001", "222222");
            Assert.Same(null, backTeacher);
        }

    }



}
