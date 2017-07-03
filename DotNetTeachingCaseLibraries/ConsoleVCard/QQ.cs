using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleVCard
{
    /// <summary>
    /// QQ
    /// </summary>
    class QQ : Contact
    {
        /// <summary>
        /// 联系方式类型
        /// </summary>
        public override string ContactType
        {
            get
            {
                return "QQ";
            }
        }

        string _contactNo;
        /// <summary>
        /// 号码
        /// </summary>
        public override string ContactNo
        {
            get => _contactNo;
            set
            {
                //QQ正则
                var regex = new Regex(@"^\d{4,12}$");
                if (regex.IsMatch(value))
                {
                    _contactNo = value;
                }
                else
                {
                    throw new ApplicationException($"{value}不是有效的{ContactType}格式！");
                }
            }
        }
    }
}
