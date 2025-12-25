-- Script t?o b?ng NguoiDung và Role cho database QuanLyNhaSach

USE QuanLyNhaSach;
GO

-- T?o b?ng Role
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Role')
BEGIN
    CREATE TABLE Role (
        RoleId INT PRIMARY KEY IDENTITY(1,1),
        RoleName NVARCHAR(50) NOT NULL
    );
    PRINT N'?? t?o b?ng Role';
END
ELSE
BEGIN
    PRINT N'B?ng Role ?? t?n t?i';
END
GO

-- T?o b?ng NguoiDung
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'NguoiDung')
BEGIN
    CREATE TABLE NguoiDung (
        NguoiDungId INT PRIMARY KEY IDENTITY(1,1),
        TenDangNhap NVARCHAR(50) NOT NULL UNIQUE,
        MatKhauHash NVARCHAR(100) NOT NULL,
        HoTen NVARCHAR(200),
        RoleId INT NOT NULL,
        KichHoat BIT NOT NULL DEFAULT 1,
        CONSTRAINT FK_NguoiDung_Role FOREIGN KEY (RoleId) REFERENCES Role(RoleId)
    );
    PRINT N'?? t?o b?ng NguoiDung';
END
ELSE
BEGIN
    PRINT N'B?ng NguoiDung ?? t?n t?i';
END
GO

-- Th?m d? li?u m?u cho Role
IF NOT EXISTS (SELECT * FROM Role WHERE RoleId = 1)
BEGIN
    INSERT INTO Role (RoleName) VALUES (N'Admin');
    INSERT INTO Role (RoleName) VALUES (N'User');
    PRINT N'?? th?m d? li?u m?u cho b?ng Role';
END
ELSE
BEGIN
    PRINT N'B?ng Role ?? c? d? li?u';
END
GO

-- Th?m t?i kho?n admin m?c ??nh (t?n: admin, m?t kh?u: admin123)
-- M?t kh?u hash SHA256 c?a "admin123": 240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9
IF NOT EXISTS (SELECT * FROM NguoiDung WHERE TenDangNhap = 'admin')
BEGIN
    INSERT INTO NguoiDung (TenDangNhap, MatKhauHash, HoTen, RoleId, KichHoat) 
    VALUES (N'admin', N'240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9', N'Qu?n tr? vi?n', 1, 1);
    PRINT N'?? t?o t?i kho?n admin m?c ??nh (t?n: admin, m?t kh?u: admin123)';
END
ELSE
BEGIN
    PRINT N'T?i kho?n admin ?? t?n t?i';
END
GO

-- Th?m t?i kho?n nh?n vi?n m?u (t?n: user1, m?t kh?u: user123)
-- M?t kh?u hash SHA256 c?a "user123": 8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92
IF NOT EXISTS (SELECT * FROM NguoiDung WHERE TenDangNhap = 'user1')
BEGIN
    INSERT INTO NguoiDung (TenDangNhap, MatKhauHash, HoTen, RoleId, KichHoat) 
    VALUES (N'user1', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', N'Nguy?n V?n A', 2, 1);
    PRINT N'?? t?o t?i kho?n user m?u (t?n: user1, m?t kh?u: user123)';
END
ELSE
BEGIN
    PRINT N'T?i kho?n user1 ?? t?n t?i';
END
GO

PRINT N'Ho?n t?t t?o b?ng v? d? li?u m?u cho NguoiDung v? Role!';
PRINT N'T?i kho?n m?c ??nh:';
PRINT N'  - Admin: t?n = admin, m?t kh?u = admin123';
PRINT N'  - User: t?n = user1, m?t kh?u = user123';
GO
