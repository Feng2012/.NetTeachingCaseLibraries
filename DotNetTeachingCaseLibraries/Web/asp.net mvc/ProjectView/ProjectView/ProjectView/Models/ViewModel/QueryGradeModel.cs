using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProjectView.Models.ViewModel
{
    public class QueryGradeModel
    {
        public string StuNo
        {
            get;
            set;
        }
        public int TeacherID
        {
            get;
            set;
        }
        public DataTable DT
        {
            get;
            set;
        }
    }
}