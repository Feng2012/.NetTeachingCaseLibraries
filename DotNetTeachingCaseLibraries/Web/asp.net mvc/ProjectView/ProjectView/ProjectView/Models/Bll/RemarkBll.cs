using ProjectView.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectView.Models.Bll
{
    /// <summary>
    /// 评语业务类
    /// </summary>
    public class RemarkBll
    {
        ProjectReviewDBEntities PRDB ;
        public RemarkBll()
        {
            PRDB = new ProjectReviewDBEntities();
        }
        public List<RemarkModel> GetRemarkModels()
        {
            var cms = new List<RemarkModel>();
            foreach (var tr in PRDB.TeacherRemarks.OrderBy(tr=>tr.ID))
            {
                var rm = new RemarkModel();
                rm.ID = tr.ID;
                rm.ProjectID = tr.ProjectID;
                rm.ProjectName = tr.Project.ProjectName;
                rm.StuNo = tr.StuNo;
                rm.StuName = tr.Student.StuName;
                if (tr.Remark.Length > 15)
                {
                    rm.Remark = tr.Remark.Substring(0, 15) + "...";
                }
                else
                {
                    rm.Remark = tr.Remark;
                }
                rm.RemarkDT = tr.RemarkDT;
                cms.Add(rm);
            }
            return cms;
        }
        public List<RemarkModel> GetRemarkModels(int classid)
        {
            var cms = new List<RemarkModel>();
            foreach (var tr in PRDB.TeacherRemarks.Where(rem => rem.Student.ClassID == classid).OrderBy(tr=>tr.ID))
            {
                var rm = new RemarkModel();
                rm.ID = tr.ID;
                rm.ProjectID = tr.ProjectID;
                rm.ProjectName = tr.Project.ProjectName;
                rm.StuNo = tr.StuNo;
                rm.StuName = tr.Student.StuName;
                if (tr.Remark.Length > 15)
                {
                    rm.Remark = tr.Remark.Substring(0, 15) + "...";
                }
                else
                {
                    rm.Remark = tr.Remark;
                }
                rm.RemarkDT = tr.RemarkDT;
                cms.Add(rm);
            }
            return cms;
        }

        public List<RemarkModel> GetRemarkModels(int classid, int projectid)
        {
            var cms = new List<RemarkModel>();
            foreach (var tr in PRDB.TeacherRemarks.Where(rem => rem.Student.ClassID == classid && rem.ProjectID == projectid))
            {
                var rm = new RemarkModel();
                rm.ID = tr.ID;
                rm.ProjectID = tr.ProjectID;
                rm.ProjectName = tr.Project.ProjectName;
                rm.StuNo = tr.StuNo;
                rm.StuName = tr.Student.StuName;
                if (tr.Remark.Length > 15)
                {
                    rm.Remark = tr.Remark.Substring(0, 15) + "...";
                }
                else
                {
                    rm.Remark = tr.Remark;
                }
                rm.FullRemark = tr.Remark;
                rm.RemarkDT = tr.RemarkDT;
                cms.Add(rm);
            }
            return cms;
        }
        public bool AddRemark(RemarkModel rm)
        {
            try
            {
                var tr = new TeacherRemark();
                tr.ProjectID = rm.ProjectID;
                tr.StuNo = rm.StuNo;
                tr.Remark = rm.Remark;
                if (rm.RemarkDT.HasValue)
                {
                    tr.RemarkDT = rm.RemarkDT.Value;
                }
                PRDB.TeacherRemarks.Add(tr);
                PRDB.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool ModifyRemark(RemarkModel rm)
        {
            try
            {
                var tr = PRDB.TeacherRemarks.SingleOrDefault(tre => tre.ID == rm.ID);
                if (tr != null)
                {
                    tr.ProjectID = rm.ProjectID;
                    tr.StuNo = rm.StuNo;
                    tr.Remark = rm.Remark;
                    if (rm.RemarkDT.HasValue)
                    {
                        tr.RemarkDT = rm.RemarkDT.Value;
                    }
                    PRDB.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool RemoveRemark(RemarkModel rm)
        {
            try
            {
                var tr = PRDB.TeacherRemarks.SingleOrDefault(tre => tre.ID == rm.ID);
                if (tr != null)
                {
                    PRDB.TeacherRemarks.Remove(tr);
                    PRDB.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public RemarkModel GetReamrkModelByID(int id, out int classid)
        {
            try
            {
                var TR = PRDB.TeacherRemarks.SingleOrDefault(tr => tr.ID == id);
                if (TR != null)
                {
                    var RM = new RemarkModel();
                    RM.ID = TR.ID;
                    RM.ProjectID = TR.ProjectID;
                    RM.ProjectName = TR.Project.ProjectName;
                    RM.Remark = TR.Remark;
                    RM.RemarkDT = TR.RemarkDT;
                    RM.StuName = TR.Student.StuName;
                    RM.StuNo = TR.StuNo;
                    classid = TR.Student.ClassID;
                    return RM;
                }
                else
                {
                    classid = 0;
                    return null;
                }
            }
            catch
            {
                classid = 0;
                return null;
            }
        }
    }
}