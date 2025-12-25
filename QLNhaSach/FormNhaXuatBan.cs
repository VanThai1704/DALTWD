using System;
using System.Linq;
using System.Windows.Forms;
using QLNhaSach.Models;
using Microsoft.EntityFrameworkCore;

namespace QLNhaSach
{
    public partial class FormNhaXuatBan : Form
    {
        public FormNhaXuatBan()
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
                // Do NOT materialize navigation properties (Saches collection)
                var data = db.NhaXuatBans
                    .AsNoTracking()
                    .Select(n => new
                    {
                        MaNXB = n.MaNXB ?? "",
                        TenNXB = n.TenNXB ?? "",
                        DiaChi = n.DiaChi ?? "",
                        SoDienThoai = n.SoDienThoai ?? "",
                        Email = n.Email ?? ""
                    }).ToList();
                dataGridView1.DataSource = data;
                if (dataGridView1.Columns.Count > 0) { dataGridView1.SetupVietnameseHeaders(); dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; }
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.ToString()); MessageBox.Show($"L?i khi t?i d? li?u:\n{ex}", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var frm = new FormNhaXuatBanEdit(); if (frm.ShowDialog() == DialogResult.OK) LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return; var id = dataGridView1.CurrentRow.Cells["MaNXB"].Value?.ToString(); if (string.IsNullOrEmpty(id)) return; using var frm = new FormNhaXuatBanEdit(id); if (frm.ShowDialog() == DialogResult.OK) LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            var id = dataGridView1.CurrentRow.Cells["MaNXB"].Value?.ToString();
            if (string.IsNullOrEmpty(id)) return;
            if (MessageBox.Show($"Xóa NXB {id}?", "Xác nh?n", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using var db = new QuanLyNhaSachContext();
                    var books = db.Saches.AsNoTracking().Where(s => s.MaNXB == id).Select(s => new { s.MaSach, s.TenSach }).ToList();
                    if (books.Count > 0)
                    {
                        // show simple list dialog
                        var msg = $"NXB {id} ?ang ???c tham chi?u b?i các sách:\n" + string.Join("\n", books.Select(b => $"{b.MaSach} - {b.TenSach}"));
                        MessageBox.Show(msg, "Không th? xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        var obj = db.NhaXuatBans.Find(id);
                        if (obj != null) { db.NhaXuatBans.Remove(obj); db.SaveChanges(); }
                        LoadData();
                    }
                }
                catch (Exception ex) { MessageBox.Show($"L?i khi xóa: {ex.Message}"); }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using var sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = "NhaXuatBan.xlsx" };
            if (sfd.ShowDialog() != DialogResult.OK) return;
            try { using var wb = new ClosedXML.Excel.XLWorkbook(); var ws = wb.Worksheets.Add("NXB"); for (int c = 0; c < dataGridView1.Columns.Count; c++) ws.Cell(1, c + 1).Value = dataGridView1.Columns[c].HeaderText; for (int r = 0; r < dataGridView1.Rows.Count; r++) for (int c = 0; c < dataGridView1.Columns.Count; c++) ws.Cell(r + 2, c + 1).SetValue(dataGridView1.Rows[r].Cells[c].Value?.ToString() ?? ""); wb.SaveAs(sfd.FileName); MessageBox.Show("Xu?t Excel thành công."); } catch (Exception ex) { MessageBox.Show($"L?i khi xu?t: {ex.Message}"); }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var q = txtSearch.Text?.Trim(); 
            if (string.IsNullOrEmpty(q)) { LoadData(); return; }
            using var db = new QuanLyNhaSachContext(); 
            var results = db.NhaXuatBans.AsNoTracking()
                .Where(n => (n.MaNXB ?? "").Contains(q) || (n.TenNXB ?? "").Contains(q))
                .Select(n => new 
                { 
                    MaNXB = n.MaNXB ?? "", 
                    TenNXB = n.TenNXB ?? "", 
                    DiaChi = n.DiaChi ?? "", 
                    SoDienThoai = n.SoDienThoai ?? "", 
                    Email = n.Email ?? "" 
                }).ToList(); 
            dataGridView1.DataSource = results; 
            dataGridView1.SetupVietnameseHeaders();
        }
    }
}
