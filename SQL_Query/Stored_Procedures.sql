USE NhaSach;
GO

-- === 1. BACKUP & RESTORE ===
CREATE OR ALTER PROCEDURE SP_BackupDatabase
    @DuongDan NVARCHAR(500)
AS
BEGIN
    -- Tạo tên file backup theo ngày giờ để không bị trùng
    DECLARE @TenFile NVARCHAR(500);
    SET @TenFile = @DuongDan + '\NhaSach_' + CONVERT(VARCHAR(20), GETDATE(), 112) + '.bak';
    
    BACKUP DATABASE NhaSach TO DISK = @TenFile WITH FORMAT, NAME = 'Full Backup';
END
GO

USE master; -- Đổi sang database hệ thống master
GO

CREATE OR ALTER PROCEDURE SP_RestoreNhaSach
    @DuongDan NVARCHAR(500)
AS
BEGIN
    -- 1. Ngắt kết nối cũ
    ALTER DATABASE NhaSach SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    
    -- 2. Restore đè lên
    RESTORE DATABASE NhaSach FROM DISK = @DuongDan WITH REPLACE;
    
    -- 3. Mở lại kết nối
    ALTER DATABASE NhaSach SET MULTI_USER;
END
GO

USE NhaSach;
GO

-- === 2. BÁO CÁO DOANH THU ===
CREATE OR ALTER PROCEDURE SP_BaoCaoTaiChinh
    @NgayBatDau DATE,
    @NgayKetThuc DATE
AS
BEGIN
    -- LỚP BẢO VỆ NGÀY: Tính ngày kết thúc TỚI CUỐI GIÂY CUỐI CÙNG (bằng cách dùng < ngày tiếp theo)
    DECLARE @NgayKetThucInclusive DATETIME = DATEADD(day, 1, @NgayKetThuc);
    
    -- 1. TÍNH TỔNG GIÁ VỐN
    DECLARE @TongGiaVon DECIMAL(18, 2);
    SELECT @TongGiaVon = SUM(ISNULL(CTPN.SoLuongNhap, 0) * ISNULL(CTPN.DonGiaNhap, 0))
    FROM PHIEUNHAPHANG PN
    JOIN CHITIETPHIEUNHAP CTPN ON PN.MaPhieuNhap = CTPN.MaPhieuNhap
    WHERE PN.NgayNhap >= @NgayBatDau 
      AND PN.NgayNhap < @NgayKetThucInclusive -- Bao trọn ngày cuối
      AND PN.TrangThai = 1;

    -- 2. TÍNH TỔNG DOANH THU
    DECLARE @TongDoanhThu DECIMAL(18, 2);
    SELECT @TongDoanhThu = SUM(ISNULL(CTHD.SoLuong, 0) * ISNULL(CTHD.DonGia, 0))
    FROM HOADON HD
    JOIN CHITIETHOADON CTHD ON HD.Ma_Hoa_Don = CTHD.Ma_Hoa_Don
    WHERE HD.NgayLap >= @NgayBatDau 
      AND HD.NgayLap < @NgayKetThucInclusive -- Bao trọn ngày cuối
      AND HD.TrangThai = 1;

    -- 3. TÍNH LỢI NHUẬN GỘP
    DECLARE @LoiNhuanGop DECIMAL(18, 2);
    SET @LoiNhuanGop = ISNULL(@TongDoanhThu, 0) - ISNULL(@TongGiaVon, 0);

    -- 4. TRẢ KẾT QUẢ VỀ
    SELECT 
        ISNULL(@TongDoanhThu, 0) AS TongDoanhThu, 
        ISNULL(@TongGiaVon, 0) AS TongGiaVon, 
        @LoiNhuanGop AS LoiNhuanGop;
END
GO

-- === 3. CÁC THỦ TỤC QUẢN LÝ (CRUD - Có xóa mềm) ===

