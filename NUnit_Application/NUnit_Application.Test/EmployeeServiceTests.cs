using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit_Application;

namespace NUnit_Application.Test
{
    //Tạo test fixture sẽ tự động kiểm tra cả các class kế thừa
    //Sinh 3 test method khi override method test fixture
    [TestFixture]
    public class EmployeeTests
    {
        public virtual Employee CreateEmployee()
        {            
            return new Employee(); ;
        }

        [TestCase]
        public void When_NameContainsIllegalChars_Expect_ContainsIllegalChars_ReturnsTrue()
        {
            Employee employee = CreateEmployee();
            employee.Name = "Da$ya";

            var result = employee.ContainsIllegalChars();

            Assert.IsTrue(result);
        }
    }

    public class ManagerTests : EmployeeTests
    {
        public override Employee CreateEmployee()
        {
            return new Manager();
        }
    }

    public class VicePresidentTests : EmployeeTests
    {
        public override Employee CreateEmployee()
        {
            return new DeliveryManager();
        }
    }
}
