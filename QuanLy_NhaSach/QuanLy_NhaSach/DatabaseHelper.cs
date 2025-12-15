using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLy_NhaSach
{
    public static class DatabaseHelper
    {
        // === 1. CHUỖI KẾT NỐI ===
        public static string ConnectionString = @"Data Source=DESKTOP-69B7U6D\SQLDEV2022;Initial Catalog=NhaSach;Persist Security Info=True;User ID=sa;Password=123;TrustServerCertificate=True";
        public static string ConnectionStringMaster = @"Data Source=DESKTOP-69B7U6D\SQLDEV2022;Initial Catalog=master;Persist Security Info=True;User ID=sa;Password=123;TrustServerCertificate=True";

        private static string GetDefaultConnectionString(string connStrOverride)
        {
            return string.IsNullOrEmpty(connStrOverride) ? ConnectionString : connStrOverride;
        }

        // 2. HÀM LẤY DỮ LIỆU (SELECT)
        public static DataTable GetDataTable(string query, SqlParameter[] parameters = null)
        {
            return GetDataTable(query, parameters, null);
        }

        public static DataTable GetDataTable(string query, SqlParameter[] parameters, string connectionStringOverride)
        {
            string connStr = GetDefaultConnectionString(connectionStringOverride);
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Tự động nhận diện Stored Procedure nếu không có khoảng trắng
                    if (!query.Contains(" ")) cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null) cmd.Parameters.AddRange(parameters);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    try
                    {
                        da.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi truy vấn: " + ex.Message);
                    }
                    return dt;
                }
            }
        }

        // 3. HÀM THỰC THI (INSERT, UPDATE, DELETE)
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            return ExecuteNonQuery(query, parameters, null);
        }

        public static int ExecuteNonQuery(string query, SqlParameter[] parameters, string connectionStringOverride)
        {
            string connStr = GetDefaultConnectionString(connectionStringOverride);
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!query.Contains(" ")) cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null) cmd.Parameters.AddRange(parameters);

                    try
                    {
                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw ex; // Ném lỗi để Form bắt được (Ví dụ: Trùng mã)
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        // 4. HÀM LẤY 1 GIÁ TRỊ (COUNT, SUM...)
        public static object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!query.Contains(" ")) cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null) cmd.Parameters.AddRange(parameters);

                    try
                    {
                        conn.Open();
                        return cmd.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi lấy dữ liệu đơn: " + ex.Message);
                    }
                }
            }
        }

        // 5. HÀM XÓA DẤU TIẾNG VIỆT
        public static string XoaDau(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        // 6. HÀM RESTORE DATABASE
        public static void RestoreDatabase(string duongDanFile)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionStringMaster))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_RestoreNhaSach", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DuongDan", duongDanFile);
                    cmd.CommandTimeout = 120;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // === 7. [MỚI] HÀM SINH MÃ TỰ ĐỘNG ===
        public static string TaoMaTuDong(string tienTo, string tenBang, string tenCotMa)
        {
            // Lấy mã lớn nhất hiện tại (Sắp xếp theo độ dài rồi đến giá trị để tránh lỗi KH1 < KH10)
            string query = $"SELECT TOP 1 {tenCotMa} FROM {tenBang} ORDER BY LEN({tenCotMa}) DESC, {tenCotMa} DESC";
            DataTable dt = GetDataTable(query);

            if (dt.Rows.Count == 0)
            {
                // Nếu bảng chưa có dữ liệu, trả về mã đầu tiên (VD: KH001)
                return tienTo + "001";
            }

            string maCu = dt.Rows[0][0].ToString();

            // Cắt bỏ phần tiền tố để lấy số (KH014 -> 014)
            string phanSo = maCu.Substring(tienTo.Length);

            if (int.TryParse(phanSo, out int soMoi))
            {
                soMoi++;
                return tienTo + soMoi.ToString("D3");
            }

            return tienTo + "001";
        }
    }
}