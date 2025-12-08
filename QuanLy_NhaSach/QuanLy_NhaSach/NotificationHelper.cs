using System;

namespace QuanLy_NhaSach
{
    // Class này dùng để phát tín hiệu cho các module khác
    public static class NotificationHelper
    {
        // Định nghĩa sự kiện: Khi giao dịch hoàn tất (TransactionCompleted)
        public static event Action TransactionCompleted;

        // Hàm gọi sự kiện (dùng trong UCBanSach và UCNhapSach)
        public static void FireTransactionCompleted()
        {
            // Kích hoạt sự kiện (Chỉ kích hoạt nếu có ai đó đang lắng nghe)
            TransactionCompleted?.Invoke();
        }
    }
}