using ProjectView.Models.ViewModel;
using ProjectView.Models.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using ProjectView.App_Start;

namespace ProjectView.Controllers
{
    /// <summary>
    /// 项目评审
    /// </summary>
    [StudentLoginFilter]
    public class ProjectReviewController : Controller
    {
        /// <summary>
        /// 评审业务类
        /// </summary>
        ReviewBll rb;

        public ProjectReviewController()
        {
            rb = new ReviewBll();
        }

        public ActionResult Review(string stuno)
        {           
            var rm = rb.GetReview(stuno);
            ViewBag.ReviewStuNo = new SelectList(rb.GetStudents(stuno), "StuNo", "StuName");
            return View(rm);
        }

        [HttpPost]
        public ActionResult Review(string stuno, string ReviewStuNo)
        {

            ViewBag.ReviewStuNo = new SelectList(rb.GetStudents(stuno), "StuNo", "StuName", ReviewStuNo);

            var rm = rb.GetReview(stuno);
            var projectitems = new List<ProjectItemModel>();
            foreach (ProjectView.Models.ViewModel.ProjectItemModel item in rm.Items)
            {
                string gradevalue = Request.Params[item.ID.ToString()];
                if (!string.IsNullOrEmpty(gradevalue))
                {
                    int grade = int.Parse(gradevalue);
                    projectitems.Add(new ProjectItemModel { ID = item.ID, Grade = grade });
                }
            }
            string reviewstuno = Request.Params["reviewstuno"];
            if (!rb.SaveGrade(stuno, reviewstuno, projectitems))
            {
                ModelState.AddModelError("error", "注意：不能对同一个学员同一个项目进行多次打分！");
            }
            return View(rm);
        }

        public ActionResult StuQueryGrade(string reviewstuno)
        {
            ViewBag.ProjectID = new SelectList(rb.GetProjects(), "ID", "ProjectName");
            var QGM = new QueryGradeModel();
            QGM.DT = new DataTable();
            QGM.StuNo = reviewstuno;
            return View(QGM);
        }
        [HttpPost]
        public ActionResult StuQueryGrade(string reviewstuno, string projectid)
        {
            ViewBag.ProjectID = new SelectList(rb.GetProjects(), "ID", "ProjectName", projectid);
            var dt = new DataTable();
            if (!string.IsNullOrEmpty(projectid) && !string.IsNullOrEmpty(reviewstuno))
            {
                int proid = int.Parse(projectid);
                dt = rb.GetSumGrade(proid, reviewstuno);
            }
            var QGM = new QueryGradeModel();
            QGM.DT = dt;
            QGM.StuNo = reviewstuno;
            return View(QGM);
        }
    }
}
