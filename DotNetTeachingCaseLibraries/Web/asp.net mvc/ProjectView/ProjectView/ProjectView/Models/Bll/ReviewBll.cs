using ProjectView.Models.DDL;
using ProjectView.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Transactions;
using System.Web;

namespace ProjectView.Models.Bll
{
    /// <summary>
    /// 评审业务类
    /// </summary>
    public class ReviewBll
    {
        ProjectReviewDBEntities PRDBEntity;
        ExecSQL esql;

        public ReviewBll()
        {
            PRDBEntity = new ProjectReviewDBEntities();
            esql = new ExecSQL();
        }

        /// <summary>
        /// 利用学号得到项目评审业面的学生和项目子项信息
        /// </summary>
        /// <param name="stuno">登录学生学号</param>
        /// <returns></returns>
        public ReviewModel GetReview(string stuno)
        {
            var rm = new ReviewModel();
            rm.StuNo = stuno;
            var student = PRDBEntity.Students.SingleOrDefault(stu => stu.StuNo == stuno);
            rm.StuName = student.StuName;
            if (student != null)
            {
                int classid = student.ClassID;
                var crp = PRDBEntity.ClassReviewProjects.SingleOrDefault(cla => cla.ClassID == classid);
                if (crp != null)
                {
                    rm.ProjectName = crp.Project.ProjectName;
                    int num = 1;
                    foreach (var pi in crp.Project.ProjectItems)
                    {
                        rm.Items.Add(new ProjectItemModel { Number = num++, ID = pi.ID, ProjectItemName = pi.ItemName, Grade = pi.Grade });
                    }
                }
            }
            return rm;
        }
        /// <summary>
        /// 保存成绩
        /// </summary>
        /// <param name="stuno">学生编号</param>
        /// <param name="reviewstuno">评审学生编号</param>
        /// <param name="items">项目评审子项</param>
        /// <returns></returns>
        public bool SaveGrade(string stuno, string reviewstuno, List<ProjectItemModel> items)
        {
            var con = PRDBEntity.Database.Connection;
            con.Open();
            using (var tran = new TransactionScope())
            {
                try
                {
                    foreach (var pi in items)
                    {
                        var pg = new ProjectGrade();
                        pg.ProjectItemID = pi.ID;
                        pg.Grade = pi.Grade;
                        pg.StuNo = stuno;
                        pg.GradeDT = DateTime.Now;
                        pg.ReviewStuNo = reviewstuno;
                        PRDBEntity.ProjectGrades.Add(pg);
                        PRDBEntity.SaveChanges();
                    }
                    tran.Complete();
                    return true;
                }
                catch
                {
                    tran.Dispose();
                    return false;
                }
                finally
                {
                    con.Close();
                }
            }
        }
        /// <summary>
        /// 获取全部项目
        /// </summary>
        /// <returns></returns>
        public List<Project> GetProjects()
        {
            return PRDBEntity.Projects.ToList();
        }
        /// <summary>
        /// 按学生编号获取本班学生
        /// </summary>
        /// <param name="stuno">学生编号</param>
        /// <returns></returns>
        public IEnumerable<Student> GetStudents(string stuno)
        {
            var student = PRDBEntity.Students.SingleOrDefault(stu => stu.StuNo == stuno);
            return student.Class.Students.Where(st => st.StuNo != stuno).OrderBy(st => st.StuNo);//把自己从评审的学生中除掉，自己不能给自己评分

        }
        /// <summary>
        /// 得到汇总后的成绩
        /// </summary>
        /// <param name="projectid">项目编号</param>
        /// <param name="stuno">学号</param>
        /// <returns></returns>
        public DataTable GetSumGrade(int projectid, string stuno)
        {
            var student = PRDBEntity.Students.SingleOrDefault(stu => stu.StuNo == stuno);
            if (student != null)
            {
                var claid = student.ClassID;
                var dt = esql.GetSumGrade(projectid, claid);
                return dt;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取项目评审成绩统计结果
        /// </summary>
        /// <param name="projectid">项目ID</param>
        /// <param name="classid">班级ID</param>
        /// <returns></returns>
        public DataTable GetSumGrade(int projectid, int classid)
        {
            var dt = esql.GetSumGrade(projectid, classid);
            return dt;
        }

        public DataTable GetSumGradeOrder(int projectid, string stuno)
        {
            var student = PRDBEntity.Students.SingleOrDefault(stu => stu.StuNo == stuno);
            if (student != null)
            {
                var claid = student.ClassID;
                var dt = esql.GetSumGradeOrder(projectid, claid);
                return dt;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获取项目评审成绩统计结果
        /// </summary>
        /// <param name="projectid">项目ID</param>
        /// <param name="classid">班级ID</param>
        /// <returns></returns>

        public DataTable GetSumGradeOrder(int projectid, int classid)
        {
            var dt = esql.GetSumGradeOrder(projectid, classid);
            return dt;
        }
    }
}