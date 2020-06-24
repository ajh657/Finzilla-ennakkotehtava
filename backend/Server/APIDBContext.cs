using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{
    public class APIDBContext : DbContext
    {

        public DbSet<Customer> newCustomers { get; set; }
        public DbSet<Customer> savedCustomers { get; set; }

        public APIDBContext(DbContextOptions<APIDBContext> options) : base(options)
        {
            loadNewCustomers();
        }

        public void loadNewCustomers()
        {
            http client = new http();
            string data = client.getAPI("http://www.filltext.com/?rows=100&pretty=true&id=%7Bindex%7D&name=%7Bbusiness%7D&address=%7BaddressObject%7D");
            List<Customer> customersList = JsonConvert.DeserializeObject<List<Customer>>(data);

            foreach (Customer item in customersList)
            {
                newCustomers.Add(item);
            }
        }
    }
}
