using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLy_NhaSach
{
    public partial class UCBanSach : UserControl
    {
        string strKetNoi = @"Data Source=DESKTOP-DF0P4U3\SQLEXPRESS;Initial Catalog=NhaSach;User ID=sa;Password=123;Encrypt=True;TrustServerCertificate=True";

        string _maNhanVien = "";
        string _tenNhanVien = "";
        string _maTaiKhoan = "";
        private decimal _tongTienCanThanhToan = 0;

        DataTable dtSach;
        BindingSource bsSach = new BindingSource();

        public UCBanSach()
        {
            InitializeComponent();
        }

        public UCBanSach(string maTaiKhoan, string tenNhanVien)
        {
            InitializeComponent();
            _maTaiKhoan = maTaiKhoan;
            _tenNhanVien = tenNhanVien;
        }

        private void UCBanSach_Load(object sender, EventArgs e)
        {
            txtNhanVien.Text = _tenNhanVien;
            LayMaNhanVienTuTaiKhoan();
            SinhMaHoaDon();
            LoadKhachHang();
            LoadSach();
            cboSach.MaxDropDownItems = 8;
            cboSach.IntegralHeight = false;
            cboSach.DropDownHeight = 150;
        }

        private void LayMaNhanVienTuTaiKhoan()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strKetNoi))
                {
                    conn.Open();
                    string query = "SELECT Ma_Nhan_Vien FROM TAIKHOAN WHERE TenDangNhap = @TenDN";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TenDN", _maTaiKhoan);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        _maNhanVien = result.ToString();
                    }
                    else
                    {
                        _maNhanVien = "NV001";
                    }
                }
            }
            catch { _maNhanVien = "NV001"; }
        }

        private void SinhMaHoaDon()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strKetNoi))
                {
                    conn.Open();
                    string query = "SELECT TOP 1 Ma_Hoa_Don FROM HOADON ORDER BY Ma_Hoa_Don DESC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        string maCuoi = result.ToString().Trim();

                        string phanSo = maCuoi.Substring(2);
                        int soThuTu = 0;

                        if (int.TryParse(phanSo, out soThuTu))
                        {
                            int maMoi = soThuTu + 1;
                            txtMaHoaDon.Text = "HD" + maMoi.ToString("D3");
                        }
                        else
                        {
                            txtMaHoaDon.Text = "HD001";
                        }
                    }
                    else
                    {
                        txtMaHoaDon.Text = "HD001";
                    }
                }
            }
            catch (Exception ex)
            {
                txtMaHoaDon.Text = "HD999";
                MessageBox.Show("Lỗi sinh mã: " + ex.Message);
            }
        }

        private void LoadKhachHang()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strKetNoi))
                {
                    conn.Open();
                    string query = "SELECT Ma_Khach_Hang, Ten_Khach_Hang FROM KHACHHANG";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboKhachHang.DataSource = dt;
                    cboKhachHang.DisplayMember = "Ten_Khach_Hang";
                    cboKhachHang.ValueMember = "Ma_Khach_Hang";
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi load KH: " + ex.Message); }
        }

        private void LoadSach()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strKetNoi))
                {
                    conn.Open();
                    string query = "SELECT MaSach, TenSach, GiaBan, SoLuong, GiaNhap FROM SACH";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    dtSach = new DataTable();
                    da.Fill(dtSach);

                    dtSach.Columns.Add("TenSach_KhongDau", typeof(string));

                    foreach (DataRow row in dtSach.Rows)
                    {
                        string tenSach = row["TenSach"] != DBNull.Value ? row["TenSach"].ToString() : "";
                        string maSach = row["MaSach"] != DBNull.Value ? row["MaSach"].ToString() : "";

                        string gopChuoi = tenSach + " " + maSach;

                        row["TenSach_KhongDau"] = XoaDau(gopChuoi);
                    }

                    bsSach.DataSource = dtSach;

                    cboSach.DataSource = bsSach;
                    cboSach.DisplayMember = "TenSach";
                    cboSach.ValueMember = "MaSach";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load Sách: " + ex.Message);
            }
        }

        private void cboSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSach.SelectedValue != null && cboSach.SelectedItem is DataRowView row)
            {
                txtGiaBan.Text = decimal.Parse(row["GiaBan"].ToString()).ToString("N0");
                txtTonKho.Text = row["SoLuong"].ToString();
            }
        }

        private void txtTimKiemSach_TextChanged(object sender, EventArgs e)
        {
            if (bsSach.DataSource == null) return;

            string tuKhoa = txtTimKiemSach.Text.Trim();
            string tuKhoaKhongDau = XoaDau(tuKhoa);

            try
            {
                if (!string.IsNullOrEmpty(tuKhoaKhongDau))
                {
                    string[] cacTu = tuKhoaKhongDau.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    System.Collections.Generic.List<string> cacDieuKien = new System.Collections.Generic.List<string>();

                    foreach (string tu in cacTu)
                    {
                        cacDieuKien.Add($"TenSach_KhongDau LIKE '%{tu}%'");
                    }

                    bsSach.Filter = string.Join(" AND ", cacDieuKien);
                }
                else
                {
                    bsSach.RemoveFilter();
                }

                if (cboSach.Items.Count > 0 && !string.IsNullOrEmpty(tuKhoa))
                {
                    cboSach.DroppedDown = true;
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    cboSach.DroppedDown = false;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboSach.SelectedValue == null) return;

            string maSach = cboSach.SelectedValue.ToString();
            string tenSach = cboSach.Text;
            decimal giaBan = decimal.Parse(txtGiaBan.Text);
            int tonKho = int.Parse(txtTonKho.Text);
            int soLuongMua = (int)numSoLuong.Value;

            if (soLuongMua > tonKho)
            {
                MessageBox.Show($"Sách này chỉ còn {tonKho} cuốn. Không đủ để bán!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow row in dgvChiTietBan.Rows)
            {
                if (row.Cells["colMaSach"].Value.ToString() == maSach)
                {
                    int slHienTaiTrongGio = int.Parse(row.Cells["colSoLuong"].Value.ToString());
                    int slMoi = slHienTaiTrongGio + soLuongMua;

                    if (slMoi > tonKho)
                    {
                        MessageBox.Show($"Tổng số lượng mua ({slMoi}) vượt quá tồn kho ({tonKho})!", "Cảnh báo");
                        return;
                    }

                    row.Cells["colSoLuong"].Value = slMoi;
                    row.Cells["colThanhTien"].Value = slMoi * giaBan;
                    TinhTongTien();
                    return;
                }
            }

            decimal thanhTien = giaBan * soLuongMua;
            dgvChiTietBan.Rows.Add(maSach, tenSach, giaBan, soLuongMua, thanhTien);
            TinhTongTien();
        }

        private void TinhTongTien()
        {
            _tongTienCanThanhToan = 0;
            foreach (DataGridViewRow row in dgvChiTietBan.Rows)
            {
                _tongTienCanThanhToan += decimal.Parse(row.Cells["colThanhTien"].Value.ToString());
            }

            lblTongTien.Text = _tongTienCanThanhToan.ToString("N0") + " VNĐ";
            TinhTienThua();
        }

        private void txtTienKhachDua_TextChanged(object sender, EventArgs e)
        {
            TinhTienThua();
        }

        private void TinhTienThua()
        {
            try
            {
                string rawText = txtTienKhachDua.Text.Replace(",", "").Replace(".", "");
                decimal tienKhachDua = 0;
                if (!string.IsNullOrEmpty(rawText))
                {
                    if (!decimal.TryParse(rawText, out tienKhachDua))
                    {
                        lblTienThua.Text = "Lỗi nhập";
                        return;
                    }
                }

                decimal tienThua = tienKhachDua - _tongTienCanThanhToan;

                lblTienThua.Text = tienThua.ToString("N0") + " VNĐ";

                if (tienThua < 0)
                {
                    lblTienThua.ForeColor = Color.Red;
                }
                else
                {
                    lblTienThua.ForeColor = Color.Green;
                }
            }
            catch
            {
                lblTienThua.Text = "0 VNĐ";
            }
        }

        private void dgvChiTietBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvChiTietBan.Columns["colXoa"].Index)
            {
                dgvChiTietBan.Rows.RemoveAt(e.RowIndex);
                TinhTongTien();
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dgvChiTietBan.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng trống!");
                return;
            }

            if (cboKhachHang.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Khách hàng!");
                return;
            }

            string rawText = txtTienKhachDua.Text.Replace(",", "").Replace(".", "");
            decimal tienKhachDua = 0;
            decimal.TryParse(rawText, out tienKhachDua);

            if (tienKhachDua < _tongTienCanThanhToan)
            {
                decimal thieu = _tongTienCanThanhToan - tienKhachDua;
                MessageBox.Show($"Khách đưa thiếu tiền!\nCòn thiếu: {thieu.ToString("N0")} VNĐ",
                                "Chưa đủ tiền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTienKhachDua.Focus();
                return;
            }

            using (SqlConnection conn = new SqlConnection(strKetNoi))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string queryHD = @"INSERT INTO HOADON (Ma_Hoa_Don, Ma_Nhan_Vien, Ma_Khach_Hang, NgayLap, TongTien)
                                       VALUES (@MaHD, @MaNV, @MaKH, @NgayLap, 0)";

                    SqlCommand cmdHD = new SqlCommand(queryHD, conn, transaction);
                    cmdHD.Parameters.AddWithValue("@MaHD", txtMaHoaDon.Text);
                    cmdHD.Parameters.AddWithValue("@MaNV", _maNhanVien);
                    cmdHD.Parameters.AddWithValue("@MaKH", cboKhachHang.SelectedValue.ToString());
                    cmdHD.Parameters.AddWithValue("@NgayLap", dtpNgayLap.Value);
                    cmdHD.ExecuteNonQuery();

                    string queryCT = @"INSERT INTO CHITIETHOADON (Ma_Hoa_Don, MaSach, SoLuong)
                                       VALUES (@MaHD, @MaSach, @SoLuong)";

                    foreach (DataGridViewRow row in dgvChiTietBan.Rows)
                    {
                        SqlCommand cmdCT = new SqlCommand(queryCT, conn, transaction);
                        cmdCT.Parameters.AddWithValue("@MaHD", txtMaHoaDon.Text);
                        cmdCT.Parameters.AddWithValue("@MaSach", row.Cells["colMaSach"].Value.ToString());
                        cmdCT.Parameters.AddWithValue("@SoLuong", int.Parse(row.Cells["colSoLuong"].Value.ToString()));
                        cmdCT.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Thanh toán thành công! Hóa đơn đã được lưu.");

                    dgvChiTietBan.Rows.Clear();
                    lblTongTien.Text = "0 VNĐ";
                    txtTienKhachDua.Text = "";
                    lblTienThua.Text = "0 VNĐ";
                    _tongTienCanThanhToan = 0;
                    SinhMaHoaDon();
                    LoadSach();
                }
                catch (SqlException sqlEx)
                {
                    transaction.Rollback();
                    if (sqlEx.Message.Contains("Không đủ số lượng sách"))
                    {
                        MessageBox.Show("LỖI KHO: " + sqlEx.Message, "Hết hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi hệ thống: " + sqlEx.Message);
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi không xác định: " + ex.Message);
                }
            }
        }
        private string XoaDau(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;

            s = s.ToLower().Trim(); // Đưa về chữ thường và xóa khoảng trắng thừa

            // Thay thế các ký tự đặc biệt của tiếng Việt
            s = s.Replace("đ", "d").Replace("Đ", "d");

            // Dùng Regex để loại bỏ dấu
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(System.Text.NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'd');
        }

        private void grpThongTinHD_Enter(object sender, EventArgs e)
        {

        }
    }
}