using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPersistLinqTests.DM
{
    class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public List<Order> Orders { get; set; }
    }
}
