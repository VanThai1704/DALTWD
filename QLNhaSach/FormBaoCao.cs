using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QLNhaSach.Models;
using System.Linq;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using Word = DocumentFormat.OpenXml.Wordprocessing;

namespace QLNhaSach
{
    public partial class FormBaoCao : Form
    {
        private readonly NguoiDung _currentUser;

        public FormBaoCao(NguoiDung user)
        {
            InitializeComponent();
            _currentUser = user;
            this.Load += FormBaoCao_Load;
            this.ApplyVietnameseFont();
            UITheme.ApplyTheme(this);
        }

        private void FormBaoCao_Load(object sender, EventArgs e)
        {
            this.Text = "Báo cáo và Xuất dữ liệu";
            LoadComboBoxLoaiBaoCao();
        }
        
        private void LoadComboBoxLoaiBaoCao()
        {
            cboLoaiBaoCao.Items.Clear();
            cboLoaiBaoCao.Items.Add("Danh sách sách");
            cboLoaiBaoCao.Items.Add("Danh sách khách hàng");
            cboLoaiBaoCao.Items.Add("Danh sách đơn hàng");
            cboLoaiBaoCao.Items.Add("Báo cáo tồn kho");
            cboLoaiBaoCao.Items.Add("Báo cáo doanh thu theo tháng");
            cboLoaiBaoCao.Items.Add("Báo cáo doanh thu theo năm");
            cboLoaiBaoCao.SelectedIndex = 0;
        }

