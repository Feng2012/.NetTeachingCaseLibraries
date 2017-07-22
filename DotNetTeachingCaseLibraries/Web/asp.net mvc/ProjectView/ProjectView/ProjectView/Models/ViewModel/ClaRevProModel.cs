using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectView.Models.ViewModel
{
  
    public class ClaRevProModel
    {
        public int ID
        {
            get;
            set;
        }
        [Display(Name = "班级名称")]
        public int ClassID
        {
            get;
            set;
        }
        [Display(Name = "班级名称")]
        public string ClassName
        {
            get;
            set;
        }
        [Display(Name = "项目名称")]
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
    }
}