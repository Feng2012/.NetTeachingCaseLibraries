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
        /// 查询帐务信息
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="financeType">财务类型</param>
        /// <param name="spendUser">花销人</param>
        /// <returns></returns>
        internal object QueryAccount(DateTime beginTime, DateTime endTime, string ids, string spendUser)
        {
            var sql = $@"SELECT Accounts.ID AS 编号, Accounts.FinanceTypeID  AS 财务类型编号, FinancialTypes.TypeName AS 财务类型名称,Accounts.Amount AS 金额, Accounts.SpendUser AS 财务人, Accounts.CreateBy AS 记帐人,Accounts.CreateOn AS 记帐时间, Accounts.[Memo] AS 备注 FROM(Accounts INNER JOIN   FinancialTypes ON Accounts.FinanceTypeID = FinancialTypes.ID) where Accounts.CreateOn>='{beginTime.ToString("yyyy-MM-dd 00:00:00")}' and Accounts.CreateOn<='{endTime.ToString("yyyy-MM-dd 23:59:59")}'";
            if(!string.IsNullOrEmpty(ids))
            {
                sql += $" and  Accounts.FinanceTypeID in ({ids})";
            }
            if (!string.IsNullOrEmpty(spendUser) && spendUser!="全部")
            {
                sql += $" and Accounts.SpendUser='{spendUser}'";
            }
            return _dataHandle.GetTable(sql);
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
            return _dataHandle.ChangeDate(sql, idPar) > 0;
        }

        /// <summary>
        /// 获取全部用户
        /// </summary>
        /// <returns></returns>
        public DataTable GetUsers()
        {
            var sql = "select id,name from users";
            return _dataHandle.GetTable(sql);
        }
        /// <summary>
        /// 添加帐户
        /// </summary>
        /// <param name="finceTypeID">财务类型</param>
        /// <param name="amount">金额</param>
        /// <param name="spendUser">花销人</param>
        /// <param name="createUser">添加人</param>
        /// <param name="memo">备注</param>
        /// <returns>是否成功</returns>
        public bool AddAccount(int finceTypeID, decimal amount, string spendUser, string createUser, string memo)
        {
            var sql = $@"insert into accounts(financetypeid,amount,spenduser,createby,createon,[memo]) values({finceTypeID},{amount},'{spendUser}','{createUser}','{DateTime .Now.ToString("yyyy-MM-dd HH:mm:ss")}','{memo}')";       
            var result=_dataHandle.ChangeDate(sql);
            return result > 0;
        }

        /// <summary>
        /// 修改帐户
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="finceTypeID">财务类型</param>
        /// <param name="amount">金额</param>
        /// <param name="spendUser">花销人</param>
        /// <param name="memo">备注</param>
        /// <returns>是否成功</returns>
        public bool UpdateAccount(int id,int finceTypeID, decimal amount, string spendUser,string memo)
        {
            var sql = $"update accounts set financetypeid={finceTypeID},amount={amount},spenduser='{spendUser}',[memo]='{memo}' where id={id}";           
            var result = _dataHandle.ChangeDate(sql);
            return result > 0;
        }

        /// <summary>
        /// 修改帐户
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>是否成功</returns>
        public bool RemoveAccount(int id)
        {
            var sql = "delete from accounts  where id=@id";
            var idPar = new OleDbParameter() { ParameterName = "@id", Value = id };
            var result = _dataHandle.ChangeDate(sql, idPar);
            return result > 0;
        }

        /// <summary>
        /// 查询当前的信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetAccounts()
        {
            var sql = $@"SELECT Accounts.ID AS 编号, Accounts.FinanceTypeID  AS 财务类型编号, FinancialTypes.TypeName AS 财务类型名称,Accounts.Amount AS 金额, Accounts.SpendUser AS 财务人, Accounts.CreateBy AS 记帐人,Accounts.CreateOn AS 记帐时间, Accounts.[Memo] AS 备注 FROM(Accounts INNER JOIN   FinancialTypes ON Accounts.FinanceTypeID = FinancialTypes.ID)";
            return _dataHandle.GetTable(sql);         
        }

      
    }
}
