using System.Drawing;
using System.Windows.Forms;

namespace QLNhaSach
{
    partial class FormSach
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
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
            // 
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
            this.toolStrip1.Size = new System.Drawing.Size(1000, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(16, 16);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;

            // btnAdd
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(70, 24);
            this.btnAdd.Text = "Thêm"; 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText; 
            this.btnAdd.Image = null;
            this.btnAdd.ToolTipText = "Thêm sách mới (Ctrl+N)";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            
            // btnEdit
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(58, 24);
            this.btnEdit.Text = "Sửa"; 
            this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText; 
            this.btnEdit.Image = null;
            this.btnEdit.ToolTipText = "Chỉnh sửa thông tin sách (Ctrl+E)";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            
            // btnDelete
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(59, 24);
            this.btnDelete.Text = "Xóa"; 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText; 
            this.btnDelete.Image = null;
            this.btnDelete.ToolTipText = "Xóa sách (Delete)";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            
            // btnExport
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(101, 24);
            this.btnExport.Text = "Xuất Excel"; 
            this.btnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText; 
            this.btnExport.Image = null;
            this.btnExport.ToolTipText = "Xuất danh sách ra Excel (Ctrl+X)";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            
            this.txtSearch.Name = "txtSearch"; 
            this.txtSearch.Size = new System.Drawing.Size(200, 27);
            
            // btnSearch
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 24);
            this.btnSearch.Text = "Tìm kiếm"; 
            this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText; 
            this.btnSearch.Image = null;
            this.btnSearch.ToolTipText = "Tìm kiếm sách (Ctrl+F)";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // dataGridView1
            // 
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
            // FormSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormSach";
            this.Text = "Qu?n lý Sách";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
