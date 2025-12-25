using System;
using System.Windows.Forms;

namespace QLNhaSach
{

    public partial class Form1 : Form
    {
        private readonly NguoiDung _currentUser;
        public Form1(NguoiDung user = null)
        {
            InitializeComponent();
            this.ApplyVietnameseFont();
            _currentUser = user;
            this.Load += Form1_Load;
            
            UITheme.ApplyTheme(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Hiển thị tên người dùng và vai trò
            var displayName = _currentUser?.HoTen ?? _currentUser?.TenDangNhap ?? "Chưa đăng nhập";
            var roleName = RolePermissions.GetRoleName(_currentUser?.RoleId ?? 0);
            this.Text = $"Quản lý Nhà sách - [{displayName}] - {roleName}";
            
            // Phân quyền hiển thị menu
            ApplyRolePermissions();
        }

        /// <summary>
        /// Áp dụng phân quyền theo role của user
        /// </summary>
        private void ApplyRolePermissions()
        {
            if (_currentUser == null) return;

            // Menu Thống kê doanh thu - chỉ Admin và Quản lý
            if (this.menuThongKe != null)
                this.menuThongKe.Visible = RolePermissions.CanViewRevenue(_currentUser);

            // Menu Nhập xuất kho - tất cả trừ ReadOnly
            if (this.menuNhapXuatKho != null)
                this.menuNhapXuatKho.Visible = RolePermissions.CanManageInventory(_currentUser);

            // Menu Xuất Excel - chỉ Admin và Quản lý
            if (this.menuXuatExcel != null)
                this.menuXuatExcel.Visible = RolePermissions.CanExportExcel(_currentUser);

            // Separator và các menu Admin - chỉ Admin
            bool isAdmin = RolePermissions.IsAdmin(_currentUser);
            
            if (this.toolStripSeparatorAdmin != null)
                this.toolStripSeparatorAdmin.Visible = isAdmin;
            
            if (this.menuAdminQuanLyNguoiDung != null)
                this.menuAdminQuanLyNguoiDung.Visible = isAdmin;
            
            if (this.menuAdminQuanLyRole != null)
                this.menuAdminQuanLyRole.Visible = isAdmin;
            
            if (this.menuAdminSaoLuuDuLieu != null)
                this.menuAdminSaoLuuDuLieu.Visible = isAdmin;
            
            if (this.menuAdminPhucHoiDuLieu != null)
                this.menuAdminPhucHoiDuLieu.Visible = isAdmin;
            
            if (this.toolStripSeparator1 != null)
                this.toolStripSeparator1.Visible = isAdmin;
            
            if (this.menuAdminCauHinhHeThong != null)
                this.menuAdminCauHinhHeThong.Visible = isAdmin;
            
            if (this.menuAdminXemNhatKy != null)
                this.menuAdminXemNhatKy.Visible = isAdmin;

            // Quick access buttons permissions
            if (this.btnThongKe != null)
                this.btnThongKe.Visible = RolePermissions.CanViewRevenue(_currentUser);
            
            if (this.btnNhapXuatKho != null)
                this.btnNhapXuatKho.Visible = RolePermissions.CanManageInventory(_currentUser);
        }

        private void menuQuanLySach_Click(object sender, EventArgs e)
        {
            ShowFormAndHide(new FormSach(_currentUser));
        }

        private void menuKhachHang_Click(object sender, EventArgs e)
        {
            ShowFormAndHide(new FormKhachHang(_currentUser));
        }

        private void menuDonHang_Click(object sender, EventArgs e)
        {
            ShowFormAndHide(new FormDonHang(_currentUser));
        }

        private void menuThongKe_Click(object sender, EventArgs e)
        {
            ShowFormAndHide(new FormThongKe());
        }

        private void menuBaoCaoTonKho_Click(object sender, EventArgs e)
        {
            ShowFormAndHide(new FormTonKho());
        }

        private void menuNhapXuatKho_Click(object sender, EventArgs e)
        {
            ShowFormAndHide(new FormNhapXuatKho(_currentUser));
        }

        private void menuXuatExcel_Click(object sender, EventArgs e)
        {
            ShowFormAndHide(new FormBaoCao(_currentUser));
        }

        // ========== MENU ADMIN ==========
        
        private void menuAdminQuanLyNguoiDung_Click(object sender, EventArgs e)
        {
            ShowFormAndHide(new FormNguoiDung());
        }

        private void menuAdminQuanLyRole_Click(object sender, EventArgs e)
        {
            ShowFormAndHide(new FormRole());
        }

        private void menuAdminSaoLuuDuLieu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng sao lưu dữ liệu đang được phát triển.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void menuAdminPhucHoiDuLieu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng phục hồi dữ liệu đang được phát triển.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void menuAdminCauHinhHeThong_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng cấu hình hệ thống đang được phát triển.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void menuAdminXemNhatKy_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng xem nhật ký hoạt động đang được phát triển.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Ẩn Form1, hiển thị form chức năng, sau đó hiện lại Form1 khi đóng
        /// </summary>
        private void ShowFormAndHide(Form childForm)
        {
            if (childForm == null) return;

            try
            {
                this.Hide(); // Ẩn Form1
                
                using (childForm)
                {
                    childForm.ShowDialog(); // Hiển thị form chức năng modal
                }
            }
            finally
            {
                this.Show(); // Hiện lại Form1 khi form chức năng đóng
                this.Activate(); // Đưa Form1 lên foreground
            }
        }
    }
}
