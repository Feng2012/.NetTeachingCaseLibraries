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
    /// 项目子项
    /// </summary>
    [TeacherLoginFilter]
    public class ProjectItemController : Controller
    {
        /// <summary>
        /// 项目业务类
        /// </summary>
        ProjectBll pb;
        /// <summary>
        /// 项目子项业务类
        /// </summary>
        ProjectItemBll pib;

        public ProjectItemController()
        {
            pb = new ProjectBll();
            pib = new ProjectItemBll();
        }

        public ActionResult Index()
        {
            var pros = pib.GetProjectItems();
            return View(pros);
        }

        public ActionResult Create()
        {
            var projects = pb.GetProjects();
            ViewBag.ProjectID = new SelectList(projects, "ID", "ProjectName");
            return View();
        }

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
                var projects = pb.GetProjects();
                ViewBag.ProjectID = new SelectList(projects, "ID", "ProjectName");
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var pim = pib.GetProjectItem(id);
            var projects = pb.GetProjects();
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
                var projects = pb.GetProjects();
                ViewBag.ProjectID = new SelectList(projects, "ID", "ProjectName", pim.ProjectID);
                var newpim = pib.GetProjectItem(pim.ID);
                return View(newpim);
            }
        }

        public ActionResult Delete(int id)
        {
            var pim = pib.GetProjectItem(id);
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
