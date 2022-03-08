using NeoSoft.Portal.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace NeoSoft.Portal.Data.Helpers
{
    public static class MasterHelperService
    {
        public static object EncodePasswordToBase64(string password)
        {
            try
            {
                if(password == null)
                {
                    return string.Empty;
                }
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                object encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        public static string DecodeFrom64(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }

        public static DataSet FillDataSet(string spName, List<Tuple<string, object>> parameter)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = spName;
                cmd.Connection = con;
                if (parameter != null && parameter.Count >= 1)
                {
                    foreach (Tuple<string, object> tuple in parameter)
                    {
                        cmd.Parameters.AddWithValue(tuple.Item1, Convert.ToString(tuple.Item2));
                    }
                    //cmd.Parameters.Add(tuple.Item1, Convert.ToString(tuple.Item2));

                }
                try
                {
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public static bool ExecuteQuery(string spName, List<Tuple<string, object>> parameter)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = spName;
                cmd.Connection = con;
                if (parameter != null && parameter.Count >= 1)
                {
                    foreach (Tuple<string, object> tuple in parameter)
                    {
                        cmd.Parameters.AddWithValue(tuple.Item1, tuple.Item2);
                    }
                }
                try
                {
                    con.Open();
                    int rows= cmd.ExecuteNonQuery();
                    bool status = (rows > 0 ? true : false);
                    return status;
                }
                catch (Exception ex)
                {                    
                    return false;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public static bool ExecuteScalar(string spName, List<Tuple<string, object>> parameter)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = spName;
                cmd.Connection = con;
                if (parameter != null && parameter.Count >= 1)
                {
                    foreach (Tuple<string, object> tuple in parameter)
                    {
                        cmd.Parameters.AddWithValue(tuple.Item1, tuple.Item2);
                    }
                }
                try
                {
                    con.Open();
                    bool status = Convert.ToBoolean(cmd.ExecuteScalar());
                    return status;
                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public static void CloseConnection(SqlConnection con)
        {
            con.Close();
        }
    }
}

