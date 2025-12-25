using System;
using System.Linq;
using System.Windows.Forms;
using QLNhaSach.Models;
using Microsoft.EntityFrameworkCore;

namespace QLNhaSach
{
    public partial class FormKhachHang : Form
    {
        private readonly NguoiDung _currentUser;

        public FormKhachHang(NguoiDung currentUser = null)
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
                btnAdd.Enabled = RolePermissions.CanAddCustomer(_currentUser);

            if (btnEdit != null)
                btnEdit.Enabled = RolePermissions.CanEditCustomer(_currentUser);

            if (btnDelete != null)
                btnDelete.Enabled = RolePermissions.CanDeleteCustomer(_currentUser);

            if (btnExport != null)
                btnExport.Enabled = RolePermissions.CanExportExcel(_currentUser);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!RolePermissions.CanAddCustomer(_currentUser))
            {
                MessageBox.Show("Bạn không có quyền thêm khách hàng!", "Từ chối", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var frm = new FormKhachHangEdit();
            if (frm.ShowDialog() == DialogResult.OK) LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!RolePermissions.CanEditCustomer(_currentUser))
            {
                MessageBox.Show("Bạn không có quyền sửa khách hàng!", "Từ chối", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dataGridView1.CurrentRow == null) return;
            var id = dataGridView1.CurrentRow.Cells["MaKH"].Value?.ToString();
            if (string.IsNullOrEmpty(id)) return;
            using var frm = new FormKhachHangEdit(id);
            if (frm.ShowDialog() == DialogResult.OK) LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!RolePermissions.CanDeleteCustomer(_currentUser))
            {
                MessageBox.Show("Bạn không có quyền xóa khách hàng!", "Từ chối", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dataGridView1.CurrentRow == null) return;
            var id = dataGridView1.CurrentRow.Cells["MaKH"].Value?.ToString();
            if (string.IsNullOrEmpty(id)) return;
            
            if (MessageBox.Show($"Xóa khách hàng {id}?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using var db = new QuanLyNhaSachContext();
                    // check for dependent orders
                    var relatedOrders = db.DonHangs.AsNoTracking().Where(d => d.MaKH == id).ToList();
                    if (relatedOrders.Count > 0)
                    {
                        MessageBox.Show($"Không thể xóa khách hàng {id} vì tồn tại {relatedOrders.Count} đơn hàng tham chiếu. Xoá hoặc chuyển khách hàng trên các đơn hàng trước.", "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        var obj = db.KhachHangs.Find(id);
                        if (obj != null) { db.KhachHangs.Remove(obj); db.SaveChanges(); }
                        LoadData();
                    }
                }
                catch (Exception ex) { MessageBox.Show($"Lỗi khi xóa: {ex.Message}"); }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (!RolePermissions.CanExportExcel(_currentUser))
            {
                MessageBox.Show("Bạn không có quyền xuất Excel!", "Từ chối", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = "KhachHang.xlsx" };
            if (sfd.ShowDialog() != DialogResult.OK) return;
            try
            {
                using var wb = new ClosedXML.Excel.XLWorkbook();
                var ws = wb.Worksheets.Add("KhachHang");
                for (int c = 0; c < dataGridView1.Columns.Count; c++) ws.Cell(1, c + 1).Value = dataGridView1.Columns[c].HeaderText;
                for (int r = 0; r < dataGridView1.Rows.Count; r++) for (int c = 0; c < dataGridView1.Columns.Count; c++) ws.Cell(r + 2, c + 1).SetValue(dataGridView1.Rows[r].Cells[c].Value?.ToString() ?? "");
                wb.SaveAs(sfd.FileName); MessageBox.Show("Xuất Excel thành công.");
            }
            catch (Exception ex) { MessageBox.Show($"Lỗi khi xuất: {ex.Message}"); }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var q = txtSearch.Text?.Trim();
            if (string.IsNullOrEmpty(q)) { LoadData(); return; }
            using var db = new QuanLyNhaSachContext();
            var results = db.KhachHangs.AsNoTracking()
                .Where(k => (k.MaKH ?? "").Contains(q) || (k.TenKH ?? "").Contains(q))
                .Select(k => new 
                { 
                    MaKH = k.MaKH ?? "", 
                    TenKH = k.TenKH ?? "", 
                    DiaChi = k.DiaChi ?? "", 
                    SoDienThoai = k.SoDienThoai ?? "", 
                    Email = k.Email ?? "", 
                    NgayDangKy = k.NgayDangKy 
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
                // Do NOT materialize navigation properties (DonHangs collection)
                var data = db.KhachHangs
                    .AsNoTracking()
                    .Select(k => new
                    {
                        MaKH = k.MaKH ?? "",
                        TenKH = k.TenKH ?? "",
                        DiaChi = k.DiaChi ?? "",
                        SoDienThoai = k.SoDienThoai ?? "",
                        Email = k.Email ?? "",
                        NgayDangKy = k.NgayDangKy
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
