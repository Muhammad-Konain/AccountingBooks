using AccountsApp.Models;
using AccountsApp.Profiles;
using AccountsApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountsApp.Controllers
{
    public class VoucherController : Controller
    {
        private IApiRequestHandler _handler;

        public VoucherController(IApiRequestHandler handler)
        {
            _handler = handler;
        }
        public IActionResult Index()
        {
            ViewBag.vouchers = JsonConvert.DeserializeObject<List<Voucher>>( _handler.GetRequest("/api/Voucher/GetAllVocuhers"));
            List<TAccount> accounts = JsonConvert.DeserializeObject<List<TAccount>>(_handler.GetRequest("/api/TAccounts/GetAllTAccounts"));
            ViewBag.accounts = accounts.Select(s => new { s.Id, s.Title }).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult AddVoucher([FromBody]VoucherViewModel viewModel)
        {
            //Voucher vouc = new Voucher() { Vouchertype = 1, Id = 0 };
            //AccountTransaction accountTransaction1 = new AccountTransaction() { TaccountId = 20, Amount = 5600, Direction = "cr" };
            //AccountTransaction accountTransaction = new AccountTransaction() { TaccountId = 21, Amount = 5600, Direction = "dr" };
            //List<AccountTransaction> lis = new List<AccountTransaction>();
            //lis.Add(accountTransaction);
            //lis.Add(accountTransaction1);


            //VoucherViewModel viewmodel = new VoucherViewModel() { voucher = vouc, transactions = lis };
            string retvalue = _handler.PostRequest("/api/Voucher/AddVoucher", JsonConvert.SerializeObject(viewModel));
            Voucher voucher = JsonConvert.DeserializeObject<Voucher>(retvalue);

            return Ok(voucher);
        }
        public IActionResult DeleteVoucher(int id)
        {
            _handler.PostRequest($"/api/Voucher/DeleteVoucher?id={id}");
            return Ok(JsonConvert.SerializeObject("successfully deleteed voucher..."));
        }
    }
}
