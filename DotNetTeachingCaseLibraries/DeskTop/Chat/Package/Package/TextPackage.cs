using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Package
{
    /// <summary>
    /// 文字报文
    /// </summary>
    [Serializable]
    public class TextPackage : Package
    {
        /// <summary>
        /// 报文类型
        /// </summary>
        public override PackageType PackageType
        {
            get
            {
                return PackageType.Text;
            }
        }
        /// <summary>
        /// 报文信息
        /// </summary>
        public string Message
        { get; set; }
    }
}
