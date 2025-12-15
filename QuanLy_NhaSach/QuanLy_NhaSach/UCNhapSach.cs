using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLy_NhaSach
{
    public partial class UCNhapSach : UserControl
    {
        private string _maNV;
        private string _tenNV;
        private DataTable _dtChiTiet;

        public UCNhapSach(string maNV, string tenNV)
        {
            InitializeComponent();
            _maNV = maNV;
            _tenNV = tenNV;

            // Kích hoạt load dữ liệu
            this.Load += new EventHandler(UCNhapSach_Load);
            this.VisibleChanged += new EventHandler(UCNhapSach_VisibleChanged);
            this.cboNhaCungCap.SelectedIndexChanged += new EventHandler(cboNhaCungCap_SelectedIndexChanged);
            KhoiTaoBangTam();
        }

        private void UCNhapSach_Load(object sender, EventArgs e)
        {
            LoadNhaCungCap();
            //LoadSach();
        }

        // --- 1. LOAD DỮ LIỆU TỪ DB HELPER ---
        private void LoadNhaCungCap()
        {
            string query = "SELECT * FROM NHACUNGCAP WHERE TrangThai = 1";
            cboNhaCungCap.DataSource = DatabaseHelper.GetDataTable(query);
            cboNhaCungCap.DisplayMember = "Ten_Nha_Cung_Cap";
            cboNhaCungCap.ValueMember = "Ma_Nha_Cung_Cap";
        }

        private void LoadSach()
        {
            cboSach.DataSource = DatabaseHelper.GetDataTable("SP_LayDanhSachSach");
            cboSach.DisplayMember = "TenSach";
            cboSach.ValueMember = "MaSach";

            // Cấu hình gợi ý tìm kiếm
            cboSach.DropDownStyle = ComboBoxStyle.DropDown;
            cboSach.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboSach.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void KhoiTaoBangTam()
        {
            _dtChiTiet = new DataTable();
            _dtChiTiet.Columns.Add("MaSach");
            _dtChiTiet.Columns.Add("TenSach");
            _dtChiTiet.Columns.Add("GiaNhap", typeof(decimal));
            _dtChiTiet.Columns.Add("SoLuong", typeof(int));
            _dtChiTiet.Columns.Add("ThanhTien", typeof(decimal));

            dgvChiTietNhap.DataSource = _dtChiTiet;

            // Thêm nút Xóa
            if (dgvChiTietNhap.Columns["colXoa"] == null)
            {
                DataGridViewButtonColumn btnXoa = new DataGridViewButtonColumn();
                btnXoa.Name = "colXoa";
                btnXoa.HeaderText = "Xóa";
                btnXoa.Text = "X";
                btnXoa.UseColumnTextForButtonValue = true;
                dgvChiTietNhap.Columns.Add(btnXoa);
            }
        }

        // --- 2. XỬ LÝ GIAO DIỆN ---
        private void cboSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSach.SelectedIndex != -1 && cboSach.SelectedItem is DataRowView row)
            {
                // Tự động điền giá nhập cũ để tham khảo
                txtGiaNhap.Text = row["GiaNhap"].ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboSach.SelectedIndex == -1) return;

            // Validate giá nhập
            if (!decimal.TryParse(txtGiaNhap.Text, out decimal giaNhap) || giaNhap <= 0)
            {
                MessageBox.Show("Giá nhập không hợp lệ!"); return;
            }

            DataRowView sach = (DataRowView)cboSach.SelectedItem;
            string maSach = sach["MaSach"].ToString();
            int soLuong = (int)numSoLuong.Value;

            // Kiểm tra trùng sách trong phiếu nhập
            foreach (DataRow r in _dtChiTiet.Rows)
            {
                if (r["MaSach"].ToString() == maSach)
                {
                    r["SoLuong"] = (int)r["SoLuong"] + soLuong;
                    r["GiaNhap"] = giaNhap; // Cập nhật giá mới nhất
                    r["ThanhTien"] = (int)r["SoLuong"] * giaNhap;
                    TinhTongTien();
                    return;
                }
            }

            _dtChiTiet.Rows.Add(maSach, sach["TenSach"], giaNhap, soLuong, giaNhap * soLuong);
            TinhTongTien();
        }

        private void dgvChiTietNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvChiTietNhap.Columns[e.ColumnIndex].Name == "colXoa")
            {
                dgvChiTietNhap.Rows.RemoveAt(e.RowIndex);
                TinhTongTien();
            }
        }

        private void TinhTongTien()
        {
            decimal tong = 0;
            foreach (DataRow r in _dtChiTiet.Rows) tong += Convert.ToDecimal(r["ThanhTien"]);
            lblTongTien.Text = tong.ToString("N0") + " VNĐ";
        }

        // --- 3. LƯU PHIẾU (TRANSACTION) ---
        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            if (_dtChiTiet.Rows.Count == 0) { MessageBox.Show("Chưa có sách nào!"); return; }
            if (cboNhaCungCap.SelectedIndex == -1) { MessageBox.Show("Chưa chọn Nhà cung cấp!"); return; }

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // Sinh mã PN + ddHHmmss (10 ký tự chuẩn)
                    string maPN = "PN" + DateTime.Now.ToString("ddHHmmss");

                    // 1. Insert Phiếu Nhập
                    string sqlPN = "INSERT INTO PHIEUNHAPHANG(MaPhieuNhap, Ma_Nhan_Vien, Ma_Nha_Cung_Cap, NgayNhap, TongTienNhap, TrangThai) VALUES (@MaPN, @MaNV, @MaNCC, GETDATE(), 0, 1)";
                    using (SqlCommand cmd = new SqlCommand(sqlPN, conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@MaPN", maPN);
                        cmd.Parameters.AddWithValue("@MaNV", _maNV);
                        cmd.Parameters.AddWithValue("@MaNCC", cboNhaCungCap.SelectedValue);
                        cmd.ExecuteNonQuery();
                    }

                    // 2. Insert Chi Tiết (Trigger sẽ tự cộng kho và update tổng tiền)
                    string sqlCT = "INSERT INTO CHITIETPHIEUNHAP(MaPhieuNhap, MaSach, SoLuongNhap, DonGiaNhap) VALUES (@MaPN, @MaSach, @SL, @DonGia)";
                    foreach (DataRow r in _dtChiTiet.Rows)
                    {
                        using (SqlCommand cmd = new SqlCommand(sqlCT, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@MaPN", maPN);
                            cmd.Parameters.AddWithValue("@MaSach", r["MaSach"]);
                            cmd.Parameters.AddWithValue("@SL", r["SoLuong"]);
                            cmd.Parameters.AddWithValue("@DonGia", r["GiaNhap"]);
                            cmd.ExecuteNonQuery();
                        }

                        // Cập nhật giá nhập mới nhất vào bảng SACH để tham khảo lần sau
                        string sqlUpdateGia = "UPDATE SACH SET GiaNhap = @GiaMoi WHERE MaSach = @MaSach";
                        using (SqlCommand cmdUpdate = new SqlCommand(sqlUpdateGia, conn, trans))
                        {
                            cmdUpdate.Parameters.AddWithValue("@GiaMoi", r["GiaNhap"]);
                            cmdUpdate.Parameters.AddWithValue("@MaSach", r["MaSach"]);
                            cmdUpdate.ExecuteNonQuery();
                        }
                    }

                    trans.Commit();
                    NotificationHelper.FireTransactionCompleted();
                    MessageBox.Show("Nhập hàng thành công! Mã: " + maPN);
                    _dtChiTiet.Rows.Clear();
                    lblTongTien.Text = "0 VNĐ";
                    LoadSach(); // Load lại để cập nhật giá nhập mới
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void UCNhapSach_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                // Tải lại danh sách sách và NCC mỗi khi tab này hiện ra
                LoadSach();
                LoadNhaCungCap();
            }
        }


        // Hàm load sách có tham số
        private void LoadSachTheoNCC(string maNCC)
        {
            SqlParameter[] pars = { new SqlParameter("@MaNCC", maNCC) };

            // Gọi Procedure lọc sách vừa tạo
            DataTable dtSachLoc = DatabaseHelper.GetDataTable("SP_LaySachTheoNhaCungCap", pars);

            // Thêm cột không dấu để tìm kiếm (như cũ)
            if (!dtSachLoc.Columns.Contains("TenSach_KhongDau"))
                dtSachLoc.Columns.Add("TenSach_KhongDau", typeof(string));

            foreach (DataRow row in dtSachLoc.Rows)
            {
                string tenGoc = row["TenSach"].ToString();
                row["TenSach_KhongDau"] = DatabaseHelper.XoaDau(tenGoc).ToLower();
            }

            // Gán dữ liệu
            cboSach.DataSource = dtSachLoc;
            cboSach.DisplayMember = "TenSach";
            cboSach.ValueMember = "MaSach";

            // Reset các ô nhập liệu
            cboSach.SelectedIndex = -1;
            txtGiaNhap.Text = "";
        }

        //Sự kiện khi chọn Nhà Cung Cấp
        private void cboNhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNhaCungCap.SelectedValue != null)
            {
                // Lấy mã NCC đang chọn
                string maNCC = cboNhaCungCap.SelectedValue.ToString();

                // Load lại danh sách sách tương ứng
                LoadSachTheoNCC(maNCC);
            }
        }
    }
}