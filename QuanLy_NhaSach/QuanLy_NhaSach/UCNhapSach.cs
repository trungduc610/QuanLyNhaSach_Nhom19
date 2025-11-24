using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLy_NhaSach
{
    public partial class UCNhapSach : UserControl
    {
        string strKetNoi = @"Data Source=DESKTOP-DF0P4U3\SQLEXPRESS;Initial Catalog=NhaSach;User ID=sa;Password=123;Encrypt=True;TrustServerCertificate=True";

        string _maNhanVien = "NV001";
        string _tenNhanVien = "Admin";

        DataTable dtSach;
        BindingSource bsSach = new BindingSource();

        public UCNhapSach()
        {
            InitializeComponent();
        }

        public UCNhapSach(string maNV, string tenNV)
        {
            InitializeComponent();
            _maNhanVien = maNV;
            _tenNhanVien = tenNV;
        }

        private void UCNhapSach_Load(object sender, EventArgs e)
        {
            txtNhanVien.Text = _tenNhanVien;
            SinhMaPhieu();
            LoadNhaCungCap();
            LoadSach();
            cboSach.MaxDropDownItems = 8;
            cboSach.IntegralHeight = false;
            cboSach.DropDownHeight = 150;
        }

        private void SinhMaPhieu()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strKetNoi))
                {
                    conn.Open();
                    string query = "SELECT TOP 1 MaPhieuNhap FROM PHIEUNHAPHANG ORDER BY MaPhieuNhap DESC";
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
                            txtMaPhieu.Text = "PN" + maMoi.ToString("D3");
                        }
                        else
                        {
                            txtMaPhieu.Text = "PN001";
                        }
                    }
                    else
                    {
                        txtMaPhieu.Text = "PN001";
                    }
                }
            }
            catch (Exception ex)
            {
                txtMaPhieu.Text = "PN999";
                MessageBox.Show("Lỗi sinh mã phiếu: " + ex.Message);
            }
        }

        private void LoadNhaCungCap()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strKetNoi))
                {
                    conn.Open();
                    string query = "SELECT Ma_Nha_Cung_Cap, Ten_Nha_Cung_Cap FROM NHACUNGCAP";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboNhaCungCap.DataSource = dt;
                    cboNhaCungCap.DisplayMember = "Ten_Nha_Cung_Cap";
                    cboNhaCungCap.ValueMember = "Ma_Nha_Cung_Cap";
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi load NCC: " + ex.Message); }
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
            if (cboSach.SelectedValue != null)
            {
                DataRowView row = cboSach.SelectedItem as DataRowView;
                if (row != null)
                {
                    txtGiaNhap.Text = row["GiaNhap"].ToString();
                }
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
            if (string.IsNullOrEmpty(txtGiaNhap.Text)) { MessageBox.Show("Vui lòng nhập giá!"); return; }

            string maSach = cboSach.SelectedValue.ToString();
            string tenSach = cboSach.Text;
            decimal giaNhap = decimal.Parse(txtGiaNhap.Text);
            int soLuong = (int)numSoLuong.Value;
            decimal thanhTien = giaNhap * soLuong;

            foreach (DataGridViewRow row in dgvChiTietNhap.Rows)
            {
                if (row.Cells["colMaSach"].Value.ToString() == maSach)
                {
                    int slCu = int.Parse(row.Cells["colSoLuong"].Value.ToString());
                    row.Cells["colSoLuong"].Value = slCu + soLuong;
                    row.Cells["colGiaNhap"].Value = giaNhap;
                    row.Cells["colThanhTien"].Value = (slCu + soLuong) * giaNhap;
                    TinhTongTien();
                    return;
                }
            }

            dgvChiTietNhap.Rows.Add(maSach, tenSach, giaNhap, soLuong, thanhTien);
            TinhTongTien();
        }

        private void TinhTongTien()
        {
            decimal tong = 0;
            foreach (DataGridViewRow row in dgvChiTietNhap.Rows)
            {
                tong += decimal.Parse(row.Cells["colThanhTien"].Value.ToString());
            }
            lblTongTien.Text = tong.ToString("N0") + " VNĐ";
        }

        private void dgvChiTietNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvChiTietNhap.Columns["colXoa"].Index)
            {
                dgvChiTietNhap.Rows.RemoveAt(e.RowIndex);
                TinhTongTien();
            }
        }

        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            if (dgvChiTietNhap.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có sách nào trong phiếu nhập!");
                return;
            }

            if (cboNhaCungCap.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Nhà cung cấp!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(strKetNoi))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string queryPhieu = @"INSERT INTO PHIEUNHAPHANG (MaPhieuNhap, Ma_Nhan_Vien, Ma_Nha_Cung_Cap, NgayNhap, TongTienNhap) 
                                          VALUES (@MaPhieu, @MaNV, @MaNCC, @NgayNhap, 0)";

                    SqlCommand cmdPhieu = new SqlCommand(queryPhieu, conn, transaction);
                    cmdPhieu.Parameters.AddWithValue("@MaPhieu", txtMaPhieu.Text);
                    cmdPhieu.Parameters.AddWithValue("@MaNV", _maNhanVien);
                    cmdPhieu.Parameters.AddWithValue("@MaNCC", cboNhaCungCap.SelectedValue.ToString());
                    cmdPhieu.Parameters.AddWithValue("@NgayNhap", dtpNgayNhap.Value);
                    cmdPhieu.ExecuteNonQuery();

                    string queryChiTiet = @"INSERT INTO CHITIETPHIEUNHAP (MaPhieuNhap, MaSach, SoLuongNhap, DonGiaNhap) 
                                            VALUES (@MaPhieu, @MaSach, @SL, @DonGia)";

                    foreach (DataGridViewRow row in dgvChiTietNhap.Rows)
                    {
                        SqlCommand cmdCT = new SqlCommand(queryChiTiet, conn, transaction);
                        cmdCT.Parameters.AddWithValue("@MaPhieu", txtMaPhieu.Text);
                        cmdCT.Parameters.AddWithValue("@MaSach", row.Cells["colMaSach"].Value.ToString());
                        cmdCT.Parameters.AddWithValue("@SL", int.Parse(row.Cells["colSoLuong"].Value.ToString()));
                        cmdCT.Parameters.AddWithValue("@DonGia", decimal.Parse(row.Cells["colGiaNhap"].Value.ToString()));
                        cmdCT.ExecuteNonQuery();
                    }

                    transaction.Commit();

                    MessageBox.Show("Nhập hàng thành công! Tồn kho đã được cập nhật.");

                    dgvChiTietNhap.Rows.Clear();
                    SinhMaPhieu();
                    lblTongTien.Text = "0 VNĐ";
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi nhập hàng: " + ex.Message);
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
    }
}