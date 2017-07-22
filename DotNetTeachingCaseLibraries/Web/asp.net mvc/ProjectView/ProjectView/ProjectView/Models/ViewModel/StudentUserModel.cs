using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectView.Models.ViewModel
{
    public class StudentUserModel
    {
        [Display(Name = "用户名")]
        [Required]
        public string UserName
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }
        [DataType(DataType.Password)]
        [Display(Name = "旧密码")]
        [Required]
        public string OldPassword
        {
            get;
            set;
        }
        [DataType(DataType.Password)]
        [Display(Name = "新密码")]
        [Required]
        public string NewPassword
        {
            get;
            set;
        }
        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("NewPassword", ErrorMessage = "两次密码不相同！")]
        public string ConfirmPassword
        {
            get;
            set;
        }
    }
}