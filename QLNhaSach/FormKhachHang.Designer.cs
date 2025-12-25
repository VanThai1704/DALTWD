namespace QLNhaSach
{
    partial class FormKhachHang
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // toolStrip1
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.btnAdd,
                this.btnEdit,
                this.btnDelete,
                this.btnExport,
                this.txtSearch,
                this.btnSearch
            });
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";

            // btnAdd
            this.btnAdd.Text = "Thêm"; this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text; this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // btnEdit
            this.btnEdit.Text = "Sửa"; this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text; this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // btnDelete
            this.btnDelete.Text = "Xóa"; this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text; this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // btnExport
            this.btnExport.Text = "Xuất Excel"; this.btnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text; this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // txtSearch
            this.txtSearch.Name = "txtSearch"; this.txtSearch.Size = new System.Drawing.Size(200, 27);
            // btnSearch
            this.btnSearch.Text = "Tìm"; this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text; this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // dataGridView1
            
            this.dataGridView1.AutoGenerateColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // FormKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormKhachHang";
            this.Text = "Qu?n lý Khách hàng";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
        }
        #endregion
    }
}
