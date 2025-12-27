using System.Drawing;
using System.Windows.Forms;

namespace QLNhaSach
{
    partial class FormRole
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            menuChucNang = new ToolStripMenuItem();
            menuThem = new ToolStripMenuItem();
            menuSua = new ToolStripMenuItem();
            menuXoa = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            menuDong = new ToolStripMenuItem();
            dataGridView1 = new DataGridView();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Tahoma", 9F);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuChucNang });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuChucNang
            // 
            menuChucNang.DropDownItems.AddRange(new ToolStripItem[] { menuThem, menuSua, menuXoa, toolStripSeparator1, menuDong });
            menuChucNang.Font = new Font("Tahoma", 9F);
            menuChucNang.Name = "menuChucNang";
            menuChucNang.Size = new Size(92, 24);
            menuChucNang.Text = "Chức năng";
            // 
            // menuThem
            // 
            menuThem.Font = new Font("Tahoma", 9F);
            menuThem.Image = null;
            menuThem.Name = "menuThem";
            menuThem.ShortcutKeys = Keys.Control | Keys.N;
            menuThem.Size = new Size(224, 26);
            menuThem.Text = "[+] Thêm";
            menuThem.Click += menuThem_Click;
            // 
            // menuSua
            // 
            menuSua.Font = new Font("Tahoma", 9F);
            menuSua.Image = null;
            menuSua.Name = "menuSua";
            menuSua.ShortcutKeys = Keys.Control | Keys.E;
            menuSua.Size = new Size(224, 26);
            menuSua.Text = "[~] Sửa";
            menuSua.Click += menuSua_Click;
            // 
            // menuXoa
            // 
            menuXoa.Font = new Font("Tahoma", 9F);
            menuXoa.Image = null;
            menuXoa.Name = "menuXoa";
            menuXoa.ShortcutKeys = Keys.Delete;
            menuXoa.Size = new Size(224, 26);
            menuXoa.Text = "[-] Xóa";
            menuXoa.Click += menuXoa_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(221, 6);
            // 
            // menuDong
            // 
            menuDong.Font = new Font("Tahoma", 9F);
            menuDong.Name = "menuDong";
            menuDong.ShortcutKeys = Keys.Alt | Keys.F4;
            menuDong.Size = new Size(224, 26);
            menuDong.Text = "Đóng";
            menuDong.Click += menuDong_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 28);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(800, 422);
            dataGridView1.TabIndex = 1;
            // 
            // FormRole
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            Font = new Font("Tahoma", 9F);
            MainMenuStrip = menuStrip1;
            Name = "FormRole";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý vai trò";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuChucNang;
        private System.Windows.Forms.ToolStripMenuItem menuThem;
        private System.Windows.Forms.ToolStripMenuItem menuSua;
        private System.Windows.Forms.ToolStripMenuItem menuXoa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuDong;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