-- Lấy Sách (Chỉ lấy sách đang hoạt động)
CREATE OR ALTER PROCEDURE SP_LayDanhSachSach
AS
BEGIN
    -- Thêm S.TrangThai vào danh sách SELECT
    SELECT S.MaSach, S.TenSach, TL.Ten_TheLoai, S.TacGia, S.Nha_Xuat_Ban, 
           S.GiaNhap, S.GiaBan, S.SoLuong, S.HinhAnh, S.ID_TheLoai,
           S.TrangThai -- <--- LẤY CỘT NÀY LÊN
    FROM SACH S 
    JOIN THELOAI TL ON S.ID_TheLoai = TL.ID_TheLoai
    WHERE S.TrangThai = 1;
END
GO

-- Thêm Sách
CREATE OR ALTER PROCEDURE SP_ThemSach
    @MaSach CHAR(10), @ID_TheLoai INT, @TenSach NVARCHAR(100), @TacGia NVARCHAR(100),
    @Nha_Xuat_Ban NVARCHAR(100), @GiaNhap DECIMAL(18,0), @GiaBan DECIMAL(18,0), 
    @SoLuong INT, @HinhAnh NVARCHAR(500)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM SACH WHERE MaSach = @MaSach)
        THROW 50001, N'Mã sách đã tồn tại!', 1;
    INSERT INTO SACH (MaSach, ID_TheLoai, TenSach, TacGia, Nha_Xuat_Ban, GiaNhap, GiaBan, SoLuong, HinhAnh, TrangThai)
    VALUES (@MaSach, @ID_TheLoai, @TenSach, @TacGia, @Nha_Xuat_Ban, @GiaNhap, @GiaBan, @SoLuong, @HinhAnh, 1);
END
GO

-- Sửa Sách
CREATE OR ALTER PROCEDURE SP_SuaSach
    @MaSach CHAR(10), @ID_TheLoai INT, @TenSach NVARCHAR(100), @TacGia NVARCHAR(100),
    @Nha_Xuat_Ban NVARCHAR(100), @GiaNhap DECIMAL(18,0), @GiaBan DECIMAL(18,0), @HinhAnh NVARCHAR(500)
AS
BEGIN
    UPDATE SACH 
    SET ID_TheLoai = @ID_TheLoai, TenSach = @TenSach, TacGia = @TacGia, 
        Nha_Xuat_Ban = @Nha_Xuat_Ban, GiaNhap = @GiaNhap, GiaBan = @GiaBan, HinhAnh = @HinhAnh
    WHERE MaSach = @MaSach;
END
GO

-- Xóa Sách (Xóa mềm)
CREATE OR ALTER PROCEDURE SP_XoaSach @MaSach CHAR(10)
AS
BEGIN
    UPDATE SACH SET TrangThai = 0 WHERE MaSach = @MaSach;
END
GO

-- Tìm kiếm Sách
CREATE OR ALTER PROCEDURE SP_TimKiemSach @TuKhoa NVARCHAR(100)
AS
BEGIN
    SET @TuKhoa = N'%' + @TuKhoa + N'%';
    SELECT S.*, TL.Ten_TheLoai 
    FROM SACH S JOIN THELOAI TL ON S.ID_TheLoai = TL.ID_TheLoai
    WHERE S.TrangThai = 1 
      AND (S.TenSach LIKE @TuKhoa OR S.MaSach LIKE @TuKhoa OR S.TacGia LIKE @TuKhoa);
END
GO

-- Đăng nhập
CREATE OR ALTER PROCEDURE SP_DangNhap
    @TenDangNhap VARCHAR(50), @MatKhau VARCHAR(100)
AS
BEGIN
    SELECT TK.*, NV.Ten_Nhan_Vien 
    FROM TAIKHOAN TK JOIN NHANVIEN NV ON TK.Ma_Nhan_Vien = NV.Ma_Nhan_Vien
    WHERE TK.TenDangNhap = @TenDangNhap AND TK.MatKhau = @MatKhau AND TK.TrangThai = 1;
END
GO

CREATE OR ALTER PROCEDURE SP_LaySachTheoNhaCungCap
    @MaNCC CHAR(10)
