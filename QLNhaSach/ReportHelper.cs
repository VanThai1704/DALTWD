using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace QLNhaSach
{
    /// <summary>
    /// Helper class de tao va xuat bao cao voi ReportViewer
    /// </summary>
    public static class ReportHelper
    {
        /// <summary>
        /// Tao bao cao don gian voi ReportViewer
        /// </summary>
        public static void CreateSimpleReport(ReportViewer reportViewer, DataTable dataTable, string reportTitle)
        {
            try
            {
                // Validate input data
                if (dataTable == null || dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để tạo báo cáo.", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Debug data info
                System.Diagnostics.Debug.WriteLine($"Creating report with {dataTable.Rows.Count} rows, {dataTable.Columns.Count} columns");
                for (int i = 0; i < Math.Min(dataTable.Columns.Count, 4); i++)
                {
                    System.Diagnostics.Debug.WriteLine($"Column {i}: {dataTable.Columns[i].ColumnName} ({dataTable.Columns[i].DataType})");
                }
                // Xoa du lieu cu va cau hinh lai LocalReport
                reportViewer.Reset();
                reportViewer.ProcessingMode = ProcessingMode.Local;
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.ReportEmbeddedResource = null;

                // Ưu tiên sử dụng template ổn định Report1.rdlc để tránh lỗi hiển thị khi xuất PDF
                string rdlcPath = Path.Combine(Application.StartupPath, "Report", "Report1.rdlc");

                // Fallback về template backup nếu không tìm thấy template chính
                if (!File.Exists(rdlcPath))
                {
                    rdlcPath = Path.Combine(Application.StartupPath, "Report", "Report1Backup.rdlc");
                }

                // Fallback về template simple nếu không tìm thấy 2 template trên
                if (!File.Exists(rdlcPath))
                {
                    rdlcPath = Path.Combine(Application.StartupPath, "Report", "Report1Simple.rdlc");
                }

                if (!File.Exists(rdlcPath))
                {
                    MessageBox.Show("Không tìm thấy file template báo cáo. Hiển thị dữ liệu dạng bảng đơn giản.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowDataInGrid(dataTable, reportTitle);
                    return;
                }

                reportViewer.LocalReport.ReportPath = rdlcPath;

                // Tao DataTable moi voi cac columns co ten co dinh (Column1, Column2, Column3, Column4)
                // de RDLC co the truy cap duoc qua ten field
                DataTable mappedTable = new DataTable();
                
                // Luon tao du 4 columns
                for (int i = 0; i < 4; i++)
                {
                    if (i < dataTable.Columns.Count)
                    {
                        DataColumn srcCol = dataTable.Columns[i];
                        DataColumn newCol = new DataColumn($"Column{i + 1}", srcCol.DataType);
                        mappedTable.Columns.Add(newCol);
                    }
                    else
                    {
                        // Neu khong du columns, tao column rong
                        DataColumn newCol = new DataColumn($"Column{i + 1}", typeof(string));
                        mappedTable.Columns.Add(newCol);
                    }
                }

                foreach (DataRow row in dataTable.Rows)
                {
                    DataRow newRow = mappedTable.NewRow();
                    for (int i = 0; i < 4; i++)
                    {
                        if (i < dataTable.Columns.Count && i < row.ItemArray.Length)
                        {
                            object value = row[i];
                            newRow[i] = value ?? "";
                        }
                        else
                        {
                            newRow[i] = "";
                        }
                    }
                    mappedTable.Rows.Add(newRow);
                }

                // Gan datasource cho DataSet1 trong RDLC
                var rds = new ReportDataSource("DataSet1", mappedTable);
                reportViewer.LocalReport.DataSources.Add(rds);

                // Thiết lập tham số cơ bản
                try
                {
                    // Kiểm tra template nào đang được sử dụng
                    bool isCompleteTemplate = Path.GetFileName(rdlcPath).Contains("Complete");
                    bool isBackupTemplate = Path.GetFileName(rdlcPath).Contains("Backup");
                    bool isLegacyTemplate = string.Equals(
                        Path.GetFileName(rdlcPath),
                        "Report1.rdlc",
                        StringComparison.OrdinalIgnoreCase);

                    // Tạo parameters cơ bản (template nào cũng dùng)
                    var parametersList = new System.Collections.Generic.List<ReportParameter>
                    {
                        new ReportParameter("TenBaoCao", reportTitle),
                        new ReportParameter("NgayTao", DateTime.Now.ToString("dd/MM/yyyy"))
                    };

                    // Tính sẵn tên cột hiển thị theo dữ liệu thực tế
                    string col1Name = dataTable.Columns.Count > 0
                        ? GetVietnameseColumnName(dataTable.Columns[0].ColumnName)
                        : "Cột 1";
                    string col2Name = dataTable.Columns.Count > 1
                        ? GetVietnameseColumnName(dataTable.Columns[1].ColumnName)
                        : "Cột 2";
                    string col3Name = dataTable.Columns.Count > 2
                        ? GetVietnameseColumnName(dataTable.Columns[2].ColumnName)
                        : "Cột 3";
                    string col4Name = dataTable.Columns.Count > 3
                        ? GetVietnameseColumnName(dataTable.Columns[3].ColumnName)
                        : "Cột 4";

                    // Nếu là template backup, thêm header parameters Col1Header..Col4Header
                    if (isBackupTemplate)
                    {
                        parametersList.Add(new ReportParameter("Col1Header", col1Name));
                        parametersList.Add(new ReportParameter("Col2Header", col2Name));
                        parametersList.Add(new ReportParameter("Col3Header", col3Name));
                        parametersList.Add(new ReportParameter("Col4Header", col4Name));
                    }

                    // Nếu là template Report1.rdlc cũ hoặc template complete mới,
                    // set Column1Name..Column4Name để header dùng chung
                    if (isLegacyTemplate || isCompleteTemplate)
                    {
                        parametersList.Add(new ReportParameter("Column1Name", col1Name));
                        parametersList.Add(new ReportParameter("Column2Name", col2Name));
                        parametersList.Add(new ReportParameter("Column3Name", col3Name));
                        parametersList.Add(new ReportParameter("Column4Name", col4Name));
                    }

                    reportViewer.LocalReport.SetParameters(parametersList.ToArray());

                    // Nếu là template hoàn chỉnh, cập nhật header của bảng động
                    if (isCompleteTemplate)
                    {
                        UpdateDynamicTableHeaders(reportViewer, dataTable);
                    }
                }
                catch
                {
                    // Neu RDLC khong dinh nghia cac parameter nay thi bo qua
                }

                // Refresh report để hiển thị dữ liệu
                try
                {
                    reportViewer.RefreshReport();
                    System.Diagnostics.Debug.WriteLine("Report generated successfully");
                }
                catch (Exception refreshEx)
                {
                    System.Diagnostics.Debug.WriteLine($"Report refresh failed: {refreshEx.Message}");
                    MessageBox.Show($"Lỗi khi tạo báo cáo:\n{refreshEx.Message}\n\nSẽ hiển thị dữ liệu dạng bảng thay thế.", 
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ShowDataInGrid(dataTable, reportTitle);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Loi khi tao bao cao: {ex.Message}\n\nSu dung che do hien thi don gian.", 
                    "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                // Fallback: Hien thi du lieu trong DataGridView
                ShowDataInGrid(dataTable, reportTitle);
            }
        }

        // Bo toan bo ma sinh RDLC dong vi de loi va kho bao tri

        /// <summary>
        /// Chuyen doi ten cot sang tieng Viet co dau
        /// </summary>
        private static string GetVietnameseColumnName(string columnName)
        {
            if (string.IsNullOrEmpty(columnName))
                return columnName;

            // Mapping cac ten cot sang tieng Viet
            var mapping = new System.Collections.Generic.Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase)
            {
                // Sach
                { "MaSach", "Mã sách" },
                { "TenSach", "Tên sách" },
                { "TacGia", "Tác giả" },
                { "NamXuatBan", "Năm xuất bản" },
                { "GiaBan", "Giá bán" },
                { "SoLuongTon", "Số lượng tồn" },
                { "MaTheLoai", "Mã thể loại" },
                { "MaNXB", "Mã NXB" },
                { "TheLoai", "Thể loại" },
                { "NhaXuatBan", "Nhà xuất bản" },

                // Khach hang
                { "MaKH", "Mã khách hàng" },
                { "TenKH", "Tên khách hàng" },
                { "DiaChi", "Địa chỉ" },
                { "SoDienThoai", "Số điện thoại" },
                { "Email", "Email" },
                { "NgayDangKy", "Ngày đăng ký" },

                // Don hang
                { "MaDonHang", "Mã đơn hàng" },
                { "NgayDat", "Ngày đặt" },
                { "TongTien", "Tổng tiền" },
                { "TrangThai", "Trạng thái" },

                // Hoa don
                { "MaHoaDon", "Mã hóa đơn" },
                { "NgayLap", "Ngày lập" },
                { "PhuongThucThanhToan", "Phương thức thanh toán" },

                // Thong ke
                { "Ma", "Mã" },
                { "Ten", "Tên" },
                { "SoLuong", "Số lượng" },
                { "Nam", "Năm" },
                { "TongDoanhThu", "Tổng doanh thu" },
                { "Thang", "Tháng" },

                // Field names from database (short forms)
                { "dbr", "Mã sách" },
                { "bdr", "Tên sách" }, 
                { "dhrh", "Tác giả" },
                { "Khoa hoc", "Thể loại" },

                // Common abbreviations
                { "ID", "Mã" },
                { "Name", "Tên" },
                { "Description", "Mô tả" },
                { "Price", "Giá" },
                { "Quantity", "Số lượng" },
                { "Date", "Ngày" },
                { "Status", "Trạng thái" },
                { "Amount", "Số tiền" },
                { "Total", "Tổng cộng" }
            };

            return mapping.TryGetValue(columnName, out string vietnameseName) ? vietnameseName : columnName;
        }

        /// <summary>
        /// Cập nhật header của bảng động trong template complete
        /// </summary>
        private static void UpdateDynamicTableHeaders(ReportViewer reportViewer, DataTable dataTable)
        {
            try
            {
                // Tạo DataTable cho header mapping
                DataTable headerTable = new DataTable();
                headerTable.Columns.Add("HeaderIndex", typeof(int));
                headerTable.Columns.Add("HeaderText", typeof(string));

                // Thêm header cho từng column có dữ liệu
                for (int i = 0; i < Math.Min(dataTable.Columns.Count, 4); i++)
                {
                    DataRow headerRow = headerTable.NewRow();
                    headerRow["HeaderIndex"] = i + 1;
                    headerRow["HeaderText"] = GetVietnameseColumnName(dataTable.Columns[i].ColumnName);
                    headerTable.Rows.Add(headerRow);
                }

                // Thêm header mặc định cho các cột trống
                for (int i = dataTable.Columns.Count; i < 4; i++)
                {
                    DataRow headerRow = headerTable.NewRow();
                    headerRow["HeaderIndex"] = i + 1;
                    headerRow["HeaderText"] = "";
                    headerTable.Rows.Add(headerRow);
                }

                // Thêm datasource cho header (nếu template hỗ trợ)
                var headerDataSource = new ReportDataSource("HeaderDataSet", headerTable);
                reportViewer.LocalReport.DataSources.Add(headerDataSource);
            }
            catch (Exception ex)
            {
                // Nếu không set được header động thì bỏ qua
                System.Diagnostics.Debug.WriteLine($"Cannot set dynamic headers: {ex.Message}");
            }
        }

        /// <summary>
        /// Tạo báo cáo chi tiết với khả năng xuất nhiều định dạng
        /// </summary>
        public static void CreateDetailedReport(ReportViewer reportViewer, DataTable dataTable, 
            string reportTitle, string subtitle = null)
        {
            try
            {
                CreateSimpleReport(reportViewer, dataTable, reportTitle);
                
                // Thêm thông tin phụ nếu có
                if (!string.IsNullOrEmpty(subtitle))
                {
                    try
                    {
                        var existingParams = reportViewer.LocalReport.GetParameters();
                        var paramsList = new System.Collections.Generic.List<ReportParameter>();
                        
                        // Copy existing parameters
                        foreach (var param in existingParams)
                        {
                            string[] values = new string[param.Values.Count];
                            param.Values.CopyTo(values, 0);
                            paramsList.Add(new ReportParameter(param.Name, values));
                        }
                        
                        // Add subtitle parameter
                        paramsList.Add(new ReportParameter("Subtitle", subtitle));
                        
                        reportViewer.LocalReport.SetParameters(paramsList.ToArray());
                    }
                    catch (Exception paramEx)
                    {
                        System.Diagnostics.Debug.WriteLine($"Could not add subtitle parameter: {paramEx.Message}");
                    }
                }

                // Cấu hình xuất file
                ConfigureExportOptions(reportViewer);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tạo báo cáo chi tiết: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cấu hình các tùy chọn xuất file
        /// </summary>
        private static void ConfigureExportOptions(ReportViewer reportViewer)
        {
            // Cấu hình tùy chọn xuất PDF
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.PageWidth;
        }

        /// <summary>
        /// Fallback: Hien thi du lieu trong DataGridView don gian
        /// </summary>
        private static void ShowDataInGrid(DataTable dataTable, string reportTitle)
        {
            Form form = new Form();
            form.Text = reportTitle;
            form.Size = new System.Drawing.Size(1000, 600);
            form.StartPosition = FormStartPosition.CenterScreen;

            DataGridView dgv = new DataGridView();
            dgv.Dock = DockStyle.Fill;
            dgv.DataSource = dataTable;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            form.Controls.Add(dgv);
            form.ShowDialog();
        }

        /// <summary>
        /// Xuất báo cáo ra nhiều định dạng với tùy chọn
        /// </summary>
        public static void ExportReportWithOptions(ReportViewer reportViewer, string reportTitle)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Title = "Xuất báo cáo";
                dialog.Filter = "PDF Files (*.pdf)|*.pdf|Excel Files (*.xlsx)|*.xlsx|Word Files (*.docx)|*.docx|All Files (*.*)|*.*";
                dialog.FilterIndex = 1;
                dialog.FileName = $"{reportTitle}_{DateTime.Now:yyyyMMdd_HHmm}";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string extension = Path.GetExtension(dialog.FileName).ToLower();
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(dialog.FileName);

                    switch (extension)
                    {
                        case ".pdf":
                            ExportToPDF(reportViewer, fileNameWithoutExt);
                            break;
                        case ".xlsx":
                            ExportToExcel(reportViewer, fileNameWithoutExt);
                            break;
                        case ".docx":
                            ExportToWord(reportViewer, fileNameWithoutExt);
                            break;
                        default:
                            MessageBox.Show("Định dạng file không được hỗ trợ!", "Cảnh báo", 
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Xuất báo cáo ra Word
        /// </summary>
        public static void ExportToWord(ReportViewer reportViewer, string fileName = null)
        {
            try
            {
                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string extension;

                byte[] bytes = reportViewer.LocalReport.Render(
                    "WORDOPENXML",
                    null,
                    out mimeType,
                    out encoding,
                    out extension,
                    out streamids,
                    out warnings);

                SaveAndOpenFile(bytes, "docx", fileName ?? "BaoCao");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất Word: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xuất báo cáo ra Excel (cải tiến)
        /// </summary>
        public static void ExportToExcel(ReportViewer reportViewer, string fileName = null)
        {
            try
            {
                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string extension;

                // Sử dụng EXCELOPENXML để tương thích tốt hơn
                byte[] bytes = reportViewer.LocalReport.Render(
                    "EXCELOPENXML",
                    null,
                    out mimeType,
                    out encoding,
                    out extension,
                    out streamids,
                    out warnings);

                SaveAndOpenFile(bytes, "xlsx", fileName ?? "BaoCao");
                
                if (warnings != null && warnings.Length > 0)
                {
                    System.Diagnostics.Debug.WriteLine($"Excel export warnings: {warnings.Length}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất Excel: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xuat bao cao ra PDF
        /// </summary>
        public static void ExportToPDF(ReportViewer reportViewer, string fileName = null)
        {
            try
            {
                // co gang ep report ve A4 va margin hop ly de han che trang trang
                // Note: PaperSize and Margins properties are read-only in newer versions
                // The report will use default page settings
                try
                {
                    var pg = reportViewer.LocalReport.GetDefaultPageSettings();
                    if (pg != null)
                    {
                        // Page settings are configured in the RDLC file itself
                        // No need to set PaperSize and Margins programmatically
                    }
                }
                catch
                {
                    // neu khong cai duoc thi bo qua, van render binh thuong
                }

                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string extension;

                // DeviceInfo: ép A4, margin nhỏ, tắt auto-resize
                string deviceInfo =
                    "<DeviceInfo>" +
                    "  <OutputFormat>PDF</OutputFormat>" +
                    "  <PageWidth>21cm</PageWidth>" +
                    "  <PageHeight>29.7cm</PageHeight>" +
                    "  <MarginTop>1cm</MarginTop>" +
                    "  <MarginLeft>1cm</MarginLeft>" +
                    "  <MarginRight>1cm</MarginRight>" +
                    "  <MarginBottom>1cm</MarginBottom>" +
                    "</DeviceInfo>";

                byte[] bytes = reportViewer.LocalReport.Render(
                    "PDF",
                    deviceInfo,            // dùng deviceInfo thay vì null
                    out mimeType,
                    out encoding,
                    out extension,
                    out streamids,
                    out warnings);

                SaveAndOpenFile(bytes, "pdf", fileName ?? "BaoCao");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Loi khi xuat PDF: {ex.Message}", "Loi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Lưu và mở file với UI cải tiến
        /// </summary>
        private static void SaveAndOpenFile(byte[] bytes, string extension, string defaultFileName)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = GetFileFilter(extension);
                saveDialog.FileName = $"{defaultFileName}_{DateTime.Now:yyyyMMdd_HHmmss}.{extension}";
                saveDialog.Title = "Lưu báo cáo";
                saveDialog.DefaultExt = extension;

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(saveDialog.FileName, bytes);
                    
                    // Thông báo thành công với thông tin chi tiết
                    string message = $"✅ Xuất file thành công!\n\n" +
                                   $"📁 Đường dẫn: {saveDialog.FileName}\n" +
                                   $"📊 Dung lượng: {FormatFileSize(bytes.Length)}\n" +
                                   $"⏰ Thời gian: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
                    
                    MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Hỏi có muốn mở file không
                    var result = MessageBox.Show("Bạn có muốn mở file vừa xuất không?", 
                        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = saveDialog.FileName,
                                UseShellExecute = true
                            });
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Không thể mở file: {ex.Message}\n\nBạn có thể mở thủ công tại:\n{saveDialog.FileName}", 
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu file: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Lấy filter cho SaveFileDialog theo extension
        /// </summary>
        private static string GetFileFilter(string extension)
        {
            switch (extension.ToLower())
            {
                case "pdf":
                    return "PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*";
                case "xlsx":
                    return "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
                case "docx":
                    return "Word Files (*.docx)|*.docx|All Files (*.*)|*.*";
                case "csv":
                    return "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
                default:
                    return $"{extension.ToUpper()} Files (*.{extension})|*.{extension}|All Files (*.*)|*.*";
            }
        }

        /// <summary>
        /// Format file size thành dạng dễ đọc
        /// </summary>
        private static string FormatFileSize(long bytes)
        {
            if (bytes < 1024) return $"{bytes} B";
            if (bytes < 1024 * 1024) return $"{bytes / 1024.0:F1} KB";
            if (bytes < 1024 * 1024 * 1024) return $"{bytes / (1024.0 * 1024.0):F1} MB";
            return $"{bytes / (1024.0 * 1024.0 * 1024.0):F1} GB";
        }

        /// <summary>
        /// Tạo preview report trước khi xuất
        /// </summary>
        public static bool PreviewReport(ReportViewer reportViewer, DataTable dataTable, string reportTitle)
        {
            try
            {
                CreateDetailedReport(reportViewer, dataTable, reportTitle);
                
                // Hiển thị form preview
                using (var previewForm = new Form())
                {
                    previewForm.Text = $"Xem trước - {reportTitle}";
                    previewForm.Size = new System.Drawing.Size(1200, 800);
                    previewForm.StartPosition = FormStartPosition.CenterScreen;
                    previewForm.MinimizeBox = true;
                    previewForm.MaximizeBox = true;

                    var previewReportViewer = new ReportViewer();
                    previewReportViewer.Dock = DockStyle.Fill;
                    
                    // Copy cấu hình từ reportViewer gốc
                    previewReportViewer.LocalReport.ReportPath = reportViewer.LocalReport.ReportPath;
                    previewReportViewer.LocalReport.DataSources.Clear();
                    foreach (ReportDataSource rds in reportViewer.LocalReport.DataSources)
                    {
                        previewReportViewer.LocalReport.DataSources.Add(rds);
                    }
                    
                    // Copy parameters safely
                    try
                    {
                        var existingParams = reportViewer.LocalReport.GetParameters();
                        var paramsList = new System.Collections.Generic.List<ReportParameter>();
                        
                        foreach (var param in existingParams)
                        {
                            string[] values = new string[param.Values.Count];
                            param.Values.CopyTo(values, 0);
                            paramsList.Add(new ReportParameter(param.Name, values));
                        }
                        
                        if (paramsList.Count > 0)
                        {
                            previewReportViewer.LocalReport.SetParameters(paramsList.ToArray());
                        }
                    }
                    catch (Exception paramEx)
                    {
                        System.Diagnostics.Debug.WriteLine($"Could not copy parameters: {paramEx.Message}");
                    }

                    previewForm.Controls.Add(previewReportViewer);
                    
                    // Thêm toolbar với các nút export
                    AddExportToolbar(previewForm, previewReportViewer, reportTitle);
                    
                    previewReportViewer.RefreshReport();
                    previewForm.ShowDialog();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo preview: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Thêm toolbar export cho preview form
        /// </summary>
        private static void AddExportToolbar(Form form, ReportViewer reportViewer, string reportTitle)
        {
            var toolStrip = new ToolStrip();
            toolStrip.Dock = DockStyle.Top;

            var pdfButton = new ToolStripButton("📄 Xuất PDF");
            pdfButton.Click += (s, e) => ExportToPDF(reportViewer, reportTitle);
            toolStrip.Items.Add(pdfButton);

            var excelButton = new ToolStripButton("📊 Xuất Excel");
            excelButton.Click += (s, e) => ExportToExcel(reportViewer, reportTitle);
            toolStrip.Items.Add(excelButton);

            var wordButton = new ToolStripButton("📝 Xuất Word");
            wordButton.Click += (s, e) => ExportToWord(reportViewer, reportTitle);
            toolStrip.Items.Add(wordButton);

            toolStrip.Items.Add(new ToolStripSeparator());

            var optionsButton = new ToolStripButton("⚙️ Tùy chọn xuất");
            optionsButton.Click += (s, e) => ExportReportWithOptions(reportViewer, reportTitle);
            toolStrip.Items.Add(optionsButton);

            form.Controls.Add(toolStrip);
        }
    }
}
