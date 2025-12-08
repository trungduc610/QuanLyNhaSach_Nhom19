using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLy_NhaSach
{
    public partial class frm_Themtaikhoan : Form
    {
        private string _maNV;
        private string _tenNV;

        public frm_Themtaikhoan(string maNV, string tenNV)
        {
            InitializeComponent();
            _maNV = maNV;
            _tenNV = tenNV;

            lblTenNV.Text = "Cho nhân viên: " + _tenNV;
            cboQuyen.SelectedIndex = 0; // Mặc định là NhanVien
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDN.Text) || string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!"); return;
            }

            try
            {
                SqlParameter[] pars = {
                    new SqlParameter("@TenDangNhap", txtTenDN.Text.Trim()),
                    new SqlParameter("@MatKhau", txtMatKhau.Text.Trim()),
                    new SqlParameter("@Ma_Nhan_Vien", _maNV),
                    new SqlParameter("@Quyen", cboQuyen.Text)
                };

                // Gọi SP_TaoTaiKhoan (đã có trong file SQL số 2)
                DatabaseHelper.ExecuteNonQuery("SP_TaoTaiKhoan", pars);

                MessageBox.Show("Cấp tài khoản thành công!", "Thông báo");
                this.DialogResult = DialogResult.OK; // Báo về cho form cha biết là xong rồi
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}