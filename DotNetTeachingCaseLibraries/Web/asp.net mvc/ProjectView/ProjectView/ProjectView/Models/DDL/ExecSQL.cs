using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ProjectView.Models.DDL
{
    public class ExecSQL
    {
        public DataTable GetSumGrade(int projectid, int classid)
        {
            string constr = ConfigurationManager.ConnectionStrings["ProjectReviewDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SumGrade";
                    cmd.Parameters.Add("@projectid", SqlDbType.Int).Value = projectid;
                    cmd.Parameters.Add("@classid", SqlDbType.Int).Value = classid;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dr.Close();
                    return dt;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    con.Close();
                }

            }
        }


        public DataTable GetSumGradeOrder(int projectid, int classid)
        {
            string constr = ConfigurationManager.ConnectionStrings["ProjectReviewDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SumGradeOrder";
                    cmd.Parameters.Add("@projectid", SqlDbType.Int).Value = projectid;
                    cmd.Parameters.Add("@classid", SqlDbType.Int).Value = classid;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dr.Close();
                    return dt;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    con.Close();
                }

            }
        }
    }
}