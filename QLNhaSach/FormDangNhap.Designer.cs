namespace QLNhaSach
{
    partial class FormDangNhap
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTenDangNhap;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Button btnThoat;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTenDangNhap = new Label();
            txtTenDangNhap = new TextBox();
            lblMatKhau = new Label();
            txtMatKhau = new TextBox();
            btnDangNhap = new Button();
            btnThoat = new Button();
            SuspendLayout();
            // 
            // lblTenDangNhap
            // 
            lblTenDangNhap.Location = new Point(20, 20);
            lblTenDangNhap.Name = "lblTenDangNhap";
            lblTenDangNhap.Size = new Size(114, 23);
            lblTenDangNhap.TabIndex = 0;
            lblTenDangNhap.Text = "Tên đăng nhập";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Location = new Point(140, 20);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(180, 27);
            txtTenDangNhap.TabIndex = 1;
            // 
            // lblMatKhau
            // 
            lblMatKhau.Location = new Point(20, 60);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(100, 23);
            lblMatKhau.TabIndex = 2;
            lblMatKhau.Text = "Mật khẩu";
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(140, 60);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.Size = new Size(180, 27);
            txtMatKhau.TabIndex = 3;
            // 
            // btnDangNhap
            // 
            btnDangNhap.DialogResult = DialogResult.OK;
            btnDangNhap.Location = new Point(140, 110);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(90, 28);
            btnDangNhap.TabIndex = 4;
            btnDangNhap.Text = "Đăng nhập";
            // 
            // btnThoat
            // 
            btnThoat.DialogResult = DialogResult.Cancel;
            btnThoat.Location = new Point(230, 110);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(90, 28);
            btnThoat.TabIndex = 5;
            btnThoat.Text = "Thoát";
            // 
            // FormDangNhap
            // 
            ClientSize = new Size(360, 170);
            Controls.Add(lblTenDangNhap);
            Controls.Add(txtTenDangNhap);
            Controls.Add(lblMatKhau);
            Controls.Add(txtMatKhau);
            Controls.Add(btnDangNhap);
            Controls.Add(btnThoat);
            Name = "FormDangNhap";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Đăng nhập hệ thống";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
