using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnit_Application
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public decimal Amount { get; set; }
    }
}
