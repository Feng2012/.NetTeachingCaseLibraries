using System;
using System.Collections.Generic;
using System.Data;
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

        /// <summary>
        /// 查询财务类型
        /// </summary>
        /// <returns>财务类型集合</returns>
        public List<dynamic> GetFinanceTypes()
        {
            var sql = "select id,typename,pid from financialtypes";
            var list = new List<dynamic>();
            foreach (DataRow row in _dataHandle.GetTable(sql).Rows)
            {
                list.Add(new { id = Convert.ToInt32(row["id"]), typename = row["typename"].ToString(), pid = Convert.ToInt32(row["pid"]) });
            }
            return list;
        }
        /// <summary>
        /// 添加财务类型
        /// </summary>
        /// <param name="typeName">类型名称</param>
        /// <param name="pid">父ID</param>
        /// <returns>类型ID</returns>
        public int AddFinanceType(string typeName, int pid)
        {
            var sql = "insert into financialtypes(typename,pid) values(@typename,@pid)";

            var typeNamePar = new OleDbParameter() { ParameterName = "@typename", Value = typeName };
            var pidPar = new OleDbParameter() { ParameterName = "@pid", Value = pid };
            var result = _dataHandle.ChangeDate(sql, typeNamePar, pidPar);
            if (result > 0)
            {
                sql = "select max(id) from financialtypes";
                var obj = _dataHandle.GetValue(sql);
                return Convert.ToInt32(obj);
            }
            else
            {
                throw new Exception("操作失败！");
            }
        }
        /// <summary>
        /// 按ID删除类型
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>删除影响行数</returns>
        public bool DeleteFinanceType(int id)
        {
            var sql = "delete from financialtypes where id=@id";
            var idPar = new OleDbParameter() { ParameterName = "@id", Value = id };
            return _dataHandle.ChangeDate(sql, idPar)>0;
        }
    }
}
