using System;
using System.Data;
using System.Data.SqlClient; // Thư viện kết nối SQL
using System.Windows.Forms;

namespace QuanLy_NhaSach
{
    public partial class UCQLKhachHang : UserControl
    {
        // Sử dụng chuỗi kết nối chuẩn như bên UCQLNhanVien
        string connectionString = @"Data Source=DESKTOP-DF0P4U3\SQLEXPRESS;Initial Catalog=NhaSach;User ID=sa;Password=123;Encrypt=True;TrustServerCertificate=True";

        public UCQLKhachHang()
        {
            InitializeComponent();
        }

        private void UCQLKhachHang_Load(object sender, EventArgs e)
        {
            LoadDanhSachKhachHang();
            LamMoiForm(); // Reset trạng thái ban đầu
        }

        // 1. Hàm tải danh sách (Sử dụng using và SqlDataAdapter chuẩn)
        private void LoadDanhSachKhachHang()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SP_LayDanhSachKhachHang", conn);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvKhachHang.DataSource = dt;

                    // Đặt tên cột tiếng Việt
                    dgvKhachHang.Columns["Ma_Khach_Hang"].HeaderText = "Mã KH";
                    dgvKhachHang.Columns["Ten_Khach_Hang"].HeaderText = "Tên Khách Hàng";
                    dgvKhachHang.Columns["So_Dien_Thoai"].HeaderText = "SĐT";
                    dgvKhachHang.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                    dgvKhachHang.Columns["Email"].HeaderText = "Email";

                    dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách khách hàng: " + ex.Message);
            }
        }

        // 2. Hàm làm mới form và reset trạng thái nút (Giống UCQLNhanVien)
        private void LamMoiForm()
        {
            txtMaKH.ReadOnly = false; // Cho phép nhập mã khi thêm mới
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
            txtTimKiem.Clear();

            dgvKhachHang.ClearSelection();

            // Logic nút bấm: Chỉ cho phép THÊM, khóa SỬA/XÓA
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        // 3. Sự kiện CellClick: Đổ dữ liệu và đổi trạng thái nút
        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];

            txtMaKH.Text = row.Cells["Ma_Khach_Hang"].Value.ToString();
            txtTenKH.Text = row.Cells["Ten_Khach_Hang"].Value.ToString();
            txtSDT.Text = row.Cells["So_Dien_Thoai"].Value.ToString();
            txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
            txtEmail.Text = row.Cells["Email"].Value.ToString();

            // Khi chọn dòng: Khóa mã, Khóa nút THÊM, Mở nút SỬA/XÓA
            txtMaKH.ReadOnly = true;
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            LamMoiForm();
            LoadDanhSachKhachHang();
        }

        // --- CHỨC NĂNG THÊM ---
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã Khách Hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKH.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ThemKhachHang", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Ma_Khach_Hang", txtMaKH.Text.Trim());
                        cmd.Parameters.AddWithValue("@Ten_Khach_Hang", txtTenKH.Text.Trim());
                        cmd.Parameters.AddWithValue("@So_Dien_Thoai", txtSDT.Text.Trim());
                        cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadDanhSachKhachHang();
                        LamMoiForm();
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601) // Lỗi trùng khóa chính
                    MessageBox.Show("Mã khách hàng này đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không xác định: " + ex.Message);
            }
        }

        // --- CHỨC NĂNG SỬA (Cải thiện theo UCQLNhanVien) ---
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKH.Text)) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_SuaKhachHang", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Ma_Khach_Hang", txtMaKH.Text.Trim());
                        cmd.Parameters.AddWithValue("@Ten_Khach_Hang", txtTenKH.Text.Trim());
                        cmd.Parameters.AddWithValue("@So_Dien_Thoai", txtSDT.Text.Trim());
                        cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadDanhSachKhachHang();
                        LamMoiForm();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- CHỨC NĂNG XÓA (Cải thiện theo UCQLNhanVien) ---
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKH.Text)) return;

            if (MessageBox.Show("Bạn có chắc muốn xóa khách hàng này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_XoaKhachHang", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Ma_Khach_Hang", txtMaKH.Text.Trim());

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadDanhSachKhachHang();
                        LamMoiForm();
                    }
                }
            }
            catch (Exception ex)
            {
                // Bắt lỗi quan hệ khóa ngoại (Nếu khách hàng đã có hóa đơn)
                MessageBox.Show("Lỗi xóa (Có thể khách hàng này đã mua hàng và có hóa đơn): " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- CHỨC NĂNG TÌM KIẾM ---
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_TimKiemKhachHang", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TuKhoa", txtTimKiem.Text.Trim());

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvKhachHang.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }
    }
}