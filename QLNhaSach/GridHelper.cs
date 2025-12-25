using System.Drawing;
using System.Windows.Forms;

namespace QLNhaSach
{
    public static class GridHelper
    {
        public static void ApplyVietnameseColumnHeaders(DataGridView dgv)
        {
            if (dgv == null || dgv.Columns.Count == 0) return;

            void Set(string key, string header)
            {
                if (!dgv.Columns.Contains(key)) return;
                var col = dgv.Columns[key];
                // Normalize to composed form to avoid combining-sequence issues
                var nh = header?.Normalize(System.Text.NormalizationForm.FormC) ?? header;
                // assign both HeaderText and HeaderCell.Value using proper Unicode string
                col.HeaderText = nh;
                if (col.HeaderCell != null)
                    col.HeaderCell.Value = nh;
                // ensure header uses the header font
                try
                {
                    col.HeaderCell.Style.Font = FontHelper.DefaultHeaderFont;
                }
                catch
                {
                    // ignore if style cannot be set
                }
                // ensure cell font is unicode-capable
                try
                {
                    col.DefaultCellStyle.Font = FontHelper.DefaultCellFont;
                }
                catch
                {
                }
                // also set grid-level header font
                try
                {
                    dgv.ColumnHeadersDefaultCellStyle.Font = FontHelper.DefaultHeaderFont;
                }
                catch { }
            }

            // Common mappings (correct Vietnamese)
            Set("MaSach", "Mã sách");
            Set("TenSach", "Tên sách");
            Set("TacGia", "Tác giả");
            Set("NamXuatBan", "Năm xuất bản");
            Set("GiaBan", "Giá bán");
            Set("SoLuongTon", "Số lượng tồn");
            Set("MaTheLoai", "Mã thể loại");
            Set("MaNXB", "Mã NXB");

            Set("MaKH", "Mã khách hàng");
            Set("TenKH", "Tên khách hàng");
            Set("DiaChi", "Địa chỉ");
            Set("SoDienThoai", "Số điện thoại");
            Set("NgayDangKy", "Ngày đăng ký");

            Set("MaGiaoDich", "Mã giao dịch");
            Set("LoaiGiaoDich", "Loại giao dịch");
            Set("SoLuong", "Số lượng");
            Set("NgayGiaoDich", "Ngày giao dịch");

            Set("MaDonHang", "Mã đơn hàng");
            Set("NgayDat", "Ngày đặt");
            Set("TongTien", "Tổng tiền");
            Set("TrangThai", "Trạng thái");

            Set("MaHoaDon", "Mã hóa đơn");
            Set("NgayLap", "Ngày lập");
            Set("PhuongThucThanhToan", "Phương thức thanh toán");

            Set("Nam", "Năm");
            Set("TongDoanhThu", "Tổng doanh thu");

            // User management columns
            Set("NguoiDungId", "Mã người dùng");
            Set("TenDangNhap", "Tên đăng nhập");
            Set("HoTen", "Họ tên");
            Set("RoleName", "Vai trò");
            Set("KichHoat", "Kích hoạt");
            Set("GhiChu", "Ghi chú");

            // Role management columns
            Set("RoleId", "Mã vai trò");
            Set("SoLuongNguoiDung", "Số người dùng");
            Set("MoTa", "Mô tả");
            Set("TonKHoHienTai", "Tồn kho hiện tại");

            // Formatting for known columns
            if (dgv.Columns.Contains("GiaBan"))
            {
                dgv.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
                dgv.Columns["GiaBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dgv.Columns.Contains("TongTien"))
            {
                dgv.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                dgv.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dgv.Columns.Contains("NgayDangKy"))
                dgv.Columns["NgayDangKy"].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (dgv.Columns.Contains("NgayGiaoDich"))
                dgv.Columns["NgayGiaoDich"].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (dgv.Columns.Contains("NgayLap"))
                dgv.Columns["NgayLap"].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (dgv.Columns.Contains("NgayDat"))
                dgv.Columns["NgayDat"].DefaultCellStyle.Format = "dd/MM/yyyy";

            // Debug output: list header texts for diagnosis
            try
            {
                System.Diagnostics.Debug.WriteLine("DataGridView headers for: " + (dgv.Name ?? "(unnamed)"));
                foreach (DataGridViewColumn c in dgv.Columns)
                {
                    System.Diagnostics.Debug.WriteLine($"  Column '{c.Name}' HeaderText='{c.HeaderText}'");
                }
            }
            catch { }
        }
    }
}
