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
- Thiết kế hệ thống phân quyền người dùng theo vai trò (Admin, Quản lý, Nhân viên).  
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
  - `Report/` – các file báo cáo RDLC (Report1.rdlc, Report1Backup.rdlc, Report1Simple.rdlc, …).  
  - `ReportHelper.cs` – tạo, cấu hình và xuất báo cáo (ReportViewer, RDLC, export Excel/PDF/Word).  
  - `UITheme.cs`, `FontHelper.cs` – tùy chỉnh giao diện (màu sắc, font tiếng Việt, DataGridView, Button, MenuStrip…).  
  - `GridHelper.cs`, `DataGridViewExtensions.cs` – đặt tên cột tiếng Việt, định dạng lưới dữ liệu.  
  - `PasswordHelper.cs`, `RolePermissions.cs` – xử lý bảo mật mật khẩu và phân quyền theo vai trò.  
- `QuanLyNhaSach.bak` – file backup cơ sở dữ liệu SQL Server (**GIỮ LẠI**, không xóa).

> Lưu ý: Các thư mục build tạm như `QLNhaSach/bin` và `QLNhaSach/obj` đã được dọn dẹp; khi build lại dự án, Visual Studio sẽ tự tạo lại.

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
- Cảnh báo sách sắp hết hàng (thông qua các báo cáo thống kê).

### 4.5. Thống kê & báo cáo

- Báo cáo doanh thu theo tháng, theo năm.  
- Báo cáo tồn kho chi tiết, danh sách sách, danh sách khách hàng, danh sách đơn hàng.  
- Xem báo cáo trực tiếp trên ReportViewer (RDLC).  
- Xuất báo cáo ra Excel, PDF, Word thông qua `ReportHelper` (ClosedXML, iTextSharp, OpenXML).

### 4.6. Quản lý người dùng & phân quyền

- Màn hình đăng nhập hệ thống.  
- Quản lý người dùng: thêm, sửa, xóa, kích hoạt/tạm khóa tài khoản.  
- Quản lý vai trò (Role) và phân quyền theo vai trò.  
- Cơ chế bảo mật: mỗi người dùng có `PasswordSalt` riêng, mật khẩu được hash và lưu an toàn.  
- Phân quyền hiển thị menu, nút chức năng theo vai trò (Admin / Quản lý / Nhân viên).

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

Ví dụ dùng `sqlcmd`:

```bash
sqlcmd -S . -d QuanLyNhaSach -E -i CreateUserTables.sql
```

### 5.3. Tài khoản đăng nhập mặc định

Xem chi tiết trong `QLNhaSach/LOGIN_INFO.md`. Một số tài khoản mặc định:


Khuyến nghị đổi mật khẩu ngay sau khi đăng nhập lần đầu.

### 5.4. Cách chạy chương trình

- Mở file solution `QLNhaSach.sln` bằng Visual Studio.  
- Chọn project khởi động là `QLNhaSach`.  
- Nhấn **Start/Run** để chạy ứng dụng.  

Hoặc dùng dòng lệnh (tại thư mục gốc dự án):

```bash
dotnet build
```

File chạy sau khi build: `QLNhaSach\bin\Debug\net48\QLNhaSach.exe`.

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

README này được viết lại hoàn toàn bằng tiếng Việt có dấu để hỗ trợ trực tiếp cho việc viết báo cáo và thuyết trình đồ án.
│   │
│   ├── Models/                  # Cac lop Model (Entity Framework)
│   │   └── QuanLyNhaSachModels.cs
│   │
│   ├── Forms/                   # Cac Form Windows
│   │   ├── Form1.cs            # Form chinh (Main Form)
│   │   ├── FormDangNhap.cs     # Form dang nhap
│   │   ├── FormSach.cs         # Quan ly sach
│   │   ├── FormSachEdit.cs     # Them/Sua sach
│   │   ├── FormKhachHang.cs    # Quan ly khach hang
│   │   ├── FormKhachHangEdit.cs
│   │   ├── FormDonHang.cs      # Quan ly don hang
│   │   ├── FormDonHangEdit.cs
│   │   ├── FormHoaDon.cs       # In hoa don
│   │   ├── FormNhapXuatKho.cs  # Quan ly kho
│   │   ├── FormThongKe.cs      # Thong ke bao cao
│   │   ├── FormTonKho.cs       # Bao cao ton kho
│   │   ├── FormNhaXuatBan.cs   # Quan ly NXB
│   │   ├── FormNhaXuatBanEdit.cs
│   │   ├── FormNguoiDung.cs    # Quan ly nguoi dung (Admin)
│   │   ├── FormNguoiDungEdit.cs
│   │   ├── FormRole.cs         # Quan ly vai tro (Admin)
│   │   └── FormRoleEdit.cs
│   │
│   ├── Helpers/                 # Cac lop tien ich
│   │   ├── FontHelper.cs       # Xu ly font tieng Viet
│   │   ├── GridHelper.cs       # Tien ich DataGridView
│   │   ├── PasswordHelper.cs   # Ma hoa mat khau
│   │   ├── RolePermissions.cs  # Kiem tra phan quyen
│   │   ├── UITheme.cs          # Tuy chinh giao dien
│   │   └── DataGridViewExtensions.cs
│   │
│   ├── Tools/                   # Cong cu ho tro
│   │   └── DatabaseSeeder.cs   # Tao du lieu mau
│   │
│   ├── SQL Scripts/             # Cac script SQL
│   │   ├── CreateUserTables.sql
│   │   ├── CreateStockManagementSystem.sql
│   │   └── SampleData.sql
│   │
│   ├── Program.cs               # Entry point cua ung dung
│   └── LOGIN_INFO.md            # Thong tin tai khoan
│
└── tools/                       # PowerShell scripts
    └── rebuild-app.ps1         # Script build tu dong
