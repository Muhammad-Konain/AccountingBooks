using AccountsAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrialBalanceController : ControllerBase
    {
        private AccountsDBContext _context;
        private IMapper _mapper;

        public TrialBalanceController(AccountsDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetTrialBalance()
        {
            List<int> accounts = _context.TAccounts.Where(w => w.Status == true).Select(s => s.Id).ToList();
            var tb = _context.AccountTransactions.Where(w => accounts.Contains((int)w.TaccountId)).GroupBy(g => g.TaccountId)
                //.Select(s=>new { s.Key, s.Sum(su=>su.Amount)});

            return Ok();
        }
    }
}
