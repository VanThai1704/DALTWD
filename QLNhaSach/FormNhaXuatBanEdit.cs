using System;
using System.Linq;
using System.Windows.Forms;
using QLNhaSach.Models;

namespace QLNhaSach
{
    public partial class FormNhaXuatBanEdit : Form
    {
        private string _id;
        public FormNhaXuatBanEdit() : this(null) { }
        public FormNhaXuatBanEdit(string id)
        {
            _id = id;
            InitializeComponent();
            this.ApplyVietnameseFont();
            if (!string.IsNullOrEmpty(_id)) LoadData();
            this.btnOK.Click += BtnOK_Click;
        }

        private void LoadData()
        {
            try
            {
                using var db = new QuanLyNhaSachContext();
                var n = db.NhaXuatBans.Find(_id);
                if (n == null) return;
                txtMaNXB.Text = n.MaNXB;
                txtTenNXB.Text = n.TenNXB;
                txtDiaChi.Text = n.DiaChi;
                txtSoDienThoai.Text = n.SoDienThoai;
                txtEmail.Text = n.Email;
                txtMaNXB.Enabled = false;
            }
            catch (Exception ex) { MessageBox.Show($"L?i khi t?i NXB: {ex.Message}"); }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNXB.Text)) { MessageBox.Show("Mã NXB không ???c ?? tr?ng"); this.DialogResult = DialogResult.None; return; }
            try
            {
                using var db = new QuanLyNhaSachContext();
                if (string.IsNullOrEmpty(_id))
                {
                    var n = new NhaXuatBan { MaNXB = txtMaNXB.Text.Trim(), TenNXB = txtTenNXB.Text.Trim(), DiaChi = txtDiaChi.Text.Trim(), SoDienThoai = txtSoDienThoai.Text.Trim(), Email = txtEmail.Text.Trim() };
                    db.NhaXuatBans.Add(n);
                }
                else
                {
                    var n = db.NhaXuatBans.Find(_id);
                    if (n != null)
                    {
                        n.TenNXB = txtTenNXB.Text.Trim();
                        n.DiaChi = txtDiaChi.Text.Trim();
                        n.SoDienThoai = txtSoDienThoai.Text.Trim();
                        n.Email = txtEmail.Text.Trim();
                    }
                }
                db.SaveChanges();
            }
            catch (Exception ex) { MessageBox.Show($"L?i khi l?u: {ex.Message}"); this.DialogResult = DialogResult.None; }
        }
    }
}
