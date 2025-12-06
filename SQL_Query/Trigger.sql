USE NhaSach;
GO

-- 1. Trigger KIỂM TRA TỒN KHO trước khi bán
CREATE OR ALTER TRIGGER TG_KiemTraTonKho
ON CHITIETHOADON
INSTEAD OF INSERT -- Dùng INSTEAD OF để kiểm tra TRƯỚC KHI thực sự INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra xem có dòng nào trong 'inserted' (dữ liệu sắp chèn) vi phạm số lượng tồn kho hay không
    IF EXISTS (
        SELECT 1
        FROM inserted AS i
        JOIN SACH AS s ON i.MaSach = s.MaSach
        WHERE i.SoLuong > s.SoLuong
    )
    BEGIN
        -- Nếu có, ném ra một lỗi và hủy giao dịch
        RAISERROR (N'Không đủ số lượng sách trong kho. Không thể thực hiện giao dịch.', 16, 1);
        ROLLBACK TRANSACTION;
    END
    ELSE
    BEGIN
        -- Nếu không vi phạm, tiến hành INSERT bình thường
        INSERT INTO CHITIETHOADON (Ma_Hoa_Don, MaSach, SoLuong)
        SELECT Ma_Hoa_Don, MaSach, SoLuong FROM inserted;
    END
END
GO


-- 2. Trigger CẬP NHẬT TỒN KHO VÀ TỔNG TIỀN sau khi bán
CREATE OR ALTER TRIGGER TG_CapNhatHoaDon_Va_TonKho
ON CHITIETHOADON
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Biến lưu các Ma_Hoa_Don bị ảnh hưởng
    DECLARE @AffectedHoaDon TABLE (Ma_Hoa_Don CHAR(10) PRIMARY KEY);

    -- ===== PHẦN 1: XỬ LÝ INSERT VÀ UPDATE (BÁN HÀNG) =====
    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        -- Lấy danh sách các hóa đơn bị ảnh hưởng
        INSERT INTO @AffectedHoaDon (Ma_Hoa_Don)
        SELECT DISTINCT Ma_Hoa_Don FROM inserted;

        -- 1a. Cập nhật DonGia (lấy giá từ bảng SACH) và ThanhTien cho các dòng vừa INSERT/UPDATE
        UPDATE CTHD
        SET 
            CTHD.DonGia = S.GiaBan, -- Lấy giá bán hiện tại của sách
            CTHD.ThanhTien = i.SoLuong * S.GiaBan -- Tính thành tiền
        FROM CHITIETHOADON AS CTHD
        JOIN inserted AS i ON CTHD.Ma_Hoa_Don = i.Ma_Hoa_Don AND CTHD.MaSach = i.MaSach
        JOIN SACH AS S ON i.MaSach = S.MaSach;

        -- 1b. Cập nhật (TRỪ) số lượng tồn kho trong bảng SACH
        UPDATE S
        SET S.SoLuong = S.SoLuong - (
            SELECT SUM(i.SoLuong) 
            FROM inserted AS i 
            WHERE i.MaSach = S.MaSach
            GROUP BY i.MaSach
        )
        FROM SACH AS S
        WHERE S.MaSach IN (SELECT DISTINCT MaSach FROM inserted);

        -- 1c. Xử lý logic cho UPDATE (cộng trả lại kho số lượng cũ)
        IF EXISTS (SELECT * FROM deleted) -- Đây là trường hợp UPDATE
        BEGIN
            UPDATE S
            SET S.SoLuong = S.SoLuong + (
                SELECT SUM(d.SoLuong)
                FROM deleted AS d
                WHERE d.MaSach = S.MaSach
                GROUP BY d.MaSach
            )
            FROM SACH AS S
            WHERE S.MaSach IN (SELECT DISTINCT MaSach FROM deleted);
        END
    END

    -- ===== PHẦN 2: XỬ LÝ DELETE (TRẢ HÀNG) =====
    IF EXISTS (SELECT * FROM deleted) AND NOT EXISTS (SELECT * FROM inserted)
    BEGIN
        -- Lấy danh sách các hóa đơn bị ảnh hưởng
        INSERT INTO @AffectedHoaDon (Ma_Hoa_Don)
        SELECT DISTINCT Ma_Hoa_Don 
        FROM deleted 
        WHERE Ma_Hoa_Don NOT IN (SELECT Ma_Hoa_Don FROM @AffectedHoaDon); -- Tránh trùng lặp

        -- 2a. Cập nhật (CỘNG TRẢ) số lượng tồn kho
        UPDATE S
        SET S.SoLuong = S.SoLuong + (
            SELECT SUM(d.SoLuong)
            FROM deleted AS d
            WHERE d.MaSach = S.MaSach
            GROUP BY d.MaSach
        )
        FROM SACH AS S
        WHERE S.MaSach IN (SELECT DISTINCT MaSach FROM deleted);
    END

    -- ===== PHẦN 3: CẬP NHẬT TỔNG TIỀN CHO TẤT CẢ HÓA ĐƠN BỊ ẢNH HƯỞNG =====
    UPDATE HD
    SET HD.TongTien = ISNULL(
        (
            SELECT SUM(CTHD.ThanhTien)
            FROM CHITIETHOADON AS CTHD
            WHERE CTHD.Ma_Hoa_Don = HD.Ma_Hoa_Don
        ), 0) -- Nếu hóa đơn không còn chi tiết nào, TongTien = 0
    FROM HOADON AS HD
    JOIN @AffectedHoaDon AS AHD ON HD.Ma_Hoa_Don = AHD.Ma_Hoa_Don;

