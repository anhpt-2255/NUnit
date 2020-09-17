using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnit_Application.Test
{   
    //Check kiểu dữ liệu truyền vào
    [TestFixture(CustomerType.Premium, 100.00)]
    public class CustomerOrderServiceTestsWithTypeArgs<T1, T2>
    {
        private T1 customerType;
        private T2 minOrder;

        public CustomerOrderServiceTestsWithTypeArgs(T1 customerType, T2 minOrder)
        {
            this.customerType = customerType;
            this.minOrder = minOrder;
        }

        [TestCase]
        public void TestMethod()
        {
            Assert.That(customerType, Is.TypeOf(typeof(CustomerType)));
            Assert.That(minOrder, Is.TypeOf(typeof(string)));
        }
    }
}
