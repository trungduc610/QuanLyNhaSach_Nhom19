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
            this.btnThemTaiKhoan.Click += new EventHandler(btnThemTaiKhoan_Click);
        }

        private void UCQLNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
            ResetForm();
        }

        private void LoadData()
        {
            DataTable dt = DatabaseHelper.GetDataTable("SP_LayDanhSachNhanVien");
            dgvNhanVien.DataSource = dt;

            if (dgvNhanVien.Columns.Contains("TrangThai"))
                dgvNhanVien.Columns["TrangThai"].Visible = false;

            if (dgvNhanVien.Columns.Contains("Quyen"))
            {
                dgvNhanVien.Columns["Quyen"].HeaderText = "Quyền Truy Cập";
                dgvNhanVien.Columns["Quyen"].Width = 60;
                dgvNhanVien.Columns["Quyen"].DisplayIndex = 7;
            }

            if (dgvNhanVien.Columns.Contains("TinhTrangTaiKhoan"))
            {
                dgvNhanVien.Columns["TinhTrangTaiKhoan"].HeaderText = "Tình Trạng TK";
                dgvNhanVien.Columns["TinhTrangTaiKhoan"].Width = 60;
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
            string maNV_DangChon = row.Cells["Ma_Nhan_Vien"].Value.ToString();
            string tinhTrangTK = row.Cells["TinhTrangTaiKhoan"].Value.ToString();

            txtMaNV.Text = maNV_DangChon;
            txtTenNV.Text = row.Cells["Ten_Nhan_Vien"].Value.ToString();
            if (row.Cells["NgaySinh"].Value != DBNull.Value)
                dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
            cboGioiTinh.Text = row.Cells["GioiTinh"].Value.ToString();
            txtSDT.Text = row.Cells["So_Dien_Thoai"].Value.ToString();
            txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();

            txtMaNV.ReadOnly = true;
            btnThem.Enabled = false;
            btnSua.Enabled = true;

            // Logic bảo mật Xóa
            if (maNV_DangChon == ADMIN_BOSS || maNV_DangChon == _maNhanVienDangNhap)
            {
                btnXoa.Enabled = false;
                btnXoa.BackColor = Color.Gray;
            }
            else
            {
                btnXoa.Enabled = true;
                btnXoa.BackColor = Color.FromArgb(231, 76, 60);
            }

            // Logic Tài khoản
            if (tinhTrangTK == "Đã có")
            {
                btnThemTaiKhoan.Text = "Xóa Tài Khoản ❌";
                btnThemTaiKhoan.BackColor = Color.OrangeRed;
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
                btnThemTaiKhoan.Text = "Cấp Tài Khoản 🔑";
                btnThemTaiKhoan.BackColor = Color.FromArgb(255, 128, 0);
                btnThemTaiKhoan.Enabled = true;
            }
        }

        // --- CẤP/XÓA TÀI KHOẢN ---
        private void btnThemTaiKhoan_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;

            if (btnThemTaiKhoan.Text.Contains("Cấp"))
            {
                frm_Themtaikhoan frm = new frm_Themtaikhoan(maNV, txtTenNV.Text);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                    MessageBox.Show("Cấp tài khoản thành công!");
                }
            }
            else
            {
                if (maNV == ADMIN_BOSS)
                {
                    MessageBox.Show("CẤM: Đây là tài khoản Boss!", "Lỗi Bảo Mật", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (MessageBox.Show($"Thu hồi quyền truy cập của {txtTenNV.Text}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        SqlParameter[] pars = { new SqlParameter("@Ma_Nhan_Vien", maNV) };
                        DatabaseHelper.ExecuteNonQuery("SP_XoaTaiKhoanTheoMaNV", pars);
                        MessageBox.Show("Đã xóa tài khoản!");
                        LoadData();
                    }
                    catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
                }
            }
        }

        // --- XÓA NHÂN VIÊN ---
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;
            if (maNV == ADMIN_BOSS || maNV == _maNhanVienDangNhap)
            {
                MessageBox.Show("Không thể xóa tài khoản này!", "Cấm", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (MessageBox.Show($"Xóa hồ sơ nhân viên {txtTenNV.Text}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
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
            // Tự động sinh mã NV: NV001, NV002...
            txtMaNV.Text = DatabaseHelper.TaoMaTuDong("NV", "NHANVIEN", "Ma_Nhan_Vien");
            txtMaNV.ReadOnly = true;

            txtTenNV.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            cboGioiTinh.SelectedIndex = 0;

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

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