using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAccountBook
{
    /// <summary>
    /// 业务数据处理类
    /// </summary>
    public class BllHandler
    {
        /// <summary>
        /// 数据处理类
        /// </summary>
        DataHandler _dataHandle;
        /// <summary>
        /// 构造函数据
        /// </summary>
        public BllHandler()
        {
            _dataHandle = new DataHandler();
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>用户姓名</returns>
        public string Login(string userName, string password)
        {
            var sql = "select name from users where username=@username and password=@password";
            var usernamePar = new OleDbParameter() { ParameterName = "@username", Value = userName };
            var passwordPar = new OleDbParameter() { ParameterName = "@password", Value = password };

            return _dataHandle.GetValue(sql, usernamePar, passwordPar)?.ToString();
        }
    }
}
