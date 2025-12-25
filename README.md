# DO AN MON: LAP TRINH TREN MOI TRUONG WINDOWS
## HE THONG QUAN LY NHA SACH

---

## THONG TIN DO AN

**Mon hoc:** Lap trinh tren moi truong Windows  
**Ngon ngu lap trinh:** C# .NET 8  
**Cong nghe:** Windows Forms Application, Entity Framework Core  
**Co so du lieu:** Microsoft SQL Server  

---

## TONG QUAN DO AN

### Gioi thieu
He thong quan ly nha sach la ung dung Windows Forms duoc xay dung nham muc dich quan ly hieu qua hoat dong kinh doanh cua mot cua hang sach. Ung dung cung cap day du cac chuc nang quan ly sach, khach hang, don hang, kho hang va thong ke bao cao.

### Muc tieu
- Xay dung ung dung Windows Forms hoan chinh voi giao dien than thien
- Ap dung cac ky thuat lap trinh huong doi tuong (OOP) trong C#
- Su dung Entity Framework Core de thao tac co so du lieu
- Trien khai he thong phan quyen nguoi dung (RBAC)
- Bao mat thong tin nguoi dung voi ma hoa mat khau


---

## CHUC NANG CHINH CUA HE THONG

### 1. Module Quan ly Sach
**Chuc nang:**
- Them moi, cap nhat, xoa thong tin sach
- Quan ly the loai sach, tac gia, nha xuat ban
- Tim kiem va loc sach theo ma sach, ten sach, tac gia, the loai
- Hien thi danh sach sach duoi dang DataGridView

**Cac control su dung:**
- DataGridView: Hien thi danh sach sach
- TextBox: Nhap thong tin sach (Ma sach, Ten sach, Tac gia, Gia ban)
- ComboBox: Chon the loai, nha xuat ban
- Button: Them, Sua, Xoa, Tim kiem
- NumericUpDown: Nhap so luong ton kho

### 2. Module Quan ly Khach hang
**Chuc nang:**
- Quan ly thong tin khach hang (Ma KH, Ten, Dia chi, SDT)
- Theo doi lich su mua hang cua khach hang
- Thong ke khach hang than thiet

**Cac control su dung:**
- DataGridView: Danh sach khach hang
- TextBox: Thong tin khach hang
- DateTimePicker: Ngay dang ky
- MaskedTextBox: So dien thoai

### 3. Module Quan ly Don hang
**Chuc nang:**
- Tao don hang moi cho khach hang
- Them sach vao don hang
- Tinh tong tien tu dong
- Theo doi trang thai don hang (Cho xu ly, Dang giao, Hoan thanh, Huy)
- In hoa don

**Cac control su dung:**
- ComboBox: Chon khach hang, chon sach
- NumericUpDown: So luong sach
- DataGridView: Chi tiet don hang
- Label: Hien thi tong tien
- GroupBox: Nhom thong tin don hang

### 4. Module Quan ly Kho
**Chuc nang:**
- Nhap hang vao kho
- Xuat hang ra khoi kho
- Bao cao ton kho hien tai
- Canh bao sach sap het hang

**Cac control su dung:**
- RadioButton: Chon loai giao dich (Nhap/Xuat)
- DateTimePicker: Ngay giao dich
- DataGridView: Danh sach giao dich

### 5. Module Thong ke & Bao cao
**Chuc nang:**
- Bao cao doanh thu theo thang, nam
- Thong ke sach ban chay
- Bao cao ton kho chi tiet
- Xuat bao cao ra Excel

**Cac control su dung:**
- Chart: Bieu do thong ke (neu co)
- DataGridView: Bang du lieu thong ke
- DateTimePicker: Chon khoang thoi gian thong ke

### 6. Module Quan ly Nguoi dung & Phan quyen
**Chuc nang:**
- Dang nhap he thong
- Quan ly tai khoan nguoi dung (Admin)
- Phan quyen theo vai tro
- Bao mat mat khau voi Salt & Hash (PBKDF2)

**Cac control su dung:**
- TextBox: Ten dang nhap, Mat khau
- CheckBox: Hien thi mat khau, Kich hoat tai khoan
- ComboBox: Chon vai tro




---

## KY THUAT LAP TRINH WINDOWS FORMS DA SU DUNG

### 1. Cac Control co ban
- **Form**: Container chinh chua cac control
- **MenuStrip**: Tao menu cho ung dung
- **Button**: Xu ly cac su kien click
- **TextBox**: Nhap lieu van ban
- **Label**: Hien thi nhan, thong tin
- **ComboBox**: Chon lua tuy chon tu danh sach
- **DataGridView**: Hien thi du lieu dang bang
- **DateTimePicker**: Chon ngay thang
- **NumericUpDown**: Nhap so voi gia tri min/max
- **Panel**: Nhom cac control lai
- **GroupBox**: Nhom cac control co lien quan

