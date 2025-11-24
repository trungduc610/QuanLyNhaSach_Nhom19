using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLy_NhaSach
{
    public partial class frm_DangNhap : Form
    {
        string connectionString = @"Data Source=DESKTOP-DF0P4U3\SQLEXPRESS;Initial Catalog=NhaSach;User ID=sa;Password=123;Encrypt=True;TrustServerCertificate=True";

        public frm_DangNhap()
        {
            InitializeComponent();
        }

        private void frm_DangNhap_Load(object sender, EventArgs e)
        {

        }
        private void txt_TenDN_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Dangnhap_Click(object sender, EventArgs e)
        {

            string tenDangNhap = txt_TenDN.Text;
            string matKhau = txt_Matkhau.Text;

            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_DangNhap", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                        cmd.Parameters.AddWithValue("@MatKhau", matKhau);

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) // Đăng nhập thành công
                            {
                                // Lấy thông tin người dùng
                                string tenNhanVien = reader["Ten_Nhan_Vien"].ToString();
                                string quyen = reader["Quyen"].ToString();
                                string maNhanVien = reader["Ma_Nhan_Vien"].ToString();

                                // Ẩn form đăng nhập
                                this.Hide();

                                // Mở form Trang Chủ 
                                frm_Trangchu frmMain = new frm_Trangchu(tenDangNhap, tenNhanVien, quyen, maNhanVien);
                                frmMain.ShowDialog();

                                // Sau khi frmTrangChu đóng, hiển thị lại form Đăng nhập
                                this.Show();
                                txt_Matkhau.Clear();
                            }
                            else
                            {
                                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message);
            }
        }

        private void txt_Matkhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu phím ấn là Enter (ASCII = 13)
            if (e.KeyChar == (char)Keys.Enter)
            {
                // e.Handled = true báo cho Windows biết là "tôi đã xử lý phím này rồi, đừng kêu nữa"
                e.Handled = true;

                // Thực hiện đăng nhập
                btn_Dangnhap.PerformClick();
            }
        }

        private void txt_TenDN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txt_Matkhau.Focus();
            }
        }
    }
}
