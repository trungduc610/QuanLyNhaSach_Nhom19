USE NhaSach;
GO

-- 1. Trigger BÁN HÀNG (Trừ kho, Tính tiền HD)
CREATE OR ALTER TRIGGER TG_BanSach
ON CHITIETHOADON
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Cập nhật ThanhTien & DonGia cho dòng vừa thêm
    UPDATE CT SET CT.ThanhTien = I.SoLuong * S.GiaBan, CT.DonGia = S.GiaBan
    FROM CHITIETHOADON CT
    JOIN inserted I ON CT.Ma_Hoa_Don = I.Ma_Hoa_Don AND CT.MaSach = I.MaSach
    JOIN SACH S ON CT.MaSach = S.MaSach;

    -- Trừ tồn kho (khi bán)
    UPDATE S SET S.SoLuong = S.SoLuong - I.SoLuong
    FROM SACH S JOIN inserted I ON S.MaSach = I.MaSach;
    
    -- Cộng lại tồn kho (nếu xóa chi tiết hóa đơn/trả hàng)
    UPDATE S SET S.SoLuong = S.SoLuong + D.SoLuong
    FROM SACH S JOIN deleted D ON S.MaSach = D.MaSach;

    -- Tính lại Tổng Tiền Hóa Đơn
    UPDATE HD SET HD.TongTien = (SELECT ISNULL(SUM(ThanhTien),0) FROM CHITIETHOADON WHERE Ma_Hoa_Don = HD.Ma_Hoa_Don)
    FROM HOADON HD
    WHERE HD.Ma_Hoa_Don IN (SELECT Ma_Hoa_Don FROM inserted UNION SELECT Ma_Hoa_Don FROM deleted);
END
GO

-- 2. Trigger NHẬP HÀNG (Cộng kho, Tính tiền PN)
CREATE OR ALTER TRIGGER TG_NhapSach
ON CHITIETPHIEUNHAP
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Cập nhật Thành Tiền Nhập
    UPDATE CT SET CT.ThanhTienNhap = I.SoLuongNhap * I.DonGiaNhap
    FROM CHITIETPHIEUNHAP CT JOIN inserted I ON CT.MaPhieuNhap = I.MaPhieuNhap AND CT.MaSach = I.MaSach;

    -- Cộng tồn kho
    UPDATE S SET S.SoLuong = S.SoLuong + I.SoLuongNhap
    FROM SACH S JOIN inserted I ON S.MaSach = I.MaSach;

    -- Trừ tồn kho (nếu xóa phiếu nhập sai)
    UPDATE S SET S.SoLuong = S.SoLuong - D.SoLuongNhap
    FROM SACH S JOIN deleted D ON S.MaSach = D.MaSach;

    -- Tính lại Tổng Tiền Phiếu Nhập
    UPDATE PN SET PN.TongTienNhap = (SELECT ISNULL(SUM(ThanhTienNhap),0) FROM CHITIETPHIEUNHAP WHERE MaPhieuNhap = PN.MaPhieuNhap)
    FROM PHIEUNHAPHANG PN
    WHERE PN.MaPhieuNhap IN (SELECT MaPhieuNhap FROM inserted UNION SELECT MaPhieuNhap FROM deleted);
END
GO