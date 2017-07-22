using ProjectView.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectView.Models.Bll
{
    public class StudentBll
    {
        ProjectReviewDBEntities PRDB = new ProjectReviewDBEntities();

        /// <summary>
        /// 验证用户名
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public bool ValidateStuUserName(string UserName)
        {
            int count = PRDB.StudentUsers.Where(su => su.StuNoUserName == UserName).Count();
            return count > 0 ? true : false;
        }
        /// <summary>
        /// 验证学生用户存在不存在
        /// </summary>
        /// <param name="user">用户名和学生的实体</param>
        /// <returns></returns>
        public bool ValidateUser(UserModel user, out object backuser)
        {
            StudentUser stu = PRDB.StudentUsers.SingleOrDefault(su => su.StuNoUserName == user.UserName && su.Password == user.Password);
            if (stu != null)
            {
                backuser = stu;
                return true;
            }
            else
            {
                TeacherUser tu = PRDB.TeacherUsers.SingleOrDefault(tea => tea.UserName == user.UserName && tea.Password == user.Password);
                if (tu != null)
                {
                    backuser = tu;
                    return true;
                }
                else
                {
                    backuser = null;
                    return false;
                }
            }
        }

        public StudentUserModel GetStudentUser(string stuno)
        {

            StudentUser su = PRDB.StudentUsers.SingleOrDefault(stuuser => stuuser.StuNoUserName == stuno);
            StudentUserModel SUM = new StudentUserModel();
            SUM.UserName = su.StuNoUserName;
            SUM.Password = su.Password;
            return SUM;
        }
        public StudentModel GetStudent(string stuno)
        {
            Student su = PRDB.Students.SingleOrDefault(stu => stu.StuNo == stuno);
            StudentModel SUM = new StudentModel();
            SUM.StuNo = su.StuNo;
            SUM.StuName = su.StuName;
            return SUM;
        }

        public bool ModeifyPassword(StudentUserModel sum, out string Message)
        {
            try
            {
                StudentUser studentuser = PRDB.StudentUsers.SingleOrDefault(su => su.StuNoUserName == sum.UserName);
                if (studentuser.Password == sum.OldPassword)
                {
                    studentuser.Password = sum.NewPassword;
                    PRDB.SaveChanges();
                    Message = "修改成功！";
                    return true;
                }
                else
                {
                    Message = "旧密码不正确！";
                    return false;
                }
            }
            catch (Exception exc)
            {
                Message = exc.Message;
                return false;
            }
        }

        public List<StudentModel> GetStudentModels()
        {
            List<StudentModel> sms = new List<StudentModel>();
            foreach (Student student in PRDB.Students.OrderBy(stu=>stu.StuNo))
            {
                StudentModel sm = new StudentModel();
                sm.StuNo = student.StuNo;
                sm.StuName = student.StuName;
                if (student.Sex.HasValue && student.Sex.Value)
                {
                    sm.Sex = "男";
                }
                else
                {
                    sm.Sex = "女";
                }
                if (student.Birthday.HasValue)
                {
                    sm.Birthday = student.Birthday.Value;
                }
                sm.Contact = student.Contact;
                sm.PersonID = student.PersonID;
                sm.ClassID = student.ClassID;
                sm.ClassName = student.Class.ClassName;
                sms.Add(sm);
            }
            return sms;
        }
        public List<StudentModel> GetStudentModels(int classid)
        {
            List<StudentModel> sms = new List<StudentModel>();
            foreach (Student student in PRDB.Students.Where(stu => stu.ClassID == classid).OrderBy(stu=>stu.StuNo))
            {
                StudentModel sm = new StudentModel();
                sm.StuNo = student.StuNo;
                sm.StuName = student.StuName;
                if (student.Sex.HasValue && student.Sex.Value)
                {
                    sm.Sex = "男";
                }
                else
                {
                    sm.Sex = "女";
                }
                if (student.Birthday.HasValue)
                {
                    sm.Birthday = student.Birthday.Value;
                }
                sm.Contact = student.Contact;
                sm.PersonID = student.PersonID;
                sm.ClassID = student.ClassID;
                sm.ClassName = student.Class.ClassName;
                sms.Add(sm);
            }
            return sms;
        }

        public bool AddStudent(StudentModel sm)
        {
            try
            {
                Student student = new Student();
                student.StuNo = sm.StuNo;
                student.StuName = sm.StuName;
                if (sm.Sex == "男")
                {
                    student.Sex = true;
                }
                else
                {
                    student.Sex = false;
                }
                student.Birthday = sm.Birthday;
                student.Contact = sm.Contact;
                student.PersonID = sm.PersonID;
                student.ClassID = sm.ClassID;
                PRDB.Students.Add(student);
                PRDB.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public StudentModel GetStudentModel(string stuno)
        {
            try
            {
                Student student = PRDB.Students.SingleOrDefault(stu => stu.StuNo == stuno);
                if (student != null)
                {
                    StudentModel sm = new StudentModel();
                    sm.StuNo = student.StuNo;
                    sm.StuName = student.StuName;
                    if (student.Sex.HasValue && student.Sex.Value)
                    {
                        sm.Sex = "男";
                    }
                    else
                    {
                        sm.Sex = "女";
                    }
                    if (student.Birthday.HasValue)
                    {
                        sm.Birthday = student.Birthday.Value;
                    }
                    sm.Contact = student.Contact;
                    sm.PersonID = student.PersonID;
                    sm.ClassID = student.ClassID;
                    sm.ClassName = student.Class.ClassName;
                    return sm;
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

        public bool ModifyStudent(StudentModel sm)
        {
            try
            {
                Student student = PRDB.Students.SingleOrDefault(stu => stu.StuNo == sm.StuNo);
                if (student != null)
                {
                    student.StuName = sm.StuName;
                    if (sm.Sex == "男")
                    {
                        student.Sex = true;
                    }
                    else
                    {
                        student.Sex = false;
                    }

                    student.Birthday = sm.Birthday;
                    student.Contact = sm.Contact;
                    student.PersonID = sm.PersonID;
                    student.ClassID = sm.ClassID;
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

        public bool RemoveStudent(StudentModel sm)
        {
            try
            {
                Student student = PRDB.Students.SingleOrDefault(stu => stu.StuNo == sm.StuNo);
                if (student != null)
                {
                    PRDB.Students.Remove(student);
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