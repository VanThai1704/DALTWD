namespace QLNhaSach
{
    partial class FormSachEdit
    {
        private System.Windows.Forms.Label lblMaSach;
        private System.Windows.Forms.TextBox txtMaSach;
        private System.Windows.Forms.Label lblTenSach;
        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.Label lblTacGia;
        private System.Windows.Forms.TextBox txtTacGia;
        private System.Windows.Forms.Label lblNamXuatBan;
        private System.Windows.Forms.NumericUpDown nudNamXuatBan;
        private System.Windows.Forms.Label lblGiaBan;
        private System.Windows.Forms.NumericUpDown nudGiaBan;
        private System.Windows.Forms.Label lblSoLuongTon;
        private System.Windows.Forms.NumericUpDown nudSoLuongTon;
        private System.Windows.Forms.Label lblMaTheLoai;
        private System.Windows.Forms.ComboBox cmbMaTheLoai;
        private System.Windows.Forms.Label lblMaNXB;
        private System.Windows.Forms.ComboBox cmbMaNXB;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;

        private void InitializeComponent()
        {
            lblMaSach = new Label();
            txtMaSach = new TextBox();
            lblTenSach = new Label();
            txtTenSach = new TextBox();
            lblTacGia = new Label();
            txtTacGia = new TextBox();
            lblNamXuatBan = new Label();
            nudNamXuatBan = new NumericUpDown();
            lblGiaBan = new Label();
            nudGiaBan = new NumericUpDown();
            lblSoLuongTon = new Label();
            nudSoLuongTon = new NumericUpDown();
            lblMaTheLoai = new Label();
            lblMaNXB = new Label();
            lblMoTa = new Label();
            txtMoTa = new TextBox();
            btnOK = new Button();
            btnCancel = new Button();
            cmbMaTheLoai = new ComboBox();
            cmbMaNXB = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)nudNamXuatBan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudGiaBan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSoLuongTon).BeginInit();
            SuspendLayout();
            // 
            // lblMaSach
            // 
            lblMaSach.Location = new Point(10, 10);
            lblMaSach.Name = "lblMaSach";
            lblMaSach.Size = new Size(100, 23);
            lblMaSach.TabIndex = 0;
            lblMaSach.Text = "Mã sách";
            // 
            // txtMaSach
            // 
            txtMaSach.Location = new Point(130, 10);
            txtMaSach.Name = "txtMaSach";
            txtMaSach.Size = new Size(260, 27);
            txtMaSach.TabIndex = 1;
            // 
            // lblTenSach
            // 
            lblTenSach.Location = new Point(10, 40);
            lblTenSach.Name = "lblTenSach";
            lblTenSach.Size = new Size(100, 23);
            lblTenSach.TabIndex = 2;
            lblTenSach.Text = "Tên sách";
            // 
            // txtTenSach
            // 
            txtTenSach.Location = new Point(130, 40);
            txtTenSach.Name = "txtTenSach";
            txtTenSach.Size = new Size(260, 27);
            txtTenSach.TabIndex = 3;
            // 
            // lblTacGia
            // 
            lblTacGia.Location = new Point(10, 70);
            lblTacGia.Name = "lblTacGia";
            lblTacGia.Size = new Size(100, 23);
            lblTacGia.TabIndex = 4;
            lblTacGia.Text = "Tác giả";
            // 
            // txtTacGia
            // 
            txtTacGia.Location = new Point(130, 70);
            txtTacGia.Name = "txtTacGia";
            txtTacGia.Size = new Size(260, 27);
            txtTacGia.TabIndex = 5;
            // 
            // lblNamXuatBan
            // 
            lblNamXuatBan.Location = new Point(10, 100);
            lblNamXuatBan.Name = "lblNamXuatBan";
            lblNamXuatBan.Size = new Size(114, 23);
            lblNamXuatBan.TabIndex = 6;
            lblNamXuatBan.Text = "Năm xuất bản";
            // 
            // nudNamXuatBan
            // 
            nudNamXuatBan.Location = new Point(130, 100);
            nudNamXuatBan.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            nudNamXuatBan.Name = "nudNamXuatBan";
            nudNamXuatBan.Size = new Size(120, 27);
            nudNamXuatBan.TabIndex = 7;
            // 
            // lblGiaBan
            // 
            lblGiaBan.Location = new Point(10, 130);
            lblGiaBan.Name = "lblGiaBan";
            lblGiaBan.Size = new Size(100, 23);
            lblGiaBan.TabIndex = 8;
            lblGiaBan.Text = "Giá bán";
            // 
            // nudGiaBan
            // 
            nudGiaBan.Location = new Point(130, 130);
            nudGiaBan.Maximum = new decimal(new int[] { -1, -1, -1, 0 });
            nudGiaBan.Name = "nudGiaBan";
            nudGiaBan.Size = new Size(120, 27);
            nudGiaBan.TabIndex = 9;
            // 
            // lblSoLuongTon
            // 
            lblSoLuongTon.Location = new Point(10, 160);
            lblSoLuongTon.Name = "lblSoLuongTon";
            lblSoLuongTon.Size = new Size(100, 23);
            lblSoLuongTon.TabIndex = 10;
            lblSoLuongTon.Text = "Số lượng tồn";
            // 
            // nudSoLuongTon
            // 
            nudSoLuongTon.Location = new Point(130, 160);
            nudSoLuongTon.Maximum = new decimal(new int[] { -1, -1, -1, 0 });
            nudSoLuongTon.Name = "nudSoLuongTon";
            nudSoLuongTon.Size = new Size(120, 27);
            nudSoLuongTon.TabIndex = 11;
            // 
            // lblMaTheLoai
            // 
            lblMaTheLoai.Location = new Point(10, 190);
            lblMaTheLoai.Name = "lblMaTheLoai";
            lblMaTheLoai.Size = new Size(100, 23);
            lblMaTheLoai.TabIndex = 12;
            lblMaTheLoai.Text = "Mã thể loại";
            // 
            // lblMaNXB
            // 
            lblMaNXB.Location = new Point(10, 220);
            lblMaNXB.Name = "lblMaNXB";
            lblMaNXB.Size = new Size(100, 23);
            lblMaNXB.TabIndex = 14;
            lblMaNXB.Text = "Mã NXB";
            // 
            // lblMoTa
            // 
            lblMoTa.Location = new Point(10, 250);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(100, 23);
            lblMoTa.TabIndex = 16;
            lblMoTa.Text = "Mô tả";
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(130, 250);
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(260, 27);
            txtMoTa.TabIndex = 17;
            // 
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(130, 320);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 18;
            btnOK.Text = "OK";
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(210, 320);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 19;
            btnCancel.Text = "Cancel";
            // 
            // cmbMaTheLoai
            // 
            cmbMaTheLoai.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMaTheLoai.Location = new Point(130, 190);
            cmbMaTheLoai.Name = "cmbMaTheLoai";
            cmbMaTheLoai.Size = new Size(200, 28);
            cmbMaTheLoai.TabIndex = 13;
            // 
            // cmbMaNXB
            // 
            cmbMaNXB.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMaNXB.Location = new Point(130, 220);
            cmbMaNXB.Name = "cmbMaNXB";
            cmbMaNXB.Size = new Size(200, 28);
            cmbMaNXB.TabIndex = 15;
            // 
            // FormSachEdit
            // 
            ClientSize = new Size(420, 360);
            Controls.Add(lblMaSach);
            Controls.Add(txtMaSach);
            Controls.Add(lblTenSach);
            Controls.Add(txtTenSach);
            Controls.Add(lblTacGia);
            Controls.Add(txtTacGia);
            Controls.Add(lblNamXuatBan);
            Controls.Add(nudNamXuatBan);
            Controls.Add(lblGiaBan);
            Controls.Add(nudGiaBan);
            Controls.Add(lblSoLuongTon);
            Controls.Add(nudSoLuongTon);
            Controls.Add(lblMaTheLoai);
            Controls.Add(cmbMaTheLoai);
            Controls.Add(lblMaNXB);
            Controls.Add(cmbMaNXB);
            Controls.Add(lblMoTa);
            Controls.Add(txtMoTa);
            Controls.Add(btnOK);
            Controls.Add(btnCancel);
            Name = "FormSachEdit";
            StartPosition = FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)nudNamXuatBan).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudGiaBan).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSoLuongTon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
