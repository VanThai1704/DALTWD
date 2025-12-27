using System;
using System.Linq;
using System.Windows.Forms;
using QLNhaSach.Models;

namespace QLNhaSach
{
    public partial class FormKhachHangEdit : Form
    {
        private string _id;
        public FormKhachHangEdit() : this(null) { }
        public FormKhachHangEdit(string id)
        {
            _id = id;
            InitializeComponent();
            this.ApplyVietnameseFont();
            UITheme.ApplyTheme(this);
            if (!string.IsNullOrEmpty(_id)) LoadData();
            this.btnOK.Click += BtnOK_Click;
        }

        private void LoadData()
        {
            try
            {
                using var db = new QuanLyNhaSachContext();
                var obj = db.KhachHangs.Find(_id);
                if (obj == null) return;
                txtMaKH.Text = obj.MaKH;
                txtTenKH.Text = obj.TenKH;
                txtDiaChi.Text = obj.DiaChi;
                txtSoDienThoai.Text = obj.SoDienThoai;
                txtEmail.Text = obj.Email;
                dtpNgayDangKy.Value = obj.NgayDangKy;
                txtMaKH.Enabled = false;
            }
            catch (Exception ex) { MessageBox.Show($"L?i khi t?i khách hàng: {ex.Message}"); }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text)) { MessageBox.Show("Mã KH không ???c ?? tr?ng"); this.DialogResult = DialogResult.None; return; }
            try
            {
                using var db = new QuanLyNhaSachContext();
                if (string.IsNullOrEmpty(_id))
                {
                    var k = new KhachHang { MaKH = txtMaKH.Text.Trim(), TenKH = txtTenKH.Text.Trim(), DiaChi = txtDiaChi.Text.Trim(), SoDienThoai = txtSoDienThoai.Text.Trim(), Email = txtEmail.Text.Trim(), NgayDangKy = dtpNgayDangKy.Value };
                    db.KhachHangs.Add(k);
                }
                else
                {
                    var k = db.KhachHangs.Find(_id);
                    if (k != null)
                    {
                        k.TenKH = txtTenKH.Text.Trim();
                        k.DiaChi = txtDiaChi.Text.Trim();
                        k.SoDienThoai = txtSoDienThoai.Text.Trim();
                        k.Email = txtEmail.Text.Trim();
                        k.NgayDangKy = dtpNgayDangKy.Value;
                    }
                }
                db.SaveChanges();
            }
            catch (Exception ex) { MessageBox.Show($"L?i khi l?u: {ex.Message}"); this.DialogResult = DialogResult.None; }
        }
    }
}
