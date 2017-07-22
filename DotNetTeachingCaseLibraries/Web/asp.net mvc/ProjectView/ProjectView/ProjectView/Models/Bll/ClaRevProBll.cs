using ProjectView.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectView.Models.Bll
{
    /// <summary>
    /// 班级评审业务类
    /// </summary>
    public class ClaRevProBll
    {
        ProjectReviewDBEntities PRDB;
        public ClaRevProBll()
        {
            PRDB = new ProjectReviewDBEntities();
        }
        /// <summary>
        /// 获取班级评审类
        /// </summary>
        /// <returns></returns>
        public List<ClaRevProModel> GetClaRevProModels()
        {
            var CRPMS = new List<ClaRevProModel>();
            foreach (var v in PRDB.ClassReviewProjects.OrderBy(crp => crp.ID))
            {
                var crm = new ClaRevProModel();
                crm.ID = v.ID;
                crm.ClassID = v.ClassID;
                crm.ClassName = v.Class.ClassName;
                if (v.ProjectID.HasValue)
                {
                    crm.ProjectID = v.ProjectID.Value;
                    crm.ProjectName = v.Project.ProjectName;
                }

                CRPMS.Add(crm);
            }
            return CRPMS;
        }
        /// <summary>
        /// 修改班级评审类
        /// </summary>
        /// <param name="crpm"></param>
        /// <returns></returns>
        public bool ModifyCRP(ClaRevProModel crpm)
        {
            try
            {
                var crp = PRDB.ClassReviewProjects.SingleOrDefault(cr => cr.ID == crpm.ID);
                if (crp != null)
                {
                    crp.ClassID = crpm.ClassID;
                    crp.ProjectID = crpm.ProjectID;
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
                return true;
            }

        }
        /// <summary>
        /// 按ID获取班级项目
        /// </summary>
        /// <param name="id">班级评审ID</param>
        /// <returns></returns>
        public ClaRevProModel GetCRPByID(int id)
        {
            try
            {
                var crp = PRDB.ClassReviewProjects.SingleOrDefault(cr => cr.ID == id);
                if (crp != null)
                {
                    var crm = new ClaRevProModel();
                    crm.ID = crp.ID;
                    crm.ClassID = crp.ClassID;
                    crm.ClassName = crp.Class.ClassName;
                    if (crp.ProjectID.HasValue)
                    {
                        crm.ProjectID = crp.ProjectID.Value;
                        crm.ProjectName = crp.Project.ProjectName;
                    }

                    return crm;
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
    }
}