USE NhaSach;
GO

--SP cập nhật CHI_TIET_HOA_DON.thanh_tien
CREATE PROC SP_UPDATE_CHI_TIET_HOA_DON_THANH_TIEN
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE CHITIETHOADON
    SET ThanhTien = SoLuong *
        (SELECT GiaBan
         FROM SACH
         WHERE SACH.MaSach = CHITIETHOADON.MaSach);
END;

EXEC SP_UPDATE_CHI_TIET_HOA_DON_THANH_TIEN;

--SP cập nhật HOA_DON.tong_tien
CREATE PROC SP_UPDATE_HOA_DON_TONG_TIEN
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE HOADON
    SET TongTien =
        (SELECT SUM(CHITIETHOADON.ThanhTien)
         FROM CHITIETHOADON
         WHERE CHITIETHOADON.Ma_Hoa_Don = HOADON.Ma_Hoa_Don);
END;

EXEC SP_UPDATE_HOA_DON_TONG_TIEN;

--  SP cập nhật CHI_TIET_PHIEU_NHAP.ThanhTienNhap
CREATE PROC SP_UPDATE_CHI_TIET_PHIEU_NHAP_THANH_TIEN
AS
BEGIN
    SET NOCOUNT ON;

    -- ThanhTienNhap = SoLuongNhap * DonGiaNhap (lấy từ chính bảng CTPN)
    UPDATE CHITIETPHIEUNHAP
    SET ThanhTienNhap = SoLuongNhap * DonGiaNhap
    WHERE ThanhTienNhap IS NULL OR ThanhTienNhap != (SoLuongNhap * DonGiaNhap);
END;
GO

EXEC SP_UPDATE_CHI_TIET_PHIEU_NHAP_THANH_TIEN

--  SP cập nhật PHIEU_NHAP_HANG.TongTienNhap
CREATE PROC SP_UPDATE_PHIEU_NHAP_TONG_TIEN
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE PHIEUNHAPHANG
    SET TongTienNhap = ISNULL(
        (SELECT SUM(CTPN.ThanhTienNhap)
         FROM CHITIETPHIEUNHAP AS CTPN
         WHERE CTPN.MaPhieuNhap = PHIEUNHAPHANG.MaPhieuNhap), 0);
END;
GO

EXEC SP_UPDATE_PHIEU_NHAP_TONG_TIEN


-- 3. SP cho chức năng Báo Cáo Doanh Thu
CREATE PROCEDURE SP_ThongKeDoanhThuTheoNgay
    @TuNgay DATE,
    @DenNgay DATE
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        HD.NgayLap,
        COUNT(DISTINCT HD.Ma_Hoa_Don) AS SoLuongHoaDon,
        SUM(HD.TongTien) AS TongDoanhThu
    FROM HOADON AS HD
    WHERE 
        HD.NgayLap BETWEEN @TuNgay AND @DenNgay
    GROUP BY 
        HD.NgayLap
    ORDER BY
        HD.NgayLap ASC;
END
GO

-- 4. SP để xem chi tiết một hóa đơn
CREATE PROCEDURE SP_LayChiTietHoaDon
    @Ma_Hoa_Don CHAR(10)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        CT.MaSach,
        S.TenSach,
        CT.SoLuong,
        CT.DonGia,
        CT.ThanhTien
    FROM CHITIETHOADON AS CT
    JOIN SACH AS S ON CT.MaSach = S.MaSach
    WHERE 
        CT.Ma_Hoa_Don = @Ma_Hoa_Don;
END
GO

-- 5. SP để xem chi tiết một phiếu NHẬP
CREATE PROCEDURE SP_LayChiTietPhieuNhap
    @MaPhieuNhap CHAR(10)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        CT.MaSach,
        S.TenSach,
        CT.SoLuongNhap,
        CT.DonGiaNhap,
        CT.ThanhTienNhap
    FROM CHITIETPHIEUNHAP AS CT
    JOIN SACH AS S ON CT.MaSach = S.MaSach
    WHERE 
        CT.MaPhieuNhap = @MaPhieuNhap;
