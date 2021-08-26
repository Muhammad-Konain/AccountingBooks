using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AccountsAPI.Profiles
{
    public class JWTAuthenticationHandler : IJWTAuthenticationHandler
    {
        private IConfiguration _config;

        public JWTAuthenticationHandler(IConfiguration config)
        {
            _config = config;
        }
        public string Authenticate(string email, string password)
        {
            if (email.Equals("konain") && password.Equals("konain"))
            {
                var TEMP =new String( _config.GetSection("jwtKey").Value);
                var tokenhandler = new JwtSecurityTokenHandler();
                var key =Encoding.ASCII.GetBytes(_config.GetSection("jwtKey").Value);
                var tokendescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.NameIdentifier, email)
            }),
                    Expires = DateTime.UtcNow.AddHours(0.4),
                    Issuer="konain.com",
                    Audience="konain.com",
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenhandler.CreateToken(tokendescriptor);
                return tokenhandler.WriteToken(token);

            }
            return null;
        }
    }
}
