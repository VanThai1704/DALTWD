using System;
using System.Linq;
using System.Windows.Forms;
using QLNhaSach.Models;
using Microsoft.EntityFrameworkCore;

namespace QLNhaSach
{
    public partial class FormNguoiDung : Form
    {
        public FormNguoiDung()
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
                var data = db.NguoiDungs
                    .Include(n => n.Role)
                    .AsNoTracking()
                    .Select(n => new
                    {
                        NguoiDungId = n.NguoiDungId,
                        TenDangNhap = n.TenDangNhap ?? "",
                        HoTen = n.HoTen ?? "",
                        RoleName = n.Role.RoleName ?? "",
                        KichHoat = n.KichHoat ? "Có" : "Không"
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
                MessageBox.Show($"Lỗi khi tải dữ liệu:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuThem_Click(object sender, EventArgs e)
        {
            using var frm = new FormNguoiDungEdit();
            if (frm.ShowDialog() == DialogResult.OK) LoadData();
        }

        private void menuSua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            var id = dataGridView1.CurrentRow.Cells["NguoiDungId"].Value;
            if (id == null) return;
            using var frm = new FormNguoiDungEdit((int)id);
            if (frm.ShowDialog() == DialogResult.OK) LoadData();
        }

        private void menuXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            var id = dataGridView1.CurrentRow.Cells["NguoiDungId"].Value;
            var tenDangNhap = dataGridView1.CurrentRow.Cells["TenDangNhap"].Value?.ToString();
            if (id == null) return;

            // Không cho xóa tài khoản admin
            if (tenDangNhap == "admin")
            {
                MessageBox.Show("Không thể xóa tài khoản admin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Xóa người dùng {tenDangNhap}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using var db = new QuanLyNhaSachContext();
                    var nguoiDung = db.NguoiDungs.Find((int)id);
                    if (nguoiDung != null)
                    {
                        db.NguoiDungs.Remove(nguoiDung);
                        db.SaveChanges();
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void menuDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
