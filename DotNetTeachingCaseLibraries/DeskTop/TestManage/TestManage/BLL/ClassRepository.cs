using Autofac;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManage.DDL;

namespace TestManage.BLL
{
    public class ClassRepository : IClassRepository
    {
        public IDBModel db;

        public ClassRepository(IDBModel testManageDB)
        {
            db = testManageDB;
        }
        /// <summary>
        /// 添加班级
        /// </summary>
        /// <param name="cls">班级</param>
        /// <returns></returns>
        public bool AddClass(Class cls)
        {
            db.Classes.Add(cls);
            var result = db.SaveChanges();
            return result > 0;
        }
        /// <summary>
        /// 查询全部班级
        /// </summary>
        /// <returns></returns>
        public IList GetClasses()
        {
            return db.Classes.Select(s=>new {编号=s.ID,班级名称=s.ClassName,备注=s.Memo  }).ToList();
        }
        /// <summary>
        /// 修改班级
        /// </summary>
        /// <param name="cls">班级</param>
        /// <returns></returns>
        public bool ModifyClass(Class cls)
        {
            var oldCls = db.Classes.SingleOrDefault(s => s.ID == cls.ID);
            if (oldCls == null)
            {
                throw new Exception($"查询不到ID为{cls.ID}的班级");
            }
            else
            {
                oldCls.ClassName = cls.ClassName;
                oldCls.Memo = cls.Memo;
                var result = db.SaveChanges();
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
            var oldCls = db.Classes.SingleOrDefault(s => s.ID == id);
            if (oldCls == null)
            {
                throw new Exception($"查询不到ID为{id}的班级");
            }
            else
            {
                db.Classes.Remove(oldCls);
                var result = db.SaveChanges();
                return result > 0;
            }

        }

    }
}
