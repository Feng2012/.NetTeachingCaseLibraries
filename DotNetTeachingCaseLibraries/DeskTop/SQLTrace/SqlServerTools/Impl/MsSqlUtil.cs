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
        /// �����洢��������
        /// </summary>
        /// <param name="name">�洢��������</param>
        /// <returns></returns>
        public static SqlCommand NewStoredProcedure(string name)
        {
            SqlCommand cmd = new SqlCommand(name);
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }
        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="query">���</param>
        /// <returns></returns>
        public static SqlCommand NewQuery(string query)
        {
            SqlCommand cmd = new SqlCommand(query);
            cmd.CommandType = CommandType.Text;
            return cmd;
        }

        /// <summary>
        /// ִ�д洢����
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static int ExecuteStoredProcedure(SqlCommand cmd, IDbConnection conn)
        {
            //����ֵ����
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
        /// ִ�в�ѯ����
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
        /// ִ�е�ֵ����
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
        /// ��ӽ���
        /// </summary>
        /// <typeparam name="T">����</typeparam>
        /// <param name="cmd">����</param>
        /// <param name="name">������</param>
        /// <param name="value">ֵ</param>
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
        /// ��ӳ���
        /// </summary>
        /// <typeparam name="T">����</typeparam>
        /// <param name="cmd">����</param>
        /// <param name="name">������</param>
        /// <param name="value">ֵ</param>
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
        /// ��ӷ��ز���
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
        /// ����ת��������ֻ��DateTime,DateTime?��string
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
