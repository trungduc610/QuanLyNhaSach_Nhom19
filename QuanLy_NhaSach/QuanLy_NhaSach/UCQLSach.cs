using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLy_NhaSach
{
    public partial class UCQLSach : UserControl
    {
        string connectionString = @"Data Source=DESKTOP-DF0P4U3\SQLEXPRESS;Initial Catalog=NhaSach;User ID=sa;Password=123;Encrypt=True;TrustServerCertificate=True";
        public UCQLSach()
        {
            InitializeComponent();
        }

        private void UCQLSach_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            LoadComboBoxes();
            LamMoiForm();

            dgvSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void txt_NXB_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoadDataGridView()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SP_LayDanhSachSach", conn);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvSach.DataSource = dt;

                    dgvSach.Columns["MaSach"].HeaderText = "Mã Sách";
                    dgvSach.Columns["TenSach"].HeaderText = "Tên Sách";
                    dgvSach.Columns["Ten_TheLoai"].HeaderText = "Thể Loại";
                    dgvSach.Columns["Ten_Nha_Cung_Cap"].HeaderText = "Nhà Cung Cấp";
                    dgvSach.Columns["TacGia"].HeaderText = "Tác Giả";
                    dgvSach.Columns["Nha_Xuat_Ban"].HeaderText = "Nhà Xuất Bản";
                    dgvSach.Columns["SoLuong"].HeaderText = "Số Lượng";
                    dgvSach.Columns["GiaNhap"].HeaderText = "Giá Nhập";
                    dgvSach.Columns["GiaBan"].HeaderText = "Giá Bán";

                    // Ẩn các cột ID (chỉ dùng để xử lý)
                    dgvSach.Columns["ID_TheLoai"].Visible = false;
                    dgvSach.Columns["Ma_Nha_Cung_Cap"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sách: " + ex.Message);
            }
        }

        private void LoadComboBoxes()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlDataAdapter adapterTL = new SqlDataAdapter("SP_LayDanhSachTheLoai", conn);
                    DataTable dtTL = new DataTable();
                    adapterTL.Fill(dtTL);
                    cboTheLoai.DataSource = dtTL;
                    cboTheLoai.DisplayMember = "Ten_TheLoai";
                    cboTheLoai.ValueMember = "ID_TheLoai";

                    SqlDataAdapter adapterNCC = new SqlDataAdapter("SP_LayDanhSachNhaCungCap", conn);
                    DataTable dtNCC = new DataTable();
                    adapterNCC.Fill(dtNCC);
                    cboNhaCungCap.DataSource = dtNCC;
                    cboNhaCungCap.DisplayMember = "Ten_Nha_Cung_Cap";
                    cboNhaCungCap.ValueMember = "Ma_Nha_Cung_Cap";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải ComboBox: " + ex.Message);
            }
        }

        private void LamMoiForm()
        {
            txtMaSach.Clear();
            txtTenSach.Clear();
            txtTacGia.Clear();
            txtNhaXuatBan.Clear();
            txtGiaNhap.Clear();
            txtGiaBan.Clear();
            txtSoLuong.Text = "0";
            cboTheLoai.SelectedIndex = -1;
            cboNhaCungCap.SelectedIndex = -1;
            dgvSach.ClearSelection();

            txtMaSach.ReadOnly = false;
            txtSoLuong.ReadOnly = false;

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvSach.Rows[e.RowIndex];

            txtMaSach.Text = row.Cells["MaSach"].Value.ToString();
            txtTenSach.Text = row.Cells["TenSach"].Value.ToString();
            txtTacGia.Text = row.Cells["TacGia"].Value.ToString();
            txtNhaXuatBan.Text = row.Cells["Nha_Xuat_Ban"].Value.ToString();
            txtGiaNhap.Text = row.Cells["GiaNhap"].Value.ToString();
            txtGiaBan.Text = row.Cells["GiaBan"].Value.ToString();
            txtSoLuong.Text = row.Cells["SoLuong"].Value.ToString();

            cboTheLoai.SelectedValue = row.Cells["ID_TheLoai"].Value;
            cboNhaCungCap.SelectedValue = row.Cells["Ma_Nha_Cung_Cap"].Value;

            txtMaSach.ReadOnly = true;
            txtSoLuong.ReadOnly = true;

            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            LamMoiForm();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSach.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã Sách.");
                txtMaSach.Focus();
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ThemSach", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaSach", txtMaSach.Text);
                        cmd.Parameters.AddWithValue("@TenSach", txtTenSach.Text);
                        cmd.Parameters.AddWithValue("@TacGia", txtTacGia.Text);
                        cmd.Parameters.AddWithValue("@Nha_Xuat_Ban", txtNhaXuatBan.Text);
                        cmd.Parameters.AddWithValue("@GiaNhap", Convert.ToDecimal(txtGiaNhap.Text));
                        cmd.Parameters.AddWithValue("@GiaBan", Convert.ToDecimal(txtGiaBan.Text));
                        cmd.Parameters.AddWithValue("@SoLuong", Convert.ToInt32(txtSoLuong.Text));
                        cmd.Parameters.AddWithValue("@ID_TheLoai", cboTheLoai.SelectedValue);
                        cmd.Parameters.AddWithValue("@Ma_Nha_Cung_Cap", cboNhaCungCap.SelectedValue);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Thêm sách mới thành công!");

                        LoadDataGridView();
                        LamMoiForm();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_SuaSach", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaSach", txtMaSach.Text);
                        cmd.Parameters.AddWithValue("@TenSach", txtTenSach.Text);
                        cmd.Parameters.AddWithValue("@TacGia", txtTacGia.Text);
                        cmd.Parameters.AddWithValue("@Nha_Xuat_Ban", txtNhaXuatBan.Text);
                        cmd.Parameters.AddWithValue("@GiaNhap", Convert.ToDecimal(txtGiaNhap.Text));
                        cmd.Parameters.AddWithValue("@GiaBan", Convert.ToDecimal(txtGiaBan.Text));
                        cmd.Parameters.AddWithValue("@ID_TheLoai", cboTheLoai.SelectedValue);
                        cmd.Parameters.AddWithValue("@Ma_Nha_Cung_Cap", cboNhaCungCap.SelectedValue);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cập nhật sách thành công!");

                        LoadDataGridView();
                        LamMoiForm();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật sách: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa cuốn sách này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_XoaSach", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaSach", txtMaSach.Text);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Xóa sách thành công!");

                        LoadDataGridView();
                        LamMoiForm();
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    MessageBox.Show("Không thể xóa sách này vì đã có trong hóa đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi CSDL: " + ex.Message);
                }
            }
        }

        private void btn_Timkiem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SP_TimKiemSach", conn);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("@TuKhoa", txtTimKiem.Text);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvSach.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }
    }
}
