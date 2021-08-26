using AccountsApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AccountsApp.Controllers
{
    public class SetUpController : Controller
    {
        public async Task<IActionResult> Index()
        {
            string url = "https://localhost:44356/api/SetUp";
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    //var resp = ;
                    var res = JsonConvert.DeserializeObject<FinancialYear>(await response.Content.ReadAsStringAsync());
                }
            }
                
            return View();
        }
    }
}