END
GO

-----------------------------------------------
-- SP Đăng nhập và đổi mật khẩu

-- SP đăng nhập
CREATE PROCEDURE SP_DangNhap
    @TenDangNhap VARCHAR(50),
    @MatKhau VARCHAR(50) -- Nhận mật khẩu thô
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        TK.TenDangNhap,
        NV.Ten_Nhan_Vien,
        TK.Quyen,
        NV.Ma_Nhan_Vien
    FROM TAIKHOAN AS TK
    JOIN NHANVIEN AS NV ON TK.Ma_Nhan_Vien = NV.Ma_Nhan_Vien
    WHERE 
        TK.TenDangNhap = @TenDangNhap 
        AND TK.MatKhau = @MatKhau -- So sánh trực tiếp (không an toàn)
        AND NV.TrangThai = 1; -- Chỉ cho đăng nhập nếu nhân viên còn làm
END
GO
-- 2. SP Lấy danh sách tài khoản (cho Admin xem)
CREATE PROCEDURE SP_LayDanhSachTaiKhoan
AS
BEGIN
    SELECT 
        T.TenDangNhap AS N'Tên đăng nhập', 
        N.Ten_Nhan_Vien AS N'Tên nhân viên', 
        T.Quyen AS N'Quyền'
    FROM TAIKHOAN AS T
    JOIN NHANVIEN AS N ON T.Ma_Nhan_Vien = N.Ma_Nhan_Vien;
END
GO

-- 3. SP Lấy danh sách nhân viên CHƯA có tài khoản (để tạo)
CREATE PROCEDURE SP_LayNhanVienChuaCoTaiKhoan
AS
BEGIN
    SELECT 
        Ma_Nhan_Vien, 
        Ten_Nhan_Vien
    FROM NHANVIEN
    WHERE 
        TrangThai = 1 -- Chỉ tạo TK cho nhân viên đang làm
        AND Ma_Nhan_Vien NOT IN (SELECT Ma_Nhan_Vien FROM TAIKHOAN);
END
GO

-- 4. SP Tạo tài khoản mới (Admin đăng ký cho nhân viên)
CREATE PROCEDURE SP_TaoTaiKhoan
    @TenDangNhap VARCHAR(50),
    @MatKhau VARCHAR(50),
    @Ma_Nhan_Vien CHAR(10),
    @Quyen VARCHAR(20)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM TAIKHOAN WHERE TenDangNhap = @TenDangNhap)
    BEGIN
        RAISERROR(N'Tên đăng nhập đã tồn tại.', 16, 1);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM TAIKHOAN WHERE Ma_Nhan_Vien = @Ma_Nhan_Vien)
    BEGIN
        RAISERROR(N'Nhân viên này đã có tài khoản.', 16, 1);
        RETURN;
    END

    INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, Ma_Nhan_Vien, Quyen)
    VALUES (@TenDangNhap, @MatKhau, @Ma_Nhan_Vien, @Quyen);
END
GO

-- SP mới để xóa tài khoản bằng Mã NV
CREATE PROCEDURE SP_XoaTaiKhoanTheoMaNV
    @Ma_Nhan_Vien CHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM TAIKHOAN
    WHERE Ma_Nhan_Vien = @Ma_Nhan_Vien;
END
GO

--SP Đổi mật khẩu
CREATE PROCEDURE SP_DoiMatKhau
    @TenDangNhap VARCHAR(50),
    @MatKhauCu VARCHAR(50),
    @MatKhauMoi VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @MatKhauTrongDB VARCHAR(50);

    -- Lấy mật khẩu hiện tại trong CSDL
    SELECT @MatKhauTrongDB = MatKhau 
    FROM TAIKHOAN 
    WHERE TenDangNhap = @TenDangNhap;

    -- Kiểm tra xem mật khẩu cũ có đúng không
    IF (@MatKhauTrongDB = @MatKhauCu)
    BEGIN
        -- Nếu đúng, cập nhật mật khẩu mới
        UPDATE TAIKHOAN
        SET MatKhau = @MatKhauMoi
        WHERE TenDangNhap = @TenDangNhap;
        
        SELECT 1 AS ThanhCong; -- Trả về 1 nếu thành công
    END
    ELSE
    BEGIN
        -- Nếu sai, trả về 0 (Mật khẩu cũ không đúng)
        SELECT 0 AS ThanhCong;
    END
