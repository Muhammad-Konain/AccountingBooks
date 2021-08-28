using AccountsApp.Models;
using AccountsApp.Profiles;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountsApp.Controllers
{
    public class TAccountsController : Controller
    {
        private IApiRequestHandler _handler;

        public TAccountsController(IApiRequestHandler handler)
        {
            _handler = handler;
        }
        public IActionResult Index()
        {
            ViewBag.allacc =JsonConvert.DeserializeObject<List<TAccount>>(_handler.GetRequest("/api/TAccounts/GetAllTAccounts"));
            return View();
        }
        public IActionResult AddEditAccount(TAccount account)
        {
            if (ModelState.IsValid) 
            {
                string reqbody = JsonConvert.SerializeObject(account);
                
                if (account.Id == 0)
                    _handler.PostRequest("/api/TAccounts/AddTAccount", reqbody);
                else
                    _handler.PostRequest("/api/TAccounts/EditTAccount", reqbody);

               // ViewBag.allacc = JsonConvert.DeserializeObject<List<TAccount>>(_handler.GetRequest("/api/TAccounts/GetAllTAccounts"));
                return RedirectToAction("Index");
            }
            return View("index");
        }
        
        public IActionResult DeleteAccount(int id)
        {
            _handler.PostRequest($"/api/TAccounts/DeleteAccount?id={id}");
            
            return Ok(JsonConvert.SerializeObject("success"));
        }
    }
}
