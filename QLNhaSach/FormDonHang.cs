using System;
using System.Linq;
using System.Windows.Forms;
using QLNhaSach.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace QLNhaSach
{
    public partial class FormDonHang : Form
    {
        private readonly NguoiDung _currentUser;

        public FormDonHang(NguoiDung currentUser = null)
        {
            _currentUser = currentUser;
            InitializeComponent();
            this.ApplyVietnameseFont();
            UITheme.ApplyTheme(this);
            LoadData();
            ApplyPermissions();
        }

        /// <summary>
        /// Áp dụng phân quyền
        /// </summary>
        private void ApplyPermissions()
        {
            if (_currentUser == null) return;

            if (btnAdd != null)
                btnAdd.Enabled = RolePermissions.CanAddOrder(_currentUser);

            if (btnEdit != null)
                btnEdit.Enabled = RolePermissions.CanEditOrder(_currentUser);

            if (btnDelete != null)
                btnDelete.Enabled = RolePermissions.CanDeleteOrder(_currentUser);

            if (btnExport != null)
                btnExport.Enabled = RolePermissions.CanExportExcel(_currentUser);
        }

        private class DonHangRow
        {
            public string MaDonHang { get; set; }
            public string MaKH { get; set; }
            public DateTime NgayDat { get; set; }
            public decimal TongTien { get; set; }
            public string TrangThai { get; set; }
            public string GhiChu { get; set; }
        }

        private void LoadData()
        {
            try
            {
                using var db = new QuanLyNhaSachContext();
                object data;
                try
                {
                    // Project on server to avoid materializing entities that contain NULLs
                    // Do NOT materialize navigation properties (KhachHang, ChiTietDonHangs, HoaDons)
                    data = db.DonHangs
                        .AsNoTracking()
                        .Select(d => new
                        {
                            MaDonHang = d.MaDonHang ?? "",
                            MaKH = d.MaKH ?? "",
                            NgayDat = d.NgayDat,
                            TongTien = d.TongTien.HasValue ? d.TongTien.Value : 0m,
                            TrangThai = d.TrangThai ?? "",
                            GhiChu = d.GhiChu ?? ""
                        })
                        .ToList<object>();
                }
                catch (System.Data.SqlTypes.SqlNullValueException)
                {
                    // Fallback: read with raw ADO.NET and safe DBNull checks
                    var listFallback = new System.Collections.Generic.List<DonHangRow>();
                    var conn = db.Database.GetDbConnection();
                    try
                    {
                        if (conn.State != System.Data.ConnectionState.Open) conn.Open();
                        using var cmd = conn.CreateCommand();
                        cmd.CommandText = "SELECT MaDonHang, MaKH, NgayDat, TongTien, TrangThai, GhiChu FROM DonHang";
                        using var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            var row = new DonHangRow();
                            row.MaDonHang = reader.IsDBNull(0) ? "" : reader.GetString(0);
                            row.MaKH = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            row.NgayDat = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                            row.TongTien = reader.IsDBNull(3) ? 0m : reader.GetDecimal(3);
                            row.TrangThai = reader.IsDBNull(4) ? "" : reader.GetString(4);
                            row.GhiChu = reader.IsDBNull(5) ? "" : reader.GetString(5);
                            listFallback.Add(row);
                        }
                    }
                    finally
                    {
                        try { if (conn.State == System.Data.ConnectionState.Open) conn.Close(); } catch { }
                    }

                    data = listFallback;
                }

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!RolePermissions.CanAddOrder(_currentUser))
            {
                MessageBox.Show("Bạn không có quyền tạo đơn hàng!", "Từ chối", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var frm = new FormDonHangEdit();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!RolePermissions.CanEditOrder(_currentUser))
            {
                MessageBox.Show("Bạn không có quyền sửa đơn hàng!", "Từ chối", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dataGridView1.CurrentRow == null) return;
            var id = dataGridView1.CurrentRow.Cells["MaDonHang"].Value?.ToString();
            if (string.IsNullOrEmpty(id)) return;
            using var frm = new FormDonHangEdit(id);
            if (frm.ShowDialog() == DialogResult.OK) LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!RolePermissions.CanDeleteOrder(_currentUser))
            {
                MessageBox.Show("Bạn không có quyền xóa đơn hàng!", "Từ chối", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dataGridView1.CurrentRow == null) return;
            var id = dataGridView1.CurrentRow.Cells["MaDonHang"].Value?.ToString();
            if (string.IsNullOrEmpty(id)) return;
            if (MessageBox.Show($"Xóa đơn hàng {id}?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using var db = new QuanLyNhaSachContext();
                    // check for dependent chi tiet and hoa don
                    var ctCount = db.ChiTietDonHangs.AsNoTracking().Count(ct => ct.MaDonHang == id);
                    var hdCount = db.HoaDons.AsNoTracking().Count(h => h.MaDonHang == id);
                    if (ctCount > 0 || hdCount > 0)
                    {
                        MessageBox.Show($"Không thể xóa đơn hàng {id} vì tồn tại {ctCount} chi tiết đơn hàng và {hdCount} hóa đơn tham chiếu. Xóa các tham chiếu trước.", "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        var obj = db.DonHangs.Find(id);
                        if (obj != null)
                        {
                            db.DonHangs.Remove(obj);
                            db.SaveChanges();
                        }
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi");
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var q = txtSearch.Text?.Trim();
            if (string.IsNullOrEmpty(q)) { LoadData(); return; }
            try
            {
                using var db = new QuanLyNhaSachContext();
                var results = db.DonHangs
                    .AsNoTracking()
                    .Where(d => (d.MaDonHang ?? "").Contains(q) || (d.MaKH ?? "").Contains(q) || (d.TrangThai ?? "").Contains(q))
                    .Select(d => new
                    {
                        MaDonHang = d.MaDonHang ?? "",
                        MaKH = d.MaKH ?? "",
                        NgayDat = d.NgayDat,
                        TongTien = d.TongTien.HasValue ? d.TongTien.Value : 0m,
                        TrangThai = d.TrangThai ?? "",
                        GhiChu = d.GhiChu ?? ""
                    })
                    .ToList();
                dataGridView1.DataSource = results;
                dataGridView1.SetupVietnameseHeaders();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                MessageBox.Show($"Lỗi khi tìm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using var sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = "DonHang.xlsx" };
            if (sfd.ShowDialog() != DialogResult.OK) return;
            try
            {
                using var wb = new ClosedXML.Excel.XLWorkbook();
                var ws = wb.Worksheets.Add("DonHang");
                // write header
                for (int c = 0; c < dataGridView1.Columns.Count; c++)
                {
                    ws.Cell(1, c + 1).Value = dataGridView1.Columns[c].HeaderText;
                }
                // rows
                for (int r = 0; r < dataGridView1.Rows.Count; r++)
                {
                    for (int c = 0; c < dataGridView1.Columns.Count; c++)
                    {
                        var v = dataGridView1.Rows[r].Cells[c].Value;
                        ws.Cell(r + 2, c + 1).SetValue(v?.ToString() ?? string.Empty);
                    }
                }
                wb.SaveAs(sfd.FileName);
                MessageBox.Show("Xuất Excel thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất Excel: {ex.Message}");
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Basic print: show print dialog and print grid as text
            using var pd = new System.Drawing.Printing.PrintDocument();
            pd.PrintPage += (s, ev) =>
            {
                var font = new System.Drawing.Font("Arial", 10);
                float y = ev.MarginBounds.Top;
                for (int r = 0; r < dataGridView1.Rows.Count; r++)
                {
                    float x = ev.MarginBounds.Left;
                    for (int c = 0; c < dataGridView1.Columns.Count; c++)
                    {
                        var text = dataGridView1.Rows[r].Cells[c].Value?.ToString() ?? "";
                        ev.Graphics.DrawString(text, font, System.Drawing.Brushes.Black, x, y);
                        x += 100;
                    }
                    y += font.Height + 4;
                    if (y > ev.MarginBounds.Bottom) { ev.HasMorePages = true; return; }
                }
                ev.HasMorePages = false;
            };
            using var dlg = new PrintPreviewDialog() { Document = pd };
            dlg.ShowDialog();
        }
    }
}
