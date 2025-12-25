using System;
using System.Linq;
using System.Windows.Forms;
using QLNhaSach.Models;
using Microsoft.EntityFrameworkCore;

namespace QLNhaSach
{
    public partial class FormSachEdit : Form
    {
        private string _id;
        public FormSachEdit() : this(null) { }
        public FormSachEdit(string id)
        {
            _id = id;
            InitializeComponent();
            this.ApplyVietnameseFont();
            LoadLookups();
            if (!string.IsNullOrEmpty(_id)) LoadData();
            this.btnOK.Click += BtnOK_Click;
        }

        private void LoadLookups()
        {
            try
            {
                using var db = new QuanLyNhaSachContext();
                var theloais = db.TheLoais.AsNoTracking().Select(t => t.MaTheLoai).ToList();
                var nxbs = db.NhaXuatBans.AsNoTracking().Select(n => n.MaNXB).ToList();
                if (cmbMaTheLoai != null)
                {
                    cmbMaTheLoai.Items.Clear();
                    foreach (var t in theloais) cmbMaTheLoai.Items.Add(t);
                }
                if (cmbMaNXB != null)
                {
                    cmbMaNXB.Items.Clear();
                    foreach (var n in nxbs) cmbMaNXB.Items.Add(n);
                }
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine("LoadLookups failed: " + ex); }
        }

        private void LoadData()
        {
            try
            {
                using var db = new QuanLyNhaSachContext();
                var s = db.Saches.Find(_id);
                if (s == null) return;
                txtMaSach.Text = s.MaSach;
                txtTenSach.Text = s.TenSach;
                txtTacGia.Text = s.TacGia;
                nudNamXuatBan.Value = s.NamXuatBan ?? 0;
                nudGiaBan.Value = s.GiaBan;
                nudSoLuongTon.Value = s.SoLuongTon;
                if (cmbMaTheLoai != null) cmbMaTheLoai.SelectedItem = s.MaTheLoai;
                if (cmbMaNXB != null) cmbMaNXB.SelectedItem = s.MaNXB;
                txtMoTa.Text = s.MoTa;
                txtMaSach.Enabled = false;
            }
            catch (Exception ex) { MessageBox.Show($"L?i khi t?i sách: {ex.Message}"); }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSach.Text)) { MessageBox.Show("Mã sách không ???c ?? tr?ng"); this.DialogResult = DialogResult.None; return; }
            try
            {
                using var db = new QuanLyNhaSachContext();
                if (string.IsNullOrEmpty(_id))
                {
                    var s = new Sach
                    {
                        MaSach = txtMaSach.Text.Trim(),
                        TenSach = txtTenSach.Text.Trim(),
                        TacGia = txtTacGia.Text.Trim(),
                        NamXuatBan = (int?)nudNamXuatBan.Value,
                        GiaBan = nudGiaBan.Value,
                        SoLuongTon = (int)nudSoLuongTon.Value,
                        MaTheLoai = cmbMaTheLoai?.SelectedItem?.ToString() ?? string.Empty,
                        MaNXB = cmbMaNXB?.SelectedItem?.ToString() ?? string.Empty,
                        MoTa = txtMoTa.Text.Trim()
                    };
                    db.Saches.Add(s);
                }
                else
                {
                    var s = db.Saches.Find(_id);
                    if (s != null)
                    {
                        s.TenSach = txtTenSach.Text.Trim();
                        s.TacGia = txtTacGia.Text.Trim();
                        s.NamXuatBan = (int?)nudNamXuatBan.Value;
                        s.GiaBan = nudGiaBan.Value;
                        s.SoLuongTon = (int)nudSoLuongTon.Value;
                        s.MaTheLoai = cmbMaTheLoai?.SelectedItem?.ToString() ?? string.Empty;
                        s.MaNXB = cmbMaNXB?.SelectedItem?.ToString() ?? string.Empty;
                        s.MoTa = txtMoTa.Text.Trim();
                    }
                }
                db.SaveChanges();
            }
            catch (Exception ex) { MessageBox.Show($"L?i khi l?u: {ex.Message}"); this.DialogResult = DialogResult.None; }
        }
    }
}
