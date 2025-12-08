CREATE DATABASE NhaSach;
GO

USE NhaSach;
GO

-- 1. Bảng Thể Loại
CREATE TABLE THELOAI(
    ID_TheLoai INT IDENTITY(1,1) PRIMARY KEY,
    Ten_TheLoai NVARCHAR(100) NOT NULL,
    TrangThai BIT DEFAULT 1 -- 1: Hiện, 0: Đã xóa
);

-- 2. Bảng Nhà Cung Cấp
CREATE TABLE NHACUNGCAP(
    Ma_Nha_Cung_Cap CHAR(10) PRIMARY KEY NOT NULL,
    Ten_Nha_Cung_Cap NVARCHAR(100) NOT NULL,
    DiaChi NVARCHAR(200),
    So_Dien_Thoai VARCHAR(20),
    Email NVARCHAR(100),
    TrangThai BIT DEFAULT 1
);

-- 3. Bảng Sách (Đã thêm HinhAnh)
CREATE TABLE SACH(
    MaSach CHAR(10) PRIMARY KEY NOT NULL,
    ID_TheLoai INT NOT NULL,
    TenSach NVARCHAR(100) NOT NULL,
    TacGia NVARCHAR(100),
    Nha_Xuat_Ban NVARCHAR(100),
    Nam_Xuat_Ban INT,
    GiaNhap DECIMAL(18,0) DEFAULT 0,
    GiaBan DECIMAL(18,0) DEFAULT 0,  
    SoLuong INT NOT NULL DEFAULT 0,
    HinhAnh NVARCHAR(500) DEFAULT NULL, -- Lưu đường dẫn ảnh (VD: D:\Anh\sach1.jpg)
    TrangThai BIT DEFAULT 1,

    CONSTRAINT FK_Sach_TheLoai FOREIGN KEY(ID_TheLoai) REFERENCES THELOAI(ID_TheLoai)
);

-- 4. Bảng Khách Hàng
CREATE TABLE KHACHHANG(
    Ma_Khach_Hang CHAR(10) PRIMARY KEY NOT NULL,
    Ten_Khach_Hang NVARCHAR(100) NOT NULL,
    So_Dien_Thoai VARCHAR(20),
    DiaChi NVARCHAR(200),
    Email NVARCHAR(100),
    TrangThai BIT DEFAULT 1
);

-- 5. Bảng Nhân Viên
CREATE TABLE NHANVIEN(
    Ma_Nhan_Vien CHAR(10) PRIMARY KEY NOT NULL,
    Ten_Nhan_Vien NVARCHAR(100) NOT NULL,
    NgaySinh DATE,
    GioiTinh NVARCHAR(10),
    So_Dien_Thoai VARCHAR(20),
    DiaChi NVARCHAR(200),
    TrangThai BIT DEFAULT 1 -- 1: Đang làm, 0: Đã nghỉ
);

-- 6. Bảng Tài Khoản
CREATE TABLE TAIKHOAN(
    TenDangNhap VARCHAR(50) PRIMARY KEY NOT NULL,
    MatKhau VARCHAR(100) NOT NULL, -- Dài ra để chứa mã hóa MD5
    Ma_Nhan_Vien CHAR(10) NOT NULL UNIQUE, 
    Quyen VARCHAR(20) NOT NULL DEFAULT 'NhanVien', 
    NgayTao DATE DEFAULT GETDATE(),
    TrangThai BIT DEFAULT 1,

    CONSTRAINT FK_TaiKhoan_NhanVien FOREIGN KEY(Ma_Nhan_Vien) REFERENCES NHANVIEN(Ma_Nhan_Vien),
    CONSTRAINT CHK_Quyen CHECK (Quyen IN ('Admin', 'NhanVien'))
);

-- 7. Bảng Hóa Đơn
CREATE TABLE HOADON(
    Ma_Hoa_Don CHAR(10) PRIMARY KEY NOT NULL,
    Ma_Nhan_Vien CHAR(10) NOT NULL,
    Ma_Khach_Hang CHAR(10) NOT NULL,
    NgayLap DATETIME DEFAULT GETDATE(), 
    TongTien DECIMAL(18,0) DEFAULT 0,
    TrangThai BIT DEFAULT 1, -- 1: Hoàn thành, 0: Đã hủy

    CONSTRAINT FK_HoaDon_NhanVien FOREIGN KEY(Ma_Nhan_Vien) REFERENCES NHANVIEN(Ma_Nhan_Vien),
    CONSTRAINT FK_HoaDon_KhachHang FOREIGN KEY(Ma_Khach_Hang) REFERENCES KHACHHANG(Ma_Khach_Hang)
);

-- 8. Bảng Chi Tiết Hóa Đơn
CREATE TABLE CHITIETHOADON(
    Ma_Hoa_Don CHAR(10) NOT NULL,
    MaSach CHAR(10) NOT NULL,
    SoLuong INT NOT NULL CHECK (SoLuong > 0),
    DonGia DECIMAL(18,0) DEFAULT 0, 
    ThanhTien DECIMAL(18,0) DEFAULT 0,

    PRIMARY KEY(Ma_Hoa_Don, MaSach),
    CONSTRAINT FK_CTHD_HoaDon FOREIGN KEY (Ma_Hoa_Don) REFERENCES HOADON(Ma_Hoa_Don) ON DELETE CASCADE, 
    CONSTRAINT FK_CTHD_Sach FOREIGN KEY (MaSach) REFERENCES SACH(MaSach)
);

-- 9. Bảng Phiếu Nhập
CREATE TABLE PHIEUNHAPHANG (
    MaPhieuNhap CHAR(10) PRIMARY KEY NOT NULL,
    Ma_Nhan_Vien CHAR(10) NOT NULL,
    Ma_Nha_Cung_Cap CHAR(10) NOT NULL,
    NgayNhap DATETIME DEFAULT GETDATE(),
    TongTienNhap DECIMAL(18,0) DEFAULT 0,
    TrangThai BIT DEFAULT 1,

    CONSTRAINT FK_PN_NhanVien FOREIGN KEY (Ma_Nhan_Vien) REFERENCES NHANVIEN(Ma_Nhan_Vien),
    CONSTRAINT FK_PN_NhaCungCap FOREIGN KEY (Ma_Nha_Cung_Cap) REFERENCES NHACUNGCAP(Ma_Nha_Cung_Cap)
);

-- 10. Bảng Chi Tiết Phiếu Nhập
CREATE TABLE CHITIETPHIEUNHAP (
    MaPhieuNhap CHAR(10) NOT NULL,
    MaSach CHAR(10) NOT NULL,
    SoLuongNhap INT NOT NULL CHECK (SoLuongNhap > 0),
    DonGiaNhap DECIMAL(18,0) NOT NULL CHECK (DonGiaNhap >= 0),
    ThanhTienNhap DECIMAL(18,0) DEFAULT 0,

    PRIMARY KEY (MaPhieuNhap, MaSach),
    CONSTRAINT FK_CTPN_PhieuNhap FOREIGN KEY (MaPhieuNhap) REFERENCES PHIEUNHAPHANG(MaPhieuNhap) ON DELETE CASCADE,
    CONSTRAINT FK_CTPN_Sach FOREIGN KEY (MaSach) REFERENCES SACH(MaSach)
);
GO