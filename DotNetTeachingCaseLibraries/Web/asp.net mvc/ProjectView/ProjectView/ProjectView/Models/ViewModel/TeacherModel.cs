using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectView.Models.ViewModel
{
    public class TeacherModel
    {
        [Display(Name = "编号")]
        public int ID
        {
            get;
            set;
        }
        [Display(Name = "姓名")]
        [Required]
        public string TeacherName
        {
            get;
            set;
        }
        [Display(Name = "性别")]    
        public string  Sex
        {
            get;
            set;
        }
    }
    public enum Sex
    {
        女 = 0,
        男 = 1
    }
}