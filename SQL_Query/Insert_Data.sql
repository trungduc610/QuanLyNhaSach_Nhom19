USE NhaSach;
GO

-- =============================================
-- 1. LÀM SẠCH DỮ LIỆU CŨ
-- =============================================
DELETE FROM CHITIETPHIEUNHAP;
DELETE FROM PHIEUNHAPHANG;
DELETE FROM CHITIETHOADON;
DELETE FROM HOADON;
DELETE FROM TAIKHOAN; 
DELETE FROM NHANVIEN; 
DELETE FROM SACH;     
DELETE FROM NHACUNGCAP;
DELETE FROM KHACHHANG;
DELETE FROM THELOAI;
GO

-- Reset bộ đếm về 0
DBCC CHECKIDENT ('THELOAI', RESEED, 0);
GO

-- =============================================
-- 2. NHẬP THỂ LOẠI (Để ID tự tăng tự nhiên)
-- =============================================
INSERT INTO THELOAI (Ten_TheLoai, TrangThai) VALUES 
(N'Tiểu thuyết', 1),
(N'Truyện tranh', 1),
(N'Sách giáo khoa', 1),
(N'Kỹ năng sống', 1),
(N'Kinh tế', 1),
(N'Văn học nước ngoài', 1),
(N'Truyện thiếu nhi', 1),
(N'Khoa học - Công nghệ', 1);
GO

-- =============================================
-- 3. NHẬP NHÀ CUNG CẤP
-- =============================================
INSERT INTO NHACUNGCAP (Ma_Nha_Cung_Cap, Ten_Nha_Cung_Cap, DiaChi, So_Dien_Thoai, TrangThai) VALUES 
('NCC001', N'NXB Kim Đồng', N'55 Quang Trung, Hà Nội', '02439434730', 1),
('NCC002', N'NXB Trẻ', N'161B Lý Chính Thắng, TP.HCM', '02839316289', 1),
('NCC003', N'NXB Giáo Dục', N'81 Trần Hưng Đạo, Hà Nội', '02438220801', 1),
('NCC004', N'NXB Hội Nhà Văn', N'65 Nguyễn Du, Hà Nội', '02438222135', 1),
('NCC005', N'Nhã Nam', N'59 Đỗ Quang, Hà Nội', '02435146875', 1);
GO

-- =============================================
-- 4. NHẬP SÁCH
-- =============================================
INSERT INTO SACH (MaSach, ID_TheLoai, TenSach, TacGia, Nha_Xuat_Ban, GiaNhap, GiaBan, SoLuong, HinhAnh, TrangThai) VALUES
-- 1. Truyện tranh (Tự tìm ID của 'Truyện tranh')
('S001', (SELECT ID_TheLoai FROM THELOAI WHERE Ten_TheLoai = N'Truyện tranh'), N'Doraemon Tập 1', N'Fujiko F', N'NXB Kim Đồng', 12000, 20000, 100, NULL, 1),
('S002', (SELECT ID_TheLoai FROM THELOAI WHERE Ten_TheLoai = N'Truyện tranh'), N'Conan Tập 100', N'Gosho Aoyama', N'NXB Kim Đồng', 15000, 25000, 100, NULL, 1),
('S003', (SELECT ID_TheLoai FROM THELOAI WHERE Ten_TheLoai = N'Truyện tranh'), N'One Piece Tập 99', N'Eiichiro Oda', N'NXB Kim Đồng', 15000, 25000, 80, NULL, 1),
('S004', (SELECT ID_TheLoai FROM THELOAI WHERE Ten_TheLoai = N'Truyện tranh'), N'Dragon Ball Super 1', N'Toriyama Akira', N'NXB Kim Đồng', 15000, 25000, 60, NULL, 1),
('S005', (SELECT ID_TheLoai FROM THELOAI WHERE Ten_TheLoai = N'Truyện tranh'), N'Shin Cậu Bé Bút Chì', N'Yoshito Usui', N'NXB Kim Đồng', 12000, 18000, 90, NULL, 1),

