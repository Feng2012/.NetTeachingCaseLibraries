using ProjectView.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectView.Models.Bll
{
    /// <summary>
    /// 教师业务类
    /// </summary>
    public class TeacherBll
    {
        ProjectReviewDBEntities PRDBEntity;

        public TeacherBll()
        {
            PRDBEntity = new ProjectReviewDBEntities();
        }
        /// <summary>
        /// 按ID获取教师
        /// </summary>
        /// <param name="TeacherID">教师ID</param>
        /// <returns></returns>
        public Teacher GetTeacher(int TeacherID)
        {
            return PRDBEntity.Teachers.SingleOrDefault(tea => tea.ID == TeacherID);
        }
        /// <summary>
        /// 获取全部教师
        /// </summary>
        /// <returns></returns>
        public List<TeacherModel> GetTeachers()
        {
            var tms = new List<TeacherModel>();
            foreach (var teacher in PRDBEntity.Teachers.OrderBy(tea => tea.ID))
            {
                var tm = new TeacherModel();
                tm.ID = teacher.ID;
                tm.TeacherName = teacher.TeacherName;
                if (teacher.Sex.HasValue && teacher.Sex.Value)
                {
                    tm.Sex = Sex.男.ToString();
                }
                else
                {
                    tm.Sex = Sex.女.ToString();
                }
                tms.Add(tm);
            }
            return tms;
        }
        /// <summary>
        /// 添加教师
        /// </summary>
        /// <param name="tm">教师</param>
        /// <returns></returns>
        public bool AddTeacher(TeacherModel tm)
        {
            try
            {
                var teacher = new Teacher();
                teacher.TeacherName = tm.TeacherName;
                if (tm.Sex == "男")
                {
                    teacher.Sex = true;
                }
                else
                {
                    teacher.Sex = false;
                }
                PRDBEntity.Teachers.Add(teacher);
                PRDBEntity.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 修改教师
        /// </summary>
        /// <param name="tm">教师</param>
        /// <returns></returns>
        public bool ModifyTeacher(TeacherModel tm)
        {
            try
            {
                var teacher = PRDBEntity.Teachers.SingleOrDefault(tea => tea.ID == tm.ID);
                if (teacher != null)
                {
                    teacher.TeacherName = tm.TeacherName;
                    if (tm.Sex == "男")
                    {
                        teacher.Sex = true;
                    }
                    else
                    {
                        teacher.Sex = false;
                    }
                    PRDBEntity.SaveChanges();
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
        /// 删除教师
        /// </summary>
        /// <param name="id">教师ID</param>
        /// <returns></returns>
        public bool RemoveTeacher(int id)
        {
            try
            {
                var teacher = PRDBEntity.Teachers.SingleOrDefault(tea => tea.ID == id);
                if (teacher != null)
                {
                    PRDBEntity.Teachers.Remove(teacher);
                    PRDBEntity.SaveChanges();
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
        /// 按ID获取教师
        /// </summary>
        /// <param name="id">教师ID</param>
        /// <returns></returns>
        public TeacherModel GetTeacherModel(int id)
        {
            var teacher = PRDBEntity.Teachers.SingleOrDefault(tea => tea.ID == id);
            if (teacher != null)
            {
                var tm = new TeacherModel();
                tm.ID = teacher.ID;
                tm.TeacherName = teacher.TeacherName;
                if (teacher.Sex.HasValue && teacher.Sex.Value)
                {
                    tm.Sex = Sex.男.ToString();
                }
                else
                {
                    tm.Sex = Sex.女.ToString();
                }
                return tm;
            }
            else
            {
                return null;
            }
        }

    }
}