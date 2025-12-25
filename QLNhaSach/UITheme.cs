using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLNhaSach
{
    public static class UITheme
    {
        // Màu s?c ch? ??o
        public static readonly Color PrimaryColor = Color.FromArgb(41, 128, 185);      // Xanh d??ng
        public static readonly Color PrimaryDarkColor = Color.FromArgb(31, 97, 141);   // Xanh d??ng ??m
        public static readonly Color PrimaryLightColor = Color.FromArgb(52, 152, 219); // Xanh d??ng nh?t
        
        public static readonly Color SecondaryColor = Color.FromArgb(52, 73, 94);      // Xám ??m
        public static readonly Color SuccessColor = Color.FromArgb(39, 174, 96);       // Xanh lá
        public static readonly Color DangerColor = Color.FromArgb(231, 76, 60);        // ??
        public static readonly Color WarningColor = Color.FromArgb(243, 156, 18);      // Cam
        public static readonly Color InfoColor = Color.FromArgb(52, 152, 219);         // Xanh nh?t
        
        // Màu n?n
        public static readonly Color BackgroundColor = Color.FromArgb(236, 240, 241);  // Xám sáng
        public static readonly Color CardBackground = Color.White;
        public static readonly Color DarkBackground = Color.FromArgb(44, 62, 80);
        
        // Màu ch?
        public static readonly Color TextColor = Color.FromArgb(44, 62, 80);
        public static readonly Color TextLightColor = Color.FromArgb(127, 140, 141);
        public static readonly Color TextWhiteColor = Color.White;
        
        // Font ch? - use FontHelper for Vietnamese support
        public static Font TitleFont => new Font(FontHelper.DefaultFormFont.FontFamily, 16F, FontStyle.Bold);
        public static Font SubtitleFont => new Font(FontHelper.DefaultFormFont.FontFamily, 12F, FontStyle.Bold);
        public static Font NormalFont => FontHelper.DefaultFormFont;
        public static Font SmallFont => new Font(FontHelper.DefaultFormFont.FontFamily, 8F);
        public static Font ButtonFont => new Font(FontHelper.DefaultFormFont.FontFamily, 10F, FontStyle.Regular);
        
        // Kích th??c
        public static readonly int BorderRadius = 5;
        public static readonly int ButtonHeight = 36;
        public static readonly int TextBoxHeight = 32;
        public static readonly Padding DefaultPadding = new Padding(10);
        public static readonly Padding CardPadding = new Padding(20);
        
        public static void ApplyTheme(Form form)
        {
            form.BackColor = BackgroundColor;
            form.Font = NormalFont;
            
            ApplyThemeToControls(form.Controls);
        }
        
        private static void ApplyThemeToControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is Button button)
                {
                    StyleButton(button, PrimaryColor);
                }
                else if (control is TextBox textBox)
                {
                    StyleTextBox(textBox);
                }
                else if (control is Label label)
                {
                    StyleLabel(label);
                }
                else if (control is DataGridView dataGridView)
                {
                    StyleDataGridView(dataGridView);
                }
                else if (control is MenuStrip menuStrip)
                {
                    StyleMenuStrip(menuStrip);
                }
                else if (control is ToolStrip toolStrip)
                {
                    StyleToolStrip(toolStrip);
                }
                else if (control is ComboBox comboBox)
                {
                    StyleComboBox(comboBox);
                }
                else if (control is Panel panel)
                {
                    StylePanel(panel);
                }
                else if (control is GroupBox groupBox)
                {
                    StyleGroupBox(groupBox);
                }
                
                if (control.HasChildren)
                {
                    ApplyThemeToControls(control.Controls);
                }
            }
        }
        
        public static void StyleButton(Button button, Color? backgroundColor = null)
        {
            button.BackColor = backgroundColor ?? PrimaryColor;
            button.ForeColor = TextWhiteColor;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = ButtonFont;
            button.Cursor = Cursors.Hand;
            button.Height = ButtonHeight;
            button.Padding = new Padding(15, 0, 15, 0);
            
            button.MouseEnter += (s, e) =>
            {
                button.BackColor = backgroundColor != null 
                    ? ControlPaint.Dark(backgroundColor.Value, 0.1f) 
                    : PrimaryDarkColor;
            };
            
            button.MouseLeave += (s, e) =>
            {
                button.BackColor = backgroundColor ?? PrimaryColor;
            };
        }
        
        public static void StyleSecondaryButton(Button button)
        {
            StyleButton(button, SecondaryColor);
        }
        
        public static void StyleSuccessButton(Button button)
        {
            StyleButton(button, SuccessColor);
        }
        
        public static void StyleDangerButton(Button button)
        {
            StyleButton(button, DangerColor);
        }
        
        public static void StyleTextBox(TextBox textBox)
        {
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.Font = NormalFont;
            textBox.Height = TextBoxHeight;
            textBox.BackColor = CardBackground;
            textBox.ForeColor = TextColor;
        }
        
        public static void StyleLabel(Label label)
        {
            label.Font = NormalFont;
            label.ForeColor = TextColor;
            label.BackColor = Color.Transparent;
        }
        
        public static void StyleDataGridView(DataGridView dataGridView)
        {
            dataGridView.BackgroundColor = CardBackground;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = PrimaryColor;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = TextWhiteColor;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = FontHelper.DefaultHeaderFont;
            dataGridView.ColumnHeadersDefaultCellStyle.Padding = new Padding(8);
            dataGridView.ColumnHeadersHeight = 40;
            
            dataGridView.DefaultCellStyle.BackColor = CardBackground;
            dataGridView.DefaultCellStyle.ForeColor = TextColor;
            dataGridView.DefaultCellStyle.SelectionBackColor = PrimaryLightColor;
            dataGridView.DefaultCellStyle.SelectionForeColor = TextWhiteColor;
            dataGridView.DefaultCellStyle.Font = NormalFont;
            dataGridView.DefaultCellStyle.Padding = new Padding(5);
            dataGridView.RowTemplate.Height = 35;
            
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);
            
            dataGridView.GridColor = Color.FromArgb(189, 195, 199);
            dataGridView.RowHeadersVisible = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ReadOnly = true;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        
        public static void StyleMenuStrip(MenuStrip menuStrip)
        {
            menuStrip.BackColor = CardBackground;
            menuStrip.ForeColor = TextColor;
            menuStrip.Font = FontHelper.DefaultFormFont;
            menuStrip.Padding = new Padding(5, 3, 0, 3);
            
            foreach (ToolStripMenuItem item in menuStrip.Items)
            {
                StyleMenuItem(item);
            }
        }
        
        private static void StyleMenuItem(ToolStripMenuItem item)
        {
            item.Font = FontHelper.DefaultFormFont;
            item.ForeColor = TextColor;
            
            foreach (ToolStripItem subItem in item.DropDownItems)
            {
                if (subItem is ToolStripMenuItem menuItem)
                {
                    menuItem.BackColor = CardBackground;
                    menuItem.ForeColor = TextColor;
                    StyleMenuItem(menuItem);
                }
            }
        }
        
        public static void StyleToolStrip(ToolStrip toolStrip)
        {
            toolStrip.BackColor = CardBackground;
            toolStrip.ForeColor = TextColor;
            toolStrip.Font = FontHelper.DefaultFormFont;
            toolStrip.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip.Padding = new Padding(10, 5, 10, 5);
            toolStrip.Renderer = new CustomToolStripRenderer();
            
            foreach (ToolStripItem item in toolStrip.Items)
            {
                if (item is ToolStripButton button)
                {
                    button.Font = FontHelper.DefaultFormFont;
                    button.ForeColor = TextColor;
                    button.Padding = new Padding(8, 5, 8, 5);
                    button.AutoSize = true;
                }
                else if (item is ToolStripTextBox textBox)
                {
                    textBox.Font = FontHelper.DefaultFormFont;
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                }
            }
        }
        
        public static void StyleComboBox(ComboBox comboBox)
        {
            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.Font = NormalFont;
            comboBox.BackColor = CardBackground;
            comboBox.ForeColor = TextColor;
        }
        
        public static void StylePanel(Panel panel)
        {
            panel.BackColor = CardBackground;
            panel.Padding = CardPadding;
        }
        
        public static void StyleGroupBox(GroupBox groupBox)
        {
            groupBox.Font = SubtitleFont;
            groupBox.ForeColor = PrimaryColor;
            groupBox.FlatStyle = FlatStyle.Flat;
        }
        
        private class CustomToolStripRenderer : ToolStripProfessionalRenderer
        {
            public CustomToolStripRenderer() : base(new CustomColorTable()) { }
            
            protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
            {
                if (e.Item is ToolStripButton button)
                {
                    if (button.Selected || button.Pressed)
                    {
                        Rectangle rect = new Rectangle(Point.Empty, e.Item.Size);
                        e.Graphics.FillRectangle(new SolidBrush(PrimaryLightColor), rect);
                    }
                }
            }
        }
        
        private class CustomColorTable : ProfessionalColorTable
        {
            public override Color MenuItemSelected => PrimaryLightColor;
            public override Color MenuItemSelectedGradientBegin => PrimaryLightColor;
            public override Color MenuItemSelectedGradientEnd => PrimaryLightColor;
            public override Color MenuItemPressedGradientBegin => PrimaryColor;
            public override Color MenuItemPressedGradientEnd => PrimaryColor;
            public override Color MenuItemBorder => PrimaryColor;
            public override Color ToolStripDropDownBackground => CardBackground;
            public override Color ImageMarginGradientBegin => CardBackground;
            public override Color ImageMarginGradientMiddle => CardBackground;
            public override Color ImageMarginGradientEnd => CardBackground;
        }
        
        // Helper method ?? t?o panel card ??p
        public static Panel CreateCardPanel(int width = 0, int height = 0)
        {
            var panel = new Panel
            {
                BackColor = CardBackground,
                Padding = CardPadding,
                Width = width > 0 ? width : 400,
                Height = height > 0 ? height : 300
            };
            
            // Thêm shadow effect (gi? l?p b?ng border)
            panel.Paint += (s, e) =>
            {
                var rect = panel.ClientRectangle;
                rect.Width -= 1;
                rect.Height -= 1;
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(189, 195, 199), 1), rect);
            };
            
            return panel;
        }
        
        // Helper ?? t?o label tiêu ??
        public static Label CreateTitleLabel(string text, int y = 20)
        {
            return new Label
            {
                Text = text,
                Font = SubtitleFont,
                ForeColor = PrimaryColor,
                AutoSize = false,
                Width = 360,
                Height = 40,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(20, y)
            };
        }
        
        // Helper ?? t?o label field
        public static Label CreateFieldLabel(string text, int y)
        {
            return new Label
            {
                Text = text,
                Font = NormalFont,
                ForeColor = TextColor,
                AutoSize = false,
                Width = 120,
                Height = 25,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(20, y)
            };
        }
        
        // Helper ?? t?o textbox
        public static TextBox CreateTextBox(int y, int width = 230)
        {
            var textBox = new TextBox
            {
                Location = new Point(150, y - 2),
                Width = width,
                Font = NormalFont
            };
            StyleTextBox(textBox);
            return textBox;
        }
        
        // Helper ?? t?o button row
        public static void CreateButtonRow(Control container, int y, params (string text, EventHandler onClick, Color? color)[] buttons)
        {
            int xStart = 150;
            int spacing = 10;
            int buttonWidth = 110;
            
            for (int i = 0; i < buttons.Length; i++)
            {
                var (text, onClick, color) = buttons[i];
                var button = new Button
                {
                    Text = text,
                    Location = new Point(xStart + (buttonWidth + spacing) * i, y),
                    Width = buttonWidth
                };
                
                if (color.HasValue)
                    StyleButton(button, color.Value);
                else
                    StyleButton(button);
                    
                if (onClick != null)
                    button.Click += onClick;
                    
                container.Controls.Add(button);
            }
        }
    }
}
