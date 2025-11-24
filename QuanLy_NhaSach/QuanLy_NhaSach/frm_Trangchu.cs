using System;
using System.Windows.Forms;

namespace QuanLy_NhaSach
{
    public partial class frm_Trangchu : Form
    {
        private string _tenDangNhap;
        private string _tenNhanVien;
        private string _quyen;
        private string _maNhanVien;
        public frm_Trangchu(string tenDangNhap, string tenNhanVien, string quyen, string maNhanVien)
        {
            InitializeComponent();
            _tenDangNhap = tenDangNhap;
            _tenNhanVien = tenNhanVien;
            _quyen = quyen;
            _maNhanVien = maNhanVien;
        }

        private void AddUserControlToPanel(UserControl uc)
        {
            panelContent.Controls.Clear(); // Xóa control cũ 
            uc.Dock = DockStyle.Fill;      // Lấp đầy panel
            panelContent.Controls.Add(uc); // Thêm control mới vào
        }

        private void frm_Trangchu_Load(object sender, EventArgs e)
        {
            PhanQuyen();

            lbl_Taikhoan.Text = "Chào: " + _tenNhanVien;

            btn_Bansach.PerformClick();
        }

        private void PhanQuyen()
        {
            btn_Bansach.Enabled = true;
            btn_Nhapsach.Enabled = true;
            btn_QLsach.Enabled = true;
            btn_Taikhoan.Enabled = true;

            // Phân quyền cho Admin và Nhân viên
            if (_quyen == "Admin")
            {
                btn_QLKH.Enabled = true;
                btn_QLNV.Enabled = true;
                btn_ThongKe.Enabled = true;
            }
            else
            {
                btn_QLKH.Enabled = false;
                btn_QLNV.Enabled = false;
                btn_ThongKe.Enabled = false;
            }
        }

        private void btn_QLsach_Click(object sender, EventArgs e)
        {
            UCQLSach uc = new UCQLSach();

            AddUserControlToPanel(uc);
        }


        private void btn_Dangxuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Bansach_Click(object sender, EventArgs e)
        {
            UCBanSach uc = new UCBanSach(_tenDangNhap, _tenNhanVien);

            AddUserControlToPanel(uc);
        }

        private void btn_Nhapsach_Click(object sender, EventArgs e)
        {
            UCNhapSach uc = new UCNhapSach(_tenDangNhap, _tenNhanVien);

            AddUserControlToPanel(uc);
        }
        private void btn_QLKH_Click(object sender, EventArgs e)
        {
            // Xóa các control cũ trong panelContent
            panelContent.Controls.Clear();

            // Tạo mới UserControl Khách hàng
            UCQLKhachHang ucKH = new UCQLKhachHang();
            ucKH.Dock = DockStyle.Fill;

            // Thêm vào panel
            panelContent.Controls.Add(ucKH);
        }

        private void btn_Taikhoan_Click(object sender, EventArgs e)
        {
            UCTaiKhoan uc = new UCTaiKhoan(_tenDangNhap, _quyen);

            AddUserControlToPanel(uc);
        }

        private void btn_QLNV_Click(object sender, EventArgs e)
        {
            UCQLNhanVien uc = new UCQLNhanVien(_maNhanVien);

            AddUserControlToPanel(uc);
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();

            lbl_Taikhoan.Text = "Chào: " + _tenNhanVien;
        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            UCTKDoanhThu uc = new UCTKDoanhThu();

            AddUserControlToPanel(uc);
        }
    }
}
