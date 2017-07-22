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
    [TeacherLoginFilter]
    public class ProjectItemController : Controller
    {
        //
        // GET: /ProjectItem/

        public ActionResult Index()
        {
            List<ProjectItemModel> pros = pib.GetProjectItems();
            return View(pros);
        }

        public ActionResult Create()
        {
            List<ProjectModel> projects = pb.GetProjects();
            ViewBag.ProjectID = new SelectList(projects, "ID", "ProjectName");
            return View();
        }
        ProjectBll pb = new ProjectBll();

        ProjectItemBll pib = new ProjectItemBll();
        [HttpPost]
        public ActionResult Create(ProjectItemModel pim)
        {

            if (pib.AddProjectItem(pim))
            {
                return RedirectToAction("index", "ProjectItem");
            }
            else
            {
                ModelState.AddModelError("Error", "添加项目子项失败！");
                List<ProjectModel> projects = pb.GetProjects();
                ViewBag.ProjectID = new SelectList(projects, "ID", "ProjectName");
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            ProjectItemModel pim = pib.GetProjectItem(id);
            List<ProjectModel> projects = pb.GetProjects();
            ViewBag.ProjectID = new SelectList(projects, "ID", "ProjectName", pim.ProjectID);
            if (pim != null)
            {
                return View(pim);
            }
            else
            {
                return RedirectToAction("index", "ProjectItem");
            }
        }
        [HttpPost]
        public ActionResult Edit(ProjectItemModel pim)
        {
            if (pib.ModifyProjectItem(pim))
            {
                return RedirectToAction("index", "ProjectItem");
            }
            else
            {
                List<ProjectModel> projects = pb.GetProjects();
                ViewBag.ProjectID = new SelectList(projects, "ID", "ProjectName", pim.ProjectID);
                ProjectItemModel newpim = pib.GetProjectItem(pim.ID);
                return View(newpim);
            }
        }

        public ActionResult Delete(int id)
        {
            ProjectItemModel pim = pib.GetProjectItem(id);
            if (pim != null)
            {
                return View(pim);
            }
            else
            {
                return RedirectToAction("index", "ProjectItem");
            }
        }
        [HttpPost]
        public ActionResult Delete(ProjectItemModel pim, int id)
        {
            if (pib.RemoveProjectItem(id))
            {
                return RedirectToAction("index", "ProjectItem");
            }
            else
            {
                return View(pim);
            }
        }
    }
}
