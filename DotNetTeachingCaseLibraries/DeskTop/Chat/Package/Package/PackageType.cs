using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Package
{
    /// <summary>
    /// 报文类型
    /// </summary>
    [Serializable]
    public enum PackageType
    {
        Text,
        Image,
        Voice
    }
}
