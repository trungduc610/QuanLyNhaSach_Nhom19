using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLy_NhaSach
{
    public partial class frm_Trangchu : Form
    {
        // 1. KHAI BÁO BIẾN CACHE (Để lưu giữ trạng thái)
        // Thay vì biến cục bộ, ta đưa lên làm biến toàn cục của class
        private UCBanSach _ucBanSach;
        private UCNhapSach _ucNhapSach;
        private UCQLSach _ucQLSach;
        private UCTaiKhoan _ucTaiKhoan;
        private UCAdminTools ucAdminTools;
        private UCQLNhanVien _ucQLNhanVien;
        private UCQLKhachHang _ucQLKhachHang;
        private UCTKDoanhThu _ucTKDoanhThu;

        // Thông tin người dùng
        private string _tenDangNhap;
        private string _tenNhanVien;
        private string _quyen;
        private string _maNhanVien;

        public frm_Trangchu(string tenDN, string tenNV, string quyen, string maNV)
        {
            InitializeComponent();
            _tenDangNhap = tenDN;
            _tenNhanVien = tenNV;
            _quyen = quyen;
            _maNhanVien = maNV;

            this.Size = new Size(1300, 800);
            this.StartPosition = FormStartPosition.CenterScreen;

            ThietLapGiaoDien();
        }

        private void ThietLapGiaoDien()
        {
            lblChao.Text = $"Xin chào: {_tenNhanVien} ({_quyen})";

            if (_quyen == "NhanVien")
            {
                btnNhanVien.Visible = false;
                btnThongKe.Visible = false;
                btnSach.Visible = false;
            }

            // Mở mặc định
            btnBanSach.PerformClick();
        }

        // 2. HÀM HIỂN THỊ THÔNG MINH (Không Clear, chỉ BringToFront)
        private void HienThiUserControl(UserControl uc, Button btnActive)
        {
            // Reset màu nút
            btnBanSach.BackColor = Color.Transparent;
            btnNhapSach.BackColor = Color.Transparent;
            btnSach.BackColor = Color.Transparent;
            btnTaiKhoan.BackColor = Color.Transparent;
            btnNhanVien.BackColor = Color.Transparent;
            btnKhachHang.BackColor = Color.Transparent;
            btnThongKe.BackColor = Color.Transparent;

            // Highlight nút chọn
            btnActive.BackColor = Color.FromArgb(52, 152, 219);

            foreach (Control c in pnlContent.Controls)
            {
                c.Visible = false;
            }

            // Kiểm tra xem UserControl này đã được thêm vào Panel chưa?
            if (!pnlContent.Controls.Contains(uc))
            {
                uc.Dock = DockStyle.Fill;
                pnlContent.Controls.Add(uc);
            }

            uc.Visible = true;
            uc.BringToFront();
        }

        // --- CÁC SỰ KIỆN CLICK ---

        private void btnBanSach_Click(object sender, EventArgs e)
        {
            // Nếu chưa từng bấm vào -> Tạo mới
            if (_ucBanSach == null)
            {
                _ucBanSach = new UCBanSach(_maNhanVien, _tenNhanVien);
            }
            // Nếu đã có rồi -> Gọi hàm hiển thị lại cái cũ
            HienThiUserControl(_ucBanSach, btnBanSach);
        }

        private void btnNhapSach_Click(object sender, EventArgs e)
        {
            if (_ucNhapSach == null)
            {
                _ucNhapSach = new UCNhapSach(_maNhanVien, _tenNhanVien);
            }
            HienThiUserControl(_ucNhapSach, btnNhapSach);
        }

        private void btnSach_Click(object sender, EventArgs e)
        {
            if (_ucQLSach == null)
            {
                _ucQLSach = new UCQLSach();
            }
            // Riêng phần Quản lý Sách, có thể bạn muốn mỗi lần vào là dữ liệu mới nhất
            // Nếu muốn reload lại data mỗi khi bấm, hãy thêm dòng này:
            // _ucQLSach.LoadLaiDuLieu(); (Bạn tự viết hàm này bên UCQLSach nếu cần)

            HienThiUserControl(_ucQLSach, btnSach);
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            if (_ucTaiKhoan == null)
            {
                // Kiểm tra xem UCTaiKhoan của bạn Constructor nhận tham số gì?
                // Theo file cũ là: public UCTaiKhoan(string tenDangNhap, string quyen)
                _ucTaiKhoan = new UCTaiKhoan(_tenDangNhap, _quyen);
            }

            // Reset màu nút Tài khoản (nếu chưa có trong hàm chung)
            btnTaiKhoan.BackColor = Color.Transparent;

            HienThiUserControl(_ucTaiKhoan, btnTaiKhoan);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            if (_ucQLNhanVien == null)
            {
                _ucQLNhanVien = new UCQLNhanVien(_maNhanVien);
            }
            HienThiUserControl(_ucQLNhanVien, btnNhanVien);
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            if (_ucQLKhachHang == null)
            {
                _ucQLKhachHang = new UCQLKhachHang();
            }
            HienThiUserControl(_ucQLKhachHang, btnKhachHang);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            // Thống kê thì NÊN tạo mới mỗi lần bấm để cập nhật số liệu mới nhất
            // Hoặc dùng cache nhưng gọi hàm Reload
            if (_ucTKDoanhThu == null)
            {
                _ucTKDoanhThu = new UCTKDoanhThu();
            }
            else
            {
                // _ucTKDoanhThu.LoadDuLieu(); // Giả sử bạn có hàm này để refresh
            }
            HienThiUserControl(_ucTKDoanhThu, btnThongKe);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frm_Trangchu_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}