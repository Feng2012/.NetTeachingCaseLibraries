using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace SqlServerTools.Impl
{
    class MsSqlUtil
    {
        /// <summary>
        /// 构建存储过程命令
        /// </summary>
        /// <param name="name">存储过程名称</param>
        /// <returns></returns>
        public static SqlCommand NewStoredProcedure(string name)
        {
            SqlCommand cmd = new SqlCommand(name);
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }
        /// <summary>
        /// 构建语句命令
        /// </summary>
        /// <param name="query">语句</param>
        /// <returns></returns>
        public static SqlCommand NewQuery(string query)
        {
            SqlCommand cmd = new SqlCommand(query);
            cmd.CommandType = CommandType.Text;
            return cmd;
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static int ExecuteStoredProcedure(SqlCommand cmd, IDbConnection conn)
        {
            //返回值参数
            SqlParameter ret = MsSqlUtil.AddReturnParam(cmd);
            cmd.Connection = (SqlConnection)conn;
            conn.Open();

            try
            {
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(ret.Value);
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 执行查询表返回
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static DataTable ExecuteAsDataTable(SqlCommand cmd, IDbConnection conn)
        {            
            cmd.Connection = (SqlConnection)conn;
            conn.Open();
            try
            {
                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());
                return table;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 执行单值返回
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static object ExecuteScalar(SqlCommand cmd, IDbConnection conn)
        {
            cmd.Connection = (SqlConnection)conn;
            conn.Open();

            try
            {
                return cmd.ExecuteScalar();
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 添加进参
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="cmd">命令</param>
        /// <param name="name">参数名</param>
        /// <param name="value">值</param>
        public static void AddInParam<T>(SqlCommand cmd, string name, T value)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = name;
            param.Direction = ParameterDirection.Input;
            if (value != null)
            {
                if (System.Text.RegularExpressions.Regex.Match(value.ToString(), @"^\d+").Success)
                    param.DbType = DbType.Int32;
                param.Value = value;
            }
            else
            {
                param.DbType = MapType(typeof(T));
                param.IsNullable = true;
                param.Value = DBNull.Value;
            }

            cmd.Parameters.Add(param);
        }
        /// <summary>
        /// 添加出参
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="cmd">命令</param>
        /// <param name="name">参数名</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static SqlParameter AddOutParam<T>(SqlCommand cmd, string name, T value)
            where T : new()
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = name;
            param.Direction = ParameterDirection.Output;
            if (value != null)
                param.Value = value;
            else
                param.DbType = MapType(typeof(T));
            cmd.Parameters.Add(param);
            return param;
        }
        /// <summary>
        /// 添加返回参数
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        private static SqlParameter AddReturnParam(SqlCommand cmd)
        {
            SqlParameter param = new SqlParameter();
            param.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param);
            return param;
        }
        /// <summary>
        /// 类型转换，这里只有DateTime,DateTime?和string
        /// </summary>
        /// <param name="T"></param>
        /// <returns></returns>
        private static DbType MapType(Type T)
        {
            if (typeof(DateTime).Equals(T) || typeof(DateTime?).Equals(T))
                return DbType.DateTime;
            else
                return DbType.String;
        }
    }
}
