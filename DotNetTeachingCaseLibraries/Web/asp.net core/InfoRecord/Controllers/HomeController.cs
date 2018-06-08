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
            try
            {
                SendEmail(record);
                ViewBag.Message = "<span style='color:green'>関連情報を提出してくれてありがとう!</span>";
            }
            catch (Exception exc)
            {
                ViewBag.Message = $"<span style='color:red'>開催者に連絡してください。Exception：{exc.Message}</span>";
            }
            return View();
        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="content"></param>
        void SendEmail(Record record)
        {         

                var emailBody = new StringBuilder("参加者記入欄\r\n");
                emailBody.AppendLine(record.ToString());
                emailBody.AppendLine($"           {DateTime.Now}");
                var message = new MimeMessage();
                //这里是测试邮箱，请不要发垃圾邮件，谢谢
                message.From.Add(new MailboxAddress("gui.suwei", "gui.suwei@netstars.co.jp"));
                message.To.Add(new MailboxAddress("lou.yue", "lou.yue@netstars.co.jp"));

                message.Subject = "参加者記入欄";
                message.Body = new TextPart("plain") { Text = emailBody.ToString() };
                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    client.Connect("sv7041.xserver.jp", 587, false);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate("gui.suwei@netstars.co.jp", "");
                    client.Send(message);
                    client.Disconnect(true);
                } 
        }

    }

    public class Record
    {
        /// <summary>
        /// 団体名または法人名または店舗名
        /// </summary>
        public string CompanyName
        { get; set; }
        /// <summary>
        ///  業種
        /// </summary>
        public string CompanyType
        { get; set; }
        /// <summary>
        ///     代表者様名
        /// </summary>
        public string Principal
        { get; set; }
        /// <summary>
        /// ご住所
        /// </summary>
        public string Address
        { get; set; }
        /// <summary>
        ///  お電話番号
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// 参加者お名前
        /// </summary>
        public string Conferee { get; set; }
        /// <summary>
        /// 参加者様人数
        /// </summary>
        public string Attendance { get; set; }

        public override string ToString()
        {
            var content = new StringBuilder();
            content.AppendLine("団体名または法人名または店舗名：");
            content.AppendLine(CompanyName);
            content.AppendLine();
            content.AppendLine("業種：");
            content.AppendLine(CompanyType);
            content.AppendLine();
            content.AppendLine("代表者様名：");
            content.AppendLine(Principal);
            content.AppendLine();
            content.AppendLine("ご住所：");
            content.AppendLine(Address);
            content.AppendLine();
            content.AppendLine("お電話番号：");
            content.AppendLine(Tel);
            content.AppendLine();
            content.AppendLine("参加者お名前：");
            content.AppendLine(Conferee);
            content.AppendLine();
            content.AppendLine("参加者様人数：");
            content.AppendLine(Attendance);
            content.AppendLine();
            return content.ToString();
        }
    }
}
