using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace SimpleAccountBook
{
    /// <summary>
    /// 数据库处理类
    /// </summary>
    public class DataHandler
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        string _connectionString;
        /// <summary>
        /// 构造函数
        /// </summary>
        public DataHandler()
        {
            _connectionString = ConfigurationManager.AppSettings["constr"];
        }

    }
}
