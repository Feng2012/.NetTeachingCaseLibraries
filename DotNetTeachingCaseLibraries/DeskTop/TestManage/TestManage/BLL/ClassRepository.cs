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
    /// 班级业务类
    /// </summary>
    public class ClassRepository : IClassRepository
    {
        /// <summary>
        /// 数据操作对象
        /// </summary>
        IDBModel _db;

        public ClassRepository(IDBModel db)
        {
            _db = db;
        }
        /// <summary>
        /// 添加班级
        /// </summary>
        /// <param name="cls">班级</param>
        /// <returns></returns>
        public bool AddClass(Class cls)
        {
            _db.Classes.Add(cls);
            var result = _db.SaveChanges();
            return result > 0;
        }
        /// <summary>
        /// 查询全部班级
        /// </summary>
        /// <returns></returns>
        public IList GetClasses()
        {
            return _db.Classes.Select(s=>new {编号=s.ID,班级名称=s.ClassName,备注=s.Memo  }).ToList();
        }
        /// <summary>
        /// 修改班级
        /// </summary>
        /// <param name="cls">班级</param>
        /// <returns></returns>
        public bool ModifyClass(Class cls)
        {
            var oldCls = _db.Classes.Find(cls.ID);
            if (oldCls == null)
            {
                throw new Exception($"查询不到ID为{cls.ID}的班级");
            }
            else
            {
                oldCls.ClassName = cls.ClassName;
                oldCls.Memo = cls.Memo;
                var result = _db.SaveChanges();
                return result > 0;
            }
        }
        /// <summary>
        /// 删除班级
        /// </summary>
        /// <param name="id">班级ID</param>
        /// <returns></returns>
        public bool RemoveClass(int id)
        {
            var oldCls = _db.Classes.Find(id);
            if (oldCls == null)
            {
                throw new Exception($"查询不到ID为{id}的班级");
            }
            else
            {
                _db.Classes.Remove(oldCls);
                var result = _db.SaveChanges();
                return result > 0;
            }

        }

    }
}
