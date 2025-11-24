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
INSERT INTO SACH (MaSach, ID_TheLoai, Ma_Nha_Cung_Cap, TenSach, TacGia, Nha_Xuat_Ban, Nam_Xuat_Ban, GiaNhap, GiaBan, SoLuong) VALUES
('S001','1','NCC001',N'Nhà giả kim',N'Paulo Coelho',N'NXB Trẻ',2018, 50000, 85000, 50),
('S002','2','NCC002',N'Doraemon Tập 1',N'Fujiko F. Fujio',N'Kim Đồng',2015, 10000, 18000, 100),
('S003','3','NCC003',N'Sách Toán 12',N'Bộ GD&ĐT',N'Giáo Dục',2021, 20000, 35000, 200),
('S004','4','NCC005',N'Đắc Nhân Tâm',N'Dale Carnegie',N'Alpha Books',2020, 60000, 98000, 80),
('S005','5','NCC001',N'Lịch Sử Việt Nam',N'Nhiều Tác Giả',N'NXB Trẻ',2019, 80000, 120000, 40),
('S006','6','NCC004',N'Vũ trụ trong vỏ hạt dẻ',N'Stephen Hawking',N'Fahasa',2018, 100000, 150000, 35),
('S007','7','NCC005',N'Cha giàu cha nghèo',N'Robert Kiyosaki',N'Alpha Books',2020, 55000, 89000, 70),
('S008','8','NCC001',N'Truyện ngắn Nam Cao',N'Nam Cao',N'NXB Trẻ',2017, 40000, 65000, 60),
('S009','9','NCC001',N'Truyện Kiều',N'Nguyễn Du',N'NXB Trẻ',2016, 30000, 55000, 55),
('S010','10','NCC004',N'Tiếng gọi nơi hoang dã',N'Jack London',N'Fahasa',2018, 45000, 78000, 45),
('S011', 1, 'NCC001', N'Rừng Na Uy', N'Haruki Murakami', N'NXB Trẻ', 2018, 90000, 145000, 70),
('S012', 2, 'NCC002', N'Conan Tập 98', N'Gosho Aoyama', N'Kim Đồng', 2021, 12000, 20000, 150),
('S013', 3, 'NCC003', N'Sách Vật Lý 12', N'Bộ GD&ĐT', N'Giáo Dục', 2021, 18000, 30000, 180),
('S014', 4, 'NCC005', N'7 Thói Quen Hiệu Quả', N'Stephen R. Covey', N'Alpha Books', 2019, 120000, 180000, 60),
('S015', 5, 'NCC001', N'Việt Nam Sử Lược', N'Trần Trọng Kim', N'NXB Trẻ', 2017, 70000, 110000, 40),
('S016', 6, 'NCC004', N'Lược sử thời gian', N'Stephen Hawking', N'Fahasa', 2017, 95000, 140000, 30),
('S017', 7, 'NCC005', N'Tư duy nhanh và chậm', N'Daniel Kahneman', N'Alpha Books', 2021, 130000, 199000, 50),
('S018', 8, 'NCC001', N'Vang bóng một thời', N'Nguyễn Tuân', N'NXB Trẻ', 2018, 50000, 78000, 65),
('S019', 9, 'NCC001', N'Số đỏ', N'Vũ Trọng Phụng', N'NXB Trẻ', 2019, 45000, 70000, 80),
('S020', 10, 'NCC004', N'Bố già', N'Mario Puzo', N'Fahasa', 2018, 110000, 165000, 25),
('S021', 1, 'NCC001', N'Cuốn theo chiều gió', N'Margaret Mitchell', N'NXB Trẻ', 2019, 150000, 220000, 30),
('S022', 2, 'NCC002', N'One Piece Tập 90', N'Eiichiro Oda', N'Kim Đồng', 2020, 12000, 20000, 120),
('S023', 4, 'NCC005', N'Người giàu có nhất thành Babylon', N'George S. Clason', N'Alpha Books', 2020, 50000, 80000, 90),
('S024', 7, 'NCC005', N'Từ tốt đến vĩ đại', N'Jim Collins', N'Alpha Books', 2019, 100000, 155000, 45),
('S025', 6, 'NCC004', N'Sapiens: Lược sử loài người', N'Yuval Noah Harari', N'Fahasa', 2018, 180000, 270000, 50),
('S026', 3, 'NCC003', N'Sách Hóa Học 12', N'Bộ GD&ĐT', N'Giáo Dục', 2021, 19000, 32000, 170),
('S027', 5, 'NCC001', N'Đại Việt Sử Ký Toàn Thư', N'Nhiều Tác Giả', N'NXB Trẻ', 2020, 300000, 450000, 20),
('S028', 10, 'NCC004', N'Không gia đình', N'Hector Malot', N'Fahasa', 2018, 75000, 115000, 55),
('S029', 9, 'NCC001', N'Lão Hạc', N'Nam Cao', N'NXB Trẻ', 2017, 25000, 40000, 100),
('S030', 2, 'NCC002', N'Thám tử lừng danh Conan - Tập đặc biệt', N'Gosho Aoyama', N'Kim Đồng', 2021, 30000, 45000, 70),
('S031', 1, 'NCC001', N'Giết con chim nhại', N'Harper Lee', N'NXB Trẻ', 2019, 85000, 125000, 40),
('S032', 4, 'NCC005', N'Nghĩ giàu và làm giàu', N'Napoleon Hill', N'Alpha Books', 2020, 65000, 99000, 85),
('S033', 7, 'NCC005', N'Khuyến học', N'Fukuzawa Yukichi', N'Alpha Books', 2018, 40000, 65000, 60),
('S034', 6, 'NCC004', N'Nguồn gốc các loài', N'Charles Darwin', N'Fahasa', 2019, 140000, 210000, 25),
('S035', 8, 'NCC001', N'Gió đầu mùa', N'Thạch Lam', N'NXB Trẻ', 2017, 35000, 55000, 70),
('S036', 3, 'NCC003', N'Sách Ngữ Văn 12', N'Bộ GD&ĐT', N'Giáo Dục', 2021, 22000, 38000, 190),
('S037', 10, 'NCC004', N'Hai vạn dặm dưới đáy biển', N'Jules Verne', N'Fahasa', 2018, 60000, 95000, 50),
('S038', 1, 'NCC001', N'Bắt trẻ đồng xanh', N'J.D. Salinger', N'NXB Trẻ', 2017, 55000, 88000, 45),
('S039', 2, 'NCC002', N'Dragon Ball Super Tập 10', N'Akira Toriyama', N'Kim Đồng', 2020, 13000, 22000, 110),
('S040', 4, 'NCC005', N'Sức mạnh của thói quen', N'Charles Duhigg', N'Alpha Books', 2019, 80000, 129000, 65),
('S041', 5, 'NCC001', N'Hồ Chí Minh: Toàn tập', N'Hội đồng biên soạn', N'NXB Trẻ', 2015, 500000, 700000, 15),
('S042', 9, 'NCC001', N'Chí Phèo', N'Nam Cao', N'NXB Trẻ', 2018, 30000, 50000, 90),
('S043', 7, 'NCC005', N'Tuần làm việc 4 giờ', N'Timothy Ferriss', N'Alpha Books', 2020, 70000, 110000, 50),
('S044', 1, 'NCC001', N'Trăm năm cô đơn', N'Gabriel Garcia Marquez', N'NXB Trẻ', 2019, 105000, 160000, 35),
('S045', 10, 'NCC004', N'Những cuộc phiêu lưu của Tom Sawyer', N'Mark Twain', N'Fahasa', 2017, 45000, 72000, 55),
('S046', 2, 'NCC002', N'Naruto Tập 72', N'Masashi Kishimoto', N'Kim Đồng', 2015, 12000, 20000, 95),
('S047', 3, 'NCC003', N'Sách Sinh Học 12', N'Bộ GD&ĐT', N'Giáo Dục', 2021, 20000, 33000, 160),
('S048', 6, 'NCC004', N'Gen Vị Kỷ', N'Richard Dawkins', N'Fahasa', 2020, 130000, 195000, 22),
('S049', 8, 'NCC001', N'Hà Nội băm sáu phố phường', N'Thạch Lam', N'NXB Trẻ', 2016, 40000, 68000, 38),
('S050', 1, 'NCC004', N'Hoàng tử bé', N'Antoine de Saint-Exupéry', N'Fahasa', 2019, 35000, 55000, 75);

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
('NV003', N'Trần Văn An','1988-09-23',N'Nam','0988901234',N'56 Điện Biên Phủ, Đà Nẵng');

-- Tài khoản (Mật khẩu '123' đã được HASH bằng SHA2_256)
INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, Ma_Nhan_Vien, Quyen) VALUES
('admin', '123', 'NV001', 'Admin');

-- Hóa đơn
INSERT INTO HOADON (Ma_Hoa_Don, Ma_Nhan_Vien, Ma_Khach_Hang, NgayLap) VALUES
('HD001','NV001','KH001','2025-08-15'),
('HD002','NV002','KH002','2025-08-20'),
('HD003','NV001','KH003','2025-09-01'),
('HD004','NV002','KH004','2025-09-10'),
('HD005','NV003','KH005','2025-09-15'),
('HD006','NV001','KH001','2025-10-02'),
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
('PN001', 'S001', 50, 50000), -- Nhập 50 cuốn Nhà giả kim
('PN001', 'S005', 30, 80000), -- Nhập 30 cuốn Lịch Sử VN
('PN002', 'S003', 100, 20000); -- Nhập 100 cuốn Toán 12
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