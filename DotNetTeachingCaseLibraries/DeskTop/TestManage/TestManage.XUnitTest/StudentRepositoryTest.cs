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
    [Trait("TestManage", "StudentRepositoryTest测试")]
    public class StudentRepositoryTest
    {
        /// <summary>
        /// DB Mock对象
        /// </summary>
        Mock<IDBModel> _dbMock;
        /// <summary>
        /// 被测试对象
        /// </summary>
        IStudentRepository _studentRepository;
        public StudentRepositoryTest()
        {
            _dbMock = new Mock<IDBModel>();
            _studentRepository = new StudentRepository(_dbMock.Object);
        }
        /// <summary>
        /// 查询学生测试
        /// </summary>
        [Fact]
        public void GetStudent_Default_ReturnCount()
        {
            var student = new Student { StuNo = "SZ201701001", Name = "张三", CardID = "412214198808082526" };
            _dbMock.Setup(db => db.Students.Find(student.StuNo)).Returns(value: student);
            var newStuent = _studentRepository.GetStudent(student.StuNo, student.CardID);
            Assert.NotNull(newStuent);
        }
        /// <summary>
        /// 查询班级全部学生测试
        /// </summary>
        [Fact]
        public void GetStudentsByClsID_Default_ReturnCount()
        {
            var student = new Student { StuNo = "SZ201701001", Name = "张三", CardID = "412214198808082526",ClassID=1,Class=new Class { ClassName="一班" } };
            var data = new List<Student> {
                new Student {
                    StuNo = "SZ201701001",
                    Name = "张三",
                    CardID = "412214198808082526",
                    ClassID = 1,
                    Class = new Class { ClassName = "一班" }
                },
                new Student {
                    StuNo = "SZ201701002",
                    Name = "张三丰",
                    CardID = "412214198808082522",
                    ClassID = 1,
                    Class = new Class { ClassName = "一班" }
                },
                new Student {
                    StuNo = "SZ201702001",
                    Name = "张三",
                    CardID = "412214198808082526",
                    ClassID = 2,
                    Class = new Class { ClassName = "二班" }
                }
            };
            var studentSet = new Mock<DbSet<Student>>()
                .SetupData(data);
            _dbMock.Setup(db => db.Students).Returns(studentSet.Object);
            var students = _studentRepository.GetStudentsByClsID(1);
            Assert.Equal(2, students.Count);
        }
        /// <summary>
        /// AddStuden异常测试
        /// </summary>
        [Fact]
        public void AddStudent_AddNull_ThrowException()
        {
            var message = "AddStudent异常";
            _dbMock.Setup(db => db.Students.Add(null)).Throws(new Exception(message));
            var ext = Assert.Throws<Exception>(() => _studentRepository.AddStudent(null));
            Assert.Contains(message, ext.Message);
        }
        /// <summary>
        /// AddStudent正常添加
        /// </summary>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void AddStudent_Default_ReturnTrue(int result)
        {
            _dbMock.Setup(db => db.Students.Add(new Student()));
            _dbMock.Setup(db => db.SaveChanges()).Returns(value: result);
            var backResult = _studentRepository.AddStudent(new Student());
            Assert.Equal(result == 1, backResult);
        }
        /// <summary>
        /// ModifyStudent异常测试
        /// </summary>
        [Fact]
        public void ModifyStudent_NotFind_ThrowException()
        {

            _dbMock.Setup(db => db.Students.Find()).Returns(value: null);
            var ext = Assert.Throws<Exception>(() => _studentRepository.ModifyStudent(new Student { StuNo="SZ20180808001" }));
            Assert.Contains("查询不到学号为SZ20180808001的学生", ext.Message);
        }
        /// <summary>
        /// ModifyStudent正常测试
        /// </summary>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void ModifyStudent_Default_ReturnTrue(int result)
        {
            var student = new Student { StuNo = "SZ20180808001" };
            _dbMock.Setup(db => db.Students.Find(student.StuNo)).Returns(value: new Student());
            _dbMock.Setup(db => db.SaveChanges()).Returns(value: result);
            var backResult = _studentRepository.ModifyStudent(student);
            Assert.Equal(result == 1, backResult);
        }

        /// <summary>
        /// RemoveStudent异常测试
        /// </summary>
        [Fact]
        public void RemoveStudent_NotFind_ThrowException()
        {
            _dbMock.Setup(db => db.Students.Find()).Returns(value: null);
            var ext = Assert.Throws<Exception>(() => _studentRepository.RemoveStudent("SZ20180808001"));
            Assert.Contains("查询不到学号为SZ20180808001的学生", ext.Message);
        }

        /// <summary>
        /// RemoveStudent正常
        /// </summary>
        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        public void RemoveStudent_Default_ReturnClass(int result)
        {
            var student = new Student { StuNo = "SZ20180808001" };
            _dbMock.Setup(db => db.Students.Find(student.StuNo)).Returns(value: new Student());
            _dbMock.Setup(db => db.SaveChanges()).Returns(value: result);
            var backResult = _studentRepository.RemoveStudent("SZ20180808001");
            Assert.Equal(result == 1, backResult);
        }

    }



}
