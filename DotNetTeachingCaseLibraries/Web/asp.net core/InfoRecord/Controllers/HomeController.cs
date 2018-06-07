using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

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
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="content"></param>
        void SendEmail(Record record)
        {
            try
            {

                var emailBody = new StringBuilder("健康检查故障:\r\n");
                emailBody.AppendLine($"--------------------------------------");               
                var message = new MimeMessage();
                //这里是测试邮箱，请不要发垃圾邮件，谢谢
                message.From.Add(new MailboxAddress("gswmicroservice", "gswmicroservice@163.com"));
                message.To.Add(new MailboxAddress("285130205", "285130205@qq.com"));

                message.Subject = "作业报警";
                message.Body = new TextPart("plain") { Text = emailBody.ToString() };
                using (var client = new SmtpClient())
                {

                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    client.Connect("smtp.163.com", 25, false);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate("gswmicroservice", "gsw790622");
                    client.Send(message);
                    client.Disconnect(true);
                }

            }
            catch
            {

            }

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
