# H? Th?ng Qu?n Lý Nhà Sách

## Gi?i thi?u
H? th?ng qu?n lý nhà sách chuyên nghi?p ???c phát tri?n b?ng C# .NET 8 và Windows Forms, s? d?ng Entity Framework Core ?? qu?n lý c? s? d? li?u SQL Server.

## Tính n?ng chính

### 1. Qu?n lý Sách
- Thêm, s?a, xóa thông tin sách
- Qu?n lý th? lo?i, tác gi?, nhà xu?t b?n
- Tìm ki?m và l?c sách theo nhi?u tiêu chí

### 2. Qu?n lý Khách hàng
- Qu?n lý thông tin khách hàng
- L?ch s? mua hàng
- Th?ng kê khách hàng thân thi?t

### 3. Qu?n lý ??n hàng
- T?o ??n hàng m?i
- Theo dõi tr?ng thái ??n hàng
- In hóa ??n

### 4. Qu?n lý Kho
- Nh?p xu?t kho
- Báo cáo t?n kho
- C?nh báo h?t hàng

### 5. Th?ng kê & Báo cáo
- Báo cáo doanh thu theo th?i gian
- Th?ng kê sách bán ch?y
- Báo cáo t?n kho
- Xu?t báo cáo Excel

### 6. Qu?n lý Ng??i dùng & Phân quy?n
- Qu?n lý tài kho?n ng??i dùng
- Phân quy?n theo vai trò (Role-based)
- B?o m?t m?t kh?u v?i Salt & Hash

## H? th?ng Phân quy?n

### Các vai trò (Roles)
1. **Admin** (RoleId: 1)
   - Toàn quy?n qu?n tr? h? th?ng
   - Qu?n lý ng??i dùng và vai trò
   - Sao l?u và ph?c h?i d? li?u
   - Xem t?t c? báo cáo và th?ng kê

2. **User** (RoleId: 2)
   - Xem và thêm m?i d? li?u c? b?n
   - Không có quy?n xóa
   - Không xem ???c báo cáo doanh thu

3. **Manager** (RoleId: 3)
   - Qu?n lý ??y ?? d? li?u nghi?p v?
   - Xem báo cáo và th?ng kê
   - Không qu?n lý ???c ng??i dùng

4. **ReadOnly** (RoleId: 4)
   - Ch? xem d? li?u
   - Không có quy?n thêm, s?a, xóa
   - Không qu?n lý kho

### Ma tr?n Phân quy?n

| Ch?c n?ng | Admin | Manager | User | ReadOnly |
|-----------|-------|---------|------|----------|
| Qu?n lý Sách | ? | ? | Thêm/S?a | Xem |
| Qu?n lý Khách hàng | ? | ? | Thêm/S?a | Xem |
| Qu?n lý ??n hàng | ? | ? | Thêm/S?a | Xem |
| Nh?p xu?t kho | ? | ? | ? | ? |
| Báo cáo t?n kho | ? | ? | ? | ? |
| Th?ng kê doanh thu | ? | ? | ? | ? |
| Xu?t Excel | ? | ? | ? | ? |
| Qu?n lý ng??i dùng | ? | ? | ? | ? |
| Qu?n lý vai trò | ? | ? | ? | ? |
| Sao l?u/Ph?c h?i | ? | ? | ? | ? |

## Yêu c?u H? th?ng

### Ph?n m?m c?n thi?t
- .NET 8 SDK
- SQL Server 2019 tr? lên (ho?c SQL Server Express)
- Visual Studio 2022 (khuy?n ngh?)

### Th? vi?n s? d?ng
- Microsoft.EntityFrameworkCore 8.0.0
- Microsoft.EntityFrameworkCore.SqlServer 8.0.0
- Microsoft.EntityFrameworkCore.Tools 8.0.0

## Cài ??t

### 1. C?u hình Database

Ch?y các script SQL theo th? t?:

```bash
# 1. T?o database và b?ng ng??i dùng
SQL: QLNhaSach/CreateUserTables.sql

# 2. T?o h? th?ng qu?n lý kho
SQL: QLNhaSach/CreateStockManagementSystem.sql

# 3. Nh?p d? li?u m?u (tùy ch?n)
SQL: QLNhaSach/SampleData.sql
```

### 2. C?u hình Connection String

M? file `Models/QuanLyNhaSachModels.cs` và c?p nh?t connection string:

