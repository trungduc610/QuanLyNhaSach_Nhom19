CREATE DATABASE NhaSach;
GO

USE NhaSach;
GO

-- Bảng thể loại sách
CREATE TABLE THELOAI(
    ID_TheLoai INT IDENTITY(1,1) PRIMARY KEY,
    Ten_TheLoai NVARCHAR(100) NOT NULL
);

-- Bảng nhà cung cấp
CREATE TABLE NHACUNGCAP(
    Ma_Nha_Cung_Cap CHAR(10) PRIMARY KEY NOT NULL,
    Ten_Nha_Cung_Cap NVARCHAR(100) NOT NULL,
    DiaChi NVARCHAR(200),
    So_Dien_Thoai VARCHAR(20),
    Email NVARCHAR(100)
);

-- Bảng sách
CREATE TABLE SACH(
    MaSach CHAR(10) PRIMARY KEY NOT NULL,
    ID_TheLoai INT NOT NULL,
    Ma_Nha_Cung_Cap CHAR(10) NOT NULL,
    TenSach NVARCHAR(100) NOT NULL,
    TacGia NVARCHAR(100),
    Nha_Xuat_Ban NVARCHAR(100),
    Nam_Xuat_Ban INT,
    GiaNhap DECIMAL(18,0) DEFAULT 0, -- Thêm giá nhập
    GiaBan DECIMAL(18,0) DEFAULT 0,  -- Đổi sang (18,0) cho VNĐ
    SoLuong INT NOT NULL DEFAULT 0,

    CONSTRAINT FK_Sach_TheLoai FOREIGN KEY(ID_TheLoai) 
        REFERENCES THELOAI(ID_TheLoai),
    CONSTRAINT FK_Sach_NhaCungCap FOREIGN KEY(Ma_Nha_Cung_Cap) 
        REFERENCES NHACUNGCAP(Ma_Nha_Cung_Cap)
);

--Bảng khách hàng
CREATE TABLE KHACHHANG(
    Ma_Khach_Hang CHAR(10) PRIMARY KEY NOT NULL,
    Ten_Khach_Hang NVARCHAR(100) NOT NULL,
    So_Dien_Thoai VARCHAR(20),
    DiaChi NVARCHAR(200),
    Email NVARCHAR(100)
);

-- Bảng nhân viên
CREATE TABLE NHANVIEN(
    Ma_Nhan_Vien CHAR(10) PRIMARY KEY NOT NULL,
    Ten_Nhan_Vien NVARCHAR(100) NOT NULL,
    NgaySinh DATE,
    GioiTinh NVARCHAR(10),
    So_Dien_Thoai VARCHAR(20),
    DiaChi NVARCHAR(200),
    TrangThai BIT DEFAULT 1 -- 1 = Đang làm, 0 = Đã nghỉ
);

-- Bảng tài khoản
CREATE TABLE TAIKHOAN(
    TenDangNhap VARCHAR(50) PRIMARY KEY NOT NULL,
    MatKhau VARCHAR(50) NOT NULL,
    Ma_Nhan_Vien CHAR(10) NOT NULL UNIQUE, -- Liên kết 1-1 với Nhân viên
    Quyen VARCHAR(20) NOT NULL DEFAULT 'NhanVien', -- 'Admin' hoặc 'NhanVien'
    NgayTao DATE DEFAULT GETDATE(),

    CONSTRAINT FK_TaiKhoan_NhanVien FOREIGN KEY(Ma_Nhan_Vien)
        REFERENCES NHANVIEN(Ma_Nhan_Vien),
    CONSTRAINT CHK_Quyen CHECK (Quyen IN ('Admin', 'NhanVien'))
);

-- Bảng hóa đơn
CREATE TABLE HOADON(
    Ma_Hoa_Don CHAR(10) PRIMARY KEY NOT NULL,
    Ma_Nhan_Vien CHAR(10) NOT NULL,
    Ma_Khach_Hang CHAR(10) NOT NULL,
    NgayLap DATE NOT NULL,
    NgayTao DATETIME DEFAULT GETDATE(), -- Thêm ngày giờ tạo chính xác
    TongTien DECIMAL(18,0) DEFAULT 0,

    CONSTRAINT FK_HoaDon_NhanVien FOREIGN KEY(Ma_Nhan_Vien) 
        REFERENCES NHANVIEN(Ma_Nhan_Vien),
    CONSTRAINT FK_HoaDon_KhachHang FOREIGN KEY(Ma_Khach_Hang) 
        REFERENCES KHACHHANG(Ma_Khach_Hang)
);

-- Bảng chi tiết hóa đơn
CREATE TABLE CHITIETHOADON(
    Ma_Hoa_Don CHAR(10) NOT NULL,
    MaSach CHAR(10) NOT NULL,
    SoLuong INT,
    DonGia DECIMAL(18,0) DEFAULT 0, -- Thêm cột DonGia (snapshot giá)
    ThanhTien DECIMAL(18,0) DEFAULT 0,

    PRIMARY KEY(Ma_Hoa_Don,MaSach),
    CONSTRAINT FK_ChiTietHoaDon_HoaDon FOREIGN KEY (Ma_Hoa_Don) 
        REFERENCES HOADON(Ma_Hoa_Don) ON DELETE CASCADE, -- Nếu xóa Hóa đơn thì xóa luôn chi tiết
    CONSTRAINT FK_ChiTietHoaDon_Sach FOREIGN KEY (MaSach) 
        REFERENCES SACH(MaSach)
);
GO

-- Bảng Phiếu Nhập Hàng
CREATE TABLE PHIEUNHAPHANG (
    MaPhieuNhap CHAR(10) PRIMARY KEY NOT NULL,
    Ma_Nhan_Vien CHAR(10) NOT NULL,
    Ma_Nha_Cung_Cap CHAR(10) NOT NULL,
    NgayNhap DATETIME DEFAULT GETDATE(),
    TongTienNhap DECIMAL(18,0) DEFAULT 0,

    CONSTRAINT FK_PhieuNhap_NhanVien FOREIGN KEY (Ma_Nhan_Vien)
        REFERENCES NHANVIEN(Ma_Nhan_Vien),
    CONSTRAINT FK_PhieuNhap_NhaCungCap FOREIGN KEY (Ma_Nha_Cung_Cap)
        REFERENCES NHACUNGCAP(Ma_Nha_Cung_Cap)
);

-- Bảng Chi Tiết Phiếu Nhập
CREATE TABLE CHITIETPHIEUNHAP (
    MaPhieuNhap CHAR(10) NOT NULL,
    MaSach CHAR(10) NOT NULL,
    SoLuongNhap INT NOT NULL,
    DonGiaNhap DECIMAL(18,0) NOT NULL,
    ThanhTienNhap DECIMAL(18,0) DEFAULT 0,

    PRIMARY KEY (MaPhieuNhap, MaSach),
    CONSTRAINT FK_CTPhieuNhap_PhieuNhap FOREIGN KEY (MaPhieuNhap)
        REFERENCES PHIEUNHAPHANG(MaPhieuNhap) ON DELETE CASCADE,
    CONSTRAINT FK_CTPhieuNhap_Sach FOREIGN KEY (MaSach)
        REFERENCES SACH(MaSach),
    CONSTRAINT CHK_SoLuongNhap_Positive CHECK (SoLuongNhap > 0),
    CONSTRAINT CHK_DonGiaNhap_Positive CHECK (DonGiaNhap >= 0)
);
GO

