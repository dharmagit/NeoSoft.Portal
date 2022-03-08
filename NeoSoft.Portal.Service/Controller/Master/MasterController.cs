
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
    public class MasterController : ControllerBase
    {

        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _config;
        private readonly MasterManager _portalManager;
        private readonly AppSettings _appSettings;
        public MasterController(MasterManager portalManager,
               IHostingEnvironment hostingEnvironment,
                   IConfiguration config, IOptions<AppSettings> appSettings)
        {
            _portalManager = portalManager;
            _hostingEnvironment = hostingEnvironment;
            _config = config;
        }




        /// <summary>
        /// Get Country List
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[Authorize]
        [Route("MasterAPI/GetCountryList")]
        public SuccessModel<object> GetCountryList()
        {
            return _portalManager.GetCountryList();
        }


        /// <summary>
        /// Get State List
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[Authorize]
        [Route("MasterAPI/GetStateList")]
        public SuccessModel<object> GetStateList(int row_Id)
        {
            return _portalManager.GetStateList(row_Id);
        }

        /// <summary>
        /// Get City List
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[Authorize]
        [Route("MasterAPI/GetCityList")]
        public SuccessModel<object> GetCityList(int row_Id)
        {
            return _portalManager.GetCityList(row_Id);
        }

    }

}