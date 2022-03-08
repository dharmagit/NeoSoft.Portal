using NeoSoft.Portal.Data.Helpers;
using NeoSoft.Portal.Data.Interface;
using NeoSoft.Portal.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.Linq;
using System.Data;

namespace NeoSoft.Portal.Data
{
    public class MasterRepository : DBConnections, IDisposable, IMasterRepository
    {

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
            }
            // free native resources if there are any.
        }

        #region "Generic Repo"

        public async Task<int> CreateAsSync(string procedureName, SqlCommand command)
        {
            SqlConnection connection = new SqlConnection(); //GetConnection();
            try
            {
                command.CommandText = procedureName;
                command.Connection = connection;

                command.CommandType = System.Data.CommandType.StoredProcedure;
                await connection.OpenAsync();
                var intReturnValue = await command.ExecuteScalarAsync();
                connection.Close();
                return Convert.ToInt32(intReturnValue);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            
        }

       

            #endregion

            #region Employee



            public SuccessModel<object> SaveEmployee(EmployeeMaster EmployeeMaster)
        {
            Employee employee = new Employee();
            employee.FirstName = EmployeeMaster.FirstName;
            employee.LastName = EmployeeMaster.LastName;
            employee.Row_Id = EmployeeMaster.Row_Id;
            employee.EmailAddress = EmployeeMaster.EmailAddress;
            employee.MobileNumber = EmployeeMaster.MobileNumber;
            employee.PassportNumber = EmployeeMaster.PassportNumber;
            employee.PanNumber = EmployeeMaster.PanNumber;
            employee.CityId = EmployeeMaster.CityId;
            employee.StateId = EmployeeMaster.StateId;
            employee.CountryId = EmployeeMaster.CountryId;
            employee.DateOfBirth = EmployeeMaster.DateOfBirth;
            employee.DateOfJoinee = EmployeeMaster.DateOfJoinee;
            employee.Gender = EmployeeMaster.Gender;

            try
            {
                var parameterList = new List<Tuple<string, object>>
                 {
                    Tuple.Create("@Row_Id", employee.Row_Id),
                    Tuple.Create("@FirstName",employee.FirstName),
                    Tuple.Create("@LastName",employee.LastName),
                    Tuple.Create("@CountryId",employee.CountryId),
                    Tuple.Create("@StateId",employee.StateId),
                    Tuple.Create("@CityId",employee.CityId),
                    Tuple.Create("@EmailAddress",employee.EmailAddress),
                    Tuple.Create("@MobileNumber",employee.MobileNumber),
                    Tuple.Create("@PanNumber",employee.PanNumber),
                    Tuple.Create("@PassportNumber",employee.PassportNumber),
                    Tuple.Create("@ProfileImage",employee.ProfileImage),
                    Tuple.Create("@Gender",employee.Gender),
                    Tuple.Create("@DateOfBirth",employee.DateOfBirth),
                    Tuple.Create("@DateOfJoinee",employee.DateOfJoinee)

                };
                DataSet ds = MasterHelperService.FillDataSet("stp_Emp_SaveEmployeeMaster", parameterList);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Columns.Count == 1)
                    {
                        return new SuccessModel<object>()
                        {
                            Status = false,
                            Data = null,
                            ErrorMessage = "Email is already being used by another client."
                        };
                    }
                    else
                    {
                        List<EmployeeMaster> EmployeeMasters = DataTableToList<EmployeeMaster>(ds.Tables[0]);
                        EmployeeMaster = EmployeeMasters[0];
                    }

                }

                return new SuccessModel<object>()
                {
                    Status = true,
                    Data = EmployeeMaster,
                    ErrorMessage = null
                };
            }
            catch (Exception)
            {

                return new SuccessModel<object>()
                {
                    Status = false,
                    Data = null,
                    ErrorMessage = "Failed"
                };
            }


        }

        public SuccessModel<object> GetEmployeeList(string keyword)
        {
            List<EmployeeMaster> EmployeeMasters = new List<EmployeeMaster>();
            try
            {
                object Keyword = keyword;
                var parameterList = new List<Tuple<string, object>>
                 {

                    Tuple.Create("@Keyword",Keyword)


                };
                DataSet ds = MasterHelperService.FillDataSet("stp_Emp_GetEmployeeList", parameterList);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    EmployeeMasters = DataTableToList<EmployeeMaster>(ds.Tables[0]);


                }

                return new SuccessModel<object>()
                {
                    Status = true,
                    Data = EmployeeMasters,
                    ErrorMessage = null
                };
            }
            catch (Exception ex)
            {

                return new SuccessModel<object>()
                {
                    Status = false,
                    Data = null,
                    // ErrorMessage = "Failed"
                    ErrorMessage = ex.Message
                };
            }


        }

        public SuccessModel<object> GetEmployeeById(int row_Id)
        {
            try
            {
                object id = row_Id;
                EmployeeMaster EmployeeMaster = new EmployeeMaster();
                var parameterList = new List<Tuple<string, object>>
                 {

                    Tuple.Create("@Row_Id",id),

                };
                DataSet ds = MasterHelperService.FillDataSet("stp_Emp_GetEmployeeById", parameterList);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    List<EmployeeMaster> EmployeeMasters = DataTableToList<EmployeeMaster>(ds.Tables[0]);
                    EmployeeMaster = EmployeeMasters[0];

                }
                return new SuccessModel<object>()
                {
                    Status = true,
                    Data = EmployeeMaster,
                    ErrorMessage = null
                };
            }
            catch (Exception ex)
            {

                return new SuccessModel<object>()
                {
                    Status = false,
                    Data = null,
                    //ErrorMessage = "Failed"
                    ErrorMessage = ex.Message
                };
            }


        }

        public SuccessModel<object> RemoveEmployee(int row_Id)
        {
            try
            {
                object id = row_Id;
                var parameterList = new List<Tuple<string, object>>
                 {

                    Tuple.Create("@Row_Id",id)

                };
                bool status = MasterHelperService.ExecuteQuery("stp_Emp_RemoveEmployeeMaster", parameterList);

                return new SuccessModel<object>()
                {
                    Status = true,
                    Data = status,
                    ErrorMessage = null
                };
            }
            catch (Exception ex)
            {
                return new SuccessModel<object>()
                {
                    Status = false,
                    Data = false,
                    ErrorMessage = Convert.ToString(ex.Message)
                };
            }


        }
        

        #endregion

        #region Location
        public SuccessModel<object> GetCountryList()
        {
            List<CountryMaster> countryMasters = new List<CountryMaster>();
            try
            {
                //object Keyword = keyword;
                var parameterList = new List<Tuple<string, object>>
                 {

                    //Tuple.Create("@Keyword",Keyword)


                };
                DataSet ds = MasterHelperService.FillDataSet("stp_Emp_GetCountryList", parameterList);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    countryMasters = DataTableToList<CountryMaster>(ds.Tables[0]);


                }

                return new SuccessModel<object>()
                {
                    Status = true,
                    Data = countryMasters,
                    ErrorMessage = null
                };
            }
            catch (Exception ex)
            {

                return new SuccessModel<object>()
                {
                    Status = false,
                    Data = null,
                    // ErrorMessage = "Failed"
                    ErrorMessage = ex.Message
                };
            }


        }

      

        public SuccessModel<object> GetStateList(int countryId)
        {
            List<StateMaster> stateMasters = new List<StateMaster>();
            try
            {
                object id = countryId;
                var parameterList = new List<Tuple<string, object>>
                {

                    Tuple.Create("@CountryId",id)


                };
                DataSet ds = MasterHelperService.FillDataSet("stp_Emp_GetStateList", parameterList);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    stateMasters = DataTableToList<StateMaster>(ds.Tables[0]);


                }

                return new SuccessModel<object>()
                {
                    Status = true,
                    Data = stateMasters,
                    ErrorMessage = null
                };
            }
            catch (Exception ex)
            {

                return new SuccessModel<object>()
                {
                    Status = false,
                    Data = null,
                    // ErrorMessage = "Failed"
                    ErrorMessage = ex.Message
                };
            }


        }

        public SuccessModel<object> GetCityList(int stateId)
        {
            List<CityMaster> cityMasters = new List<CityMaster>();
            try
            {
                object id = stateId;
                var parameterList = new List<Tuple<string, object>>
                {

                    Tuple.Create("@StateId",id)


                };
                DataSet ds = MasterHelperService.FillDataSet("stp_Emp_GetCityList", parameterList);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    cityMasters = DataTableToList<CityMaster>(ds.Tables[0]);


                }

                return new SuccessModel<object>()
                {
                    Status = true,
                    Data = cityMasters,
                    ErrorMessage = null
                };
            }
            catch (Exception ex)
            {

                return new SuccessModel<object>()
                {
                    Status = false,
                    Data = null,
                    // ErrorMessage = "Failed"
                    ErrorMessage = ex.Message
                };
            }


        }
        #endregion


    }
}
