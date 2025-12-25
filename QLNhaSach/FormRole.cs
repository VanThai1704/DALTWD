using System;
using System.Linq;
using System.Windows.Forms;
using QLNhaSach.Models;
using Microsoft.EntityFrameworkCore;

namespace QLNhaSach
{
    public partial class FormRole : Form
    {
        public FormRole()
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
                var data = db.Roles
                    .AsNoTracking()
                    .Select(r => new
                    {
                        r.RoleId,
                        r.RoleName,
                        r.MoTa,
                        SoLuongNguoiDung = r.NguoiDungRoles.Count()
                    })
                    .OrderBy(r => r.RoleId)
                    .ToList();

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
                MessageBox.Show($"L?i khi t?i d? li?u:\n{ex.Message}", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuThem_Click(object sender, EventArgs e)
        {
            using var frm = new FormRoleEdit();
            if (frm.ShowDialog() == DialogResult.OK) LoadData();
        }

        private void menuSua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            var id = dataGridView1.CurrentRow.Cells["RoleId"].Value;
            if (id == null) return;
            using var frm = new FormRoleEdit((int)id);
            if (frm.ShowDialog() == DialogResult.OK) LoadData();
        }

        private void menuXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            var id = dataGridView1.CurrentRow.Cells["RoleId"].Value;
            var roleName = dataGridView1.CurrentRow.Cells["RoleName"].Value?.ToString();
            if (id == null) return;

            // Không cho xóa roles h? th?ng (Admin, Nhân viên, Qu?n lý)
            int roleId = (int)id;
            if (roleId <= 3)
            {
                MessageBox.Show($"Không th? xóa role h? th?ng '{roleName}'!", "C?nh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Xóa role '{roleName}'?\n\nL?u ý: T?t c? ng??i dùng có role này s? b? xóa kh?i role.", "Xác nh?n", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using var db = new QuanLyNhaSachContext();
                    var role = db.Roles.Find(roleId);
                    if (role != null)
                    {
                        db.Roles.Remove(role);
                        db.SaveChanges();
                        LoadData();
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"L?i khi xóa: {ex.Message}", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void menuDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