-- 2. Tiểu thuyết & Văn học nước ngoài
('S006', (SELECT ID_TheLoai FROM THELOAI WHERE Ten_TheLoai = N'Tiểu thuyết'), N'Mắt Biếc', N'Nguyễn Nhật Ánh', N'NXB Trẻ', 70000, 110000, 50, NULL, 1),
('S007', (SELECT ID_TheLoai FROM THELOAI WHERE Ten_TheLoai = N'Tiểu thuyết'), N'Tôi Thấy Hoa Vàng', N'Nguyễn Nhật Ánh', N'NXB Trẻ', 75000, 125000, 45, NULL, 1),
('S008', (SELECT ID_TheLoai FROM THELOAI WHERE Ten_TheLoai = N'Văn học nước ngoài'), N'Harry Potter 1', N'J.K. Rowling', N'NXB Trẻ', 150000, 250000, 30, NULL, 1),
('S009', (SELECT ID_TheLoai FROM THELOAI WHERE Ten_TheLoai = N'Văn học nước ngoài'), N'Nhà Giả Kim', N'Paulo Coelho', N'Nhã Nam', 50000, 79000, 100, NULL, 1),
('S010', (SELECT ID_TheLoai FROM THELOAI WHERE Ten_TheLoai = N'Văn học nước ngoài'), N'Rừng Na Uy', N'Haruki Murakami', N'Nhã Nam', 80000, 130000, 40, NULL, 1),
('S011', (SELECT ID_TheLoai FROM THELOAI WHERE Ten_TheLoai = N'Tiểu thuyết'), N'Số Đỏ', N'Vũ Trọng Phụng', N'NXB Hội Nhà Văn', 40000, 65000, 60, NULL, 1),
('S012', (SELECT ID_TheLoai FROM THELOAI WHERE Ten_TheLoai = N'Tiểu thuyết'), N'Dế Mèn Phiêu Lưu Ký', N'Tô Hoài', N'NXB Kim Đồng', 30000, 50000, 150, NULL, 1),

-- 3. Kỹ năng sống & Kinh tế
('S013', (SELECT ID_TheLoai FROM THELOAI WHERE Ten_TheLoai = N'Kỹ năng sống'), N'Đắc Nhân Tâm', N'Dale Carnegie', N'NXB Trẻ', 55000, 86000, 200, NULL, 1),
('S014', (SELECT ID_TheLoai FROM THELOAI WHERE Ten_TheLoai = N'Kỹ năng sống'), N'Đời Thay Đổi Khi Ta Thay Đổi', N'Andrew Matthews', N'NXB Trẻ', 45000, 75000, 80, NULL, 1),
('S015', (SELECT ID_TheLoai FROM THELOAI WHERE Ten_TheLoai = N'Kinh tế'), N'Cha Giàu Cha Nghèo', N'Robert Kiyosaki', N'NXB Trẻ', 60000, 110000, 120, NULL, 1),
('S016', (SELECT ID_TheLoai FROM THELOAI WHERE Ten_TheLoai = N'Kinh tế'), N'Nhà Đầu Tư Thông Minh', N'Benjamin Graham', N'NXB Trẻ', 120000, 199000, 30, NULL, 1),
('S017', (SELECT ID_TheLoai FROM THELOAI WHERE Ten_TheLoai = N'Kỹ năng sống'), N'Tuổi Trẻ Đáng Giá Bao Nhiêu', N'Rosie Nguyễn', N'Nhã Nam', 50000, 80000, 150, NULL, 1),

-- 4. Sách giáo khoa
('S018', (SELECT ID_TheLoai FROM THELOAI WHERE Ten_TheLoai = N'Sách giáo khoa'), N'Toán 12 - Tập 1', N'Bộ Giáo Dục', N'NXB Giáo Dục', 10000, 15000, 300, NULL, 1),
('S019', (SELECT ID_TheLoai FROM THELOAI WHERE Ten_TheLoai = N'Sách giáo khoa'), N'Toán 12 - Tập 2', N'Bộ Giáo Dục', N'NXB Giáo Dục', 10000, 15000, 300, NULL, 1),
('S020', (SELECT ID_TheLoai FROM THELOAI WHERE Ten_TheLoai = N'Sách giáo khoa'), N'Ngữ Văn 12 - Tập 1', N'Bộ Giáo Dục', N'NXB Giáo Dục', 12000, 17000, 250, NULL, 1),
('S021', (SELECT ID_TheLoai FROM THELOAI WHERE Ten_TheLoai = N'Sách giáo khoa'), N'Vật Lý 12', N'Bộ Giáo Dục', N'NXB Giáo Dục', 15000, 22000, 200, NULL, 1),
('S022', (SELECT ID_TheLoai FROM THELOAI WHERE Ten_TheLoai = N'Sách giáo khoa'), N'Hóa Học 12', N'Bộ Giáo Dục', N'NXB Giáo Dục', 15000, 22000, 200, NULL, 1),
('S023', (SELECT ID_TheLoai FROM THELOAI WHERE Ten_TheLoai = N'Sách giáo khoa'), N'Tiếng Anh 12', N'Bộ Giáo Dục', N'NXB Giáo Dục', 25000, 35000, 180, NULL, 1),

