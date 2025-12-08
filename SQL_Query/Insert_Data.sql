USE NhaSach;
GO

-- 1. XÓA DỮ LIỆU CŨ (Theo thứ tự: Con trước -> Cha sau)
DELETE FROM CHITIETPHIEUNHAP;
DELETE FROM PHIEUNHAPHANG;
DELETE FROM CHITIETHOADON;
DELETE FROM HOADON;
DELETE FROM SACH; -- Xóa sách trước khi xóa Thể loại/NCC
DELETE FROM NHACUNGCAP;
DELETE FROM THELOAI;
DELETE FROM TAIKHOAN;
DELETE FROM NHANVIEN;
DELETE FROM KHACHHANG;
GO

-- 2. RESET BỘ ĐẾM TỰ TĂNG (QUAN TRỌNG ĐỂ TRÁNH LỖI FK)
-- Lệnh này bắt buộc ID tiếp theo phải bắt đầu từ 1
DBCC CHECKIDENT ('THELOAI', RESEED, 0);
GO

-- 1. Thể Loại
INSERT INTO THELOAI (Ten_TheLoai, TrangThai) VALUES 
(N'Tiểu thuyết', 1), 
(N'Truyện tranh', 1), 
(N'Sách giáo khoa', 1),
(N'Kỹ năng sống', 1);

-- 2. Nhà Cung Cấp (PHẢI KHỚP VỚI NXB CỦA SÁCH BÊN DƯỚI)
-- Chúng ta tạo 3 ông lớn cung cấp sách
INSERT INTO NHACUNGCAP (Ma_Nha_Cung_Cap, Ten_Nha_Cung_Cap, DiaChi, So_Dien_Thoai, TrangThai) VALUES 
('NCC001', N'NXB Kim Đồng', N'Hà Nội', '02439434730', 1),
('NCC002', N'NXB Trẻ', N'TP.HCM', '02839316289', 1),
('NCC003', N'NXB Giáo Dục', N'Hà Nội', '02438220801', 1);

-- 3. Sách (Cột Nha_Xuat_Ban phải chứa tên của NCC ở trên)
-- Logic lọc: LIKE %TênNCC%
INSERT INTO SACH (MaSach, ID_TheLoai, TenSach, TacGia, Nha_Xuat_Ban, GiaNhap, GiaBan, SoLuong, HinhAnh, TrangThai) VALUES
-- Sách của Kim Đồng (NCC001)
('S001', 2, N'Doraemon Tập 1', N'Fujiko F', N'NXB Kim Đồng', 12000, 20000, 100, NULL, 1),
('S002', 2, N'Conan Tập 100', N'Gosho Aoyama', N'NXB Kim Đồng', 15000, 25000, 50, NULL, 1),

-- Sách của NXB Trẻ (NCC002)
('S003', 1, N'Mắt Biếc', N'Nguyễn Nhật Ánh', N'NXB Trẻ', 70000, 110000, 40, NULL, 1),
('S004', 1, N'Harry Potter 1', N'J.K. Rowling', N'NXB Trẻ', 150000, 250000, 20, NULL, 1),

-- Sách của Giáo Dục (NCC003)
('S005', 3, N'Toán 12 - Tập 1', N'Bộ Giáo Dục', N'NXB Giáo Dục', 10000, 15000, 200, NULL, 1);

-- 4. Khách Hàng
INSERT INTO KHACHHANG (Ma_Khach_Hang, Ten_Khach_Hang, So_Dien_Thoai, DiaChi, Email, TrangThai) VALUES
('KH001', N'Nguyễn Văn An', '0909123456', N'Q.1, TP.HCM', 'an@gmail.com', 1), 
('KH002', N'Trần Thị Bích', '0912345678', N'Q.3, TP.HCM', 'bich@yahoo.com', 1);

-- 5. Nhân Viên
INSERT INTO NHANVIEN (Ma_Nhan_Vien, Ten_Nhan_Vien, NgaySinh, GioiTinh, So_Dien_Thoai, DiaChi, TrangThai) VALUES
('NV001', N'Lê Minh Quân', '2000-01-01', N'Nam', '0988777666', N'TP.HCM', 1),
('NV002', N'Phạm Thị Hoa', '1999-05-20', N'Nữ', '0911222333', N'Đồng Nai', 1);

-- 6. Tài Khoản
INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, Ma_Nhan_Vien, Quyen, TrangThai) VALUES
('admin', '123', 'NV001', 'Admin', 1),
('nhanvien', '123', 'NV002', 'NhanVien', 1);
GO