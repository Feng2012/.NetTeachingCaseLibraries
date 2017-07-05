using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// 发送报文抽象父类
    /// </summary>
    [Serializable]
    public abstract class Package
    {     
        /// <summary>
        /// 报文类型
        /// </summary>
        public abstract PackageType PackageType
        { get;  }
    }
}
