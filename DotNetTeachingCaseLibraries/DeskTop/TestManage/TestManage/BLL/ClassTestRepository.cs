﻿using Autofac;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManage.DDL;

namespace TestManage.BLL
{
    /// <summary>
    /// 考试班级业务类
    /// </summary>
    public class ClassTestRepository : IClassTestRepository
    {
        /// <summary>
        /// 数据操作对象
        /// </summary>
        IDBModel _db;

        public ClassTestRepository(IDBModel db)
        {
            _db = db;
        }
        /// <summary>
        /// 添加考试班级
        /// </summary>
        /// <param name="clsTest">考试班级</param>
        /// <returns></returns>
        public bool AddClassTest(ClassTest clsTest)
        {
            _db.ClassTests.Add(clsTest);
            var result = _db.SaveChanges();
            return result > 0;
        }
        /// <summary>
        /// 查询全部考试班级
        /// </summary>
        /// <returns></returns>
        public IList GetClassTests()
        {
            return _db.ClassTests.Where(w=>w.IsValidate==true).Select(s=>new {班级编号=s.ClassID,班级名称=s.Class.ClassName,试卷编号=s.TestID,试卷名称=s.Test.TestName ,是否有效=s.IsValidate }).ToList();
        }
        /// <summary>
        /// 修改考试班级
        /// </summary>
        /// <param name="clsTest">考试班级</param>
        /// <returns></returns>
        public bool ModifyClassTest(ClassTest clsTest)
        {
            var oldClsTest = _db.ClassTests.Find(clsTest.ID);
            if (oldClsTest == null)
            {
                throw new Exception($"查询不到ID为{clsTest.ID}的考试班级");
            }
            else
            {
                oldClsTest.TestID = clsTest.TestID;
                oldClsTest.ClassID = clsTest.ClassID;
                oldClsTest.IsValidate = clsTest.IsValidate;
               
                var result = _db.SaveChanges();
                return result > 0;
            }
        }
        /// <summary>
        /// 删除考试班级
        /// </summary>
        /// <param name="id">考试班级ID</param>
        /// <returns></returns>
        public bool RemoveClassTest(int id)
        {
            var oldClsTest = _db.ClassTests.Find(id);
            if (oldClsTest == null)
            {
                throw new Exception($"查询不到ID为{id}的考试班级");
            }
            else
            {
                _db.ClassTests.Remove(oldClsTest);
                var result = _db.SaveChanges();
                return result > 0;
            }

        }

    }
}
