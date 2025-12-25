-- Script thêm d? li?u m?u cho database QuanLyNhaSach

USE QuanLyNhaSach;
GO

-- Xóa d? li?u c? (n?u có)
DELETE FROM TonKho;
DELETE FROM ChiTietDonHang;
DELETE FROM HoaDon;
DELETE FROM DonHang;
DELETE FROM KhachHang;
DELETE FROM Sach;
DELETE FROM TheLoai;
DELETE FROM NhaXuatBan;
GO

-- Thêm th? lo?i sách
INSERT INTO TheLoai (MaTheLoai, TenTheLoai, MoTa) VALUES
('TL01', N'V?n h?c', N'Sách v?n h?c trong và ngoài n??c'),
('TL02', N'Khoa h?c', N'Sách khoa h?c công ngh?'),
('TL03', N'Kinh t?', N'Sách v? kinh t? và qu?n lý'),
('TL04', N'K? n?ng s?ng', N'Sách phát tri?n b?n thân'),
('TL05', N'Thi?u nhi', N'Sách dành cho tr? em');
GO

-- Thêm nhà xu?t b?n
INSERT INTO NhaXuatBan (MaNXB, TenNXB, DiaChi, SoDienThoai, Email) VALUES
('NXB01', N'NXB Tr?', N'161B Lý Chính Th?ng, Q.3, TP.HCM', '02839316289', 'nxbtre@nxbtre.com.vn'),
('NXB02', N'NXB Kim ??ng', N'55 Quang Trung, Hai Bà Tr?ng, Hà N?i', '02439434730', 'info@nxbkimdong.com.vn'),
('NXB03', N'NXB V?n h?c', N'18 Nguy?n Tr??ng T?, Ba ?ình, Hà N?i', '02438222718', 'nxbvanhoc@hn.vnn.vn'),
('NXB04', N'NXB Lao ??ng', N'175 Gi?ng Võ, ??ng ?a, Hà N?i', '02438514821', 'nxblaodong@hn.vnn.vn'),
('NXB05', N'NXB T?ng h?p TP.HCM', N'62 Nguy?n Th? Minh Khai, Q.1, TP.HCM', '02838222922', 'info@nxbtonghop.com.vn');
GO

-- Thêm sách
INSERT INTO Sach (MaSach, TenSach, MaTheLoai, MaNXB, TacGia, NamXuatBan, GiaBan, SoLuongTon, MoTa) VALUES
('S001', N'??c nhân tâm', 'TL04', 'NXB01', N'Dale Carnegie', 2020, 86000, 150, N'Cu?n sách kinh ?i?n v? ngh? thu?t giao ti?p và ?ng x?'),
('S002', N'Sapiens: L??c s? loài ng??i', 'TL02', 'NXB02', N'Yuval Noah Harari', 2019, 189000, 80, N'Khám phá l?ch s? ti?n hóa c?a loài ng??i'),
('S003', N'T? duy nhanh và ch?m', 'TL04', 'NXB03', N'Daniel Kahneman', 2021, 179000, 95, N'Sách v? tâm lý h?c và quá trình ra quy?t ??nh'),
('S004', N'Nhà gi? kim', 'TL01', 'NXB01', N'Paulo Coelho', 2018, 79000, 120, N'Câu chuy?n v? hành trình tìm ki?m kho báu'),
('S005', N'Tu?i tr? ?áng giá bao nhiêu', 'TL04', 'NXB04', N'Rosie Nguy?n', 2019, 89000, 200, N'Sách v? ??nh h??ng cu?c s?ng cho gi?i tr?'),
('S006', N'Doraemon - T?p 1', 'TL05', 'NXB02', N'Fujiko F Fujio', 2020, 18000, 300, N'Truy?n tranh thi?u nhi n?i ti?ng'),
('S007', N'Kinh t? h?c vi mô', 'TL03', 'NXB05', N'Gregory Mankiw', 2021, 150000, 60, N'Giáo trình kinh t? h?c c? b?n'),
('S008', N'Cà phê cùng Tony', 'TL04', 'NXB01', N'Tony Bu?i Sáng', 2018, 75000, 110, N'Chia s? v? cu?c s?ng và kinh doanh'),
('S009', N'Sherlock Holmes - B? s?u t?p', 'TL01', 'NXB03', N'Arthur Conan Doyle', 2020, 299000, 50, N'Truy?n trinh thám kinh ?i?n'),
('S010', N'7 thói quen c?a ng??i thành ??t', 'TL04', 'NXB04', N'Stephen Covey', 2019, 99000, 85, N'Phát tri?n k? n?ng lãnh ??o và qu?n lý');
GO

