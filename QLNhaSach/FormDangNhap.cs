using System;
using System.Linq;
using System.Windows.Forms;
using QLNhaSach.Models;

namespace QLNhaSach
{
    public partial class FormDangNhap : Form
    {
        public NguoiDung DangNhapThanhCong { get; private set; }
        public FormDangNhap()
        {
            InitializeComponent();
            this.ApplyVietnameseFont();
            UITheme.ApplyTheme(this);
            CustomizeLoginForm();
            this.btnDangNhap.Click += BtnDangNhap_Click;
            this.btnThoat.Click += (s, e) => this.Close();
        }
        
        private void CustomizeLoginForm()
        {
            this.BackColor = UITheme.PrimaryColor;
            this.Size = new System.Drawing.Size(500, 400);
            
            var panel = new Panel
            {
                BackColor = UITheme.CardBackground,
                Width = 400,
                Height = 280,
                Anchor = AnchorStyles.None
            };
            
            var titleLabel = new Label
            {
                Text = "ĐĂNG NHẬP HỆ THỐNG",
                Font = new System.Drawing.Font(FontHelper.DefaultFormFont.FontFamily, 14F, System.Drawing.FontStyle.Bold),
                ForeColor = UITheme.PrimaryColor,
                AutoSize = false,
                Width = 360,
                Height = 40,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Location = new System.Drawing.Point(20, 20)
            };
            
            lblTenDangNhap.Location = new System.Drawing.Point(20, 80);
            lblTenDangNhap.Width = 120;
            lblTenDangNhap.Font = FontHelper.DefaultFormFont;
            
            txtTenDangNhap.Location = new System.Drawing.Point(150, 77);
            txtTenDangNhap.Width = 230;
            txtTenDangNhap.Font = FontHelper.DefaultFormFont;
            UITheme.StyleTextBox(txtTenDangNhap);
            
            lblMatKhau.Location = new System.Drawing.Point(20, 130);
            lblMatKhau.Width = 120;
            lblMatKhau.Font = FontHelper.DefaultFormFont;
            
            txtMatKhau.Location = new System.Drawing.Point(150, 127);
            txtMatKhau.Width = 230;
            txtMatKhau.Font = FontHelper.DefaultFormFont;
            UITheme.StyleTextBox(txtMatKhau);
            
            btnDangNhap.Location = new System.Drawing.Point(150, 190);
            btnDangNhap.Width = 110;
            btnDangNhap.Font = FontHelper.DefaultFormFont;
            UITheme.StyleButton(btnDangNhap);
            
            btnThoat.Location = new System.Drawing.Point(270, 190);
            btnThoat.Width = 110;
            btnThoat.Font = FontHelper.DefaultFormFont;
            UITheme.StyleSecondaryButton(btnThoat);
            
            panel.Controls.Add(titleLabel);
            panel.Controls.Add(lblTenDangNhap);
            panel.Controls.Add(txtTenDangNhap);
            panel.Controls.Add(lblMatKhau);
            panel.Controls.Add(txtMatKhau);
            panel.Controls.Add(btnDangNhap);
            panel.Controls.Add(btnThoat);
            
            this.Controls.Clear();
            this.Controls.Add(panel);
            
            panel.Location = new System.Drawing.Point((this.ClientSize.Width - panel.Width) / 2, (this.ClientSize.Height - panel.Height) / 2);
            
            this.Resize += (s, e) =>
            {
                panel.Location = new System.Drawing.Point((this.ClientSize.Width - panel.Width) / 2, (this.ClientSize.Height - panel.Height) / 2);
            };
        }

        private void BtnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                var ten = txtTenDangNhap.Text.Trim();
                var mk = txtMatKhau.Text;
                if (string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(mk))
                {
                    MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.");
                    this.DialogResult = DialogResult.None;
                    return;
                }
                
                using (var db = new QuanLyNhaSachContext())
                {
                    // Load Role cùng với NguoiDung để kiểm tra quyền truy cập
                    var user = db.NguoiDungs
                        .Include("Role")
                        .FirstOrDefault(u => u.TenDangNhap == ten && u.KichHoat);
                    
                    if (user == null)
                    {
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu, hoặc tài khoản bị khóa.");
                        this.DialogResult = DialogResult.None;
                        return;
                    }

                    // Verify mật khẩu với salt
                    if (!PasswordHelper.VerifyPassword(mk, user.MatKhauHash, user.PasswordSalt))
                    {
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu, hoặc tài khoản bị khóa.");
                        this.DialogResult = DialogResult.None;
                        return;
                    }

                    DangNhapThanhCong = user;
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi đăng nhập: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}
