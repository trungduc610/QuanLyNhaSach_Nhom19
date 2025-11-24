using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLy_NhaSach
{
    public partial class frm_Themtaikhoan : Form
    {
        string connectionString = @"Data Source=DESKTOP-69B7U6D\SQLDEV2022;Initial Catalog=NhaSach;Integrated Security=True;TrustServerCertificate=True";

        // Biến để lưu thông tin nhân viên được truyền sang
        private string _maNV;
        private string _tenNV;
        public frm_Themtaikhoan(string maNhanVien, string tenNhanVien)
        {
            InitializeComponent();
            _maNV = maNhanVien;
            _tenNV = tenNhanVien;
        }

        private void frm_Themtaikhoan_Load(object sender, EventArgs e)
        {
            lblTenNhanVien.Text = "Cấp tài khoản cho: " + _tenNV;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txbTenDN.Text;
            string matKhau = txt_Matkhau.Text;
            string xacNhan = txt_Xacnhanmk.Text;

            // === THAY ĐỔI: TỰ ĐỘNG GÁN QUYỀN ===
            string quyen = "NhanVien"; // Tự động gán quyền là "NhanVien"

            // Kiểm tra đầu vào
            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Tên đăng nhập và mật khẩu không được rỗng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (matKhau != xacNhan)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Gọi Stored Procedure
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_TaoTaiKhoan", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                        cmd.Parameters.AddWithValue("@MatKhau", matKhau);
                        cmd.Parameters.AddWithValue("@Ma_Nhan_Vien", _maNV);
                        cmd.Parameters.AddWithValue("@Quyen", quyen); // Gửi quyền "NhanVien" đã gán

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Tạo tài khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // Tự động đóng form pop-up
                    }
                }
            }
            catch (SqlException ex) // Bắt lỗi từ RAISERROR của SQL
            {
                MessageBox.Show(ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
