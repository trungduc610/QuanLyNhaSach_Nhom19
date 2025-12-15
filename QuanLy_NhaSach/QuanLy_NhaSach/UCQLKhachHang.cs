using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLy_NhaSach
{
    public partial class UCQLKhachHang : UserControl
    {
        private DataTable _dtKhachHang;

        public UCQLKhachHang()
        {
            InitializeComponent();
            this.VisibleChanged += new EventHandler(UCQLKhachHang_VisibleChanged);
        }

        private void UCQLKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
            ResetForm();
        }

        private void UCQLKhachHang_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                LoadData();
            }
        }

        // --- 1. TẢI DỮ LIỆU ---
        private void LoadData()
        {
            _dtKhachHang = DatabaseHelper.GetDataTable("SP_LayDanhSachKhachHang");

            // Thêm cột không dấu cho tìm kiếm
            if (!_dtKhachHang.Columns.Contains("TenKhachHang_KhongDau"))
            {
                _dtKhachHang.Columns.Add("TenKhachHang_KhongDau");
            }

            foreach (DataRow r in _dtKhachHang.Rows)
            {
                string tenKH = r["Ten_Khach_Hang"] != DBNull.Value ? r["Ten_Khach_Hang"].ToString() : "";
                r["TenKhachHang_KhongDau"] = DatabaseHelper.XoaDau(tenKH).ToLower();
            }

            BindingSource bs = new BindingSource();
            bs.DataSource = _dtKhachHang;
            dgvKhachHang.DataSource = bs;

            // Ẩn cột không cần thiết
            if (dgvKhachHang.Columns.Contains("TrangThai")) dgvKhachHang.Columns["TrangThai"].Visible = false;
            if (dgvKhachHang.Columns.Contains("TenKhachHang_KhongDau")) dgvKhachHang.Columns["TenKhachHang_KhongDau"].Visible = false;
        }

        // --- 2. BINDING DỮ LIỆU & LỊCH SỬ MUA ---
        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
            txtMaKH.Text = row.Cells["Ma_Khach_Hang"].Value?.ToString();
            txtTenKH.Text = row.Cells["Ten_Khach_Hang"].Value?.ToString();
            txtSDT.Text = row.Cells["So_Dien_Thoai"].Value?.ToString();
            txtEmail.Text = row.Cells["Email"].Value?.ToString();
            txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();

            // Load Lịch sử mua hàng
            try
            {
                SqlParameter[] pars = { new SqlParameter("@Ma_Khach_Hang", txtMaKH.Text) };
                // Gọi SP lấy lịch sử
                DataTable dtLichSu = DatabaseHelper.GetDataTable("SP_LayLichSuMuaHang", pars);
                dgvLichSuMua.DataSource = dtLichSu;
            }
            catch { }

            // Khóa nút thêm, mở nút sửa/xóa
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        // --- 3. THÊM ---
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                SqlParameter[] pars = {
                    new SqlParameter("@Ma_Khach_Hang", txtMaKH.Text),
                    new SqlParameter("@Ten_Khach_Hang", txtTenKH.Text),
                    new SqlParameter("@So_Dien_Thoai", txtSDT.Text),
                    new SqlParameter("@DiaChi", txtDiaChi.Text),
                    new SqlParameter("@Email", txtEmail.Text)
                };

                DatabaseHelper.ExecuteNonQuery("SP_ThemKhachHang", pars);
                MessageBox.Show("Thêm khách hàng thành công!");
                LoadData();
                ResetForm();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // --- 4. SỬA ---
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] pars = {
                    new SqlParameter("@Ma_Khach_Hang", txtMaKH.Text),
                    new SqlParameter("@Ten_Khach_Hang", txtTenKH.Text),
                    new SqlParameter("@So_Dien_Thoai", txtSDT.Text),
                    new SqlParameter("@DiaChi", txtDiaChi.Text),
                    new SqlParameter("@Email", txtEmail.Text)
                };

                DatabaseHelper.ExecuteNonQuery("SP_SuaKhachHang", pars);
                MessageBox.Show("Cập nhật thành công!");
                LoadData();
                ResetForm();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // --- 5. XÓA ---
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    SqlParameter[] pars = { new SqlParameter("@Ma_Khach_Hang", txtMaKH.Text) };
                    DatabaseHelper.ExecuteNonQuery("SP_XoaKhachHang", pars);

                    MessageBox.Show("Đã xóa khách hàng!");
                    LoadData();
                    ResetForm();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        // --- 6. TÌM KIẾM ---
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = DatabaseHelper.XoaDau(txtTimKiem.Text.Trim()).ToLower();
            string filter = string.Format("Ten_Khach_Hang LIKE '%{0}%' OR Ma_Khach_Hang LIKE '%{0}%' OR TenKhachHang_KhongDau LIKE '%{1}%'",
                                          txtTimKiem.Text, tuKhoa);

            if (dgvKhachHang.DataSource is BindingSource bs)
            {
                bs.Filter = filter;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            // Tự động sinh mã KH và KHÓA ô nhập
            txtMaKH.Text = DatabaseHelper.TaoMaTuDong("KH", "KHACHHANG", "Ma_Khach_Hang");
            txtMaKH.ReadOnly = true;

            txtTenKH.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();

            // Xóa bảng lịch sử
            dgvLichSuMua.DataSource = null;

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text)) { MessageBox.Show("Chưa nhập Mã khách hàng!"); return false; }
            if (string.IsNullOrWhiteSpace(txtTenKH.Text)) { MessageBox.Show("Chưa nhập Tên khách hàng!"); return false; }
            return true;
        }
    }
}