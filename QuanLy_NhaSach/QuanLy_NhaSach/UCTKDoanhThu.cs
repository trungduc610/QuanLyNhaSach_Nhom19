using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLy_NhaSach
{
    public partial class UCTKDoanhThu : UserControl
    {
        private string _maHD_Print;
        private string _tenNV_Print;
        private string _tenKH_Print;
        private DateTime _ngayLap_Print;
        private DataTable _dtChiTiet_Print;
        private string _maPN_Print;
        private string _tenNV_PN_Print;
        private string _tenNCC_Print;
        private DateTime _ngayNhap_Print;
        private DataTable _dtChiTietPN_Print;
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
                // 1. TẠO THAM SỐ CHO TỔNG HỢP
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

        private void btn_In_Click(object sender, EventArgs e)
        {
            // TRƯỜNG HỢP 1: Đang ở tab LỊCH SỬ BÁN HÀNG -> In Hóa Đơn
            if (tabBaoCao.SelectedTab == tpLichSuBan)
            {
                if (dgvLichSuBan.CurrentRow == null || dgvLichSuBan.CurrentRow.IsNewRow)
                {
                    MessageBox.Show("Vui lòng chọn Hóa đơn cần in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy cột Ma_Hoa_Don (giả sử cột đầu tiên index 0)
                string maHD = dgvLichSuBan.CurrentRow.Cells[0].Value?.ToString();
                if (!string.IsNullOrEmpty(maHD))
                {
                    InHoaDonCu(maHD);
                }
            }
            // TRƯỜNG HỢP 2: Đang ở tab LỊCH SỬ NHẬP HÀNG -> In Phiếu Nhập
            else if (tabBaoCao.SelectedTab == tpLichSuNhap)
            {
                if (dgvLichSuNhap.CurrentRow == null || dgvLichSuNhap.CurrentRow.IsNewRow)
                {
                    MessageBox.Show("Vui lòng chọn Phiếu nhập cần in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy cột MaPhieuNhap (giả sử cột đầu tiên index 0)
                string maPN = dgvLichSuNhap.CurrentRow.Cells[0].Value?.ToString();
                if (!string.IsNullOrEmpty(maPN))
                {
                    InPhieuNhap(maPN);
                }
            }
            else
            {
                MessageBox.Show("Chức năng in chỉ hỗ trợ ở tab 'Lịch sử Bán' và 'Lịch sử Nhập'!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void InHoaDonCu(string maHoaDon)
        {
            _maHD_Print = maHoaDon;

            // 1. Lấy thông tin Header
            SqlParameter[] p1 = { new SqlParameter("@MaHoaDon", maHoaDon) };
            DataTable dtHeader = DatabaseHelper.GetDataTable("SP_LayThongTinHoaDon_DeIn", p1);

            if (dtHeader.Rows.Count > 0)
            {
                _ngayLap_Print = Convert.ToDateTime(dtHeader.Rows[0]["NgayLap"]);
                _tenNV_Print = dtHeader.Rows[0]["Ten_Nhan_Vien"].ToString();
                _tenKH_Print = dtHeader.Rows[0]["Ten_Khach_Hang"].ToString();
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin hóa đơn này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Lấy chi tiết
            SqlParameter[] p2 = { new SqlParameter("@MaHoaDon", maHoaDon) };
            _dtChiTiet_Print = DatabaseHelper.GetDataTable("SP_LayChiTietHoaDon_DeIn", p2);

            // 3. Khởi tạo in
            PrintDocument pdoc = new PrintDocument();
            pdoc.PrintPage += new PrintPageEventHandler(pdoc_InHoaDon_PrintPage);

            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = pdoc;
            ((Form)preview).WindowState = FormWindowState.Maximized;
            preview.ShowDialog();
        }

        private void pdoc_InHoaDon_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font fTitle = new Font("Arial", 22, FontStyle.Bold);
            Font fSubTitle = new Font("Arial", 16, FontStyle.Bold);
            Font fBold = new Font("Arial", 11, FontStyle.Bold);
            Font fRegular = new Font("Arial", 11, FontStyle.Regular);
            Font fItalic = new Font("Arial", 10, FontStyle.Italic);
            Font fTotal = new Font("Arial", 14, FontStyle.Bold);

            Brush brush = Brushes.Black;
            Pen pen = new Pen(Color.Black, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Solid };
            StringFormat center = new StringFormat() { Alignment = StringAlignment.Center };
            StringFormat left = new StringFormat() { Alignment = StringAlignment.Near };
            StringFormat right = new StringFormat() { Alignment = StringAlignment.Far };

            int w = e.PageBounds.Width;
            int margin = 50;
            int y = 50;
            int xTenSach = margin;
            int xSL = w - margin - 220;
            int xGia = w - margin - 110;
            int xTien = w - margin;

            y += 50;
            g.DrawString("HÓA ĐƠN BÁN HÀNG", fSubTitle, brush, new RectangleF(0, y, w, 30), center);
            y += 40;

            g.DrawString($"Khách hàng: {_tenKH_Print}", fRegular, brush, margin, y);
            g.DrawString($"Số: {_maHD_Print}", fBold, brush, w - margin, y, right);
            y += 25;
            g.DrawString($"Nhân viên: {_tenNV_Print}", fRegular, brush, margin, y);
            g.DrawString($"Ngày: {_ngayLap_Print:dd/MM/yyyy HH:mm}", fRegular, brush, w - margin, y, right);
            y += 35;

            g.DrawLine(new Pen(Color.Black, 2), margin, y, w - margin, y);
            y += 8;
            g.DrawString("Tên Sách", fBold, brush, xTenSach, y, left);
            g.DrawString("SL", fBold, brush, xSL, y, right);
            g.DrawString("Đơn Giá", fBold, brush, xGia, y, right);
            g.DrawString("Thành Tiền", fBold, brush, xTien, y, right);
            y += 25;
            g.DrawLine(pen, margin, y, w - margin, y);
            y += 15;

            decimal tongTien = 0;
            foreach (DataRow row in _dtChiTiet_Print.Rows)
            {
                string ten = row["TenSach"].ToString();
                if (ten.Length > 45) ten = ten.Substring(0, 42) + "...";

                int sl = Convert.ToInt32(row["SoLuong"]);
                decimal gia = Convert.ToDecimal(row["DonGia"]);
                decimal thanhTien = Convert.ToDecimal(row["ThanhTien"]);
                tongTien += thanhTien;

                g.DrawString(ten, fRegular, brush, xTenSach, y, left);
                g.DrawString(sl.ToString(), fRegular, brush, xSL, y, right);
                g.DrawString(gia.ToString("N0"), fRegular, brush, xGia, y, right);
                g.DrawString(thanhTien.ToString("N0"), fRegular, brush, xTien, y, right);
                y += 30;
            }

            y += 10;
            g.DrawLine(new Pen(Color.Black, 2), margin, y, w - margin, y);
            y += 20;

            g.DrawString("TỔNG CỘNG:", fBold, brush, xGia - 50, y, right);
            g.DrawString(tongTien.ToString("N0") + " VNĐ", fTotal, brush, xTien, y - 3, right);
            y += 80;
            g.DrawString("Cảm ơn quý khách và hẹn gặp lại!", fItalic, brush, new RectangleF(0, y, w, 30), center);
        }

        private void InPhieuNhap(string maPhieuNhap)
        {
            _maPN_Print = maPhieuNhap;

            // 1. Lấy Header
            SqlParameter[] p1 = { new SqlParameter("@MaPhieuNhap", maPhieuNhap) };
            DataTable dtHeader = DatabaseHelper.GetDataTable("SP_LayThongTinPhieuNhap_DeIn", p1);

            if (dtHeader.Rows.Count > 0)
            {
                _ngayNhap_Print = Convert.ToDateTime(dtHeader.Rows[0]["NgayNhap"]);
                _tenNV_PN_Print = dtHeader.Rows[0]["Ten_Nhan_Vien"].ToString();
                _tenNCC_Print = dtHeader.Rows[0]["Ten_Nha_Cung_Cap"].ToString();
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin phiếu nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Lấy Chi tiết
            SqlParameter[] p2 = { new SqlParameter("@MaPhieuNhap", maPhieuNhap) };
            _dtChiTietPN_Print = DatabaseHelper.GetDataTable("SP_LayChiTietPhieuNhap_DeIn", p2);

            // 3. Khởi tạo in
            PrintDocument pdoc = new PrintDocument();
            pdoc.PrintPage += new PrintPageEventHandler(pdoc_InPhieuNhap_PrintPage);

            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = pdoc;
            ((Form)preview).WindowState = FormWindowState.Maximized;
            preview.ShowDialog();
        }

        private void pdoc_InPhieuNhap_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            // (Dùng lại các Font cũ)
            Font fSubTitle = new Font("Arial", 16, FontStyle.Bold);
            Font fBold = new Font("Arial", 11, FontStyle.Bold);
            Font fRegular = new Font("Arial", 11, FontStyle.Regular);
            Font fTotal = new Font("Arial", 14, FontStyle.Bold);
            Brush brush = Brushes.Black;
            StringFormat center = new StringFormat() { Alignment = StringAlignment.Center };
            StringFormat right = new StringFormat() { Alignment = StringAlignment.Far };
            StringFormat left = new StringFormat() { Alignment = StringAlignment.Near };

            int w = e.PageBounds.Width;
            int margin = 50;
            int y = 50;
            int xTenSach = margin;
            int xSL = w - margin - 220;
            int xGia = w - margin - 110;
            int xTien = w - margin;

            // Header
            y += 50;
            g.DrawString("PHIẾU NHẬP HÀNG", fSubTitle, brush, new RectangleF(0, y, w, 30), center);
            y += 40;

            g.DrawString($"Nhà cung cấp: {_tenNCC_Print}", fRegular, brush, margin, y);
            g.DrawString($"Mã phiếu: {_maPN_Print}", fBold, brush, w - margin, y, right);
            y += 25;
            g.DrawString($"Nhân viên nhập: {_tenNV_PN_Print}", fRegular, brush, margin, y);
            g.DrawString($"Ngày nhập: {_ngayNhap_Print:dd/MM/yyyy}", fRegular, brush, w - margin, y, right);
            y += 35;

            // Table Header
            g.DrawLine(new Pen(Color.Black, 2), margin, y, w - margin, y);
            y += 8;
            g.DrawString("Tên Sách", fBold, brush, xTenSach, y, left);
            g.DrawString("SL", fBold, brush, xSL, y, right);
            g.DrawString("Giá Nhập", fBold, brush, xGia, y, right);
            g.DrawString("Thành Tiền", fBold, brush, xTien, y, right);
            y += 25;
            g.DrawLine(new Pen(Color.Black, 1), margin, y, w - margin, y);
            y += 15;

            // Table Body
            decimal tongTien = 0;
            foreach (DataRow row in _dtChiTietPN_Print.Rows)
            {
                string ten = row["TenSach"].ToString();
                if (ten.Length > 45) ten = ten.Substring(0, 42) + "...";
                int sl = Convert.ToInt32(row["SoLuongNhap"]);
                decimal gia = Convert.ToDecimal(row["DonGiaNhap"]);
                decimal thanhTien = Convert.ToDecimal(row["ThanhTien"]);
                tongTien += thanhTien;

                g.DrawString(ten, fRegular, brush, xTenSach, y, left);
                g.DrawString(sl.ToString(), fRegular, brush, xSL, y, right);
                g.DrawString(gia.ToString("N0"), fRegular, brush, xGia, y, right);
                g.DrawString(thanhTien.ToString("N0"), fRegular, brush, xTien, y, right);
                y += 30;
            }

            // Footer
            y += 10;
            g.DrawLine(new Pen(Color.Black, 2), margin, y, w - margin, y);
            y += 20;
            g.DrawString("TỔNG TIỀN NHẬP:", fBold, brush, xGia - 50, y, right);
            g.DrawString(tongTien.ToString("N0") + " VNĐ", fTotal, brush, xTien, y - 3, right);
        }
    }
}