AS
BEGIN
    -- 1. Lấy tên của Nhà Cung Cấp từ mã
    DECLARE @TenNCC NVARCHAR(100);
    SELECT @TenNCC = Ten_Nha_Cung_Cap FROM NHACUNGCAP WHERE Ma_Nha_Cung_Cap = @MaNCC;

    -- 2. Tìm các cuốn sách có Nha_Xuat_Ban GẦN GIỐNG với tên NCC
    -- (Dùng LIKE để tìm tương đối, ví dụ NCC là "NXB Trẻ" thì tìm sách có NXB chứa chữ "Trẻ")
    SELECT * FROM SACH 
    WHERE Nha_Xuat_Ban LIKE N'%' + @TenNCC + N'%' 
      AND TrangThai = 1;
END
GO

-- Lấy danh sách Nhân viên
CREATE OR ALTER PROCEDURE SP_LayDanhSachNhanVien
AS
BEGIN
    SELECT 
        N.Ma_Nhan_Vien,
        N.Ten_Nhan_Vien,
        N.NgaySinh,
        N.GioiTinh,
        N.So_Dien_Thoai,
        N.DiaChi,
        -- Cột trạng thái tài khoản
        CASE 
            WHEN T.TenDangNhap IS NOT NULL THEN N'Đã có' 
            ELSE N'Chưa có' 
        END AS TinhTrangTaiKhoan,
        -- === CỘT QUYỀN (ROLE) ===
        T.Quyen 
    FROM 
        NHANVIEN AS N
    LEFT JOIN 
        TAIKHOAN AS T ON N.Ma_Nhan_Vien = T.Ma_Nhan_Vien
    WHERE
        N.TrangThai = 1; 
END
GO

-- Thêm Nhân viên
CREATE OR ALTER PROCEDURE SP_ThemNhanVien
    @Ma_Nhan_Vien CHAR(10),
    @Ten_Nhan_Vien NVARCHAR(100),
    @NgaySinh DATE,
    @GioiTinh NVARCHAR(10),
    @So_Dien_Thoai VARCHAR(20),
    @DiaChi NVARCHAR(200)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM NHANVIEN WHERE Ma_Nhan_Vien = @Ma_Nhan_Vien)
        THROW 50001, N'Mã nhân viên đã tồn tại!', 1;

    INSERT INTO NHANVIEN (Ma_Nhan_Vien, Ten_Nhan_Vien, NgaySinh, GioiTinh, So_Dien_Thoai, DiaChi, TrangThai)
    VALUES (@Ma_Nhan_Vien, @Ten_Nhan_Vien, @NgaySinh, @GioiTinh, @So_Dien_Thoai, @DiaChi, 1);
END
GO

-- Sửa Nhân viên
CREATE OR ALTER PROCEDURE SP_SuaNhanVien
    @Ma_Nhan_Vien CHAR(10),
    @Ten_Nhan_Vien NVARCHAR(100),
    @NgaySinh DATE,
    @GioiTinh NVARCHAR(10),
    @So_Dien_Thoai VARCHAR(20),
    @DiaChi NVARCHAR(200)
AS
BEGIN
    UPDATE NHANVIEN
    SET Ten_Nhan_Vien = @Ten_Nhan_Vien,
        NgaySinh = @NgaySinh,
        GioiTinh = @GioiTinh,
        So_Dien_Thoai = @So_Dien_Thoai,
        DiaChi = @DiaChi
    WHERE Ma_Nhan_Vien = @Ma_Nhan_Vien;
END
GO

-- Xóa Nhân viên (Xóa mềm)
CREATE OR ALTER PROCEDURE SP_XoaNhanVien
    @Ma_Nhan_Vien CHAR(10)
AS
BEGIN
    -- LỚP BẢO VỆ SERVER-SIDE: Chặn xóa hồ sơ Admin Gốc (NV001)
    IF @Ma_Nhan_Vien = 'NV001'
    BEGIN
        THROW 50002, N'LỖI BẢO MẬT: Hồ sơ Quản trị viên Gốc (NV001) không thể bị xóa!', 1;
        RETURN;
    END

    -- Xóa tài khoản liên quan trước (đã được bảo vệ ở trên)
    DELETE FROM TAIKHOAN WHERE Ma_Nhan_Vien = @Ma_Nhan_Vien;
    
    -- Cập nhật trạng thái nghỉ việc
    UPDATE NHANVIEN SET TrangThai = 0 WHERE Ma_Nhan_Vien = @Ma_Nhan_Vien;
