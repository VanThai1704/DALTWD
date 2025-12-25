using System;
using System.Linq;
using System.Windows.Forms;
using QLNhaSach.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QLNhaSach
{
    public partial class FormNguoiDungEdit : Form
    {
        private int? _id;
        public FormNguoiDungEdit() : this(null) { }
        public FormNguoiDungEdit(int? id)
        {
            _id = id;
            InitializeComponent();
            this.ApplyVietnameseFont();
            LoadRoles();
            if (_id.HasValue) LoadData();
            this.btnOK.Click += BtnOK_Click;
        }

        private void LoadRoles()
        {
            try
            {
                using var db = new QuanLyNhaSachContext();
                var roles = db.Roles.OrderBy(r => r.RoleId).ToList();
                
                // Load CheckedListBox
                clbRoles.Items.Clear();
                clbRoles.DisplayMember = "RoleName";
                clbRoles.ValueMember = "RoleId";
                foreach (var role in roles)
                {
                    clbRoles.Items.Add(role);
                }
                
                // Mặc định chọn role "Nhân viên" (RoleId = 2) khi thêm mới
                if (!_id.HasValue)
                {
                    // Check "Nhân viên" trong CheckedListBox
                    for (int i = 0; i < clbRoles.Items.Count; i++)
                    {
                        var role = (Role)clbRoles.Items[i];
                        if (role.RoleId == RolePermissions.NHANVIEN_ROLE_ID)
                        {
                            clbRoles.SetItemChecked(i, true);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách role: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                using var db = new QuanLyNhaSachContext();
                var n = db.NguoiDungs
                    .Include(u => u.NguoiDungRoles)
                    .ThenInclude(nr => nr.Role)
                    .FirstOrDefault(u => u.NguoiDungId == _id.Value);
                    
                if (n == null) return;
                
                txtTenDangNhap.Text = n.TenDangNhap;
                txtHoTen.Text = n.HoTen;
                chkKichHoat.Checked = n.KichHoat;
                txtTenDangNhap.Enabled = false;
                lblMatKhau.Text = "Mật khẩu mới (để trống nếu không đổi):";
                
                // Check các roles đã assigned
                var assignedRoleIds = n.NguoiDungRoles.Select(nr => nr.RoleId).ToList();
                for (int i = 0; i < clbRoles.Items.Count; i++)
                {
                    var role = (Role)clbRoles.Items[i];
                    if (assignedRoleIds.Contains(role.RoleId))
                    {
                        clbRoles.SetItemChecked(i, true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải người dùng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                MessageBox.Show("Tên đăng nhập không được để trống", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            if (!_id.HasValue && string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Mật khẩu không được để trống khi tạo người dùng mới", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            // Lấy danh sách roles đã checked
            var selectedRoleIds = new List<int>();
            foreach (var item in clbRoles.CheckedItems)
            {
                var role = (Role)item;
                selectedRoleIds.Add(role.RoleId);
            }

            if (selectedRoleIds.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một vai trò", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            try
            {
                using var db = new QuanLyNhaSachContext();
                
                // Primary role = role đầu tiên được chọn (thứ tự theo RoleId)
                int primaryRoleId = selectedRoleIds.OrderBy(id => id).First();
                
                if (!_id.HasValue)
                {
                    // Kiểm tra trùng tên đăng nhập
                    if (db.NguoiDungs.Any(u => u.TenDangNhap == txtTenDangNhap.Text.Trim()))
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.DialogResult = DialogResult.None;
                        return;
                    }

                    // Tạo salt mới và hash mật khẩu
                    string salt;
                    string passwordHash = PasswordHelper.HashPasswordWithNewSalt(txtMatKhau.Text, out salt);

                    var n = new NguoiDung
                    {
                        TenDangNhap = txtTenDangNhap.Text.Trim(),
                        MatKhauHash = passwordHash,
                        PasswordSalt = salt,
                        HoTen = txtHoTen.Text.Trim(),
                        RoleId = primaryRoleId, // Primary role tự động
                        KichHoat = chkKichHoat.Checked
                    };
                    db.NguoiDungs.Add(n);
                    db.SaveChanges();

                    // Thêm vào bảng NguoiDungRole
                    foreach (var roleId in selectedRoleIds)
                    {
                        db.NguoiDungRoles.Add(new NguoiDungRole
                        {
                            NguoiDungId = n.NguoiDungId,
                            RoleId = roleId,
                            NgayGan = DateTime.Now
                        });
                    }
                    db.SaveChanges();
                }
                else
                {
                    var n = db.NguoiDungs
                        .Include(u => u.NguoiDungRoles)
                        .FirstOrDefault(u => u.NguoiDungId == _id.Value);
                        
                    if (n != null)
                    {
                        n.HoTen = txtHoTen.Text.Trim();
                        n.RoleId = primaryRoleId; // Primary role tự động
                        n.KichHoat = chkKichHoat.Checked;

                        // Cập nhật mật khẩu nếu có nhập mới
                        if (!string.IsNullOrWhiteSpace(txtMatKhau.Text))
                        {
                            string salt;
                            string passwordHash = PasswordHelper.HashPasswordWithNewSalt(txtMatKhau.Text, out salt);
                            n.MatKhauHash = passwordHash;
                            n.PasswordSalt = salt;
                        }

                        // Xóa các role assignments cũ
                        db.NguoiDungRoles.RemoveRange(n.NguoiDungRoles);

                        // Thêm lại các role mới
                        foreach (var roleId in selectedRoleIds)
                        {
                            db.NguoiDungRoles.Add(new NguoiDungRole
                            {
                                NguoiDungId = n.NguoiDungId,
                                RoleId = roleId,
                                NgayGan = DateTime.Now
                            });
                        }
                    }
                    db.SaveChanges();
                }
                MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}
