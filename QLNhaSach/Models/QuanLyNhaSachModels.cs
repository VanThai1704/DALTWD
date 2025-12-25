using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QLNhaSach.Models
{
    public class TheLoai
    {
        public string MaTheLoai { get; set; }
        public string TenTheLoai { get; set; }
        public string MoTa { get; set; }
        public ICollection<Sach> Saches { get; set; }
    }

    public class NhaXuatBan
    {
        public string MaNXB { get; set; }
        public string TenNXB { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public ICollection<Sach> Saches { get; set; }
    }

    public class Sach
    {
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public string MaTheLoai { get; set; }
        public string MaNXB { get; set; }
        public string TacGia { get; set; }
        public int? NamXuatBan { get; set; }
        public decimal GiaBan { get; set; }
        public int SoLuongTon { get; set; }
        public string MoTa { get; set; }
        public TheLoai TheLoai { get; set; }
        public NhaXuatBan NhaXuatBan { get; set; }
        public ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public ICollection<TonKho> TonKhos { get; set; }
    }

    public class KhachHang
    {
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public DateTime NgayDangKy { get; set; }
        public ICollection<DonHang> DonHangs { get; set; }
    }

    public class DonHang
    {
        public string MaDonHang { get; set; }
        public string MaKH { get; set; }
        public DateTime NgayDat { get; set; }
        public decimal? TongTien { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }
        public KhachHang KhachHang { get; set; }
        public ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public ICollection<HoaDon> HoaDons { get; set; }
    }

    public class ChiTietDonHang
    {
        public int MaChiTiet { get; set; }
        public string MaDonHang { get; set; }
        public string MaSach { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
        public DonHang DonHang { get; set; }
        public Sach Sach { get; set; }
    }

    public class HoaDon
    {
        public string MaHoaDon { get; set; }
        public string MaDonHang { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal? TongTien { get; set; }
        public string PhuongThucThanhToan { get; set; }
        public DonHang DonHang { get; set; }
    }

    public class TonKho
    {
        public int MaGiaoDich { get; set; }
        public string MaSach { get; set; }
        public string LoaiGiaoDich { get; set; }
        public int SoLuong { get; set; }
        public DateTime NgayGiaoDich { get; set; }
        public string GhiChu { get; set; }
        public Sach Sach { get; set; }
    }

    public class QuanLyNhaSachContext : DbContext
    {
        public DbSet<TheLoai> TheLoais { get; set; }
        public DbSet<NhaXuatBan> NhaXuatBans { get; set; }
        public DbSet<Sach> Saches { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<TonKho> TonKhos { get; set; }
        public DbSet<NguoiDung> NguoiDungs { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<NguoiDungRole> NguoiDungRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Connection string cho SQL Server LAPTOP-OVMVKSDU
            optionsBuilder.UseSqlServer("Server=LAPTOP-OVMVKSDU;Database=QuanLyNhaSach;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // C?u hình tên b?ng trong database
            modelBuilder.Entity<TheLoai>().ToTable("TheLoai");
            modelBuilder.Entity<NhaXuatBan>().ToTable("NhaXuatBan");
            modelBuilder.Entity<Sach>().ToTable("Sach");
            modelBuilder.Entity<KhachHang>().ToTable("KhachHang");
            modelBuilder.Entity<DonHang>().ToTable("DonHang");
            modelBuilder.Entity<ChiTietDonHang>().ToTable("ChiTietDonHang");
            modelBuilder.Entity<HoaDon>().ToTable("HoaDon");
            modelBuilder.Entity<TonKho>().ToTable("TonKho");

            // C?u hình khóa chính
            modelBuilder.Entity<TheLoai>().HasKey(t => t.MaTheLoai);
            modelBuilder.Entity<NhaXuatBan>().HasKey(n => n.MaNXB);
            modelBuilder.Entity<Sach>().HasKey(s => s.MaSach);
            modelBuilder.Entity<KhachHang>().HasKey(k => k.MaKH);
            modelBuilder.Entity<DonHang>().HasKey(d => d.MaDonHang);
            modelBuilder.Entity<ChiTietDonHang>().HasKey(c => c.MaChiTiet);
            modelBuilder.Entity<HoaDon>().HasKey(h => h.MaHoaDon);
            modelBuilder.Entity<TonKho>().HasKey(t => t.MaGiaoDich);

            // C?u hình ki?u d? li?u cho các c?t text (nvarchar)
            // TheLoai
            modelBuilder.Entity<TheLoai>().Property(t => t.MaTheLoai).HasMaxLength(10).IsRequired();
            modelBuilder.Entity<TheLoai>().Property(t => t.TenTheLoai).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<TheLoai>().Property(t => t.MoTa).HasMaxLength(500);

            // NhaXuatBan
            modelBuilder.Entity<NhaXuatBan>().Property(n => n.MaNXB).HasMaxLength(10).IsRequired();
            modelBuilder.Entity<NhaXuatBan>().Property(n => n.TenNXB).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<NhaXuatBan>().Property(n => n.DiaChi).HasMaxLength(300);
            modelBuilder.Entity<NhaXuatBan>().Property(n => n.SoDienThoai).HasMaxLength(15);
            modelBuilder.Entity<NhaXuatBan>().Property(n => n.Email).HasMaxLength(100);

            // Sach
            modelBuilder.Entity<Sach>().Property(s => s.MaSach).HasMaxLength(10).IsRequired();
            modelBuilder.Entity<Sach>().Property(s => s.TenSach).HasMaxLength(300).IsRequired();
            modelBuilder.Entity<Sach>().Property(s => s.MaTheLoai).HasMaxLength(10);
            modelBuilder.Entity<Sach>().Property(s => s.MaNXB).HasMaxLength(10);
            modelBuilder.Entity<Sach>().Property(s => s.TacGia).HasMaxLength(200);
            modelBuilder.Entity<Sach>().Property(s => s.GiaBan).HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<Sach>().Property(s => s.MoTa).HasMaxLength(1000);

            // KhachHang
            modelBuilder.Entity<KhachHang>().Property(k => k.MaKH).HasMaxLength(10).IsRequired();
            modelBuilder.Entity<KhachHang>().Property(k => k.TenKH).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<KhachHang>().Property(k => k.DiaChi).HasMaxLength(300);
            modelBuilder.Entity<KhachHang>().Property(k => k.SoDienThoai).HasMaxLength(15);
            modelBuilder.Entity<KhachHang>().Property(k => k.Email).HasMaxLength(100);

            // DonHang
            modelBuilder.Entity<DonHang>().Property(d => d.MaDonHang).HasMaxLength(10).IsRequired();
            modelBuilder.Entity<DonHang>().Property(d => d.MaKH).HasMaxLength(10);
            modelBuilder.Entity<DonHang>().Property(d => d.TongTien).HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<DonHang>().Property(d => d.TrangThai).HasMaxLength(50);
            modelBuilder.Entity<DonHang>().Property(d => d.GhiChu).HasMaxLength(500);

            // ChiTietDonHang
            modelBuilder.Entity<ChiTietDonHang>().Property(c => c.MaDonHang).HasMaxLength(10);
            modelBuilder.Entity<ChiTietDonHang>().Property(c => c.MaSach).HasMaxLength(10);
            modelBuilder.Entity<ChiTietDonHang>().Property(c => c.DonGia).HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<ChiTietDonHang>().Property(c => c.ThanhTien).HasColumnType("decimal(18, 2)");

            // HoaDon
            modelBuilder.Entity<HoaDon>().Property(h => h.MaHoaDon).HasMaxLength(10).IsRequired();
            modelBuilder.Entity<HoaDon>().Property(h => h.MaDonHang).HasMaxLength(10);
            modelBuilder.Entity<HoaDon>().Property(h => h.TongTien).HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<HoaDon>().Property(h => h.PhuongThucThanhToan).HasMaxLength(50);

            // TonKho
            modelBuilder.Entity<TonKho>().Property(t => t.MaSach).HasMaxLength(10);
            modelBuilder.Entity<TonKho>().Property(t => t.LoaiGiaoDich).HasMaxLength(20);
            modelBuilder.Entity<TonKho>().Property(t => t.GhiChu).HasMaxLength(300);

            // Role
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Role>().HasKey(r => r.RoleId);
            modelBuilder.Entity<Role>().Property(r => r.RoleName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Role>().Property(r => r.MoTa).HasMaxLength(500);

            // NguoiDung
            modelBuilder.Entity<NguoiDung>().ToTable("NguoiDung");
            modelBuilder.Entity<NguoiDung>().HasKey(n => n.NguoiDungId);
            modelBuilder.Entity<NguoiDung>().Property(n => n.TenDangNhap).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<NguoiDung>().Property(n => n.MatKhauHash).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<NguoiDung>().Property(n => n.PasswordSalt).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<NguoiDung>().Property(n => n.HoTen).HasMaxLength(200);

            // NguoiDungRole
            modelBuilder.Entity<NguoiDungRole>().ToTable("NguoiDungRole");
            modelBuilder.Entity<NguoiDungRole>().HasKey(nr => new { nr.NguoiDungId, nr.RoleId });
            modelBuilder.Entity<NguoiDungRole>().Property(nr => nr.NgayGan).HasDefaultValueSql("GETDATE()");

            // C?u hình quan h?
            modelBuilder.Entity<Sach>()
                .HasOne(s => s.TheLoai)
                .WithMany(t => t.Saches)
                .HasForeignKey(s => s.MaTheLoai)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Sach>()
                .HasOne(s => s.NhaXuatBan)
                .WithMany(n => n.Saches)
                .HasForeignKey(s => s.MaNXB)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DonHang>()
                .HasOne(d => d.KhachHang)
                .WithMany(k => k.DonHangs)
                .HasForeignKey(d => d.MaKH)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ChiTietDonHang>()
                .HasOne(c => c.DonHang)
                .WithMany(d => d.ChiTietDonHangs)
                .HasForeignKey(c => c.MaDonHang)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ChiTietDonHang>()
                .HasOne(c => c.Sach)
                .WithMany(s => s.ChiTietDonHangs)
                .HasForeignKey(c => c.MaSach)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<HoaDon>()
                .HasOne(h => h.DonHang)
                .WithMany(d => d.HoaDons)
                .HasForeignKey(h => h.MaDonHang)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TonKho>()
                .HasOne(t => t.Sach)
                .WithMany(s => s.TonKhos)
                .HasForeignKey(t => t.MaSach)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<NguoiDung>()
                .HasOne(n => n.Role)
                .WithMany(r => r.NguoiDungs)
                .HasForeignKey(n => n.RoleId)
                .OnDelete(DeleteBehavior.NoAction);

            // NguoiDungRole relationships
            modelBuilder.Entity<NguoiDungRole>()
                .HasOne(nr => nr.NguoiDung)
                .WithMany(n => n.NguoiDungRoles)
                .HasForeignKey(nr => nr.NguoiDungId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<NguoiDungRole>()
                .HasOne(nr => nr.Role)
                .WithMany(r => r.NguoiDungRoles)
                .HasForeignKey(nr => nr.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

// User/Role management for admin
public class Role
{
    public int RoleId { get; set; }
    public string RoleName { get; set; }
    public string MoTa { get; set; }
    public System.Collections.Generic.ICollection<NguoiDung> NguoiDungs { get; set; }
    public System.Collections.Generic.ICollection<NguoiDungRole> NguoiDungRoles { get; set; }
}

public class NguoiDung
{
    public int NguoiDungId { get; set; }
    public string TenDangNhap { get; set; }
    public string MatKhauHash { get; set; }
    public string PasswordSalt { get; set; } // Salt ngẫu nhiên cho mỗi user
    public string HoTen { get; set; }
    public int RoleId { get; set; } // Primary role (backward compatibility)
    public Role Role { get; set; }
    public bool KichHoat { get; set; }
    public System.Collections.Generic.ICollection<NguoiDungRole> NguoiDungRoles { get; set; }
}

// Many-to-Many relationship table
public class NguoiDungRole
{
    public int NguoiDungId { get; set; }
    public int RoleId { get; set; }
    public System.DateTime NgayGan { get; set; }
    public NguoiDung NguoiDung { get; set; }
    public Role Role { get; set; }
}
