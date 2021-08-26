using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountsAPI.Profiles
{
    public interface IJWTAuthenticationHandler
    {
        string Authenticate(string email, string password);
    }
}