END
GO

-----------------------------------------------------------
-- SP cho UCQLNhanvien

-- 1. SP LẤY DANH SÁCH NHÂN VIÊN (Quan trọng: có kiểm tra tài khoản)
IF OBJECT_ID('SP_LayDanhSachNhanVien', 'P') IS NOT NULL
    DROP PROCEDURE SP_LayDanhSachNhanVien;
GO
CREATE PROCEDURE SP_LayDanhSachNhanVien
AS
BEGIN
    SELECT 
        N.Ma_Nhan_Vien,
        N.Ten_Nhan_Vien,
        N.NgaySinh,
        N.GioiTinh,
        N.So_Dien_Thoai,
        N.DiaChi,
        -- Cột kiểm tra, dùng 'LEFT JOIN'
        CASE 
            WHEN T.TenDangNhap IS NOT NULL THEN N'Đã có' 
            ELSE N'Chưa có' 
        END AS TinhTrangTaiKhoan
    FROM 
        NHANVIEN AS N
    LEFT JOIN 
        TAIKHOAN AS T ON N.Ma_Nhan_Vien = T.Ma_Nhan_Vien
    WHERE
        N.TrangThai = 1; -- Chỉ hiển thị nhân viên đang làm
END
GO

-- 2. SP THÊM NHÂN VIÊN MỚI (Tự động sinh mã)
IF OBJECT_ID('SP_ThemNhanVien', 'P') IS NOT NULL
    DROP PROCEDURE SP_ThemNhanVien;
GO
CREATE PROCEDURE SP_ThemNhanVien
    @Ma_Nhan_Vien CHAR(10), -- <<< THAM SỐ MỚI
    @Ten_Nhan_Vien NVARCHAR(100),
    @NgaySinh DATE,
    @GioiTinh NVARCHAR(10),
    @So_Dien_Thoai VARCHAR(20),
    @DiaChi NVARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra xem mã đã tồn tại chưa
    IF EXISTS (SELECT 1 FROM NHANVIEN WHERE Ma_Nhan_Vien = @Ma_Nhan_Vien)
    BEGIN
        -- Ném lỗi nếu mã đã tồn tại
        RAISERROR (N'Mã nhân viên này đã tồn tại. Vui lòng nhập mã khác.', 16, 1);
        RETURN; -- Dừng lại
    END

    -- Nếu mã hợp lệ, tiến hành THÊM
    INSERT INTO NHANVIEN (Ma_Nhan_Vien, Ten_Nhan_Vien, NgaySinh, GioiTinh, So_Dien_Thoai, DiaChi, TrangThai)
    VALUES (@Ma_Nhan_Vien, @Ten_Nhan_Vien, @NgaySinh, @GioiTinh, @So_Dien_Thoai, @DiaChi, 1);
END
GO

-- 3. SP SỬA THÔNG TIN NHÂN VIÊN
IF OBJECT_ID('SP_SuaNhanVien', 'P') IS NOT NULL
    DROP PROCEDURE SP_SuaNhanVien;
GO
CREATE PROCEDURE SP_SuaNhanVien
    @Ma_Nhan_Vien CHAR(10),
    @Ten_Nhan_Vien NVARCHAR(100),
    @NgaySinh DATE,
    @GioiTinh NVARCHAR(10),
    @So_Dien_Thoai VARCHAR(20),
    @DiaChi NVARCHAR(200)
AS
BEGIN
    UPDATE NHANVIEN
    SET 
        Ten_Nhan_Vien = @Ten_Nhan_Vien,
        NgaySinh = @NgaySinh,
        GioiTinh = @GioiTinh,
        So_Dien_Thoai = @So_Dien_Thoai,
        DiaChi = @DiaChi
    WHERE 
        Ma_Nhan_Vien = @Ma_Nhan_Vien;
