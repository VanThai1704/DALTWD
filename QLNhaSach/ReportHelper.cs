using System;
using System.Data;
using System.IO;
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
                // Xoa du lieu cu
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.ReportPath = string.Empty;

                // Tao report programmatically
                reportViewer.LocalReport.ReportEmbeddedResource = null;
                
                // Neu co file RDLC, dung no
                string rdlcPath = Path.Combine(Application.StartupPath, "Reports", "Report1.rdlc");
                if (File.Exists(rdlcPath))
                {
                    reportViewer.LocalReport.ReportPath = rdlcPath;
                }
                else
                {
                    // Neu khong co, tao report dong
                    CreateDynamicReport(reportViewer, dataTable, reportTitle);
                    return;
                }

                // Add data source
                ReportDataSource rds = new ReportDataSource("DataSet1", dataTable);
                reportViewer.LocalReport.DataSources.Add(rds);

                // Set parameters
                ReportParameter[] parameters = new ReportParameter[]
                {
                    new ReportParameter("TenBaoCao", reportTitle),
                    new ReportParameter("NgayTao", DateTime.Now.ToString("dd/MM/yyyy HH:mm"))
                };
                reportViewer.LocalReport.SetParameters(parameters);

                // Refresh report
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Loi khi tao bao cao: {ex.Message}\n\nSu dung che do hien thi don gian.", 
                    "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                // Fallback: Hien thi du lieu trong DataGridView
                ShowDataInGrid(dataTable, reportTitle);
            }
        }

        /// <summary>
        /// Tao report dong khi khong co file RDLC
        /// </summary>
        private static void CreateDynamicReport(ReportViewer reportViewer, DataTable dataTable, string reportTitle)
        {
            // Tao RDLC content dong
            string rdlc = GenerateRDLC(dataTable, reportTitle);
            
            // Luu tam file RDLC
            string tempPath = Path.Combine(Path.GetTempPath(), "TempReport.rdlc");
            File.WriteAllText(tempPath, rdlc);
            
            reportViewer.LocalReport.ReportPath = tempPath;
            
            ReportDataSource rds = new ReportDataSource("DataSet1", dataTable);
            reportViewer.LocalReport.DataSources.Add(rds);
            
            reportViewer.RefreshReport();
        }

        /// <summary>
        /// Tao noi dung RDLC dong
        /// </summary>
        private static string GenerateRDLC(DataTable dataTable, string reportTitle)
        {
            string rdlc = @"<?xml version=""1.0"" encoding=""utf-8""?>
<Report xmlns=""http://schemas.microsoft.com/sqlserver/reporting/2016/01/reportdefinition"">
  <DataSources>
    <DataSource Name=""DataSet1"">
      <ConnectionProperties>
        <DataProvider>System.Data.DataSet</DataProvider>
        <ConnectString>/* Local Connection */</ConnectString>
      </ConnectionProperties>
    </DataSource>
  </DataSources>
  <DataSets>
    <DataSet Name=""DataSet1"">
      <Query>
        <DataSourceName>DataSet1</DataSourceName>
        <CommandText>/* Local Query */</CommandText>
      </Query>
      <Fields>";

            // Add fields
            foreach (DataColumn column in dataTable.Columns)
            {
                rdlc += $@"
        <Field Name=""{column.ColumnName}"">
          <DataField>{column.ColumnName}</DataField>
        </Field>";
            }

            rdlc += @"
      </Fields>
    </DataSet>
  </DataSets>
  <Body>
    <ReportItems>
      <Textbox Name=""Title"">
        <CanGrow>true</CanGrow>
        <KeepTogether>true</KeepTogether>
        <Paragraphs>
          <Paragraph>
            <TextRuns>
              <TextRun>
                <Value>" + reportTitle + @"</Value>
                <Style>
                  <FontSize>16pt</FontSize>
                  <FontWeight>Bold</FontWeight>
                </Style>
              </TextRun>
            </TextRuns>
          </Paragraph>
        </Paragraphs>
        <Top>0.5cm</Top>
        <Left>0.5cm</Left>
        <Height>1cm</Height>
        <Width>15cm</Width>
      </Textbox>
    </ReportItems>
  </Body>
  <Width>21cm</Width>
  <Page>
    <PageHeight>29.7cm</PageHeight>
    <PageWidth>21cm</PageWidth>
    <LeftMargin>1cm</LeftMargin>
    <RightMargin>1cm</RightMargin>
    <TopMargin>1cm</TopMargin>
    <BottomMargin>1cm</BottomMargin>
  </Page>
</Report>";

            return rdlc;
        }

        /// <summary>
        /// Fallback: Hien thi du lieu trong DataGridView
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
        /// Xuat bao cao ra Excel
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

                byte[] bytes = reportViewer.LocalReport.Render(
                    "EXCELOPENXML",
                    null,
                    out mimeType,
                    out encoding,
                    out extension,
                    out streamids,
                    out warnings);

                SaveAndOpenFile(bytes, "xlsx", fileName ?? "BaoCao");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Loi khi xuat Excel: {ex.Message}", "Loi",
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
                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string extension;

                byte[] bytes = reportViewer.LocalReport.Render(
                    "PDF",
                    null,
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
        /// Xuat bao cao ra Word
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
                MessageBox.Show($"Loi khi xuat Word: {ex.Message}", "Loi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Luu va mo file
        /// </summary>
        private static void SaveAndOpenFile(byte[] bytes, string extension, string defaultFileName)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = extension.ToUpper() + " Files|*." + extension;
            saveDialog.FileName = $"{defaultFileName}_{DateTime.Now:yyyyMMdd_HHmmss}.{extension}";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(saveDialog.FileName, bytes);
                MessageBox.Show($"Xuat file thanh cong!\nFile: {saveDialog.FileName}",
                    "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (MessageBox.Show("Ban co muon mo file vua xuat?", "Xac nhan",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = saveDialog.FileName,
                        UseShellExecute = true
                    });
                }
            }
        }
    }
}
