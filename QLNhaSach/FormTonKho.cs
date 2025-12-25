using System;
using System.Linq;
using System.Windows.Forms;
using QLNhaSach.Models;
using Microsoft.EntityFrameworkCore;

namespace QLNhaSach
{
    public partial class FormTonKho : Form
    {
        public FormTonKho()
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
                // Do NOT materialize navigation properties (Sach)
                var data = db.TonKhos
                    .AsNoTracking()
                    .Select(t => new
                    {
                        MaGiaoDich = t.MaGiaoDich,
                        MaSach = t.MaSach ?? "",
                        LoaiGiaoDich = t.LoaiGiaoDich ?? "",
                        SoLuong = t.SoLuong,
                        NgayGiaoDich = t.NgayGiaoDich,
                        GhiChu = t.GhiChu ?? ""
                    })
                    .OrderByDescending(t => t.NgayGiaoDich)
                    .ToList();

                dataGridView1.DataSource = data;

                if (dataGridView1.Columns.Count > 0)
                {
                    // Apply standardized Vietnamese headers and formatting
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
