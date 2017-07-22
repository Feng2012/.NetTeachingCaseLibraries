using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectView.Models.ViewModel
{

    public class RemarkModel
    {
        [Display(Name = "编号")]
        public int ID
        {
            get;
            set;
        }

        [Display(Name = "学号")]
        public string StuNo
        {
            get;
            set;
        }
        [Display(Name = "学生姓名")]
        public string StuName
        {
            get;
            set;
        }

        [Display(Name = "项目编号")]
        public int ProjectID
        {
            get;
            set;
        }

        [Display(Name = "项目名称")]
        public string ProjectName
        {
            get;
            set;
        }
        [Display(Name = "评语")]
        [DataType(DataType.MultilineText)]
        [Required]
        public string Remark
        {
            get;
            set;
        }
        public string FullRemark
        {
            get;
            set;
        }

        [Display(Name = "评语时间")]

        public DateTime? RemarkDT
        {
            get;
            set;
        }
    }
}