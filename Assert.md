NUnit – Assert 
=====================
NUnit class Assert được sử dụng để xác định một test method cụ thể có đạt được kết quả mong đợi hay không.

Trong một test method, chúng ta viết code để kiểm tra hành vi của business object. Business object đó trả về một kết quả. 
Method Assert dùng để khớp kết quả thực tế nhận được và kết quả mong đợi. Nếu kết quả thực tế giống với kết quả mong đợi, trường hợp test đó pass, và ngược lại,
hai kết quả không giống nhau, test fail.

## 1. Mô hình ràng buộc
NUnit cung cấp một Mô hình ràng buộc mới để cải thiện khả năng đọc test method. Trong mô hình ràng buộc, chúng ta sử dụng một method That để kiểm tra phản hồi mong đợi.
Method That áp dụng một ràng buộc đến giá trị thực tế. Nếu ràng buộc được đáp ứng, trường hợp test của chúng ta pass, và ngược lại trường hợp đó fail.

## 2. Các Helper class
Dưới đây là một vài helper class để cung cấp một ràng buộc cho method Assert.
- Is
- Has
- Contains
- Does
- Throws

## 3. Phân loại các ràng buộc
Những ràng buộc có thể chia thành tám loại:

1. Comparison
 - Equal
 - Not Equal
 - Greater Than
 - Less Than
 - Ranges
2.String
 - Equals and Ignore Case
 - Sub string
 - Empty
 - Starts With / Ends With
 - Regex
3. Collection
 - All Items
   + Not Null
   + All Greater Than
   + All Less Than
   + Instance Of
 - No Items
 - Exactly n Items
 - Unique Items
 - Contains
 - Ordered
   + Ascending
   + Descending
   + By Single Property
   + Multiple Properties
 - Suprset/Subset
4. Conditional
  - Null
  - Boolean (True / False)
  - Empty
  - 5. Compound
  - And
  - Not
  - Or
6. Directory/File
 - File or Directory Exits
 - Same Path
 - Empty Directory
7. Type/Reference
  - Instance Of
  - Same Type
  - Assignable to another Type
8. Exceptions
  - Is Exception throws
  - Expected Exception
  - Exception Message Comparison
