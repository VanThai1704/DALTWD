-- ========================================
-- H? TH?NG T? ??NG C?P NH?T T?N KHO
-- ========================================
USE QuanLyNhaSach;
GO

-- =============================================
-- TRIGGER 1: T? ??ng c?p nh?t t?n kho khi bán hàng
-- =============================================
IF OBJECT_ID('trg_ChiTietDonHang_UpdateStock', 'TR') IS NOT NULL
    DROP TRIGGER trg_ChiTietDonHang_UpdateStock;
GO

CREATE TRIGGER trg_ChiTietDonHang_UpdateStock
ON ChiTietDonHang
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    
    -- X? lý INSERT (Thêm chi ti?t ??n hàng - XU?T KHO)
    IF EXISTS (SELECT * FROM inserted) AND NOT EXISTS (SELECT * FROM deleted)
    BEGIN
        -- Gi?m t?n kho
        UPDATE Sach
        SET SoLuongTon = SoLuongTon - i.SoLuong
        FROM Sach s
        INNER JOIN inserted i ON s.MaSach = i.MaSach;
        
        -- Ghi log vào b?ng TonKho
        INSERT INTO TonKho (MaSach, LoaiGiaoDich, SoLuong, NgayGiaoDich, GhiChu)
        SELECT 
            i.MaSach,
            N'Xu?t bán',
            -i.SoLuong, -- Âm = Xu?t
            GETDATE(),
            N'??n hàng: ' + i.MaDonHang
        FROM inserted i;
        
        PRINT '?ã c?p nh?t t?n kho (XU?T)';
    END
    
    -- X? lý UPDATE (S?a s? l??ng)
    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
    BEGIN
        -- Hoàn l?i s? l??ng c?
        UPDATE Sach
        SET SoLuongTon = SoLuongTon + d.SoLuong
        FROM Sach s
        INNER JOIN deleted d ON s.MaSach = d.MaSach;
        
        -- Tr? s? l??ng m?i
        UPDATE Sach
        SET SoLuongTon = SoLuongTon - i.SoLuong
        FROM Sach s
        INNER JOIN inserted i ON s.MaSach = i.MaSach;
        
        PRINT '?ã c?p nh?t t?n kho (S?A)';
    END
    
    -- X? lý DELETE (Xóa chi ti?t ??n - Hoàn l?i kho)
    IF EXISTS (SELECT * FROM deleted) AND NOT EXISTS (SELECT * FROM inserted)
    BEGIN
        -- Hoàn l?i t?n kho
        UPDATE Sach
        SET SoLuongTon = SoLuongTon + d.SoLuong
        FROM Sach s
        INNER JOIN deleted d ON s.MaSach = d.MaSach;
        
        -- Ghi log
        INSERT INTO TonKho (MaSach, LoaiGiaoDich, SoLuong, NgayGiaoDich, GhiChu)
        SELECT 
            d.MaSach,
            N'Hoàn tr?',
            d.SoLuong, -- D??ng = Nh?p
            GETDATE(),
            N'H?y ??n: ' + d.MaDonHang
        FROM deleted d;
        
        PRINT '?ã hoàn l?i t?n kho (XÓA)';
    END
END
GO

PRINT '? Trigger "trg_ChiTietDonHang_UpdateStock" ?ã ???c t?o';
GO

-- =============================================
-- TRIGGER 2: Ki?m tra t?n kho tr??c khi bán
-- =============================================
IF OBJECT_ID('trg_ChiTietDonHang_CheckStock', 'TR') IS NOT NULL
    DROP TRIGGER trg_ChiTietDonHang_CheckStock;
GO

CREATE TRIGGER trg_ChiTietDonHang_CheckStock
ON ChiTietDonHang
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Ki?m tra t?n kho ?? không
    DECLARE @MaSach NVARCHAR(10), @SoLuongBan INT, @TonKho INT;
    
    DECLARE cur CURSOR FOR 
    SELECT MaSach, SoLuong FROM inserted;
    
    OPEN cur;
    FETCH NEXT FROM cur INTO @MaSach, @SoLuongBan;
    
    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- L?y t?n kho hi?n t?i
        SELECT @TonKho = SoLuongTon FROM Sach WHERE MaSach = @MaSach;
        
        -- Ki?m tra ?? hàng không
        IF @TonKho < @SoLuongBan
        BEGIN
            CLOSE cur;
            DEALLOCATE cur;
            
            DECLARE @ErrorMsg NVARCHAR(500) = 
                N'Không ?? t?n kho! Sách "' + @MaSach + 
                N'" ch? còn ' + CAST(@TonKho AS NVARCHAR(10)) + 
                N' cu?n, không th? bán ' + CAST(@SoLuongBan AS NVARCHAR(10)) + N' cu?n.';
            
            RAISERROR(@ErrorMsg, 16, 1);
            RETURN;
        END
        
        FETCH NEXT FROM cur INTO @MaSach, @SoLuongBan;
    END
    
    CLOSE cur;
    DEALLOCATE cur;
    
    -- N?u ?? hàng ? Cho phép insert
    INSERT INTO ChiTietDonHang (MaDonHang, MaSach, SoLuong, DonGia, ThanhTien)
    SELECT MaDonHang, MaSach, SoLuong, DonGia, ThanhTien
    FROM inserted;
END
GO

PRINT '? Trigger "trg_ChiTietDonHang_CheckStock" ?ã ???c t?o';
GO

