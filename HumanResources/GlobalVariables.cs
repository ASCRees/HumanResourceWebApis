using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Employees
{
    public static class GlobalVariables
    {
        public static HttpClient WebApiclient = new HttpClient();

        static GlobalVariables()
        {
            WebApiclient.BaseAddress = new Uri("https://localhost:44383/api/");
            WebApiclient.DefaultRequestHeaders.Clear();
            WebApiclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}