END
GO

CREATE OR ALTER PROCEDURE SP_TaoTaiKhoan
    @TenDangNhap VARCHAR(50),
    @MatKhau VARCHAR(100),
    @Ma_Nhan_Vien CHAR(10),
    @Quyen VARCHAR(20)
AS
BEGIN
    -- 1. Kiểm tra xem Tên đăng nhập đã có người dùng chưa
    IF EXISTS (SELECT 1 FROM TAIKHOAN WHERE TenDangNhap = @TenDangNhap)
    BEGIN
        THROW 50001, N'Tên đăng nhập này đã tồn tại. Vui lòng chọn tên khác!', 1;
    END

    -- 2. Kiểm tra xem Nhân viên này đã có tài khoản chưa (Mỗi NV chỉ 1 TK)
    IF EXISTS (SELECT 1 FROM TAIKHOAN WHERE Ma_Nhan_Vien = @Ma_Nhan_Vien)
    BEGIN
        THROW 50001, N'Nhân viên này đã được cấp tài khoản rồi!', 1;
    END

    -- 3. Nếu ổn thì Thêm mới
    INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, Ma_Nhan_Vien, Quyen, TrangThai)
    VALUES (@TenDangNhap, @MatKhau, @Ma_Nhan_Vien, @Quyen, 1);
END
GO

-- Thủ tục Xóa riêng Tài khoản (Thu hồi quyền truy cập)
CREATE OR ALTER PROCEDURE SP_XoaTaiKhoanTheoMaNV
    @Ma_Nhan_Vien CHAR(10)
AS
BEGIN
    -- LỚP BẢO VỆ SERVER-SIDE: Chặn xóa Admin Gốc (NV001)
    IF @Ma_Nhan_Vien = 'NV001'
    BEGIN
        THROW 50002, N'LỖI BẢO MẬT: Tài khoản Quản trị viên Gốc (NV001) không thể bị thu hồi quyền truy cập!', 1;
        RETURN;
    END

    -- Nếu không phải Admin Gốc thì xóa
    DELETE FROM TAIKHOAN WHERE Ma_Nhan_Vien = @Ma_Nhan_Vien;
END
GO

-- Lấy danh sách Khách hàng
CREATE OR ALTER PROCEDURE SP_LayDanhSachKhachHang
AS
BEGIN
    SELECT * FROM KHACHHANG WHERE TrangThai = 1;
END
GO

-- Thêm Khách hàng
CREATE OR ALTER PROCEDURE SP_ThemKhachHang
    @Ma_Khach_Hang CHAR(10),
    @Ten_Khach_Hang NVARCHAR(100),
    @So_Dien_Thoai VARCHAR(20),
    @DiaChi NVARCHAR(200),
    @Email VARCHAR(100)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM KHACHHANG WHERE Ma_Khach_Hang = @Ma_Khach_Hang)
        THROW 50001, N'Mã khách hàng đã tồn tại!', 1;

    INSERT INTO KHACHHANG (Ma_Khach_Hang, Ten_Khach_Hang, So_Dien_Thoai, DiaChi, Email, TrangThai)
    VALUES (@Ma_Khach_Hang, @Ten_Khach_Hang, @So_Dien_Thoai, @DiaChi, @Email, 1);
END
GO

-- Sửa Khách hàng
CREATE OR ALTER PROCEDURE SP_SuaKhachHang
    @Ma_Khach_Hang CHAR(10),
    @Ten_Khach_Hang NVARCHAR(100),
    @So_Dien_Thoai VARCHAR(20),
    @DiaChi NVARCHAR(200),
    @Email VARCHAR(100)
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

-- Xóa Khách hàng (Xóa mềm)
CREATE OR ALTER PROCEDURE SP_XoaKhachHang
    @Ma_Khach_Hang CHAR(10)
AS
BEGIN
    UPDATE KHACHHANG SET TrangThai = 0 WHERE Ma_Khach_Hang = @Ma_Khach_Hang;
END
GO

