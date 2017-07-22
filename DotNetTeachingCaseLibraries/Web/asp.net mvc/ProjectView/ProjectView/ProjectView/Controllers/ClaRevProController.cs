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
    public class ClaRevProController : Controller
    {
        //
        // GET: /ClaRevPro/

        ClaRevProBll crpb = new ClaRevProBll();
        public ActionResult Index()
        {
            return View(crpb.GetClaRevProModels());
        }

        public ActionResult Edit(int id)
        {
            ClaRevProModel crpm = crpb.GetCRPByID(id);
            if (crpm != null)
            {
                ProjectBll pb = new ProjectBll();
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
                ProjectBll pb = new ProjectBll();
                ViewBag.ProjectID = new SelectList(pb.GetProjects(), "ID", "ProjectName", crpm.ProjectID);
                return View(crpm);
            }
        }
    }
}
