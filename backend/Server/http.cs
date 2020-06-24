using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace Server
{
    public class http
    {
        HttpClient client = new HttpClient();

        public String getAPI(string url)
        {

            string data = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
            return data;
        }
    }
}