END
GO

-- 3. Trigger CẬP NHẬT TỒN KHO VÀ TỔNG TIỀN khi NHẬP HÀNG
CREATE OR ALTER TRIGGER TG_CapNhatPhieuNhap_Va_TonKho
ON CHITIETPHIEUNHAP
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @AffectedPhieuNhap TABLE (MaPhieuNhap CHAR(10) PRIMARY KEY);

    -- ===== PHẦN 1: XỬ LÝ INSERT VÀ UPDATE (NHẬP HÀNG) =====
    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        INSERT INTO @AffectedPhieuNhap (MaPhieuNhap)
        SELECT DISTINCT MaPhieuNhap FROM inserted;

        UPDATE CTPN
        SET CTPN.ThanhTienNhap = i.SoLuongNhap * i.DonGiaNhap
        FROM CHITIETPHIEUNHAP AS CTPN
        JOIN inserted AS i ON CTPN.MaPhieuNhap = i.MaPhieuNhap AND CTPN.MaSach = i.MaSach;

        UPDATE S
        SET S.SoLuong = S.SoLuong + i.SoLuongNhap
        FROM SACH AS S
        JOIN inserted AS i ON S.MaSach = i.MaSach;

        IF EXISTS (SELECT * FROM deleted) -- Trường hợp UPDATE
        BEGIN
            UPDATE S
            SET S.SoLuong = S.SoLuong - d.SoLuongNhap
            FROM SACH AS S
            JOIN deleted AS d ON S.MaSach = d.MaSach;
        END
    END

    -- ===== PHẦN 2: XỬ LÝ DELETE (HỦY PHIẾU NHẬP) =====
    IF EXISTS (SELECT * FROM deleted) AND NOT EXISTS (SELECT * FROM inserted)
    BEGIN
        INSERT INTO @AffectedPhieuNhap (MaPhieuNhap)
        SELECT DISTINCT MaPhieuNhap 
        FROM deleted 
        WHERE MaPhieuNhap NOT IN (SELECT MaPhieuNhap FROM @AffectedPhieuNhap);

        UPDATE S
        SET S.SoLuong = S.SoLuong - d.SoLuongNhap
        FROM SACH AS S
        JOIN deleted AS d ON S.MaSach = d.MaSach;
    END

    -- ===== PHẦN 3: CẬP NHẬT TỔNG TIỀN PHIẾU NHẬP =====
    UPDATE PN
    SET PN.TongTienNhap = ISNULL(
        (
            SELECT SUM(CTPN.ThanhTienNhap)
            FROM CHITIETPHIEUNHAP AS CTPN
            WHERE CTPN.MaPhieuNhap = PN.MaPhieuNhap
        ), 0)
    FROM PHIEUNHAPHANG AS PN
    JOIN @AffectedPhieuNhap AS APN ON PN.MaPhieuNhap = APN.MaPhieuNhap;

END
GO