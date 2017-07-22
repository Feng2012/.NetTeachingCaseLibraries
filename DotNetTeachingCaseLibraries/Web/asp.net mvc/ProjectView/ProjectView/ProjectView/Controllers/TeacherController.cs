using ProjectView.Models;
using ProjectView.Models.Bll;
using ProjectView.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectView.App_Start;
using System.Data;

namespace ProjectView.Controllers
{
    [TeacherLoginFilter]
    public class TeacherController : Controller
    {
        //
        // GET: /Teacher/
        public ActionResult MainPage()
        {
            int TeacherID = int.Parse(TeacherLoginFilter.TeacherID);
            TeacherBll tb = new TeacherBll();
            Teacher teacher = tb.GetTeacher(TeacherID);
            TeacherModel tm = new TeacherModel();
            tm.ID = TeacherID;
            tm.TeacherName = teacher.TeacherName;
            return View(tm);
        }

        TeacherBll tb = new TeacherBll();

        public ActionResult Index()
        {
            return View(tb.GetTeachers());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TeacherModel tm)
        {
            if (tb.AddTeacher(tm))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("Error", "添加教师失败！");
                return View();
            }

        }

        public ActionResult Edit(int id)
        {
            TeacherModel tm = tb.GetTeacherModel(id);
            if (tm != null)
            {
                return View(tm);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult Edit(TeacherModel tm)
        {
            if (tb.ModifyTeacher(tm))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("Error", "修改教师信息失几！");
                return View(tm);
            }
        }

        public ActionResult Delete(int id)
        {
            TeacherModel tm = tb.GetTeacherModel(id);
            if (tm != null)
            {
                return View(tm);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult Delete(TeacherModel tm)
        {
            if (tb.RemoveTeacher(tm.ID))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(tm);
            }
        }

        public ActionResult TeaQueryGrade(int TeacherID)
        {
            ReviewBll rb = new ReviewBll();
            ViewBag.ProjectID = new SelectList(rb.GetProjects(), "ID", "ProjectName");
            ClassBll cb = new ClassBll();
            ViewBag.ClassID = new SelectList(cb.GetClasses(), "ID", "ClassName");

            QueryGradeModel QGM = new QueryGradeModel();
            QGM.DT = new DataTable();
            QGM.TeacherID = TeacherID;
            return View(QGM);
        }
        [HttpPost]
        public ActionResult TeaQueryGrade(int classid, int projectid)
        {
            ReviewBll rb = new ReviewBll();
            ViewBag.ProjectID = new SelectList(rb.GetProjects(), "ID", "ProjectName", projectid);
            ClassBll cb = new ClassBll();
            ViewBag.ClassID = new SelectList(cb.GetClasses(), "ID", "ClassName", classid);
            

            DataTable dt = new DataTable();
            if (Request.Params["ScoreOrder"] == "false")
            {
                dt = rb.GetSumGrade(projectid, classid);
                ViewBag.ScoreOrder = false;
            }
            else
            {
                dt = rb.GetSumGradeOrder(projectid, classid);
                ViewBag.ScoreOrder = true;
            }
            QueryGradeModel QGM = new QueryGradeModel();
            QGM.DT = dt;
            if (Request.Params["outexcel"] != null)
            {
                DataTable2Excel(dt);
            }
            return View(QGM);
        }

        [NonAction]
        public static void DataTable2Excel(System.Data.DataTable dtData)
        {
            System.Web.UI.WebControls.DataGrid dgExport = null;
            // 当前对话 
            System.Web.HttpContext curContext = System.Web.HttpContext.Current;
            // IO用于导出并返回excel文件 
            System.IO.StringWriter strWriter = null;
            System.Web.UI.HtmlTextWriter htmlWriter = null;

            if (dtData != null)
            {
                // 设置编码和附件格式 
                curContext.Response.ContentType = "application/vnd.ms-excel";
                curContext.Response.ContentEncoding = System.Text.Encoding.UTF8;
                curContext.Response.Charset = "";

                // 导出excel文件 
                strWriter = new System.IO.StringWriter();
                htmlWriter = new System.Web.UI.HtmlTextWriter(strWriter);

                // 为了解决dgData中可能进行了分页的情况，需要重新定义一个无分页的DataGrid 
                dgExport = new System.Web.UI.WebControls.DataGrid();
                dgExport.DataSource = dtData.DefaultView;
                dgExport.AllowPaging = false;
                dgExport.DataBind();

                // 返回客户端 
                dgExport.RenderControl(htmlWriter);
                curContext.Response.Write(strWriter.ToString());
                curContext.Response.End();
            }

        }
    }
}