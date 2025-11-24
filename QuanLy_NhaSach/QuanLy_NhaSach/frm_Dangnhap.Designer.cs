namespace QuanLy_NhaSach
{
    partial class frm_DangNhap
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_TenDN = new System.Windows.Forms.TextBox();
            this.txt_Matkhau = new System.Windows.Forms.TextBox();
            this.btn_Dangnhap = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(167, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "Đăng Nhập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(72, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên đăng nhập:";
            // 
            // txt_TenDN
            // 
            this.txt_TenDN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(243)))), ((int)(((byte)(206)))));
            this.txt_TenDN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_TenDN.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TenDN.Location = new System.Drawing.Point(77, 145);
            this.txt_TenDN.Name = "txt_TenDN";
            this.txt_TenDN.Size = new System.Drawing.Size(365, 31);
            this.txt_TenDN.TabIndex = 1;
            this.txt_TenDN.TextChanged += new System.EventHandler(this.txt_TenDN_TextChanged);
            this.txt_TenDN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_TenDN_KeyDown);
            // 
            // txt_Matkhau
            // 
            this.txt_Matkhau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(243)))), ((int)(((byte)(206)))));
            this.txt_Matkhau.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Matkhau.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.txt_Matkhau.Location = new System.Drawing.Point(77, 246);
            this.txt_Matkhau.Name = "txt_Matkhau";
            this.txt_Matkhau.PasswordChar = '*';
            this.txt_Matkhau.Size = new System.Drawing.Size(365, 32);
            this.txt_Matkhau.TabIndex = 4;
            this.txt_Matkhau.TextChanged += new System.EventHandler(this.txt_TenDN_TextChanged);
            this.txt_Matkhau.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Matkhau_KeyPress);
            // 
            // btn_Dangnhap
            // 
            this.btn_Dangnhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(50)))), ((int)(((byte)(94)))));
            this.btn_Dangnhap.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.btn_Dangnhap.ForeColor = System.Drawing.Color.White;
            this.btn_Dangnhap.Location = new System.Drawing.Point(77, 317);
            this.btn_Dangnhap.Name = "btn_Dangnhap";
            this.btn_Dangnhap.Size = new System.Drawing.Size(365, 51);
            this.btn_Dangnhap.TabIndex = 5;
            this.btn_Dangnhap.Text = "Đăng nhập";
            this.btn_Dangnhap.UseVisualStyleBackColor = false;
            this.btn_Dangnhap.Click += new System.EventHandler(this.btn_Dangnhap_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(72, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 28);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mật khẩu:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel1.Location = new System.Drawing.Point(77, 175);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(365, 2);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel2.Location = new System.Drawing.Point(77, 276);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(365, 2);
            this.panel2.TabIndex = 8;
            // 
            // frm_DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(243)))), ((int)(((byte)(206)))));
            this.ClientSize = new System.Drawing.Size(513, 418);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Dangnhap);
            this.Controls.Add(this.txt_Matkhau);
            this.Controls.Add(this.txt_TenDN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            this.Load += new System.EventHandler(this.frm_DangNhap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_TenDN;
        private System.Windows.Forms.TextBox txt_Matkhau;
        private System.Windows.Forms.Button btn_Dangnhap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}