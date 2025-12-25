using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using QLNhaSach.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace QLNhaSach
{
    public partial class FormBaoCao : Form
    {
        private readonly NguoiDung _currentUser;

        public FormBaoCao(NguoiDung user = null)
        {
            InitializeComponent();
            _currentUser = user;
            this.Load += FormBaoCao_Load;
            this.ApplyVietnameseFont();
            UITheme.ApplyTheme(this);
        }

        private void FormBaoCao_Load(object sender, EventArgs e)
        {
            this.Text = "Bao cao va Xuat du lieu";
            LoadComboBoxLoaiBaoCao();
        }

        private void LoadComboBoxLoaiBaoCao()
        {
            cboLoaiBaoCao.Items.Clear();
            cboLoaiBaoCao.Items.Add("Danh sach sach");
            cboLoaiBaoCao.Items.Add("Danh sach khach hang");
            cboLoaiBaoCao.Items.Add("Danh sach don hang");
            cboLoaiBaoCao.Items.Add("Bao cao ton kho");
            cboLoaiBaoCao.Items.Add("Bao cao doanh thu theo thang");
            cboLoaiBaoCao.Items.Add("Bao cao doanh thu theo nam");
            cboLoaiBaoCao.SelectedIndex = 0;
        }

        private void btnTaoBaoCao_Click(object sender, EventArgs e)
        {
            if (cboLoaiBaoCao.SelectedIndex < 0)
            {
                MessageBox.Show("Vui long chon loai bao cao!", "Thong bao", 
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
                        case "Danh sach sach":
                            dataTable = GetDanhSachSach(db);
                            break;
                        case "Danh sach khach hang":
                            dataTable = GetDanhSachKhachHang(db);
                            break;
                        case "Danh sach don hang":
                            dataTable = GetDanhSachDonHang(db);
                            break;
                        case "Bao cao ton kho":
                            dataTable = GetBaoCaoTonKho(db);
                            break;
                        case "Bao cao doanh thu theo thang":
                            dataTable = GetDoanhThuTheoThang(db);
                            break;
                        case "Bao cao doanh thu theo nam":
                            dataTable = GetDoanhThuTheoNam(db);
                            break;
                    }
                }

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    HienThiBaoCao(dataTable, loaiBaoCao);
                }
                else
                {
                    MessageBox.Show("Khong co du lieu de hien thi bao cao!", "Thong bao",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Loi khi tao bao cao: {ex.Message}", "Loi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable GetDanhSachSach(QuanLyNhaSachContext db)
        {
            var data = db.Saches
                .Include(s => s.TheLoai)
                .Include(s => s.NhaXuatBan)
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
                .Include(d => d.KhachHang)
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
                .Include(s => s.TheLoai)
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

        private void HienThiBaoCao(DataTable dataTable, string tenBaoCao)
        {
            try
            {
                reportViewer.LocalReport.ReportPath = "Report1.rdlc";
                reportViewer.LocalReport.DataSources.Clear();

                ReportDataSource rds = new ReportDataSource("DataSet1", dataTable);
                reportViewer.LocalReport.DataSources.Add(rds);

                ReportParameter[] parameters = new ReportParameter[]
                {
                    new ReportParameter("TenBaoCao", tenBaoCao),
                    new ReportParameter("NgayTao", DateTime.Now.ToString("dd/MM/yyyy HH:mm"))
                };
                reportViewer.LocalReport.SetParameters(parameters);

                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Loi khi hien thi bao cao: {ex.Message}", "Loi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            ExportReport("Excel");
        }

        private void btnXuatPDF_Click(object sender, EventArgs e)
        {
            ExportReport("PDF");
        }

        private void btnXuatWord_Click(object sender, EventArgs e)
        {
            ExportReport("Word");
        }

        private void ExportReport(string format)
        {
            try
            {
                string mimeType, encoding, fileNameExtension;
                string deviceInfo = "";
                Warning[] warnings;
                string[] streams;

                string formatType = format == "Excel" ? "EXCELOPENXML" : 
                                    format == "PDF" ? "PDF" : "WORDOPENXML";

                byte[] bytes = reportViewer.LocalReport.Render(
                    formatType,
                    deviceInfo,
                    out mimeType,
                    out encoding,
                    out fileNameExtension,
                    out streams,
                    out warnings);

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = format == "Excel" ? "Excel Files|*.xlsx" :
                                   format == "PDF" ? "PDF Files|*.pdf" : "Word Files|*.docx";
                saveDialog.FileName = $"BaoCao_{DateTime.Now:yyyyMMdd_HHmmss}";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllBytes(saveDialog.FileName, bytes);
                    MessageBox.Show($"Xuat bao cao thanh cong!\nFile: {saveDialog.FileName}",
                        "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (MessageBox.Show("Ban co muon mo file vua xuat?", "Xac nhan",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = saveDialog.FileName,
                            UseShellExecute = true
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Loi khi xuat bao cao: {ex.Message}", "Loi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
