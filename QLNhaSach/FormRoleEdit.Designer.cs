namespace QLNhaSach
{
    partial class FormRoleEdit
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
            lblRoleName = new Label();
            txtRoleName = new TextBox();
            lblMoTa = new Label();
            txtMoTa = new TextBox();
            btnOK = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblRoleName
            // 
            lblRoleName.AutoSize = true;
            lblRoleName.Location = new Point(30, 30);
            lblRoleName.Name = "lblRoleName";
            lblRoleName.Size = new Size(80, 18);
            lblRoleName.TabIndex = 0;
            lblRoleName.Text = "Tên vai trò";
            // 
            // txtRoleName
            // 
            txtRoleName.Location = new Point(150, 27);
            txtRoleName.MaxLength = 50;
            txtRoleName.Name = "txtRoleName";
            txtRoleName.Size = new Size(300, 26);
            txtRoleName.TabIndex = 1;
            // 
            // lblMoTa
            // 
            lblMoTa.AutoSize = true;
            lblMoTa.Location = new Point(30, 70);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(46, 18);
            lblMoTa.TabIndex = 2;
            lblMoTa.Text = "Mô tả";
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(150, 67);
            txtMoTa.MaxLength = 500;
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(300, 120);
            txtMoTa.TabIndex = 3;
            // 
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(150, 210);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(100, 35);
            btnOK.TabIndex = 4;
            btnOK.Text = "Lưu";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(270, 210);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // FormRoleEdit
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(480, 270);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(txtMoTa);
            Controls.Add(lblMoTa);
            Controls.Add(txtRoleName);
            Controls.Add(lblRoleName);
            Font = new Font("Tahoma", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormRoleEdit";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thông tin vai trò";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblRoleName;
        private System.Windows.Forms.TextBox txtRoleName;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}
