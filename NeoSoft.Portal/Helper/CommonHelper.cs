using FrontEndApp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FrontEndApp
{
    public class CommonHelper
    {
        public string apiURL = ConfigurationManager.AppSettings["ServiceUrl"] + "EmployeeAPI/";

        public async Task<SuccessModel<object>> GetAPIResponse(string methodName, List<Tuple<string, object>> parameters)
        {
            SuccessModel<object> successModel = new SuccessModel<object>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiURL + methodName).ConfigureAwait(false))
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    successModel = JsonConvert.DeserializeObject<SuccessModel<object>>(apiResponse);

                }
            }
            return successModel;
        }

        public async Task<SuccessModel<object>> GetAPIResponseById(string methodName, string param)
        {
            SuccessModel<object> successModel = new SuccessModel<object>();

            using (var httpClient = new HttpClient())
            {
                string url = string.Format(apiURL + methodName + "?row_Id={0}", param);
                using (var response = await httpClient.GetAsync(url).ConfigureAwait(false))
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    successModel = JsonConvert.DeserializeObject<SuccessModel<object>>(apiResponse);

                }
            }
            return successModel;
        }

        public async Task<SuccessModel<object>> PostAPIResponse(string methodName, EmployeeMaster employeeMaster)
        {
            SuccessModel<object> successModel = new SuccessModel<object>();
            string Serialized = JsonConvert.SerializeObject(employeeMaster);
            HttpContent content = new StringContent(Serialized, Encoding.Unicode, "application/json");
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsync(apiURL + methodName, content).ConfigureAwait(false))
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    successModel = JsonConvert.DeserializeObject<SuccessModel<object>>(apiResponse);
                    //countryList = JsonConvert.DeserializeObject<List<CountryMaster>>(successModel.Data.ToString());

                }
            }
            return successModel;
        }

        public async Task<SuccessModel<object>> PostAPIResponseWithQueryParam(string methodName, int id)
        {
            SuccessModel<object> successModel = new SuccessModel<object>();


            using (var httpClient = new HttpClient())
            {
                string url = string.Format(apiURL + methodName + "?row_Id={0}", Convert.ToString(id));

                using (var response = await httpClient.PostAsync(url, null).ConfigureAwait(false))
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    successModel = JsonConvert.DeserializeObject<SuccessModel<object>>(apiResponse);

                }
            }
            return successModel;
        }
    }
}
