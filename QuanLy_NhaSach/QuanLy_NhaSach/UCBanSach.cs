using System;
using System.Data;
using System.Data.SqlClient; // Để dùng Transaction
using System.Windows.Forms;

namespace QuanLy_NhaSach
{
    public partial class UCBanSach : UserControl
    {
        private string _maNV;
        private string _tenNV;
        private DataTable _dtSach;
        private DataTable _dtGioHang;

        public UCBanSach(string maNV, string tenNV)
        {
            InitializeComponent();
            _maNV = maNV;
            _tenNV = tenNV;
            this.Load += new EventHandler(UCBanSach_Load);
            this.VisibleChanged += new EventHandler(UCBanSach_VisibleChanged);
            KhoiTaoGioHang();
        }

        private void UCBanSach_Load(object sender, EventArgs e)
        {
            LoadKhachHang();
            LoadSach();
        }

        private void LoadKhachHang()
        {
            string query = "SELECT Ma_Khach_Hang, Ten_Khach_Hang FROM KHACHHANG WHERE TrangThai = 1";
            // Gọi Helper lấy bảng, không cần viết SqlConnection nữa
            cboKhachHang.DataSource = DatabaseHelper.GetDataTable(query);
            cboKhachHang.DisplayMember = "Ten_Khach_Hang";
            cboKhachHang.ValueMember = "Ma_Khach_Hang";
        }

        private void LoadSach()
        {
            // Gọi Helper lấy bảng Sách
            _dtSach = DatabaseHelper.GetDataTable("SP_LayDanhSachSach");

            if (!_dtSach.Columns.Contains("TenSach_KhongDau"))
                _dtSach.Columns.Add("TenSach_KhongDau", typeof(string));

            foreach (DataRow row in _dtSach.Rows)
            {
                // Gọi Helper hàm XoaDau
                row["TenSach_KhongDau"] = DatabaseHelper.XoaDau(row["TenSach"].ToString()).ToLower();
            }

            cboSach.DataSource = _dtSach;
            cboSach.DisplayMember = "TenSach";
            cboSach.ValueMember = "MaSach";
            cboSach.DropDownStyle = ComboBoxStyle.DropDown;
            cboSach.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboSach.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void KhoiTaoGioHang()
        {
            _dtGioHang = new DataTable();
            _dtGioHang.Columns.Add("MaSach");
            _dtGioHang.Columns.Add("TenSach");
            _dtGioHang.Columns.Add("DonGia", typeof(decimal));
            _dtGioHang.Columns.Add("SoLuong", typeof(int));
            _dtGioHang.Columns.Add("ThanhTien", typeof(decimal));
            dgvGioHang.DataSource = _dtGioHang;

            if (dgvGioHang.Columns["colXoa"] == null)
            {
                DataGridViewButtonColumn btnXoa = new DataGridViewButtonColumn();
                btnXoa.Name = "colXoa";
                btnXoa.HeaderText = "Xóa";
                btnXoa.Text = "X";
                btnXoa.UseColumnTextForButtonValue = true;
                dgvGioHang.Columns.Add(btnXoa);
            }
        }

        private void cboSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSach.SelectedIndex == -1) return;
            if (cboSach.SelectedItem is DataRowView row)
            {
                lblGiaBan.Text = Convert.ToDecimal(row["GiaBan"]).ToString("N0") + " VNĐ";
                lblTonKho.Text = $"(Tồn kho: {row["SoLuong"]})";
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (_dtSach == null) return;
            string tuKhoa = DatabaseHelper.XoaDau(txtTimKiem.Text.Trim()).ToLower();
            try
            {
                _dtSach.DefaultView.RowFilter = string.Format(
                    "MaSach LIKE '%{0}%' OR TenSach LIKE '%{0}%' OR TenSach_KhongDau LIKE '%{1}%'",
                    txtTimKiem.Text.Trim(), tuKhoa);
            }
            catch { _dtSach.DefaultView.RowFilter = ""; }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboSach.SelectedIndex == -1) return;
            DataRowView sach = (DataRowView)cboSach.SelectedItem;
            string maSach = sach["MaSach"].ToString();
            int soLuongMua = (int)numSoLuong.Value;
            int tonKho = Convert.ToInt32(sach["SoLuong"]);

