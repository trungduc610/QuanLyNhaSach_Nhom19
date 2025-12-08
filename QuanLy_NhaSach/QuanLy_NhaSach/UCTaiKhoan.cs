using System;
using System.Data.SqlClient;
using System.Drawing; // Cần thiết để dùng Size
using System.Windows.Forms;

namespace QuanLy_NhaSach
{
    public partial class UCTaiKhoan : UserControl
    {
        private string _tenDangNhap;
        private string _quyen;

        // Nhận thông tin từ Main Form
        public UCTaiKhoan(string tenDN, string quyen)
        {
            InitializeComponent();
            _tenDangNhap = tenDN;
            _quyen = quyen;
        }

        private void UCTaiKhoan_Load(object sender, EventArgs e)
        {
            // Hiển thị thông tin người dùng
            lblTenDN.Text = _tenDangNhap;
            lblQuyen.Text = _quyen;

            // Đảm bảo mật khẩu không bị nhìn thấy
            txtMKCu.UseSystemPasswordChar = true;
            txtMKMoi.UseSystemPasswordChar = true;
            txtNhapLaiMK.UseSystemPasswordChar = true;

            // === LOGIC MỚI: PHÂN QUYỀN NÚT ADMIN ===
            if (_quyen == "Admin")
            {
                btnAdminTools.Visible = true;
            }
            // ======================================
        }

        // --- HÀM XỬ LÝ ĐỔI MẬT KHẨU ---
        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            string matKhauCu = txtMKCu.Text.Trim();
            string matKhauMoi = txtMKMoi.Text.Trim();

            try
            {
                SqlParameter[] pars = {
                    new SqlParameter("@TenDangNhap", _tenDangNhap),
                    new SqlParameter("@MatKhauCu", matKhauCu),
                    new SqlParameter("@MatKhauMoi", matKhauMoi)
                };

                // Gọi SP_DoiMatKhau
                DatabaseHelper.ExecuteNonQuery("SP_DoiMatKhau", pars);

                MessageBox.Show("Đổi mật khẩu thành công! Vui lòng sử dụng mật khẩu mới trong lần đăng nhập tới.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xóa các ô mật khẩu
                txtMKCu.Clear();
                txtMKMoi.Clear();
                txtNhapLaiMK.Clear();
            }
            catch (SqlException ex)
            {
                // Bắt lỗi từ THROW 50001 (Mật khẩu cũ không đúng)
                if (ex.Number == 50001)
                {
                    MessageBox.Show(ex.Message, "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- HÀM XỬ LÝ NÚT ADMIN TOOLS (Backup/Restore) ---
        private void btnAdminTools_Click(object sender, EventArgs e)
        {
            // Tạo một Form mới (Modal) để chứa UCAdminTools
            Form frmModal = new Form();
            UCAdminTools ucAdmin = new UCAdminTools(); // Khởi tạo UCAdminTools

            frmModal.Text = "Công cụ Quản trị Cơ sở Dữ liệu";
            frmModal.Size = new Size(900, 650);
            frmModal.StartPosition = FormStartPosition.CenterScreen;
            frmModal.MinimizeBox = false;
            frmModal.MaximizeBox = false;

            // Thêm UserControl vào Form Modal
            ucAdmin.Dock = DockStyle.Fill;
            frmModal.Controls.Add(ucAdmin);

            // Hiển thị Form dưới dạng Modal (bắt buộc người dùng xử lý form này trước)
            frmModal.ShowDialog();
        }


        // --- HÀM VALIDATE ---
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMKCu.Text) ||
                string.IsNullOrWhiteSpace(txtMKMoi.Text) ||
                string.IsNullOrWhiteSpace(txtNhapLaiMK.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ các trường mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtMKMoi.Text.Trim() != txtNhapLaiMK.Text.Trim())
            {
                MessageBox.Show("Mật khẩu mới và Nhập lại mật khẩu không khớp!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtMKCu.Text.Trim() == txtMKMoi.Text.Trim())
            {
                MessageBox.Show("Mật khẩu mới phải khác mật khẩu cũ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}