-- Thêm khách hàng
INSERT INTO KhachHang (MaKH, TenKH, DiaChi, SoDienThoai, Email, NgayDangKy) VALUES
('KH001', N'Nguy?n V?n An', N'123 Lê L?i, Q.1, TP.HCM', '0901234567', 'nguyenvanan@gmail.com', '2023-01-15'),
('KH002', N'Tr?n Th? Bích', N'456 Hai Bà Tr?ng, Q.3, TP.HCM', '0912345678', 'tranthib@gmail.com', '2023-02-20'),
('KH003', N'Lê Hoàng C??ng', N'789 Nguy?n Hu?, Q.1, TP.HCM', '0923456789', 'lehoangc@gmail.com', '2023-03-10'),
('KH004', N'Ph?m Thu Dung', N'321 Võ V?n T?n, Q.3, TP.HCM', '0934567890', 'phamthud@gmail.com', '2023-04-05'),
('KH005', N'Hoàng Minh D?ng', N'654 Lý Th??ng Ki?t, Q.10, TP.HCM', '0945678901', 'hoangminhd@gmail.com', '2023-05-12');
GO

-- Thêm ??n hàng
INSERT INTO DonHang (MaDonHang, MaKH, NgayDat, TongTien, TrangThai, GhiChu) VALUES
('DH001', 'KH001', '2024-01-10', 354000, N'?ã giao', N'Giao hàng nhanh'),
('DH002', 'KH002', '2024-01-15', 268000, N'?ã giao', NULL),
('DH003', 'KH003', '2024-02-01', 528000, N'?ang x? lý', N'G?i tr??c khi giao'),
('DH004', 'KH004', '2024-02-10', 164000, N'?ã giao', NULL),
('DH005', 'KH005', '2024-02-20', 398000, N'?ang x? lý', NULL);
GO

-- Thêm chi ti?t ??n hàng
INSERT INTO ChiTietDonHang (MaDonHang, MaSach, SoLuong, DonGia, ThanhTien) VALUES
('DH001', 'S001', 2, 86000, 172000),
('DH001', 'S004', 1, 79000, 79000),
('DH001', 'S008', 1, 75000, 75000),
('DH002', 'S002', 1, 189000, 189000),
('DH002', 'S003', 1, 179000, 179000),
('DH003', 'S007', 2, 150000, 300000),
('DH003', 'S009', 1, 299000, 299000),
('DH004', 'S005', 1, 89000, 89000),
('DH004', 'S008', 1, 75000, 75000),
('DH005', 'S010', 2, 99000, 198000);
GO

-- Thêm hóa ??n
INSERT INTO HoaDon (MaHoaDon, MaDonHang, NgayLap, TongTien, PhuongThucThanhToan) VALUES
('HD001', 'DH001', '2024-01-10', 354000, N'Ti?n m?t'),
('HD002', 'DH002', '2024-01-15', 268000, N'Chuy?n kho?n'),
('HD004', 'DH004', '2024-02-10', 164000, N'Ti?n m?t');
GO

-- Thêm l?ch s? t?n kho
INSERT INTO TonKho (MaSach, LoaiGiaoDich, SoLuong, NgayGiaoDich, GhiChu) VALUES
('S001', N'Nh?p', 200, '2023-12-01', N'Nh?p hàng ??u tháng'),
('S002', N'Nh?p', 100, '2023-12-01', N'Nh?p hàng ??u tháng'),
('S001', N'Xu?t', 2, '2024-01-10', N'Bán cho KH001'),
('S004', N'Xu?t', 1, '2024-01-10', N'Bán cho KH001'),
('S002', N'Xu?t', 1, '2024-01-15', N'Bán cho KH002'),
('S003', N'Nh?p', 100, '2024-01-20', N'Nh?p b? sung'),
('S007', N'Xu?t', 2, '2024-02-01', N'Bán cho KH003');
GO

PRINT N'?ã thêm d? li?u m?u thành công!';
GO
