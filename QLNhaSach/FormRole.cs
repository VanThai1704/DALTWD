using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QLNhaSach.Models;

namespace QLNhaSach
{
    public partial class FormRole : Form
    {
        public FormRole()
        {
            InitializeComponent();
            this.ApplyVietnameseFont();
            UITheme.ApplyTheme(this);
            StyleMenus();
            LoadData();
        }

        /// <summary>
        /// Style the menus for professional appearance
        /// </summary>
        private void StyleMenus()
        {
            if (menuStrip1 != null)
            {
                menuStrip1.ImageScalingSize = new Size(16, 16);
                menuStrip1.RenderMode = ToolStripRenderMode.Professional;
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
