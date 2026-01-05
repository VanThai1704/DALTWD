# ĐỒ ÁN MÔN HỌC: LẬP TRÌNH TRÊN MÔI TRƯỜNG WINDOWS
## HỆ THỐNG QUẢN LÝ NHÀ SÁCH

---

## 1. THÔNG TIN CHUNG

- **Môn học:** Lập trình trên môi trường Windows  
- **Đề tài:** Xây dựng hệ thống quản lý nhà sách  
- **Ngôn ngữ:** C# (Windows Forms, .NET Framework 4.8)  
- **Cơ sở dữ liệu:** Microsoft SQL Server  
- **ORM:** Entity Framework 6.4.4  
- **Báo cáo:** Microsoft ReportViewer + RDLC  
- **Thư viện hỗ trợ:** ClosedXML (Excel), iTextSharp (PDF), OpenXML (Word)

---

## 2. MỤC TIÊU ĐỀ TÀI

- Xây dựng ứng dụng desktop quản lý nhà sách với giao diện thân thiện, dễ sử dụng.  
- Áp dụng lập trình hướng đối tượng (OOP) trong C#.  
- Sử dụng Entity Framework để làm việc với CSDL SQL Server.  
- Thiết kế hệ thống phân quyền người dùng theo vai trò (Admin, Quản lý, Nhân viên, Nhân viên xem-only).  
- Đảm bảo an toàn tài khoản bằng cơ chế `PasswordSalt` + hash mật khẩu (class `PasswordHelper`).  
- Tích hợp hệ thống báo cáo (RDLC + ReportViewer) và chức năng xuất dữ liệu ra Excel/PDF/Word.

---

## 3. CÔNG NGHỆ VÀ CẤU TRÚC DỰ ÁN

### 3.1. Công nghệ chính

- **.NET Framework 4.8** – nền tảng chạy ứng dụng WinForms.  
- **C#** – ngôn ngữ lập trình chính.  
- **Windows Forms** – xây dựng giao diện người dùng.  
- **SQL Server** – lưu trữ dữ liệu.  
- **Entity Framework 6.4.4** – ORM truy cập dữ liệu.  
- **Microsoft ReportViewer + RDLC** – hiển thị và in báo cáo.  
- **ClosedXML, iTextSharp, OpenXML** – xuất dữ liệu ra Excel, PDF, Word.

### 3.2. Thư mục quan trọng

- `QLNhaSach/` – mã nguồn chính của ứng dụng WinForms.  
  - `Form*.cs` – các form giao diện (Sách, Khách hàng, Đơn hàng, Kho, Thống kê, Báo cáo, Đăng nhập, Người dùng, Role, …).  
  - `Models/QuanLyNhaSachModels.cs` – các lớp mô hình (Sach, KhachHang, DonHang, TonKho, HoaDon, NguoiDung, Role, …).  
  - `Report/` – các file báo cáo RDLC.  
  - `ReportHelper.cs` – tạo, cấu hình và xuất báo cáo (ReportViewer, RDLC, export Excel/PDF/Word).  
  - `UITheme.cs`, `FontHelper.cs` – tùy chỉnh giao diện (màu sắc, font tiếng Việt, DataGridView, Button, MenuStrip…).  
  - `GridHelper.cs`, `DataGridViewExtensions.cs` – đặt tên cột tiếng Việt, định dạng lưới dữ liệu.  
  - `PasswordHelper.cs`, `RolePermissions.cs` – xử lý bảo mật mật khẩu và phân quyền theo vai trò.  
  - `Tools/DatabaseSeeder.cs` – tạo dữ liệu mẫu.  
- `QLNhaSach/SQL Scripts/` – các script SQL: tạo bảng, data mẫu, user, phân quyền.  
- `QLNhaSach/LOGIN_INFO.md` – thông tin tài khoản mặc định.  
- `QuanLyNhaSach.bak` – file backup cơ sở dữ liệu (**GIỮ LẠI**, không xóa).

> Lưu ý: Các thư mục build tạm như `QLNhaSach/bin` và `QLNhaSach/obj` có thể bị xóa; khi build lại dự án, Visual Studio sẽ tự tạo lại.

