using NeoSoft.Portal.Data.Interface;
using NeoSoft.Portal.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace NeoSoft.Portal.Data
{
    public class DataRepository
    {
        protected DataTable GetData(string cmdText, SqlParameter[] parameters = null,
                             CommandType cmdType = CommandType.StoredProcedure)
        {
            string connstr = "";
            // by defining these variables OUTSIDE the using statements, we can evaluate them in 
            // the debugger even when the using's go out of scope.
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataReader reader = null;
            DataTable data = null;

            // create the connection
            using (conn = new SqlConnection(connstr))
            {
                // open it
                conn.Open();
                // create the SqlCommand object
                using (cmd = new SqlCommand(cmdText, conn)
                { CommandTimeout = 0, CommandType = cmdType })
                {
                    // give the SqlCommand object the parameters required for the stored proc/query
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    //create the SqlDataReader
                    using (reader = cmd.ExecuteReader())
                    {
                        // move the data to a DataTable
                        data = new DataTable();
                        data.Load(reader);
                    }
                }
            }
            // return the DataTable object to the calling method
            return data;
        }

        //public IEnumerable<T> GetAll(string procedureName, SqlCommand command)
        //{
        //    List<EmployeeMaster> employeeMasters = new List<EmployeeMaster>();
        //    SqlConnection connection = new SqlConnection("");
        //    SqlDataAdapter da = new SqlDataAdapter();

        //    command.CommandText = procedureName;
        //    command.Connection = connection;
        //    command.CommandType = CommandType.StoredProcedure;
        //    da.SelectCommand = command;
        //    using (DataTable dt = new DataTable())
        //    {
        //        da.Fill(dt);
        //        //var result=  	
        //        //return ;
        //        employeeMasters = ConvertDataTable<EmployeeMaster>(dt);
        //    }
        //    return employeeMasters;


        //}
        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
    }
}


