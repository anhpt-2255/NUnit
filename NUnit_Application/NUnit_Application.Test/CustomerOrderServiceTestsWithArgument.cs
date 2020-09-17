using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit_Application;

namespace NUnit_Application.Test
{
    [TestFixture(CustomerType.Premium, 100.00)]
    [TestFixture(CustomerType.Basic)]    
    public class CustomerOrderServiceTestsWithArgument
    {
        private CustomerType customerType;
        private double minOrder;

        public CustomerOrderServiceTestsWithArgument(CustomerType customerType, double minOrder)
        {
            this.customerType = customerType;
            this.minOrder = minOrder;
        }

        public CustomerOrderServiceTestsWithArgument(CustomerType customerType) : this(customerType, 0)
        {
        }
            
        [TestCase]
        public void TestMethod()
        {
            Assert.IsTrue((customerType == CustomerType.Basic && minOrder == 0 || customerType == CustomerType.Premium && minOrder > 10000));
        }
    }
}
