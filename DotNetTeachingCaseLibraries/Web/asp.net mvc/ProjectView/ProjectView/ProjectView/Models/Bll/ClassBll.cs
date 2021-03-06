﻿using ProjectView.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectView.Models;

namespace ProjectView.Models.Bll
{
    /// <summary>
    /// 班级业务顺
    /// </summary>
    public class ClassBll
    {

        ProjectReviewDBEntities PRDB;
        public ClassBll()
        {
            PRDB = new ProjectReviewDBEntities();
        }
        /// <summary>
        /// 获取全部班级
        /// </summary>
        /// <returns></returns>
        public List<ClassModel> GetClasses()
        {
            var cms = new List<ClassModel>();
            foreach (Class cla in PRDB.Classes.OrderBy(cla => cla.ID))
            {
                var cm = new ClassModel();
                cm.ID = cla.ID;
                cm.ClassName = cla.ClassName;
                cm.Describe = cla.Describe;
                cms.Add(cm);
            }
            return cms;
        }
        /// <summary>
        /// 添加班级
        /// </summary>
        /// <param name="cm">班级</param>
        /// <returns></returns>
        public bool AddClass(ClassModel cm)
        {
            try
            {
                var cla = new Class();
                cla.ClassName = cm.ClassName;
                cla.Describe = cm.Describe;
                PRDB.Classes.Add(cla);
                PRDB.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 按ID获取班级
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ClassModel GetClassByID(int id)
        {
            try
            {
                var cla = PRDB.Classes.SingleOrDefault(clas => clas.ID == id);
                if (cla != null)
                {
                    var cm = new ClassModel();
                    cm.ID = cla.ID;
                    cm.ClassName = cla.ClassName;
                    cm.Describe = cla.Describe;
                    return cm;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 修改班级
        /// </summary>
        /// <param name="cm">班级</param>
        /// <returns></returns>
        public bool ModifyClass(ClassModel cm)
        {
            try
            {
                var cla = PRDB.Classes.SingleOrDefault(clas => clas.ID == cm.ID);
                if (cla != null)
                {
                    cla.ClassName = cm.ClassName;
                    cla.Describe = cm.Describe;
                    PRDB.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 移除班级
        /// </summary>
        /// <param name="cm">班级</param>
        /// <returns></returns>
        public bool RemoveClass(ClassModel cm)
        {
            try
            {
                var cla = PRDB.Classes.SingleOrDefault(clas => clas.ID == cm.ID);
                if (cla != null)
                {
                    PRDB.Classes.Remove(cla);
                    PRDB.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}