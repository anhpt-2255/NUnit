NUnit – Array và Order
=====================
## 1. NUnit TestCase Array
Dưới đây là ví dụ về truyền array vào một test method.
```csharp
[TestCase(new int[] { 2, 4, 6 })]
public void When_AllNumberAreEven_Expects_AreAllNumbersEvenAsTrue(int[] numbers)
{
    Number number = new Number();
 
    bool result = number.AreAllNumbersEven(numbers);
 
    Assert.That(result == true);
}
```
Có một hạn chế đối với kiểu của array(Array type must be a constant expression). Kiểu của array bị hạn chế thuộc một trong những kiêu sau:
- bool
- byte
- char
- short
- int
- long
- float
- double
- Enum
- object
Đối với việc truyền vào các kiểu data khác như string, chúng ta có thể sử dụng kiểu object hoặc NUnit TestCaseSource. 
Dưới đây là ví dụ của việc truyền một array gồm các string được thay bằng object array.
```csharp
[TestCase(new object[] { "1", "2", "3" })]
public void When_AllNumberAreEven_Expects_AreAllNumbersEvenAsTrue(object[] numbers)
{
    ....
}
```

## 2.Attribute TestCaseSource
