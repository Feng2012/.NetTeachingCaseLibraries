using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectView.Models.ViewModel
{
    public class ProjectModel
    {
        [Display(Name = "编号")]
        public int ID
        {
            get;
            set;
        }
        [Required]
        [Display(Name = "项目名称")]
        public string ProjectName
        {
            get;
            set;
        }   
        [Display(Name = "项目说明")]
        public string Describe
        {
            get;
            set;
        }
    }
}