            if (soLuongMua > tonKho) { MessageBox.Show("Không đủ hàng!", "Cảnh báo"); return; }

            foreach (DataRow r in _dtGioHang.Rows)
            {
                if (r["MaSach"].ToString() == maSach)
                {
                    r["SoLuong"] = (int)r["SoLuong"] + soLuongMua;
                    r["ThanhTien"] = (int)r["SoLuong"] * Convert.ToDecimal(r["DonGia"]);
                    TinhTongTien(); return;
                }
            }
            _dtGioHang.Rows.Add(maSach, sach["TenSach"], sach["GiaBan"], soLuongMua, (decimal)sach["GiaBan"] * soLuongMua);
            TinhTongTien();
        }

        private void dgvGioHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvGioHang.Columns[e.ColumnIndex].Name == "colXoa")
            {
                dgvGioHang.Rows.RemoveAt(e.RowIndex);
                TinhTongTien();
            }
        }

        private void TinhTongTien()
        {
            decimal tong = 0;
            foreach (DataRow r in _dtGioHang.Rows) tong += Convert.ToDecimal(r["ThanhTien"]);
            lblTongTien.Text = tong.ToString("N0") + " VNĐ";
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (_dtGioHang.Rows.Count == 0) { MessageBox.Show("Giỏ hàng trống!"); return; }

            string maHD = "";
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    maHD = "HD" + DateTime.Now.ToString("ddHHmmss");
                    string queryHD = "INSERT INTO HOADON (Ma_Hoa_Don, Ma_Nhan_Vien, Ma_Khach_Hang, NgayLap, TrangThai) VALUES (@MaHD, @MaNV, @MaKH, GETDATE(), 1)";

                    using (SqlCommand cmdHD = new SqlCommand(queryHD, conn, trans))
                    {
                        cmdHD.Parameters.AddWithValue("@MaHD", maHD);
                        cmdHD.Parameters.AddWithValue("@MaNV", _maNV);
                        if (cboKhachHang.SelectedValue != null) cmdHD.Parameters.AddWithValue("@MaKH", cboKhachHang.SelectedValue);
                        else cmdHD.Parameters.AddWithValue("@MaKH", DBNull.Value);
                        cmdHD.ExecuteNonQuery();
                    }

                    string queryCT = "INSERT INTO CHITIETHOADON (Ma_Hoa_Don, MaSach, SoLuong, DonGia) VALUES (@MaHD, @MaSach, @SoLuong, @DonGia)";
                    foreach (DataRow r in _dtGioHang.Rows)
                    {
                        using (SqlCommand cmdCT = new SqlCommand(queryCT, conn, trans))
                        {
                            cmdCT.Parameters.AddWithValue("@MaHD", maHD);
                            cmdCT.Parameters.AddWithValue("@MaSach", r["MaSach"]);
                            cmdCT.Parameters.AddWithValue("@SoLuong", r["SoLuong"]);
                            cmdCT.Parameters.AddWithValue("@DonGia", r["DonGia"]);
                            cmdCT.ExecuteNonQuery();
                        }
                    }

                    trans.Commit();
                    NotificationHelper.FireTransactionCompleted();
                    MessageBox.Show("Thanh toán thành công! Mã: " + maHD, "Thông báo");
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Lỗi: " + ex.Message);
                    return;
                }
            }

            //if (MessageBox.Show("Bạn có muốn in hóa đơn không?", "Thành công", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            //{
            //    frm_InHoaDon frmIn = new frm_InHoaDon(maHD);
            //    frmIn.ShowDialog();
            //}

            _dtGioHang.Rows.Clear();
            lblTongTien.Text = "0 VNĐ";
            LoadSach();
        }

        private void UCBanSach_VisibleChanged(object sender, EventArgs e)
        {
            // Nếu Form đang hiện lên (Visible = true) thì tải lại sách
            if (this.Visible == true)
            {
                LoadSach();
                // LoadKhachHang(); // Nếu muốn cập nhật cả khách hàng mới thêm
            }
        }
    }
}