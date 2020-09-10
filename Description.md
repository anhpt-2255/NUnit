Mô tả Unit Test (NUnit)
=====================

## 1. Một số đặc điểm của Unit Test
- Code unit test phải ngắn gọn, dễ hiểu, dễ đọc.
- Mỗi unit test là 1 đơn vi riêng biệt, độc lập, không phụ thuộc vào unit khác.
- Mỗi unit test là 1 method trong test class, tên method cũng là tên UnitTest. Do đó ta nên đặt tên hàm rõ ràng, nói rõ unit test này test cái gì (Test_A_Do_B), tên method có thể   rất dàiii cũng không sao.
- Unit Test phải nhanh, vì nó sẽ được chạy để kiểm định lỗi mỗi lần build. Do đó trong unit test nên hạn chế các task tốn thời gian như gọi I/O, database, network,…
- Unit Test nên test từng đối tượng riêng biệt. Vd: Unit Test cho Business Class thì chỉnh test chính BusinessClass đó, không nên dụng tới các class móc nối với nó (DataAccess       Class chẳng hạn).

## 2. Một số lợi ích của Unit Test:
- Nếu viết Unit Test một cách cẩn thận, code của bạn sẽ ít lỗi hơi, vì Unit Test sẽ phát hiện lỗi cho bạn.
- Phát hiện những hàm chạy chậm và không hiệu quả thông qua thời gian chạy của Unit Test.
- Tăng sự tự tin khi code, vì đã có Unit Test phát hiện lỗi.
- Khi refactor code, sửa code hay thêm chức năng mới, Unit Test đảm bảo chương trình chạy đúng, phát hiện những lỗi tiềm tàng mà ta bỏ lỡ.

## 3. Giới thiệu NUnit
  NUnit là framework nguồn mở dùng để triển khai unit test cho ngôn ngữ bên .NET.
  Unit có thể được hiểu là các hàm (function), thủ tục (procedure), hay lớp (class) hoặc phương thức (method), …

## 4. Các từ khóa cơ bản sử dụng trong khi Unit Test với NUnit
Thuộc tính trong NUnit để xác định lớp kiểm thử (test class), phương thức kiểm thử (test method), điều khiện đầu vào (pre-condition) và kết thúc (post-condition).

- TestFixture: Được sử dụng ở đầu mỗi lớp, xác định lớp đó là một lớp kiểm thử.
- Test: Được sử dụng ở đầu mỗi phương thức bên trong một lớp TestFixture, xác định đó là một phương thức kiểm thử.
- SetUp: Được sử dụng ở đầu một phương thức bên trong một lớp TestFixture, xác định đó là một phương thức điều kiện đầu vào cho từng phương thức Test. Có thể có hoặc không trong     một lớp TestFixture, và chỉ nên được khai báo một lần duy nhất trong một lớp TestFixture.
- Teardown: Được sử dụng ở đầu một phương thức bên trong một lớp TestFixture, xác định đó là một phương thức điều kiện kết thúc cho từng phương thức Test. Có thể có hoặc không       trong một lớp TestFixture, và chỉ nên được khai báo một lần duy nhất trong một lớp TestFixture.
- SetUpFixture: Được sử dụng ở đầu một lớp, xác định một lớp kiểm thử cơ bản. Trong lớp này sẽ có điều kiện bắt đầu và điều kiện kết thúc cho toàn bộ các lớp TestFixture trong     một không gian tên (namespace). Có thể có hoặc không trong một không gian tên, nhưng chỉ được khai báo một lần duy nhất.
- TestFixtureSetUp: Được sử dụng ở đầu một phương thức bên trong một lớp TestFixture, xác định đó là một phương thức điều kiện bắt đầu cho từng lớp TestFixture. Có thể có hoặc     không trong một lớp TestFixture, và chỉ được khai báo một lần duy nhất.
- TestFixtureTearDown: Được sử dụng ở đầu một phương thức bên trong một lớp TestFixture, xác định đó là một phương thức điều kiện kết thúc cho từng lớp TestFixture. Có thể có     hoặc không trong một lớp TestFixture, và chỉ được khai báo một lần duy nhất.

## 5. Cài đặt 
 Trang chủ: http://www.nunit.org/
 Download: http://www.nunit.org/index.php?p=download
 Trong file tải về, có thư mục bin chứa file NUnit.exe dùng để chạy Unit Test từ giao diện.
 Hoặc bạn có thể cài trực tiếp từ Nuget thông qua Visual Studio: Project => Manage NuGet Packets …
 
 ## 6. Cách chạy Unit Test NUnit
 Chọn Visual Studio Test Menu > Windows > Test Explorer.
 
![myimage-alt-tag](https://github.com/anhbpt-2255/NUnit/blob/master/4WiQknl.png)

Test Explorer hiển thị các test function trong phần Not Run Tests. Nhấn nút Run All để chạy các test.

![myimage-alt-tag](https://github.com/anhbpt-2255/NUnit/blob/master/LDf9w1P.png)

Phía dưới Test Explorer sẽ hiển thị kết quả test. Ở hình dưới đây, nó hiển thị kết quả củaTest1: Test Passed – Test1.

![myimage-alt-tag](https://github.com/anhbpt-2255/NUnit/blob/master/6gk4hHk.png)
