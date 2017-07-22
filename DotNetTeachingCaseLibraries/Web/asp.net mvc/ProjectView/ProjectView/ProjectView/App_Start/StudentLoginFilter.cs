using ProjectView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjectView.App_Start
{
    public class StudentLoginFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                string cookiename = FormsAuthentication.FormsCookieName + "Student";
                var v = filterContext.HttpContext.Request.Cookies[cookiename].Value;
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(v);//解密 
                string userno = authTicket.UserData;
                ProjectView.Models.ProjectReviewDBEntities PRDB = new Models.ProjectReviewDBEntities();

                StudentUser su = PRDB.StudentUsers.SingleOrDefault(stu => stu.StuNoUserName == userno);
                if (su == null)
                {
                    int tid = int.Parse(userno);
                    TeacherUser tu = PRDB.TeacherUsers.SingleOrDefault(teu => teu.TeacherID == tid);
                    if (tu == null)
                    {
                        filterContext.HttpContext.Response.Redirect("~/Student/Login");
                    }
                }
                else
                {
                    StuNo = userno;
                }
            }
            catch
            {
                filterContext.HttpContext.Response.Redirect("~/Student/Login");
            }
        }

        public static string StuNo
        {
            get;
            set;
        }
    }
}