using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// 登录结果报文
    /// </summary>
    [Serializable]
    public class LoginResultPackage : Package
    {
        /// <summary>
        /// 报文类型
        /// </summary>
        public override PackageType PackageType => PackageType.LoginResult;
        /// <summary>
        /// 登录结果
        /// </summary>
        public bool Result
        { get; set; }
        /// <summary>
        /// 登录失败时提示信息
        /// </summary>
        public string Message
        { get; set; }

        /// <summary>
        /// 朋友列表
        /// </summary>
        public string[] Frinds
        { get; set; }


    }
}
