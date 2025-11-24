namespace QuanLy_NhaSach
{
    partial class frm_Trangchu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Dangxuat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Taikhoan = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.btn_ThongKe = new System.Windows.Forms.Button();
            this.btn_QLNV = new System.Windows.Forms.Button();
            this.btn_Nhapsach = new System.Windows.Forms.Button();
            this.btn_Bansach = new System.Windows.Forms.Button();
            this.btn_Taikhoan = new System.Windows.Forms.Button();
            this.btn_QLKH = new System.Windows.Forms.Button();
            this.btn_QLsach = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.btn_Dangxuat);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(295, 789);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btn_ThongKe, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.btn_QLNV, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btn_Nhapsach, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_Bansach, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Taikhoan, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btn_QLKH, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btn_QLsach, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 109);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(292, 424);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // btn_Dangxuat
            // 
            this.btn_Dangxuat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Dangxuat.FlatAppearance.BorderSize = 0;
            this.btn_Dangxuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Dangxuat.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.btn_Dangxuat.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Dangxuat.Location = new System.Drawing.Point(81, 708);
            this.btn_Dangxuat.Name = "btn_Dangxuat";
            this.btn_Dangxuat.Size = new System.Drawing.Size(125, 45);
            this.btn_Dangxuat.TabIndex = 8;
            this.btn_Dangxuat.Text = "Đăng xuất";
            this.btn_Dangxuat.UseVisualStyleBackColor = true;
            this.btn_Dangxuat.Click += new System.EventHandler(this.btn_Dangxuat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(75, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "QL Nhà Sách";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbl_Taikhoan
            // 
            this.lbl_Taikhoan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Taikhoan.AutoSize = true;
            this.lbl_Taikhoan.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lbl_Taikhoan.ForeColor = System.Drawing.Color.Black;
            this.lbl_Taikhoan.Location = new System.Drawing.Point(1283, 26);
            this.lbl_Taikhoan.Name = "lbl_Taikhoan";
            this.lbl_Taikhoan.Size = new System.Drawing.Size(140, 28);
            this.lbl_Taikhoan.TabIndex = 20;
            this.lbl_Taikhoan.Text = "Tên đăng nhập";
            // 
            // panelContent
            // 
            this.panelContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.Location = new System.Drawing.Point(301, 68);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1228, 721);
            this.panelContent.TabIndex = 1;
            this.panelContent.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContent_Paint);
            // 
            // btn_ThongKe
            // 
            this.btn_ThongKe.FlatAppearance.BorderSize = 0;
            this.btn_ThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ThongKe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ThongKe.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_ThongKe.Image = global::QuanLy_NhaSach.Properties.Resources.Thongke;
            this.btn_ThongKe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ThongKe.Location = new System.Drawing.Point(3, 363);
            this.btn_ThongKe.Name = "btn_ThongKe";
            this.btn_ThongKe.Size = new System.Drawing.Size(286, 58);
            this.btn_ThongKe.TabIndex = 0;
            this.btn_ThongKe.Text = "Thống kê Doanh Thu";
            this.btn_ThongKe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ThongKe.UseVisualStyleBackColor = true;
            this.btn_ThongKe.Click += new System.EventHandler(this.btn_ThongKe_Click);
            // 
            // btn_QLNV
            // 
            this.btn_QLNV.FlatAppearance.BorderSize = 0;
            this.btn_QLNV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_QLNV.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QLNV.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_QLNV.Image = global::QuanLy_NhaSach.Properties.Resources.QLnhanvien;
            this.btn_QLNV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_QLNV.Location = new System.Drawing.Point(3, 243);
            this.btn_QLNV.Name = "btn_QLNV";
            this.btn_QLNV.Size = new System.Drawing.Size(275, 54);
            this.btn_QLNV.TabIndex = 1;
            this.btn_QLNV.Text = "Quản Lý Nhân Viên";
            this.btn_QLNV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_QLNV.UseVisualStyleBackColor = true;
            this.btn_QLNV.Click += new System.EventHandler(this.btn_QLNV_Click);
            // 
            // btn_Nhapsach
            // 
            this.btn_Nhapsach.FlatAppearance.BorderSize = 0;
            this.btn_Nhapsach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Nhapsach.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Nhapsach.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Nhapsach.Image = global::QuanLy_NhaSach.Properties.Resources.Nhapsach;
            this.btn_Nhapsach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Nhapsach.Location = new System.Drawing.Point(3, 63);
            this.btn_Nhapsach.Name = "btn_Nhapsach";
            this.btn_Nhapsach.Size = new System.Drawing.Size(286, 54);
            this.btn_Nhapsach.TabIndex = 2;
            this.btn_Nhapsach.Text = "Nhập Sách";
            this.btn_Nhapsach.UseVisualStyleBackColor = true;
            this.btn_Nhapsach.Click += new System.EventHandler(this.btn_Nhapsach_Click);
            // 
            // btn_Bansach
            // 
            this.btn_Bansach.FlatAppearance.BorderSize = 0;
            this.btn_Bansach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Bansach.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Bansach.ForeColor = System.Drawing.Color.White;
            this.btn_Bansach.Image = global::QuanLy_NhaSach.Properties.Resources.Bansach;
            this.btn_Bansach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Bansach.Location = new System.Drawing.Point(3, 3);
            this.btn_Bansach.Name = "btn_Bansach";
            this.btn_Bansach.Size = new System.Drawing.Size(286, 54);
            this.btn_Bansach.TabIndex = 0;
            this.btn_Bansach.Text = "Bán Sách";
            this.btn_Bansach.UseVisualStyleBackColor = true;
            this.btn_Bansach.Click += new System.EventHandler(this.btn_Bansach_Click);
            // 
            // btn_Taikhoan
            // 
            this.btn_Taikhoan.FlatAppearance.BorderSize = 0;
            this.btn_Taikhoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Taikhoan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Taikhoan.ForeColor = System.Drawing.Color.White;
            this.btn_Taikhoan.Image = global::QuanLy_NhaSach.Properties.Resources.Taikhoan;
            this.btn_Taikhoan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Taikhoan.Location = new System.Drawing.Point(3, 123);
            this.btn_Taikhoan.Name = "btn_Taikhoan";
            this.btn_Taikhoan.Size = new System.Drawing.Size(286, 54);
            this.btn_Taikhoan.TabIndex = 0;
            this.btn_Taikhoan.Text = "Tài Khoản";
            this.btn_Taikhoan.UseVisualStyleBackColor = true;
            this.btn_Taikhoan.Click += new System.EventHandler(this.btn_Taikhoan_Click);
            // 
            // btn_QLKH
            // 
            this.btn_QLKH.FlatAppearance.BorderSize = 0;
            this.btn_QLKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_QLKH.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QLKH.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_QLKH.Image = global::QuanLy_NhaSach.Properties.Resources.QLkhachhang;
            this.btn_QLKH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_QLKH.Location = new System.Drawing.Point(3, 303);
            this.btn_QLKH.Name = "btn_QLKH";
            this.btn_QLKH.Size = new System.Drawing.Size(286, 54);
            this.btn_QLKH.TabIndex = 5;
            this.btn_QLKH.Text = "Quản Lý Khách Hàng";
            this.btn_QLKH.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_QLKH.UseVisualStyleBackColor = true;
            this.btn_QLKH.Click += new System.EventHandler(this.btn_QLKH_Click);
            // 
            // btn_QLsach
            // 
            this.btn_QLsach.FlatAppearance.BorderSize = 0;
            this.btn_QLsach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_QLsach.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QLsach.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_QLsach.Image = global::QuanLy_NhaSach.Properties.Resources.QLsach;
            this.btn_QLsach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_QLsach.Location = new System.Drawing.Point(3, 184);
            this.btn_QLsach.Name = "btn_QLsach";
            this.btn_QLsach.Size = new System.Drawing.Size(286, 53);
            this.btn_QLsach.TabIndex = 6;
            this.btn_QLsach.Text = "Quản Lý Sách";
            this.btn_QLsach.UseVisualStyleBackColor = true;
            this.btn_QLsach.Click += new System.EventHandler(this.btn_QLsach_Click);
            // 
            // frm_Trangchu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1529, 788);
            this.Controls.Add(this.lbl_Taikhoan);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panel1);
            this.Name = "frm_Trangchu";
            this.Text = "Trang chủ";
            this.Load += new System.EventHandler(this.frm_Trangchu_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Bansach;
        private System.Windows.Forms.Button btn_Nhapsach;
        private System.Windows.Forms.Button btn_QLsach;
        private System.Windows.Forms.Button btn_QLKH;
        private System.Windows.Forms.Button btn_QLNV;
        private System.Windows.Forms.Button btn_Taikhoan;
        private System.Windows.Forms.Button btn_ThongKe;
        private System.Windows.Forms.Button btn_Dangxuat;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbl_Taikhoan;
    }
}