---

## 4. CÁC CHỨC NĂNG CHÍNH

### 4.1. Quản lý sách

- Thêm, sửa, xóa thông tin sách.  
- Quản lý thể loại sách, nhà xuất bản.  
- Tìm kiếm sách theo mã sách, tên sách, tác giả, thể loại.  
- Hiển thị danh sách sách bằng `DataGridView` với tiêu đề cột tiếng Việt.  

### 4.2. Quản lý khách hàng

- Lưu thông tin khách hàng: mã KH, tên, địa chỉ, số điện thoại, email, ngày đăng ký.  
- Tìm kiếm khách hàng theo mã hoặc tên.  
- Hỗ trợ thống kê khách hàng thông qua các báo cáo.  

### 4.3. Quản lý đơn hàng & hóa đơn

- Lập đơn hàng cho khách hàng, chọn sách và số lượng.  
- Tự động tính tổng tiền đơn hàng.  
- Quản lý trạng thái đơn hàng: Chờ xử lý, Đang giao, Hoàn thành, Hủy.  
- Liên kết với hóa đơn (FormHoaDon) để theo dõi thanh toán.  

### 4.4. Quản lý kho (Nhập/Xuất kho, tồn kho)

- Nhập kho, xuất kho theo từng mã sách.  
- Lưu lịch sử giao dịch kho (số lượng, loại giao dịch, thời gian, ghi chú).  
- Xem báo cáo tồn kho, số lượng còn lại, giá trị tồn kho.  
- Cảnh báo sách sắp hết hàng (qua báo cáo).  

### 4.5. Thống kê & báo cáo

- Báo cáo doanh thu theo tháng, theo năm.  
- Báo cáo tồn kho chi tiết, danh sách sách, danh sách khách hàng, danh sách đơn hàng.  
- Xem báo cáo trực tiếp trên ReportViewer (RDLC).  
- Xuất báo cáo ra Excel, PDF, Word thông qua `ReportHelper` (ClosedXML, iTextSharp, OpenXML).  

### 4.6. Quản lý người dùng & phân quyền

- Màn hình đăng nhập hệ thống (`FormDangNhap`).  
- Quản lý người dùng: thêm, sửa, xóa, kích hoạt/tạm khóa tài khoản.  
- Quản lý vai trò (Role) và phân quyền theo vai trò.  
- Cơ chế bảo mật: mỗi người dùng có `PasswordSalt` riêng, mật khẩu được hash và lưu an toàn.  
- Phân quyền hiển thị menu, nút chức năng theo vai trò (Admin / Quản lý / Nhân viên / Nhân viên chỉ xem) qua `RolePermissions`.

### 4.7. Quyền theo Role (các cờ QuyenDoc/QuyenXem/QuyenSua)

- Bảng `Role` có thêm 3 cột kiểu `bit`: `QuyenDoc`, `QuyenXem`, `QuyenSua`.  
- Trong form `FormRoleEdit`, khi tạo/sửa vai trò, có 3 checkbox tương ứng để cấu hình:  
  - `Quyền đọc`, `Quyền xem`, `Quyền sửa`.  
- Các cờ này được lưu trong bảng `Role` và có thể được sử dụng để kiểm soát chi tiết hành vi của từng vai trò (mở rộng trong `RolePermissions.cs`).

### 4.8. Đăng nhập & đăng xuất

- **Đăng nhập:**  
  - Chạy ứng dụng, màn hình `ĐĂNG NHẬP HỆ THỐNG` hiển thị.  
  - Nhập tên đăng nhập và mật khẩu.  
  - Nếu thành công, `FormDangNhap` trả về `NguoiDung DangNhapThanhCong` và mở `Form1` với user tương ứng.  
- **Đăng xuất:**  
  - Từ `Form1`, vào menu `☰ Chức năng` → chọn `⏻ Đăng xuất`.  
  - Sự kiện `menuDangXuat_Click` sẽ hỏi xác nhận rồi gọi `Application.Restart();`.  
  - Ứng dụng khởi động lại, quay về `Program.Main` và hiển thị lại màn hình đăng nhập.  
  - Cách này tránh lỗi dừng ứng dụng do đóng nhầm form chính.

