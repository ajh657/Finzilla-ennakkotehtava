using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server
{
    public class NewCustomers
    {
        public List<Customer> customers;
    }
    public class Customer
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("address")]
        [ForeignKey("Address")]
        [NotMapped]
        public Address Address { get; set; }
    }

    public class Address
    {
        [JsonProperty("streetAddress")]
        public string StreetAddress { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("zip")]
        public long Zip { get; set; }
    }
}
