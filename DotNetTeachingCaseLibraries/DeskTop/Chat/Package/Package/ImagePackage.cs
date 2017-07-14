using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Package
{
    /// <summary>
    /// 图片报文
    /// </summary>
    [Serializable]
    public class ImagePackage : Package
    {
        /// <summary>
        /// 报文类型
        /// </summary>
        public override PackageType PackageType
        {
            get
            {
                return PackageType.Image;
            }
        }
        /// <summary>
        /// 扩展名
        /// </summary>
        public string ExtName
        { get; set; }
        /// <summary>
        /// 图片字节数组
        /// </summary>
        public byte[] ImageBytes
        { get; set; } = new byte[0];

    }
}
