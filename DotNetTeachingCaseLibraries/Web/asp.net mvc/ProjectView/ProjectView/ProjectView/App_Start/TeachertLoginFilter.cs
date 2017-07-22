using ProjectView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjectView.App_Start
{
    public class TeacherLoginFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                string cookiename = FormsAuthentication.FormsCookieName + "Teacher";
                var v = filterContext.HttpContext.Request.Cookies[cookiename].Value;
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(v);//解密 
                string userno = authTicket.UserData;
                TeacherID = userno;
                ProjectView.Models.ProjectReviewDBEntities PRDB = new Models.ProjectReviewDBEntities();
                StudentUser su = PRDB.StudentUsers.SingleOrDefault(stu => stu.StuNoUserName == userno);            
                if (su == null)
                {
                    int tid = int.Parse(userno);
                    TeacherUser tu = PRDB.TeacherUsers.SingleOrDefault(teu => teu.TeacherID == tid);
                    if (su == null && tu == null)
                    {
                        filterContext.HttpContext.Response.Redirect("~/Student/Login");
                    }
                }              
            }
            catch
            {
                filterContext.HttpContext.Response.Redirect("~/Student/Login");
            }
        }

        public static string TeacherID
        {
            get;
            set;
        }

    }
}