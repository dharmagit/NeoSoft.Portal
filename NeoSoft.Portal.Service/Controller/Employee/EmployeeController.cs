
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NeoSoft.Portal.Business;
using NeoSoft.Portal.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using NeoSoft.Portal.Service.Helpers;
using Microsoft.Extensions.Options;
using System.Data;
using System.IO;



// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NeoSoft.Portal.Service
{
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _config;
        private readonly EmployeeManager _employeeManager;
        private readonly AppSettings _appSettings;
        public EmployeeController(EmployeeManager portalManager,
               IHostingEnvironment hostingEnvironment,
                   IConfiguration config, IOptions<AppSettings> appSettings)
        {
            _employeeManager = portalManager;
            _hostingEnvironment = hostingEnvironment;
            _config = config;
        }



        /// <summary>
        /// Get Employee List
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        [HttpGet]
        //[Authorize]
        [Route("EmployeeAPI/GetEmployeeList")]
        
        public SuccessModel<object> GetEmployeeList(string keyword)
        { 
            return _employeeManager.GetEmployeeList(keyword);
        }


        /// <summary>
        /// Get Employee By Id
        /// </summary>
        /// <param name="row_Id">Id</param>
        /// <returns>Employee</returns>
        [HttpGet]
        //[Authorize]
        [Route("EmployeeAPI/GetEmployeeById")]
        public SuccessModel<object> GetEmployeeById(int row_Id)
        {
            return _employeeManager.GetEmployeeById(row_Id);
        }


        /// <summary>
        /// Save/Update Employee 
        /// </summary>
        /// <param name="employeeMaster">Employee</param>
        /// <returns></returns>
        [HttpPost]
        //[Authorize]
        [Route("EmployeeAPI/SaveEmployee")]
        public SuccessModel<object> SaveEmployee(EmployeeMaster employeeMaster)
        {
            SuccessModel<object> successModel = new SuccessModel<object>();
            return _employeeManager.SaveEmployee(employeeMaster);            
        }


        /// <summary>
        /// Remove Employee By Id
        /// </summary>
        /// <param name="row_Id"></param>
        /// <returns></returns>
        [HttpPost]
        //[Authorize]
        [Route("EmployeeAPI/RemoveEmployee")]
        public SuccessModel<object> RemoveEmployee(int row_Id)
        {
            return _employeeManager.RemoveEmployee(row_Id);
        }



    }

}