using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stately.Portal.Service.Helpers;

namespace Stately.Portal.Service
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        // GET: api/<AccountController>
        [HttpGet]
        public string Get()
        {
            return AccountHelper.GetWinAuthAccount(HttpContext);
        }

    }
}
