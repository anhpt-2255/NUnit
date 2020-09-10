NUnit – Assert 
=====================
NUnit class Assert được sử dụng để xác định một test method cụ thể có đạt được kết quả mong đợi hay không.

Trong một test method, chúng ta viết code để kiểm tra hành vi của business object. Business object đó trả về một kết quả. 
Method Assert dùng để khớp kết quả thực tế nhận được và kết quả mong đợi. Nếu kết quả thực tế giống với kết quả mong đợi, trường hợp test đó pass, và ngược lại,
hai kết quả không giống nhau, test fail.

## 1. Mô hình ràng buộc
NUnit cung cấp một Mô hình ràng buộc mới để cải thiện khả năng đọc test method. Trong mô hình ràng buộc, chúng ta sử dụng một method That để kiểm tra phản hồi mong đợi.
Method That áp dụng một ràng buộc đến giá trị thực tế. Nếu ràng buộc được đáp ứng, trường hợp test của chúng ta pass, và ngược lại trường hợp đó fail.
