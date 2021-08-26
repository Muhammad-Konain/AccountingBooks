using AccountsApp.Models;
using AccountsApp.Profiles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AccountsApp.Controllers
{
    public class SetUpController : Controller
    {
        private IApiRequestHandler _requesthandler;

        public SetUpController(IApiRequestHandler requesthandler)
        {
            _requesthandler = requesthandler;
        }
        public async Task<IActionResult> Index()
        {
            //string url = "https://localhost:44356/api/SetUp";
            //using (HttpClient client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(url);
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //    client.DefaultRequestHeaders.Accept.Add(new me)
            //    HttpResponseMessage response = await client.GetAsync(url);
            //    if (response.IsSuccessStatusCode)
            //    {
            //        //var resp = ;
            //        var res = JsonConvert.DeserializeObject<FinancialYear>(await response.Content.ReadAsStringAsync());
            //    }
            //}

            //FinancialYear p= JsonConvert.DeserializeObject<FinancialYear>( _requesthandler.GetRequest("api/Setup"));
            FinancialYear year = new FinancialYear { Title = "sometime" };

            var cre = _requesthandler.PostRequest("api/Setup", JsonConvert.SerializeObject(year));
            return View();
        }
    }
}
