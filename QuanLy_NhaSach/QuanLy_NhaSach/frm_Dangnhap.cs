using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLy_NhaSach
{
    public partial class frm_DangNhap : Form
    {
        public frm_DangNhap()
        {
            InitializeComponent();
        }

        // --- XỬ LÝ GIAO DIỆN (Placeholder) ---
        private void txtTenDN_Click(object sender, EventArgs e)
        {
            if (txtTenDN.Text == "Tên đăng nhập")
            {
                txtTenDN.Text = "";
                txtTenDN.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtMatKhau_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == "Mật khẩu")
            {
                txtMatKhau.Text = "";
                txtMatKhau.ForeColor = System.Drawing.Color.Black;
                txtMatKhau.UseSystemPasswordChar = true;
            }
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // --- XỬ LÝ LOGIC ĐĂNG NHẬP ---
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDN = txtTenDN.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            // 1. Kiểm tra rỗng
            if (string.IsNullOrEmpty(tenDN) || tenDN == "Tên đăng nhập" ||
                string.IsNullOrEmpty(matKhau) || matKhau == "Mật khẩu")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Gọi DatabaseHelper (Code ngắn gọn, sạch sẽ)
                SqlParameter[] pars = {
                    new SqlParameter("@TenDangNhap", tenDN),
                    new SqlParameter("@MatKhau", matKhau) // Sau này sẽ thêm hàm HashPassword(matKhau) vào đây
                };

                DataTable dt = DatabaseHelper.GetDataTable("SP_DangNhap", pars);

                if (dt.Rows.Count > 0)
                {
                    // 3. Đăng nhập thành công -> Lấy thông tin
                    string tenNV = dt.Rows[0]["Ten_Nhan_Vien"].ToString();
                    string quyen = dt.Rows[0]["Quyen"].ToString();
                    string maNV = dt.Rows[0]["Ma_Nhan_Vien"].ToString();

                    MessageBox.Show("Đăng nhập thành công! Xin chào " + tenNV, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 4. Mở Form chính và truyền dữ liệu
                    frm_Trangchu frmMain = new frm_Trangchu(tenDN, tenNV, quyen, maNV);
                    this.Hide();
                    frmMain.ShowDialog();

                    // Khi Form chính đóng thì hiện lại Form đăng nhập (để đăng nhập người khác)
                    this.Show();
                    txtMatKhau.Text = "";
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTenDN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                txtMatKhau.Focus();
            }
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                btnDangNhap.PerformClick();
            }
        }
    }
}