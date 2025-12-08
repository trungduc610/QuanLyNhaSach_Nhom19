using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Text;
using System.Windows.Forms;

namespace QuanLy_NhaSach
{
    public static class DatabaseHelper
    {
        // === 1. CHUỖI KẾT NỐI ===
        public static string ConnectionString = @"Data Source=DESKTOP-DF0P4U3\SQLEXPRESS;Initial Catalog=NhaSach;User ID=sa;Password=123;Encrypt=True;TrustServerCertificate=True";
        public static string ConnectionStringMaster = @"Data Source=DESKTOP-DF0P4U3\SQLEXPRESS;Initial Catalog=NhaSach;User ID=sa;Password=123;Encrypt=True;TrustServerCertificate=True";

        // === HÀM CHUNG: Xác định chuỗi kết nối mặc định ===
        private static string GetDefaultConnectionString(string connStrOverride)
        {
            // Nếu không có chuỗi kết nối override, dùng chuỗi kết nối NhaSach mặc định
            return string.IsNullOrEmpty(connStrOverride) ? ConnectionString : connStrOverride;
        }

        // 2. HÀM LẤY DỮ LIỆU (SELECT) -> Trả về DataTable
        // Overload 1: Dùng chuỗi kết nối mặc định (NhaSach)
        public static DataTable GetDataTable(string query, SqlParameter[] parameters = null)
        {
            return GetDataTable(query, parameters, null);
        }

        // Overload 2: Cho phép override chuỗi kết nối (Ví dụ: Master)
        public static DataTable GetDataTable(string query, SqlParameter[] parameters, string connectionStringOverride)
        {
            string connStr = GetDefaultConnectionString(connectionStringOverride);

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
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


        // 3. HÀM THỰC THI (INSERT, UPDATE, DELETE) -> Trả về số dòng ảnh hưởng
        // Overload 1: Dùng chuỗi kết nối mặc định (NhaSach)
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            return ExecuteNonQuery(query, parameters, null);
        }

        // Overload 2: Cho phép override chuỗi kết nối (Ví dụ: Master)
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
                        throw ex;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        // 4. HÀM LẤY 1 GIÁ TRỊ (COUNT, SUM...) - Dùng kết nối mặc định
        public static object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            // Code giữ nguyên (Dùng kết nối mặc định)
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

        // 5. HÀM XÓA DẤU TIẾNG VIỆT (Giữ nguyên)
        public static string XoaDau(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        // 6. HÀM RESTORE DATABASE (Đã có, dùng MasterConnectionString)
        public static void RestoreDatabase(string duongDanFile)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionStringMaster))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_RestoreNhaSach", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DuongDan", duongDanFile);
                    cmd.CommandTimeout = 120; // 2 phút
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}