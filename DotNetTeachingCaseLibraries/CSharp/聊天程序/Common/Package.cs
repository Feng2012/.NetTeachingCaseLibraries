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

        /// <summary>
        /// 重写tostring方法，显示本身的属性和值
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var content = "";
            foreach(var pro in this.GetType().GetProperties())
            {
                content += $"{pro.Name}:{pro.GetValue(this)}  ";
            }
            return content;
        }
    }
}
