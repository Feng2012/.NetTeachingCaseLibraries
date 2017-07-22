using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectView.Models.ViewModel
{
    public class ReviewModel
    {
        [Display(Name = "项目名称")]
        public string ProjectName
        {
            get;
            set;
        }
        public string StuNo
        {
            get;
            set;
        }
        public string StuName
        {
            get;
            set;
        }
        List<ProjectItemModel> items = new List<ProjectItemModel>();
        [Display(Name = "项目评审项")]
        public List<ProjectItemModel> Items
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
            }
        }        
    }
}