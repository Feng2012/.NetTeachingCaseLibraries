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
    /// 班级
    /// </summary>
    [TeacherLoginFilter]
    public class ClassController : Controller
    {
        /// <summary>
        /// 班级业务类
        /// </summary>
        ClassBll cb;
        public ClassController()
        {
            cb = new ClassBll();
        }

        public ActionResult Index()
        {

            var cms = cb.GetClasses();
            return View(cms);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ClassModel cm)
        {
            if (cb.AddClass(cm))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var cm = cb.GetClassByID(id);
            if (cm != null)
            {
                return View(cm);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(ClassModel cm)
        {
            if (cb.ModifyClass(cm))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(cm);
            }
        }

        public ActionResult Delete(int id)
        {
            var cm = cb.GetClassByID(id);
            if (cm != null)
            {
                return View(cm);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Delete(ClassModel cm)
        {
            if (cb.RemoveClass(cm))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(cm);
            }
        }
    }
}
