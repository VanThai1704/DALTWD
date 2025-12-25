namespace QLNhaSach
{
    partial class FormNguoiDungEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTenDangNhap = new Label();
            txtTenDangNhap = new TextBox();
            lblMatKhau = new Label();
            txtMatKhau = new TextBox();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblRole = new Label();
            clbRoles = new CheckedListBox();
            chkKichHoat = new CheckBox();
            btnOK = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTenDangNhap
            // 
            lblTenDangNhap.AutoSize = true;
            lblTenDangNhap.Location = new Point(30, 30);
            lblTenDangNhap.Name = "lblTenDangNhap";
            lblTenDangNhap.Size = new Size(109, 18);
            lblTenDangNhap.TabIndex = 0;
            lblTenDangNhap.Text = "Tên đăng nhập";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Location = new Point(180, 27);
            txtTenDangNhap.MaxLength = 50;
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(300, 26);
            txtTenDangNhap.TabIndex = 1;
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.Location = new Point(30, 70);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(69, 18);
            lblMatKhau.TabIndex = 2;
            lblMatKhau.Text = "Mật khẩu";
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(180, 67);
            txtMatKhau.MaxLength = 100;
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.Size = new Size(300, 26);
            txtMatKhau.TabIndex = 3;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(30, 110);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(52, 18);
            lblHoTen.TabIndex = 4;
            lblHoTen.Text = "Họ tên";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(180, 107);
            txtHoTen.MaxLength = 200;
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(300, 26);
            txtHoTen.TabIndex = 5;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(30, 150);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(130, 18);
            lblRole.TabIndex = 6;
            lblRole.Text = "Vai trò (Bắt buộc):";
            // 
            // clbRoles
            // 
            clbRoles.FormattingEnabled = true;
            clbRoles.Location = new Point(180, 150);
            clbRoles.Name = "clbRoles";
            clbRoles.Size = new Size(300, 88);
            clbRoles.TabIndex = 7;
            // 
            // chkKichHoat
            // 
            chkKichHoat.AutoSize = true;
            chkKichHoat.Checked = true;
            chkKichHoat.CheckState = CheckState.Checked;
            chkKichHoat.Location = new Point(180, 270);
            chkKichHoat.Name = "chkKichHoat";
            chkKichHoat.Size = new Size(90, 22);
            chkKichHoat.TabIndex = 8;
            chkKichHoat.Text = "Kích hoạt";
            chkKichHoat.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(180, 315);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(100, 35);
            btnOK.TabIndex = 9;
            btnOK.Text = "Lưu";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(300, 315);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // FormNguoiDungEdit
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(520, 375);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(chkKichHoat);
            Controls.Add(clbRoles);
            Controls.Add(lblRole);
            Controls.Add(txtHoTen);
            Controls.Add(lblHoTen);
            Controls.Add(txtMatKhau);
            Controls.Add(lblMatKhau);
            Controls.Add(txtTenDangNhap);
            Controls.Add(lblTenDangNhap);
            Font = new Font("Tahoma", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormNguoiDungEdit";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thông tin người dùng";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTenDangNhap;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.CheckedListBox clbRoles;
        private System.Windows.Forms.CheckBox chkKichHoat;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}
