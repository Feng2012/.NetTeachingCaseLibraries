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

namespace TestManage.UnitTest
{
    /// <summary>
    /// ClassRepository测试类
    /// </summary>
    [Trait("TestManage", "ClassRepository测试")]
    public class ClassRepositoryTest
    {
        /// <summary>
        /// DB Mock对象
        /// </summary>
        Mock<IDBModel> _dbMock;
        /// <summary>
        /// 被测试对象
        /// </summary>
        IClassRepository _classRepository;
        public ClassRepositoryTest()
        {
            _dbMock = new Mock<IDBModel>();
            _classRepository = new ClassRepository(_dbMock.Object);
        }
        /// <summary>
        /// AddClass异常测试
        /// </summary>
        [Fact]
        public void AddClass_ThrowException_Catch()
        {
            _dbMock.Setup(db => db.Classes.Add(null)).Throws(new Exception("AddClass异常"));
            var ext = Assert.Throws<Exception>(() => _classRepository.AddClass(null));
            Assert.Contains("AddClass异常", ext.Message);
        }
        /// <summary>
        /// AddClass正常添加
        /// </summary>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void AddClass_Default_ReturnTrue(int result)
        {
            _dbMock.Setup(db => db.Classes.Add(new Class()));
            _dbMock.Setup(db => db.SaveChanges()).Returns(value: result);
            var backResult= _classRepository.AddClass(new Class());
            Assert.Equal(result==1, backResult);
        }
        /// <summary>
        /// ModifyClass异常测试
        /// </summary>
        [Fact]
        public void ModifyClass_ThrowException_Catch()
        {
          
            _dbMock.Setup(db => db.Classes.Find()).Returns(value:null);
            var ext = Assert.Throws<Exception>(() => _classRepository.ModifyClass(new Class { ID = 111 }));
            Assert.Contains("查询不到ID为111的班级", ext.Message);
        }
        /// <summary>
        /// ModifyClass异常测试
        /// </summary>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void ModifyClass_Default_ReturnTrue(int result)
        {
            var cls = new Class { ID = 111 };
            _dbMock.Setup(db => db.Classes.Find(cls.ID)).Returns(value: new Class());      
            _dbMock.Setup(db => db.SaveChanges()).Returns(value: result);
            var backResult =_classRepository.ModifyClass(cls);
            Assert.Equal(result == 1, backResult);
        }

        /// <summary>
        /// RemoveClass异常测试
        /// </summary>
        [Fact]
        public void RemoveClass_ThrowException_Catch()
        {

           // _dbMock.SetupProperty(db => db.Classes);
            _dbMock.Setup(db => db.Classes.SingleOrDefault(s=>s.ID==111)).Returns(value: new Class());
            var ext = Assert.Throws<Exception>(() => _classRepository.RemoveClass(111));
            Assert.Contains("查询不到ID为111的班级", ext.Message);
        }
    }
}
