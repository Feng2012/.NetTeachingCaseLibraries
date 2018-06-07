using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace InfoRecord.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Record record)
        {
            ViewBag.Message = "<span style='color:red'>ok</span>";
            return View();
        }


    }

    public class Record
    {
        public string CompanyName
        { get; set; }
        public string CompanyType
        { get; set; }

        public string Principal
        { get; set; }
        public string Address
        { get; set; }
        public string Tel { get; set; }

        public string Conferee { get; set; }

        public string Attendance { get; set; }
    }
}
