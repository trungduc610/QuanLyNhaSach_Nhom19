namespace QuanLy_NhaSach
{
    partial class UCNhapSach
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
            this.grpThongTinPhieu = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaPhieu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cboNhaCungCap = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNhanVien = new System.Windows.Forms.TextBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.grpDanhSach = new System.Windows.Forms.GroupBox();
            this.dgvChiTietNhap = new System.Windows.Forms.DataGridView();
            this.colMaSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiaNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colXoa = new System.Windows.Forms.DataGridViewButtonColumn();
            this.grpNhapLieu = new System.Windows.Forms.GroupBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.numSoLuong = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.txtGiaNhap = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboSach = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTimKiemSach = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnLuuPhieu = new System.Windows.Forms.Button();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.grpThongTinPhieu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietNhap)).BeginInit();
            this.grpNhapLieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpThongTinPhieu
            // 
            this.grpThongTinPhieu.Controls.Add(this.tableLayoutPanel1);
            this.grpThongTinPhieu.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpThongTinPhieu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.grpThongTinPhieu.Location = new System.Drawing.Point(0, 0);
            this.grpThongTinPhieu.Name = "grpThongTinPhieu";
            this.grpThongTinPhieu.Size = new System.Drawing.Size(1228, 120);
            this.grpThongTinPhieu.TabIndex = 0;
            this.grpThongTinPhieu.TabStop = false;
            this.grpThongTinPhieu.Text = "Thông tin Phiếu Nhập";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtMaPhieu, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtpNgayNhap, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboNhaCungCap, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtNhanVien, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 30);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1222, 87);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã phiếu nhập:";
            // 
            // txtMaPhieu
            // 
            this.txtMaPhieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaPhieu.Enabled = false;
            this.txtMaPhieu.Location = new System.Drawing.Point(186, 5);
            this.txtMaPhieu.Name = "txtMaPhieu";
            this.txtMaPhieu.Size = new System.Drawing.Size(421, 32);
            this.txtMaPhieu.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(613, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ngày nhập:";
            // 
            // dtpNgayNhap
            // 
            this.dtpNgayNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayNhap.Location = new System.Drawing.Point(796, 5);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(423, 32);
            this.dtpNgayNhap.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nhà cung cấp:";
            // 
            // cboNhaCungCap
            // 
            this.cboNhaCungCap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboNhaCungCap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhaCungCap.FormattingEnabled = true;
            this.cboNhaCungCap.Location = new System.Drawing.Point(186, 53);
            this.cboNhaCungCap.Name = "cboNhaCungCap";
            this.cboNhaCungCap.Size = new System.Drawing.Size(421, 33);
            this.cboNhaCungCap.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(613, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nhân viên:";
            // 
            // txtNhanVien
            // 
            this.txtNhanVien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNhanVien.Enabled = false;
            this.txtNhanVien.Location = new System.Drawing.Point(796, 49);
            this.txtNhanVien.Name = "txtNhanVien";
            this.txtNhanVien.Size = new System.Drawing.Size(423, 32);
            this.txtNhanVien.TabIndex = 7;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grpDanhSach);
            this.pnlMain.Controls.Add(this.grpNhapLieu);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 120);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1228, 601);
            this.pnlMain.TabIndex = 1;
            // 
            // grpDanhSach
            // 
            this.grpDanhSach.Controls.Add(this.dgvChiTietNhap);
            this.grpDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDanhSach.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.grpDanhSach.Location = new System.Drawing.Point(400, 0);
            this.grpDanhSach.Name = "grpDanhSach";
            this.grpDanhSach.Size = new System.Drawing.Size(828, 601);
            this.grpDanhSach.TabIndex = 1;
            this.grpDanhSach.TabStop = false;
            this.grpDanhSach.Text = "Danh sách nhập (Xem trước)";
            // 
            // dgvChiTietNhap
            // 
            this.dgvChiTietNhap.AllowUserToAddRows = false;
            this.dgvChiTietNhap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietNhap.ColumnHeadersHeight = 35;
            this.dgvChiTietNhap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaSach,
            this.colTenSach,
            this.colGiaNhap,
            this.colSoLuong,
            this.colThanhTien,
            this.colXoa});
            this.dgvChiTietNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTietNhap.Location = new System.Drawing.Point(3, 28);
            this.dgvChiTietNhap.Name = "dgvChiTietNhap";
            this.dgvChiTietNhap.RowHeadersWidth = 51;
            this.dgvChiTietNhap.Size = new System.Drawing.Size(822, 570);
            this.dgvChiTietNhap.TabIndex = 0;
            this.dgvChiTietNhap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTietNhap_CellClick);
            // 
            // colMaSach
            // 
            this.colMaSach.FillWeight = 15F;
            this.colMaSach.HeaderText = "Mã sách";
            this.colMaSach.MinimumWidth = 6;
            this.colMaSach.Name = "colMaSach";
            // 
            // colTenSach
            // 
            this.colTenSach.FillWeight = 30F;
            this.colTenSach.HeaderText = "Tên sách";
            this.colTenSach.MinimumWidth = 6;
            this.colTenSach.Name = "colTenSach";
            // 
            // colGiaNhap
            // 
            this.colGiaNhap.FillWeight = 20F;
            this.colGiaNhap.HeaderText = "Giá nhập";
            this.colGiaNhap.MinimumWidth = 6;
            this.colGiaNhap.Name = "colGiaNhap";
            // 
            // colSoLuong
            // 
            this.colSoLuong.FillWeight = 10F;
            this.colSoLuong.HeaderText = "SL";
            this.colSoLuong.MinimumWidth = 6;
            this.colSoLuong.Name = "colSoLuong";
            // 
            // colThanhTien
            // 
            this.colThanhTien.FillWeight = 20F;
            this.colThanhTien.HeaderText = "Thành tiền";
            this.colThanhTien.MinimumWidth = 6;
            this.colThanhTien.Name = "colThanhTien";
            // 
            // colXoa
            // 
            this.colXoa.FillWeight = 5F;
            this.colXoa.HeaderText = "";
            this.colXoa.MinimumWidth = 6;
            this.colXoa.Name = "colXoa";
            this.colXoa.Text = "X";
            this.colXoa.UseColumnTextForButtonValue = true;
            // 
            // grpNhapLieu
            // 
            this.grpNhapLieu.Controls.Add(this.btnThem);
            this.grpNhapLieu.Controls.Add(this.numSoLuong);
            this.grpNhapLieu.Controls.Add(this.label8);
            this.grpNhapLieu.Controls.Add(this.txtGiaNhap);
            this.grpNhapLieu.Controls.Add(this.label7);
            this.grpNhapLieu.Controls.Add(this.cboSach);
            this.grpNhapLieu.Controls.Add(this.label6);
            this.grpNhapLieu.Controls.Add(this.txtTimKiemSach);
            this.grpNhapLieu.Controls.Add(this.label5);
            this.grpNhapLieu.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpNhapLieu.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.grpNhapLieu.Location = new System.Drawing.Point(0, 0);
            this.grpNhapLieu.Name = "grpNhapLieu";
            this.grpNhapLieu.Size = new System.Drawing.Size(400, 601);
            this.grpNhapLieu.TabIndex = 0;
            this.grpNhapLieu.TabStop = false;
            this.grpNhapLieu.Text = "Nhập sách vào phiếu";
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(24, 330);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(344, 50);
            this.btnThem.TabIndex = 8;
            this.btnThem.Text = "Thêm vào phiếu ⬇";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // numSoLuong
            // 
            this.numSoLuong.Location = new System.Drawing.Point(24, 270);
            this.numSoLuong.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numSoLuong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSoLuong.Name = "numSoLuong";
            this.numSoLuong.Size = new System.Drawing.Size(344, 32);
            this.numSoLuong.TabIndex = 7;
            this.numSoLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numSoLuong.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 240);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 25);
            this.label8.TabIndex = 6;
            this.label8.Text = "Số lượng nhập:";
            // 
            // txtGiaNhap
            // 
            this.txtGiaNhap.Location = new System.Drawing.Point(24, 190);
            this.txtGiaNhap.Name = "txtGiaNhap";
            this.txtGiaNhap.Size = new System.Drawing.Size(344, 32);
            this.txtGiaNhap.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 25);
            this.label7.TabIndex = 4;
            this.label7.Text = "Giá nhập:";
            // 
            // cboSach
            // 
            this.cboSach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSach.FormattingEnabled = true;
            this.cboSach.Location = new System.Drawing.Point(24, 110);
            this.cboSach.Name = "cboSach";
            this.cboSach.Size = new System.Drawing.Size(344, 33);
            this.cboSach.TabIndex = 3;
            this.cboSach.SelectedIndexChanged += new System.EventHandler(this.cboSach_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 25);
            this.label6.TabIndex = 2;
            this.label6.Text = "Chọn sách:";
            // 
            // txtTimKiemSach
            // 
            this.txtTimKiemSach.Location = new System.Drawing.Point(120, 35);
            this.txtTimKiemSach.Name = "txtTimKiemSach";
            this.txtTimKiemSach.Size = new System.Drawing.Size(248, 32);
            this.txtTimKiemSach.TabIndex = 1;
            this.txtTimKiemSach.TextChanged += new System.EventHandler(this.txtTimKiemSach_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tìm sách:";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFooter.Controls.Add(this.btnLuuPhieu);
            this.pnlFooter.Controls.Add(this.lblTongTien);
            this.pnlFooter.Controls.Add(this.label9);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 621);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1228, 100);
            this.pnlFooter.TabIndex = 2;
            // 
            // btnLuuPhieu
            // 
            this.btnLuuPhieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuuPhieu.BackColor = System.Drawing.Color.LimeGreen;
            this.btnLuuPhieu.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnLuuPhieu.ForeColor = System.Drawing.Color.White;
            this.btnLuuPhieu.Location = new System.Drawing.Point(985, 15);
            this.btnLuuPhieu.Name = "btnLuuPhieu";
            this.btnLuuPhieu.Size = new System.Drawing.Size(220, 70);
            this.btnLuuPhieu.TabIndex = 2;
            this.btnLuuPhieu.Text = "LƯU PHIẾU 💾";
            this.btnLuuPhieu.UseVisualStyleBackColor = false;
            this.btnLuuPhieu.Click += new System.EventHandler(this.btnLuuPhieu_Click);
            // 
            // lblTongTien
            // 
            this.lblTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.Red;
            this.lblTongTien.Location = new System.Drawing.Point(660, 30);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(300, 40);
            this.lblTongTien.TabIndex = 1;
            this.lblTongTien.Text = "0 VNĐ";
            this.lblTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label9.Location = new System.Drawing.Point(450, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(183, 32);
            this.label9.TabIndex = 0;
            this.label9.Text = "Tổng tiền nhập:";
            // 
            // UCNhapSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.grpThongTinPhieu);
            this.Name = "UCNhapSach";
            this.Size = new System.Drawing.Size(1228, 721);
            this.Load += new System.EventHandler(this.UCNhapSach_Load);
            this.grpThongTinPhieu.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietNhap)).EndInit();
            this.grpNhapLieu.ResumeLayout(false);
            this.grpNhapLieu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpThongTinPhieu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaPhieu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboNhaCungCap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNhanVien;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox grpDanhSach;
        private System.Windows.Forms.GroupBox grpNhapLieu;
        private System.Windows.Forms.DataGridView dgvChiTietNhap;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtGiaNhap;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboSach;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTimKiemSach;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnLuuPhieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGiaNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThanhTien;
        private System.Windows.Forms.DataGridViewButtonColumn colXoa;
    }
}