END
GO

-- 4. SP XÓA NHÂN VIÊN (Cập nhật trạng thái nghỉ việc)
IF OBJECT_ID('SP_XoaNhanVien', 'P') IS NOT NULL
    DROP PROCEDURE SP_XoaNhanVien;
GO
CREATE PROCEDURE SP_XoaNhanVien
    @Ma_Nhan_Vien CHAR(10)
AS
BEGIN
    -- BƯỚC 1: Xóa tài khoản liên quan (nếu có)
    DELETE FROM TAIKHOAN 
    WHERE Ma_Nhan_Vien = @Ma_Nhan_Vien;

    -- BƯỚC 2: Cập nhật trạng thái "Đã nghỉ" cho nhân viên
    UPDATE NHANVIEN
    SET TrangThai = 0 
    WHERE Ma_Nhan_Vien = @Ma_Nhan_Vien;
END
GO

--------------------------------------------------------------
-- SP cho UCQLSach

-- 1. SP LẤY DANH SÁCH SÁCH (Quan trọng)
-- (Lấy cả Tên Thể Loại, Tên NCC để hiển thị, nhưng lấy ID để xử lý)
IF OBJECT_ID('SP_LayDanhSachSach', 'P') IS NOT NULL
    DROP PROCEDURE SP_LayDanhSachSach;
GO
CREATE PROCEDURE SP_LayDanhSachSach
AS
BEGIN
    SELECT 
        S.MaSach,
        S.TenSach,
        S.TacGia,
        S.Nha_Xuat_Ban,
        TL.Ten_TheLoai,     
        NCC.Ten_Nha_Cung_Cap, 
        S.GiaNhap,
        S.GiaBan,
        S.SoLuong,
        S.ID_TheLoai,         -- Lấy ID để xử lý CellClick
        S.Ma_Nha_Cung_Cap     -- Lấy ID để xử lý CellClick
    FROM SACH AS S
    JOIN THELOAI AS TL ON S.ID_TheLoai = TL.ID_TheLoai
    JOIN NHACUNGCAP AS NCC ON S.Ma_Nha_Cung_Cap = NCC.Ma_Nha_Cung_Cap;
END
GO

-- 2. SP LẤY DANH SÁCH THỂ LOẠI (Cho ComboBox)
IF OBJECT_ID('SP_LayDanhSachTheLoai', 'P') IS NOT NULL
    DROP PROCEDURE SP_LayDanhSachTheLoai;
GO
CREATE PROCEDURE SP_LayDanhSachTheLoai
AS
BEGIN
    SELECT ID_TheLoai, Ten_TheLoai FROM THELOAI;
END
GO

-- 3. SP LẤY DANH SÁCH NHÀ CUNG CẤP (Cho ComboBox)
IF OBJECT_ID('SP_LayDanhSachNhaCungCap', 'P') IS NOT NULL
    DROP PROCEDURE SP_LayDanhSachNhaCungCap;
GO
CREATE PROCEDURE SP_LayDanhSachNhaCungCap
AS
BEGIN
    SELECT Ma_Nha_Cung_Cap, Ten_Nha_Cung_Cap FROM NHACUNGCAP;
END
GO

-- 4. SP THÊM SÁCH MỚI (Cho phép nhập Số lượng)
IF OBJECT_ID('SP_ThemSach', 'P') IS NOT NULL
    DROP PROCEDURE SP_ThemSach;
GO
CREATE PROCEDURE SP_ThemSach
    @MaSach CHAR(10),
    @ID_TheLoai INT,
    @Ma_Nha_Cung_Cap CHAR(10),
    @TenSach NVARCHAR(100),
    @TacGia NVARCHAR(100),
    @Nha_Xuat_Ban NVARCHAR(100),
    @GiaNhap DECIMAL(18,0),
    @GiaBan DECIMAL(18,0),
    @SoLuong INT -- Cho phép nhập số lượng ban đầu
