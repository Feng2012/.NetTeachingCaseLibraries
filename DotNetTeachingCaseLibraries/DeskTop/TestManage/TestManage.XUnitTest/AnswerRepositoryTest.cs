using Moq;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using TestManage.BLL;
using TestManage.DDL;
using Xunit;


namespace TestManage.XUnitTest
{
    /// <summary>
    /// AnswerRepository测试类
    /// </summary>
    [Trait("TestManage", "AnswerRepository测试类")]
    public class AnswerRepositoryTest
    {
        /// <summary>
        /// DB Mock对象
        /// </summary>
        Mock<IDBModel> _dbMock;
        /// <summary>
        /// 被测试对象
        /// </summary>
        IAnswerRepository _answerRepository;
        public AnswerRepositoryTest()
        {
            _dbMock = new Mock<IDBModel>();
            _answerRepository = new AnswerRepository(_dbMock.Object);
        }
        /// <summary>
        /// 按问题查询答案
        /// </summary>
        [Fact]
        public void GetAnswer_Default_ReturnCount()
        {
            var data = new List<Answer> { new Answer { ID = 1, Answer1 = "答案1",IsAnswer=true,QuestionID=1 }, new Answer { ID = 2, Answer1 = "答案2",IsAnswer=false,QuestionID=1 } };

            var answerSet = new Mock<DbSet<Answer>>()
                .SetupData(data);
            _dbMock.Setup(db => db.Answers).Returns(answerSet.Object);
            var list = _answerRepository.GetAnswers(1);
            Assert.Equal(2, list.Count);
        }

        /// <summary>
        /// AddAnswer异常测试
        /// </summary>
        [Fact]
        public void AddAnswer_AddNull_ThrowException()
        {
            var message = "AddAnswer异常";
            _dbMock.Setup(db => db.Answers.Add(null)).Throws(new Exception(message));
            var ext = Assert.Throws<Exception>(() => _answerRepository.AddAnswer(null));
            Assert.Contains(message, ext.Message);
        }
        /// <summary>
        /// AddAnswer正常添加
        /// </summary>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void AddAnswer_Default_ReturnTrue(int result)
        {
            _dbMock.Setup(db => db.Answers.Add(new Answer()));
            _dbMock.Setup(db => db.SaveChanges()).Returns(value: result);
            var backResult = _answerRepository.AddAnswer(new Answer());
            Assert.Equal(result == 1, backResult);
        }
        /// <summary>
        /// ModifyAnswer异常测试
        /// </summary>
        [Fact]
        public void ModifyAnswer_NotFind_ThrowException()
        {

            _dbMock.Setup(db => db.Answers.Find()).Returns(value: null);
            var ext = Assert.Throws<Exception>(() => _answerRepository.ModifyAnswer(new Answer { ID = 111 }));
            Assert.Contains("查询不到ID为111的答案", ext.Message);
        }
        /// <summary>
        /// ModifyAnswer正常测试
        /// </summary>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void ModifyAnswer_Default_ReturnTrue(int result)
        {
            var answer = new Answer { ID = 111 };
            _dbMock.Setup(db => db.Answers.Find(answer.ID)).Returns(value: new Answer());
            _dbMock.Setup(db => db.SaveChanges()).Returns(value: result);
            var backResult = _answerRepository.ModifyAnswer(answer);
            Assert.Equal(result == 1, backResult);
        }

        /// <summary>
        /// RemoveAnswer异常测试
        /// </summary>
        [Fact]
        public void RemoveSubject_NotFind_ThrowException()
        {
            _dbMock.Setup(db => db.Answers.Find()).Returns(value: null);
            var ext = Assert.Throws<Exception>(() => _answerRepository.RemoveAnswer(111));
            Assert.Contains("查询不到ID为111的答案", ext.Message);
        }

        /// <summary>
        /// RemoveAnswer正常
        /// </summary>
        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        public void RemoveAnswer_Default_ReturnClass(int result)
        {
            var answer = new Answer { ID = 111 };
            _dbMock.Setup(db => db.Answers.Find(answer.ID)).Returns(value: new Answer());
            _dbMock.Setup(db => db.SaveChanges()).Returns(value: result);
            var backResult = _answerRepository.RemoveAnswer(111);
            Assert.Equal(result == 1, backResult);
        }

    }



}
