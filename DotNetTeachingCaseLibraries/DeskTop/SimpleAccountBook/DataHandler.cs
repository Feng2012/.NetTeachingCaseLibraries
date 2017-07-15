using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.OleDb;

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
            _connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={System.IO.Directory.GetCurrentDirectory()+"//" +ConfigurationManager.AppSettings["database"]};" ;
        }

        /// <summary>
        /// 查询table
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="pars">参数列表</param>
        /// <returns></returns>
        public DataTable GetTable(string sql, params OleDbParameter[] pars)
        {
            using (var con = new OleDbConnection(_connectionString))
            {
                var cmd = new OleDbCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(pars);
                con.Open();
                var table = new DataTable();
                var reader = cmd.ExecuteReader();
                table.Load(reader);
                return table;
            }
        }
        /// <summary>
        /// 改变数据
        /// </summary>
        /// <param name="sql">语句</param>
        /// <param name="pars">参数列表</param>
        /// <returns></returns>
        public int ChangeDate(string sql, params OleDbCommand[] pars)
        {
            using (var con = new OleDbConnection(_connectionString))
            {
                var cmd = new OleDbCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(pars);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 查询table
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="pars">参数列表</param>
        /// <returns></returns>
        public object GetValue(string sql, params OleDbParameter[] pars)
        {
            using (var con = new OleDbConnection(_connectionString))
            {
                var cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(pars);
                con.Open();
                return cmd.ExecuteScalar();
            }
        }
    }
}
