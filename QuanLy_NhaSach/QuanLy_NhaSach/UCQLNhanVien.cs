using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLy_NhaSach
{
    public partial class UCQLNhanVien : UserControl
    {
        private string _maNhanVienDangNhap;

        private const string ADMIN_BOSS = "NV001";

        public UCQLNhanVien(string maNhanVienDangNhap)
        {
            InitializeComponent();
            _maNhanVienDangNhap = maNhanVienDangNhap;
            this.Load += new EventHandler(UCQLNhanVien_Load);

            // Gán sự kiện cho nút Cấp/Xóa tài khoản
            this.btnThemTaiKhoan.Click += new EventHandler(btnThemTaiKhoan_Click);
        }

        private void UCQLNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
            ResetForm();
        }

        private void LoadData()
        {
            // Gọi SP_LayDanhSachNhanVien (đã có thêm cột Quyen)
            DataTable dt = DatabaseHelper.GetDataTable("SP_LayDanhSachNhanVien");
            dgvNhanVien.DataSource = dt;

            // Ẩn cột không cần thiết
            if (dgvNhanVien.Columns.Contains("TrangThai"))
                dgvNhanVien.Columns["TrangThai"].Visible = false;

            if (dgvNhanVien.Columns.Contains("Quyen"))
            {
                dgvNhanVien.Columns["Quyen"].HeaderText = "Quyền Truy Cập";
                dgvNhanVien.Columns["Quyen"].Width = 60;
                dgvNhanVien.Columns["Quyen"].DisplayIndex = 7;
            }

            // Cấu hình cột Tình trạng TK
            if (dgvNhanVien.Columns.Contains("TinhTrangTaiKhoan"))
            {
                dgvNhanVien.Columns["TinhTrangTaiKhoan"].HeaderText = "Tình Trạng TK";
                dgvNhanVien.Columns["TinhTrangTaiKhoan"].Width = 60;
            }
        }

        // --- XỬ LÝ CLICK: KIỂM TRA QUYỀN VÀ TRẠNG THÁI ---
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
            string maNV_DangChon = row.Cells["Ma_Nhan_Vien"].Value.ToString();
            string tinhTrangTK = row.Cells["TinhTrangTaiKhoan"].Value.ToString();

            // 1. Đổ dữ liệu vào ô nhập
            txtMaNV.Text = maNV_DangChon;
            txtTenNV.Text = row.Cells["Ten_Nhan_Vien"].Value.ToString();
            if (row.Cells["NgaySinh"].Value != DBNull.Value)
                dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
            cboGioiTinh.Text = row.Cells["GioiTinh"].Value.ToString();
            txtSDT.Text = row.Cells["So_Dien_Thoai"].Value.ToString();
            txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();

            // Khóa mã
            txtMaNV.ReadOnly = true;
            btnThem.Enabled = false;
            btnSua.Enabled = true;

            // --- LOGIC BẢO MẬT NÚT XÓA NHÂN VIÊN ---
            // 1. Không được xóa Sếp (NV001)
            // 2. Không được xóa Chính mình
            if (maNV_DangChon == ADMIN_BOSS || maNV_DangChon == _maNhanVienDangNhap)
            {
                btnXoa.Enabled = false; // Vô hiệu hóa nút Xóa
                btnXoa.BackColor = Color.Gray;
            }
            else
            {
                btnXoa.Enabled = true;
                btnXoa.BackColor = Color.FromArgb(231, 76, 60); // Màu đỏ
            }

            // --- LOGIC NÚT TÀI KHOẢN (CẤP / XÓA) ---
            if (tinhTrangTK == "Đã có")
            {
                // Nếu đã có -> Chuyển thành nút XÓA TÀI KHOẢN
                btnThemTaiKhoan.Text = "Xóa Tài Khoản ❌";
                btnThemTaiKhoan.BackColor = Color.OrangeRed;

                // Bảo vệ: Không được xóa tài khoản Sếp hoặc Chính mình
                if (maNV_DangChon == ADMIN_BOSS || maNV_DangChon == _maNhanVienDangNhap)
                {
                    btnThemTaiKhoan.Enabled = false;
                    btnThemTaiKhoan.BackColor = Color.Gray;
                }
                else
                {
                    btnThemTaiKhoan.Enabled = true;
                }
            }
            else
            {
                // Nếu chưa có -> Chuyển thành nút CẤP TÀI KHOẢN
                btnThemTaiKhoan.Text = "Cấp Tài Khoản 🔑";
                btnThemTaiKhoan.BackColor = Color.FromArgb(255, 128, 0); // Màu Cam
                btnThemTaiKhoan.Enabled = true;
            }
        }

        // --- CHỨC NĂNG: CẤP HOẶC XÓA TÀI KHOẢN ---
        private void btnThemTaiKhoan_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;

            // 1. Trường hợp CẤP MỚI
            if (btnThemTaiKhoan.Text.Contains("Cấp"))
            {
                frm_Themtaikhoan frm = new frm_Themtaikhoan(maNV, txtTenNV.Text);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                    // Reset lại giao diện ngay để nút đổi thành "Xóa"
                    MessageBox.Show("Cấp tài khoản thành công! Nhân viên có thể đăng nhập ngay.");
                }
            }
            // 2. Trường hợp XÓA (THU HỒI)
            else
            {
                // === KIỂM TRA BẢO MẬT: CHẶN XÓA ADMIN GỐC ===
                if (maNV == ADMIN_BOSS)
                {
                    MessageBox.Show("CẤM: Đây là tài khoản Quản Trị Viên Gốc (Boss). Không thể thu hồi quyền truy cập!", "Lỗi Bảo Mật", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (MessageBox.Show($"Bạn có chắc muốn THU HỒI quyền truy cập (Xóa tài khoản) của {txtTenNV.Text}?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        SqlParameter[] pars = { new SqlParameter("@Ma_Nhan_Vien", maNV) };
                        DatabaseHelper.ExecuteNonQuery("SP_XoaTaiKhoanTheoMaNV", pars);

                        MessageBox.Show("Đã xóa tài khoản thành công!");
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }
        }

        // --- CHỨC NĂNG: XÓA NHÂN VIÊN (Đuổi việc) ---
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;

            // KIỂM TRA BẢO MẬT
            if (maNV == ADMIN_BOSS)
            {
                MessageBox.Show("CẤM: Hồ sơ Quản Trị Viên Gốc không thể bị xóa khỏi hệ thống!", "Cấm", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (maNV == _maNhanVienDangNhap)
            {
                MessageBox.Show("Bạn không thể tự xóa hồ sơ của chính mình khi đang làm việc!", "Cấm", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // SỬA LẠI DÒNG NÀY: Dùng MessageBoxIcon.Error hoặc MessageBoxIcon.Stop
            if (MessageBox.Show($"Bạn có chắc muốn xóa hồ sơ nhân viên {txtTenNV.Text}?\n(Tài khoản đăng nhập của người này cũng sẽ bị xóa theo)",
                "Xác nhận sa thải", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                try
                {
                    SqlParameter[] pars = { new SqlParameter("@Ma_Nhan_Vien", maNV) };
                    DatabaseHelper.ExecuteNonQuery("SP_XoaNhanVien", pars);
                    MessageBox.Show("Đã xóa nhân viên!");
                    LoadData();
                    ResetForm();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        // ... (Các hàm Thêm, Sửa, ResetForm giữ nguyên logic cũ) ...
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            try
            {
                SqlParameter[] pars = {
                    new SqlParameter("@Ma_Nhan_Vien", txtMaNV.Text),
                    new SqlParameter("@Ten_Nhan_Vien", txtTenNV.Text),
                    new SqlParameter("@NgaySinh", dtpNgaySinh.Value),
                    new SqlParameter("@GioiTinh", cboGioiTinh.Text),
                    new SqlParameter("@So_Dien_Thoai", txtSDT.Text),
                    new SqlParameter("@DiaChi", txtDiaChi.Text)
                };
                DatabaseHelper.ExecuteNonQuery("SP_ThemNhanVien", pars);
                MessageBox.Show("Thêm thành công!");
                LoadData(); ResetForm();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] pars = {
                    new SqlParameter("@Ma_Nhan_Vien", txtMaNV.Text),
                    new SqlParameter("@Ten_Nhan_Vien", txtTenNV.Text),
                    new SqlParameter("@NgaySinh", dtpNgaySinh.Value),
                    new SqlParameter("@GioiTinh", cboGioiTinh.Text),
                    new SqlParameter("@So_Dien_Thoai", txtSDT.Text),
                    new SqlParameter("@DiaChi", txtDiaChi.Text)
                };
                DatabaseHelper.ExecuteNonQuery("SP_SuaNhanVien", pars);
                MessageBox.Show("Cập nhật thành công!");
                LoadData(); ResetForm();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            txtMaNV.ReadOnly = false;
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            cboGioiTinh.SelectedIndex = 0;

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            // Reset nút tài khoản về mặc định
            btnThemTaiKhoan.Enabled = false;
            btnThemTaiKhoan.Text = "Cấp Tài Khoản 🔑";
            btnThemTaiKhoan.BackColor = Color.FromArgb(255, 128, 0);
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text)) { MessageBox.Show("Chưa nhập Mã NV!"); return false; }
            if (string.IsNullOrWhiteSpace(txtTenNV.Text)) { MessageBox.Show("Chưa nhập Tên NV!"); return false; }
            return true;
        }
    }
}