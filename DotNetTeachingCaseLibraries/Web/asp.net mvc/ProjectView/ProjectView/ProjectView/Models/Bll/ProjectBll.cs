using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectView.Models;
using ProjectView.Models.ViewModel;

namespace ProjectView.Models.Bll
{
    /// <summary>
    /// 项目业务
    /// </summary>
    public class ProjectBll
    {
        ProjectReviewDBEntities PRDB;
        public ProjectBll()
        {
            PRDB = new ProjectReviewDBEntities();
        }
        /// <summary>
        /// 添加项目
        /// </summary>
        /// <param name="pm">项目</param>
        /// <returns></returns>
        public bool AddProject(ProjectModel pm)
        {
            try
            {
                var project = new Project();
                project.ProjectName = pm.ProjectName;
                project.Describe = pm.Describe;
                PRDB.Projects.Add(project);
                PRDB.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 获取全部项目
        /// </summary>
        /// <returns></returns>
        public List<ProjectModel> GetProjects()
        {
            var pros = new List<ProjectModel>();
            foreach (var pro in PRDB.Projects.OrderBy(pro => pro.ID))
            {
                var pm = new ProjectModel();
                pm.ID = pro.ID;
                pm.ProjectName = pro.ProjectName;
                pm.Describe = pro.Describe;
                pros.Add(pm);
            }
            return pros;
        }
        /// <summary>
        /// 按照ID获取项目
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public ProjectModel GetProjectByID(int id)
        {
            var project = PRDB.Projects.SingleOrDefault(pro => pro.ID == id);
            var pm = new ProjectModel();
            if (project != null)
            {
                pm.ID = project.ID;
                pm.ProjectName = project.ProjectName;
                pm.Describe = project.Describe;
            }
            return pm;
        }
        /// <summary>
        /// 修改项目
        /// </summary>
        /// <param name="pm">项目</param>
        /// <returns></returns>
        public bool ModiftyProject(ProjectModel pm)
        {
            try
            {
                var project = PRDB.Projects.SingleOrDefault(pro => pro.ID == pm.ID);
                if (project != null)
                {
                    project.ProjectName = pm.ProjectName;
                    project.Describe = pm.Describe;
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
        /// 删除项目
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public bool DeleteProject(int id)
        {
            try
            {
                Project project = PRDB.Projects.SingleOrDefault(pro => pro.ID == id);
                if (project != null)
                {
                    PRDB.Projects.Remove(project);
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