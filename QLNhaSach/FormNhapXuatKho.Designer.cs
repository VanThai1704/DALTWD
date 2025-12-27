using System.Drawing;
using System.Windows.Forms;

namespace QLNhaSach
{
    partial class FormNhapXuatKho
    {
        private System.ComponentModel.IContainer components = null;

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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            groupBox1 = new GroupBox();
            lblWarning = new Label();
            btnXuatKho = new Button();
            btnNhapKho = new Button();
            lblTonKhoHienTai = new Label();
            txtGhiChu = new TextBox();
            numSoLuong = new NumericUpDown();
            cboMaSach = new ComboBox();
            groupBox2 = new GroupBox();
            dataGridView1 = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 30);
            label1.Name = "label1";
            label1.Size = new Size(104, 18);
            label1.TabIndex = 0;
            label1.Text = "📚 Chọn sách:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 95);
            label2.Name = "label2";
            label2.Size = new Size(92, 18);
            label2.TabIndex = 2;
            label2.Text = "🔢 Số lượng:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 130);
            label3.Name = "label3";
            label3.Size = new Size(84, 18);
            label3.TabIndex = 4;
            label3.Text = "📝 Ghi chú:";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(lblWarning);
            groupBox1.Controls.Add(btnXuatKho);
            groupBox1.Controls.Add(btnNhapKho);
            groupBox1.Controls.Add(lblTonKhoHienTai);
            groupBox1.Controls.Add(txtGhiChu);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(numSoLuong);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cboMaSach);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(960, 210);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "📦 Thông tin Nhập/Xuất";
            // 
            // lblWarning
            // 
            lblWarning.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblWarning.AutoSize = true;
            lblWarning.Font = new Font("Tahoma", 9F, FontStyle.Bold);
            lblWarning.ForeColor = SystemColors.ControlText;
            lblWarning.Location = new Point(460, 173);
            lblWarning.Name = "lblWarning";
            lblWarning.Size = new Size(0, 18);
            lblWarning.TabIndex = 9;
            // 
            // btnXuatKho
            // 
            btnXuatKho.BackColor = Color.FromArgb(255, 160, 122);
            btnXuatKho.Cursor = Cursors.Hand;
            btnXuatKho.Font = new Font("Tahoma", 9F, FontStyle.Bold);
            btnXuatKho.ForeColor = Color.DarkRed;
            btnXuatKho.Location = new Point(290, 165);
            btnXuatKho.Name = "btnXuatKho";
            btnXuatKho.Size = new Size(150, 35);
            btnXuatKho.TabIndex = 8;
            btnXuatKho.Text = "⬆ XUẤT KHO";
            btnXuatKho.UseVisualStyleBackColor = false;
            btnXuatKho.Click += btnXuatKho_Click;
            // 
            // btnNhapKho
            // 
            btnNhapKho.BackColor = Color.FromArgb(144, 238, 144);
            btnNhapKho.Cursor = Cursors.Hand;
            btnNhapKho.Font = new Font("Tahoma", 9F, FontStyle.Bold);
            btnNhapKho.ForeColor = Color.DarkGreen;
            btnNhapKho.Location = new Point(120, 165);
            btnNhapKho.Name = "btnNhapKho";
            btnNhapKho.Size = new Size(150, 35);
            btnNhapKho.TabIndex = 7;
            btnNhapKho.Text = "⬇ NHẬP KHO";
            btnNhapKho.UseVisualStyleBackColor = false;
            btnNhapKho.Click += btnNhapKho_Click;
            // 
            // lblTonKhoHienTai
            // 
            lblTonKhoHienTai.AutoSize = true;
            lblTonKhoHienTai.Font = new Font("Tahoma", 9F, FontStyle.Bold);
            lblTonKhoHienTai.ForeColor = Color.Green;
            lblTonKhoHienTai.Location = new Point(120, 60);
            lblTonKhoHienTai.Name = "lblTonKhoHienTai";
            lblTonKhoHienTai.Size = new Size(168, 18);
            lblTonKhoHienTai.TabIndex = 6;
            lblTonKhoHienTai.Text = "📊 Tồn kho hiện tại: 0";
            // 
            // txtGhiChu
            // 
            txtGhiChu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtGhiChu.Location = new Point(120, 127);
            txtGhiChu.MaxLength = 300;
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(810, 26);
            txtGhiChu.TabIndex = 5;
            // 
            // numSoLuong
            // 
            numSoLuong.Location = new Point(120, 92);
            numSoLuong.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numSoLuong.Name = "numSoLuong";
            numSoLuong.Size = new Size(150, 26);
            numSoLuong.TabIndex = 3;
            numSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cboMaSach
            // 
            cboMaSach.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboMaSach.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMaSach.FormattingEnabled = true;
            cboMaSach.Location = new Point(120, 27);
            cboMaSach.Name = "cboMaSach";
            cboMaSach.Size = new Size(810, 26);
            cboMaSach.TabIndex = 1;
            cboMaSach.SelectedIndexChanged += cboMaSach_SelectedIndexChanged;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Location = new Point(12, 228);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(960, 320);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "📋 Lịch sử giao dịch kho";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 25);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(948, 289);
            dataGridView1.TabIndex = 0;
            // 
            // FormNhapXuatKho
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new Font("Tahoma", 9F);
            MinimumSize = new Size(1000, 600);
            Name = "FormNhapXuatKho";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "📦 Quản lý Kho";
            Load += FormNhapXuatKho_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);

        }

        private System.Windows.Forms.ComboBox cboMaSach;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label lblTonKhoHienTai;
        private System.Windows.Forms.Button btnNhapKho;
        private System.Windows.Forms.Button btnXuatKho;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