```csharp
optionsBuilder.UseSqlServer("Server=YOUR_SERVER;Database=QuanLyNhaSach;Trusted_Connection=True;TrustServerCertificate=True;");
```

### 3. Build và Ch?y

```bash
# Restore packages
dotnet restore

# Build project
dotnet build

# Run application
dotnet run
```

Ho?c s? d?ng script ti?n ích:
```powershell
.\tools\rebuild-app.ps1
```

## ??ng nh?p

### Tài kho?n m?c ??nh

Xem file `LOGIN_INFO.md` ?? bi?t thông tin ??ng nh?p các tài kho?n m?u.

**Tài kho?n Admin:**
- Username: `admin`
- Password: `Admin@123`

## C?u trúc D? án

```
QLNhaSach/
??? Models/                      # Entity Framework Models
?   ??? QuanLyNhaSachModels.cs
??? Forms/                       # Windows Forms
?   ??? Form1.cs                 # Form chính
?   ??? FormDangNhap.cs         # Form ??ng nh?p
?   ??? FormSach.cs             # Qu?n lý sách
?   ??? FormKhachHang.cs        # Qu?n lý khách hàng
?   ??? FormDonHang.cs          # Qu?n lý ??n hàng
?   ??? FormNhapXuatKho.cs      # Nh?p xu?t kho
?   ??? FormThongKe.cs          # Th?ng kê báo cáo
?   ??? FormTonKho.cs           # Báo cáo t?n kho
?   ??? FormNguoiDung.cs        # Qu?n lý ng??i dùng (Admin)
?   ??? FormRole.cs             # Qu?n lý vai trò (Admin)
??? Helpers/                     # Helper classes
?   ??? FontHelper.cs           # H? tr? font ti?ng Vi?t
?   ??? GridHelper.cs           # DataGridView helpers
?   ??? PasswordHelper.cs       # Mã hóa m?t kh?u
?   ??? RolePermissions.cs      # Ki?m tra quy?n
?   ??? UITheme.cs              # Giao di?n theme
??? Tools/                       # Utility tools
?   ??? DatabaseSeeder.cs       # Seed d? li?u
??? SQL Scripts/                 # Database scripts
    ??? CreateUserTables.sql
    ??? CreateStockManagementSystem.sql
    ??? SampleData.sql
```

## Tính n?ng K? thu?t

### 1. B?o m?t
- M?t kh?u ???c mã hóa v?i **PBKDF2** và **Salt**
- Phân quy?n d?a trên vai trò (RBAC)
- Session management cho ng??i dùng ??ng nh?p

### 2. Entity Framework Core
- Database First approach
- Lazy loading relationships
- Transaction support
- Query optimization

### 3. UI/UX
- Modern flat design
- Vietnamese font support (Tahoma/Segoe UI)
- Responsive layout
- Theme customization

### 4. Code Quality
- Clean architecture pattern
- Separation of concerns
- Reusable helper classes
- Comprehensive error handling

## Troubleshooting

### L?i k?t n?i Database
```
Unable to connect to SQL Server
```
**Gi?i pháp:**
- Ki?m tra SQL Server ?ang ch?y
- Ki?m tra connection string
- Ki?m tra firewall settings

### L?i hi?n th? ti?ng Vi?t
```
Vietnamese characters not displaying correctly
```
**Gi?i pháp:**
- ??m b?o font Tahoma ho?c Segoe UI ???c cài ??t
- Ki?m tra file encoding (UTF-8)
- G?i `form.ApplyVietnameseFont()` sau `InitializeComponent()`

### L?i Entity Framework
```
The entity type 'X' requires a primary key
```
**Gi?i pháp:**
- C?p nh?t model t? database: `Scaffold-DbContext`
- Ki?m tra các b?ng có primary key

## ?óng góp

N?u b?n mu?n ?óng góp vào d? án:
1. Fork repository
2. T?o branch m?i (`git checkout -b feature/AmazingFeature`)
3. Commit changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to branch (`git push origin feature/AmazingFeature`)
5. T?o Pull Request

## License

D? án này ???c phát tri?n cho m?c ?ích h?c t?p và nghiên c?u.

## Liên h?

N?u có th?c m?c ho?c c?n h? tr?, vui lòng t?o issue trên repository.

---

**Phiên b?n:** 1.0.0  
**Ngày c?p nh?t:** 2025  
**Công ngh?:** .NET 8, Windows Forms, Entity Framework Core, SQL Server
