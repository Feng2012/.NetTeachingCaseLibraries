using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Package
{
    /// <summary>
    /// 抽象报文
    /// </summary>
    [Serializable]
    public abstract class Package
    {
        /// <summary>
        /// 报文类型
        /// </summary>
        public abstract PackageType PackageType
        { get; }
    }

 

}
