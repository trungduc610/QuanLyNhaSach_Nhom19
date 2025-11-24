using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLy_NhaSach
{
    public partial class UCQLNhanVien : UserControl
    {
        string connectionString = @"Data Source=DESKTOP-DF0P4U3\SQLEXPRESS;Initial Catalog=NhaSach;User ID=sa;Password=123;Encrypt=True;TrustServerCertificate=True";
        private string _maNhanVienDangNhap;
        public UCQLNhanVien(string maNhanVienDangNhap)
        {
            InitializeComponent();
            _maNhanVienDangNhap = maNhanVienDangNhap;
        }

        private void UCQLNhanVien_Load(object sender, EventArgs e)
        {
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";

            LoadDanhSachNhanVien();

            comboBox1.Items.Add("Nam");
            comboBox1.Items.Add("Nữ");

            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            LamMoiForm();
        }

        private void LoadDanhSachNhanVien()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SP_LayDanhSachNhanVien", conn);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvNhanVien.DataSource = dt;

                    dgvNhanVien.Columns["Ma_Nhan_Vien"].HeaderText = "Mã NV";
                    dgvNhanVien.Columns["Ten_Nhan_Vien"].HeaderText = "Tên Nhân Viên";
                    dgvNhanVien.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
                    dgvNhanVien.Columns["GioiTinh"].HeaderText = "Giới Tính";
                    dgvNhanVien.Columns["So_Dien_Thoai"].HeaderText = "Số Điện Thoại";
                    dgvNhanVien.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                    dgvNhanVien.Columns["TinhTrangTaiKhoan"].HeaderText = "Tài Khoản";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nhân viên: " + ex.Message);
            }
        }

        private void LamMoiForm()
        {
            txtMaNV.ReadOnly = false;
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtDiaChi.Clear();
            txtSoDienThoai.Clear();
            comboBox1.SelectedIndex = -1;
            dtpNgaySinh.Value = DateTime.Now;
            dgvNhanVien.ClearSelection();

            btn_Them.Enabled = true;
            btn_Xoa.Enabled = false;
            btn_Sua.Enabled = false;
            btnThemTaiKhoan.Enabled = false;
            btnThemTaiKhoan.Text = "Thêm tài khoản";
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Bỏ qua nếu click vào tiêu đề

            // 1. Lấy dữ liệu từ dòng được chọn
            DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

            // 2. Gán lên các control trong GroupBox
            txtMaNV.Text = row.Cells["Ma_Nhan_Vien"].Value.ToString();
            txtTenNV.Text = row.Cells["Ten_Nhan_Vien"].Value.ToString();
            txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
            txtSoDienThoai.Text = row.Cells["So_Dien_Thoai"].Value.ToString();
            dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
            comboBox1.SelectedItem = row.Cells["GioiTinh"].Value.ToString();

            // 3. Xử lý trạng thái nút "Thêm tài khoản"
            string tinhTrangTK = row.Cells["TinhTrangTaiKhoan"].Value.ToString();
            if (tinhTrangTK == "Đã có")
            {
                btnThemTaiKhoan.Enabled = true;
                btnThemTaiKhoan.Text = "Xóa tài khoản";
            }
            else
            {
                btnThemTaiKhoan.Enabled = true;
                btnThemTaiKhoan.Text = "Thêm tài khoản";
            }

            txtMaNV.ReadOnly = true;
            btn_Them.Enabled = false;
            btn_Sua.Enabled = true;
            btn_Xoa.Enabled = true;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã Nhân Viên.");
                txtMaNV.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ThemNhanVien", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Ma_Nhan_Vien", txtMaNV.Text);
                        cmd.Parameters.AddWithValue("@Ten_Nhan_Vien", txtTenNV.Text);
                        cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                        cmd.Parameters.AddWithValue("@GioiTinh", comboBox1.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@So_Dien_Thoai", txtSoDienThoai.Text);
                        cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Thêm nhân viên thành công!");

                        LoadDanhSachNhanVien();
                        LamMoiForm();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không xác định: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_SuaNhanVien", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Ma_Nhan_Vien", txtMaNV.Text);
                        cmd.Parameters.AddWithValue("@Ten_Nhan_Vien", txtTenNV.Text);
                        cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                        cmd.Parameters.AddWithValue("@GioiTinh", comboBox1.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@So_Dien_Thoai", txtSoDienThoai.Text);
                        cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cập nhật thông tin thành công!");

                        LoadDanhSachNhanVien();
                        LamMoiForm();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa nhân viên: " + ex.Message);
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == _maNhanVienDangNhap)
            {
                MessageBox.Show("Bạn không thể xóa hồ sơ của chính mình khi đang đăng nhập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return; 
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa nhân viên này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_XoaNhanVien", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Ma_Nhan_Vien", txtMaNV.Text);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadDanhSachNhanVien();
                        LamMoiForm();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message);
            }
        }

        private void btn_Lammoi_Click(object sender, EventArgs e)
        {
            LamMoiForm();
        }

        private void btnThemTaiKhoan_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;
            string tenNV = txtTenNV.Text;

            if (string.IsNullOrEmpty(maNV))
            {
                MessageBox.Show("Vui lòng chọn một nhân viên từ danh sách.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (btnThemTaiKhoan.Text == "Thêm tài khoản")
            {
                frm_Themtaikhoan popupForm = new frm_Themtaikhoan(maNV, tenNV);
                popupForm.ShowDialog();
            }
            else
            {
                if (maNV == _maNhanVienDangNhap)
                {
                    MessageBox.Show("Bạn không thể xóa tài khoản mình đang sử dụng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (MessageBox.Show($"Bạn có chắc muốn XÓA tài khoản của nhân viên {tenNV} không?",
                                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_XoaTaiKhoanTheoMaNV", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Ma_Nhan_Vien", maNV);

                            conn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Xóa tài khoản thành công!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa tài khoản: " + ex.Message);
                }
            }

            LoadDanhSachNhanVien();
            LamMoiForm();
        }

        private void pnlChucNang_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
