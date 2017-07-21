using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Microsoft.SqlServer.Management.Smo;
using System.Data;
using Microsoft.SqlServer.Management.Common;
using ServerType=Microsoft.SqlServer.Management.Common.ServerType;

namespace AnfiniL.SqlServerTools.Impl
{
    class ServerConnector : IServerConnector
    {
        #region IServerConnector Members

        /// <summary>
        /// 获取可用 SQL Server 实例名列表
        /// </summary>
        /// <returns></returns>
        public string[] GetServerList()
        {
            List<string> result = new List<string>();
            foreach(DataRow row in SmoApplication.EnumAvailableSqlServers().Rows)
            {
                result.Add(row["Name"] as string);
            }
            return result.ToArray();
        }
        /// <summary>
        /// 测试连接
        /// </summary>
        /// <param name="serverName">数据库服务器名称</param>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="error">返回错误</param>
        /// <returns></returns>
        public bool TestConnection(string serverName, string userName, string password, out string error)
        {
            return TestServerConnection(new ServerConnection(serverName, userName, password), out error);
        }

        /// <summary>
        /// 测试连接
        /// </summary>
        /// <param name="serverName">服务器名</param>
        /// <param name="error">返回错误</param>
        /// <returns></returns>
        public bool TestConnection(string serverName, out string error)
        {
            return TestServerConnection(new ServerConnection(serverName), out error);
        }
        /// <summary>
        /// 测试连接
        /// </summary>
        /// <param name="rawConnectionString">连接字符串</param>
        /// <param name="error">返回错误</param>
        /// <returns></returns>
        public bool TestRawConnection(string rawConnectionString, out string error)
        {
            return TestServerConnection(new ServerConnection(new SqlConnection(rawConnectionString)), out error);
        }
        /// <summary>
        /// 测试连接
        /// </summary>
        /// <param name="sc">服务端连接对象</param>
        /// <param name="error">返回错误</param>
        /// <returns></returns>
        private static bool TestServerConnection(ServerConnection sc, out string error)
        {
            try
            {
                sc.ConnectTimeout = 20;//20 seconds
                sc.Connect();
                if(sc.ServerVersion.Major < 9)
                {
                    error = "SQL Server版本低于 9.0 (SQL Server 2005)，无法使用本性能分析！";
                    return false;
                }

                error = string.Empty;
                return true;
            }
            catch (Exception exc)
            {
                error = exc.Message;
                return false;
            }
        }

        #endregion
    }
}
