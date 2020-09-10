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

 Trong ví dụ trên, class CustomerOrderServiceTests cần một tham số kiểu CustomerType, như vậy chúng ta tạo một constructor chỉ nhận vào một CustomerType. Chúng ta cung cấp giá trị cho tham số thông qua TestFixture là CustomerType.Basic.

 Nếu NUnit framework không tìm thấy constructor nào phù hợp với dạng của attribute TestFixture. Ví dụ như chúng ta không truyền vào CustomerType.Basic như là đối số, NUnit framework sẽ báo lỗi:
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