AS
BEGIN
    IF EXISTS (SELECT 1 FROM SACH WHERE MaSach = @MaSach)
    BEGIN
        RAISERROR(N'Mã sách này đã tồn tại.', 16, 1);
        RETURN;
    END
    
    INSERT INTO SACH (MaSach, ID_TheLoai, Ma_Nha_Cung_Cap, TenSach, TacGia, Nha_Xuat_Ban, GiaNhap, GiaBan, SoLuong)
    VALUES (@MaSach, @ID_TheLoai, @Ma_Nha_Cung_Cap, @TenSach, @TacGia, @Nha_Xuat_Ban, @GiaNhap, @GiaBan, @SoLuong);
END
GO

-- 5. SP SỬA SÁCH (KHÔNG cho sửa Số lượng)
IF OBJECT_ID('SP_SuaSach', 'P') IS NOT NULL
    DROP PROCEDURE SP_SuaSach;
GO
CREATE PROCEDURE SP_SuaSach
    @MaSach CHAR(10),
    @ID_TheLoai INT,
    @Ma_Nha_Cung_Cap CHAR(10),
    @TenSach NVARCHAR(100),
    @TacGia NVARCHAR(100),
    @Nha_Xuat_Ban NVARCHAR(100),
    @GiaNhap DECIMAL(18,0),
    @GiaBan DECIMAL(18,0)
    -- Không có @SoLuong, vì Số lượng chỉ được sửa qua Nhập/Bán
AS
BEGIN
    UPDATE SACH
    SET 
        ID_TheLoai = @ID_TheLoai,
        Ma_Nha_Cung_Cap = @Ma_Nha_Cung_Cap,
        TenSach = @TenSach,
        TacGia = @TacGia,
        Nha_Xuat_Ban = @Nha_Xuat_Ban,
        GiaNhap = @GiaNhap,
        GiaBan = @GiaBan
    WHERE 
        MaSach = @MaSach;
END
GO

-- 6. SP XÓA SÁCH
IF OBJECT_ID('SP_XoaSach', 'P') IS NOT NULL
    DROP PROCEDURE SP_XoaSach;
GO
CREATE PROCEDURE SP_XoaSach
    @MaSach CHAR(10)
AS
BEGIN
    -- Cảnh báo: Lệnh này sẽ thất bại nếu sách đã có trong CHITIETHOADON
    DELETE FROM SACH
    WHERE MaSach = @MaSach;
END
GO

--7. SP cho chức năng Tìm Kiếm Sách

IF OBJECT_ID('SP_TimKiemSach', 'P') IS NOT NULL
    DROP PROCEDURE SP_TimKiemSach;
GO

CREATE PROCEDURE SP_TimKiemSach
    @TuKhoa NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    
    SET @TuKhoa = N'%' + LTRIM(RTRIM(@TuKhoa)) + N'%';

    SELECT 
        S.MaSach,
        S.TenSach,
        S.TacGia,
        S.Nha_Xuat_Ban,
        S.GiaNhap,        
        S.GiaBan,
        S.SoLuong,
        TL.Ten_TheLoai,
        NCC.Ten_Nha_Cung_Cap,
        S.ID_TheLoai,      
        S.Ma_Nha_Cung_Cap 
    FROM SACH AS S
    JOIN THELOAI AS TL ON S.ID_TheLoai = TL.ID_TheLoai
    JOIN NHACUNGCAP AS NCC ON S.Ma_Nha_Cung_Cap = NCC.Ma_Nha_Cung_Cap
    WHERE
        S.TenSach LIKE @TuKhoa
        OR S.TacGia LIKE @TuKhoa
        OR S.MaSach LIKE @TuKhoa;
END;
GO

select * from SACH

--Quản lý khách hàng--

CREATE PROCEDURE SP_LayDanhSachKhachHang
AS
BEGIN
    SELECT * FROM KHACHHANG;
END
GO

