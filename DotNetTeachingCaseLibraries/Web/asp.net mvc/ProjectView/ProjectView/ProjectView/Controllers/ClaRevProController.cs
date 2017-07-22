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
    /// 班级项目类
    /// </summary>
    [TeacherLoginFilter]
    public class ClaRevProController : Controller
    {
        /// <summary>
        /// 项目业务类
        /// </summary>
        ProjectBll pb;
        /// <summary>
        /// 班级项目类
        /// </summary>
        ClaRevProBll crpb;
        public ClaRevProController()
        {
            pb = new ProjectBll();
            crpb = new ClaRevProBll();
        }
    
        public ActionResult Index()
        {
            return View(crpb.GetClaRevProModels());
        }

        public ActionResult Edit(int id)
        {
            var crpm = crpb.GetCRPByID(id);
            if (crpm != null)
            {
              
                ViewBag.ProjectID = new SelectList(pb.GetProjects(), "ID", "ProjectName", crpm.ProjectID);
                return View(crpm);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(ClaRevProModel crpm)
        {
            if (crpb.ModifyCRP(crpm))
            {
                return RedirectToAction("Index");
            }
            else
            {               
                ViewBag.ProjectID = new SelectList(pb.GetProjects(), "ID", "ProjectName", crpm.ProjectID);
                return View(crpm);
            }
        }
    }
}
