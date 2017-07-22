using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectView.Models.ViewModel
{
    public class StudentModel
    {
        [Display(Name = "学　号")]
        [Required]
        public string StuNo
        {
            get;
            set;
        }
        [Display(Name = "姓　名")]
        [Required]
        public string StuName
        {
            get;
            set;
        }
        [Display(Name = "性　别")]
        public string Sex
        {
            get;
            set;
        }
        [Display(Name = "出生日期")]
        [DataType(DataType.Date)]
        public DateTime Birthday
        {
            get;
            set;
        }
        [Display(Name = "联系方式")]
        [DataType(DataType.PhoneNumber)]
        public string Contact
        {
            get;
            set;
        }
        [Display(Name = "身份证")]
        public string PersonID
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

        public int TeacherID
        {
            get;
            set;
        }
    }
}