using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private APIDBContext dbContext;

        public CustomerController(APIDBContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        public string getNewUserJson()
        {

            return null;
        }
    }
}