CREATE OR ALTER PROCEDURE SP_BaoCaoChiTietDoanhThu
    @NgayBatDau DATE,
    @NgayKetThuc DATE
AS
BEGIN
    DECLARE @NgayKetThucInclusive DATETIME = DATEADD(day, 1, @NgayKetThuc);
    
    -- Trả về tổng doanh thu theo từng ngày
    SELECT 
        CAST(HD.NgayLap AS DATE) AS Ngay,
        SUM(CTHD.SoLuong * CTHD.DonGia) AS DoanhThuNgay
    FROM 
        HOADON HD
    JOIN 
        CHITIETHOADON CTHD ON HD.Ma_Hoa_Don = CTHD.Ma_Hoa_Don
    WHERE 
        HD.NgayLap >= @NgayBatDau 
        AND HD.NgayLap < @NgayKetThucInclusive 
        AND HD.TrangThai = 1
    GROUP BY 
        CAST(HD.NgayLap AS DATE)
    ORDER BY 
        Ngay;
END
GO

CREATE OR ALTER PROCEDURE SP_LayDanhSachHoaDonTheoNgay
    @NgayBatDau DATE,
    @NgayKetThuc DATE
AS
BEGIN
    DECLARE @NgayKetThucInclusive DATETIME = DATEADD(day, 1, @NgayKetThuc);
    
    SELECT 
        HD.Ma_Hoa_Don,
        HD.NgayLap,
        NV.Ten_Nhan_Vien,
        KH.Ten_Khach_Hang,
        S.TenSach,
        CTHD.SoLuong,
        CTHD.DonGia AS GiaBan,
        (CTHD.SoLuong * CTHD.DonGia) AS ThanhTien
    FROM HOADON HD
    JOIN CHITIETHOADON CTHD ON HD.Ma_Hoa_Don = CTHD.Ma_Hoa_Don
    JOIN NHANVIEN NV ON HD.Ma_Nhan_Vien = NV.Ma_Nhan_Vien
    LEFT JOIN KHACHHANG KH ON HD.Ma_Khach_Hang = KH.Ma_Khach_Hang
    JOIN SACH S ON CTHD.MaSach = S.MaSach
    WHERE HD.NgayLap >= @NgayBatDau AND HD.NgayLap < @NgayKetThucInclusive
    ORDER BY HD.NgayLap DESC;
END
GO

CREATE OR ALTER PROCEDURE SP_LayDanhSachPhieuNhapTheoNgay
    @NgayBatDau DATE,
    @NgayKetThuc DATE
AS
BEGIN
    DECLARE @NgayKetThucInclusive DATETIME = DATEADD(day, 1, @NgayKetThuc);

    SELECT
        PN.MaPhieuNhap,
        PN.NgayNhap,
        NV.Ten_Nhan_Vien,
        NCC.Ten_Nha_Cung_Cap,
        S.TenSach,
        CTPN.SoLuongNhap,
        CTPN.DonGiaNhap,
        (CTPN.SoLuongNhap * CTPN.DonGiaNhap) AS TongChiPhi
    FROM PHIEUNHAPHANG PN
    JOIN CHITIETPHIEUNHAP CTPN ON PN.MaPhieuNhap = CTPN.MaPhieuNhap
    JOIN NHANVIEN NV ON PN.Ma_Nhan_Vien = NV.Ma_Nhan_Vien
    JOIN NHACUNGCAP NCC ON PN.Ma_Nha_Cung_Cap = NCC.Ma_Nha_Cung_Cap
    JOIN SACH S ON CTPN.MaSach = S.MaSach
    WHERE PN.NgayNhap >= @NgayBatDau AND PN.NgayNhap < @NgayKetThucInclusive
    ORDER BY PN.NgayNhap DESC;
END
GO

CREATE OR ALTER PROCEDURE SP_BaoCaoChiTietTaiChinh
    @NgayBatDau DATE,
    @NgayKetThuc DATE
