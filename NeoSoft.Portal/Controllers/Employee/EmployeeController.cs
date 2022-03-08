using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using FrontEndApp;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using NeoSoft.Portal.Model;
using System.Threading;
using System.Net;
using System.Text;
using System.IO;
using System.Net.Http.Headers;
using System.Web.Script.Serialization;

namespace FrontEndApp.Controllers
{
    public class EmployeeController : Controller
    {


        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            List<EmployeeMaster> employeeMasterList = new List<EmployeeMaster>();
            SuccessModel<object> successModel = new SuccessModel<object>();

            List<Tuple<string, object>> parameter = new List<Tuple<string, object>>();
            CommonHelper commonHelper = new CommonHelper();
            successModel = await commonHelper.GetAPIResponse("GetEmployeeList", parameter);
            employeeMasterList = JsonConvert.DeserializeObject<List<EmployeeMaster>>(successModel.Data.ToString());

            
            BindMasterList();

            return View(employeeMasterList);
        }

        public async Task<JsonResult> GetValues(string sidx, string sord, int page, int rows) //Gets the todo Lists.  
        {
            List<EmployeeMaster> employeeMasterList = new List<EmployeeMaster>();
            SuccessModel<object> successModel = new SuccessModel<object>();

            List<Tuple<string, object>> parameter = new List<Tuple<string, object>>();
            CommonHelper commonHelper = new CommonHelper();
            successModel = await commonHelper.GetAPIResponse("GetEmployeeList", parameter);
            employeeMasterList = JsonConvert.DeserializeObject<List<EmployeeMaster>>(successModel.Data.ToString());


            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            var Results = employeeMasterList.AsQueryable();
            int totalRecords = Results.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sord.ToUpper() == "DESC")
            {
                Results = Results.OrderByDescending(s => s.Row_Id);
                Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                Results = Results.OrderBy(s => s.Row_Id);
                Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = Results
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        private void BindMasterList()
        {
            List<Tuple<string, object>> parameter = new List<Tuple<string, object>>();

            SuccessModel<object> successModel = new SuccessModel<object>();

            //Thread.Sleep(3000);

            List<CountryMaster> countryList = new List<CountryMaster>();
            //parameter = new List<Tuple<string, object>>();
            //CommonHelper commonHelper = new CommonHelper();
            //successModel = await commonHelper.GetAPIResponse("GetCountryList", parameter);
            //countryList = JsonConvert.DeserializeObject<List<CountryMaster>>(successModel.Data.ToString());
            countryList.Add(new CountryMaster { CountryName = "USA", CountryId = 231  });
            countryList.Add(new CountryMaster { CountryName = "India", CountryId = 101 });
            Session["Country"] = countryList;

        }

        /// <summary>
        /// Using this action method we will return a form to enter the details of a new employee
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            EmployeeMaster employeeModel = new EmployeeMaster();
            employeeModel.CountryMasters = (List<CountryMaster>)Session["Country"];
            // pass an object of the employeeModel class
            return View(employeeModel);
        }

        /// <summary>
        /// Method to pass the paramter values from the form to an INSERT query to add the entered employee
        /// </summary>
        /// <param name="employeeModel">data sent from the form will be binded to this employeeModel object</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Create(EmployeeMaster employeeModel)
        {
           
            SuccessModel<object> successModel = new SuccessModel<object>();
            CommonHelper commonHelper = new CommonHelper();
            successModel=await commonHelper.PostAPIResponse("SaveEmployee", employeeModel);
           

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Method used to get the employee details to edit in Edit View form
        /// </summary>
        /// <param name="id">the passed employeeID to be edited</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            EmployeeMaster employeeMaster = new EmployeeMaster();
            SuccessModel<object> successModel = new SuccessModel<object>();

            CommonHelper commonHelper = new CommonHelper();
            successModel = await commonHelper.GetAPIResponseById("GetEmployeeById", Convert.ToString(id));
            employeeMaster = JsonConvert.DeserializeObject<EmployeeMaster>(successModel.Data.ToString());

            employeeMaster.CountryMasters = (List<CountryMaster>)Session["Country"];
            return View(employeeMaster);
        }

        /// <summary>
        /// Method to pass the paramter values from the form to an UPDATE query to modify the chosen employee
        /// </summary>
        /// <param name="employeeMaster">data sent from the form will be binded to this employeeMaster object</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Edit(EmployeeMaster employeeMaster)
        {
            SuccessModel<object> successModel = new SuccessModel<object>();
            CommonHelper commonHelper = new CommonHelper();
            successModel = await commonHelper.PostAPIResponse("SaveEmployee", employeeMaster);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Method to delete the chosen employee with the EmployeeId
        /// </summary>
        /// <param name="id">the passed EmployeeId to be deleted</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            SuccessModel<object> successModel = new SuccessModel<object>();

            CommonHelper commonHelper = new CommonHelper();
            successModel = await commonHelper.PostAPIResponseWithQueryParam("RemoveEmployee", id);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Get State List By CountryId
        /// </summary>
        /// <param name="CountryId">CountryId</param>
        /// <returns>StateList</returns>
        public async Task<JsonResult> GetStateList(int CountryId)
        {
            //List<StateMaster> stateList = (List<StateMaster>)Session["State"];
            SuccessModel<object> successModel = new SuccessModel<object>();
            List<StateMaster> stateList = new List<StateMaster>();
            List<Tuple<string, object>> parameter = new List<Tuple<string, object>>();
            CommonHelper commonHelper = new CommonHelper();
            //successModel = await commonHelper.GetAPIResponse("GetStateList", parameter);
            successModel = await commonHelper.GetAPIResponseById("GetStateList", Convert.ToString(CountryId));
            stateList = JsonConvert.DeserializeObject<List<StateMaster>>(successModel.Data.ToString());


            // ------- Inserting Select Item in List -------
            stateList.Insert(0, new StateMaster { StateId = 0, StateName = "---Select State---" });

            return Json(new SelectList(stateList, "StateId", "StateName"), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get City List By State Id
        /// </summary>
        /// <param name="StateId">StateId</param>
        /// <returns>CityList</returns>
        public async Task<JsonResult> GetCityList(int StateId)
        {
            //List<CityMaster> citylist = (List<CityMaster>)Session["City"];
            SuccessModel<object> successModel = new SuccessModel<object>();
            List<CityMaster> citylist = new List<CityMaster>();
            List<Tuple<string, object>> parameter = new List<Tuple<string, object>>();
            CommonHelper commonHelper = new CommonHelper();
            //successModel = await commonHelper.GetAPIResponse("GetCityList", parameter);
            successModel = await commonHelper.GetAPIResponseById("GetCityList", Convert.ToString(StateId));

            citylist = JsonConvert.DeserializeObject<List<CityMaster>>(successModel.Data.ToString());


            // ------- Inserting Select Item in List -------
            citylist.Insert(0, new CityMaster { CityId = 0, CityName = "---Select City---" });

            return Json(new SelectList(citylist, "CityId", "CityName"), JsonRequestBehavior.AllowGet);
        }
    }

   
}

