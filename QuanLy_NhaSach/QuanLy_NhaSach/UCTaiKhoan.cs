using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLy_NhaSach
{
    public partial class UCTaiKhoan : UserControl
    {
        string connectionString = @"Data Source=DESKTOP-DF0P4U3\SQLEXPRESS;Initial Catalog=NhaSach;User ID=sa;Password=123;Encrypt=True;TrustServerCertificate=True";
        private string _tenDangNhap;
        private string _quyen;

        public UCTaiKhoan(string tenDangNhap, string quyen)
        {
            InitializeComponent();
            _tenDangNhap = tenDangNhap;
            _quyen = quyen;
        }

        private void txbTenDN_TextChanged(object sender, EventArgs e)
        {

        }

        private void UCTaiKhoan_Load(object sender, EventArgs e)
        {
            txbTenDN.Text = _tenDangNhap;
            lbChucVu.Text = _quyen;
        }

        private void btn_Xacnhan_Click(object sender, EventArgs e)
        {
            string matKhauCu = txt_Matkhau.Text;      // Tên control "Mật khẩu:"
            string matKhauMoi = txt_Matkhaumoi.Text;  // Tên control "Mật khẩu mới:"
            string xacNhanMoi = txt_Xacnhanmk.Text;     // Tên control "Nhập lại:"

            // --- Kiểm tra giao diện ---
            if (string.IsNullOrEmpty(matKhauCu) || string.IsNullOrEmpty(matKhauMoi) || string.IsNullOrEmpty(xacNhanMoi))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin mật khẩu.");
                return;
            }

            if (matKhauMoi != xacNhanMoi)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận không khớp.");
                return;
            }

            // --- Gọi Stored Procedure ---
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_DoiMatKhau", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // _tenDangNhap lấy từ biến đã lưu, không lấy từ textbox
                        cmd.Parameters.AddWithValue("@TenDangNhap", _tenDangNhap);
                        cmd.Parameters.AddWithValue("@MatKhauCu", matKhauCu);
                        cmd.Parameters.AddWithValue("@MatKhauMoi", matKhauMoi);

                        conn.Open();
                        int ketQua = (int)cmd.ExecuteScalar();

                        if (ketQua == 1)
                        {
                            MessageBox.Show("Đổi mật khẩu thành công!");
                            txt_Matkhau.Clear();
                            txt_Matkhaumoi.Clear();
                            txt_Xacnhanmk.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu cũ không chính xác.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi CSDL: " + ex.Message);
            }
        }

        private void txt_Xacnhanmk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                btn_Xacnhan.PerformClick();
            }
        }
    }
}
