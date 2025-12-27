using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QLNhaSach.Models;

namespace QLNhaSach
{
    public partial class FormSach : Form
    {
        private readonly NguoiDung _currentUser;

        public FormSach(NguoiDung currentUser = null)
        {
            _currentUser = currentUser;
            InitializeComponent();
            this.ApplyVietnameseFont();
            UITheme.ApplyTheme(this);
            StyleToolbar();
            LoadData();
            ApplyPermissions();
        }

        /// <summary>
        /// Style the toolbar for professional appearance
        /// </summary>
        private void StyleToolbar()
        {
            if (toolStrip1 != null)
            {
                toolStrip1.ImageScalingSize = new Size(16, 16);
                toolStrip1.RenderMode = ToolStripRenderMode.Professional;
            }
        }

        /// <summary>
        /// Create a simple colored icon
        /// </summary>
        private static Image CreateColorIcon(Color color, int width, int height)
        {
            var bitmap = new Bitmap(width, height);
            using (var g = Graphics.FromImage(bitmap))
            {
                using (var brush = new SolidBrush(color))
                {
                    g.FillEllipse(brush, 2, 2, width - 4, height - 4);
                }
                using (var pen = new Pen(Color.DarkGray))
                {
                    g.DrawEllipse(pen, 2, 2, width - 4, height - 4);
                }
            }
            return bitmap;
        }

