﻿using Moq;
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
    /// SubjectRepository测试类
    /// </summary>
    [Trait("TestManage", "SubjectRepository测试")]
    public class SubjectRepositoryTest
    {
        /// <summary>
        /// DB Mock对象
        /// </summary>
        Mock<IDBModel> _dbMock;
        /// <summary>
        /// 被测试对象
        /// </summary>
        ISubjectRepository _subjectRepository;
        public SubjectRepositoryTest()
        {
            _dbMock = new Mock<IDBModel>();
            _subjectRepository = new SubjectRepository(_dbMock.Object);
        }
        /// <summary>
        /// 查询科目测试
        /// </summary>
        [Fact]
        public void GetSubjects_Default_ReturnCount()
        {
            var data = new List<Subject> { new Subject { ID = 1, Name = "科目1" }, new Subject { ID = 2, Name = "科目" } };
            var subjectSet = new Mock<DbSet<Subject>>()
                .SetupData(data);
            _dbMock.Setup(db => db.Subjects).Returns(subjectSet.Object);
            var list = _subjectRepository.GetSubjects();
            Assert.Equal(2, list.Count);
        }

        /// <summary>
        /// AddSubject异常测试
        /// </summary>
        [Fact]
        public void AddSubject_AddNull_ThrowException()
        {
            var message = "AddSubject异常";
            _dbMock.Setup(db => db.Subjects.Add(null)).Throws(new Exception(message));
            var ext = Assert.Throws<Exception>(() => _subjectRepository.AddSubject(null));
            Assert.Contains(message, ext.Message);
        }
        /// <summary>
        /// AddSubject正常添加
        /// </summary>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void AddSubject_Default_ReturnTrue(int result)
        {
            _dbMock.Setup(db => db.Subjects.Add(new Subject()));
            _dbMock.Setup(db => db.SaveChanges()).Returns(value: result);
            var backResult = _subjectRepository.AddSubject(new Subject());
            Assert.Equal(result == 1, backResult);
        }
        /// <summary>
        /// ModifySubject异常测试
        /// </summary>
        [Fact]
        public void ModifySubject_NotFind_ThrowException()
        {

            _dbMock.Setup(db => db.Subjects.Find()).Returns(value: null);
            var ext = Assert.Throws<Exception>(() => _subjectRepository.ModifySubject(new Subject { ID = 111 }));
            Assert.Contains("查询不到ID为111的科目", ext.Message);
        }
        /// <summary>
        /// ModifySubject正常测试
        /// </summary>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void ModifySubject_Default_ReturnTrue(int result)
        {
            var subject = new Subject { ID = 111 };
            _dbMock.Setup(db => db.Subjects.Find(subject.ID)).Returns(value: new Subject());
            _dbMock.Setup(db => db.SaveChanges()).Returns(value: result);
            var backResult = _subjectRepository.ModifySubject(subject);
            Assert.Equal(result == 1, backResult);
        }

        /// <summary>
        /// RemoveSubject异常测试
        /// </summary>
        [Fact]
        public void RemoveSubject_NotFind_ThrowException()
        {
            _dbMock.Setup(db => db.Subjects.Find()).Returns(value: null);
            var ext = Assert.Throws<Exception>(() => _subjectRepository.RemoveSubject(111));
            Assert.Contains("查询不到ID为111的科目", ext.Message);
        }

        /// <summary>
        /// RemoveSubject正常
        /// </summary>
        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        public void RemoveSubject_Default_ReturnClass(int result)
        {
            var subjet = new Subject { ID = 111 };
            _dbMock.Setup(db => db.Subjects.Find(subjet.ID)).Returns(value: new Subject());
            _dbMock.Setup(db => db.SaveChanges()).Returns(value: result);
            var backResult = _subjectRepository.RemoveSubject(111);
            Assert.Equal(result == 1, backResult);
        }

    }



}
