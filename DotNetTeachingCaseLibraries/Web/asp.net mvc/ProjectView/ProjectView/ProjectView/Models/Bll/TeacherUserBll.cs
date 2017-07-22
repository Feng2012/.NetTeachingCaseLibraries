using ProjectView.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectView.Models.Bll
{
    public class TeacherUserBll
    {
        ProjectReviewDBEntities PRDB = new ProjectReviewDBEntities();
        public List<TeacherUserModel> GetTeacherModels()
        {
            List<TeacherUserModel> tums = new List<TeacherUserModel>();
            foreach (TeacherUser tu in PRDB.TeacherUsers.OrderBy(tu=>tu.TeacherID))
            {
                TeacherUserModel tum = new TeacherUserModel();
                tum.TeacherID = tu.TeacherID;
                tum.TeacherName = tu.Teacher.TeacherName;
                tum.Password = tu.Password;
                tum.UserName = tu.UserName;
                tums.Add(tum);
            }
            return tums;
        }

        public bool AddTeacher(TeacherUserModel tum)
        {
            try
            {
                TeacherUser tu = new TeacherUser();
                tu.UserName = tum.UserName;
                tu.Password = tum.Password;
                tu.TeacherID = tum.TeacherID;
                PRDB.TeacherUsers.Add(tu);
                PRDB.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool ModeifyTeacher(TeacherUserModel tum)
        {
            try
            {
                TeacherUser tu = PRDB.TeacherUsers.SingleOrDefault(tus => tus.UserName == tum.UserName);
                if (tu != null)
                {
                    tu.Password = tum.Password;
                    tu.TeacherID = tum.TeacherID;
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
        public bool RemoveTeacher(TeacherUserModel tum)
        {
            try
            {
                TeacherUser tu = PRDB.TeacherUsers.SingleOrDefault(tus => tus.UserName == tum.UserName);
                if (tu != null)
                {
                    PRDB.TeacherUsers.Remove(tu);
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
        public TeacherUserModel GetTeacherUserModel(string username)
        {
            try
            {
                TeacherUser tu = PRDB.TeacherUsers.SingleOrDefault(tuser => tuser.UserName == username);
                if (tu != null)
                {
                    TeacherUserModel tum = new TeacherUserModel();
                    tum.UserName = tu.UserName;
                    tum.Password = tu.Password;
                    tum.TeacherID = tu.TeacherID;
                    return tum;
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