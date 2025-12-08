//using System;
//using System.Data;
//using System.Data.SqlClient;
//using System.Windows.Forms;
//using Microsoft.Reporting.WinForms; // Bắt buộc phải có thư viện này

//namespace QuanLy_NhaSach
//{
//    public partial class frm_InHoaDon : Form
//    {
//        private string _maHoaDon;

//        // Form nhận Mã Hóa Đơn cần in
//        public frm_InHoaDon(string maHD)
//        {
//            InitializeComponent();
//            _maHoaDon = maHD;
//            this.Text = $"In Hóa Đơn: {maHD}";
//        }

//        private void frm_InHoaDon_Load(object sender, EventArgs e)
//        {
//            LoadReport();
//        }

//        private void LoadReport()
//        {
//            try
//            {
//                SqlParameter[] pars = { new SqlParameter("@Ma_Hoa_Don", _maHoaDon) };

//                // Lấy dữ liệu chi tiết hóa đơn từ SQL (SP_LayChiTietHoaDon)
//                DataTable dtReport = DatabaseHelper.GetDataTable("SP_LayChiTietHoaDon", pars);

//                // --- 1. XỬ LÝ DỮ LIỆU ---
//                decimal tongTien = 0;
//                foreach (DataRow row in dtReport.Rows)
//                {
//                    // Tính tổng tiền cho tham số (Parameter)
//                    tongTien += Convert.ToDecimal(row["ThanhTien"]);
//                }

//                // --- 2. GÁN DỮ LIỆU VÀO REPORTVIEWER ---

//                // Khai báo ReportDataSource (Tên phải khớp chính xác với tên trong file RDLC: DataSetHoaDon)
//                ReportDataSource rds = new ReportDataSource("DataSetHoaDon", dtReport);

//                // Thiết lập ReportViewer (Tên file RDLC)
//                reportViewer1.LocalReport.ReportPath = "HoaDon.rdlc";

//                // Xóa và Thêm DataSource
//                reportViewer1.LocalReport.DataSources.Clear();
//                reportViewer1.LocalReport.DataSources.Add(rds);

//                // Thêm tham số Tổng tiền (Parameter: TongThanhToan)
//                ReportParameter paramTongTien = new ReportParameter("TongThanhToan", tongTien.ToString("N0") + " VNĐ");
//                reportViewer1.LocalReport.SetParameters(paramTongTien);


//                // 3. Refresh Report để hiển thị
//                this.reportViewer1.RefreshReport();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Lỗi tải báo cáo: " + ex.Message + "\nKiểm tra:\n1. Tên DataSet trong RDLC\n2. Cài đặt ReportViewer", "Lỗi In Hóa Đơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }
//    }
//}