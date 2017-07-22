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
    /// 教师用户
    /// </summary>
    [TeacherLoginFilter]
    public class TeacherUserController : Controller
    {

        /// <summary>
        /// 教师业务类
        /// </summary>
        TeacherUserBll tub;
        public TeacherUserController()
        {
            tub = new TeacherUserBll();
        }

        public ActionResult Index()
        {
            var tums = tub.GetTeacherModels();
            return View(tums);
        }


        TeacherBll tb = new TeacherBll();
        public ActionResult Create()
        {
            ViewBag.TeacherID = new SelectList(tb.GetTeachers(), "ID", "TeacherName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(TeacherUserModel tum)
        {
            if (tub.AddTeacher(tum))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("Error", "添加用户失败！");
                ViewBag.TeacherID = new SelectList(tb.GetTeachers(), "ID", "TeacherName", tum.TeacherID);
                return View();
            }
        }


        public ActionResult Edit(string UserName)
        {
            var tum = tub.GetTeacherUserModel(UserName);
            if (tum != null)
            {
                ViewBag.TeacherID = new SelectList(tb.GetTeachers(), "ID", "TeacherName", tum.TeacherID);
                return View(tum);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult Edit(TeacherUserModel tum)
        {

            if (tub.ModeifyTeacher(tum))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.TeacherID = new SelectList(tb.GetTeachers(), "ID", "TeacherName", tum.TeacherID);
                ModelState.AddModelError("Error", "修改教师用户信息失败!");
                return View(tum);
            }
        }
        public ActionResult Delete(string UserName)
        {
            var tum = tub.GetTeacherUserModel(UserName);
            if (tum != null)
            {
                return View(tum);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult Delete(TeacherUserModel tum)
        {
            if (tub.RemoveTeacher(tum))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("Error", "删除教师用户信息失败!");
                return View(tum);
            }
        }
    }
}
