using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.OleDb;

namespace Ciitc
{
    class SQLHelper
    {
        public object ExecuteScalar(string sql, params SqlParameter[] parameteres)
        {
            string ConStr = ConfigurationManager.ConnectionStrings["Ciitc.Properties.Settings.xmldataConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(ConStr))
            {
                conn.Open();
                using (SqlCommand ConCmd = conn.CreateCommand())
                {
                    ConCmd.CommandText = sql;
                    foreach (SqlParameter param in parameteres)
                    {
                        ConCmd.Parameters.Add(param);
                    }
                    object i = ConCmd.ExecuteScalar();
                    conn.Close();
                    return i;
                }
                
            }
        }

        public DataTable ExecuteDataTable(string sql)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string ConStr = ConfigurationManager.ConnectionStrings["CiitcConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(ConStr);
            SqlDataAdapter sqd = new SqlDataAdapter(sql, conn);
            sqd.Fill(ds);
            conn.Close();
            dt = ds.Tables[0];
            return dt;
        }

        public int ExecuteNonQuery(string sql, params SqlParameter[] parameteres)
        {
            string ConStr = ConfigurationManager.ConnectionStrings["CiitcConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(ConStr))
            {
                conn.Open();
                using (SqlCommand ConCmd = conn.CreateCommand())
                {
                    ConCmd.CommandText = sql;
                    foreach (SqlParameter param in parameteres)
                    {
                        ConCmd.Parameters.Add(param);
                    }
                    int i = ConCmd.ExecuteNonQuery();
                    conn.Close();
                    return i;
                }
            }
        }

        public object ExecuteScalarO(string sql, params OleDbParameter[] parameteres)
        {
            string ConStr = ConfigurationManager.ConnectionStrings["Ciitc.Properties.Settings.xmldataConnectionString"].ConnectionString;
            using (OleDbConnection conn = new OleDbConnection(ConStr))
            {
                conn.Open();
                using (OleDbCommand ConCmd = conn.CreateCommand())
                {
                    ConCmd.CommandText = sql;
                    foreach (OleDbParameter param in parameteres)
                    {
                        ConCmd.Parameters.Add(param);
                    }
                    return ConCmd.ExecuteScalar();
                }
            }
        }

        public int ExecuteNonQueryO(string sql, params OleDbParameter[] parameteres)
        {
            string ConStr = ConfigurationManager.ConnectionStrings["Ciitc.Properties.Settings.xmldataConnectionString"].ConnectionString;
            using (OleDbConnection conn = new OleDbConnection(ConStr))
            {
                conn.Open();
                using (OleDbCommand ConCmd = conn.CreateCommand())
                {
                    ConCmd.CommandText = sql;
                    foreach (OleDbParameter param in parameteres)
                    {
                        ConCmd.Parameters.Add(param);
                    }
                    return ConCmd.ExecuteNonQuery();
                }
            }
        }
    }
}
