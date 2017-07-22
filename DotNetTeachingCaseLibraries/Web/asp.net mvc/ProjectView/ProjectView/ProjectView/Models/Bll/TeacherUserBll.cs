using ProjectView.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectView.Models.Bll
{
    /// <summary>
    /// 教师用户
    /// </summary>
    public class TeacherUserBll
    {
        ProjectReviewDBEntities PRDB;

        public TeacherUserBll()
        {
            PRDB = new ProjectReviewDBEntities();
        }
        /// <summary>
        /// 获取全部教师
        /// </summary>
        /// <returns></returns>
        public List<TeacherUserModel> GetTeacherModels()
        {
            var tums = new List<TeacherUserModel>();
            foreach (var tu in PRDB.TeacherUsers.OrderBy(tu => tu.TeacherID))
            {
                var tum = new TeacherUserModel();
                tum.TeacherID = tu.TeacherID;
                tum.TeacherName = tu.Teacher.TeacherName;
                tum.Password = tu.Password;
                tum.UserName = tu.UserName;
                tums.Add(tum);
            }
            return tums;
        }
        /// <summary>
        /// 添加教师用户
        /// </summary>
        /// <param name="tum"></param>
        /// <returns></returns>
        public bool AddTeacher(TeacherUserModel tum)
        {
            try
            {
                var tu = new TeacherUser();
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
        /// <summary>
        /// 修改教师用户
        /// </summary>
        /// <param name="tum">教师用户</param>
        /// <returns></returns>
        public bool ModeifyTeacher(TeacherUserModel tum)
        {
            try
            {
                var tu = PRDB.TeacherUsers.SingleOrDefault(tus => tus.UserName == tum.UserName);
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
        /// <summary>
        /// 删除教师用户
        /// </summary>
        /// <param name="tum">教师用户</param>
        /// <returns></returns>
        public bool RemoveTeacher(TeacherUserModel tum)
        {
            try
            {
                var tu = PRDB.TeacherUsers.SingleOrDefault(tus => tus.UserName == tum.UserName);
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
        /// <summary>
        /// 按用户名获取教师用户名
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        public TeacherUserModel GetTeacherUserModel(string username)
        {
            try
            {
                var tu = PRDB.TeacherUsers.SingleOrDefault(tuser => tuser.UserName == username);
                if (tu != null)
                {
                    var tum = new TeacherUserModel();
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