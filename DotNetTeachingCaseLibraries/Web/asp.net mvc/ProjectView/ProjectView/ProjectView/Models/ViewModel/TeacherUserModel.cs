using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectView.Models.ViewModel
{
    public class TeacherUserModel
    {
        [Display(Name = "用户名")]
        [Required]
        public string UserName
        {
            get;
            set;
        }
        [Display(Name = "密码")]
        [Required]
        public string Password
        {
            get;
            set;
        }
        [Display(Name = "教师编号")]
        [Required]
        public int TeacherID
        {
            get;
            set;
        }
        [Display(Name = "教师姓名")]
        public string TeacherName
        {
            get;
            set;
        }
    }
}