-- =============================================
-- STORED PROCEDURE: Nh?p kho
-- =============================================
IF OBJECT_ID('sp_NhapKho', 'P') IS NOT NULL
    DROP PROCEDURE sp_NhapKho;
GO

CREATE PROCEDURE sp_NhapKho
    @MaSach NVARCHAR(10),
    @SoLuong INT,
    @GhiChu NVARCHAR(300) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Ki?m tra sách t?n t?i
    IF NOT EXISTS (SELECT 1 FROM Sach WHERE MaSach = @MaSach)
    BEGIN
        RAISERROR(N'Mã sách không t?n t?i!', 16, 1);
        RETURN;
    END
    
    -- T?ng t?n kho
    UPDATE Sach
    SET SoLuongTon = SoLuongTon + @SoLuong
    WHERE MaSach = @MaSach;
    
    -- Ghi log
    INSERT INTO TonKho (MaSach, LoaiGiaoDich, SoLuong, NgayGiaoDich, GhiChu)
    VALUES (@MaSach, N'Nh?p kho', @SoLuong, GETDATE(), @GhiChu);
    
    -- Tr? v? t?n kho m?i
    SELECT 
        MaSach,
        TenSach,
        SoLuongTon AS TonKhoMoi
    FROM Sach
    WHERE MaSach = @MaSach;
    
    PRINT N'? Nh?p kho thành công!';
END
GO

PRINT '? Stored Procedure "sp_NhapKho" ?ã ???c t?o';
GO

-- =============================================
-- STORED PROCEDURE: Xu?t kho (không qua ??n hàng)
-- =============================================
IF OBJECT_ID('sp_XuatKho', 'P') IS NOT NULL
    DROP PROCEDURE sp_XuatKho;
GO

CREATE PROCEDURE sp_XuatKho
    @MaSach NVARCHAR(10),
    @SoLuong INT,
    @GhiChu NVARCHAR(300) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @TonKho INT;
    
    -- Ki?m tra sách t?n t?i
    IF NOT EXISTS (SELECT 1 FROM Sach WHERE MaSach = @MaSach)
    BEGIN
        RAISERROR(N'Mã sách không t?n t?i!', 16, 1);
        RETURN;
    END
    
    -- Ki?m tra t?n kho
    SELECT @TonKho = SoLuongTon FROM Sach WHERE MaSach = @MaSach;
    
    IF @TonKho < @SoLuong
    BEGIN
        DECLARE @Msg NVARCHAR(200) = 
            N'Không ?? t?n kho! Ch? còn ' + CAST(@TonKho AS NVARCHAR(10)) + N' cu?n.';
        RAISERROR(@Msg, 16, 1);
        RETURN;
    END
    
    -- Gi?m t?n kho
    UPDATE Sach
    SET SoLuongTon = SoLuongTon - @SoLuong
    WHERE MaSach = @MaSach;
    
    -- Ghi log
    INSERT INTO TonKho (MaSach, LoaiGiaoDich, SoLuong, NgayGiaoDich, GhiChu)
    VALUES (@MaSach, N'Xu?t kho', -@SoLuong, GETDATE(), @GhiChu);
    
    -- Tr? v? t?n kho m?i
    SELECT 
        MaSach,
        TenSach,
        SoLuongTon AS TonKhoMoi
    FROM Sach
    WHERE MaSach = @MaSach;
    
    PRINT N'? Xu?t kho thành công!';
END
GO

PRINT '? Stored Procedure "sp_XuatKho" ?ã ???c t?o';
GO

-- =============================================
-- VIEW: L?ch s? t?n kho chi ti?t
-- =============================================
IF OBJECT_ID('vw_LichSuTonKho', 'V') IS NOT NULL
    DROP VIEW vw_LichSuTonKho;
GO

CREATE VIEW vw_LichSuTonKho
AS
SELECT 
    tk.MaGiaoDich,
    tk.MaSach,
    s.TenSach,
    tk.LoaiGiaoDich,
    tk.SoLuong,
    tk.NgayGiaoDich,
    tk.GhiChu,
    s.SoLuongTon AS TonKhoHienTai
FROM TonKho tk
INNER JOIN Sach s ON tk.MaSach = s.MaSach;
GO

PRINT '? View "vw_LichSuTonKho" ?ã ???c t?o';
GO

-- =============================================
-- TEST: Ki?m tra h? th?ng
-- =============================================
PRINT '';
PRINT '========================================';
PRINT 'KI?M TRA H? TH?NG';
PRINT '========================================';

-- Test nh?p kho
PRINT '';
PRINT '1. Test NH?P KHO:';
EXEC sp_NhapKho @MaSach = 'S001', @SoLuong = 100, @GhiChu = N'Nh?p hàng t? NXB';

-- Test xu?t kho
PRINT '';
PRINT '2. Test XU?T KHO:';
EXEC sp_XuatKho @MaSach = 'S001', @SoLuong = 5, @GhiChu = N'Xu?t m?u cho ??i tác';

-- Xem l?ch s?
PRINT '';
PRINT '3. Xem L?CH S? T?N KHO:';
SELECT TOP 10 * FROM vw_LichSuTonKho ORDER BY NgayGiaoDich DESC;

PRINT '';
PRINT '========================================';
PRINT '? H? TH?NG T?N KHO ?Ã S?N SÀNG!';
PRINT '========================================';
GO
