using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVCardManagement
{
    class Card
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int No
        { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        { get; set; }
        /// <summary>
        /// 公司
        /// </summary>
        public string Company
        { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public string Position
        {
            get; set;
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        { get; set; }

        /// <summary>
        /// 联系方式集合,默认值是为空集合，非Null
        /// </summary>
        public List<Contact> Contacts
        { get; set; } = new List<Contact>();

        public override string ToString()
        {
            //把名片拼接成圆角名片的形式
            var namePostion = Name + "  " + Position;
            //横线20个长度
            var line = "————————————————————";
            Console.WriteLine(GetLength(line));
            var content = $@"╭NO：{No.ToString("0000")}————————————————╮
∣{Company.PadRight(GetLength(line) - (GetLength(Company) - Company.Length))}∣
∣{(namePostion).PadRight(GetLength(line) - (GetLength(namePostion) - namePostion.Length))}∣
∣{(Address).PadRight(GetLength(line) - (GetLength(Address) - Address.Length))}∣
";
            foreach (var contact in Contacts)
            {
                var contactStr = $"{contact.ContactType}:{contact.ContactNo}";
                content += $@"∣{contactStr.PadRight(GetLength(line) - (GetLength(contactStr) - contactStr.Length))}∣
";
            }
            content += $"╰{ line}╯";
            return content;
        }

        int GetLength(string contant)
        {
            return Encoding.Default.GetByteCount(contant);
        }
    }
}
