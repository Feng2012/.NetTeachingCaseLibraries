using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// 报文类型
    /// </summary>
    [Serializable]
    public enum PackageType
    {
        /// <summary>
        /// 登录
        /// </summary>
        Login,
        /// <summary>
        /// 登录结果
        /// </summary>
        LoginResult,
        /// <summary>
        /// 消息
        /// </summary>
        Message,
    }
}
