using HDFC.Core.Logging;
using NeoSoft.Portal.Data.Interface;
using NeoSoft.Portal.Model;
using System;
using System.Collections.Generic;

namespace NeoSoft.Portal.Business
{
    public class EmployeeManager
    {
        private readonly IEmployeeRepository _masterRepository;
        public EmployeeManager(IEmployeeRepository masterRepository)
        {
            _masterRepository = masterRepository;
        }

        #region Employee       

        public SuccessModel<object> SaveEmployee(EmployeeMaster employeeMaster)
        {
            NLogManager.Info("MasterManager - SaveEmployee started");
            return _masterRepository.SaveEmployee(employeeMaster);
        }

        public SuccessModel<object> GetEmployeeList(string keyword)
        {
            NLogManager.Info("MasterManager - GetEmployeeList started");
            return _masterRepository.GetEmployeeList(keyword);
        }

        public SuccessModel<object> GetEmployeeById(int employeeId)
        {
            NLogManager.Info("MasterManager - GetEmployeeById started");
            return _masterRepository.GetEmployeeById(employeeId);
        }

        public SuccessModel<object> RemoveEmployee(int employeeId)
        {
            NLogManager.Info("MasterManager - RemoveEmployee started");
            return _masterRepository.RemoveEmployee(employeeId);
        }


        #endregion

    }
}
 
