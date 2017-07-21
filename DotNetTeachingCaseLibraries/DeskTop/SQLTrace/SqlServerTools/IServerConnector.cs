using System;
using System.Collections.Generic;
using System.Text;

namespace AnfiniL.SqlServerTools
{
    /// <summary>
    /// 服务连接接口
    /// </summary>
    public interface IServerConnector
    {
        string[] GetServerList();
        bool TestConnection(string serverName, string userName, string password, out string error);
        bool TestConnection(string serverName, out string error);
        bool TestRawConnection(string rawConnectionString, out string error);
    }
}