### 2. Xu ly su kien (Event Handling)
```csharp
// Su kien Click cua Button
private void btnThem_Click(object sender, EventArgs e)
{
    // Code xu ly
}

// Su kien Load cua Form
private void Form_Load(object sender, EventArgs e)
{
    // Khoi tao du lieu
}

// Su kien CellClick cua DataGridView
private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
{
    // Xu ly khi click vao cell
}
```

### 3. Lap trinh huong doi tuong (OOP)
```csharp
// Class model
public class Sach
{
    public int MaSach { get; set; }
    public string TenSach { get; set; }
    public decimal GiaBan { get; set; }
    public int SoLuongTon { get; set; }
}

// Ke thua (Inheritance)
public class FormSachEdit : Form
{
    // Cac thanh phan cua form
}

// Dong goi (Encapsulation)
private void LoadData()
{
    // Method private chi dung trong class
}
```

### 4. Ket noi va thao tac CSDL voi Entity Framework Core
```csharp
// DbContext
public class QuanLyNhaSachContext : DbContext
{
    public DbSet<Sach> Saches { get; set; }
    public DbSet<KhachHang> KhachHangs { get; set; }
    public DbSet<DonHang> DonHangs { get; set; }
}

// CRUD Operations
using (var db = new QuanLyNhaSachContext())
{
    // Create
    db.Saches.Add(new Sach { TenSach = "ABC" });
    
    // Read
    var sach = db.Saches.Find(id);
    
    // Update
    sach.GiaBan = 100000;
    db.SaveChanges();
    
    // Delete
    db.Saches.Remove(sach);
    db.SaveChanges();
}
```

### 5. Validation va xu ly loi
```csharp
// Kiem tra du lieu dau vao
if (string.IsNullOrWhiteSpace(txtTenSach.Text))
{
    MessageBox.Show("Vui long nhap ten sach!", "Thong bao", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
    return;
}

// Try-Catch xu ly loi
try
{
    db.SaveChanges();
    MessageBox.Show("Luu thanh cong!");
}
catch (Exception ex)
{
    MessageBox.Show($"Loi: {ex.Message}");
}
```

### 6. Tuy chinh giao dien (UI Customization)
```csharp
// Thay doi mau sac, font chu
this.BackColor = Color.FromArgb(236, 240, 241);
label.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
button.FlatStyle = FlatStyle.Flat;

// Tao giao dien theme tu class UITheme
UITheme.StyleButton(btnThem);
UITheme.StyleDataGridView(dataGridView);
```

---

## CONG NGHE VA THU VIEN SU DUNG

### Framework & Language
- **.NET 8.0**: Framework moi nhat cua Microsoft
- **C# 12.0**: Ngon ngu lap trinh hien dai, huong doi tuong
- **Windows Forms**: Cong nghe xay dung giao dien desktop

### Database
- **Microsoft SQL Server 2019+**: He quan tri co so du lieu
- **Entity Framework Core 8.0**: ORM framework cho .NET

### NuGet Packages
```xml
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.0" />
```

### Design Patterns
- **Repository Pattern**: Truy xuat du lieu
- **MVC Pattern**: Phan tach logic nghiep vu
- **Singleton Pattern**: Quan ly ket noi database
- **Factory Pattern**: Tao doi tuong form

---

## HE THONG PHAN QUYEN (ROLE-BASED ACCESS CONTROL)

### Cac vai tro trong he thong
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


---

## CAU TRUC CO SO DU LIEU

### So do quan he (ERD - Entity Relationship Diagram)

**Cac bang chinh:**
1. **Sach** (MaSach, TenSach, TacGia, NamXuatBan, GiaBan, SoLuongTon, MaTheLoai, MaNXB)
2. **TheLoai** (MaTheLoai, TenTheLoai)
3. **NhaXuatBan** (MaNXB, TenNXB, DiaChi, SoDienThoai)
4. **KhachHang** (MaKH, TenKH, DiaChi, SoDienThoai, NgayDangKy)
5. **DonHang** (MaDonHang, MaKH, NgayDat, TongTien, TrangThai)
6. **ChiTietDonHang** (MaDonHang, MaSach, SoLuong, DonGia, ThanhTien)
7. **GiaoDichKho** (MaGiaoDich, MaSach, LoaiGiaoDich, SoLuong, NgayGiaoDich)
8. **NguoiDung** (NguoiDungId, TenDangNhap, MatKhauHash, PasswordSalt, HoTen, RoleId, KichHoat)
9. **Role** (RoleId, RoleName, MoTa)

