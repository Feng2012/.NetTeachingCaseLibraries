using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// 登录报文
    /// </summary>
    [Serializable]
    public class LoginPackage : Package
    {
        /// <summary>
        /// 报文类型
        /// </summary>
        public override PackageType PackageType =>PackageType.Login;
        /// <summary>
        /// 帐号
        /// </summary>
        public string Account
        { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        { get; set; }
    }
}
