namespace QLNhaSach
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            menuChucNang = new ToolStripMenuItem();
            menuQuanLySach = new ToolStripMenuItem();
            menuKhachHang = new ToolStripMenuItem();
            menuDonHang = new ToolStripMenuItem();
            menuThongKe = new ToolStripMenuItem();
            menuBaoCaoTonKho = new ToolStripMenuItem();
            menuNhapXuatKho = new ToolStripMenuItem();
            menuXuatExcel = new ToolStripMenuItem();
            toolStripSeparatorAdmin = new ToolStripSeparator();
            menuAdminQuanLyNguoiDung = new ToolStripMenuItem();
            menuAdminQuanLyRole = new ToolStripMenuItem();
            menuAdminSaoLuuDuLieu = new ToolStripMenuItem();
            menuAdminPhucHoiDuLieu = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            menuAdminCauHinhHeThong = new ToolStripMenuItem();
            menuAdminXemNhatKy = new ToolStripMenuItem();
            panelWelcome = new Panel();
            lblWelcome = new Label();
            lblSystemInfo = new Label();
            panelQuickAccess = new Panel();
            lblQuickAccess = new Label();
            btnQuanLySach = new Button();
            btnKhachHang = new Button();
            btnDonHang = new Button();
            btnThongKe = new Button();
            btnBaoCaoTonKho = new Button();
            btnNhapXuatKho = new Button();
            menuStrip1.SuspendLayout();
            panelWelcome.SuspendLayout();
            panelQuickAccess.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(41, 128, 185);
            menuStrip1.Font = new Font("Segoe UI", 10F);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuChucNang });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(8, 4, 0, 4);
            menuStrip1.Size = new Size(1200, 31);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuChucNang
            // 
            menuChucNang.DropDownItems.AddRange(new ToolStripItem[] { menuQuanLySach, menuKhachHang, menuDonHang, menuThongKe, menuBaoCaoTonKho, menuNhapXuatKho, menuXuatExcel, toolStripSeparatorAdmin, menuAdminQuanLyNguoiDung, menuAdminQuanLyRole, menuAdminSaoLuuDuLieu, menuAdminPhucHoiDuLieu, toolStripSeparator1, menuAdminCauHinhHeThong, menuAdminXemNhatKy });
            menuChucNang.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            menuChucNang.ForeColor = Color.White;
            menuChucNang.Name = "menuChucNang";
            menuChucNang.Padding = new Padding(10, 0, 10, 0);
            menuChucNang.Size = new Size(107, 23);
            menuChucNang.Text = "☰ Chức năng";
            // 
            // menuQuanLySach
            // 
            menuQuanLySach.Font = new Font("Segoe UI", 10F);
            menuQuanLySach.Name = "menuQuanLySach";
            menuQuanLySach.Size = new Size(260, 26);
            menuQuanLySach.Text = "📖 Danh sách sách";
            menuQuanLySach.Click += menuQuanLySach_Click;
            // 
            // menuKhachHang
            // 
            menuKhachHang.Font = new Font("Segoe UI", 10F);
            menuKhachHang.Name = "menuKhachHang";
            menuKhachHang.Size = new Size(260, 26);
            menuKhachHang.Text = "👥 Danh sách khách hàng";
            menuKhachHang.Click += menuKhachHang_Click;
            // 
            // menuDonHang
            // 
            menuDonHang.Font = new Font("Segoe UI", 10F);
            menuDonHang.Name = "menuDonHang";
            menuDonHang.Size = new Size(260, 26);
            menuDonHang.Text = "📝 Danh sách đơn hàng";
            menuDonHang.Click += menuDonHang_Click;
            // 
            // menuThongKe
            // 
            menuThongKe.Font = new Font("Segoe UI", 10F);
            menuThongKe.Name = "menuThongKe";
            menuThongKe.Size = new Size(260, 26);
            menuThongKe.Text = "📊 Thống kê báo cáo";
            menuThongKe.Click += menuThongKe_Click;
            // 
            // menuBaoCaoTonKho
            // 
            menuBaoCaoTonKho.Font = new Font("Segoe UI", 10F);
            menuBaoCaoTonKho.Name = "menuBaoCaoTonKho";
            menuBaoCaoTonKho.Size = new Size(260, 26);
            menuBaoCaoTonKho.Text = "📦 Báo cáo tồn kho";
            menuBaoCaoTonKho.Click += menuBaoCaoTonKho_Click;
            // 
            // menuNhapXuatKho
            // 
            menuNhapXuatKho.Font = new Font("Segoe UI", 10F);
            menuNhapXuatKho.Name = "menuNhapXuatKho";
            menuNhapXuatKho.Size = new Size(260, 26);
            menuNhapXuatKho.Text = "🛒 Nhập xuất kho";
            menuNhapXuatKho.Click += menuNhapXuatKho_Click;
            // 
            // menuXuatExcel
            // 
            menuXuatExcel.Font = new Font("Segoe UI", 10F);
            menuXuatExcel.Name = "menuXuatExcel";
            menuXuatExcel.Size = new Size(260, 26);
            menuXuatExcel.Text = "📄 Xuất Excel";
            menuXuatExcel.Click += menuXuatExcel_Click;
            // 
            // toolStripSeparatorAdmin
            // 
            toolStripSeparatorAdmin.Name = "toolStripSeparatorAdmin";
            toolStripSeparatorAdmin.Size = new Size(257, 6);
            // 
            // menuAdminQuanLyNguoiDung
            // 
            menuAdminQuanLyNguoiDung.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            menuAdminQuanLyNguoiDung.ForeColor = Color.FromArgb(231, 76, 60);
            menuAdminQuanLyNguoiDung.Name = "menuAdminQuanLyNguoiDung";
            menuAdminQuanLyNguoiDung.Size = new Size(260, 26);
            menuAdminQuanLyNguoiDung.Text = "👤 Quản lý người dùng";
            menuAdminQuanLyNguoiDung.Visible = false;
            menuAdminQuanLyNguoiDung.Click += menuAdminQuanLyNguoiDung_Click;
            // 
            // menuAdminQuanLyRole
            // 
            menuAdminQuanLyRole.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            menuAdminQuanLyRole.ForeColor = Color.FromArgb(231, 76, 60);
            menuAdminQuanLyRole.Name = "menuAdminQuanLyRole";
            menuAdminQuanLyRole.Size = new Size(260, 26);
            menuAdminQuanLyRole.Text = "🔑 Quản lý vai trò";
            menuAdminQuanLyRole.Visible = false;
            menuAdminQuanLyRole.Click += menuAdminQuanLyRole_Click;
            // 
            // menuAdminSaoLuuDuLieu
            // 
            menuAdminSaoLuuDuLieu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            menuAdminSaoLuuDuLieu.ForeColor = Color.FromArgb(231, 76, 60);
            menuAdminSaoLuuDuLieu.Name = "menuAdminSaoLuuDuLieu";
            menuAdminSaoLuuDuLieu.Size = new Size(260, 26);
            menuAdminSaoLuuDuLieu.Text = "💾 Sao lưu dữ liệu";
            menuAdminSaoLuuDuLieu.Visible = false;
            menuAdminSaoLuuDuLieu.Click += menuAdminSaoLuuDuLieu_Click;
            // 
            // menuAdminPhucHoiDuLieu
            // 
            menuAdminPhucHoiDuLieu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            menuAdminPhucHoiDuLieu.ForeColor = Color.FromArgb(231, 76, 60);
            menuAdminPhucHoiDuLieu.Name = "menuAdminPhucHoiDuLieu";
            menuAdminPhucHoiDuLieu.Size = new Size(260, 26);
            menuAdminPhucHoiDuLieu.Text = "♻ Phục hồi dữ liệu";
            menuAdminPhucHoiDuLieu.Visible = false;
            menuAdminPhucHoiDuLieu.Click += menuAdminPhucHoiDuLieu_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(257, 6);
            toolStripSeparator1.Visible = false;
            // 
            // menuAdminCauHinhHeThong
            // 
            menuAdminCauHinhHeThong.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            menuAdminCauHinhHeThong.ForeColor = Color.FromArgb(231, 76, 60);
            menuAdminCauHinhHeThong.Name = "menuAdminCauHinhHeThong";
            menuAdminCauHinhHeThong.Size = new Size(260, 26);
            menuAdminCauHinhHeThong.Text = "⚙ Cấu hình hệ thống";
            menuAdminCauHinhHeThong.Visible = false;
            menuAdminCauHinhHeThong.Click += menuAdminCauHinhHeThong_Click;
            // 
            // menuAdminXemNhatKy
            // 
            menuAdminXemNhatKy.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            menuAdminXemNhatKy.ForeColor = Color.FromArgb(231, 76, 60);
            menuAdminXemNhatKy.Name = "menuAdminXemNhatKy";
            menuAdminXemNhatKy.Size = new Size(260, 26);
            menuAdminXemNhatKy.Text = "📋 Nhật ký hoạt động ";
            menuAdminXemNhatKy.Visible = false;
            menuAdminXemNhatKy.Click += menuAdminXemNhatKy_Click;
            // 
            // panelWelcome
            // 
            panelWelcome.BackColor = Color.White;
            panelWelcome.Controls.Add(lblSystemInfo);
            panelWelcome.Controls.Add(lblWelcome);
            panelWelcome.Location = new Point(50, 80);
            panelWelcome.Name = "panelWelcome";
            panelWelcome.Size = new Size(700, 150);
            panelWelcome.TabIndex = 1;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.FromArgb(41, 128, 185);
            lblWelcome.Location = new Point(30, 20);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(500, 45);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Chào mừng đến với hệ thống quản lý nhà sách";
            // 
            // lblSystemInfo
            // 
            lblSystemInfo.AutoSize = true;
            lblSystemInfo.Font = new Font("Segoe UI", 11F);
            lblSystemInfo.ForeColor = Color.FromArgb(127, 140, 141);
            lblSystemInfo.Location = new Point(30, 80);
            lblSystemInfo.Name = "lblSystemInfo";
            lblSystemInfo.Size = new Size(400, 60);
            lblSystemInfo.TabIndex = 1;
            lblSystemInfo.Text = "Hệ thống quản lý bán sách chuyên nghiệp\nQuản lý sách, khách hàng, đơn hàng và báo cáo thống kê\nPhiên bản 1.0.0";
            // 
            // panelQuickAccess
            // 
            panelQuickAccess.BackColor = Color.White;
            panelQuickAccess.Controls.Add(lblQuickAccess);
            panelQuickAccess.Controls.Add(btnQuanLySach);
            panelQuickAccess.Controls.Add(btnKhachHang);
            panelQuickAccess.Controls.Add(btnDonHang);
            panelQuickAccess.Controls.Add(btnThongKe);
            panelQuickAccess.Controls.Add(btnBaoCaoTonKho);
            panelQuickAccess.Controls.Add(btnNhapXuatKho);
            panelQuickAccess.Location = new Point(50, 260);
            panelQuickAccess.Name = "panelQuickAccess";
            panelQuickAccess.Size = new Size(700, 300);
            panelQuickAccess.TabIndex = 2;
            // 
            // lblQuickAccess
            // 
            lblQuickAccess.AutoSize = true;
            lblQuickAccess.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblQuickAccess.ForeColor = Color.FromArgb(52, 73, 94);
            lblQuickAccess.Location = new Point(30, 20);
            lblQuickAccess.Name = "lblQuickAccess";
            lblQuickAccess.Size = new Size(150, 25);
            lblQuickAccess.TabIndex = 0;
            lblQuickAccess.Text = "Truy cập nhanh";
            // 
            // btnQuanLySach
            // 
            btnQuanLySach.BackColor = Color.FromArgb(52, 152, 219);
            btnQuanLySach.FlatStyle = FlatStyle.Flat;
            btnQuanLySach.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnQuanLySach.ForeColor = Color.White;
            btnQuanLySach.Location = new Point(30, 70);
            btnQuanLySach.Name = "btnQuanLySach";
            btnQuanLySach.Size = new Size(200, 60);
            btnQuanLySach.TabIndex = 1;
            btnQuanLySach.Text = "📖 Danh sách sách";
            btnQuanLySach.UseVisualStyleBackColor = false;
            btnQuanLySach.Click += menuQuanLySach_Click;
            // 
            // btnKhachHang
            // 
            btnKhachHang.BackColor = Color.FromArgb(46, 204, 113);
            btnKhachHang.FlatStyle = FlatStyle.Flat;
            btnKhachHang.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnKhachHang.ForeColor = Color.White;
            btnKhachHang.Location = new Point(250, 70);
            btnKhachHang.Name = "btnKhachHang";
            btnKhachHang.Size = new Size(200, 60);
            btnKhachHang.TabIndex = 2;
            btnKhachHang.Text = "👥 Khách hàng";
            btnKhachHang.UseVisualStyleBackColor = false;
            btnKhachHang.Click += menuKhachHang_Click;
            // 
            // btnDonHang
            // 
            btnDonHang.BackColor = Color.FromArgb(155, 89, 182);
            btnDonHang.FlatStyle = FlatStyle.Flat;
            btnDonHang.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDonHang.ForeColor = Color.White;
            btnDonHang.Location = new Point(470, 70);
            btnDonHang.Name = "btnDonHang";
            btnDonHang.Size = new Size(200, 60);
            btnDonHang.TabIndex = 3;
            btnDonHang.Text = "📝 Đơn hàng";
            btnDonHang.UseVisualStyleBackColor = false;
            btnDonHang.Click += menuDonHang_Click;
            // 
            // btnThongKe
            // 
            btnThongKe.BackColor = Color.FromArgb(230, 126, 34);
            btnThongKe.FlatStyle = FlatStyle.Flat;
            btnThongKe.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnThongKe.ForeColor = Color.White;
            btnThongKe.Location = new Point(30, 150);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(200, 60);
            btnThongKe.TabIndex = 4;
            btnThongKe.Text = "📊 Thống kê báo cáo";
            btnThongKe.UseVisualStyleBackColor = false;
            btnThongKe.Click += menuThongKe_Click;
            // 
            // btnBaoCaoTonKho
            // 
            btnBaoCaoTonKho.BackColor = Color.FromArgb(231, 76, 60);
            btnBaoCaoTonKho.FlatStyle = FlatStyle.Flat;
            btnBaoCaoTonKho.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnBaoCaoTonKho.ForeColor = Color.White;
            btnBaoCaoTonKho.Location = new Point(250, 150);
            btnBaoCaoTonKho.Name = "btnBaoCaoTonKho";
            btnBaoCaoTonKho.Size = new Size(200, 60);
            btnBaoCaoTonKho.TabIndex = 5;
            btnBaoCaoTonKho.Text = "📦 Báo cáo tồn kho";
            btnBaoCaoTonKho.UseVisualStyleBackColor = false;
            btnBaoCaoTonKho.Click += menuBaoCaoTonKho_Click;
            // 
            // btnNhapXuatKho
            // 
            btnNhapXuatKho.BackColor = Color.FromArgb(52, 73, 94);
            btnNhapXuatKho.FlatStyle = FlatStyle.Flat;
            btnNhapXuatKho.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnNhapXuatKho.ForeColor = Color.White;
            btnNhapXuatKho.Location = new Point(470, 150);
            btnNhapXuatKho.Name = "btnNhapXuatKho";
            btnNhapXuatKho.Size = new Size(200, 60);
            btnNhapXuatKho.TabIndex = 6;
            btnNhapXuatKho.Text = "🛒 Nhập xuất kho";
            btnNhapXuatKho.UseVisualStyleBackColor = false;
            btnNhapXuatKho.Click += menuNhapXuatKho_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(800, 600);
            Controls.Add(panelQuickAccess);
            Controls.Add(panelWelcome);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 10F);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hệ thống quản lý nhà sách";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panelWelcome.ResumeLayout(false);
            panelWelcome.PerformLayout();
            panelQuickAccess.ResumeLayout(false);
            panelQuickAccess.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuChucNang;
        private System.Windows.Forms.ToolStripMenuItem menuQuanLySach;
        private System.Windows.Forms.ToolStripMenuItem menuKhachHang;
        private System.Windows.Forms.ToolStripMenuItem menuDonHang;
        private System.Windows.Forms.ToolStripMenuItem menuThongKe;
        private System.Windows.Forms.ToolStripMenuItem menuBaoCaoTonKho;
        private System.Windows.Forms.ToolStripMenuItem menuNhapXuatKho;
        private System.Windows.Forms.ToolStripMenuItem menuXuatExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorAdmin;
        private System.Windows.Forms.ToolStripMenuItem menuAdminQuanLyNguoiDung;
        private System.Windows.Forms.ToolStripMenuItem menuAdminQuanLyRole;
        private System.Windows.Forms.ToolStripMenuItem menuAdminSaoLuuDuLieu;
        private System.Windows.Forms.ToolStripMenuItem menuAdminPhucHoiDuLieu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuAdminCauHinhHeThong;
        private System.Windows.Forms.ToolStripMenuItem menuAdminXemNhatKy;
        private System.Windows.Forms.Panel panelWelcome;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblSystemInfo;
        private System.Windows.Forms.Panel panelQuickAccess;
        private System.Windows.Forms.Label lblQuickAccess;
        private System.Windows.Forms.Button btnQuanLySach;
        private System.Windows.Forms.Button btnKhachHang;
        private System.Windows.Forms.Button btnDonHang;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnBaoCaoTonKho;
        private System.Windows.Forms.Button btnNhapXuatKho;
    }
}


