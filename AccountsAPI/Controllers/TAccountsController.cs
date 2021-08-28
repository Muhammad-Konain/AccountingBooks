using AccountsAPI.Dtos;
using AccountsAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountsAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TAccountsController : ControllerBase
    {
        private AccountsDBContext _context;
        private IMapper _mapper;

        public TAccountsController(AccountsDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddTAccount(WriteTAccountDTO taccdto)
        {
            TAccount taccount = _mapper.Map<TAccount>(taccdto);
            taccount.Createdate = DateTime.Now;
            _context.TAccounts.Add(taccount);
            _context.SaveChanges();

            ReadTAccountDto retdto = _mapper.Map<ReadTAccountDto>(_context.TAccounts.Where(w => w.Title == taccdto.Title).ToList().First());
            
            return CreatedAtRoute(nameof(GetTAccountById), new { id = retdto.Id }, retdto);
        }

        [HttpPost]
        public IActionResult EditTAccount(WriteTAccountDTO taccountdto)
        {
            TAccount taccount = _context.TAccounts.Where(w => w.Id == taccountdto.Id).FirstOrDefault();
            if (taccount == null)
                return BadRequest();

            _mapper.Map(taccountdto, taccount);
            _context.TAccounts.Update(taccount);
            _context.SaveChanges();

            ReadTAccountDto retdto = _mapper.Map<ReadTAccountDto>(taccount);
            // return Ok(JsonConvert.SerializeObject(retdto));
            return Ok(retdto);
        }
        [HttpGet(Name = "GetTAccountById")]
        public IActionResult GetTAccountById(int id)
        {
            TAccount account = _context.TAccounts.Where(w => w.Id == id).FirstOrDefault();
            if(account==null)
                return NotFound();

            ReadTAccountDto retdto = _mapper.Map<ReadTAccountDto>(account);

            //return Ok(JsonConvert.SerializeObject(retdto));
            return Ok(retdto);
        }
        [HttpPost]
        public IActionResult DeleteAccount(int id)
        {
            TAccount taccount = _context.TAccounts.Where(w => w.Id == id).FirstOrDefault();
            if (taccount == null)
                return BadRequest();

            taccount.Status = false;
            _context.TAccounts.Update(taccount);
            _context.SaveChanges();
            return Ok("Account Deleted Successfully");
        }
        [HttpGet]
        public IActionResult GetAllTAccounts()
        {
            List<TAccount> taccounts = _context.TAccounts.Where(w=>w.Status==true).ToList();
            List<ReadTAccountDto> taccountdtos = new List<ReadTAccountDto>();
            _mapper.Map(taccounts,taccountdtos);

            //return Ok(JsonConvert.SerializeObject(taccountdtos));
            return Ok(taccountdtos);
        }

    }
}
