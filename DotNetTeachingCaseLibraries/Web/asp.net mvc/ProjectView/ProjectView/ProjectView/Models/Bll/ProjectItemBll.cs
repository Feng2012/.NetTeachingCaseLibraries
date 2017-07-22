using ProjectView.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectView.Models.Bll
{
    /// <summary>
    /// 项目子项业务类
    /// </summary>
    public class ProjectItemBll
    {
        ProjectReviewDBEntities PRDB;
        public ProjectItemBll()
        {
            PRDB = new ProjectReviewDBEntities();
        }
        /// <summary>
        /// 获取项目子项
        /// </summary>
        /// <returns></returns>
        public List<ProjectItemModel> GetProjectItems()
        {
            var pros = new List<ProjectItemModel>();
            foreach (var pi in PRDB.ProjectItems.OrderBy(item => item.ID))
            {
                var pim = new ProjectItemModel();
                pim.ID = pi.ID;
                pim.ProjectItemName = pi.ItemName;
                pim.ProjectID = pi.ProjectID;
                pim.Grade = pi.Grade;
                pim.ProjectName = pi.Project.ProjectName;
                pros.Add(pim);
            }
            return pros;
        }
        /// <summary>
        /// 按项目ID获取项目子项
        /// </summary>
        /// <param name="projectid">项目ID</param>
        /// <returns></returns>
        public List<ProjectItemModel> GetProjectItems(int projectid)
        {
            var pros = new List<ProjectItemModel>();
            foreach (var pi in PRDB.ProjectItems.Where(pi => pi.ProjectID == projectid).OrderBy(ite => ite.ID))
            {
                var pim = new ProjectItemModel();
                pim.ID = pi.ID;
                pim.ProjectItemName = pi.ItemName;
                pim.ProjectID = pi.ProjectID;
                pim.Grade = pi.Grade;
                pim.ProjectName = pi.Project.ProjectName;
                pros.Add(pim);
            }
            return pros;
        }
        /// <summary>
        /// 获取项目子项
        /// </summary>
        /// <param name="id">项目子项ID</param>
        /// <returns></returns>
        public ProjectItemModel GetProjectItem(int id)
        {
            var pi = PRDB.ProjectItems.SingleOrDefault(pis => pis.ID == id);
            if (pi != null)
            {
                var pim = new ProjectItemModel();
                pim.ID = pi.ID;
                pim.ProjectItemName = pi.ItemName;
                pim.ProjectID = pi.ProjectID;
                pim.Grade = pi.Grade;
                pim.ProjectName = pi.Project.ProjectName;
                return pim;
            }
            return null;

        }
        /// <summary>
        /// 添加项目子项
        /// </summary>
        /// <param name="pim">项目子项</param>
        /// <returns></returns>
        public bool AddProjectItem(ProjectItemModel pim)
        {
            try
            {
                var pi = new ProjectItem();
                pi.ItemName = pim.ProjectItemName;
                pi.Grade = pim.Grade;
                pi.ProjectID = pim.ProjectID;
                PRDB.ProjectItems.Add(pi);
                PRDB.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 修改项目子项
        /// </summary>
        /// <param name="pim">项目子项</param>
        /// <returns></returns>
        public bool ModifyProjectItem(ProjectItemModel pim)
        {
            try
            {
                var pi = PRDB.ProjectItems.SingleOrDefault(pis => pis.ID == pim.ID);
                if (pi != null)
                {
                    pi.ItemName = pim.ProjectItemName;
                    pi.Grade = pim.Grade;
                    pi.ProjectID = pim.ProjectID;
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
        /// 移除项目子项
        /// </summary>
        /// <param name="id">项目子项ID</param>
        /// <returns></returns>
        public bool RemoveProjectItem(int id)
        {
            try
            {
                var pi = PRDB.ProjectItems.SingleOrDefault(pis => pis.ID == id);
                if (pi != null)
                {
                    PRDB.ProjectItems.Remove(pi);
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