```

---

## HUONG DAN SU DUNG UNG DUNG

### 1. Dang nhap
- Chay ung dung, man hinh dang nhap se hien ra
- Nhap ten dang nhap va mat khau
- Nhan nut "Dang nhap"
- He thong se chuyen den man hinh chinh voi menu tuong ung quyen han

### 2. Quan ly Sach
- Chon menu "Chuc nang" > "Danh sach sach"
- **Them sach moi**: Nhan nut "Them", nhap thong tin, nhan "Luu"
- **Sua thong tin**: Click chon sach trong bang, nhan "Sua", cap nhat, nhan "Luu"
- **Xoa sach**: Chon sach, nhan "Xoa", xac nhan
- **Tim kiem**: Nhap tu khoa vao o tim kiem, he thong tu dong loc

### 3. Quan ly Khach hang
- Tuong tu nhu quan ly sach
- Co them chuc nang xem lich su mua hang cua khach hang

### 4. Tao Don hang
- Chon menu "Don hang" > "Danh sach don hang" > "Them"
- Chon khach hang tu ComboBox
- Them sach vao don hang: Chon sach, nhap so luong, nhan "Them vao gio"
- Kiem tra danh sach, he thong tu tinh tong tien
- Nhan "Luu don hang"

### 5. Nhap/Xuat Kho
- Chon menu "Nhap xuat kho"
- Chon loai giao dich (Nhap/Xuat)
- Chon sach va nhap so luong
- Nhan "Luu giao dich"
- So luong ton se tu dong cap nhat

### 6. Xem Thong ke
- Chon menu "Thong ke bao cao"
- Chon khoang thoi gian can thong ke
- Xem bao cao doanh thu, sach ban chay
- Co the xuat ra Excel (neu la Admin/Manager)

### 7. Quan ly Nguoi dung (Chi danh cho Admin)
- Chon menu "Quan ly nguoi dung"
- Them/Sua/Xoa tai khoan nguoi dung
- Phan quyen cho nguoi dung
- Khoa/Mo khoa tai khoan

---

## KET QUA DAT DUOC

### Chuc nang da hoan thanh
✅ Xay dung giao dien Windows Forms hoan chinh  
✅ Quan ly sach, khach hang, don hang  
✅ Quan ly nhap xuat kho  
✅ Thong ke bao cao doanh thu  
✅ He thong dang nhap va phan quyen  
✅ Ma hoa mat khau bao mat  
✅ Validation du lieu dau vao  
✅ Xu ly loi va thong bao cho nguoi dung  
✅ Tuy chinh giao dien dep mat, than thien  
✅ Ho tro hien thi tieng Viet dung  

### Ky nang dat duoc
✅ Lap trinh Windows Forms voi C#  
✅ Su dung cac Control co ban va nang cao  
✅ Xu ly su kien (Event Handling)  
✅ Lap trinh huong doi tuong (OOP)  
✅ Ket noi va thao tac CSDL voi Entity Framework Core  
✅ Thiet ke co so du lieu quan he  
✅ Validation va xu ly loi  
✅ Bao mat ung dung  
✅ Trien khai he thong phan quyen  

---

## KHO KHAN VA GIAI PHAP

### 1. Hien thi tieng Viet bi loi font
**Van de:** Ky tu tieng Viet hien thi sai hoac thanh dau ?  
**Giai phap:** 
- Tao lop `FontHelper.cs` de quan ly font chu
- Su dung font Tahoma hoac Segoe UI
- Goi `form.ApplyVietnameseFont()` sau `InitializeComponent()`

### 2. Ket noi database that bai
**Van de:** Khong ket noi duoc SQL Server  
**Giai phap:**
- Kiem tra SQL Server Service dang chay
- Kiem tra connection string dung
- Kiem tra firewall cho phep ket noi

### 3. Entity Framework khong load duoc du lieu
**Van de:** Relationship giua cac bang khong hoat dong  
**Giai phap:**
- Su dung `.Include()` de load related entities
- Kiem tra Foreign Key constraint trong database

### 4. DataGridView khong hien thi du lieu
**Van de:** Binding data khong thanh cong  
**Giai phap:**
```csharp
dataGridView.DataSource = null;
dataGridView.DataSource = listData;
dataGridView.Refresh();
```

---

## THAM KHAO

### Tai lieu tham khao
1. Microsoft Docs - Windows Forms: https://docs.microsoft.com/dotnet/desktop/winforms/
2. Entity Framework Core: https://docs.microsoft.com/ef/core/
3. C# Programming Guide: https://docs.microsoft.com/dotnet/csharp/

### Video huong dan
- Lap trinh Windows Forms C# - YouTube
- Entity Framework Core Tutorial - Microsoft Learn

---

## KET LUAN

Do an da xay dung thanh cong mot he thong quan ly nha sach hoan chinh voi day du cac chuc nang quan ly sach, khach hang, don hang, kho hang va thong ke bao cao. Ung dung ap dung cac ky thuat lap trinh Windows Forms hien dai, su dung Entity Framework Core de thao tac co so du lieu, va trien khai he thong phan quyen nguoi dung bao mat.

Qua qua trinh thuc hien do an, sinh vien da nam vung cac kien thuc ve lap trinh tren moi truong Windows, lap trinh huong doi tuong, thiet ke co so du lieu, va xay dung ung dung thuc te.

---

## THONG TIN LIEN HE

**Mon hoc:** Lap trinh tren moi truong Windows  
**Phien ban:** 1.0.0  
**Ngay hoan thanh:** 2025  
**Cong nghe:** .NET 8, Windows Forms, Entity Framework Core, SQL Server

---

*Tai lieu nay duoc tao de phuc vu muc dich bao cao do an mon hoc*
