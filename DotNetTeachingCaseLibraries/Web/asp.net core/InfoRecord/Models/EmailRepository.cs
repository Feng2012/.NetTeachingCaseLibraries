using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoRecord.Models
{
    public class EmailRepository : IEmailRepository
    {
        readonly EmailSetting _emailSetting;
        public EmailRepository(EmailSetting emailSetting)
        {
            _emailSetting = emailSetting;
        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="record">内容</param>
        /// <returns></returns>
        public (bool Result, string Message) SendEmail(Record record)
        {
            try
            {
                var title = "参加者記入欄";
                var emailBody = new StringBuilder(title);
                emailBody.AppendLine(record.ToString());
                emailBody.AppendLine($"           {DateTime.Now}");
                var message = new MimeMessage();
                //这里是测试邮箱，请不要发垃圾邮件，谢谢
                message.From.Add(new MailboxAddress(_emailSetting.UserName, _emailSetting.FromAccount));
                message.To.Add(new MailboxAddress(_emailSetting.ToUserName, _emailSetting.ToAccount));
                message.Subject = title;
                message.Body = new TextPart("plain") { Text = emailBody.ToString() };
                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    client.Connect(_emailSetting.Server, _emailSetting.Port, false);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailSetting.FromAccount, _emailSetting.FromPassword);
                    client.Send(message);
                    client.Disconnect(true);
                }
                return (true, "");
            }
            catch (Exception exc)
            {
                return (false, exc.Message);
            }
        }
    }
}
