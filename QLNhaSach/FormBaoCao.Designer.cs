using System.Drawing;
using System.Windows.Forms;

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
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblLoaiBaoCao = new System.Windows.Forms.Label();
            this.cboLoaiBaoCao = new System.Windows.Forms.ComboBox();
            this.lblNam = new System.Windows.Forms.Label();
            this.dtpNam = new System.Windows.Forms.DateTimePicker();
            this.btnTaoBaoCao = new System.Windows.Forms.Button();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnXuatPDF = new System.Windows.Forms.Button();
            this.btnXuatWord = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Controls.Add(this.lblLoaiBaoCao);
            this.panelTop.Controls.Add(this.cboLoaiBaoCao);
            this.panelTop.Controls.Add(this.lblNam);
            this.panelTop.Controls.Add(this.dtpNam);
            this.panelTop.Controls.Add(this.btnTaoBaoCao);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(10);
            this.panelTop.Size = new System.Drawing.Size(1100, 120);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblTitle.Location = new System.Drawing.Point(13, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(332, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "BÁO CÁO VÀ XUẤT DỮ LIỆU";
            // 
            // lblLoaiBaoCao
            // 
            this.lblLoaiBaoCao.AutoSize = true;
            this.lblLoaiBaoCao.Location = new System.Drawing.Point(13, 44);
            this.lblLoaiBaoCao.Name = "lblLoaiBaoCao";
            this.lblLoaiBaoCao.Size = new System.Drawing.Size(111, 23);
            this.lblLoaiBaoCao.TabIndex = 1;
            this.lblLoaiBaoCao.Text = "Loại báo cáo:";
            // 
            // cboLoaiBaoCao
            // 
            this.cboLoaiBaoCao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiBaoCao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLoaiBaoCao.FormattingEnabled = true;
            this.cboLoaiBaoCao.Location = new System.Drawing.Point(130, 47);
            this.cboLoaiBaoCao.Name = "cboLoaiBaoCao";
            this.cboLoaiBaoCao.Size = new System.Drawing.Size(300, 31);
            this.cboLoaiBaoCao.TabIndex = 2;
            // 
            // lblNam
            // 
            this.lblNam.AutoSize = true;
            this.lblNam.Location = new System.Drawing.Point(449, 43);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(51, 23);
            this.lblNam.TabIndex = 3;
            this.lblNam.Text = "Năm:";
            // 
            // dtpNam
            // 
            this.dtpNam.CustomFormat = "yyyy";
            this.dtpNam.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNam.Location = new System.Drawing.Point(516, 44);
            this.dtpNam.Name = "dtpNam";
            this.dtpNam.ShowUpDown = true;
            this.dtpNam.Size = new System.Drawing.Size(100, 30);
            this.dtpNam.TabIndex = 4;
            // 
            // btnTaoBaoCao
            // 
            this.btnTaoBaoCao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnTaoBaoCao.FlatAppearance.BorderSize = 0;
            this.btnTaoBaoCao.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnTaoBaoCao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))), ((int)(((byte)(220)))));
            this.btnTaoBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoBaoCao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTaoBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnTaoBaoCao.Location = new System.Drawing.Point(633, 43);
            this.btnTaoBaoCao.Name = "btnTaoBaoCao";
            this.btnTaoBaoCao.Size = new System.Drawing.Size(120, 35);
            this.btnTaoBaoCao.TabIndex = 5;
            this.btnTaoBaoCao.Text = "[>] Tạo báo cáo";
            this.btnTaoBaoCao.UseVisualStyleBackColor = false;
            this.btnTaoBaoCao.Click += new System.EventHandler(this.btnTaoBaoCao_Click);
            // 
            // reportViewer
            // 
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer.Location = new System.Drawing.Point(0, 120);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(1100, 488);
            this.reportViewer.TabIndex = 1;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.White;
            this.panelBottom.Controls.Add(this.btnXuatExcel);
            this.panelBottom.Controls.Add(this.btnXuatPDF);
            this.panelBottom.Controls.Add(this.btnXuatWord);
            this.panelBottom.Controls.Add(this.btnDong);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 608);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Padding = new System.Windows.Forms.Padding(10);
            this.panelBottom.Size = new System.Drawing.Size(1100, 60);
            this.panelBottom.TabIndex = 2;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnXuatExcel.FlatAppearance.BorderSize = 0;
            this.btnXuatExcel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnXuatExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))), ((int)(((byte)(220)))));
            this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXuatExcel.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcel.Location = new System.Drawing.Point(28, 6);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(130, 35);
            this.btnXuatExcel.TabIndex = 0;
            this.btnXuatExcel.Text = "[E] Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = false;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // btnXuatPDF
            // 
            this.btnXuatPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnXuatPDF.FlatAppearance.BorderSize = 0;
            this.btnXuatPDF.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnXuatPDF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))), ((int)(((byte)(220)))));
            this.btnXuatPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatPDF.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXuatPDF.ForeColor = System.Drawing.Color.White;
            this.btnXuatPDF.Location = new System.Drawing.Point(164, 6);
            this.btnXuatPDF.Name = "btnXuatPDF";
            this.btnXuatPDF.Size = new System.Drawing.Size(130, 35);
            this.btnXuatPDF.TabIndex = 1;
            this.btnXuatPDF.Text = "[P] Xuất PDF";
            this.btnXuatPDF.UseVisualStyleBackColor = false;
            this.btnXuatPDF.Click += new System.EventHandler(this.btnXuatPDF_Click);
            // 
            // btnXuatWord
            // 
            this.btnXuatWord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnXuatWord.FlatAppearance.BorderSize = 0;
            this.btnXuatWord.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnXuatWord.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))), ((int)(((byte)(220)))));
            this.btnXuatWord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatWord.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXuatWord.ForeColor = System.Drawing.Color.White;
            this.btnXuatWord.Location = new System.Drawing.Point(300, 6);
            this.btnXuatWord.Name = "btnXuatWord";
            this.btnXuatWord.Size = new System.Drawing.Size(130, 35);
            this.btnXuatWord.TabIndex = 2;
            this.btnXuatWord.Text = "[W] Xuất Word";
            this.btnXuatWord.UseVisualStyleBackColor = false;
            this.btnXuatWord.Click += new System.EventHandler(this.btnXuatWord_Click);
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.btnDong.FlatAppearance.BorderSize = 0;
            this.btnDong.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnDong.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))), ((int)(((byte)(220)))));
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(957, 6);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(130, 35);
            this.btnDong.TabIndex = 3;
            this.btnDong.Text = "[x] Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FormBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1100, 668);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FormBaoCao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo và Xuất dữ liệu";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
