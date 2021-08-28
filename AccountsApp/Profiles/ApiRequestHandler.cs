using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AccountsApp.Profiles
{
    public class ApiRequestHandler : IApiRequestHandler
    {
        private IConfiguration _config;
        public ApiRequestHandler(IConfiguration config)
        {
            _config = config;
        }
        public string GetRequest(string endpoint, string jsonbody = null)
        {
            string baseurl = _config.GetSection("ApiBaseUrl").Value;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create($"{baseurl}{endpoint}");
            req.Method = "Get";
            req.ContentType = "application/json";

            if (jsonbody != null)
            {
                using (var sw = new StreamWriter(req.GetRequestStream()))
                {
                    sw.Write(jsonbody);
                    sw.Flush();
                }
            }
            try
            {
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                using (var reader = new StreamReader(res.GetResponseStream(), Encoding.ASCII))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public string PostRequest(string endpoint, string jsonbody=null)
        {
            string baseurl = _config.GetSection("ApiBaseUrl").Value;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create($"{baseurl}{endpoint}");
            req.Method = "POST";
            req.ContentType = "application/json";

            if (jsonbody != null)
            {
                using (var sw = new StreamWriter(req.GetRequestStream()))
                {
                    sw.Write(jsonbody);
                    sw.Flush();
                }
            }
            try
            {
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                using (var reader = new StreamReader(res.GetResponseStream(), Encoding.ASCII))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
