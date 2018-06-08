using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoRecord.Models
{
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

        public string ToTxt()
        {
            var content = $"{CompanyName}   {CompanyType}   {Principal}   {Address}   {Tel}   {Conferee}   {Attendance}";
            return content;
        }
    }
}