**Cac moi quan he:**
- Sach N-1 TheLoai
- Sach N-1 NhaXuatBan
- DonHang N-1 KhachHang
- ChiTietDonHang N-1 DonHang
- ChiTietDonHang N-1 Sach
- GiaoDichKho N-1 Sach
- NguoiDung N-1 Role

---

## YEU CAU HE THONG

### Phan mem can thiet
- .NET 8 SDK
- SQL Server 2019 tro len (hoac SQL Server Express)
- Visual Studio 2022 (khuyen nghi)

### Thu vien su dung
- Microsoft.EntityFrameworkCore 8.0.0
- Microsoft.EntityFrameworkCore.SqlServer 8.0.0
- Microsoft.EntityFrameworkCore.Tools 8.0.0


---

## HUONG DAN CAI DAT VA CHAY UNG DUNG

### Buoc 1: Cai dat phan mem yeu cau
1. Cai dat **.NET 8 SDK** tu https://dotnet.microsoft.com/download
2. Cai dat **SQL Server 2019** hoac **SQL Server Express**
3. Cai dat **Visual Studio 2022** (Community Edition mien phi)
4. Cai dat **SQL Server Management Studio (SSMS)** de quan ly database

### Buoc 2: Tao co so du lieu

Chay cac script SQL theo thu tu:

```bash
# 1. Tao database va bang nguoi dung
SQL: QLNhaSach/CreateUserTables.sql

# 2. Tao he thong quan ly kho
SQL: QLNhaSach/CreateStockManagementSystem.sql

# 3. Nhap du lieu mau (tuy chon)
SQL: QLNhaSach/SampleData.sql
```


### Buoc 3: Cau hinh Connection String

1. Mo file `QLNhaSach/Models/QuanLyNhaSachModels.cs`
2. Tim dong `optionsBuilder.UseSqlServer(...)`
3. Thay doi connection string cho phu hop:

```csharp
// Doi ten server thanh ten SQL Server cua ban
optionsBuilder.UseSqlServer(
    "Server=YOUR_SERVER_NAME;Database=QuanLyNhaSach;Trusted_Connection=True;TrustServerCertificate=True;"
);

// Vi du:
// - Server=(localdb)\\mssqllocaldb  // SQL LocalDB
// - Server=localhost                 // SQL Server Express
// - Server=.\\SQLEXPRESS             // SQL Server Express co ten instance
```

### Buoc 4: Build va chay ung dung

**Cach 1: Su dung Visual Studio**
1. Mo file `QLNhaSach.sln` trong Visual Studio
2. Nhan `Ctrl + Shift + B` de build solution
3. Nhan `F5` de chay ung dung (Debug mode)
4. Hoac nhan `Ctrl + F5` de chay khong debug

**Cach 2: Su dung Command Line**
```bash
# Di chuyen den thu muc project
cd C:\LTMTWD\QLNhaSach

# Restore NuGet packages
dotnet restore

# Build project
dotnet build

# Chay ung dung
dotnet run --project QLNhaSach/QLNhaSach.csproj
```

**Cach 3: Su dung PowerShell Script**
```powershell
# Chay script rebuild tu dong
.\tools\rebuild-app.ps1
```

### Buoc 5: Dang nhap he thong


Sau khi chay ung dung, su dung cac tai khoan sau de dang nhap:

**Tai khoan Admin (Quan tri vien):**
- Username: `admin`
- Password: `Admin@123`
- Quyen han: Toan quyen quan tri he thong

**Tai khoan Manager (Quan ly):**
- Username: `manager`  
- Password: `Manager@123`
- Quyen han: Quan ly nghiep vu, xem bao cao

**Tai khoan User (Nhan vien):**
- Username: `user1`
- Password: `User@123`
- Quyen han: Them/sua du lieu co ban

**Tai khoan ReadOnly (Chi xem):**
- Username: `viewer`
- Password: `Viewer@123`
- Quyen han: Chi xem du lieu

*Xem chi tiet trong file `QLNhaSach/LOGIN_INFO.md`*

---

## CAU TRUC THU MUC DU AN


```
QLNhaSach/
├── QLNhaSach.sln               # Solution file
├── README.md                    # Tai lieu huong dan
├── .gitignore                   # Git ignore file
│
├── QLNhaSach/                   # Project chinh
│   ├── QLNhaSach.csproj        # Project file
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
