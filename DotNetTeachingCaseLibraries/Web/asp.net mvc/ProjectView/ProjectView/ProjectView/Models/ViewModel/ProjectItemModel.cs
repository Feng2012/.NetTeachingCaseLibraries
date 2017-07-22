using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectView.Models.ViewModel
{
    public class ProjectItemModel
    {
        [Display(Name = "序号")]
        public int Number
        {
            get;
            set;
        }
        [Display(Name = "编号")]
        public int ID
        {
            get;
            set;
        }
        [Display(Name = "子项内容")]
        [DataType(DataType.MultilineText)]
        [Required]
        public string ProjectItemName
        {
            get;
            set;
        }
        [Required]
        [Range(0, 100, ErrorMessage = "分值在0到100之间！")]
        [Display(Name = "分值")]        
        public int Grade
        {
            get;
            set;
        }
        public int ProjectID
        {
            get;
            set;
        }
        [Display(Name = "项目")]
        public string ProjectName
        {
            get;
            set;
        }
    }
}