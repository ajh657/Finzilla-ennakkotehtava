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
        //Hae uudet asiakkaat
        [HttpGet]
        public string getNewUserJson()
        {
            return JsonConvert.SerializeObject(dbContext.newCustomers.Local);
        }
        //tallentaa uden asiakkaan
        [HttpPost]
        public void Post([FromBody] string value)
        {
            Customer customer = JsonConvert.DeserializeObject<Customer>(value);
            dbContext.savedCustomers.Add(customer);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Customer customer = new Customer { Id = id };
            dbContext.savedCustomers.Attach(customer);
            dbContext.savedCustomers.Remove(customer);
        }
    }
}
