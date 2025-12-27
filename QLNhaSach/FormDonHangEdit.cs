using System;
using System.Linq;
using System.Windows.Forms;
using QLNhaSach.Models;

namespace QLNhaSach
{
    public partial class FormDonHangEdit : Form
    {
        private string _id;
        public FormDonHangEdit() : this(null) { }
        public FormDonHangEdit(string id)
        {
            _id = id;
            InitializeComponent();
            // Apply Vietnamese-capable font to dialog controls
            this.ApplyVietnameseFont();
            UITheme.ApplyTheme(this);
            // Reassign UI strings with normalized Unicode at runtime to avoid any designer encoding issues
            try
            {
                lblMaDonHang.Text = string.Intern("Mã đơn hàng").Normalize(System.Text.NormalizationForm.FormC);
                lblMaKH.Text = string.Intern("Mã KH").Normalize(System.Text.NormalizationForm.FormC);
                lblNgayDat.Text = string.Intern("Ngày đặt").Normalize(System.Text.NormalizationForm.FormC);
                lblTongTien.Text = string.Intern("Tổng tiền").Normalize(System.Text.NormalizationForm.FormC);
                lblTrangThai.Text = string.Intern("Trạng thái").Normalize(System.Text.NormalizationForm.FormC);
                lblGhiChu.Text = string.Intern("Ghi chú").Normalize(System.Text.NormalizationForm.FormC);
                btnOK.Text = string.Intern("OK");
                btnCancel.Text = string.Intern("Cancel");
                this.Text = string.Intern(_id == null ? "Thêm đơn hàng" : "Sửa đơn hàng").Normalize(System.Text.NormalizationForm.FormC);
            }
            catch { }

            LoadData();
            this.btnOK.Click += BtnOK_Click;
        }

        private void LoadData()
        {
            if (string.IsNullOrEmpty(_id)) return;
            try
            {
                using var db = new QuanLyNhaSachContext();
                var d = db.DonHangs.Find(_id);
                if (d == null) return;
                txtMaDonHang.Text = d.MaDonHang;
                txtMaKH.Text = d.MaKH;
                dtpNgayDat.Value = d.NgayDat;
                nudTongTien.Value = d.TongTien ?? 0m;
                txtTrangThai.Text = d.TrangThai;
                txtGhiChu.Text = d.GhiChu;
                txtMaDonHang.Enabled = false; // PK not editable
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải đơn: {ex.Message}");
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            // Basic validation
            if (string.IsNullOrWhiteSpace(txtMaDonHang.Text))
            {
                MessageBox.Show("Mã đơn hàng không được để trống");
                this.DialogResult = DialogResult.None;
                return;
            }

            try
            {
                using var db = new QuanLyNhaSachContext();
                if (string.IsNullOrEmpty(_id))
                {
                    var d = new DonHang
                    {
                        MaDonHang = txtMaDonHang.Text.Trim(),
                        MaKH = txtMaKH.Text.Trim(),
                        NgayDat = dtpNgayDat.Value,
                        TongTien = nudTongTien.Value,
                        TrangThai = txtTrangThai.Text.Trim(),
                        GhiChu = txtGhiChu.Text.Trim()
                    };
                    db.DonHangs.Add(d);
                }
                else
                {
                    var d = db.DonHangs.Find(_id);
                    if (d != null)
                    {
                        d.MaKH = txtMaKH.Text.Trim();
                        d.NgayDat = dtpNgayDat.Value;
                        d.TongTien = nudTongTien.Value;
                        d.TrangThai = txtTrangThai.Text.Trim();
                        d.GhiChu = txtGhiChu.Text.Trim();
                    }
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu: {ex.Message}");
                this.DialogResult = DialogResult.None;
            }
        }
    }
}
