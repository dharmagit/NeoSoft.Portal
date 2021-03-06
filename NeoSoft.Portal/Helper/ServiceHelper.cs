using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace FrontEndApp
{
    public class ServiceHelper
    {
        public HttpClient Client { get; set; }
        public ServiceHelper()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ServiceUrl"].ToString());
        }
        public HttpResponseMessage GetResponse(string url)
        {
            return Client.GetAsync(url).Result;
        }
        
        public HttpResponseMessage PostResponse(string url, HttpContent model)
        {
            return Client.PostAsync(url, model).Result;
        }
        public HttpResponseMessage DeleteResponse(string url)
        {
            return Client.DeleteAsync(url).Result;
        }
    }
}