-- 2. Thêm khách hàng
CREATE PROCEDURE SP_ThemKhachHang
    @Ma_Khach_Hang CHAR(10),
    @Ten_Khach_Hang NVARCHAR(100),
    @So_Dien_Thoai VARCHAR(20),
    @DiaChi NVARCHAR(200),
    @Email NVARCHAR(100)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM KHACHHANG WHERE Ma_Khach_Hang = @Ma_Khach_Hang)
    BEGIN
        RAISERROR(N'Mã khách hàng đã tồn tại.', 16, 1);
        RETURN;
    END
    INSERT INTO KHACHHANG VALUES (@Ma_Khach_Hang, @Ten_Khach_Hang, @So_Dien_Thoai, @DiaChi, @Email);
END
GO

CREATE PROCEDURE SP_SuaKhachHang
    @Ma_Khach_Hang CHAR(10),
    @Ten_Khach_Hang NVARCHAR(100),
    @So_Dien_Thoai VARCHAR(20),
    @DiaChi NVARCHAR(200),
    @Email NVARCHAR(100)
AS
BEGIN
    UPDATE KHACHHANG
    SET Ten_Khach_Hang = @Ten_Khach_Hang,
        So_Dien_Thoai = @So_Dien_Thoai,
        DiaChi = @DiaChi,
        Email = @Email
    WHERE Ma_Khach_Hang = @Ma_Khach_Hang;
END
GO

CREATE PROCEDURE SP_XoaKhachHang
    @Ma_Khach_Hang CHAR(10)
AS
BEGIN
    DELETE FROM KHACHHANG WHERE Ma_Khach_Hang = @Ma_Khach_Hang;
END
GO

CREATE PROCEDURE SP_TimKiemKhachHang
    @TuKhoa NVARCHAR(100)
AS
BEGIN
    SELECT * FROM KHACHHANG
    WHERE Ten_Khach_Hang LIKE N'%' + @TuKhoa + N'%'
       OR So_Dien_Thoai LIKE N'%' + @TuKhoa + N'%'
       OR Ma_Khach_Hang LIKE N'%' + @TuKhoa + N'%';
END
GO

----------------------------
--SP cho UCThongKe

-- 1. SP TỔNG HỢP TÀI CHÍNH
IF OBJECT_ID('SP_BaoCaoTaiChinh', 'P') IS NOT NULL
    DROP PROCEDURE SP_BaoCaoTaiChinh;
GO
CREATE PROCEDURE SP_BaoCaoTaiChinh
    @TuNgay DATE,
    @DenNgay DATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Bước 1: Lấy tất cả các ngày có giao dịch (Bán hoặc Nhập)
    SELECT DISTINCT Ngay GiaoDich
    INTO #DanhSachNgay
    FROM (
        SELECT NgayLap AS Ngay FROM HOADON WHERE NgayLap BETWEEN @TuNgay AND @DenNgay
        UNION
        SELECT NgayNhap AS Ngay FROM PHIEUNHAPHANG WHERE NgayNhap BETWEEN @TuNgay AND @DenNgay
    ) AS AllDates;

    -- Bước 2: Kết hợp dữ liệu Bán (Thu) và Nhập (Chi) theo từng ngày
    SELECT 
        D.GiaoDich AS Ngay,
        ISNULL(SUM(H.TongTien), 0) AS DoanhThu,      -- Tổng tiền bán sách
        ISNULL(SUM(P.TongTienNhap), 0) AS ChiPhi,    -- Tổng tiền nhập sách
        ISNULL(SUM(H.TongTien), 0) - ISNULL(SUM(P.TongTienNhap), 0) AS LoiNhuan
    FROM #DanhSachNgay D
    LEFT JOIN HOADON H ON D.GiaoDich = H.NgayLap
    LEFT JOIN PHIEUNHAPHANG P ON D.GiaoDich = P.NgayNhap
    GROUP BY D.GiaoDich
    ORDER BY D.GiaoDich ASC;

    -- Dọn dẹp bảng tạm
    DROP TABLE #DanhSachNgay;
END
GO

