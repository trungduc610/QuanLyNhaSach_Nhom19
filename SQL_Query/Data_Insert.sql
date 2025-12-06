USE NhaSach;
GO

-- Thể loại
INSERT INTO THELOAI (Ten_TheLoai) VALUES
(N'Tiểu thuyết'), (N'Truyện tranh'), (N'Sách giáo khoa'), (N'Tâm lý - Kỹ năng sống'),
(N'Lịch sử'), (N'Khoa học'), (N'Kinh tế'), (N'Truyện ngắn'), (N'Văn học Việt Nam'), (N'Văn học nước ngoài');

-- Nhà cung cấp
INSERT INTO NHACUNGCAP VALUES
('NCC001', N'NXB Trẻ', N'123 Nguyễn Trãi, TP.HCM', '0901234567', 'nxbtre@gmail.com'),
('NCC002', N'NXB Kim Đồng', N'45 Hai Bà Trưng, Hà Nội', '0912345678', 'kimdong@gmail.com'),
('NCC003', N'NXB Giáo Dục', N'12 Lê Lợi, Hà Nội', '0933456789', 'giaoduc@gmail.com'),
('NCC004', N'Fahasa', N'235 Lý Thường Kiệt, TP.HCM', '0944567890', 'fahasa@gmail.com'),
('NCC005', N'Alpha Books', N'99 Nguyễn Văn Cừ, Hà Nội', '0999012345', 'alphabooks@gmail.com');

-- Sách
INSERT INTO SACH (MaSach, ID_TheLoai, TenSach, TacGia, Nha_Xuat_Ban, Nam_Xuat_Ban, GiaNhap, GiaBan, SoLuong) VALUES
('S001', 1, N'Nhà giả kim', N'Paulo Coelho', N'NXB Trẻ', 2018, 50000, 85000, 50),
('S002', 2, N'Doraemon Tập 1', N'Fujiko F. Fujio', N'Kim Đồng', 2015, 10000, 18000, 100),
('S003', 3, N'Sách Toán 12', N'Bộ GD&ĐT', N'Giáo Dục', 2021, 20000, 35000, 200),
('S004', 4, N'Đắc Nhân Tâm', N'Dale Carnegie', N'Alpha Books', 2020, 60000, 98000, 80),
('S005', 5, N'Lịch Sử Việt Nam', N'Nhiều Tác Giả', N'NXB Trẻ', 2019, 80000, 120000, 40),
('S006', 6, N'Vũ trụ trong vỏ hạt dẻ', N'Stephen Hawking', N'Fahasa', 2018, 100000, 150000, 35),
('S007', 7, N'Cha giàu cha nghèo', N'Robert Kiyosaki', N'Alpha Books', 2020, 55000, 89000, 70),
('S008', 8, N'Truyện ngắn Nam Cao', N'Nam Cao', N'NXB Trẻ', 2017, 40000, 65000, 60),
('S009', 9, N'Truyện Kiều', N'Nguyễn Du', N'NXB Trẻ', 2016, 30000, 55000, 55),
('S010', 10, N'Tiếng gọi nơi hoang dã', N'Jack London', N'Fahasa', 2018, 45000, 78000, 45),
('S011', 1, N'Rừng Na Uy', N'Haruki Murakami', N'NXB Trẻ', 2018, 90000, 145000, 70),
('S012', 2, N'Conan Tập 98', N'Gosho Aoyama', N'Kim Đồng', 2021, 12000, 20000, 150),
('S013', 3, N'Sách Vật Lý 12', N'Bộ GD&ĐT', N'Giáo Dục', 2021, 18000, 30000, 180),
('S014', 4, N'7 Thói Quen Hiệu Quả', N'Stephen R. Covey', N'Alpha Books', 2019, 120000, 180000, 60),
('S015', 5, N'Việt Nam Sử Lược', N'Trần Trọng Kim', N'NXB Trẻ', 2017, 70000, 110000, 40);


-- Khách hàng
INSERT INTO KHACHHANG VALUES
('KH001', N'Nguyễn Văn A', '0912345678', N'123 CMT8, TP.HCM', 'vana@gmail.com'),
('KH002', N'Trần Thị B', '0987654321', N'45 Hai Bà Trưng, Hà Nội', 'thib@gmail.com'),
('KH003', N'Lê Văn C', '02839101010', N'12 Điện Biên, Đà Nẵng', 'vanc@gmail.com'),
('KH004', N'Phạm Thị D', '0966789012', N'99 Lý Thường Kiệt, TP.HCM', 'thid@gmail.com'),
('KH005', N'Hoàng Văn E', '0900112233', N'67 Trần Phú, Hà Nội', 'vane@gmail.com');

