using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectView.Models.ViewModel
{
    /// <summary>
    /// 用户界面模型
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "用户名不能为空！")]
        [Remote("ValidateUserName", "Student", ErrorMessage = "用户名不存在！")]
        public string UserName
        {
            get;
            set;
        }
        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "密码不能为空！")]
        public string Password
        {
            get;
            set;
        }
    }
}