-- 5. Khoa học / Thiếu nhi
('S024', (SELECT ID_TheLoai FROM THELOAI WHERE Ten_TheLoai = N'Khoa học - Công nghệ'), N'Clean Code', N'Robert C. Martin', N'NXB Trẻ', 200000, 350000, 20, NULL, 1),
('S025', (SELECT ID_TheLoai FROM THELOAI WHERE Ten_TheLoai = N'Khoa học - Công nghệ'), N'Introduction to Algorithms', N'Thomas H. Cormen', N'NXB Giáo Dục', 300000, 500000, 10, NULL, 1),
('S026', (SELECT ID_TheLoai FROM THELOAI WHERE Ten_TheLoai = N'Khoa học - Công nghệ'), N'Design Patterns', N'Gang of Four', N'NXB Trẻ', 150000, 250000, 15, NULL, 1),
('S027', (SELECT ID_TheLoai FROM THELOAI WHERE Ten_TheLoai = N'Khoa học - Công nghệ'), N'SQL Server 2022', N'Mai Hữu Toàn', N'NXB Thống Kê', 90000, 150000, 40, NULL, 1),
('S028', (SELECT ID_TheLoai FROM THELOAI WHERE Ten_TheLoai = N'Truyện thiếu nhi'), N'Thần Đồng Đất Việt 1', N'Lê Linh', N'NXB Trẻ', 15000, 25000, 60, NULL, 1),
('S029', (SELECT ID_TheLoai FROM THELOAI WHERE Ten_TheLoai = N'Truyện thiếu nhi'), N'Trạng Tí', N'Phan Thị', N'NXB Trẻ', 15000, 25000, 50, NULL, 1),
('S030', (SELECT ID_TheLoai FROM THELOAI WHERE Ten_TheLoai = N'Kỹ năng sống'), N'Hạt Giống Tâm Hồn', N'Nhiều Tác Giả', N'NXB Trẻ', 35000, 55000, 100, NULL, 1);
GO

-- =============================================
-- 5. NHẬP KHÁCH HÀNG & NHÂN VIÊN
-- =============================================
INSERT INTO KHACHHANG (Ma_Khach_Hang, Ten_Khach_Hang, So_Dien_Thoai, DiaChi, Email, TrangThai) VALUES
('KH001', N'Nguyễn Văn An', '0909111222', N'Q.1, TP.HCM', 'an.nguyen@gmail.com', 1), 
('KH002', N'Trần Thị Bích', '0909333444', N'Q.3, TP.HCM', 'bich.tran@yahoo.com', 1),
('KH003', N'Lê Hoàng Nam', '0912345678', N'Q.5, TP.HCM', 'nam.le@gmail.com', 1),
('KH004', N'Phạm Minh Tuấn', '0988777666', N'Biên Hòa, Đồng Nai', 'tuan.pham@outlook.com', 1),
('KH005', N'Hoàng Thị Lan', '0918123123', N'Thủ Đức, TP.HCM', 'lan.hoang@gmail.com', 1),
('KH006', N'Vũ Đức Đam', '0909000111', N'Bình Thạnh, TP.HCM', 'dam.vu@gmail.com', 1),
('KH007', N'Đặng Lê Nguyên', '0909999888', N'Q.10, TP.HCM', 'nguyen.dang@cafe.vn', 1),
('KH008', N'Bùi Thị Xuân', '0912222333', N'Gò Vấp, TP.HCM', 'xuan.bui@gmail.com', 1),
('KH009', N'Đỗ Hùng Dũng', '0901234567', N'Hà Nội', 'dung.do@bongda.vn', 1),
('KH010', N'Nguyễn Quang Hải', '0909191919', N'Đông Anh, Hà Nội', 'hai.nguyen@bongda.vn', 1),
('KH011', N'Phan Văn Đức', '0988888999', N'Nghệ An', 'duc.phan@slna.com', 1),
('KH012', N'Trấn Thành', '0901111222', N'Q.7, TP.HCM', 'thanh.tran@showbiz.vn', 1),
('KH013', N'Trường Giang', '0902222333', N'Quảng Nam', 'giang.truong@showbiz.vn', 1),
('KH014', N'Mỹ Tâm', '0903333444', N'Đà Nẵng', 'tam.my@singer.vn', 1),
('KH015', N'Sơn Tùng MTP', '0904444555', N'Thái Bình', 'tung.son@mtp.vn', 1),
('KH016', N'Ngô Bảo Châu', '0905555666', N'Pháp', 'chau.ngo@math.com', 1),
('KH017', N'Phạm Nhật Vượng', '0906666777', N'Hà Nội', 'vuong.pham@vingroup.com', 1),
('KH018', N'Lý Nhã Kỳ', '0907777888', N'Vũng Tàu', 'ky.ly@bds.vn', 1),
('KH019', N'Hương Giang', '0908888999', N'Hà Nội', 'giang.huong@queen.vn', 1),
('KH020', N'Đen Vâu', '0909999000', N'Hạ Long', 'den.vau@rap.vn', 1);