        private void btnTaoBaoCao_Click(object sender, EventArgs e)
        {
            if (cboLoaiBaoCao.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn loại báo cáo!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string loaiBaoCao = cboLoaiBaoCao.SelectedItem.ToString();
                DataTable dataTable = null;

                using (var db = new QuanLyNhaSachContext())
                {
                    switch (loaiBaoCao)
                    {
                        case "Danh sách sách":
                            dataTable = GetDanhSachSach(db);
                            break;
                        case "Danh sách khách hàng":
                            dataTable = GetDanhSachKhachHang(db);
                            break;
                        case "Danh sách đơn hàng":
                            dataTable = GetDanhSachDonHang(db);
                            break;
                        case "Báo cáo tồn kho":
                            dataTable = GetBaoCaoTonKho(db);
                            break;
                        case "Báo cáo doanh thu theo tháng":
                            dataTable = GetDoanhThuTheoThang(db);
                            break;
                        case "Báo cáo doanh thu theo năm":
                            dataTable = GetDoanhThuTheoNam(db);
                            break;
                    }
                }

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    // Hien thi bang ReportViewer thay vi DataGridView
                    ReportHelper.CreateSimpleReport(reportViewer, dataTable, loaiBaoCao);
                    reportViewer.BringToFront();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị báo cáo!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo báo cáo: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable GetDanhSachSach(QuanLyNhaSachContext db)
        {
            var data = db.Saches
                .Include("TheLoai")
                .Include("NhaXuatBan")
                .Select(s => new
                {
                    s.MaSach,
                    s.TenSach,
                    TacGia = s.TacGia ?? "",
                    TheLoai = s.TheLoai != null ? s.TheLoai.TenTheLoai : "",
                    NhaXuatBan = s.NhaXuatBan != null ? s.NhaXuatBan.TenNXB : "",
                    s.NamXuatBan,
                    s.GiaBan,
                    s.SoLuongTon
                })
                .ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("MaSach", typeof(string));
            dt.Columns.Add("TenSach", typeof(string));
            dt.Columns.Add("TacGia", typeof(string));
            dt.Columns.Add("TheLoai", typeof(string));
            dt.Columns.Add("NhaXuatBan", typeof(string));
            dt.Columns.Add("NamXuatBan", typeof(int));
            dt.Columns.Add("GiaBan", typeof(decimal));
            dt.Columns.Add("SoLuongTon", typeof(int));

            foreach (var item in data)
            {
                dt.Rows.Add(item.MaSach, item.TenSach, item.TacGia, item.TheLoai,
                    item.NhaXuatBan, item.NamXuatBan ?? 0, item.GiaBan, item.SoLuongTon);
            }

            return dt;
        }

        private DataTable GetDanhSachKhachHang(QuanLyNhaSachContext db)
        {
            var data = db.KhachHangs
                .Select(k => new
                {
                    k.MaKH,
                    k.TenKH,
                    k.DiaChi,
                    k.SoDienThoai,
                    k.Email,
                    k.NgayDangKy
                })
                .ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("MaKH", typeof(string));
            dt.Columns.Add("TenKH", typeof(string));
            dt.Columns.Add("DiaChi", typeof(string));
            dt.Columns.Add("SoDienThoai", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("NgayDangKy", typeof(DateTime));

            foreach (var item in data)
            {
                dt.Rows.Add(item.MaKH, item.TenKH, item.DiaChi ?? "",
                    item.SoDienThoai ?? "", item.Email ?? "", item.NgayDangKy);
            }

            return dt;
        }

        private DataTable GetDanhSachDonHang(QuanLyNhaSachContext db)
        {
            var data = db.DonHangs
                .Include("KhachHang")
                .Select(d => new
                {
                    d.MaDonHang,
                    TenKH = d.KhachHang != null ? d.KhachHang.TenKH : "",
                    d.NgayDat,
                    d.TongTien,
                    d.TrangThai
                })
                .ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("MaDonHang", typeof(string));
            dt.Columns.Add("TenKH", typeof(string));
            dt.Columns.Add("NgayDat", typeof(DateTime));
            dt.Columns.Add("TongTien", typeof(decimal));
            dt.Columns.Add("TrangThai", typeof(string));

            foreach (var item in data)
            {
                dt.Rows.Add(item.MaDonHang, item.TenKH, item.NgayDat,
                    item.TongTien ?? 0, item.TrangThai ?? "");
            }

            return dt;
        }

        private DataTable GetBaoCaoTonKho(QuanLyNhaSachContext db)
        {
            var data = db.Saches
                .Include("TheLoai")
                .Select(s => new
                {
                    s.MaSach,
                    s.TenSach,
                    TheLoai = s.TheLoai != null ? s.TheLoai.TenTheLoai : "",
                    s.GiaBan,
                    s.SoLuongTon,
                    GiaTriTonKho = s.GiaBan * s.SoLuongTon
                })
                .OrderBy(s => s.SoLuongTon)
                .ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("MaSach", typeof(string));
            dt.Columns.Add("TenSach", typeof(string));
            dt.Columns.Add("TheLoai", typeof(string));
            dt.Columns.Add("GiaBan", typeof(decimal));
            dt.Columns.Add("SoLuongTon", typeof(int));
            dt.Columns.Add("GiaTriTonKho", typeof(decimal));

            foreach (var item in data)
            {
                dt.Rows.Add(item.MaSach, item.TenSach, item.TheLoai,
                    item.GiaBan, item.SoLuongTon, item.GiaTriTonKho);
            }

            return dt;
        }

        private DataTable GetDoanhThuTheoThang(QuanLyNhaSachContext db)
        {
            int nam = dtpNam.Value.Year;
            var data = db.DonHangs
                .Where(d => d.NgayDat.Year == nam && d.TrangThai == "Hoan thanh")
                .GroupBy(d => d.NgayDat.Month)
                .Select(g => new
                {
                    Thang = g.Key,
                    TongDoanhThu = g.Sum(d => d.TongTien ?? 0),
                    SoDonHang = g.Count()
                })
                .OrderBy(x => x.Thang)
                .ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("Thang", typeof(int));
            dt.Columns.Add("Nam", typeof(int));
            dt.Columns.Add("TongDoanhThu", typeof(decimal));
            dt.Columns.Add("SoDonHang", typeof(int));

            foreach (var item in data)
            {
                dt.Rows.Add(item.Thang, nam, item.TongDoanhThu, item.SoDonHang);
            }

            return dt;
        }

        private DataTable GetDoanhThuTheoNam(QuanLyNhaSachContext db)
        {
            var data = db.DonHangs
                .Where(d => d.TrangThai == "Hoan thanh")
                .GroupBy(d => d.NgayDat.Year)
                .Select(g => new
                {
                    Nam = g.Key,
                    TongDoanhThu = g.Sum(d => d.TongTien ?? 0),
                    SoDonHang = g.Count()
                })
                .OrderBy(x => x.Nam)
                .ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("Nam", typeof(int));
            dt.Columns.Add("TongDoanhThu", typeof(decimal));
            dt.Columns.Add("SoDonHang", typeof(int));

            foreach (var item in data)
            {
                dt.Rows.Add(item.Nam, item.TongDoanhThu, item.SoDonHang);
            }

            return dt;
        }
        
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            ReportHelper.ExportToExcel(reportViewer, "BaoCao_" + cboLoaiBaoCao.Text.Replace(" ", "_"));
        }

        private void btnXuatPDF_Click(object sender, EventArgs e)
        {
            ReportHelper.ExportToPDF(reportViewer, "BaoCao_" + cboLoaiBaoCao.Text.Replace(" ", "_"));
        }

        private void btnXuatWord_Click(object sender, EventArgs e)
        {
            ReportHelper.ExportToWord(reportViewer, "BaoCao_" + cboLoaiBaoCao.Text.Replace(" ", "_"));
        }
        
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
