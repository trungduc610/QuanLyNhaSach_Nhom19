using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLy_NhaSach
{
    public partial class UCAdminTools : UserControl
    {
        public UCAdminTools()
        {
            InitializeComponent();

            // Đặt đường dẫn mặc định
            txtBackupPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\NhaSachBackup";
        }

        // --- HÀM CHỌN FILE/FOLDER ---

        private void btnChonDuongDanBackup_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtBackupPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnChonDuongDanRestore_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Backup Files (*.bak)|*.bak";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtRestorePath.Text = openFileDialog.FileName;
            }
        }

        // --- 1. SAO LƯU (BACKUP) ---

        private void btnBackup_Click(object sender, EventArgs e)
        {
            string backupPath = txtBackupPath.Text.Trim();
            if (string.IsNullOrWhiteSpace(backupPath))
            {
                MessageBox.Show("Vui lòng chọn thư mục lưu trữ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SqlParameter[] pars = { new SqlParameter("@DuongDan", backupPath) };

                // Backup sử dụng DatabaseHelper (kết nối thường)
                DatabaseHelper.ExecuteNonQuery("SP_BackupDatabase", pars);

                MessageBox.Show("Sao lưu thành công!\nFile đã được lưu tại: " + backupPath,
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sao lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- 2. PHỤC HỒI (RESTORE) ---

        private void btnRestore_Click(object sender, EventArgs e)
        {
            string restoreFile = txtRestorePath.Text.Trim();
            if (string.IsNullOrWhiteSpace(restoreFile))
            {
                MessageBox.Show("Vui lòng chọn file phục hồi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("CẢNH BÁO: Việc phục hồi sẽ XÓA TOÀN BỘ dữ liệu hiện tại và thay thế bằng dữ liệu trong file backup.\nBạn có chắc chắn muốn tiếp tục?",
                "Xác nhận phục hồi", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.No)
            {
                return;
            }

            // Xử lý Restore phải dùng kết nối tới master
            string masterConnectionString = DatabaseHelper.ConnectionStringMaster;

            try
            {
                // Dùng SqlCommand để gọi trực tiếp thủ tục SP_RestoreDatabase
                using (SqlConnection connMaster = new SqlConnection(masterConnectionString))
                {
                    connMaster.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_RestoreNhaSach", connMaster))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 300; // Tăng timeout cho restore
                        cmd.Parameters.AddWithValue("@DuongDan", restoreFile);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Phục hồi Database thành công! Vui lòng khởi động lại ứng dụng.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Khuyến khích tắt ứng dụng sau khi Restore
                Application.Exit();

            }
            catch (SqlException ex)
            {
                // Thường gặp lỗi khi kết nối master bị đóng trước khi đưa về multi-user
                MessageBox.Show($"Phục hồi lỗi. Nguyên nhân: {ex.Message}", "Lỗi Phục Hồi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chung: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}