        /// <summary>
        /// Áp dụng phân quyền - Ẩn/hiện buttons theo role
        /// </summary>
        private void ApplyPermissions()
        {
            if (_currentUser == null) return;

            // Quyền THÊM
            if (btnAdd != null)
                btnAdd.Enabled = RolePermissions.CanAddBook(_currentUser);

            // Quyền SỬA
            if (btnEdit != null)
                btnEdit.Enabled = RolePermissions.CanEditBook(_currentUser);

            // Quyền XÓA
            if (btnDelete != null)
                btnDelete.Enabled = RolePermissions.CanDeleteBook(_currentUser);

            // Quyền XUẤT EXCEL
            if (btnExport != null)
                btnExport.Enabled = RolePermissions.CanExportExcel(_currentUser);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Double-check permission
            if (!RolePermissions.CanAddBook(_currentUser))
            {
                MessageBox.Show("Bạn không có quyền thêm sách!", "Từ chối", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var frm = new FormSachEdit(); 
            if (frm.ShowDialog() == DialogResult.OK) LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Double-check permission
            if (!RolePermissions.CanEditBook(_currentUser))
            {
                MessageBox.Show("Bạn không có quyền sửa sách!", "Từ chối", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dataGridView1.CurrentRow == null) return; 
            var id = dataGridView1.CurrentRow.Cells["MaSach"].Value?.ToString(); 
            if (string.IsNullOrEmpty(id)) return; 
            using var frm = new FormSachEdit(id); 
            if (frm.ShowDialog() == DialogResult.OK) LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Double-check permission
            if (!RolePermissions.CanDeleteBook(_currentUser))
            {
                MessageBox.Show("Bạn không có quyền xóa sách!", "Từ chối", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dataGridView1.CurrentRow == null) return;
            var id = dataGridView1.CurrentRow.Cells["MaSach"].Value?.ToString();
            if (string.IsNullOrEmpty(id)) return;
            
            if (MessageBox.Show($"Xóa sách {id}?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using var db = new QuanLyNhaSachContext();
                    // check dependent records: ChiTietDonHang, TonKho
                    var ctCount = db.ChiTietDonHangs.AsNoTracking().Count(ct => ct.MaSach == id);
                    var tkCount = db.TonKhos.AsNoTracking().Count(t => t.MaSach == id);
                    if (ctCount > 0 || tkCount > 0)
                    {
                        MessageBox.Show($"Không thể xóa sách {id} vì tồn tại {ctCount} chi tiết đơn hàng và {tkCount} bản ghi tồn kho tham chiếu. Xóa các tham chiếu trước.", "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        var obj = db.Saches.Find(id);
                        if (obj != null) { db.Saches.Remove(obj); db.SaveChanges(); }
                        LoadData();
                    }
                }
                catch (Exception ex) { MessageBox.Show($"Lỗi khi xóa: {ex.Message}"); }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // Double-check permission
            if (!RolePermissions.CanExportExcel(_currentUser))
            {
                MessageBox.Show("Bạn không có quyền xuất Excel!", "Từ chối", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = "Sach.xlsx" };
            if (sfd.ShowDialog() != DialogResult.OK) return;
            try { using var wb = new ClosedXML.Excel.XLWorkbook(); var ws = wb.Worksheets.Add("Sach"); for (int c = 0; c < dataGridView1.Columns.Count; c++) ws.Cell(1, c + 1).Value = dataGridView1.Columns[c].HeaderText; for (int r = 0; r < dataGridView1.Rows.Count; r++) for (int c = 0; c < dataGridView1.Columns.Count; c++) ws.Cell(r + 2, c + 1).SetValue(dataGridView1.Rows[r].Cells[c].Value?.ToString() ?? ""); wb.SaveAs(sfd.FileName); MessageBox.Show("Xuất Excel thành công."); }
            catch (Exception ex) { MessageBox.Show($"Lỗi khi xuất: {ex.Message}"); }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var q = txtSearch.Text?.Trim(); if (string.IsNullOrEmpty(q)) { LoadData(); return; }
            using var db = new QuanLyNhaSachContext(); 
            var results = db.Saches.AsNoTracking()
                .Where(s => (s.MaSach ?? "").Contains(q) || (s.TenSach ?? "").Contains(q))
                .Select(s => new 
                { 
                    MaSach = s.MaSach ?? "", 
                    TenSach = s.TenSach ?? "", 
                    TacGia = s.TacGia ?? "", 
                    NamXuatBan = s.NamXuatBan.HasValue ? s.NamXuatBan.Value : 0, 
                    GiaBan = s.GiaBan, 
                    SoLuongTon = s.SoLuongTon, 
                    MaTheLoai = s.MaTheLoai ?? "", 
                    MaNXB = s.MaNXB ?? "" 
                }).ToList(); 
            dataGridView1.DataSource = results; 
            dataGridView1.SetupVietnameseHeaders();
        }

        private void LoadData()
        {
            try
            {
                using var db = new QuanLyNhaSachContext();
                // Use AsNoTracking and server-side projection to avoid SqlNullValueException
                // Do NOT materialize navigation properties (TheLoai, NhaXuatBan)
                var data = db.Saches
                    .AsNoTracking()
                    .Select(s => new
                    {
                        MaSach = s.MaSach ?? "",
                        TenSach = s.TenSach ?? "",
                        TacGia = s.TacGia ?? "",
                        NamXuatBan = s.NamXuatBan.HasValue ? s.NamXuatBan.Value : 0,
                        GiaBan = s.GiaBan,
                        SoLuongTon = s.SoLuongTon,
                        MaTheLoai = s.MaTheLoai ?? "",
                        MaNXB = s.MaNXB ?? ""
                    }).ToList();

                dataGridView1.DataSource = data;

                if (dataGridView1.Columns.Count > 0)
                {
                    dataGridView1.SetupVietnameseHeaders();

                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.Columns["MaSach"].FillWeight = 60;
                    dataGridView1.Columns["TenSach"].FillWeight = 150;
                    dataGridView1.Columns["TacGia"].FillWeight = 100;
                    dataGridView1.Columns["NamXuatBan"].FillWeight = 70;
                    dataGridView1.Columns["GiaBan"].FillWeight = 80;
                    dataGridView1.Columns["SoLuongTon"].FillWeight = 70;
                    dataGridView1.Columns["MaTheLoai"].FillWeight = 70;
                    dataGridView1.Columns["MaNXB"].FillWeight = 70;
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
