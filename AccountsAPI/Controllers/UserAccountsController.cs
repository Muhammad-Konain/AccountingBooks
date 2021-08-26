using AccountsAPI.Dtos;
using AccountsAPI.Models;
using AccountsAPI.Profiles;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class UserAccountsController : ControllerBase
    {
        private IJWTAuthenticationHandler _handler;
        private IMapper _mapper;

        public UserAccountsController(IJWTAuthenticationHandler handler, IMapper mapper)
        {
            _handler = handler;
            _mapper = mapper;
        }
         
        //[HttpPost]
        //public IActionResult Login(UserLoginDto usercred)
        //{
        //    return Ok();
        //}

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Authenticate([FromQuery]string id,[FromQuery] string password)
        {
            //string token = _handler.Authenticate(user.email, user.password);
            string token = _handler.Authenticate(id, password);
            if (!string.IsNullOrEmpty(token))
            {
                return Ok(token);
            }
            return Unauthorized();
        }
    }
}
