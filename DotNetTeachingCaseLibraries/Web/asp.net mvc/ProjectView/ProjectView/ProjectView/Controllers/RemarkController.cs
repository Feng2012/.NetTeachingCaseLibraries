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
    public class RemarkController : Controller
    {
        //
        // GET: /Remark/

        RemarkBll rb = new RemarkBll();

        [StudentLoginFilter]
        public ActionResult QueryRemark(string stuno)
        {
            ProjectBll pb = new ProjectBll();
            ViewBag.ProjectID = new SelectList(pb.GetProjects(), "ID", "ProjectName");
            StudentBll sb = new StudentBll();
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
            ProjectBll pb = new ProjectBll();
            ViewBag.ProjectID = new SelectList(pb.GetProjects(), "ID", "ProjectName", projectid);
            int classid = int.Parse(Request.Params["ClassID"]);
            ViewBag.ClassID = classid;

            return View(rb.GetRemarkModels(classid, projectid));

        }
        
        [TeacherLoginFilter]
        public ActionResult Index()
        {
            ClassBll cb = new ClassBll();
            List<ClassModel> cms = cb.GetClasses();
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
            ClassBll cb = new ClassBll();
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
            ClassBll cb = new ClassBll();
            ProjectBll pb = new ProjectBll();
            StudentBll sb = new StudentBll();

            ViewBag.ProjectID = new SelectList(pb.GetProjects(), "ID", "ProjectName");
            List<ClassModel> cms = cb.GetClasses();
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
            ClassBll cb = new ClassBll();
            ProjectBll pb = new ProjectBll();
            StudentBll sb = new StudentBll();
            ViewBag.ProjectID = new SelectList(pb.GetProjects(), "ID", "ProjectName", rm.ProjectID);

            string ClassID = Request.Params["ClassID"];
            List<ClassModel> cms = cb.GetClasses();
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
            StudentBll sb = new StudentBll();
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
            RemarkModel rm = rb.GetReamrkModelByID(id, out classid);
            if (rm != null)
            {
                ClassBll cb = new ClassBll();
                ProjectBll pb = new ProjectBll();
                StudentBll sb = new StudentBll();
                ViewBag.ProjectID = new SelectList(pb.GetProjects(), "ID", "ProjectName", rm.ProjectID);
                List<ClassModel> cms = cb.GetClasses();
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
                int classid = int.Parse(Request.Params["ClassID"]);
                ClassBll cb = new ClassBll();
                ProjectBll pb = new ProjectBll();
                StudentBll sb = new StudentBll();
                ViewBag.ProjectID = new SelectList(pb.GetProjects(), "ID", "ProjectName", rm.ProjectID);
                List<ClassModel> cms = cb.GetClasses();
                ViewBag.ClassID = new SelectList(cms, "ID", "ClassName", classid);
                ViewBag.StuNo = new SelectList(sb.GetStudentModels(classid), "StuNo", "StuName", rm.StuNo);
                return View(rm);
            }
        }
        [TeacherLoginFilter]
        public ActionResult Details(int id)
        {
            int classid;
            RemarkModel rm = rb.GetReamrkModelByID(id, out classid);
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
            RemarkModel rm = rb.GetReamrkModelByID(id, out classid);
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
