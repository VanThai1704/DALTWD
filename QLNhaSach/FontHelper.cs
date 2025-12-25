using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLNhaSach
{
    /// <summary>
    /// L?p h? tr? c?u hình font ti?ng Vi?t cho các control trong ?ng d?ng
    /// </summary>
    public static class FontHelper
    {
        /// <summary>
        /// Font chu?n cho các cell trong DataGridView
        /// </summary>
        // Use a UI font that reliably contains Vietnamese glyphs. Prefer 'Tahoma' for wide availability.
        private const string PreferredUiFont = "Tahoma";
        private const string FallbackUiFont = "Segoe UI";
        private const string SecondFallbackFont = "Microsoft Sans Serif";

        private static string ChooseFontFamily()
        {
            // Verify the preferred font is available on the system; if not, use fallback.
            try
            {
                var installed = new System.Drawing.Text.InstalledFontCollection();
                var families = installed.Families;
                foreach (var f in families)
                {
                    if (string.Equals(f.Name, PreferredUiFont, StringComparison.OrdinalIgnoreCase))
                        return PreferredUiFont;
                }

                // If preferred not found but fallback exists, use it
                foreach (var f in families)
                {
                    if (string.Equals(f.Name, FallbackUiFont, StringComparison.OrdinalIgnoreCase))
                        return FallbackUiFont;
                }

                // Try a broader unicode-capable font
                foreach (var f in families)
                {
                    if (string.Equals(f.Name, SecondFallbackFont, StringComparison.OrdinalIgnoreCase))
                        return SecondFallbackFont;
                }

                // As a last resort return the system default font family name
                return SystemFonts.DefaultFont.FontFamily.Name;
            }
            catch
            {
                return SystemFonts.DefaultFont.FontFamily.Name;
            }
        }

        public static Font DefaultCellFont => new Font(ChooseFontFamily(), 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        
        /// <summary>
        /// Font chu?n cho header c?a DataGridView
        /// </summary>
        public static Font DefaultHeaderFont => new Font(ChooseFontFamily(), 9.75F, FontStyle.Bold, GraphicsUnit.Point);
        
        /// <summary>
        /// Font chu?n cho form
        /// </summary>
        public static Font DefaultFormFont => new Font(ChooseFontFamily(), 9F, FontStyle.Regular, GraphicsUnit.Point);
        
        /// <summary>
        /// Font cho tiêu ??
        /// </summary>
        public static Font TitleFont => new Font(ChooseFontFamily(), 12F, FontStyle.Bold, GraphicsUnit.Point);
        
        /// <summary>
        /// Áp d?ng font ti?ng Vi?t cho DataGridView
        /// </summary>
        /// <param name="dataGridView">DataGridView c?n c?u hình</param>
        /// <param name="rowHeight">Chi?u cao m?i row (m?c ??nh 28)</param>
        public static void ApplyVietnameseFont(this DataGridView dataGridView, int rowHeight = 28)
        {
            if (dataGridView == null) return;
            
            dataGridView.Font = DefaultCellFont;
            dataGridView.DefaultCellStyle.Font = DefaultCellFont;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = DefaultHeaderFont;
            dataGridView.RowTemplate.Height = rowHeight;
            
            // ??m b?o DataGridView render ?úng
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridView.EnableHeadersVisualStyles = false;

            // Ensure each existing column explicitly uses the fonts (addresses cases where header cells keep old style)
            if (dataGridView.Columns != null)
            {
                foreach (DataGridViewColumn col in dataGridView.Columns)
                {
                    if (col == null) continue;
                    col.DefaultCellStyle.Font = DefaultCellFont;
                    if (col.HeaderCell != null)
                    {
                        col.HeaderCell.Style.Font = DefaultHeaderFont;
                    }
                }
            }
        }
        
        /// <summary>
        /// Áp d?ng font ti?ng Vi?t cho Form và t?t c? control con
        /// </summary>
        /// <param name="form">Form c?n c?u hình</param>
        public static void ApplyVietnameseFont(this Form form)
        {
            if (form == null) return;
            
            form.Font = DefaultFormFont;
            
            // Áp d?ng cho t?t c? control con
            foreach (Control control in form.Controls)
            {
                ApplyFontToControl(control);
            }
        }
        
        private static void ApplyFontToControl(Control control)
        {
            if (control is DataGridView dgv)
            {
                dgv.ApplyVietnameseFont();
            }
            else if (control is Label || control is Button || control is TextBox || control is ComboBox || control is GroupBox)
            {
                control.Font = DefaultFormFont;
            }

            // MenuStrip / ToolStrip handling
            else if (control is MenuStrip menu)
            {
                menu.Font = DefaultFormFont;
                foreach (ToolStripItem item in menu.Items)
                {
                    if (item != null)
                        item.Font = DefaultFormFont;
                    if (item is ToolStripMenuItem menuItem && menuItem.HasDropDownItems)
                    {
                        ApplyFontToToolStripMenuItems(menuItem.DropDownItems);
                    }
                }
            }
            else if (control is ToolStrip toolStrip)
            {
                toolStrip.Font = DefaultFormFont;
                foreach (ToolStripItem item in toolStrip.Items)
                {
                    if (item != null)
                        item.Font = DefaultFormFont;
                }
            }
            else if (control is StatusStrip status)
            {
                status.Font = DefaultFormFont;
                foreach (ToolStripItem item in status.Items)
                {
                    if (item != null)
                        item.Font = DefaultFormFont;
                }
            }
            
            // ?? quy cho control con
            foreach (Control child in control.Controls)
            {
                ApplyFontToControl(child);
            }
        }

        private static void ApplyFontToToolStripMenuItems(ToolStripItemCollection items)
        {
            if (items == null) return;
            foreach (ToolStripItem it in items)
            {
                if (it == null) continue;
                it.Font = DefaultFormFont;
                if (it is ToolStripMenuItem tmi && tmi.HasDropDownItems)
                {
                    ApplyFontToToolStripMenuItems(tmi.DropDownItems);
                }
            }
        }
    }
}