INSERT INTO NHANVIEN (Ma_Nhan_Vien, Ten_Nhan_Vien, NgaySinh, GioiTinh, So_Dien_Thoai, DiaChi, TrangThai) VALUES
('NV001', N'Lê Minh Quân', '1990-01-01', N'Nam', '0901111111', N'TP.HCM', 1), 
('NV002', N'Nguyễn Thị Hoa', '1995-05-20', N'Nữ', '0902222222', N'Đồng Nai', 1);

INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, Ma_Nhan_Vien, Quyen, TrangThai) VALUES
('admin', '123', 'NV001', 'Admin', 1),
('banhang', '123', 'NV002', 'NhanVien', 1);
GO

-- =============================================
-- 6. NHẬP GIAO DỊCH (PHIẾU NHẬP & HÓA ĐƠN)
-- =============================================

-- Phiếu Nhập
INSERT INTO PHIEUNHAPHANG (MaPhieuNhap, Ma_Nhan_Vien, Ma_Nha_Cung_Cap, NgayNhap, TongTienNhap, TrangThai) VALUES
('PN001', 'NV002', 'NCC001', '2023-11-01', 0, 1),
('PN002', 'NV001', 'NCC002', '2023-11-05', 0, 1),
('PN003', 'NV001', 'NCC003', '2023-11-10', 0, 1),
('PN004', 'NV002', 'NCC005', '2023-12-01', 0, 1),
('PN005', 'NV001', 'NCC001', '2023-12-15', 0, 1);

INSERT INTO CHITIETPHIEUNHAP (MaPhieuNhap, MaSach, SoLuongNhap, DonGiaNhap) VALUES
('PN001', 'S001', 50, 12000), 
('PN001', 'S002', 50, 15000), 
('PN002', 'S006', 20, 70000), 
('PN002', 'S013', 30, 55000), 
('PN003', 'S018', 100, 10000), 
('PN004', 'S009', 50, 50000), 
('PN005', 'S003', 40, 15000); 

-- Hóa Đơn
INSERT INTO HOADON (Ma_Hoa_Don, Ma_Nhan_Vien, Ma_Khach_Hang, NgayLap, TongTien, TrangThai) VALUES
('HD001', 'NV002', 'KH001', '2023-11-02', 0, 1),
('HD002', 'NV002', 'KH002', '2023-11-03', 0, 1),
('HD003', 'NV002', 'KH003', '2023-11-04', 0, 1),
('HD004', 'NV002', 'KH001', '2023-11-10', 0, 1),
('HD005', 'NV001', 'KH005', '2023-11-15', 0, 1),
('HD006', 'NV002', 'KH010', '2023-11-20', 0, 1),
('HD007', 'NV002', 'KH012', '2023-11-25', 0, 1),
('HD008', 'NV001', 'KH015', '2023-12-01', 0, 1),
('HD009', 'NV002', 'KH020', '2023-12-05', 0, 1),
('HD010', 'NV002', 'KH001', '2023-12-08', 0, 1),
('HD011', 'NV002', 'KH004', '2023-12-10', 0, 1),
('HD012', 'NV001', 'KH008', '2023-12-12', 0, 1),
('HD013', 'NV002', 'KH002', GETDATE(), 0, 1),
('HD014', 'NV002', 'KH003', GETDATE(), 0, 1);

INSERT INTO CHITIETHOADON (Ma_Hoa_Don, MaSach, SoLuong, DonGia) VALUES
('HD001', 'S001', 2, 20000), 
('HD001', 'S002', 1, 25000),
('HD002', 'S006', 1, 110000),
('HD003', 'S018', 5, 15000),
('HD003', 'S019', 5, 15000),
('HD004', 'S008', 1, 250000),
('HD005', 'S013', 2, 86000),
('HD006', 'S014', 10, 75000), 
('HD007', 'S009', 5, 79000),
('HD007', 'S010', 2, 130000),
('HD008', 'S015', 3, 110000),
('HD009', 'S003', 10, 25000),
('HD010', 'S024', 1, 350000),
('HD011', 'S027', 1, 150000), 
('HD012', 'S030', 2, 55000), 
('HD013', 'S001', 5, 20000),
('HD014', 'S005', 2, 18000);
GO