AS
BEGIN
    DECLARE @NgayKetThucInclusive DATETIME = DATEADD(day, 1, @NgayKetThuc);
    
    -- 1. Tính Doanh thu (Sales) theo ngày
    SELECT 
        CAST(HD.NgayLap AS DATE) AS Ngay,
        SUM(CTHD.SoLuong * CTHD.DonGia) AS TongTien
    INTO #DoanhThu
    FROM HOADON HD
    JOIN CHITIETHOADON CTHD ON HD.Ma_Hoa_Don = CTHD.Ma_Hoa_Don
    WHERE HD.NgayLap >= @NgayBatDau AND HD.NgayLap < @NgayKetThucInclusive AND HD.TrangThai = 1
    GROUP BY CAST(HD.NgayLap AS DATE);
    
    -- 2. Tính Giá vốn (Cost) theo ngày
    SELECT 
        CAST(PN.NgayNhap AS DATE) AS Ngay,
        SUM(CTPN.SoLuongNhap * CTPN.DonGiaNhap) AS TongTien
    INTO #GiaVon
    FROM PHIEUNHAPHANG PN
    JOIN CHITIETPHIEUNHAP CTPN ON PN.MaPhieuNhap = CTPN.MaPhieuNhap
    WHERE PN.NgayNhap >= @NgayBatDau AND PN.NgayNhap < @NgayKetThucInclusive AND PN.TrangThai = 1
    GROUP BY CAST(PN.NgayNhap AS DATE);

    -- 3. Kết hợp kết quả (FULL OUTER JOIN để không bỏ sót ngày chỉ có Nhập hoặc chỉ có Bán)
    SELECT 
        ISNULL(DT.Ngay, GV.Ngay) AS NgayBaoCao,
        ISNULL(DT.TongTien, 0) AS DoanhThuNgay,
        ISNULL(GV.TongTien, 0) AS GiaVonNgay,
        (ISNULL(DT.TongTien, 0) - ISNULL(GV.TongTien, 0)) AS LoiNhuanNgay
    FROM #DoanhThu DT
    FULL OUTER JOIN #GiaVon GV ON DT.Ngay = GV.Ngay
    ORDER BY NgayBaoCao;

    DROP TABLE #DoanhThu;
    DROP TABLE #GiaVon;
END
GO

-- THỦ TỤC ĐỔI MẬT KHẨU
CREATE OR ALTER PROCEDURE SP_DoiMatKhau
    @TenDangNhap VARCHAR(50),
    @MatKhauCu VARCHAR(100),
    @MatKhauMoi VARCHAR(100)
AS
BEGIN
    -- 1. Xác thực mật khẩu cũ
    IF NOT EXISTS (SELECT 1 FROM TAIKHOAN WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhauCu)
    BEGIN
        THROW 50001, N'Mật khẩu cũ không chính xác!', 1;
        RETURN;
    END

    -- 2. Cập nhật mật khẩu mới
    UPDATE TAIKHOAN
    SET MatKhau = @MatKhauMoi
    WHERE TenDangNhap = @TenDangNhap;
END
GO

CREATE OR ALTER PROCEDURE SP_DangNhap
    @TenDangNhap VARCHAR(50),
    @MatKhau VARCHAR(100)
AS
BEGIN
    SELECT 
        TK.Ma_Nhan_Vien, 
        NV.Ten_Nhan_Vien,
        TK.Quyen
    FROM 
        TAIKHOAN TK
    JOIN 
        NHANVIEN NV ON TK.Ma_Nhan_Vien = NV.Ma_Nhan_Vien
    WHERE 
        TK.TenDangNhap = @TenDangNhap 
        AND TK.MatKhau = @MatKhau;
END
GO

CREATE OR ALTER PROCEDURE SP_LayChiTietHoaDon
    @Ma_Hoa_Don CHAR(10)
AS
BEGIN
    -- Lấy thông tin Header và Details
    SELECT 
        HD.Ma_Hoa_Don,
        HD.NgayLap,
        NV.Ten_Nhan_Vien AS NguoiLap,
        ISNULL(KH.Ten_Khach_Hang, N'Khách lẻ') AS TenKhachHang,
        -- Chi tiết sản phẩm
        S.TenSach,
        CTHD.SoLuong,
        CTHD.DonGia AS GiaBan,
        (CTHD.SoLuong * CTHD.DonGia) AS ThanhTien
    FROM HOADON HD
    JOIN CHITIETHOADON CTHD ON HD.Ma_Hoa_Don = CTHD.Ma_Hoa_Don
    JOIN NHANVIEN NV ON HD.Ma_Nhan_Vien = NV.Ma_Nhan_Vien
    LEFT JOIN KHACHHANG KH ON HD.Ma_Khach_Hang = KH.Ma_Khach_Hang
    JOIN SACH S ON CTHD.MaSach = S.MaSach
    WHERE HD.Ma_Hoa_Don = @Ma_Hoa_Don;
