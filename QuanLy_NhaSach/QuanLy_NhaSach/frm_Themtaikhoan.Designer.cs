namespace QuanLy_NhaSach
{
    partial class frm_Themtaikhoan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnHuy = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbTenSach = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_Xacnhanmk = new System.Windows.Forms.TextBox();
            this.txt_Matkhau = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txbTenDN = new System.Windows.Forms.TextBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.lblTenNhanVien = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.Red;
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Location = new System.Drawing.Point(218, 371);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(254, 60);
            this.btnHuy.TabIndex = 53;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label3.Location = new System.Drawing.Point(103, 291);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(297, 42);
            this.label3.TabIndex = 51;
            this.label3.Text = "Xác nhận mật khẩu:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label2.Location = new System.Drawing.Point(103, 215);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 42);
            this.label2.TabIndex = 50;
            this.label2.Text = "Mật khẩu:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbTenSach
            // 
            this.lbTenSach.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenSach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lbTenSach.Location = new System.Drawing.Point(103, 137);
            this.lbTenSach.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTenSach.Name = "lbTenSach";
            this.lbTenSach.Size = new System.Drawing.Size(236, 42);
            this.lbTenSach.TabIndex = 49;
            this.lbTenSach.Text = "Tên đăng nhập:";
            this.lbTenSach.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(439, 332);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(377, 1);
            this.panel2.TabIndex = 47;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(439, 256);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(377, 1);
            this.panel1.TabIndex = 46;
            // 
            // txt_Xacnhanmk
            // 
            this.txt_Xacnhanmk.BackColor = System.Drawing.Color.White;
            this.txt_Xacnhanmk.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Xacnhanmk.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Xacnhanmk.Location = new System.Drawing.Point(439, 294);
            this.txt_Xacnhanmk.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Xacnhanmk.Name = "txt_Xacnhanmk";
            this.txt_Xacnhanmk.PasswordChar = '*';
            this.txt_Xacnhanmk.Size = new System.Drawing.Size(377, 40);
            this.txt_Xacnhanmk.TabIndex = 44;
            // 
            // txt_Matkhau
            // 
            this.txt_Matkhau.BackColor = System.Drawing.Color.White;
            this.txt_Matkhau.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Matkhau.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Matkhau.Location = new System.Drawing.Point(439, 217);
            this.txt_Matkhau.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Matkhau.Name = "txt_Matkhau";
            this.txt_Matkhau.PasswordChar = '*';
            this.txt_Matkhau.Size = new System.Drawing.Size(377, 40);
            this.txt_Matkhau.TabIndex = 43;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Black;
            this.panel7.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel7.Location = new System.Drawing.Point(439, 176);
            this.panel7.Margin = new System.Windows.Forms.Padding(2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(377, 1);
            this.panel7.TabIndex = 42;
            // 
            // txbTenDN
            // 
            this.txbTenDN.BackColor = System.Drawing.Color.White;
            this.txbTenDN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbTenDN.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTenDN.Location = new System.Drawing.Point(439, 137);
            this.txbTenDN.Margin = new System.Windows.Forms.Padding(2);
            this.txbTenDN.Name = "txbTenDN";
            this.txbTenDN.Size = new System.Drawing.Size(377, 40);
            this.txbTenDN.TabIndex = 41;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(528, 371);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(254, 60);
            this.btnLuu.TabIndex = 54;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // lblTenNhanVien
            // 
            this.lblTenNhanVien.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenNhanVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTenNhanVien.Location = new System.Drawing.Point(169, 62);
            this.lblTenNhanVien.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTenNhanVien.Name = "lblTenNhanVien";
            this.lblTenNhanVien.Size = new System.Drawing.Size(557, 42);
            this.lblTenNhanVien.TabIndex = 55;
            this.lblTenNhanVien.Text = "Cấp tài khoản ";
            this.lblTenNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frm_Themtaikhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(934, 539);
            this.Controls.Add(this.lblTenNhanVien);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbTenSach);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt_Xacnhanmk);
            this.Controls.Add(this.txt_Matkhau);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.txbTenDN);
            this.Name = "frm_Themtaikhoan";
            this.Text = "Thêm Tài khoản ";
            this.Load += new System.EventHandler(this.frm_Themtaikhoan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbTenSach;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_Xacnhanmk;
        private System.Windows.Forms.TextBox txt_Matkhau;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox txbTenDN;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Label lblTenNhanVien;
    }
}