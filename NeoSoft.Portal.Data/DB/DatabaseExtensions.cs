using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.Portal.Data
{
    public static class DatabaseExtensions
    {
        public static Database ChangeDatabase(this Database db, string databaseName)
        {

            //Change Database
            DbConnectionStringBuilder builder = new DbConnectionStringBuilder()
            {
                ConnectionString = db.ConnectionString
                
            };

            builder["initial catalog"] = databaseName;
            
            // Create new EL DB using new connection string
            return new GenericDatabase(builder.ConnectionString, db.DbProviderFactory);

        }
             
    }

    public class SearchReportThreeParameterMapper : IParameterMapper
    {
        public void AssignParameters(DbCommand command, object[] parameterValues)
        {

            DbParameter parameter = command.CreateParameter();
            parameter.ParameterName = "@SearchKeyword";
            parameter.Value = parameterValues[0];
            command.Parameters.Add(parameter);

            parameter = command.CreateParameter();
            parameter.ParameterName = "@SearchColumn";
            parameter.Value = parameterValues[1];
            command.Parameters.Add(parameter);

            parameter = command.CreateParameter();
            parameter.ParameterName = "@CaseNumbers";
            parameter.Value = parameterValues[2];
            command.Parameters.Add(parameter);


        }
    }

    public class SearchReportOneParameterMapper : IParameterMapper
    {
        public void AssignParameters(DbCommand command, object[] parameterValues)
        {

            DbParameter parameter = command.CreateParameter();
            parameter.ParameterName = "@SearchKeyword";
            parameter.Value = parameterValues[0];
            command.Parameters.Add(parameter);



        }
    }

    public class SearchReportTwoParameterMapper : IParameterMapper
    {
        public void AssignParameters(DbCommand command, object[] parameterValues)
        {

            DbParameter parameter = command.CreateParameter();
            parameter.ParameterName = "@SearchKeyword";
            parameter.Value = parameterValues[0];
            command.Parameters.Add(parameter);

            parameter = command.CreateParameter();
            parameter.ParameterName = "@SearchType";
            parameter.Value = parameterValues[1];
            command.Parameters.Add(parameter);


        }
    }


    public class FourParameterMapper : IParameterMapper
    {
        public void AssignParameters(DbCommand command, object[] parameterValues)

        {

            DbParameter parameter = command.CreateParameter();
            parameter.ParameterName = "@CDRMasterId";
            parameter.Value = parameterValues[0];
            command.Parameters.Add(parameter);

            parameter = command.CreateParameter();
            parameter.ParameterName = "@FROMDATE";
            parameter.Value = parameterValues[1];
            command.Parameters.Add(parameter);

            parameter = command.CreateParameter();
            parameter.ParameterName = "@TODATE";
            parameter.Value = parameterValues[2];
            command.Parameters.Add(parameter);

            parameter = command.CreateParameter();
            parameter.ParameterName = "@EXCLUDE";
            parameter.Value = parameterValues[3];
            command.Parameters.Add(parameter);

        }
    }
    public class ThreeParameterMapper : IParameterMapper
    {
        public void AssignParameters(DbCommand command, object[] parameterValues)
        
        {
           
            DbParameter parameter = command.CreateParameter();
            parameter.ParameterName = "@CDRMasterId";
            parameter.Value = parameterValues[0];
            command.Parameters.Add(parameter);

            parameter = command.CreateParameter();
            parameter.ParameterName = "@FROMDATE";
            parameter.Value = parameterValues[1];
            command.Parameters.Add(parameter);

            parameter = command.CreateParameter();
            parameter.ParameterName = "@TODATE";
            parameter.Value = parameterValues[2];
            command.Parameters.Add(parameter);
               

        }
    }

    public class ExampleParameterMapper1 : IParameterMapper
    {
   
        public void AssignParameters(DbCommand command, object[] parameterValues)
        {

            DbParameter parameter = command.CreateParameter();
            parameter.ParameterName = "@CDRMasterId";
            parameter.Value = parameterValues[0];
            command.Parameters.Add(parameter);


        }
    }


}
