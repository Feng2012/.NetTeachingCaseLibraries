using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleVCardManagement
{
    /// <summary>
    /// 手机
    /// </summary>
    class Mobile : Contact
    {
        /// <summary>
        /// 手机类型
        /// </summary>
        public override string ContactType
        {
            get
            {
                return "手机";
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
                var regex = new Regex(@"^0?(13[0-9]|15[012356789]|17[013678]|18[0-9]|14[57])[0-9]{8}$");
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
