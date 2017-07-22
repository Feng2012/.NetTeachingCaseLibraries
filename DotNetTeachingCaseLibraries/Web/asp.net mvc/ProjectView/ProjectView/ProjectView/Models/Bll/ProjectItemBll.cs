using ProjectView.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectView.Models.Bll
{
    public class ProjectItemBll
    {
        ProjectReviewDBEntities PRDB = new ProjectReviewDBEntities();
        public List<ProjectItemModel> GetProjectItems()
        {
            List<ProjectItemModel> pros = new List<ProjectItemModel>();
            foreach (ProjectItem pi in PRDB.ProjectItems.OrderBy(item => item.ID))
            {
                ProjectItemModel pim = new ProjectItemModel();
                pim.ID = pi.ID;
                pim.ProjectItemName = pi.ItemName;
                pim.ProjectID = pi.ProjectID;
                pim.Grade = pi.Grade;
                pim.ProjectName = pi.Project.ProjectName;
                pros.Add(pim);
            }
            return pros;
        }
        public List<ProjectItemModel> GetProjectItems(int projectid)
        {
            List<ProjectItemModel> pros = new List<ProjectItemModel>();
            foreach (ProjectItem pi in PRDB.ProjectItems.Where(pi => pi.ProjectID == projectid).OrderBy(ite => ite.ID))
            {
                ProjectItemModel pim = new ProjectItemModel();
                pim.ID = pi.ID;
                pim.ProjectItemName = pi.ItemName;
                pim.ProjectID = pi.ProjectID;
                pim.Grade = pi.Grade;
                pim.ProjectName = pi.Project.ProjectName;
                pros.Add(pim);
            }
            return pros;
        }
        public ProjectItemModel GetProjectItem(int id)
        {
            ProjectItem pi = PRDB.ProjectItems.SingleOrDefault(pis => pis.ID == id);
            if (pi != null)
            {
                ProjectItemModel pim = new ProjectItemModel();
                pim.ID = pi.ID;
                pim.ProjectItemName = pi.ItemName;
                pim.ProjectID = pi.ProjectID;
                pim.Grade = pi.Grade;
                pim.ProjectName = pi.Project.ProjectName;
                return pim;
            }
            return null;

        }
        public bool AddProjectItem(ProjectItemModel pim)
        {
            try
            {
                ProjectItem pi = new ProjectItem();
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
        public bool ModifyProjectItem(ProjectItemModel pim)
        {
            try
            {
                ProjectItem pi = PRDB.ProjectItems.SingleOrDefault(pis => pis.ID == pim.ID);
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
        public bool RemoveProjectItem(int id)
        {
            try
            {
                ProjectItem pi = PRDB.ProjectItems.SingleOrDefault(pis => pis.ID == id);
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