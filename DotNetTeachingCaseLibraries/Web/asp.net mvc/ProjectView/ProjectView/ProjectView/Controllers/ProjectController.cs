using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectView.Models;
using ProjectView.Models.ViewModel;
using ProjectView.Models.Bll;
using ProjectView.App_Start;

namespace ProjectView.Controllers
{
    [TeacherLoginFilter]
    public class ProjectController : Controller
    {
        //
        // GET: /Project/

        public ActionResult Create()
        {
            ProjectModel pm = new ProjectModel();
            return View(pm);
        }
        [HttpPost]
        public ActionResult Create(ProjectModel pm)
        {
            if (pb.AddProject(pm))
            {
                return RedirectToAction("index", "Project");
            }
            else
            {
                ModelState.AddModelError("Error", "添加项目失败！");
                ProjectModel temppm = pb.GetProjectByID(pm.ID);
                return View(temppm);
            }         
        }
        public ActionResult Index()
        {
            List<ProjectModel> pros = pb.GetProjects();
            return View(pros);
        }
        ProjectBll pb = new ProjectBll();
        public ActionResult Edit(int id)
        {
            ProjectModel pm = pb.GetProjectByID(id);
            return View(pm);
        }

        [HttpPost]
        public ActionResult Edit(ProjectModel pm)
        {
            if (pb.ModiftyProject(pm))
            {
                return RedirectToAction("index", "Project");
            }
            else
            {
                ModelState.AddModelError("Error", "修改项目失败！");
                 ProjectModel temppm = pb.GetProjectByID(pm.ID);
                 return View(temppm);
            }
        }

        public ActionResult Delete(int id)
        {
            ProjectModel pm = pb.GetProjectByID(id);
            return View(pm);
        }
        [HttpPost]
        public ActionResult Delete(ProjectModel pm,int id)
        {
            if (pb.DeleteProject(id))
            {
                return RedirectToAction("index", "Project");
            }
            else
            {
                ModelState.AddModelError("Error", "删除项目失败！");
                ProjectModel temppm = pb.GetProjectByID(id);
                return View(temppm);
            }
        }




    }
}
