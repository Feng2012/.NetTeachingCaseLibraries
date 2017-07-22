using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectView.Models;
using ProjectView.Models.ViewModel;

namespace ProjectView.Models.Bll
{

    public class ProjectBll
    {
        ProjectReviewDBEntities PRDB = new ProjectReviewDBEntities();
        public bool AddProject(ProjectModel pm)
        {
            try
            {
                Project project = new Project();
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
        public List<ProjectModel> GetProjects()
        {
            List<ProjectModel> pros = new List<ProjectModel>();
            foreach (Project pro in PRDB.Projects.OrderBy(pro=>pro.ID))
            {
                ProjectModel pm = new ProjectModel();
                pm.ID = pro.ID;
                pm.ProjectName = pro.ProjectName;
                pm.Describe = pro.Describe;
                pros.Add(pm);
            }
            return pros;
        }

        public ProjectModel GetProjectByID(int id)
        {
            Project project = PRDB.Projects.SingleOrDefault(pro => pro.ID == id);
            ProjectModel pm = new ProjectModel();
            if (project != null)
            {
                pm.ID = project.ID;
                pm.ProjectName = project.ProjectName;
                pm.Describe = project.Describe;
            }
            return pm;
        }
        public bool ModiftyProject(ProjectModel pm)
        {
            try
            {
                Project project = PRDB.Projects.SingleOrDefault(pro => pro.ID == pm.ID);
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