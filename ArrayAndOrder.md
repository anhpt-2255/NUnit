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
TestCaseSource cho biết rằng có thể truyền một nguồn các tham số vào làm tham số của nó. Dưới đây là cấu trúc của TestCaseSource.
```csharp
[TestCaseSource(Type sourceType, string sourceName)]
```
Trong sourceType chúng ta định nghĩa kiểu của tham số. Trong sourceName chúng ta cung cấp tên của data source. Trong sourceName, source có thể được cung cấp dưới các dạng:
- Static Field / Property / Method Name
- Property Name
- Field Name
- Custom Type implements IEnumerable
Dưới đây là ví dụ truyền vào string array sử dụng custom type vào attribute TestCaseSource.
```csharp
public class StringArrayTestDataSource : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new string[] { "2", "4", "6" };
        yield return new string[] { "3", "4", "5" };
        yield return new string[] { "6", "8", "10" };
    }
}
 
[TestFixture]
public class EmployeeTests
{
    [TestCaseSource(typeof(StringArrayTestDataSource))]
    public void When_StringArrayAreEvenNumbers_Expects_IsStringArrayOfEvenNumbersAsTrue(string[] numbers)
    {
        Number number = new Number();
 
        bool result = number.IsStringArrayOfEvenNumbers(numbers);
 
        Assert.That(result == true);
    }
}
```
Trong ví dụ trên, chúng ta tạo một class mới StringArrayTestDataSource kế thừa từ interface IEnumerable. Trong method  GetEnumerator, chúng ta trả về các string array. Sử dụng attribute TestCaseSource và truyền vào typeof(StringArrayTestDataSource) là tham số của nó. Trong tham số của test method, chúng ta sử dụng một  string array.
Test Runner sẽ chọn một  string array từ GetEnumerator và truyền từng array một vào test method.

## 3.Thứ tự thực thi trong TestCase
Đôi khi chúng ta cần thực thi các test method theo một thứ tự nhất định. Các test method phụ thuộc lẫn nhau. Do đó, NUnit cung cấp attribute Order cho mục đích này. Dưới đây là ví dụ:
```csharp
[TestCase]
[Order(1)]
public void When_AgeGreaterAndEqualTo60_Expects_IsSeniorCitizeAsTrue()
{
    ....
}
 
[TestCase]
[Order(2)]
public void When_AgeLessThan60_Expects_IsSeniorCitizeAsFalse()
{
    ....
}
```
