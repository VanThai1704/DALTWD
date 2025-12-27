using System;
using System.Linq;
using System.Windows.Forms;
using QLNhaSach.Models;

namespace QLNhaSach
{
    public partial class FormHoaDon : Form
    {
        public FormHoaDon()
        {
            InitializeComponent();
            this.ApplyVietnameseFont();
            UITheme.ApplyTheme(this);
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using var db = new QuanLyNhaSachContext();
                // Use AsNoTracking and server-side projection to avoid SqlNullValueException
                // Do NOT materialize navigation properties (DonHang)
                var data = db.HoaDons
                    .AsNoTracking()
                    .Select(h => new
                    {
                        MaHoaDon = h.MaHoaDon ?? "",
                        MaDonHang = h.MaDonHang ?? "",
                        NgayLap = h.NgayLap,
                        TongTien = h.TongTien.HasValue ? h.TongTien.Value : 0m,
                        PhuongThucThanhToan = h.PhuongThucThanhToan ?? ""
                    }).ToList();

                dataGridView1.DataSource = data;

                if (dataGridView1.Columns.Count > 0)
                {
                    dataGridView1.SetupVietnameseHeaders();
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                MessageBox.Show($"Lỗi khi tải dữ liệu:\n{ex}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
