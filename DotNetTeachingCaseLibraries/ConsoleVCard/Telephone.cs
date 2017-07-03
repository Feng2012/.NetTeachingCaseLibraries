using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleVCard
{
    /// <summary>
    /// 固话类
    /// </summary>
    class Telephone : Contact
    {
        /// <summary>
        /// 联系方式类型
        /// </summary>
        public override string ContactType
        {
            get
            {
                return "电话";
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
                //电话正则
                var regex = new Regex("^(0[0-9]{2,3}-)?([2-9][0-9]{6,7})+(-[0-9]{1,4})?$");
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
