using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPersistLinqTests.DM
{
    class Order
    {
        public DateTime OrderDate { get; set; }
        public List<OrderDetail> Details { get; set; }
        public double Total { get; set; }
    }
}
