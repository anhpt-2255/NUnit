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

## 2.NUnit TestCase ExpectedResult
Trong ví dụ trên, chúng ta đã cố định kết quả là true, do đó chúng ta chỉ có thể kiểm tra trường hợp test trên với các tham số chắc chắn. Nhưng bằng cách sử dụng property ExpectedResult, chúng ta có cũng có thể chỉ rõ những kết quả khác nhau tương ứng với mỗi tham số. Dưới đây là một ví dụ:
```csharp
[TestCase(Author = "Michael")]
public void When_AgeGreaterAndEqualTo60_Expects_IsSeniorCitizeAsTrue()
{
    ...
}
 
[TestCase(Author = "George")]
public void When_AgeGreaterAndEqualTo100_Expects_IsSeniorCitizeAsTrue()
{
    ...
}
```
Khi thực thi test, click chuột phải vào bất cứ test method nào và chọn GroupBy > Traits.
Bằng cách lựa chọn option này, Test Explorer sẽ phân loại test method theo các property khác nhau của TestCase.

## 3.Property TestName
Property TestName được dùng khi chúng ta phải dùng tên khác với tên của test method. Dưới đây là ví dụ:
```csharp
[TestCase(TestName = "EmployeeAgeGreaterAndEqualTo60_Expects_IsSCitizenAsTrue")]
public void When_AgeGreaterAndEqualTo60_Expects_IsSeniorCitizeAsTrue()
{
        ...
}
 
[TestCase(TestName = "EmployeeAgeGreaterThan100_Expects_IsSCitizenAsTrue")]
public void When_AgeGreaterThan100_Expects_IsSeniorCitizeAsTrue()
{
    ...
}
```

## 4. Ignore TestCase
Đôi khi chúng ta cần phải bỏ qua trường hợp test có thể do đoạn code chưa hoàn thành. Thế nên chúng ta có thể dùng property Ignore để đánh dấu trường hợp test bị bỏ qua. Test method đó vẫn sẽ được hiển thị trong Test Explorer nhưng Test Runner sẽ không thực thi nó.
```csharp
[TestCase(Ignore = "Code is not complete yet.")]
public void When_AgeGreaterAndEqualTo60_Expects_IsSeniorCitizeAsTrue()
{
    ....
}
```
