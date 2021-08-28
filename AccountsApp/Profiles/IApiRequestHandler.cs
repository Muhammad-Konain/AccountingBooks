using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountsApp.Profiles
{
    public interface IApiRequestHandler
    {
        string GetRequest(string endpoint, string body = null);
        string PostRequest(string endpoint, string body=null);
    }
}
