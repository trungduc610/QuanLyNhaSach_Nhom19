using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLy_NhaSach
{
    public partial class UCTKDoanhThu : UserControl
    {
        string connectionString = @"Data Source=DESKTOP-DF0P4U3\SQLEXPRESS;Initial Catalog=NhaSach;User ID=sa;Password=123;TrustServerCertificate=True";
        public UCTKDoanhThu()
        {
            InitializeComponent();
        }

        private void UCTKDoanhThu_Load(object sender, EventArgs e)
        {
            dgvBaoCao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // 1. Cài đặt ngày mặc định (Từ đầu tháng đến hiện tại)
            DateTime now = DateTime.Now;
            dtpTuNgay.Value = new DateTime(now.Year, now.Month, 1);
            dtpDenNgay.Value = now;
            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.CustomFormat = "dd/MM/yyyy";

            // 2. Cài đặt biểu đồ (Chỉ còn Chart Doanh Thu)
            CaiDatBieuDo();

            // 3. Tải dữ liệu
            LoadDuLieuThongKe();
        }

        private void CaiDatBieuDo()
        {
            chartDoanhThu.Series.Clear();
            chartDoanhThu.Titles.Clear();
            chartDoanhThu.Titles.Add("Biểu đồ Tài Chính (Thu - Chi)");

            // Tạo Series Doanh Thu (Cột Xanh)
            Series sThu = new Series("Doanh Thu");
            sThu.ChartType = SeriesChartType.Column;
            sThu.Color = Color.MediumSeaGreen;
            sThu.IsValueShownAsLabel = true; // Hiện số tiền trên cột
            chartDoanhThu.Series.Add(sThu);

            // Tạo Series Chi Phí (Cột Đỏ)
            Series sChi = new Series("Chi Phí");
            sChi.ChartType = SeriesChartType.Column;
            sChi.Color = Color.Tomato;
            sChi.IsValueShownAsLabel = true; // Hiện số tiền trên cột
            chartDoanhThu.Series.Add(sChi);

            // Định dạng trục X (Ngày tháng)
            chartDoanhThu.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM";
            chartDoanhThu.ChartAreas[0].AxisX.Interval = 1; // Hiện tất cả các ngày
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            LoadDuLieuThongKe();
        }

        private void LoadDuLieuThongKe()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_BaoCaoTaiChinh", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TuNgay", dtpTuNgay.Value);
                        cmd.Parameters.AddWithValue("@DenNgay", dtpDenNgay.Value);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // 1. Hiển thị lên DataGridView
                        dgvBaoCao.DataSource = dt;

                        // Format hiển thị tiền tệ và đổi tên cột cho đẹp
                        dgvBaoCao.Columns["Ngay"].HeaderText = "Ngày";
                        dgvBaoCao.Columns["DoanhThu"].HeaderText = "Doanh Thu";
                        dgvBaoCao.Columns["DoanhThu"].DefaultCellStyle.Format = "N0";
                        dgvBaoCao.Columns["ChiPhi"].HeaderText = "Chi Phí Nhập";
                        dgvBaoCao.Columns["ChiPhi"].DefaultCellStyle.Format = "N0";
                        dgvBaoCao.Columns["LoiNhuan"].HeaderText = "Lợi Nhuận";
                        dgvBaoCao.Columns["LoiNhuan"].DefaultCellStyle.Format = "N0";

                        // 2. Tính tổng hiển thị lên 3 Thẻ (Labels)
                        decimal tongDoanhThu = 0;
                        decimal tongChiPhi = 0;
                        decimal tongLoiNhuan = 0;

                        foreach (DataRow row in dt.Rows)
                        {
                            tongDoanhThu += Convert.ToDecimal(row["DoanhThu"]);
                            tongChiPhi += Convert.ToDecimal(row["ChiPhi"]);
                        }
                        tongLoiNhuan = tongDoanhThu - tongChiPhi;

                        lblTongDoanhThu.Text = string.Format("{0:N0} VNĐ", tongDoanhThu);
                        lblTongChiPhi.Text = string.Format("{0:N0} VNĐ", tongChiPhi);
                        lblLoiNhuan.Text = string.Format("{0:N0} VNĐ", tongLoiNhuan);

                        // Đổi màu Lợi nhuận (Lãi = Xanh, Lỗ = Đỏ)
                        if (tongLoiNhuan >= 0) lblLoiNhuan.ForeColor = Color.Green;
                        else lblLoiNhuan.ForeColor = Color.Red;

                        // 3. Vẽ lên Biểu đồ
                        chartDoanhThu.Series["Doanh Thu"].Points.Clear();
                        chartDoanhThu.Series["Chi Phí"].Points.Clear();

                        foreach (DataRow row in dt.Rows)
                        {
                            DateTime ngay = Convert.ToDateTime(row["Ngay"]);
                            decimal thu = Convert.ToDecimal(row["DoanhThu"]);
                            decimal chi = Convert.ToDecimal(row["ChiPhi"]);

                            // Chỉ vẽ những ngày có số liệu > 0 để biểu đồ đỡ rối
                            if (thu > 0 || chi > 0)
                            {
                                chartDoanhThu.Series["Doanh Thu"].Points.AddXY(ngay, thu);
                                chartDoanhThu.Series["Chi Phí"].Points.AddXY(ngay, chi);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thống kê: " + ex.Message);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
