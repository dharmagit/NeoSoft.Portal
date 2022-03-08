using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;
using HDFC.Core.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace NeoSoft.Portal.Data
{
    public class DBConnections
    {
        protected Database SQLDB
        {
            get;
            set;
        }

        public DBConnections ()
        {
            ///SQLDB = new SqlDatabase(OracleConnectionHelper.ConnectionStringMaster);
            string strConnect = 
                //@"Data Source=DHARMESHG\JAYSERVER;Initial Catalog=NeoSoft;User Id=sa;Password=udsl@1210;";
            ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            SQLDB = new SqlDatabase(strConnect);
        }

        public static List<T> DataTableToList<T>(DataTable dt) where T : class, new()
        {
            List<T> lstItems = new List<T>();
            if (dt != null && dt.Rows.Count > 0)
                foreach (DataRow row in dt.Rows)
                    lstItems.Add(ConvertDataRowToGenericType<T>(row));
            else
                lstItems = null;
            return lstItems;
        }

        private static T ConvertDataRowToGenericType<T>(DataRow row) where T : class, new()
        {
            Type entityType = typeof(T);
            T objEntity = new T();
            foreach (DataColumn column in row.Table.Columns)
            {
                object value = row[column.ColumnName];
                if (value == DBNull.Value) value = null;
                PropertyInfo property = entityType.GetProperty(column.ColumnName, BindingFlags.Instance | BindingFlags.IgnoreCase | BindingFlags.Public);
                try
                {
                    if (property != null && property.CanWrite)
                        property.SetValue(objEntity, value, null);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return objEntity;
        }
    }

    public static class Extensionmethod
    {
        public static string ToXml(this object oValue)
        {
            XmlSerializer serializer = new XmlSerializer(oValue.GetType());
            using (StringWriter stringWriter = new StringWriter())
            {
                serializer.Serialize(stringWriter, oValue);
                return StripXmlNamespaces(stringWriter.ToString());
            }
        }

        public static string StripXmlNamespaces(string xml)
        {
            string strXMLPattern = @"xmlns(:\w+)?=""([^""]+)""|xsi(:\w+)?=""([^""]+)""";
            xml = Regex.Replace(xml, strXMLPattern, "");
            return xml;
        }

      
    }
}
