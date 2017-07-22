using ProjectView.App_Start;
using ProjectView.Models.Bll;
using ProjectView.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectView.Controllers
{
    /// <summary>
    /// 评语
    /// </summary>
    public class RemarkController : Controller
    {
        /// <summary>
        /// 项目业务类
        /// </summary>
        ProjectBll pb;
        /// <summary>
        /// 评语业务类
        /// </summary>
        RemarkBll rb;
        /// <summary>
        /// 学生业务类
        /// </summary>
        StudentBll sb;
        /// <summary>
        /// 班级业务类
        /// </summary>
        ClassBll cb;
        public RemarkController()
        {
            rb = new RemarkBll();
            pb = new ProjectBll();
            sb = new StudentBll();
            cb = new ClassBll();
        }

        [StudentLoginFilter]
        public ActionResult QueryRemark(string stuno)
        {

            ViewBag.ProjectID = new SelectList(pb.GetProjects(), "ID", "ProjectName");
            int classid = sb.GetStudentModel(stuno).ClassID;
            ViewBag.ClassID = classid;
            ViewBag.StuNo = stuno;
            return View(new List<RemarkModel>());


        }
        [StudentLoginFilter]
        [HttpPost]
        public ActionResult QueryRemark(IEnumerable<ProjectView.Models.ViewModel.RemarkModel> rms)
        {
            int projectid = int.Parse(Request.Params["ProjectID"]);
            ViewBag.ProjectID = new SelectList(pb.GetProjects(), "ID", "ProjectName", projectid);
            int classid = int.Parse(Request.Params["ClassID"]);
            ViewBag.ClassID = classid;

            return View(rb.GetRemarkModels(classid, projectid));

        }

        [TeacherLoginFilter]
        public ActionResult Index()
        {

            var cms = cb.GetClasses();
            ViewBag.ClassID = new SelectList(cms, "ID", "ClassName");
            if (cms.Count > 0)
            {
                return View(rb.GetRemarkModels(cms[0].ID));
            }
            else
            {
                return View(rb.GetRemarkModels());
            }
        }
        [TeacherLoginFilter]
        [HttpPost]
        public ActionResult Index(IEnumerable<RemarkModel> rms)
        {
            string classid = Request.Params["ClassID"];

            if (!string.IsNullOrEmpty(classid))
            {
                ViewBag.ClassID = new SelectList(cb.GetClasses(), "ID", "ClassName", classid);
                return View(rb.GetRemarkModels(int.Parse(classid)));
            }
            else
            {
                ViewBag.ClassID = new SelectList(cb.GetClasses(), "ID", "ClassName");
                return View(rb.GetRemarkModels());
            }

        }
        [TeacherLoginFilter]
        public ActionResult Create()
        {


            ViewBag.ProjectID = new SelectList(pb.GetProjects(), "ID", "ProjectName");
            var cms = cb.GetClasses();
            ViewBag.ClassID = new SelectList(cms, "ID", "ClassName");
            if (cms.Count > 0)
            {
                int classid = cms[0].ID;
                ViewBag.StuNo = new SelectList(sb.GetStudentModels(classid), "StuNo", "StuName");
            }
            else
            {
                ViewBag.StuNo = new SelectList(new List<StudentModel>(), "StuNo", "StuName");
            }

            return View();
        }
        [HttpPost]
        [TeacherLoginFilter]
        public ActionResult Create(RemarkModel rm)
        {
            ViewBag.ProjectID = new SelectList(pb.GetProjects(), "ID", "ProjectName", rm.ProjectID);

            string ClassID = Request.Params["ClassID"];
            var cms = cb.GetClasses();
            ViewBag.ClassID = new SelectList(cms, "ID", "ClassName", ClassID);
            if (cms.Count > 0)
            {
                int classid = cms[0].ID;
                ViewBag.StuNo = new SelectList(sb.GetStudentModels(classid), "StuNo", "StuName", rm.StuNo);
            }
            else
            {
                ViewBag.StuNo = new SelectList(new List<StudentModel>(), "StuNo", "StuName", rm.StuNo);
            }

            rm.RemarkDT = DateTime.Now;

            if (!rb.AddRemark(rm))
            {
                ModelState.AddModelError("Error", "添加评语失败！");
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [TeacherLoginFilter]
        public JsonResult GetStudent(int id)
        {

            string con = "";
            foreach (var v in sb.GetStudentModels(id))
            {
                con += "<option value='" + v.StuNo + "'>" + v.StuName + "</option>";
            }
            return new JsonResult { Data = con, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [TeacherLoginFilter]
        public ActionResult Edit(int id)
        {
            int classid;
            var rm = rb.GetReamrkModelByID(id, out classid);
            if (rm != null)
            {

                ViewBag.ProjectID = new SelectList(pb.GetProjects(), "ID", "ProjectName", rm.ProjectID);
               var cms = cb.GetClasses();
                ViewBag.ClassID = new SelectList(cms, "ID", "ClassName", classid);
                ViewBag.StuNo = new SelectList(sb.GetStudentModels(classid), "StuNo", "StuName", rm.StuNo);

                return View(rm);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        [TeacherLoginFilter]
        public ActionResult Edit(RemarkModel rm)
        {
            if (rb.ModifyRemark(rm))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("Error", "修改评语失败！");
                var classid = int.Parse(Request.Params["ClassID"]);

                ViewBag.ProjectID = new SelectList(pb.GetProjects(), "ID", "ProjectName", rm.ProjectID);
                var cms = cb.GetClasses();
                ViewBag.ClassID = new SelectList(cms, "ID", "ClassName", classid);
                ViewBag.StuNo = new SelectList(sb.GetStudentModels(classid), "StuNo", "StuName", rm.StuNo);
                return View(rm);
            }
        }
        [TeacherLoginFilter]
        public ActionResult Details(int id)
        {
            int classid;
            var rm = rb.GetReamrkModelByID(id, out classid);
            if (rm != null)
            {
                return View(rm);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [TeacherLoginFilter]
        public ActionResult Delete(int id)
        {
            int classid;
            var rm = rb.GetReamrkModelByID(id, out classid);
            if (rm != null)
            {
                return View(rm);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        [TeacherLoginFilter]
        public ActionResult Delete(RemarkModel rm)
        {
            if (rb.RemoveRemark(rm))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("Error", "修改评语失败！");
                return View(rm);
            }
        }

    }
}
