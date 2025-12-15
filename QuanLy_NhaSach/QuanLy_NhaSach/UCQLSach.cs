using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QuanLy_NhaSach
{
    public partial class UCQLSach : UserControl
    {
        private DataTable _dtSach;
        private string _duongDanAnh = "";

        public UCQLSach()
        {
            InitializeComponent();
            this.VisibleChanged += new EventHandler(UCQLSach_VisibleChanged);
        }

        private void UCQLSach_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadComboBoxInput();
            ResetForm();
        }

        private void UCQLSach_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            _dtSach = DatabaseHelper.GetDataTable("SP_LayDanhSachSach");

            if (!_dtSach.Columns.Contains("TenSach_KhongDau"))
            {
                _dtSach.Columns.Add("TenSach_KhongDau");
            }

            foreach (DataRow r in _dtSach.Rows)
            {
                string tenSach = r["TenSach"] != DBNull.Value ? r["TenSach"].ToString() : "";
                r["TenSach_KhongDau"] = DatabaseHelper.XoaDau(tenSach).ToLower();
            }

            BindingSource bs = new BindingSource();
            bs.DataSource = _dtSach;
            dgvSach.DataSource = bs;

            if (dgvSach.Columns.Contains("ID_TheLoai")) dgvSach.Columns["ID_TheLoai"].Visible = false;
            if (dgvSach.Columns.Contains("HinhAnh")) dgvSach.Columns["HinhAnh"].Visible = false;
            if (dgvSach.Columns.Contains("TenSach_KhongDau")) dgvSach.Columns["TenSach_KhongDau"].Visible = false;
            if (dgvSach.Columns.Contains("TrangThai")) dgvSach.Columns["TrangThai"].Visible = false;
        }

        // Tách thành LoadComboBoxInput cho phần nhập liệu và phần Lọc
        private void LoadComboBoxInput()
        {
            // 1. Load cho Form Nhập (Input)
            cboTheLoai.DataSource = DatabaseHelper.GetDataTable("SELECT * FROM THELOAI WHERE TrangThai = 1");
            cboTheLoai.DisplayMember = "Ten_TheLoai";
            cboTheLoai.ValueMember = "ID_TheLoai";

            cboNXB.DataSource = DatabaseHelper.GetDataTable("SELECT * FROM NHACUNGCAP WHERE TrangThai = 1");
            cboNXB.DisplayMember = "Ten_Nha_Cung_Cap";
            cboNXB.ValueMember = "Ten_Nha_Cung_Cap";

            // 2. Load cho Form Lọc (Filter) - Thêm mục "Tất cả"
            DataTable dtTLFilter = DatabaseHelper.GetDataTable("SELECT * FROM THELOAI WHERE TrangThai = 1");
            DataRow drTL = dtTLFilter.NewRow();
            drTL["ID_TheLoai"] = -1;
            drTL["Ten_TheLoai"] = "--- Tất cả Thể loại ---";
            dtTLFilter.Rows.InsertAt(drTL, 0);

            cboLocTheLoai.DataSource = dtTLFilter;
            cboLocTheLoai.DisplayMember = "Ten_TheLoai";
            cboLocTheLoai.ValueMember = "ID_TheLoai";
            cboLocTheLoai.SelectedIndexChanged += Filter_Changed;

            DataTable dtNXBFilter = DatabaseHelper.GetDataTable("SELECT * FROM NHACUNGCAP WHERE TrangThai = 1");
            DataRow drNXB = dtNXBFilter.NewRow();
            drNXB["Ten_Nha_Cung_Cap"] = "--- Tất cả NXB ---";
            dtNXBFilter.Rows.InsertAt(drNXB, 0);

            cboLocNXB.DataSource = dtNXBFilter;
            cboLocNXB.DisplayMember = "Ten_Nha_Cung_Cap";
            cboLocNXB.ValueMember = "Ten_Nha_Cung_Cap";
            cboLocNXB.SelectedIndexChanged += Filter_Changed;
        }

        // Hàm xử lý lọc chung
        private void Filter_Changed(object sender, EventArgs e)
        {
            if (dgvSach.DataSource is BindingSource bs)
            {
                string filter = "1=1";

                if (!string.IsNullOrEmpty(txtTimKiem.Text))
                {
                    string tuKhoa = DatabaseHelper.XoaDau(txtTimKiem.Text.Trim()).ToLower();
                    filter += string.Format(" AND (TenSach LIKE '%{0}%' OR MaSach LIKE '%{0}%' OR TenSach_KhongDau LIKE '%{1}%')", txtTimKiem.Text, tuKhoa);
                }

                if (cboLocTheLoai.SelectedValue != null && cboLocTheLoai.SelectedValue.ToString() != "-1")
                {
                    filter += $" AND ID_TheLoai = {cboLocTheLoai.SelectedValue}";
                }

                if (cboLocNXB.SelectedValue != null && cboLocNXB.Text != "--- Tất cả NXB ---")
                {
                    filter += $" AND Nha_Xuat_Ban = '{cboLocNXB.SelectedValue}'";
                }

                bs.Filter = filter;
            }
        }

        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvSach.Rows[e.RowIndex];

            txtMaSach.Text = row.Cells["MaSach"].Value?.ToString();
            txtTenSach.Text = row.Cells["TenSach"].Value?.ToString();
            cboTheLoai.SelectedValue = row.Cells["ID_TheLoai"].Value;
            txtTacGia.Text = row.Cells["TacGia"].Value?.ToString();
            cboNXB.SelectedValue = row.Cells["Nha_Xuat_Ban"].Value?.ToString();
            txtGiaNhap.Text = row.Cells["GiaNhap"].Value?.ToString();
            txtGiaBan.Text = row.Cells["GiaBan"].Value?.ToString();

            if (row.Cells["SoLuong"].Value != DBNull.Value)
                numSoLuong.Value = Convert.ToDecimal(row.Cells["SoLuong"].Value);

            string path = row.Cells["HinhAnh"].Value?.ToString();
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                ptbHinhAnh.Image = Image.FromFile(path);
                _duongDanAnh = path;
            }
            else
            {
                ptbHinhAnh.Image = null;
                _duongDanAnh = "";
            }

            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            try
            {
                SqlParameter[] pars = {
                    new SqlParameter("@MaSach", txtMaSach.Text),
                    new SqlParameter("@ID_TheLoai", cboTheLoai.SelectedValue),
                    new SqlParameter("@TenSach", txtTenSach.Text),
                    new SqlParameter("@TacGia", txtTacGia.Text),
                    new SqlParameter("@Nha_Xuat_Ban", cboNXB.SelectedValue != null ? cboNXB.SelectedValue.ToString() : ""),
                    new SqlParameter("@GiaNhap", decimal.Parse(txtGiaNhap.Text)),
                    new SqlParameter("@GiaBan", decimal.Parse(txtGiaBan.Text)),
                    new SqlParameter("@SoLuong", (int)numSoLuong.Value),
                    new SqlParameter("@HinhAnh", _duongDanAnh)
                };
                DatabaseHelper.ExecuteNonQuery("SP_ThemSach", pars);
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
                    new SqlParameter("@MaSach", txtMaSach.Text),
                    new SqlParameter("@ID_TheLoai", cboTheLoai.SelectedValue),
                    new SqlParameter("@TenSach", txtTenSach.Text),
                    new SqlParameter("@TacGia", txtTacGia.Text),
                    new SqlParameter("@Nha_Xuat_Ban", cboNXB.SelectedValue != null ? cboNXB.SelectedValue.ToString() : ""),
                    new SqlParameter("@GiaNhap", decimal.Parse(txtGiaNhap.Text)),
                    new SqlParameter("@GiaBan", decimal.Parse(txtGiaBan.Text)),
                    new SqlParameter("@HinhAnh", _duongDanAnh)
                };
                DatabaseHelper.ExecuteNonQuery("SP_SuaSach", pars);
                MessageBox.Show("Cập nhật thành công!");
                LoadData(); ResetForm();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa sách này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    SqlParameter[] pars = { new SqlParameter("@MaSach", txtMaSach.Text) };
                    DatabaseHelper.ExecuteNonQuery("SP_XoaSach", pars);
                    MessageBox.Show("Đã xóa sách!");
                    LoadData(); ResetForm();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            Filter_Changed(sender, e);
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Ảnh|*.jpg;*.png;*.jpeg";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ptbHinhAnh.Image = Image.FromFile(dlg.FileName);
                _duongDanAnh = dlg.FileName;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            // Tự sinh mã Sách
            txtMaSach.Text = DatabaseHelper.TaoMaTuDong("S", "SACH", "MaSach");
            txtMaSach.ReadOnly = true;

            txtTenSach.Clear();
            txtTacGia.Clear();
            cboNXB.SelectedIndex = -1;
            cboTheLoai.SelectedIndex = -1;
            txtGiaNhap.Text = "0";
            txtGiaBan.Text = "0";
            numSoLuong.Value = 0;
            ptbHinhAnh.Image = null;
            _duongDanAnh = "";

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaSach.Text)) { MessageBox.Show("Chưa nhập Mã sách!"); return false; }
            if (string.IsNullOrWhiteSpace(txtTenSach.Text)) { MessageBox.Show("Chưa nhập Tên sách!"); return false; }
            if (cboNXB.SelectedIndex == -1) { MessageBox.Show("Chưa chọn Nhà xuất bản!"); return false; }
            return true;
        }
    }
}