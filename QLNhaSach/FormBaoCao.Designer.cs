namespace QLNhaSach
{
    partial class FormBaoCao
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cboLoaiBaoCao;
        private System.Windows.Forms.Label lblLoaiBaoCao;
        private System.Windows.Forms.DateTimePicker dtpNam;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.Button btnTaoBaoCao;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Button btnXuatPDF;
        private System.Windows.Forms.Button btnXuatWord;
        private System.Windows.Forms.Button btnDong;

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
            panelTop = new Panel();
            lblTitle = new Label();
            lblLoaiBaoCao = new Label();
            cboLoaiBaoCao = new ComboBox();
            lblNam = new Label();
            dtpNam = new DateTimePicker();
            btnTaoBaoCao = new Button();
            reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            panelBottom = new Panel();
            btnXuatExcel = new Button();
            btnXuatPDF = new Button();
            btnXuatWord = new Button();
            btnDong = new Button();
            panelTop.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
            
            // panelTop
            panelTop.BackColor = Color.White;
            panelTop.Controls.Add(lblTitle);
            panelTop.Controls.Add(lblLoaiBaoCao);
            panelTop.Controls.Add(cboLoaiBaoCao);
            panelTop.Controls.Add(lblNam);
            panelTop.Controls.Add(dtpNam);
            panelTop.Controls.Add(btnTaoBaoCao);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(10);
            panelTop.Size = new Size(1200, 120);
            panelTop.TabIndex = 0;
            
            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(41, 128, 185);
            lblTitle.Location = new Point(13, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(250, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "BAO CAO VA XUAT DU LIEU";
            
            // lblLoaiBaoCao
            lblLoaiBaoCao.AutoSize = true;
            lblLoaiBaoCao.Location = new Point(13, 50);
            lblLoaiBaoCao.Name = "lblLoaiBaoCao";
            lblLoaiBaoCao.Size = new Size(90, 19);
            lblLoaiBaoCao.TabIndex = 1;
            lblLoaiBaoCao.Text = "Loai bao cao:";
            
            // cboLoaiBaoCao
            cboLoaiBaoCao.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiBaoCao.FormattingEnabled = true;
            cboLoaiBaoCao.Location = new Point(110, 47);
            cboLoaiBaoCao.Name = "cboLoaiBaoCao";
            cboLoaiBaoCao.Size = new Size(300, 27);
            cboLoaiBaoCao.TabIndex = 2;
            
            // lblNam
            lblNam.AutoSize = true;
            lblNam.Location = new Point(430, 50);
            lblNam.Name = "lblNam";
            lblNam.Size = new Size(40, 19);
            lblNam.TabIndex = 3;
            lblNam.Text = "Nam:";
            
            // dtpNam
            dtpNam.CustomFormat = "yyyy";
            dtpNam.Format = DateTimePickerFormat.Custom;
            dtpNam.Location = new Point(476, 47);
            dtpNam.Name = "dtpNam";
            dtpNam.ShowUpDown = true;
            dtpNam.Size = new Size(100, 27);
            dtpNam.TabIndex = 4;
            
            // btnTaoBaoCao
            btnTaoBaoCao.BackColor = Color.FromArgb(41, 128, 185);
            btnTaoBaoCao.FlatStyle = FlatStyle.Flat;
            btnTaoBaoCao.ForeColor = Color.White;
            btnTaoBaoCao.Location = new Point(596, 43);
            btnTaoBaoCao.Name = "btnTaoBaoCao";
            btnTaoBaoCao.Size = new Size(120, 35);
            btnTaoBaoCao.TabIndex = 5;
            btnTaoBaoCao.Text = "Tao bao cao";
            btnTaoBaoCao.UseVisualStyleBackColor = false;
            btnTaoBaoCao.Click += btnTaoBaoCao_Click;
            
            // reportViewer
            reportViewer.Dock = DockStyle.Fill;
            reportViewer.Location = new Point(0, 120);
            reportViewer.Name = "reportViewer";
            reportViewer.ServerReport.BearerToken = null;
            reportViewer.Size = new Size(1200, 480);
            reportViewer.TabIndex = 1;
            
            // panelBottom
            panelBottom.BackColor = Color.White;
            panelBottom.Controls.Add(btnXuatExcel);
            panelBottom.Controls.Add(btnXuatPDF);
            panelBottom.Controls.Add(btnXuatWord);
            panelBottom.Controls.Add(btnDong);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 600);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(10);
            panelBottom.Size = new Size(1200, 60);
            panelBottom.TabIndex = 2;
            
            // btnXuatExcel
            btnXuatExcel.BackColor = Color.FromArgb(39, 174, 96);
            btnXuatExcel.FlatStyle = FlatStyle.Flat;
            btnXuatExcel.ForeColor = Color.White;
            btnXuatExcel.Location = new Point(13, 13);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(130, 35);
            btnXuatExcel.TabIndex = 0;
            btnXuatExcel.Text = "?? Xuat Excel";
            btnXuatExcel.UseVisualStyleBackColor = false;
            btnXuatExcel.Click += btnXuatExcel_Click;
            
            // btnXuatPDF
            btnXuatPDF.BackColor = Color.FromArgb(231, 76, 60);
            btnXuatPDF.FlatStyle = FlatStyle.Flat;
            btnXuatPDF.ForeColor = Color.White;
            btnXuatPDF.Location = new Point(153, 13);
            btnXuatPDF.Name = "btnXuatPDF";
            btnXuatPDF.Size = new Size(130, 35);
            btnXuatPDF.TabIndex = 1;
            btnXuatPDF.Text = "?? Xuat PDF";
            btnXuatPDF.UseVisualStyleBackColor = false;
            btnXuatPDF.Click += btnXuatPDF_Click;
            
            // btnXuatWord
            btnXuatWord.BackColor = Color.FromArgb(52, 152, 219);
            btnXuatWord.FlatStyle = FlatStyle.Flat;
            btnXuatWord.ForeColor = Color.White;
            btnXuatWord.Location = new Point(293, 13);
            btnXuatWord.Name = "btnXuatWord";
            btnXuatWord.Size = new Size(130, 35);
            btnXuatWord.TabIndex = 2;
            btnXuatWord.Text = "?? Xuat Word";
            btnXuatWord.UseVisualStyleBackColor = false;
            btnXuatWord.Click += btnXuatWord_Click;
            
            // btnDong
            btnDong.BackColor = Color.FromArgb(127, 140, 141);
            btnDong.FlatStyle = FlatStyle.Flat;
            btnDong.ForeColor = Color.White;
            btnDong.Location = new Point(1057, 13);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(130, 35);
            btnDong.TabIndex = 3;
            btnDong.Text = "Dong";
            btnDong.UseVisualStyleBackColor = false;
            btnDong.Click += btnDong_Click;
            
            // FormBaoCao
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1200, 660);
            Controls.Add(reportViewer);
            Controls.Add(panelBottom);
            Controls.Add(panelTop);
            Font = new Font("Segoe UI", 10F);
            Name = "FormBaoCao";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bao cao va Xuat du lieu";
            WindowState = FormWindowState.Maximized;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
