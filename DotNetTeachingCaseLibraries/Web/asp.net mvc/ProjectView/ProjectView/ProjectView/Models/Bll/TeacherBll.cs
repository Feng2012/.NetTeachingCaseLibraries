using ProjectView.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectView.Models.Bll
{
    public class TeacherBll
    {
        ProjectReviewDBEntities PRDBEntity = new ProjectReviewDBEntities();


        public Teacher GetTeacher(int TeacherID)
        {
            return PRDBEntity.Teachers.SingleOrDefault(tea => tea.ID == TeacherID);
        }
        public List<TeacherModel> GetTeachers()
        {
            List<TeacherModel> tms = new List<TeacherModel>();
            foreach (Teacher teacher in PRDBEntity.Teachers.OrderBy(tea=>tea.ID))
            {
                TeacherModel tm = new TeacherModel();
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

        public bool AddTeacher(TeacherModel tm)
        {
            try
            {
                Teacher teacher = new Teacher();
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
        public bool ModifyTeacher(TeacherModel tm)
        {
            try
            {
                Teacher teacher = PRDBEntity.Teachers.SingleOrDefault(tea => tea.ID == tm.ID);
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
        public bool RemoveTeacher(int id)
        {
            try
            {
                Teacher teacher = PRDBEntity.Teachers.SingleOrDefault(tea => tea.ID == id);
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
        public TeacherModel GetTeacherModel(int id)
        {
            Teacher teacher = PRDBEntity.Teachers.SingleOrDefault(tea => tea.ID == id);
            if (teacher != null)
            {
                TeacherModel tm = new TeacherModel();
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