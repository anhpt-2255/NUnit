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
