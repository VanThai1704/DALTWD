using System;
using System.Linq;
using System.Windows.Forms;
using QLNhaSach.Models;
using Microsoft.EntityFrameworkCore;

namespace QLNhaSach
{
    public partial class FormThongKe : Form
    {
        public FormThongKe()
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
                // Project only the needed fields to avoid materializing entire entities (prevents SqlNullValueException
                // when the provider reads NULL into an unexpected CLR type).
                // Do NOT materialize navigation properties (DonHang, Sach) - use explicit field access only
                var list = db.ChiTietDonHangs
                    .AsNoTracking()
                    .Where(ct => ct.DonHang != null && ct.DonHang.NgayDat != null)
                    .Select(ct => new
                    {
                        ct.MaDonHang,
                        ThanhTien = ct.ThanhTien,
                        NgayDat = ct.DonHang.NgayDat
                    })
                    .ToList();

                // Group by year (already filtered out NULL NgayDat in the query above)
                var data = list
                    .GroupBy(ct => ct.NgayDat.Year)
                    .Select(g => new
                    {
                        Nam = g.Key,
                        TongDoanhThu = g.Sum(x => x.ThanhTien)
                    })
                    .OrderBy(x => x.Nam)
                    .ToList();

                dataGridView1.DataSource = data;

                // Debug info
                System.Diagnostics.Debug.WriteLine($"FormThongKe: loaded {list.Count} ChiTietDonHang rows, aggregated {data.Count} years.");
                if (data.Count == 0)
                {
                    MessageBox.Show($"Không có dữ liệu thống kê. Kiểm tra dữ liệu gốc hoặc ngày đặt của đơn hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

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
