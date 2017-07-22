using ProjectView.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectView.Models.Bll
{
    /// <summary>
    /// 学生业务类
    /// </summary>
    public class StudentBll
    {
        ProjectReviewDBEntities PRDB;
        public StudentBll()
        {
            PRDB = new ProjectReviewDBEntities();
        }
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
            var stu = PRDB.StudentUsers.SingleOrDefault(su => su.StuNoUserName == user.UserName && su.Password == user.Password);
            if (stu != null)
            {
                backuser = stu;
                return true;
            }
            else
            {
                var tu = PRDB.TeacherUsers.SingleOrDefault(tea => tea.UserName == user.UserName && tea.Password == user.Password);
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
        /// <summary>
        /// 获取学生用户类
        /// </summary>
        /// <param name="stuno"></param>
        /// <returns></returns>
        public StudentUserModel GetStudentUser(string stuno)
        {
            var su = PRDB.StudentUsers.SingleOrDefault(stuuser => stuuser.StuNoUserName == stuno);
            var SUM = new StudentUserModel();
            SUM.UserName = su.StuNoUserName;
            SUM.Password = su.Password;
            return SUM;
        }
        /// <summary>
        /// 按学生编号获取学生
        /// </summary>
        /// <param name="stuno">学生编号</param>
        /// <returns></returns>
        public StudentModel GetStudent(string stuno)
        {
            var su = PRDB.Students.SingleOrDefault(stu => stu.StuNo == stuno);
            var SUM = new StudentModel();
            SUM.StuNo = su.StuNo;
            SUM.StuName = su.StuName;
            return SUM;
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="sum">学生用户</param>
        /// <param name="Message">修改结果消息</param>
        /// <returns></returns>
        public bool ModeifyPassword(StudentUserModel sum, out string Message)
        {
            try
            {
                var studentuser = PRDB.StudentUsers.SingleOrDefault(su => su.StuNoUserName == sum.UserName);
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
        /// <summary>
        /// 获取学生
        /// </summary>
        /// <returns></returns>
        public List<StudentModel> GetStudentModels()
        {
            var sms = new List<StudentModel>();
            foreach (var student in PRDB.Students.OrderBy(stu => stu.StuNo))
            {
                var sm = new StudentModel();
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
        /// <summary>
        /// 按班级获取学生
        /// </summary>
        /// <param name="classid">班级ID</param>
        /// <returns></returns>
        public List<StudentModel> GetStudentModels(int classid)
        {
            var sms = new List<StudentModel>();
            foreach (var student in PRDB.Students.Where(stu => stu.ClassID == classid).OrderBy(stu => stu.StuNo))
            {
                var sm = new StudentModel();
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
        /// <summary>
        /// 添加学生
        /// </summary>
        /// <param name="sm">学生</param>
        /// <returns></returns>
        public bool AddStudent(StudentModel sm)
        {
            try
            {
                var student = new Student();
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
        /// <summary>
        /// 按编号获取学生
        /// </summary>
        /// <param name="stuno">学生编号</param>
        /// <returns></returns>
        public StudentModel GetStudentModel(string stuno)
        {
            try
            {
                var student = PRDB.Students.SingleOrDefault(stu => stu.StuNo == stuno);
                if (student != null)
                {
                    var sm = new StudentModel();
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
        /// <summary>
        /// 修改学生
        /// </summary>
        /// <param name="sm">学生</param>
        /// <returns></returns>
        public bool ModifyStudent(StudentModel sm)
        {
            try
            {
                var student = PRDB.Students.SingleOrDefault(stu => stu.StuNo == sm.StuNo);
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
        /// <summary>
        /// 移除学生
        /// </summary>
        /// <param name="sm">学生</param>
        /// <returns></returns>
        public bool RemoveStudent(StudentModel sm)
        {
            try
            {
                var student = PRDB.Students.SingleOrDefault(stu => stu.StuNo == sm.StuNo);
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