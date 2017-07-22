using ProjectView.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectView.Models.Bll
{
    public class ClaRevProBll
    {
        ProjectReviewDBEntities PRDB = new ProjectReviewDBEntities();
        public List<ClaRevProModel> GetClaRevProModels()
        {
            List<ClaRevProModel> CRPMS = new List<ClaRevProModel>();
            foreach (var v in PRDB.ClassReviewProjects.OrderBy(crp=>crp.ID))
            {
                ClaRevProModel crm = new ClaRevProModel();
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

        public bool ModifyCRP(ClaRevProModel crpm)
        {
            try
            {
                ClassReviewProject crp = PRDB.ClassReviewProjects.SingleOrDefault(cr => cr.ID == crpm.ID);
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
        public ClaRevProModel GetCRPByID(int id)
        {
            try
            {
                ClassReviewProject crp = PRDB.ClassReviewProjects.SingleOrDefault(cr => cr.ID == id);
                if (crp != null)
                {
                    ClaRevProModel crm = new ClaRevProModel();
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