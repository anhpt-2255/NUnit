NUnit – TestFixture
=====================
## 1. Cách sử dụng và ví dụ về TestFixture
```csharp
using NUnit.Framework;

namespace CustomerOrderService.Tests
{
    [TestFixture]
    public class CustomerOrderServiceTests
    {
    }
}
```
Lưu ý: TestFixture chỉ có thể được dùng cho class, không dùng được cho method.

## 2. Parameterized / Arguments TestFixtures
Đôi khi các class cần các đối số (argument). Chúng ta có thể truyền các đối số vào class thông qua các contructor.
```csharp
[TestFixture(CustomerType.Basic)]
public class CustomerOrderServiceTests
{
    private CustomerType customerType;

    public CustomerOrderServiceTests(CustomerType customerType)
    {
        this.customerType = customerType;
    }
}
```
Trong ví dụ trên, class CustomerOrderServiceTests cần một tham số kiểu CustomerType, như vậy chúng ta tạo một constructor chỉ nhận vào một CustomerType. Chúng ta cung cấp giá   trị cho tham số thông qua TestFixture là CustomerType.Basic.
Nếu NUnit framework không tìm thấy constructor nào phù hợp với dạng của attribute TestFixture. Ví dụ như chúng ta không truyền vào CustomerType.Basic như là đối số, NUnit        framework sẽ báo lỗi:
 ```csharp
 Message: OneTimeSetup: No suitable constructor was found
 ```
 Chúng ta có thể tạo nhiều constructor và truyền các tham số thông qua TestFixture
  ```csharp
 [TestFixture(CustomerType.Premium, 100.00)]
 [TestFixture(CustomerType.Basic)]
 public class CustomerOrderServiceTests
 {
     private CustomerType customerType;
     private double minOrder;

     public CustomerOrderServiceTests(CustomerType customerType, double minOrder)
     {
         this.customerType = customerType;
         this.minOrder = minOrder;
     }

     public CustomerOrderServiceTests(CustomerType customerType) : this(customerType, 0)
     {
     }

     [TestCase]
     public void TestMethod()
     {
         Assert.IsTrue((customerType == CustomerType.Basic && minOrder == 0 || customerType == CustomerType.Premium && minOrder > 0));
     }
  }
   ```
Khi chúng ta tạo nhiều constructor, NUnit sẽ tạo ra các object riêng biệt tương ứng với mỗi constructor. Trong ví dụ trên, NUnit sẽ tạo hai test method khác nhau với hai       constructor của class CustomerOrderServiceTests.
 
## 2.NUnit TestFixture Inheritance
Attribute TestFixture hỗ trợ kế thừa, tức là khi chúng ta đánh dấu một class bởi attribute TestFixture, các class con của nó cũng sẽ được kế thừa attribute này. Một class cha vẫn có thể là một abstract class.

## 3.Abstract Fixture Pattern
Pattern này được sử dụng khi chúng ta muốn kiểm tra logic của class cha và đảm bảo rằng các class con không vi phạm việc thực thi class cha.
Lấy ví dụ, chúng ta có một class cha là Employee, hai class con Manager và DeliveryManager kế thừa từ class này. Chúng ta có một vài sự kiểm tra bên trong class Employee. Đồng thời chúng ta viết các trường hợp test cho class Employee và cần đảm bảo rằng những sự kiểm tra bên trong class Employee phải được xác thực thông qua class con.
 ```csharp
 public abstract class Employee
{
    public string Name { get; set; }
 
    public bool ContainsIllegalChars()
    {
        if (this.Name.Contains("$"))
        {
            return true;
        }
        return false;
    }
}
 
public class Manager : Employee {}
 
public class DeliveryManager : Employee {}
 ```
 Phần test: 
 ```csharp
 using NUnit.Framework;
 
namespace EmployeeService.Tests
{
    [TestFixture]
    public class EmployeeTests
    {
        public virtual Employee CreateEmployee()
        {
            return new Employee();
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
 ```
Chúng ta đã tạo một class EmployeeTests, trong đó chứa một virtual method CreateEmployee sẽ tạo một instance mới của class Employee và có thể bị ghi đè bởi các class con. Viết một test method dùng để test phương thức ContainsIllegalChars của class Employee.
Tạo hai test class khác là ManagerTests và VicePresidentTests thừa kế từ class EmployeeTests. Lưu ý rằng chúng ta không dùng attribute TestFixture ở các class con. Chúng sẽ tự động kế thừa attribute này nhờ sự kế thừa class.
Chúng ta ghi đè method CreateEmployee và trả về các class con kế thừa từ class Employee. NUnit framework sẽ tạo ba test method khác nhau cho cả ba class này.

## 4. Generic TestFixture
Ngoài các tham số, chúng ta cũng có thể thêm chỉ dẫn những kiểu dữ liệu nào sẽ được truyền vào thông qua attribute TestFixture. Dưới đây là ví dụ:
```csharp
 [TestFixture(CustomerType.Premium, 100.00, TypeArgs = new Type[] { typeof(CustomerType), typeof(double) })]
public class CustomerOrderServiceTests<T1, T2>
{
    private T1 customerType;
    private T2 minOrder;
 
    public CustomerOrderServiceTests(T1 customerType, T2 minOrder)
    {
        this.customerType = customerType;
        this.minOrder = minOrder;
    }
 
    [TestCase]
    public void TestMethod()
    {
        Assert.That(customerType, Is.TypeOf<CustomerType>());
        Assert.That(minOrder, Is.TypeOf<double>());
    }
}
 ```
Trong ví dụ trên, chúng ta chỉ rõ các tham số và sau đó sử dụng TypeArgs để chỉ ra những kiểu đối số. Trong TestMethod, chúng ta kiểm tra xem các tham số được truyền vào có đúng kiểu của các đối số hay không.

## 5.TestFixture Restrictions
Dưới đây là một số hạn chế của attribute TestFixture:
- Chỉ áp dụng cho class.
- Nếu không có đối số nào được cung cấp trong attribute TestFixture thì class phải có constructor mặc định.
- Nếu đối số được cung cấp trong attribute TestFixture thì class phải có constructor phù hợp.
- Chúng ta có thể áp dụng nhiều attribute TestFixture cho một class.
- Attribute TestFixture có thể được thừa kế.
- Chúng ta có thể truyền các đối số chung (generic argument) vào class TestFixture.
- Chúng ta có thể áp dụng attribute TestFixture vào abstract class.
