using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoRecord.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MimeKit;

namespace InfoRecord.Controllers
{
    public class HomeController : Controller
    {
        readonly IEmailRepository _emailRepository;
        readonly IRecordRepository _recordRepository;
        /// <summary>
        /// 日志对象
        /// </summary>
        readonly ILogger<HomeController> _logger;
        public HomeController(IRecordRepository recordRepository, IEmailRepository emailRepository, ILogger<HomeController> logger)
        {
            _recordRepository = recordRepository;
            _emailRepository = emailRepository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Record record)
        {
            _logger.LogInformation($"添加记录：{record.ToTxt()}");
            var dataResult = _recordRepository.AddRecord(record);
            var emailResult = _emailRepository.SendEmail(record);
            if(!dataResult.Result)
            {
                _logger.LogError(dataResult.Message);
            }
            if (!emailResult.Result)
            {
                _logger.LogError(emailResult.Message);
            }
            if (dataResult.Result || emailResult.Result)
            {
                ViewBag.Message = "<span style='color:green'>関連情報を提出してくれてありがとう!</span>";
                return View();
            }
            else
            {
                ViewBag.Message = $"<span style='color:red'>開催者に連絡してください。DataException：{dataResult.Message}  EmailException:{emailResult.Message}</span>";
                return View();
            }
        }


    }


}
