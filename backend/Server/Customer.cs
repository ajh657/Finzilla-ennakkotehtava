using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{
    public class Customer
    {
        public int id;
        public string name;
        public Address address;
    }

    public class Address
    {
        public string streetAdress;
        public string city;
        public string state;
        public string zip;
    }
}
