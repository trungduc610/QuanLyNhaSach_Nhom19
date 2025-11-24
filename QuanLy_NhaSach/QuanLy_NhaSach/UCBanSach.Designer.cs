namespace QuanLy_NhaSach
{
    partial class UCBanSach
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
            this.grpThongTinHD = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaHoaDon = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpNgayLap = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cboKhachHang = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNhanVien = new System.Windows.Forms.TextBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.grpDanhSach = new System.Windows.Forms.GroupBox();
            this.dgvChiTietBan = new System.Windows.Forms.DataGridView();
            this.colMaSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colXoa = new System.Windows.Forms.DataGridViewButtonColumn();
            this.grpNhapLieu = new System.Windows.Forms.GroupBox();
            this.txtTonKho = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.numSoLuong = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboSach = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTimKiemSach = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblTienThua = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTienKhachDua = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.grpThongTinHD.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietBan)).BeginInit();
            this.grpNhapLieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpThongTinHD
            // 
            this.grpThongTinHD.Controls.Add(this.tableLayoutPanel1);
            this.grpThongTinHD.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpThongTinHD.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.grpThongTinHD.Location = new System.Drawing.Point(0, 0);
            this.grpThongTinHD.Name = "grpThongTinHD";
            this.grpThongTinHD.Size = new System.Drawing.Size(1228, 120);
            this.grpThongTinHD.TabIndex = 0;
            this.grpThongTinHD.TabStop = false;
            this.grpThongTinHD.Text = "Thông tin Hóa Đơn";
            this.grpThongTinHD.Enter += new System.EventHandler(this.grpThongTinHD_Enter);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtMaHoaDon, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtpNgayLap, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboKhachHang, 1, 1);
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
            this.label1.Size = new System.Drawing.Size(118, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã hóa đơn:";
            // 
            // txtMaHoaDon
            // 
            this.txtMaHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaHoaDon.Enabled = false;
            this.txtMaHoaDon.Location = new System.Drawing.Point(186, 5);
            this.txtMaHoaDon.Name = "txtMaHoaDon";
            this.txtMaHoaDon.Size = new System.Drawing.Size(421, 32);
            this.txtMaHoaDon.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(613, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ngày lập:";
            // 
            // dtpNgayLap
            // 
            this.dtpNgayLap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayLap.Location = new System.Drawing.Point(796, 5);
            this.dtpNgayLap.Name = "dtpNgayLap";
            this.dtpNgayLap.Size = new System.Drawing.Size(423, 32);
            this.dtpNgayLap.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Khách hàng:";
            // 
            // cboKhachHang
            // 
            this.cboKhachHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboKhachHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhachHang.FormattingEnabled = true;
            this.cboKhachHang.Location = new System.Drawing.Point(186, 53);
            this.cboKhachHang.Name = "cboKhachHang";
            this.cboKhachHang.Size = new System.Drawing.Size(421, 33);
            this.cboKhachHang.TabIndex = 5;
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
            this.grpDanhSach.Controls.Add(this.dgvChiTietBan);
            this.grpDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDanhSach.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.grpDanhSach.Location = new System.Drawing.Point(400, 0);
            this.grpDanhSach.Name = "grpDanhSach";
            this.grpDanhSach.Size = new System.Drawing.Size(828, 601);
            this.grpDanhSach.TabIndex = 1;
            this.grpDanhSach.TabStop = false;
            this.grpDanhSach.Text = "Giỏ hàng (Chi tiết hóa đơn)";
            // 
            // dgvChiTietBan
            // 
            this.dgvChiTietBan.AllowUserToAddRows = false;
            this.dgvChiTietBan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietBan.ColumnHeadersHeight = 35;
            this.dgvChiTietBan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaSach,
            this.colTenSach,
            this.colGiaBan,
            this.colSoLuong,
            this.colThanhTien,
            this.colXoa});
            this.dgvChiTietBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTietBan.Location = new System.Drawing.Point(3, 28);
            this.dgvChiTietBan.Name = "dgvChiTietBan";
            this.dgvChiTietBan.RowHeadersWidth = 51;
            this.dgvChiTietBan.Size = new System.Drawing.Size(822, 570);
            this.dgvChiTietBan.TabIndex = 0;
            this.dgvChiTietBan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTietBan_CellClick);
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
            // colGiaBan
            // 
            this.colGiaBan.FillWeight = 20F;
            this.colGiaBan.HeaderText = "Giá bán";
            this.colGiaBan.MinimumWidth = 6;
            this.colGiaBan.Name = "colGiaBan";
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
            this.grpNhapLieu.Controls.Add(this.txtTonKho);
            this.grpNhapLieu.Controls.Add(this.label10);
            this.grpNhapLieu.Controls.Add(this.btnThem);
            this.grpNhapLieu.Controls.Add(this.numSoLuong);
            this.grpNhapLieu.Controls.Add(this.label8);
            this.grpNhapLieu.Controls.Add(this.txtGiaBan);
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
            this.grpNhapLieu.Text = "Chọn sách bán";
            // 
            // txtTonKho
            // 
            this.txtTonKho.Enabled = false;
            this.txtTonKho.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtTonKho.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txtTonKho.Location = new System.Drawing.Point(149, 190);
            this.txtTonKho.Name = "txtTonKho";
            this.txtTonKho.Size = new System.Drawing.Size(219, 32);
            this.txtTonKho.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 193);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(124, 25);
            this.label10.TabIndex = 9;
            this.label10.Text = "Số lượng tồn:";
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(24, 379);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(344, 50);
            this.btnThem.TabIndex = 8;
            this.btnThem.Text = "Thêm vào hóa đơn ➡";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // numSoLuong
            // 
            this.numSoLuong.Location = new System.Drawing.Point(24, 330);
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
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 300);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 25);
            this.label8.TabIndex = 6;
            this.label8.Text = "Số lượng mua:";
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Enabled = false;
            this.txtGiaBan.Location = new System.Drawing.Point(24, 255);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(344, 32);
            this.txtGiaBan.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 25);
            this.label7.TabIndex = 4;
            this.label7.Text = "Giá bán:";
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
            this.pnlFooter.Controls.Add(this.lblTienThua);
            this.pnlFooter.Controls.Add(this.label13);
            this.pnlFooter.Controls.Add(this.txtTienKhachDua);
            this.pnlFooter.Controls.Add(this.label11);
            this.pnlFooter.Controls.Add(this.btnThanhToan);
            this.pnlFooter.Controls.Add(this.lblTongTien);
            this.pnlFooter.Controls.Add(this.label9);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 621);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1228, 100);
            this.pnlFooter.TabIndex = 2;
            // 
            // lblTienThua
            // 
            this.lblTienThua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTienThua.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienThua.ForeColor = System.Drawing.Color.Green;
            this.lblTienThua.Location = new System.Drawing.Point(760, 65);
            this.lblTienThua.Name = "lblTienThua";
            this.lblTienThua.Size = new System.Drawing.Size(200, 32);
            this.lblTienThua.TabIndex = 6;
            this.lblTienThua.Text = "0 VNĐ";
            this.lblTienThua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label13.Location = new System.Drawing.Point(557, 70);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(97, 28);
            this.label13.TabIndex = 5;
            this.label13.Text = "Tiền thừa:";
            // 
            // txtTienKhachDua
            // 
            this.txtTienKhachDua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTienKhachDua.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienKhachDua.Location = new System.Drawing.Point(707, 3);
            this.txtTienKhachDua.Name = "txtTienKhachDua";
            this.txtTienKhachDua.Size = new System.Drawing.Size(253, 30);
            this.txtTienKhachDua.TabIndex = 4;
            this.txtTienKhachDua.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTienKhachDua.TextChanged += new System.EventHandler(this.txtTienKhachDua_TextChanged);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label11.Location = new System.Drawing.Point(507, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(147, 28);
            this.label11.TabIndex = 3;
            this.label11.Text = "Tiền khách đưa:";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThanhToan.BackColor = System.Drawing.Color.OrangeRed;
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(987, 19);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(220, 60);
            this.btnThanhToan.TabIndex = 2;
            this.btnThanhToan.Text = "THANH TOÁN 💲";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // lblTongTien
            // 
            this.lblTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.ForeColor = System.Drawing.Color.Red;
            this.lblTongTien.Location = new System.Drawing.Point(663, 29);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(300, 49);
            this.lblTongTien.TabIndex = 1;
            this.lblTongTien.Text = "0 VNĐ";
            this.lblTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(493, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(161, 28);
            this.label9.TabIndex = 0;
            this.label9.Text = "Tổng thanh toán:";
            // 
            // UCBanSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.grpThongTinHD);
            this.Name = "UCBanSach";
            this.Size = new System.Drawing.Size(1228, 721);
            this.Load += new System.EventHandler(this.UCBanSach_Load);
            this.grpThongTinHD.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietBan)).EndInit();
            this.grpNhapLieu.ResumeLayout(false);
            this.grpNhapLieu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpThongTinHD;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaHoaDon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpNgayLap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboKhachHang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNhanVien;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox grpDanhSach;
        private System.Windows.Forms.GroupBox grpNhapLieu;
        private System.Windows.Forms.DataGridView dgvChiTietBan;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtGiaBan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboSach;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTimKiemSach;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.TextBox txtTonKho;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThanhTien;
        private System.Windows.Forms.DataGridViewButtonColumn colXoa;
        
        private System.Windows.Forms.TextBox txtTienKhachDua;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblTienThua;
        private System.Windows.Forms.Label label13;
    }
}