namespace QLNhaSach
{
    partial class FormDonHangEdit
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMaDonHang;
        private System.Windows.Forms.TextBox txtMaDonHang;
        private System.Windows.Forms.Label lblMaKH;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Label lblNgayDat;
        private System.Windows.Forms.DateTimePicker dtpNgayDat;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.NumericUpDown nudTongTien;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.TextBox txtTrangThai;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;

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
            lblMaDonHang = new Label();
            txtMaDonHang = new TextBox();
            lblMaKH = new Label();
            txtMaKH = new TextBox();
            lblNgayDat = new Label();
            dtpNgayDat = new DateTimePicker();
            lblTongTien = new Label();
            nudTongTien = new NumericUpDown();
            lblTrangThai = new Label();
            txtTrangThai = new TextBox();
            lblGhiChu = new Label();
            txtGhiChu = new TextBox();
            btnOK = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)nudTongTien).BeginInit();
            SuspendLayout();
            // 
            // lblMaDonHang
            // 
            lblMaDonHang.Location = new Point(10, 10);
            lblMaDonHang.Name = "lblMaDonHang";
            lblMaDonHang.Size = new Size(100, 23);
            lblMaDonHang.TabIndex = 0;
            lblMaDonHang.Text = "Mã đơn hàng";
            // 
            // txtMaDonHang
            // 
            txtMaDonHang.Location = new Point(120, 10);
            txtMaDonHang.Name = "txtMaDonHang";
            txtMaDonHang.Size = new Size(200, 27);
            txtMaDonHang.TabIndex = 1;
            // 
            // lblMaKH
            // 
            lblMaKH.Location = new Point(10, 40);
            lblMaKH.Name = "lblMaKH";
            lblMaKH.Size = new Size(100, 23);
            lblMaKH.TabIndex = 2;
            lblMaKH.Text = "Mã KH";
            // 
            // txtMaKH
            // 
            txtMaKH.Location = new Point(120, 40);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.Size = new Size(200, 27);
            txtMaKH.TabIndex = 3;
            // 
            // lblNgayDat
            // 
            lblNgayDat.Location = new Point(10, 70);
            lblNgayDat.Name = "lblNgayDat";
            lblNgayDat.Size = new Size(100, 23);
            lblNgayDat.TabIndex = 4;
            lblNgayDat.Text = "Ngày đặt";
            // 
            // dtpNgayDat
            // 
            dtpNgayDat.Location = new Point(120, 70);
            dtpNgayDat.Name = "dtpNgayDat";
            dtpNgayDat.Size = new Size(200, 27);
            dtpNgayDat.TabIndex = 5;
            // 
            // lblTongTien
            // 
            lblTongTien.Location = new Point(10, 100);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(100, 23);
            lblTongTien.TabIndex = 6;
            lblTongTien.Text = "Tổng tiền";
            // 
            // nudTongTien
            // 
            nudTongTien.Location = new Point(120, 100);
            nudTongTien.Maximum = new decimal(new int[] { -1, -1, -1, 0 });
            nudTongTien.Name = "nudTongTien";
            nudTongTien.Size = new Size(120, 27);
            nudTongTien.TabIndex = 7;
            // 
            // lblTrangThai
            // 
            lblTrangThai.Location = new Point(10, 130);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(100, 23);
            lblTrangThai.TabIndex = 8;
            lblTrangThai.Text = "Trạng thái";
            // 
            // txtTrangThai
            // 
            txtTrangThai.Location = new Point(120, 130);
            txtTrangThai.Name = "txtTrangThai";
            txtTrangThai.Size = new Size(200, 27);
            txtTrangThai.TabIndex = 9;
            // 
            // lblGhiChu
            // 
            lblGhiChu.Location = new Point(10, 160);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new Size(100, 23);
            lblGhiChu.TabIndex = 10;
            lblGhiChu.Text = "Ghi chú";
            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(120, 160);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(200, 27);
            txtGhiChu.TabIndex = 11;
            // 
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(120, 240);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 12;
            btnOK.Text = "OK";
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(200, 240);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Cancel";
            // 
            // FormDonHangEdit
            // 
            ClientSize = new Size(360, 300);
            Controls.Add(lblMaDonHang);
            Controls.Add(txtMaDonHang);
            Controls.Add(lblMaKH);
            Controls.Add(txtMaKH);
            Controls.Add(lblNgayDat);
            Controls.Add(dtpNgayDat);
            Controls.Add(lblTongTien);
            Controls.Add(nudTongTien);
            Controls.Add(lblTrangThai);
            Controls.Add(txtTrangThai);
            Controls.Add(lblGhiChu);
            Controls.Add(txtGhiChu);
            Controls.Add(btnOK);
            Controls.Add(btnCancel);
            Name = "FormDonHangEdit";
            StartPosition = FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)nudTongTien).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