-- Nhân viên
INSERT INTO NHANVIEN (Ma_Nhan_Vien, Ten_Nhan_Vien, NgaySinh, GioiTinh, So_Dien_Thoai, DiaChi) VALUES
('NV001', N'Lê Minh Quân','1990-03-12',N'Nam','0944567890',N'123 Nguyễn Trãi, TP.HCM'),
('NV002', N'Nguyễn Thị Hoa','1992-07-05',N'Nữ','0955678901',N'45 Hai Bà Trưng, Hà Nội'),
('NV003', N'Trần Văn An','1988-09-23',N'Nam','0988901234',N'56 Điện Biên Phủ, Đà Nẵng'),
('NV004', N'Đinh Thị Hồng','1998-10-13',N'Nữ','0988905678',N'789 Lê Hồng Phong, TP.HCM'),
('NV005', N'Võ Văn Bình','1995-08-30',N'Nam','0988909613',N'234 Trần Quang Diệu, TP.HCM');

-- Tài khoản
INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, Ma_Nhan_Vien, Quyen) VALUES
('admin', '123', 'NV001', 'Admin');

-- Hóa đơn
INSERT INTO HOADON (Ma_Hoa_Don, Ma_Nhan_Vien, Ma_Khach_Hang, NgayLap) VALUES
('HD001','NV001','KH001','2025-08-15'),
('HD002','NV002','KH002','2025-08-20'),
('HD003','NV001','KH003','2025-09-01'),
('HD004','NV005','KH004','2025-09-10'),
('HD005','NV003','KH005','2025-09-15'),
('HD006','NV004','KH001','2025-10-02'),
('HD007','NV002','KH002','2025-10-05');

-- Chi tiết hóa đơn
-- HD001 (Tháng 8)
INSERT INTO CHITIETHOADON (Ma_Hoa_Don, MaSach, SoLuong) VALUES
('HD001','S001',2),
('HD001','S004',1);
-- HD002 (Tháng 8)
INSERT INTO CHITIETHOADON (Ma_Hoa_Don, MaSach, SoLuong) VALUES
('HD002','S002',3),
('HD002','S003',2);
-- HD003 (Tháng 9)
INSERT INTO CHITIETHOADON (Ma_Hoa_Don, MaSach, SoLuong) VALUES
('HD003','S005',1);
-- HD004 (Tháng 9)
INSERT INTO CHITIETHOADON (Ma_Hoa_Don, MaSach, SoLuong) VALUES
('HD004','S006',1),
('HD004','S009',4),
('HD004','S010',3);
-- HD005 (Tháng 9)
INSERT INTO CHITIETHOADON (Ma_Hoa_Don, MaSach, SoLuong) VALUES
('HD005','S007',2);
-- HD006 (Tháng 10)
INSERT INTO CHITIETHOADON (Ma_Hoa_Don, MaSach, SoLuong) VALUES
('HD006','S001',1),
('HD006','S002',5);
-- HD007 (Tháng 10)
INSERT INTO CHITIETHOADON (Ma_Hoa_Don, MaSach, SoLuong) VALUES
('HD007','S008',2);

-- Phiếu Nhập Hàng
INSERT INTO PHIEUNHAPHANG (MaPhieuNhap, Ma_Nhan_Vien, Ma_Nha_Cung_Cap, NgayNhap) VALUES
('PN001', 'NV001', 'NCC001', '2025-10-28'),
('PN002', 'NV003', 'NCC003', '2025-10-29');

-- Chi tiết phiếu NHẬP
INSERT INTO CHITIETPHIEUNHAP (MaPhieuNhap, MaSach, SoLuongNhap, DonGiaNhap) VALUES
('PN001', 'S001', 50, 50000), 
('PN001', 'S005', 30, 80000), 
('PN002', 'S003', 100, 20000); 
GO

SELECT * FROM THELOAI
SELECT * FROM SACH
SELECT * FROM NHACUNGCAP
SELECT * FROM NHANVIEN
SELECT * FROM KHACHHANG
SELECT * FROM HOADON
SELECT * FROM CHITIETHOADON
SELECT * FROM PHIEUNHAPHANG
SELECT * FROM CHITIETPHIEUNHAP
SELECT * FROM TAIKHOAN





PRINT N'Kiểm tra bảng Hóa Đơn (Đã tự động cập nhật TongTien):'
SELECT * FROM HOADON

PRINT N'Kiểm tra bảng Chi Tiết Hóa Đơn (Đã tự động cập nhật DonGia, ThanhTien):'
SELECT * FROM CHITIETHOADON

PRINT N'Kiểm tra bảng Sách (Đã tự động cập nhật/trừ số lượng tồn kho):'
SELECT MaSach, TenSach, SoLuong FROM SACH
GO

PRINT N'Kiểm tra TỒN KHO CUỐI CÙNG (Sau khi đã Bán và Nhập):'
SELECT MaSach, TenSach, SoLuong FROM SACH ORDER BY MaSach;
GO

PRINT N'Kiểm tra HÓA ĐƠN BÁN (đã tự tính TongTien):'
SELECT * FROM HOADON;
GO

PRINT N'Kiểm tra PHIẾU NHẬP HÀNG (đã tự tính TongTienNhap):'
SELECT * FROM PHIEUNHAPHANG;
GO