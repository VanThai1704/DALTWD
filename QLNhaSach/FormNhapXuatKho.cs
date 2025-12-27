using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using QLNhaSach.Models;
using System.Data.SqlClient;

namespace QLNhaSach
{
    public partial class FormNhapXuatKho : Form
    {
        private readonly NguoiDung _currentUser;

        public FormNhapXuatKho(NguoiDung currentUser = null)
        {
            _currentUser = currentUser;
            InitializeComponent();
            this.ApplyVietnameseFont();
            UITheme.ApplyTheme(this);
            
            // Thiết lập ComboBox trước khi load dữ liệu
            cboMaSach.DropDownStyle = ComboBoxStyle.DropDownList;
            
            LoadSach();
            ApplyPermissions();
        }

        /// <summary>
        /// Phân quyền: Chỉ Admin và Quản lý mới được nhập/xuất kho
        /// </summary>
        private void ApplyPermissions()
        {
            bool canManageStock = RolePermissions.IsAdmin(_currentUser) || 
                                  RolePermissions.IsQuanLy(_currentUser);

            btnNhapKho.Enabled = canManageStock;
            btnXuatKho.Enabled = canManageStock;

            if (!canManageStock)
            {
                lblWarning.Text = "⚠️ Bạn chỉ có quyền xem lịch sử tồn kho";
                lblWarning.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void LoadSach()
        {
            try
            {
                using var db = new QuanLyNhaSachContext();
                var saches = db.Saches
                    .AsNoTracking()
                    .Where(s => !string.IsNullOrEmpty(s.MaSach) && !string.IsNullOrEmpty(s.TenSach))
                    .OrderBy(s => s.TenSach)
                    .Select(s => new SachComboItem 
                    { 
                        MaSach = s.MaSach, 
                        TenSach = s.TenSach, 
                        SoLuongTon = s.SoLuongTon 
                    })
                    .ToList();

                // Kiểm tra danh sách rỗng
                if (saches.Count == 0)
                {
                    MessageBox.Show("Không có sách nào trong hệ thống!", "Cảnh báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboMaSach.DataSource = null;
                    return;
                }

                // Gán dữ liệu cho ComboBox
                cboMaSach.DataSource = null; // Reset trước
                cboMaSach.DisplayMember = "TenSach";
                cboMaSach.ValueMember = "MaSach";
                cboMaSach.DataSource = saches;
                
                // Chọn item đầu tiên
                if (cboMaSach.Items.Count > 0)
                {
                    cboMaSach.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải sách: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Class helper cho ComboBox
        private class SachComboItem
        {
            public string MaSach { get; set; }
            public string TenSach { get; set; }
            public int SoLuongTon { get; set; }
        }

        private void LoadLichSu()
        {
            try
            {
                using var db = new QuanLyNhaSachContext();
                
                // Load lịch sử tồn kho - dùng Join để tránh null reference
                var lichSu = (from t in db.TonKhos
                             join s in db.Saches on t.MaSach equals s.MaSach into sJoin
                             from s in sJoin.DefaultIfEmpty()
                             orderby t.NgayGiaoDich descending
                             select new
                             {
                                 t.MaGiaoDich,
                                 t.MaSach,
                                 TenSach = s != null ? s.TenSach : "N/A",
                                 t.LoaiGiaoDich,
                                 t.SoLuong,
                                 t.NgayGiaoDich,
                                 t.GhiChu,
                                 TonKhoHienTai = s != null ? s.SoLuongTon : (int?)0
                             })
                             .Take(100)
                             .ToList();

                dataGridView1.DataSource = lichSu;

                if (dataGridView1.Columns.Count > 0)
                {
                    dataGridView1.SetupVietnameseHeaders();
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải lịch sử: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            if (!RolePermissions.IsAdmin(_currentUser) && !RolePermissions.IsQuanLy(_currentUser))
            {
                MessageBox.Show("Bạn không có quyền nhập kho!", "Từ chối", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra item được chọn
            var selectedItem = cboMaSach.SelectedItem as SachComboItem;
            if (selectedItem == null || string.IsNullOrWhiteSpace(selectedItem.MaSach))
            {
                MessageBox.Show("Vui lòng chọn sách!", "Cảnh báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numSoLuong.Value <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0!", "Cảnh báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var db = new QuanLyNhaSachContext();
                var maSach = selectedItem.MaSach;
                var soLuong = (int)numSoLuong.Value;
                var ghiChu = txtGhiChu.Text.Trim();

                // Gọi stored procedure sp_NhapKho
                var connectionString = db.Database.Connection.ConnectionString;
                using var connection = new SqlConnection(connectionString);
                using var command = new SqlCommand("sp_NhapKho", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MaSach", maSach);
                command.Parameters.AddWithValue("@SoLuong", soLuong);
                command.Parameters.AddWithValue("@GhiChu", string.IsNullOrEmpty(ghiChu) ? DBNull.Value : (object)ghiChu);

                connection.Open();
                command.ExecuteNonQuery();

                MessageBox.Show($"✅ Nhập kho thành công {soLuong} cuốn!", "Thành công", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset form
                numSoLuong.Value = 1;
                txtGhiChu.Clear();
                LoadSach();
                LoadLichSu();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi nhập kho: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuatKho_Click(object sender, EventArgs e)
        {
            if (!RolePermissions.IsAdmin(_currentUser) && !RolePermissions.IsQuanLy(_currentUser))
            {
                MessageBox.Show("Bạn không có quyền xuất kho!", "Từ chối", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra item được chọn
            var selectedItem = cboMaSach.SelectedItem as SachComboItem;
            if (selectedItem == null || string.IsNullOrWhiteSpace(selectedItem.MaSach))
            {
                MessageBox.Show("Vui lòng chọn sách!", "Cảnh báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numSoLuong.Value <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0!", "Cảnh báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var db = new QuanLyNhaSachContext();
                var maSach = selectedItem.MaSach;
                var soLuong = (int)numSoLuong.Value;
                var ghiChu = txtGhiChu.Text.Trim();

                // Gọi stored procedure sp_XuatKho
                var connectionString = db.Database.Connection.ConnectionString;
                using var connection = new SqlConnection(connectionString);
                using var command = new SqlCommand("sp_XuatKho", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MaSach", maSach);
                command.Parameters.AddWithValue("@SoLuong", soLuong);
                command.Parameters.AddWithValue("@GhiChu", string.IsNullOrEmpty(ghiChu) ? DBNull.Value : (object)ghiChu);

                connection.Open();
                command.ExecuteNonQuery();

                MessageBox.Show($"✅ Xuất kho thành công {soLuong} cuốn!", "Thành công", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset form
                numSoLuong.Value = 1;
                txtGhiChu.Clear();
                LoadSach();
                LoadLichSu();
            }
            catch (SqlException ex)
            {
                // Catch lỗi từ stored procedure (không đủ tồn kho)
                MessageBox.Show($"❌ {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất kho: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboMaSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra ComboBox có item không
                if (cboMaSach.SelectedIndex < 0 || cboMaSach.SelectedItem == null)
                {
                    lblTonKhoHienTai.Text = "📊 Tồn kho hiện tại: 0 cuốn";
                    lblTonKhoHienTai.ForeColor = System.Drawing.Color.Gray;
                    return;
                }

                // Lấy item đã chọn
                var selectedItem = cboMaSach.SelectedItem as SachComboItem;
                if (selectedItem == null || string.IsNullOrWhiteSpace(selectedItem.MaSach))
                {
                    lblTonKhoHienTai.Text = "📊 Tồn kho hiện tại: 0 cuốn";
                    lblTonKhoHienTai.ForeColor = System.Drawing.Color.Gray;
                    return;
                }

                // Hiển thị tồn kho từ item đã chọn (không cần query lại DB)
                lblTonKhoHienTai.Text = $"📊 Tồn kho hiện tại: {selectedItem.SoLuongTon} cuốn";
                lblTonKhoHienTai.ForeColor = selectedItem.SoLuongTon < 10 
                    ? System.Drawing.Color.Red 
                    : System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                // Log lỗi nhưng không hiển thị cho user
                System.Diagnostics.Debug.WriteLine($"Error in cboMaSach_SelectedIndexChanged: {ex.Message}");
                lblTonKhoHienTai.Text = "📊 Tồn kho hiện tại: 0 cuốn";
                lblTonKhoHienTai.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void FormNhapXuatKho_Load(object sender, EventArgs e)
        {
            LoadLichSu();
        }
    }
}
