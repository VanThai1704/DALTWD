using System.Drawing;
using System.Windows.Forms;

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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuChucNang = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuanLySach = new System.Windows.Forms.ToolStripMenuItem();
            this.menuKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDonHang = new System.Windows.Forms.ToolStripMenuItem();
            this.menuThongKe = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBaoCaoTonKho = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNhapXuatKho = new System.Windows.Forms.ToolStripMenuItem();
            this.menuXuatExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorAdmin = new System.Windows.Forms.ToolStripSeparator();
            this.menuAdminQuanLyNguoiDung = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdminQuanLyRole = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdminSaoLuuDuLieu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdminPhucHoiDuLieu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuAdminCauHinhHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdminXemNhatKy = new System.Windows.Forms.ToolStripMenuItem();
            this.xuấtBáoCáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelWelcome = new System.Windows.Forms.Panel();
            this.lblSystemInfo = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.panelQuickAccess = new System.Windows.Forms.Panel();
            this.lblQuickAccess = new System.Windows.Forms.Label();
            this.btnQuanLySach = new System.Windows.Forms.Button();
            this.btnKhachHang = new System.Windows.Forms.Button();
            this.btnDonHang = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnBaoCaoTonKho = new System.Windows.Forms.Button();
            this.btnNhapXuatKho = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panelWelcome.SuspendLayout();
            this.panelQuickAccess.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuChucNang});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(800, 35);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuChucNang
            // 
            this.menuChucNang.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuQuanLySach,
            this.menuKhachHang,
            this.menuDonHang,
            this.menuThongKe,
            this.menuBaoCaoTonKho,
            this.menuNhapXuatKho,
            this.menuXuatExcel,
            this.toolStripSeparatorAdmin,
            this.menuAdminQuanLyNguoiDung,
            this.menuAdminQuanLyRole,
            this.menuAdminSaoLuuDuLieu,
            this.menuAdminPhucHoiDuLieu,
            this.toolStripSeparator1,
            this.menuAdminCauHinhHeThong,
            this.menuAdminXemNhatKy,
            this.xuấtBáoCáoToolStripMenuItem});
            this.menuChucNang.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.menuChucNang.ForeColor = System.Drawing.Color.White;
            this.menuChucNang.Name = "menuChucNang";
            this.menuChucNang.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.menuChucNang.Size = new System.Drawing.Size(140, 27);
            this.menuChucNang.Text = "☰ Chức năng";
            // 
            // menuQuanLySach
            // 
            this.menuQuanLySach.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuQuanLySach.Name = "menuQuanLySach";
            this.menuQuanLySach.Size = new System.Drawing.Size(296, 28);
            this.menuQuanLySach.Text = "📖 Danh sách sách";
            this.menuQuanLySach.Click += new System.EventHandler(this.menuQuanLySach_Click);
            // 
            // menuKhachHang
            // 
            this.menuKhachHang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuKhachHang.Name = "menuKhachHang";
            this.menuKhachHang.Size = new System.Drawing.Size(296, 28);
            this.menuKhachHang.Text = "👥 Danh sách khách hàng";
            this.menuKhachHang.Click += new System.EventHandler(this.menuKhachHang_Click);
            // 
            // menuDonHang
            // 
            this.menuDonHang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuDonHang.Name = "menuDonHang";
            this.menuDonHang.Size = new System.Drawing.Size(296, 28);
            this.menuDonHang.Text = "📝 Danh sách đơn hàng";
            this.menuDonHang.Click += new System.EventHandler(this.menuDonHang_Click);
            // 
            // menuThongKe
            // 
            this.menuThongKe.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuThongKe.Name = "menuThongKe";
            this.menuThongKe.Size = new System.Drawing.Size(296, 28);
            this.menuThongKe.Text = "📊 Thống kê báo cáo";
            this.menuThongKe.Click += new System.EventHandler(this.menuThongKe_Click);
            // 
            // menuBaoCaoTonKho
            // 
            this.menuBaoCaoTonKho.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuBaoCaoTonKho.Name = "menuBaoCaoTonKho";
            this.menuBaoCaoTonKho.Size = new System.Drawing.Size(296, 28);
            this.menuBaoCaoTonKho.Text = "📦 Báo cáo tồn kho";
            this.menuBaoCaoTonKho.Click += new System.EventHandler(this.menuBaoCaoTonKho_Click);
            // 
            // menuNhapXuatKho
            // 
            this.menuNhapXuatKho.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuNhapXuatKho.Name = "menuNhapXuatKho";
            this.menuNhapXuatKho.Size = new System.Drawing.Size(296, 28);
            this.menuNhapXuatKho.Text = "🛒 Nhập xuất kho";
            this.menuNhapXuatKho.Click += new System.EventHandler(this.menuNhapXuatKho_Click);
            // 
            // menuXuatExcel
            // 
            this.menuXuatExcel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.menuXuatExcel.Name = "menuXuatExcel";
            this.menuXuatExcel.Size = new System.Drawing.Size(296, 28);
            this.menuXuatExcel.Text = "📄 Xuất báo cáo";
            this.menuXuatExcel.Click += new System.EventHandler(this.menuXuatExcel_Click);
            // 
            // toolStripSeparatorAdmin
            // 
            this.toolStripSeparatorAdmin.Name = "toolStripSeparatorAdmin";
            this.toolStripSeparatorAdmin.Size = new System.Drawing.Size(293, 6);
            // 
            // menuAdminQuanLyNguoiDung
            // 
            this.menuAdminQuanLyNguoiDung.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.menuAdminQuanLyNguoiDung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.menuAdminQuanLyNguoiDung.Name = "menuAdminQuanLyNguoiDung";
            this.menuAdminQuanLyNguoiDung.Size = new System.Drawing.Size(296, 28);
            this.menuAdminQuanLyNguoiDung.Text = "👤 Quản lý người dùng";
            this.menuAdminQuanLyNguoiDung.Visible = false;
            this.menuAdminQuanLyNguoiDung.Click += new System.EventHandler(this.menuAdminQuanLyNguoiDung_Click);
            // 
            // menuAdminQuanLyRole
            // 
            this.menuAdminQuanLyRole.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.menuAdminQuanLyRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.menuAdminQuanLyRole.Name = "menuAdminQuanLyRole";
            this.menuAdminQuanLyRole.Size = new System.Drawing.Size(296, 28);
            this.menuAdminQuanLyRole.Text = "🔑 Quản lý vai trò";
            this.menuAdminQuanLyRole.Visible = false;
            this.menuAdminQuanLyRole.Click += new System.EventHandler(this.menuAdminQuanLyRole_Click);
            // 
            // menuAdminSaoLuuDuLieu
            // 
            this.menuAdminSaoLuuDuLieu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.menuAdminSaoLuuDuLieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.menuAdminSaoLuuDuLieu.Name = "menuAdminSaoLuuDuLieu";
            this.menuAdminSaoLuuDuLieu.Size = new System.Drawing.Size(296, 28);
            this.menuAdminSaoLuuDuLieu.Text = "💾 Sao lưu dữ liệu";
            this.menuAdminSaoLuuDuLieu.Visible = false;
            this.menuAdminSaoLuuDuLieu.Click += new System.EventHandler(this.menuAdminSaoLuuDuLieu_Click);
            // 
            // menuAdminPhucHoiDuLieu
            // 
            this.menuAdminPhucHoiDuLieu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.menuAdminPhucHoiDuLieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.menuAdminPhucHoiDuLieu.Name = "menuAdminPhucHoiDuLieu";
            this.menuAdminPhucHoiDuLieu.Size = new System.Drawing.Size(296, 28);
            this.menuAdminPhucHoiDuLieu.Text = "♻ Phục hồi dữ liệu";
            this.menuAdminPhucHoiDuLieu.Visible = false;
            this.menuAdminPhucHoiDuLieu.Click += new System.EventHandler(this.menuAdminPhucHoiDuLieu_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(293, 6);
            this.toolStripSeparator1.Visible = false;
            // 
            // menuAdminCauHinhHeThong
            // 
            this.menuAdminCauHinhHeThong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.menuAdminCauHinhHeThong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.menuAdminCauHinhHeThong.Name = "menuAdminCauHinhHeThong";
            this.menuAdminCauHinhHeThong.Size = new System.Drawing.Size(296, 28);
            this.menuAdminCauHinhHeThong.Text = "⚙ Cấu hình hệ thống";
            this.menuAdminCauHinhHeThong.Visible = false;
            this.menuAdminCauHinhHeThong.Click += new System.EventHandler(this.menuAdminCauHinhHeThong_Click);
            // 
            // menuAdminXemNhatKy
            // 
            this.menuAdminXemNhatKy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.menuAdminXemNhatKy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.menuAdminXemNhatKy.Name = "menuAdminXemNhatKy";
            this.menuAdminXemNhatKy.Size = new System.Drawing.Size(296, 28);
            this.menuAdminXemNhatKy.Text = "📋 Nhật ký hoạt động ";
            this.menuAdminXemNhatKy.Visible = false;
            this.menuAdminXemNhatKy.Click += new System.EventHandler(this.menuAdminXemNhatKy_Click);
            // 
            // xuấtBáoCáoToolStripMenuItem
            // 
            this.xuấtBáoCáoToolStripMenuItem.Name = "xuấtBáoCáoToolStripMenuItem";
            this.xuấtBáoCáoToolStripMenuItem.Size = new System.Drawing.Size(296, 28);
            this.xuấtBáoCáoToolStripMenuItem.Text = "📄 Xuất Báo Cáo";
            // 
            // panelWelcome
            // 
            this.panelWelcome.BackColor = System.Drawing.Color.White;
            this.panelWelcome.Controls.Add(this.lblSystemInfo);
            this.panelWelcome.Controls.Add(this.lblWelcome);
            this.panelWelcome.Location = new System.Drawing.Point(50, 80);
            this.panelWelcome.Name = "panelWelcome";
            this.panelWelcome.Size = new System.Drawing.Size(700, 169);
            this.panelWelcome.TabIndex = 1;
            // 
            // lblSystemInfo
            // 
            this.lblSystemInfo.AutoSize = true;
            this.lblSystemInfo.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSystemInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblSystemInfo.Location = new System.Drawing.Point(30, 80);
            this.lblSystemInfo.Name = "lblSystemInfo";
            this.lblSystemInfo.Size = new System.Drawing.Size(492, 75);
            this.lblSystemInfo.TabIndex = 1;
            this.lblSystemInfo.Text = "Hệ thống quản lý bán sách chuyên nghiệp\nQuản lý sách, khách hàng, đơn hàng và báo" +
    " cáo thống kê\nPhiên bản 1.0.0";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblWelcome.Location = new System.Drawing.Point(30, 20);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(899, 54);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Chào mừng đến với hệ thống quản lý nhà sách";
            // 
            // panelQuickAccess
            // 
            this.panelQuickAccess.BackColor = System.Drawing.Color.White;
            this.panelQuickAccess.Controls.Add(this.lblQuickAccess);
            this.panelQuickAccess.Controls.Add(this.btnQuanLySach);
            this.panelQuickAccess.Controls.Add(this.btnKhachHang);
            this.panelQuickAccess.Controls.Add(this.btnDonHang);
            this.panelQuickAccess.Controls.Add(this.btnThongKe);
            this.panelQuickAccess.Controls.Add(this.btnBaoCaoTonKho);
            this.panelQuickAccess.Controls.Add(this.btnNhapXuatKho);
            this.panelQuickAccess.Location = new System.Drawing.Point(50, 277);
            this.panelQuickAccess.Name = "panelQuickAccess";
            this.panelQuickAccess.Size = new System.Drawing.Size(700, 283);
            this.panelQuickAccess.TabIndex = 2;
            // 
            // lblQuickAccess
            // 
            this.lblQuickAccess.AutoSize = true;
            this.lblQuickAccess.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblQuickAccess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblQuickAccess.Location = new System.Drawing.Point(30, 20);
            this.lblQuickAccess.Name = "lblQuickAccess";
            this.lblQuickAccess.Size = new System.Drawing.Size(189, 32);
            this.lblQuickAccess.TabIndex = 0;
            this.lblQuickAccess.Text = "Truy cập nhanh";
            // 
            // btnQuanLySach
            // 
            this.btnQuanLySach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnQuanLySach.FlatAppearance.BorderSize = 0;
            this.btnQuanLySach.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnQuanLySach.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))), ((int)(((byte)(220)))));
            this.btnQuanLySach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLySach.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnQuanLySach.ForeColor = System.Drawing.Color.White;
            this.btnQuanLySach.Location = new System.Drawing.Point(30, 70);
            this.btnQuanLySach.Name = "btnQuanLySach";
            this.btnQuanLySach.Size = new System.Drawing.Size(200, 60);
            this.btnQuanLySach.TabIndex = 1;
            this.btnQuanLySach.Text = "Quản lý sách";
            this.btnQuanLySach.UseVisualStyleBackColor = false;
            this.btnQuanLySach.Click += new System.EventHandler(this.btnQuanLySach_Click);
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnKhachHang.FlatAppearance.BorderSize = 0;
            this.btnKhachHang.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnKhachHang.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))), ((int)(((byte)(220)))));
            this.btnKhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhachHang.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnKhachHang.ForeColor = System.Drawing.Color.White;
            this.btnKhachHang.Location = new System.Drawing.Point(250, 70);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Size = new System.Drawing.Size(200, 60);
            this.btnKhachHang.TabIndex = 2;
            this.btnKhachHang.Text = "Khách hàng";
            this.btnKhachHang.UseVisualStyleBackColor = false;
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // btnDonHang
            // 
            this.btnDonHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnDonHang.FlatAppearance.BorderSize = 0;
            this.btnDonHang.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnDonHang.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))), ((int)(((byte)(220)))));
            this.btnDonHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDonHang.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDonHang.ForeColor = System.Drawing.Color.White;
            this.btnDonHang.Location = new System.Drawing.Point(470, 70);
            this.btnDonHang.Name = "btnDonHang";
            this.btnDonHang.Size = new System.Drawing.Size(200, 60);
            this.btnDonHang.TabIndex = 3;
            this.btnDonHang.Text = "Đơn hàng";
            this.btnDonHang.UseVisualStyleBackColor = false;
            this.btnDonHang.Click += new System.EventHandler(this.btnDonHang_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnThongKe.FlatAppearance.BorderSize = 0;
            this.btnThongKe.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnThongKe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))), ((int)(((byte)(220)))));
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKe.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.Location = new System.Drawing.Point(30, 150);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(200, 60);
            this.btnThongKe.TabIndex = 4;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnBaoCaoTonKho
            // 
            this.btnBaoCaoTonKho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnBaoCaoTonKho.FlatAppearance.BorderSize = 0;
            this.btnBaoCaoTonKho.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnBaoCaoTonKho.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))), ((int)(((byte)(220)))));
            this.btnBaoCaoTonKho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaoCaoTonKho.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnBaoCaoTonKho.ForeColor = System.Drawing.Color.White;
            this.btnBaoCaoTonKho.Location = new System.Drawing.Point(250, 150);
            this.btnBaoCaoTonKho.Name = "btnBaoCaoTonKho";
            this.btnBaoCaoTonKho.Size = new System.Drawing.Size(200, 60);
            this.btnBaoCaoTonKho.TabIndex = 5;
            this.btnBaoCaoTonKho.Text = "Báo cáo tồn kho";
            this.btnBaoCaoTonKho.UseVisualStyleBackColor = false;
            this.btnBaoCaoTonKho.Click += new System.EventHandler(this.btnBaoCaoTonKho_Click);
            // 
            // btnNhapXuatKho
            // 
            this.btnNhapXuatKho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnNhapXuatKho.FlatAppearance.BorderSize = 0;
            this.btnNhapXuatKho.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnNhapXuatKho.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))), ((int)(((byte)(220)))));
            this.btnNhapXuatKho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhapXuatKho.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnNhapXuatKho.ForeColor = System.Drawing.Color.White;
            this.btnNhapXuatKho.Location = new System.Drawing.Point(470, 150);
            this.btnNhapXuatKho.Name = "btnNhapXuatKho";
            this.btnNhapXuatKho.Size = new System.Drawing.Size(200, 60);
            this.btnNhapXuatKho.TabIndex = 6;
            this.btnNhapXuatKho.Text = "Nhập xuất kho";
            this.btnNhapXuatKho.UseVisualStyleBackColor = false;
            this.btnNhapXuatKho.Click += new System.EventHandler(this.btnNhapXuatKho_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.panelQuickAccess);
            this.Controls.Add(this.panelWelcome);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống quản lý nhà sách";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelWelcome.ResumeLayout(false);
            this.panelWelcome.PerformLayout();
            this.panelQuickAccess.ResumeLayout(false);
            this.panelQuickAccess.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private ToolStripMenuItem xuấtBáoCáoToolStripMenuItem;
    }
}


