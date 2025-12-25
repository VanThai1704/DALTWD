# He Thong Quan Ly Nha Sach

## Gioi thieu
He thong quan ly nha sach chuyen nghiep duoc phat trien bang C# .NET 8 va Windows Forms, su dung Entity Framework Core de quan ly co so du lieu SQL Server.

## Tinh nang chinh

### 1. Quan ly Sach
- Them, sua, xoa thong tin sach
- Quan ly the loai, tac gia, nha xuat ban
- Tim kiem va loc sach theo nhieu tieu chi

### 2. Quan ly Khach hang
- Quan ly thong tin khach hang
- Lich su mua hang
- Thong ke khach hang than thiet

### 3. Quan ly Don hang
- Tao don hang moi
- Theo doi trang thai don hang
- In hoa don

### 4. Quan ly Kho
- Nhap xuat kho
- Bao cao ton kho
- Canh bao het hang

### 5. Thong ke & Bao cao
- Bao cao doanh thu theo thoi gian
- Thong ke sach ban chay
- Bao cao ton kho
- Xuat bao cao Excel

### 6. Quan ly Nguoi dung & Phan quyen
- Quan ly tai khoan nguoi dung
- Phan quyen theo vai tro (Role-based)
- Bao mat mat khau voi Salt & Hash


## He thong Phan quyen

### Cac vai tro (Roles)
1. **Admin** (RoleId: 1)
   - Toan quyen quan tri he thong
   - Quan ly nguoi dung va vai tro
   - Sao luu va phuc hoi du lieu
   - Xem tat ca bao cao va thong ke

2. **User** (RoleId: 2)
   - Xem va them moi du lieu co ban
   - Khong co quyen xoa
   - Khong xem duoc bao cao doanh thu

3. **Manager** (RoleId: 3)
   - Quan ly day du du lieu nghiep vu
   - Xem bao cao va thong ke
   - Khong quan ly duoc nguoi dung

4. **ReadOnly** (RoleId: 4)
   - Chi xem du lieu
   - Khong co quyen them, sua, xoa
   - Khong quan ly kho

### Ma tran Phan quyen

| Chuc nang | Admin | Manager | User | ReadOnly |
|-----------|-------|---------|------|----------|
| Quan ly Sach | ? | ? | Them/Sua | Xem |
| Quan ly Khach hang | ? | ? | Them/Sua | Xem |
| Quan ly Don hang | ? | ? | Them/Sua | Xem |
| Nhap xuat kho | ? | ? | ? | ? |
| Bao cao ton kho | ? | ? | ? | ? |
| Thong ke doanh thu | ? | ? | ? | ? |
| Xuat Excel | ? | ? | ? | ? |
| Quan ly nguoi dung | ? | ? | ? | ? |
| Quan ly vai tro | ? | ? | ? | ? |
| Sao luu/Phuc hoi | ? | ? | ? | ? |

## Yeu cau He thong

### Phan mem can thiet
- .NET 8 SDK
- SQL Server 2019 tro len (hoac SQL Server Express)
- Visual Studio 2022 (khuyen nghi)

### Thu vien su dung
- Microsoft.EntityFrameworkCore 8.0.0
- Microsoft.EntityFrameworkCore.SqlServer 8.0.0
- Microsoft.EntityFrameworkCore.Tools 8.0.0

## Cai dat

### 1. Cau hinh Database

Chay cac script SQL theo thu tu:

```bash
# 1. Tao database va bang nguoi dung
SQL: QLNhaSach/CreateUserTables.sql

# 2. Tao he thong quan ly kho
SQL: QLNhaSach/CreateStockManagementSystem.sql

# 3. Nhap du lieu mau (tuy chon)
SQL: QLNhaSach/SampleData.sql
```

### 2. Cau hinh Connection String

Mo file `Models/QuanLyNhaSachModels.cs` va cap nhat connection string:

```csharp
optionsBuilder.UseSqlServer("Server=YOUR_SERVER;Database=QuanLyNhaSach;Trusted_Connection=True;TrustServerCertificate=True;");
```

### 3. Build va Chay

```bash
# Restore packages
dotnet restore

# Build project
dotnet build

# Run application
dotnet run
```

Hoac su dung script tien ich:
```powershell
.\tools\rebuild-app.ps1
```

## Dang nhap

### Tai khoan mac dinh

Xem file `LOGIN_INFO.md` de biet thong tin dang nhap cac tai khoan mau.

**Tai khoan Admin:**
- Username: `admin`
- Password: `Admin@123`

## Cau truc Du an

```
QLNhaSach/
??? Models/                      # Entity Framework Models
?   ??? QuanLyNhaSachModels.cs
??? Forms/                       # Windows Forms
?   ??? Form1.cs                 # Form chinh
?   ??? FormDangNhap.cs         # Form dang nhap
?   ??? FormSach.cs             # Quan ly sach
?   ??? FormKhachHang.cs        # Quan ly khach hang
?   ??? FormDonHang.cs          # Quan ly don hang
?   ??? FormNhapXuatKho.cs      # Nhap xuat kho
?   ??? FormThongKe.cs          # Thong ke bao cao
?   ??? FormTonKho.cs           # Bao cao ton kho
?   ??? FormNguoiDung.cs        # Quan ly nguoi dung (Admin)
?   ??? FormRole.cs             # Quan ly vai tro (Admin)
??? Helpers/                     # Helper classes
?   ??? FontHelper.cs           # Ho tro font tieng Viet
?   ??? GridHelper.cs           # DataGridView helpers
?   ??? PasswordHelper.cs       # Ma hoa mat khau
?   ??? RolePermissions.cs      # Kiem tra quyen
?   ??? UITheme.cs              # Giao dien theme
??? Tools/                       # Utility tools
?   ??? DatabaseSeeder.cs       # Seed du lieu
??? SQL Scripts/                 # Database scripts
    ??? CreateUserTables.sql
    ??? CreateStockManagementSystem.sql
    ??? SampleData.sql
```

## Tinh nang Ky thuat

### 1. Bao mat
- Mat khau duoc ma hoa voi **PBKDF2** va **Salt**
- Phan quyen dua tren vai tro (RBAC)
- Session management cho nguoi dung dang nhap

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

### Loi ket noi Database
```
Unable to connect to SQL Server
```
**Giai phap:**
- Kiem tra SQL Server dang chay
- Kiem tra connection string
- Kiem tra firewall settings

### Loi hien thi tieng Viet
```
Vietnamese characters not displaying correctly
```
**Giai phap:**
- Dam bao font Tahoma hoac Segoe UI duoc cai dat
- Kiem tra file encoding (UTF-8)
- Goi `form.ApplyVietnameseFont()` sau `InitializeComponent()`

### Loi Entity Framework
```
The entity type 'X' requires a primary key
```
**Giai phap:**
- Cap nhat model tu database: `Scaffold-DbContext`
- Kiem tra cac bang co primary key

## Dong gop

Neu ban muon dong gop vao du an:
1. Fork repository
2. Tao branch moi (`git checkout -b feature/AmazingFeature`)
3. Commit changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to branch (`git push origin feature/AmazingFeature`)
5. Tao Pull Request

## License

Du an nay duoc phat trien cho muc dich hoc tap va nghien cuu.

## Lien he

Neu co thac mac hoac can ho tro, vui long tao issue tren repository.

---

**Phien ban:** 1.0.0  
**Ngay cap nhat:** 2025  
**Cong nghe:** .NET 8, Windows Forms, Entity Framework Core, SQL Server