END
GO

CREATE OR ALTER PROCEDURE SP_LayLichSuMuaHang
    @Ma_Khach_Hang CHAR(10)
AS
BEGIN
    SELECT 
        HD.Ma_Hoa_Don AS [Mã HĐ],
        HD.NgayLap AS [Ngày Lập],
        S.TenSach AS [Tên Sách],
        CTHD.SoLuong AS [SL],
        CTHD.DonGia AS [Đơn Giá],
        (CTHD.SoLuong * CTHD.DonGia) AS [Thành Tiền]
    FROM HOADON HD
    JOIN CHITIETHOADON CTHD ON HD.Ma_Hoa_Don = CTHD.Ma_Hoa_Don
    JOIN SACH S ON CTHD.MaSach = S.MaSach
    WHERE HD.Ma_Khach_Hang = @Ma_Khach_Hang 
      AND HD.TrangThai = 1
    ORDER BY HD.NgayLap DESC;
END
GO

CREATE OR ALTER PROCEDURE SP_LayThongTinHoaDon_DeIn
    @MaHoaDon VARCHAR(20)
AS
BEGIN
    SELECT 
        H.NgayLap,
        NV.Ten_Nhan_Vien,
        KH.Ten_Khach_Hang
    FROM HOADON H
    JOIN NHANVIEN NV ON H.Ma_Nhan_Vien = NV.Ma_Nhan_Vien
    JOIN KHACHHANG KH ON H.Ma_Khach_Hang = KH.Ma_Khach_Hang
    WHERE H.Ma_Hoa_Don = @MaHoaDon
END
GO

CREATE OR ALTER PROCEDURE SP_LayChiTietHoaDon_DeIn
    @MaHoaDon VARCHAR(20)
AS
BEGIN
    SELECT 
        S.TenSach,
        CT.SoLuong,
        CT.DonGia,
        (CT.SoLuong * CT.DonGia) AS ThanhTien
    FROM CHITIETHOADON CT
    JOIN SACH S ON CT.MaSach = S.MaSach
    WHERE CT.Ma_Hoa_Don = @MaHoaDon
END

CREATE OR ALTER PROCEDURE SP_LayThongTinPhieuNhap_DeIn
    @MaPhieuNhap VARCHAR(20)
AS
BEGIN
    SELECT 
        PN.NgayNhap,
        ISNULL(NV.Ten_Nhan_Vien, N'Không xác định') AS Ten_Nhan_Vien,
        ISNULL(NCC.Ten_Nha_Cung_Cap, N'NCC Vãng lai') AS Ten_Nha_Cung_Cap
    FROM PHIEUNHAPHANG PN
    LEFT JOIN NHANVIEN NV ON PN.Ma_Nhan_Vien = NV.Ma_Nhan_Vien
    LEFT JOIN NHACUNGCAP NCC ON PN.Ma_Nha_Cung_Cap = NCC.Ma_Nha_Cung_Cap
    WHERE PN.MaPhieuNhap = @MaPhieuNhap
END
GO

CREATE OR ALTER PROCEDURE SP_LayChiTietPhieuNhap_DeIn
    @MaPhieuNhap VARCHAR(20)
AS
BEGIN
    SELECT 
        S.TenSach,
        CT.SoLuongNhap,
        CT.DonGiaNhap,
        (CT.SoLuongNhap * CT.DonGiaNhap) AS ThanhTien
    FROM CHITIETPHIEUNHAP CT
    JOIN SACH S ON CT.MaSach = S.MaSach
    WHERE CT.MaPhieuNhap = @MaPhieuNhap
END
GO
