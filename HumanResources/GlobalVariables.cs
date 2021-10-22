using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Employees
{
    public static class GlobalVariables
    {
        public static HttpClient WebApiclient = new HttpClient();

        static GlobalVariables()
        {
            WebApiclient.BaseAddress = new Uri(ConfigurationManager.AppSettings["HumanResourcesWebApiURL"]);
            WebApiclient.DefaultRequestHeaders.Clear();
            WebApiclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}