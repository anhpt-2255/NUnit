using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit_Application;

namespace NUnit_Application.Test
{
    [TestFixture]
    //TestFixture chỉ có thể được dùng cho class, không dùng được cho method
    public class CustomerOrderServiceTests
    {
        [TestCase]
        //Mọi test method đều phải public và nên trả về kiểu void   
        public void When_PremiumCustomer_Expect_10PercentDiscount()
        {
            //Arrange
            //Khởi tạo tham số để UnitTest
            Customer premiumCustomer = new Customer
            {
                CustomerId = 1,
                CustomerName = "George",
                CustomerType = CustomerType.Premium
            };

            Order order = new Order
            {
                OrderId = 1,
                ProductId = 212,
                ProductQuantity = 1,
                Amount = 150
            };

            CustomerOrderService customerOrderService = new CustomerOrderService();

            //Act            
            customerOrderService.ApplyDiscount(premiumCustomer, order);

            //Assert
            //So sánh giá trị trả về và giá trị cần so sánh  
            //Nếu điều kiện trong assert pass thì test pass và ngược lại
            Assert.AreEqual(order.Amount, 135);
        }
    }
}
