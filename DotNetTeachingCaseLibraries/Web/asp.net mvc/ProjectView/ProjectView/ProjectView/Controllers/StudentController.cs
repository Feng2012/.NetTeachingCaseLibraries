﻿using ProjectView.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectView.Models.Bll;
using ProjectView.Models;
using System.Web.Security;
using System.Security.Principal;
using ProjectView.App_Start;

namespace ProjectView.Controllers
{
    /// <summary>
    /// 班级
    /// </summary>
    public class StudentController : Controller
    {
        /// <summary>
        /// 班级业务类
        /// </summary>
        StudentBll sb;
        /// <summary>
        /// 教师用户类
        /// </summary>
        TeacherUserBll tub;
        /// <summary>
        /// 班级
        /// </summary>
        ClassBll cb;

        public StudentController()
        {
            sb = new StudentBll();
            tub = new TeacherUserBll();
            cb = new ClassBll();
        }

        #region 无权限Action

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(UserModel user)
        {
            //判断是学生登录还是老师登录            
            object loguser;
            if (sb.ValidateUser(user, out loguser))
            {

                if (loguser is StudentUser)
                {
                    //加载学生访问的Cookie
                    var ticket = new FormsAuthenticationTicket(1, user.UserName,
                        DateTime.Now, DateTime.Now.Add(FormsAuthentication.Timeout), true, user.UserName);

                    string cookiename = FormsAuthentication.FormsCookieName + "Student";
                    var cookie = new HttpCookie(cookiename, FormsAuthentication.Encrypt(ticket));
                    Response.Cookies.Add(cookie);

                    return RedirectToActionPermanent("MainPage", "Student", new { stuno = user.UserName });
                }
                else
                {
                    //加载教师访问的Cookie
                    var tu = loguser as TeacherUser;
                    var ticket = new FormsAuthenticationTicket(1, tu.TeacherID.ToString(),
              DateTime.Now, DateTime.Now.Add(FormsAuthentication.Timeout), true, tu.TeacherID.ToString());
                    string cookiename = FormsAuthentication.FormsCookieName + "Teacher";
                    HttpCookie cookie = new HttpCookie(cookiename, FormsAuthentication.Encrypt(ticket));
                    Response.Cookies.Add(cookie);
                    return RedirectToActionPermanent("MainPage", "Teacher");
                }
            }
            else
            {
                ModelState.AddModelError("error", "用户名或密码不正确！");
                return View();
            }



        }
        /// <summary>
        /// 验证用户名是否存在
        /// </summary>
        /// <param name="UserName">传过来的用户名</param>
        /// <returns></returns>
        public ActionResult ValidateUserName(string UserName)
        {

            var tum = tub.GetTeacherUserModel(UserName);
            var teavalue = tum == null ? false : true;
            var stuvalue = sb.ValidateStuUserName(UserName);
            if (teavalue || stuvalue)
            {
                return new JsonResult { Data = true, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            else
            {
                return new JsonResult { Data = false, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

        }
        #endregion

        #region  学生权限的Action
        [StudentLoginFilter]
        public ActionResult MainPage()
        {
            var stuno = StudentLoginFilter.StuNo;   
            var sm = sb.GetStudent(stuno);
            return View(sm);
        }
        [StudentLoginFilter]
        public ActionResult ChangPassword(string stuno)
        {      
            var sum = sb.GetStudentUser(stuno);
            return View(sum);
        }
        [StudentLoginFilter]
        [HttpPost]
        public ActionResult ChangPassword(StudentUserModel sum, string stuno)
        {      
            sum.UserName = stuno;
            string message;
            if (!sb.ModeifyPassword(sum, out message))
            {
                ModelState.AddModelError("error", message);
                return View(sum);
            }
            else
            {
                return RedirectToActionPermanent("MainPage", "Student", new { stuno = stuno });
            }
        }

        [StudentLoginFilter]
        public ActionResult Perfect(string stuno)
        {
            var sm = sb.GetStudentModel(stuno);
            return View(sm);
        }
        [HttpPost]
        [StudentLoginFilter]
        public ActionResult Perfect(StudentModel sm)
        {
            if (sb.ModifyStudent(sm))
            {
                return RedirectToAction("MainPage", "Student", new { stuno = sm.StuNo });
            }
            else
            {
                var cms = cb.GetClasses();
                ViewBag.ClassID = new SelectList(cms, "ID", "ClassName", sm.ClassID);
                ModelState.AddModelError("Error", "完善学生信息失败！");
                return View(sm);
            }
        }


        #endregion


        #region 教师权限的Action
        [TeacherLoginFilter]
        public ActionResult Index(string classid)
        {
            if (classid == null)
            {
            
               var cms = cb.GetClasses();
                ViewBag.ClassID = new SelectList(cms, "ID", "ClassName");
                return View(sb.GetStudentModels(cms[0].ID));
            }
            else
            {
              
                var cms = cb.GetClasses();
                ViewBag.ClassID = new SelectList(cms, "ID", "ClassName");
                return View(sb.GetStudentModels(int.Parse(classid)));
            }

        }
        [HttpPost]
        [TeacherLoginFilter]
        public ActionResult Index(int classid)
        {

            var cms = cb.GetClasses();
            ViewBag.ClassID = new SelectList(cms, "ID", "ClassName", classid);
            return View(sb.GetStudentModels(classid));
        }
      
        [TeacherLoginFilter]
        public ActionResult Create()
        {
            var cms = cb.GetClasses();
            ViewBag.ClassID = new SelectList(cms, "ID", "ClassName");
            return View();
        }
        [HttpPost]
        [TeacherLoginFilter]
        public ActionResult Create(StudentModel sm)
        {
            if (sb.AddStudent(sm))
            {
                return RedirectToAction("Index");
            }
            else
            {
                var cms = cb.GetClasses();
                ViewBag.ClassID = new SelectList(cms, "ID", "ClassName", sm.ClassID);
                ModelState.AddModelError("Error", "添加学生信息失败!");
                return View();
            }
        }
        [TeacherLoginFilter]
        public ActionResult Edit(string stuno)
        {
            var sm = sb.GetStudentModel(stuno);
            var cms = cb.GetClasses();
            ViewBag.ClassID = new SelectList(cms, "ID", "ClassName", sm.ClassID);
            return View(sm);
        }
        [HttpPost]
        [TeacherLoginFilter]
        public ActionResult Edit(StudentModel sm)
        {
            if (sb.ModifyStudent(sm))
            {
                return RedirectToAction("Index");
            }
            else
            {
                var cms = cb.GetClasses();
                ViewBag.ClassID = new SelectList(cms, "ID", "ClassName", sm.ClassID);
                ModelState.AddModelError("Error", "修改学生信息失败！");
                return View(sm);
            }
        }

        [TeacherLoginFilter]
        public ActionResult Delete(string stuno)
        {
            var sm = sb.GetStudentModel(stuno);
            var cms = cb.GetClasses();
            ViewBag.ClassID = new SelectList(cms, "ID", "ClassName", sm.ClassID);
            return View(sm);
        }
        [HttpPost]
        [TeacherLoginFilter]
        public ActionResult Delete(StudentModel sm)
        {
            if (sb.RemoveStudent(sm))
            {
                return RedirectToAction("Index");
            }
            else
            {
                var cms = cb.GetClasses();
                ViewBag.ClassID = new SelectList(cms, "ID", "ClassName", sm.ClassID);
                ModelState.AddModelError("Error", "删除学生信息失败！");
                var smo = sb.GetStudentModel(sm.StuNo);
                return View(smo);
            }

        }
        #endregion

    }
}
