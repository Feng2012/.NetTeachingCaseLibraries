using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectView.Models.ViewModel
{
    public class ClassModel
    {
        [Display(Name = "编号")]
        [Required]
        public int ID
        {
            get;
            set;
        }
        [Display(Name = "班级名称")]
        [Required]
        public string ClassName
        {
            get;
            set;
        }
        [Display(Name = "说明")]
        [DataType(DataType.MultilineText)]
        public string Describe
        {
            get;
            set;
        }
    }
}