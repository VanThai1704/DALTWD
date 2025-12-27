using System.Drawing;
using System.Windows.Forms;

namespace QLNhaSach
{
    partial class FormDonHang
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            toolStrip1 = new ToolStrip();
            btnAdd = new ToolStripButton();
            btnEdit = new ToolStripButton();
            btnDelete = new ToolStripButton();
            btnPrint = new ToolStripButton();
            btnExport = new ToolStripButton();
            txtSearch = new ToolStripTextBox();
            btnSearch = new ToolStripButton();
            dataGridView1 = new DataGridView();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnAdd, btnEdit, btnDelete, btnPrint, btnExport, txtSearch, btnSearch });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1000, 27);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            btnAdd.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            btnAdd.Image = null;
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(70, 24);
            btnAdd.Text = "Thêm";
            btnAdd.ToolTipText = "Thêm đơn hàng mới (Ctrl+N)";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            btnEdit.Image = null;
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(58, 24);
            btnEdit.Text = "Sửa";
            btnEdit.ToolTipText = "Chỉnh sửa đơn hàng (Ctrl+E)";
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            btnDelete.Image = null;
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(59, 24);
            btnDelete.Text = "Xóa";
            btnDelete.ToolTipText = "Xóa đơn hàng (Delete)";
            btnDelete.Click += btnDelete_Click;
            // 
            // btnPrint
            // 
            btnPrint.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            btnPrint.Image = null;
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(49, 24);
            btnPrint.Text = "In";
            btnPrint.ToolTipText = "In đơn hàng (Ctrl+P)";
            btnPrint.Click += btnPrint_Click;
            // 
            // btnExport
            // 
            btnExport.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            btnExport.Image = null;
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(101, 24);
            btnExport.Text = "Xuất Excel";
            btnExport.ToolTipText = "Xuất dữ liệu ra Excel (Ctrl+X)";
            btnExport.Click += btnExport_Click;
            // 
            // txtSearch
            // 
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(200, 27);
            // 
            // btnSearch
            // 
            btnSearch.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            btnSearch.Image = null;
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(90, 24);
            btnSearch.Text = "Tìm kiếm";
            btnSearch.ToolTipText = "Tìm kiếm đơn hàng (Ctrl+F)";
            btnSearch.Click += btnSearch_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 27);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1000, 573);
            dataGridView1.TabIndex = 0;
            // 
            // FormDonHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Controls.Add(dataGridView1);
            Controls.Add(toolStrip1);
            Name = "FormDonHang";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý đơn hàng";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
    }
}
