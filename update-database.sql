CREATE DATABASE test
USE test



--Tạo bảng Thể loại sản phẩm--
GO
CREATE TABLE LoaiSP
(
	MaLoaiSP VARCHAR(10) NOT NULL PRIMARY KEY,
	TenTheLoai NVARCHAR(100) NOT NULL UNIQUE
)

--Tạo bảng Khối lượng sản phẩm--
GO
CREATE TABLE KhoiLuongSP
(
	MaKhoiLuong VARCHAR(10) NOT NULL PRIMARY KEY,
	TenKhoiLuong NVARCHAR(100) NOT NULL UNIQUE
)

--Tạo bảng Nhà sản xuất--
GO
CREATE TABLE NhaSanXuat
(
	MaNhaSanXuat VARCHAR(10) NOT NULL PRIMARY KEY,
	TenNhaSanXuat NVARCHAR(100) NOT NULL UNIQUE,
	DiaChiNhaSanXuat NVARCHAR(100) NULL,
	DienThoaiNhaSanXuat VARCHAR(20)  NULL
)

--Tạo bảng Sản phẩm--
GO
CREATE TABLE SanPham
(
	MaSanPham VARCHAR(10) NOT NULL PRIMARY KEY,
	TenSanPham NVARCHAR(50) NOT NULL UNIQUE,
	MaLoaiSP VARCHAR(10) FOREIGN KEY REFERENCES LoaiSP(MaLoaiSP) NULL,
	MaKhoiLuong VARCHAR(10) FOREIGN KEY REFERENCES KhoiLuongSP(MaKhoiLuong) NULL,
	MaNhaSanXuat VARCHAR(10) FOREIGN KEY REFERENCES NhaSanXuat(MaNhaSanXuat) NULL,
	DonViTinh NVARCHAR(50) NULL,
	SoLuong INT NULL,
	SoLuongBan INT NULL,
	DonGia INT NULL ,
	MoTa NTEXT NULL,
	NgayCapNhat SMALLDATETIME NULL,
	HinhMinhHoa VARCHAR(50) NULL
)

--Tạo bảng Khách hàng--
GO
CREATE TABLE KhachHang
(
	MaKhachHang VARCHAR(10) NOT NULL PRIMARY KEY,
	TenKhachHang NVARCHAR(50) NOT NULL ,
	DiaChiKhachHang NVARCHAR(100)NULL,
	DienThoaiKhach VARCHAR(20) NULL,
	TenDangNhap VARCHAR(50) NOT NULL,
	MatKhau VARCHAR(50) NOT NULL,
	NgaySinh SMALLDATETIME NULL,
	GioiTinh BIT NOT NULL,
	Email VARCHAR(50) NULL
)
--Tạo bảng Đặt hàng
go 
create table DatHang
( 
	MaHoaDon varchar(10) not null primary key,
	MaKhachHang varchar(10) foreign key references KhachHang(MaKhachHang) null,
	TongTien int null,
	NgayDatHang SMALLDATETIME null,
	TrangThai bit

)
--Tạo bảng Chi tiết đặt hàng--
GO
CREATE TABLE ChiTietDatHang
(
	SoHoaDon VARCHAR(10) NOT NULL PRIMARY KEY,
	MaSanPham VARCHAR(10) FOREIGN KEY REFERENCES SanPham(MaSanPham) NULL,
	MaKhachHang VARCHAR(10) FOREIGN KEY REFERENCES KhachHang(MaKhachHang) NULL,
	MaHoaDon  VARCHAR(10) FOREIGN KEY REFERENCES DatHang(MaHoaDon) NULL,
	SoLuong INT NULL,
	DonGia INT NULL,
	ThanhTien INT NULL,
	NgayDatHang SMALLDATETIME NULL,
	NgayGiaoHang SMALLDATETIME NULL
)

--Tạo bảng Nhân viên--
GO
CREATE TABLE NhanVien
(
	MaNhanVien VARCHAR(10) NOT NULL PRIMARY KEY,
	TenNhanVien NVARCHAR(50) NOT NULL ,
	GioiTinh BIT NOT NULL,
	NgaySinh SMALLDATETIME NULL,
	DienThoai VARCHAR(20) NULL,
	DiaChi NVARCHAR(100) NULL
)

CREATE TABLE USERS
(
UserId INT IDENTITY PRIMARY KEY,
	UserName NVARCHAR(30) NOT NULL,
	[PassWord] NVARCHAR(30) NOT NULL,
	Email NVARCHAR(50),
	Phone NVARCHAR(20),
	Avatar NVARCHAR(100),
	Allowed INT DEFAULT(0)
)
