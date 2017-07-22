using ProjectView.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectView.Models;

namespace ProjectView.Models.Bll
{
    public class ClassBll
    {
        ProjectReviewDBEntities PRDB = new ProjectReviewDBEntities();
        public List<ClassModel> GetClasses()
        {
            List<ClassModel> cms = new List<ClassModel>();
            foreach (Class cla in PRDB.Classes.OrderBy(cla=>cla.ID))
            {
                ClassModel cm = new ClassModel();
                cm.ID = cla.ID;
                cm.ClassName = cla.ClassName;
                cm.Describe = cla.Describe;
                cms.Add(cm);
            }
            return cms;
        }
        public bool AddClass(ClassModel cm)
        {
            try
            {
                Class cla = new Class();
                cla.ClassName = cm.ClassName;
                cla.Describe = cm.Describe;
                PRDB.Classes.Add(cla);
                PRDB.SaveChanges();
                return true ;
            }
            catch
            {
                return false;
            }
        }
        public ClassModel GetClassByID(int id)
        {
            try
            {
                Class cla = PRDB.Classes.SingleOrDefault(clas => clas.ID == id);
                if (cla != null)
                {
                    ClassModel cm = new ClassModel();
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
        public bool ModifyClass(ClassModel cm)
        {
            try
            {
                Class cla = PRDB.Classes.SingleOrDefault(clas => clas.ID == cm.ID);
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
        public bool RemoveClass(ClassModel cm)
        {
            try
            {
                Class cla = PRDB.Classes.SingleOrDefault(clas => clas.ID == cm.ID);
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