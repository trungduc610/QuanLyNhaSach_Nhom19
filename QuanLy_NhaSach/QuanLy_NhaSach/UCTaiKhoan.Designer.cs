namespace QuanLy_NhaSach
{
    partial class UCTaiKhoan
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.btnAdminTools = new System.Windows.Forms.Button(); // Nút mới
            this.lblQuyen = new System.Windows.Forms.Label();
            this.lblTenDN = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpDoiMK = new System.Windows.Forms.GroupBox();
            this.btnDoiMK = new System.Windows.Forms.Button();
            this.txtNhapLaiMK = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMKMoi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMKCu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grpThongTin.SuspendLayout();
            this.grpDoiMK.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.btnAdminTools);
            this.grpThongTin.Controls.Add(this.lblQuyen);
            this.grpThongTin.Controls.Add(this.lblTenDN);
            this.grpThongTin.Controls.Add(this.label3);
            this.grpThongTin.Controls.Add(this.label2);
            this.grpThongTin.Controls.Add(this.label1);
            this.grpThongTin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.grpThongTin.Location = new System.Drawing.Point(364, 50);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(500, 220); // Tăng chiều cao để chứa nút mới
            this.grpThongTin.TabIndex = 0;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin tài khoản";
            // 
            // btnAdminTools
            // 
            this.btnAdminTools.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAdminTools.FlatAppearance.BorderSize = 0;
            this.btnAdminTools.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdminTools.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdminTools.ForeColor = System.Drawing.Color.White;
            this.btnAdminTools.Location = new System.Drawing.Point(30, 160); // Vị trí nút Admin Tools
            this.btnAdminTools.Name = "btnAdminTools";
            this.btnAdminTools.Size = new System.Drawing.Size(440, 40);
            this.btnAdminTools.TabIndex = 5;
            this.btnAdminTools.Text = "CÔNG CỤ QUẢN TRỊ (Backup/Restore)";
            this.btnAdminTools.UseVisualStyleBackColor = false;
            this.btnAdminTools.Visible = false; // Mặc định ẩn
            this.btnAdminTools.Click += new System.EventHandler(this.btnAdminTools_Click);
            // 
            // lblQuyen
            // 
            this.lblQuyen.AutoSize = true;
            this.lblQuyen.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblQuyen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblQuyen.Location = new System.Drawing.Point(200, 110);
            this.lblQuyen.Name = "lblQuyen";
            this.lblQuyen.Size = new System.Drawing.Size(111, 28);
            this.lblQuyen.TabIndex = 4;
            this.lblQuyen.Text = "[QUYEN]";
            // 
            // lblTenDN
            // 
            this.lblTenDN.AutoSize = true;
            this.lblTenDN.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTenDN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblTenDN.Location = new System.Drawing.Point(200, 60);
            this.lblTenDN.Name = "lblTenDN";
            this.lblTenDN.Size = new System.Drawing.Size(117, 28);
            this.lblTenDN.TabIndex = 3;
            this.lblTenDN.Text = "[TENDN]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(30, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "Quyền:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 28);
            this.label2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(30, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đang nhập là:";
            // 
            // grpDoiMK
            // 
            this.grpDoiMK.Controls.Add(this.btnDoiMK);
            this.grpDoiMK.Controls.Add(this.txtNhapLaiMK);
            this.grpDoiMK.Controls.Add(this.label6);
            this.grpDoiMK.Controls.Add(this.txtMKMoi);
            this.grpDoiMK.Controls.Add(this.label5);
            this.grpDoiMK.Controls.Add(this.txtMKCu);
            this.grpDoiMK.Controls.Add(this.label4);
            this.grpDoiMK.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpDoiMK.Location = new System.Drawing.Point(364, 300); // Điều chỉnh vị trí Y
            this.grpDoiMK.Name = "grpDoiMK";
            this.grpDoiMK.Size = new System.Drawing.Size(500, 350);
            this.grpDoiMK.TabIndex = 1;
            this.grpDoiMK.TabStop = false;
            this.grpDoiMK.Text = "Đổi mật khẩu";
            // 
            // btnDoiMK
            // 
            this.btnDoiMK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDoiMK.FlatAppearance.BorderSize = 0;
            this.btnDoiMK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoiMK.ForeColor = System.Drawing.Color.White;
            this.btnDoiMK.Location = new System.Drawing.Point(20, 270);
            this.btnDoiMK.Name = "btnDoiMK";
            this.btnDoiMK.Size = new System.Drawing.Size(460, 45);
            this.btnDoiMK.TabIndex = 6;
            this.btnDoiMK.Text = "CẬP NHẬT MẬT KHẨU";
            this.btnDoiMK.UseVisualStyleBackColor = false;
            this.btnDoiMK.Click += new System.EventHandler(this.btnDoiMK_Click);
            // 
            // txtNhapLaiMK
            // 
            this.txtNhapLaiMK.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtNhapLaiMK.Location = new System.Drawing.Point(20, 215);
            this.txtNhapLaiMK.Name = "txtNhapLaiMK";
            this.txtNhapLaiMK.Size = new System.Drawing.Size(460, 32);
            this.txtNhapLaiMK.TabIndex = 5;
            this.txtNhapLaiMK.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label6.Location = new System.Drawing.Point(15, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(183, 25);
            this.label6.TabIndex = 4;
            this.label6.Text = "Nhập lại mật khẩu:";
            // 
            // txtMKMoi
            // 
            this.txtMKMoi.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMKMoi.Location = new System.Drawing.Point(20, 145);
            this.txtMKMoi.Name = "txtMKMoi";
            this.txtMKMoi.Size = new System.Drawing.Size(460, 32);
            this.txtMKMoi.TabIndex = 3;
            this.txtMKMoi.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label5.Location = new System.Drawing.Point(15, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 25);
            this.label5.TabIndex = 2;
            this.label5.Text = "Mật khẩu mới:";
            // 
            // txtMKCu
            // 
            this.txtMKCu.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMKCu.Location = new System.Drawing.Point(20, 75);
            this.txtMKCu.Name = "txtMKCu";
            this.txtMKCu.Size = new System.Drawing.Size(460, 32);
            this.txtMKCu.TabIndex = 1;
            this.txtMKCu.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label4.Location = new System.Drawing.Point(15, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mật khẩu cũ:";
            // 
            // UCTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpDoiMK);
            this.Controls.Add(this.grpThongTin);
            this.Name = "UCTaiKhoan";
            this.Size = new System.Drawing.Size(1228, 721);
            this.Load += new System.EventHandler(this.UCTaiKhoan_Load);
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.grpDoiMK.ResumeLayout(false);
            this.grpDoiMK.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblQuyen;
        private System.Windows.Forms.Label lblTenDN;
        private System.Windows.Forms.GroupBox grpDoiMK;
        private System.Windows.Forms.Button btnDoiMK;
        private System.Windows.Forms.TextBox txtNhapLaiMK;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMKMoi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMKCu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAdminTools; // Khai báo nút mới
    }
}