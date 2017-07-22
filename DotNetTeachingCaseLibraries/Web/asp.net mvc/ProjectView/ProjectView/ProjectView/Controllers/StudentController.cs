using ProjectView.Models.ViewModel;
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
    public class StudentController : Controller
    {
        #region 无权限Action
        StudentBll sb = new StudentBll();
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
            if (sb.ValidateUser(user, out  loguser))
            {

                if (loguser is StudentUser)
                {
                    //加载学生访问的Cookie
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.UserName,
                        DateTime.Now, DateTime.Now.Add(FormsAuthentication.Timeout), true, user.UserName);

                    string cookiename = FormsAuthentication.FormsCookieName + "Student";
                    HttpCookie cookie = new HttpCookie(cookiename, FormsAuthentication.Encrypt(ticket));
                    Response.Cookies.Add(cookie);

                    return RedirectToActionPermanent("MainPage", "Student", new { stuno = user.UserName });
                }
                else
                {
                    //加载教师访问的Cookie
                    TeacherUser tu = loguser as TeacherUser;
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, tu.TeacherID.ToString(),
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
            TeacherUserBll tub = new TeacherUserBll();
            TeacherUserModel tum = tub.GetTeacherUserModel(UserName);
            bool teavalue = tum == null ? false : true;
            bool stuvalue = sb.ValidateStuUserName(UserName);
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
            string stuno = StudentLoginFilter.StuNo;
            StudentBll sb = new StudentBll();
            StudentModel sm = sb.GetStudent(stuno);
            return View(sm);
        }
        [StudentLoginFilter]
        public ActionResult ChangPassword(string stuno)
        {
            StudentBll sb = new StudentBll();
            StudentUserModel sum = sb.GetStudentUser(stuno);
            return View(sum);
        }
        [StudentLoginFilter]
        [HttpPost]
        public ActionResult ChangPassword(StudentUserModel sum, string stuno)
        {
            StudentBll sb = new StudentBll();
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
            StudentModel sm = sb.GetStudentModel(stuno);
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
                List<ClassModel> cms = cb.GetClasses();
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
                ClassBll cb = new ClassBll();
                List<ClassModel> cms = cb.GetClasses();
                ViewBag.ClassID = new SelectList(cms, "ID", "ClassName");
                return View(sb.GetStudentModels(cms[0].ID));
            }
            else
            {
                ClassBll cb = new ClassBll();
                List<ClassModel> cms = cb.GetClasses();
                ViewBag.ClassID = new SelectList(cms, "ID", "ClassName");
                return View(sb.GetStudentModels(int.Parse(classid)));
            }

        }
        [HttpPost]
        [TeacherLoginFilter]
        public ActionResult Index(int classid)
        {

            List<ClassModel> cms = cb.GetClasses();
            ViewBag.ClassID = new SelectList(cms, "ID", "ClassName", classid);
            return View(sb.GetStudentModels(classid));
        }
        ClassBll cb = new ClassBll();
        [TeacherLoginFilter]
        public ActionResult Create()
        {
            List<ClassModel> cms = cb.GetClasses();
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
                List<ClassModel> cms = cb.GetClasses();
                ViewBag.ClassID = new SelectList(cms, "ID", "ClassName", sm.ClassID);
                ModelState.AddModelError("Error", "添加学生信息失败!");
                return View();
            }
        }
        [TeacherLoginFilter]
        public ActionResult Edit(string stuno)
        {
            StudentModel sm = sb.GetStudentModel(stuno);
            List<ClassModel> cms = cb.GetClasses();
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
                List<ClassModel> cms = cb.GetClasses();
                ViewBag.ClassID = new SelectList(cms, "ID", "ClassName", sm.ClassID);
                ModelState.AddModelError("Error", "修改学生信息失败！");
                return View(sm);
            }
        }

        [TeacherLoginFilter]
        public ActionResult Delete(string stuno)
        {
            StudentModel sm = sb.GetStudentModel(stuno);
            List<ClassModel> cms = cb.GetClasses();
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
                List<ClassModel> cms = cb.GetClasses();
                ViewBag.ClassID = new SelectList(cms, "ID", "ClassName", sm.ClassID);
                ModelState.AddModelError("Error", "删除学生信息失败！");
                StudentModel smo = sb.GetStudentModel(sm.StuNo);
                return View(smo);
            }

        }
        #endregion
      
    }
}
