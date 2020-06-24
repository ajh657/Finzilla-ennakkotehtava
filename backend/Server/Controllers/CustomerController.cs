using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Server.Controllers
{
    [Route("Customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private APIDBContext dbContext;
        JsonSerializerSettings settings;

        public CustomerController(APIDBContext context)
        {
            dbContext = context;
            settings = new JsonSerializerSettings()
             {
                 ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                 Error = (sender, args) =>
                 {
                     args.ErrorContext.Handled = true;
                 },
             };
        }

        [HttpGet]
        public string getNewUserJson()
        {
            return JsonConvert.SerializeObject(dbContext.newCustomers.Local);
        }
    }
}
