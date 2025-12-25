namespace QLNhaSach
{
    partial class FormNhaXuatBanEdit
    {
        private System.Windows.Forms.Label lblMaNXB;
        private System.Windows.Forms.TextBox txtMaNXB;
        private System.Windows.Forms.Label lblTenNXB;
        private System.Windows.Forms.TextBox txtTenNXB;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblSoDienThoai;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;

        private void InitializeComponent()
        {
            lblMaNXB = new Label();
            txtMaNXB = new TextBox();
            lblTenNXB = new Label();
            txtTenNXB = new TextBox();
            lblDiaChi = new Label();
            txtDiaChi = new TextBox();
            lblSoDienThoai = new Label();
            txtSoDienThoai = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            btnOK = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblMaNXB
            // 
            lblMaNXB.Location = new Point(10, 10);
            lblMaNXB.Name = "lblMaNXB";
            lblMaNXB.Size = new Size(100, 23);
            lblMaNXB.TabIndex = 0;
            lblMaNXB.Text = "Mã NXB";
            // 
            // txtMaNXB
            // 
            txtMaNXB.Location = new Point(120, 10);
            txtMaNXB.Name = "txtMaNXB";
            txtMaNXB.Size = new Size(220, 27);
            txtMaNXB.TabIndex = 1;
            // 
            // lblTenNXB
            // 
            lblTenNXB.Location = new Point(10, 40);
            lblTenNXB.Name = "lblTenNXB";
            lblTenNXB.Size = new Size(100, 23);
            lblTenNXB.TabIndex = 2;
            lblTenNXB.Text = "Tên NXB";
            // 
            // txtTenNXB
            // 
            txtTenNXB.Location = new Point(120, 40);
            txtTenNXB.Name = "txtTenNXB";
            txtTenNXB.Size = new Size(220, 27);
            txtTenNXB.TabIndex = 3;
            // 
            // lblDiaChi
            // 
            lblDiaChi.Location = new Point(10, 70);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(100, 23);
            lblDiaChi.TabIndex = 4;
            lblDiaChi.Text = "Địa chỉ";
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
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(120, 170);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 10;
            btnOK.Text = "OK";
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(200, 170);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Cancel";
            // 
            // FormNhaXuatBanEdit
            // 
            ClientSize = new Size(360, 220);
            Controls.Add(lblMaNXB);
            Controls.Add(txtMaNXB);
            Controls.Add(lblTenNXB);
            Controls.Add(txtTenNXB);
            Controls.Add(lblDiaChi);
            Controls.Add(txtDiaChi);
            Controls.Add(lblSoDienThoai);
            Controls.Add(txtSoDienThoai);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(btnOK);
            Controls.Add(btnCancel);
            Name = "FormNhaXuatBanEdit";
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
            PerformLayout();
        }

    }
}
