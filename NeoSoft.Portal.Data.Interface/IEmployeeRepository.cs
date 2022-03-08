using NeoSoft.Portal.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace NeoSoft.Portal.Data.Interface
{
    public interface IEmployeeRepository
    {
        #region Employee
       

        SuccessModel<object> SaveEmployee(EmployeeMaster EmployeeMaster);

        SuccessModel<object> GetEmployeeList(string keyword);

        SuccessModel<object> GetEmployeeById(int employeeId);

        SuccessModel<object> RemoveEmployee(int employeeId);

        #endregion


    }
}
