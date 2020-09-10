NUnit – Attribute TestCase 
=====================
## 1. Test Method
Khi chúng ta đánh dấu attribute TestCase cho bất cứ method nào thì method đó sẽ được NUnit xem là test method và sau đó các Test Runner có thể thực thi nó.
```csharp
namespace EmployeeService
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
 
        public bool IsSeniorCitizen()
        {
            if(Age >= 60)
            {
                return true;
            }
            return false;
        }
    }
}
 
using NUnit.Framework;
 
namespace EmployeeService.Tests
{
    [TestFixture]
    public class EmployeeTests
    {
        [TestCase]
        public void When_AgeGreaterAndEqualTo60_Expects_IsSeniorCitizeAsTrue()
        {
            Employee emp = new Employee();
            emp.Age = 60;
 
            bool result = emp.IsSeniorCitizen();
 
            Assert.That(result == true);
        }
    }
}
```
Các đối số/tham số trong NUnit TestCase

Các đối số của TestCase được sử dụng khi chúng ta test cùng một trường hợp nhưng sử dụng data khác nhau.

Lấy ví dụ, trong ví dụ trên, chúng ta cố định tuổi của nhân viên ở mốc 60. Đối với các mốc tuổi khác thì chúng ta phải viết các 
trường hợp test khác. Nhưng bằng cách sử dụng các tham số của TestCase, chúng ta có thể dùng chung một test method cho các mốc tuổi khác nhau.
```csharp
[TestCase(60)]
[TestCase(80)]
[TestCase(90)]
public void When_AgeGreaterAndEqualTo60_Expects_IsSeniorCitizeAsTrue(int age)
{
    Employee emp = new Employee();
    emp.Age = age;
 
    bool result = emp.IsSeniorCitizen();
 
    Assert.That(result == true);
}
```
Trong ví dụ này, chúng ta dùng ba attribute TestCase cho cùng một method với các tham số khác nhau. NUnit framework sẽ tạo ba trường hợp test khác nhau sử dụng ba tham số này.
