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
    /// TestRepository测试类
    /// </summary>
    [Trait("TestManage", "TestRepository测试")]
    public class TestRepositoryTest
    {
        /// <summary>
        /// DB Mock对象
        /// </summary>
        Mock<IDBModel> _dbMock;
        /// <summary>
        /// 被测试对象
        /// </summary>
        ITestRepository _testRepository;
        public TestRepositoryTest()
        {
            _dbMock = new Mock<IDBModel>();
            _testRepository = new TestRepository(_dbMock.Object);
        }
        /// <summary>
        /// 查询试卷测试
        /// </summary>
        [Fact]
        public void GetTests_Default_ReturnCount()
        {
            var data = new List<Test> { new Test { ID = 1, TestName = "试卷1" , SubjectID=1, Teacher = new Teacher { ID = 1, Name = "张老师" }, Subject = new Subject { ID = 1, Name = "数学" } }, new Test { ID = 2, TestName = "试卷2",SubjectID=1 ,Teacher=new Teacher { ID=1, Name="张老师" }, Subject=new Subject { ID=1, Name="数学" } } };
            var testSet = new Mock<DbSet<Test>>()
                .SetupData(data);
            _dbMock.Setup(db => db.Tests).Returns(testSet.Object);
            var list = _testRepository.GetTests(1);
            Assert.Equal(2, list.Count);
        }
        /// <summary>
        /// GetTest测试
        /// </summary>
        [Fact]
        public void GetTest_Default_Return()
        {
            _dbMock.Setup(db => db.Tests.Find(1)).Returns(value: new Test() { ID=1});
            var test =  _testRepository.GetTest(1);
            Assert.NotNull(test);
        }
        /// <summary>
        /// AddTest异常测试
        /// </summary>
        [Fact]
        public void AddTest_AddNull_ThrowException()
        {
            var message = "AddTest异常";
            _dbMock.Setup(db => db.Tests.Add(null)).Throws(new Exception(message));
            var ext = Assert.Throws<Exception>(() => _testRepository.AddTest(null));
            Assert.Contains(message, ext.Message);
        }
        /// <summary>
        /// AddTest正常添加
        /// </summary>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void AddTest_Default_ReturnTrue(int result)
        {
            _dbMock.Setup(db => db.Tests.Add(new Test()));
            _dbMock.Setup(db => db.SaveChanges()).Returns(value: result);
            var backResult = _testRepository.AddTest(new Test());
            Assert.Equal(result == 1, backResult);
        }
        /// <summary>
        /// ModifyTest异常测试
        /// </summary>
        [Fact]
        public void ModifyTest_NotFind_ThrowException()
        {

            _dbMock.Setup(db => db.Tests.Find()).Returns(value: null);
            var ext = Assert.Throws<Exception>(() => _testRepository.ModifyTest(new Test { ID = 111 }));
            Assert.Contains("查询不到ID为111的试卷", ext.Message);
        }
        /// <summary>
        /// ModifyTest正常测试
        /// </summary>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void ModifySubject_Default_ReturnTrue(int result)
        {
            var test = new Test { ID = 111 };
            _dbMock.Setup(db => db.Tests.Find(test.ID)).Returns(value: new Test());
            _dbMock.Setup(db => db.SaveChanges()).Returns(value: result);
            var backResult = _testRepository.ModifyTest(test);
            Assert.Equal(result == 1, backResult);
        }

        /// <summary>
        /// RemoveTest异常测试
        /// </summary>
        [Fact]
        public void RemoveTest_NotFind_ThrowException()
        {
            _dbMock.Setup(db => db.Tests.Find()).Returns(value: null);
            var ext = Assert.Throws<Exception>(() => _testRepository.RemoveTest(111));
            Assert.Contains("查询不到ID为111的试卷", ext.Message);
        }

        /// <summary>
        /// RemoveTest正常
        /// </summary>
        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        public void RemoveTest_Default_ReturnClass(int result)
        {
            var test = new Test { ID = 111 };
            _dbMock.Setup(db => db.Tests.Find(test.ID)).Returns(value: new Test());
            _dbMock.Setup(db => db.SaveChanges()).Returns(value: result);
            var backResult = _testRepository.RemoveTest(111);
            Assert.Equal(result == 1, backResult);
        }

    }



}
