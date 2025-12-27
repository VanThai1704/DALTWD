using System.Drawing;
using System.Windows.Forms;

namespace QLNhaSach
{
    partial class FormKhachHangEdit
    {
        private System.Windows.Forms.Label lblMaKH;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Label lblTenKH;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblSoDienThoai;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblNgayDangKy;
        private System.Windows.Forms.DateTimePicker dtpNgayDangKy;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;

        private void InitializeComponent()
        {
            lblMaKH = new Label();
            txtMaKH = new TextBox();
            lblTenKH = new Label();
            txtTenKH = new TextBox();
            lblDiaChi = new Label();
            txtDiaChi = new TextBox();
            lblSoDienThoai = new Label();
            txtSoDienThoai = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblNgayDangKy = new Label();
            dtpNgayDangKy = new DateTimePicker();
            btnOK = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblMaKH
            // 
            lblMaKH.Location = new Point(10, 10);
            lblMaKH.Name = "lblMaKH";
            lblMaKH.Size = new Size(100, 23);
            lblMaKH.TabIndex = 0;
            lblMaKH.Text = "Mã KH";
            // 
            // txtMaKH
            // 
            txtMaKH.Location = new Point(120, 10);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.Size = new Size(220, 27);
            txtMaKH.TabIndex = 1;
            // 
            // lblTenKH
            // 
            lblTenKH.Location = new Point(10, 40);
            lblTenKH.Name = "lblTenKH";
            lblTenKH.Size = new Size(100, 23);
            lblTenKH.TabIndex = 2;
            lblTenKH.Text = "Tên KH";
            // 
            // txtTenKH
            // 
            txtTenKH.Location = new Point(120, 40);
            txtTenKH.Name = "txtTenKH";
            txtTenKH.Size = new Size(220, 27);
            txtTenKH.TabIndex = 3;
            // 
            // lblDiaChi
            // 
            lblDiaChi.Location = new Point(10, 70);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(100, 23);
            lblDiaChi.TabIndex = 4;
            lblDiaChi.Text = "??a ch?";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(120, 70);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(220, 27);
            txtDiaChi.TabIndex = 5;
            // 
            // lblSoDienThoai
            // 
            lblSoDienThoai.Location = new Point(10, 100);
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.Size = new Size(100, 23);
            lblSoDienThoai.TabIndex = 6;
            lblSoDienThoai.Text = "Số điện thoại";
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Location = new Point(120, 100);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(220, 27);
            txtSoDienThoai.TabIndex = 7;
            // 
            // lblEmail
            // 
            lblEmail.Location = new Point(10, 130);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(100, 23);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(120, 130);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(220, 27);
            txtEmail.TabIndex = 9;
            // 
            // lblNgayDangKy
            // 
            lblNgayDangKy.Location = new Point(10, 160);
            lblNgayDangKy.Name = "lblNgayDangKy";
            lblNgayDangKy.Size = new Size(100, 23);
            lblNgayDangKy.TabIndex = 10;
            lblNgayDangKy.Text = "Ngày đăng ký";
            // 
            // dtpNgayDangKy
            // 
            dtpNgayDangKy.Location = new Point(120, 160);
            dtpNgayDangKy.Name = "dtpNgayDangKy";
            dtpNgayDangKy.Size = new Size(200, 27);
            dtpNgayDangKy.TabIndex = 11;
            // 
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(120, 200);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 12;
            btnOK.Text = "OK";
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(200, 200);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Cancel";
            // 
            // FormKhachHangEdit
            // 
            ClientSize = new Size(360, 250);
            Controls.Add(lblMaKH);
            Controls.Add(txtMaKH);
            Controls.Add(lblTenKH);
            Controls.Add(txtTenKH);
            Controls.Add(lblDiaChi);
            Controls.Add(txtDiaChi);
            Controls.Add(lblSoDienThoai);
            Controls.Add(txtSoDienThoai);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblNgayDangKy);
            Controls.Add(dtpNgayDangKy);
            Controls.Add(btnOK);
            Controls.Add(btnCancel);
            Name = "FormKhachHangEdit";
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
