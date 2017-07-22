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
    public class ReviewBll
    {
        ProjectReviewDBEntities PRDBEntity = new ProjectReviewDBEntities();
        /// <summary>
        /// 利用学号得到项目评审业面的学生和项目子项信息
        /// </summary>
        /// <param name="stuno">登录学生学号</param>
        /// <returns></returns>
        public ReviewModel GetReview(string stuno)
        {
            ReviewModel rm = new ReviewModel();
            rm.StuNo = stuno;
            Student student = PRDBEntity.Students.SingleOrDefault(stu => stu.StuNo == stuno);
            rm.StuName = student.StuName;
            if (student != null)
            {
                int classid = student.ClassID;
                ClassReviewProject crp = PRDBEntity.ClassReviewProjects.SingleOrDefault(cla => cla.ClassID == classid);
                if (crp != null)
                {
                    rm.ProjectName = crp.Project.ProjectName;
                    int num = 1;
                    foreach (ProjectItem pi in crp.Project.ProjectItems)
                    {
                        rm.Items.Add(new ProjectItemModel { Number = num++, ID = pi.ID, ProjectItemName = pi.ItemName, Grade = pi.Grade });
                    }
                }
            }
            return rm;
        }

        public bool SaveGrade(string stuno, string reviewstuno, List<ProjectItemModel> items)
        {
            DbConnection con = PRDBEntity.Database.Connection;
            con.Open();
            // DbTransaction tran = con.BeginTransaction();
            using (TransactionScope tran = new TransactionScope())
            {
                try
                {
                    foreach (ProjectItemModel pi in items)
                    {
                        ProjectGrade pg = new ProjectGrade();
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

        public List<Project> GetProjects()
        {
            return PRDBEntity.Projects.ToList();
        }
        public IEnumerable<Student> GetStudents(string stuno)
        {
            Student student = PRDBEntity.Students.SingleOrDefault(stu => stu.StuNo == stuno);
            return student.Class.Students.Where(st => st.StuNo != stuno).OrderBy(st=>st.StuNo);//把自己从评审的学生中除掉，自己不能给自己评分

        }
        /// <summary>
        /// 得到汇总后的成绩
        /// </summary>
        /// <param name="projectid">项目编号</param>
        /// <param name="stuno">学号</param>
        /// <returns></returns>
        public DataTable GetSumGrade(int projectid, string stuno)
        {
            Student student = PRDBEntity.Students.SingleOrDefault(stu => stu.StuNo == stuno);
            if (student != null)
            {
                int claid = student.ClassID;
                ExecSQL esql = new ExecSQL();
                DataTable dt = esql.GetSumGrade(projectid, claid);
                return dt;
            }
            else
            {
                return null;
            }

        }


        public DataTable GetSumGrade(int projectid, int classid)
        {
            ExecSQL esql = new ExecSQL();
            DataTable dt = esql.GetSumGrade(projectid, classid);
            return dt;
        }

        public DataTable GetSumGradeOrder(int projectid, string stuno)
        {
            Student student = PRDBEntity.Students.SingleOrDefault(stu => stu.StuNo == stuno);
            if (student != null)
            {
                int claid = student.ClassID;
                ExecSQL esql = new ExecSQL();
                DataTable dt = esql.GetSumGradeOrder(projectid, claid);
                return dt;
            }
            else
            {
                return null;
            }

        }


        public DataTable GetSumGradeOrder(int projectid, int classid)
        {
            ExecSQL esql = new ExecSQL();
            DataTable dt = esql.GetSumGradeOrder(projectid, classid);
            return dt;
        }
    }
}