---

## 5. HƯỚNG DẪN CÀI ĐẶT VÀ CHẠY CHƯƠNG TRÌNH

### 5.1. Yêu cầu môi trường

- Windows cài .NET Framework 4.8 trở lên.  
- SQL Server (khuyến nghị 2016 trở lên).  
- Visual Studio (2019/2022) hoặc công cụ tương đương để mở solution.

### 5.2. Khởi tạo cơ sở dữ liệu

1. Tạo database trống tên **QuanLyNhaSach** trong SQL Server.  
2. Phục hồi file backup `QuanLyNhaSach.bak` vào database đó (Restore Database).  
3. Nếu chưa có bảng người dùng/role, chạy script `CreateUserTables.sql` (tham khảo thêm file `QLNhaSach/LOGIN_INFO.md`).  
4. Đảm bảo bảng `Role` có 3 cột kiểu `bit`: `QuyenDoc`, `QuyenXem`, `QuyenSua`.

### 5.3. Tài khoản đăng nhập mặc định

Xem chi tiết trong `QLNhaSach/LOGIN_INFO.md`.  
Khuyến nghị đổi mật khẩu ngay sau khi đăng nhập lần đầu.

### 5.4. Cách chạy chương trình

- Mở file solution `QLNhaSach.sln` bằng Visual Studio.  
- Chọn project khởi động là `QLNhaSach`.  
- Nhấn **Start/Run** để chạy ứng dụng.  

Sau khi build, file chạy nằm tại: `QLNhaSach\bin\Debug\QLNhaSach.exe` (hoặc `Release`)

---

## 6. GỢI Ý BỐ CỤC VIẾT BÁO CÁO ĐỒ ÁN

Khi viết báo cáo, có thể dựa trên các mục sau:

1. **Giới thiệu đề tài**  
   - Lý do chọn đề tài.  
   - Mục tiêu, phạm vi áp dụng.  

2. **Phân tích hệ thống**  
   - Các chức năng chính (quản lý sách, khách hàng, đơn hàng, kho, báo cáo, người dùng).  
   - Sơ đồ use-case, mô tả yêu cầu nghiệp vụ.  

3. **Thiết kế hệ thống**  
   - Mô hình cơ sở dữ liệu (các bảng: Sach, KhachHang, DonHang, TonKho, HoaDon, NguoiDung, Role, NhaXuatBan, TheLoai, …).  
   - Thiết kế lớp (class diagram) và một số class quan trọng (Models, Helper).  
   - Thiết kế giao diện: Form chính, các form chức năng, form báo cáo.  

4. **Cài đặt và triển khai**  
   - Mô tả cách hiện thực từng module trong mã nguồn.  
   - Trình bày cách sử dụng Entity Framework, ReportViewer, các thư viện export.  
   - Minh họa bằng hình ảnh giao diện và đoạn code tiêu biểu.

5. **Kiểm thử và đánh giá**  
   - Một số ca kiểm thử (thêm/sửa/xóa, tìm kiếm, nhập/xuất kho, tạo báo cáo, phân quyền…).  
   - Đánh giá kết quả đạt được, những điểm mạnh/yếu của hệ thống.

6. **Kết luận và hướng phát triển**  
   - Kết luận chung về đề tài.  
   - Đề xuất hướng phát triển: thêm biểu đồ thống kê, gửi email báo cáo, đưa hệ thống lên web, v.v.

---

README này được viết lại hoàn toàn bằng tiếng Việt có dấu để hỗ trợ trực tiếp cho việc viết báo cáo và thuyết trình đồ án, đồng thời cập nhật các thay đổi mới nhất: cơ chế đăng xuất (`Application.Restart`) và phân quyền chi tiết bằng các cờ `QuyenDoc`, `QuyenXem`, `QuyenSua` trong bảng `Role` và form `FormRoleEdit`.
