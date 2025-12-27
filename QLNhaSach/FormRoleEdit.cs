using System;
using System.Linq;
using System.Windows.Forms;
using QLNhaSach.Models;

namespace QLNhaSach
{
    public partial class FormRoleEdit : Form
    {
        private int? _id;

        public FormRoleEdit() : this(null) { }

        public FormRoleEdit(int? id)
        {
            _id = id;
            InitializeComponent();
            this.ApplyVietnameseFont();
            UITheme.ApplyTheme(this);

            if (_id.HasValue)
            {
                LoadData();
                // Không cho sửa roles hệ thống
                if (_id.Value <= 3)
                {
                    txtRoleName.Enabled = false;
                    MessageBox.Show("Đây là role hệ thống chỉ có thể sửa mô tả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            this.btnOK.Click += BtnOK_Click;
        }

        private void LoadData()
        {
            try
            {
                using var db = new QuanLyNhaSachContext();
                var role = db.Roles.Find(_id.Value);
                if (role == null) return;

                txtRoleName.Text = role.RoleName;
                txtMoTa.Text = role.MoTa;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải role: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRoleName.Text))
            {
                MessageBox.Show("Tên vai trò không được để trống", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            try
            {
                using var db = new QuanLyNhaSachContext();

                if (!_id.HasValue)
                {
                    // Kiểm tra trùng tên role
                    if (db.Roles.Any(r => r.RoleName == txtRoleName.Text.Trim()))
                    {
                        MessageBox.Show("Tên vai trò đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.DialogResult = DialogResult.None;
                        return;
                    }

                    var role = new Role
                    {
                        RoleName = txtRoleName.Text.Trim(),
                        MoTa = txtMoTa.Text.Trim()
                    };
                    db.Roles.Add(role);
                }
                else
                {
                    var role = db.Roles.Find(_id.Value);
                    if (role != null)
                    {
                        // Chỉ cho phép sửa RoleName nếu không phải role hệ thống
                        if (_id.Value > 3)
                        {
                            role.RoleName = txtRoleName.Text.Trim();
                        }
                        role.MoTa = txtMoTa.Text.Trim();
                    }
                }

                db.SaveChanges();
                MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Thêm dòng này để đóng form khi lưu xong
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}