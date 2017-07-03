using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVCard
{
    /// <summary>
    /// 联系方式抽象类
    /// </summary>
    abstract class Contact
    {
        /// <summary>
        /// 联系方式类型
        /// </summary>
        public abstract string ContactType
        { get;}
        /// <summary>
        /// 联系方式号码
        /// </summary>
        public abstract string ContactNo
        { get; set; }
    }
}
