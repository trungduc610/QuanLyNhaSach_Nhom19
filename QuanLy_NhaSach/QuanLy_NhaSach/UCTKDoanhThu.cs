using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLy_NhaSach
{
    public partial class UCTKDoanhThu : UserControl
    {
        public UCTKDoanhThu()
        {
            InitializeComponent();

            NotificationHelper.TransactionCompleted += HandleTransactionCompleted;

            this.VisibleChanged += new EventHandler(UCTKDoanhThu_VisibleChanged);
        }

        private void UCTKDoanhThu_Load(object sender, EventArgs e)
        {
            // Thiết lập mặc định: Từ đầu tháng đến hôm nay
            dtpBatDau.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpKetThuc.Value = DateTime.Now;

            LoadBaoCao();
        }

        private void UCTKDoanhThu_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                LoadBaoCao();
            }
        }

        private void HandleTransactionCompleted()
        {
            if (this.Visible)
            {
                LoadBaoCao();
            }
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            LoadBaoCao();
        }

        private void LoadBaoCao()
        {
            if (dtpBatDau.Value > dtpKetThuc.Value)
            {
                MessageBox.Show("Ngày bắt đầu không được sau ngày kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1. TẠO THAM SỐ CHO TỔNG HỢP (Lần gọi 1)
                SqlParameter[] parsSummary = {
                    new SqlParameter("@NgayBatDau", dtpBatDau.Value.Date),
                    new SqlParameter("@NgayKetThuc", dtpKetThuc.Value.Date)
                };

                // Tải Báo cáo Tổng hợp
                DataTable dtSummary = DatabaseHelper.GetDataTable("SP_BaoCaoTaiChinh", parsSummary);

                if (dtSummary.Rows.Count > 0)
                {
                    DataRow row = dtSummary.Rows[0];
                    decimal giaVon = Convert.ToDecimal(row["TongGiaVon"]);
                    decimal doanhThu = Convert.ToDecimal(row["TongDoanhThu"]);
                    decimal loiNhuan = Convert.ToDecimal(row["LoiNhuanGop"]);

                    // Hiển thị kết quả Tổng hợp
                    lblGiaVon.Text = giaVon.ToString("N0") + " VNĐ";
                    lblDoanhThu.Text = doanhThu.ToString("N0") + " VNĐ";
                    lblLoiNhuan.Text = loiNhuan.ToString("N0") + " VNĐ";

                    // Đổi màu lợi nhuận
                    if (loiNhuan < 0)
                    {
                        pnlLoiNhuan.BackColor = System.Drawing.Color.FromArgb(192, 57, 43); // Đỏ nếu lỗ
                    }
                    else
                    {
                        pnlLoiNhuan.BackColor = System.Drawing.Color.FromArgb(46, 204, 113); // Xanh nếu lời
                    }
                }
                else
                {
                    // Trường hợp không có dữ liệu
                    lblGiaVon.Text = lblDoanhThu.Text = lblLoiNhuan.Text = "0 VNĐ";
                    pnlLoiNhuan.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
                }

                // 2. Tải Dữ liệu Chi tiết: Gọi hàm chi tiết sau khi có kết quả tổng hợp
                LoadChiTietBaoCao();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblGiaVon.Text = lblDoanhThu.Text = lblLoiNhuan.Text = "LỖI";
            }
        }

        private void LoadChiTietBaoCao()
        {
            try
            {
                // LƯU GIÁ TRỊ NGÀY RA MẢNG OBJECT
                object[] dateValues = { dtpBatDau.Value.Date, dtpKetThuc.Value.Date };

                // HÀM TẠO MẢNG THAM SỐ MỚI (Lambda Function)
                Func<SqlParameter[]> createParams = () => new SqlParameter[]
                {
                    new SqlParameter("@NgayBatDau", dateValues[0]),
                    new SqlParameter("@NgayKetThuc", dateValues[1])
                };


                // 2.1. Tải dữ liệu cho Biểu đồ (Biểu đồ Cột) - LẦN GỌI 2
                DataTable dtChart = DatabaseHelper.GetDataTable("SP_BaoCaoChiTietTaiChinh", createParams());
                DrawChart(dtChart);

                // 2.2. Tải Lịch sử Bán hàng - LẦN GỌI 3
                DataTable dtSales = DatabaseHelper.GetDataTable("SP_LayDanhSachHoaDonTheoNgay", createParams());
                dgvLichSuBan.DataSource = dtSales;

                // 2.3. Tải Lịch sử Nhập hàng - LẦN GỌI 4
                DataTable dtImports = DatabaseHelper.GetDataTable("SP_LayDanhSachPhieuNhapTheoNgay", createParams());
                dgvLichSuNhap.DataSource = dtImports;
            }
            catch (Exception ex)
            {
                // Nếu lỗi xảy ra khi tái sử dụng tham số, nó sẽ bị bắt ở đây
                MessageBox.Show("Lỗi tải chi tiết báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DrawChart(DataTable dtChart)
        {
            chartDoanhThu.Series.Clear();
            chartDoanhThu.Titles.Clear();

            // Cấu hình tiêu đề
            chartDoanhThu.Titles.Add("Doanh thu & Giá vốn theo ngày");

            // Series 1: Doanh thu
            Series seriesRevenue = new Series("Doanh Thu");
            seriesRevenue.ChartType = SeriesChartType.Column;
            seriesRevenue.IsValueShownAsLabel = true;
            seriesRevenue.Color = System.Drawing.Color.FromArgb(52, 152, 219); // Xanh dương

            // Series 2: Giá vốn
            Series seriesCost = new Series("Giá Vốn");
            seriesCost.ChartType = SeriesChartType.Column;
            seriesCost.IsValueShownAsLabel = true;
            seriesCost.Color = System.Drawing.Color.FromArgb(243, 156, 18); // Cam

            foreach (DataRow row in dtChart.Rows)
            {
                // Đảm bảo dữ liệu không bị NULL trước khi Convert
                if (row["NgayBaoCao"] != DBNull.Value && row["DoanhThuNgay"] != DBNull.Value)
                {
                    DateTime date = Convert.ToDateTime(row["NgayBaoCao"]);
                    string dateLabel = date.ToString("dd/MM");

                    // Lấy giá trị an toàn
                    decimal revenue = Convert.ToDecimal(row["DoanhThuNgay"]);
                    decimal cost = Convert.ToDecimal(row["GiaVonNgay"]);

                    // Thêm điểm dữ liệu
                    seriesRevenue.Points.AddXY(dateLabel, revenue);
                    seriesCost.Points.AddXY(dateLabel, cost);
                }
            }

            chartDoanhThu.Series.Add(seriesRevenue);
            chartDoanhThu.Series.Add(seriesCost);

            // Cấu hình trục X/Y
            chartDoanhThu.ChartAreas[0].AxisX.Title = "Ngày";
            chartDoanhThu.ChartAreas[0].AxisY.Title = "Giá trị (VNĐ)";
            chartDoanhThu.ChartAreas[0].AxisY.LabelStyle.Format = "N0";
        }
    }
}