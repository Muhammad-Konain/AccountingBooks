using AccountsAPI.Dtos;
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
    public class SetUpController : ControllerBase
    {
        private AccountsDBContext _context;
        private IMapper _mapper;

        public SetUpController(AccountsDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetFinancialYear")]
        public IActionResult GetFinancialYear()
        {
            FinancialYear currentyear = _context.FinancialYears.Where(s => s.Status == true).ToList().FirstOrDefault();
            if (currentyear != null)
            {
                FinancialYearDto yeardto = new FinancialYearDto();
                return Ok(_mapper.Map(currentyear, yeardto));
            }
            
            return NotFound();
        }

        [HttpPost]
        public IActionResult FinancialYear(FinancialYearDto fiscalyear)
        {
            bool exist = _context.FinancialYears.Any(w => w.Id == fiscalyear.Id);
            FinancialYear year = new FinancialYear();
            _mapper.Map(fiscalyear, year);

            if (!exist)
            {
                _context.FinancialYears.Add(year);
                _context.SaveChanges();
                _mapper.Map(year, fiscalyear);
                return CreatedAtRoute(nameof(GetFinancialYear), new { id = fiscalyear.Id }, fiscalyear);
            }
            
            _context.FinancialYears.Update(year);
            _context.SaveChanges();
            
            return Ok(_mapper.Map( year,fiscalyear));
        }
    }
}
