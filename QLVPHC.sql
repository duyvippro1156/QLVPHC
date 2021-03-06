USE [master]
GO
/****** Object:  Database [ViPhamHanhChinh]    Script Date: 8/16/2021 6:34:27 PM ******/
CREATE DATABASE [ViPhamHanhChinh]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ViPhamHanhChinh', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ViPhamHanhChinh.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ViPhamHanhChinh_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ViPhamHanhChinh_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ViPhamHanhChinh] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ViPhamHanhChinh].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ViPhamHanhChinh] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ViPhamHanhChinh] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ViPhamHanhChinh] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ViPhamHanhChinh] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ViPhamHanhChinh] SET ARITHABORT OFF 
GO
ALTER DATABASE [ViPhamHanhChinh] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ViPhamHanhChinh] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ViPhamHanhChinh] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ViPhamHanhChinh] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ViPhamHanhChinh] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ViPhamHanhChinh] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ViPhamHanhChinh] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ViPhamHanhChinh] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ViPhamHanhChinh] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ViPhamHanhChinh] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ViPhamHanhChinh] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ViPhamHanhChinh] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ViPhamHanhChinh] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ViPhamHanhChinh] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ViPhamHanhChinh] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ViPhamHanhChinh] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ViPhamHanhChinh] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ViPhamHanhChinh] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ViPhamHanhChinh] SET  MULTI_USER 
GO
ALTER DATABASE [ViPhamHanhChinh] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ViPhamHanhChinh] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ViPhamHanhChinh] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ViPhamHanhChinh] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ViPhamHanhChinh] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ViPhamHanhChinh] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ViPhamHanhChinh] SET QUERY_STORE = OFF
GO
USE [ViPhamHanhChinh]
GO
/****** Object:  UserDefinedFunction [dbo].[func_DemNguoiViPham]    Script Date: 8/16/2021 6:34:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[func_DemNguoiViPham](@maLoi char(5))
returns int
as
begin
	declare @dem int
	select @dem = count(@maLoi)
	from dbo.ThongTinBienBan
	where maLoiViPham = @maLoi
	return @dem
end

GO
/****** Object:  UserDefinedFunction [dbo].[func_DemTangVatTamGiu]    Script Date: 8/16/2021 6:34:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[func_DemTangVatTamGiu](@maBienBan varchar(5))
returns int
as
begin
	declare @demTV int
	select @demTV = count(@maBienBan)
	from dbo.ThongTinTangVatTamGiu
	where maBienBan = @maBienBan
	return @demTV
end
GO
/****** Object:  UserDefinedFunction [dbo].[func_DSNguoiViPham]    Script Date: 8/16/2021 6:34:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[func_DSNguoiViPham](@soCMND char(9))
returns nvarchar(200)
as
begin
	declare @hoTen nvarchar(200)
	select @hoTen = hoTen
	from dbo.NguoiViPham
	where soCMND = @soCMND
	return @hoTen
end

GO
/****** Object:  UserDefinedFunction [dbo].[func_TangVatTamGiu]    Script Date: 8/16/2021 6:34:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Function hiển thị tình trạng hoàn trả tang vật dựa vào biên bản */
CREATE function [dbo].[func_TangVatTamGiu](@maBienBan varchar(5))
returns bit
as
begin
	declare @tinhTrangHoanTra bit
	select @tinhTrangHoanTra = tinhTrangHoanTra
	from dbo.ThongTinTangVatTamGiu
	where maBienBan = @maBienBan
	return @tinhTrangHoanTra
end
GO
/****** Object:  UserDefinedFunction [dbo].[func_TTNopPhatTheoBB]    Script Date: 8/16/2021 6:34:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Function xem tình trạng nộp phạt theo mã biên bản*/
CREATE function [dbo].[func_TTNopPhatTheoBB](@maBB varchar(5))
returns nvarchar(20)
as
begin
	declare @tinhtrang nvarchar(20) 
	select @tinhtrang  = tinhTrangNopPhat
	from dbo.TTBienLai 
	where maBienBan = @maBB
	return @tinhtrang
end
GO
/****** Object:  Table [dbo].[NguoiViPham]    Script Date: 8/16/2021 6:34:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiViPham](
	[soCMND] [char](9) NOT NULL,
	[hoTen] [nvarchar](200) NULL,
	[gioiTinh] [bit] NULL,
	[ngaySinh] [date] NULL,
	[soDienThoai] [char](10) NULL,
	[diaChi] [nvarchar](200) NULL,
	[quocTich] [nvarchar](100) NULL,
 CONSTRAINT [PK_NguoiViPham] PRIMARY KEY CLUSTERED 
(
	[soCMND] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[LayNguoiViPhamView]    Script Date: 8/16/2021 6:34:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[LayNguoiViPhamView]
as
select * from NguoiViPham

GO
/****** Object:  Table [dbo].[ThongTinBienBan]    Script Date: 8/16/2021 6:34:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongTinBienBan](
	[maBienBan] [varchar](5) NOT NULL,
	[soCMND] [char](9) NULL,
	[bienSoXe] [varchar](100) NULL,
	[giayPhepLaiXe] [nvarchar](100) NULL,
	[maLoiViPham] [char](5) NULL,
	[diaDiemViPham] [nvarchar](200) NULL,
	[ngayViPham] [date] NULL,
	[maThanhTra] [int] NULL,
	[tangVatTamGiu] [nvarchar](200) NULL,
 CONSTRAINT [PK_ThongTinBienBan] PRIMARY KEY CLUSTERED 
(
	[maBienBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[LayTTBienBanView]    Script Date: 8/16/2021 6:34:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[LayTTBienBanView]
as
select * from ThongTinBienBan
GO
/****** Object:  Table [dbo].[MucPhat]    Script Date: 8/16/2021 6:34:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MucPhat](
	[maLoi] [char](5) NOT NULL,
	[tenLoi] [nvarchar](200) NULL,
	[soTienPhat] [decimal](18, 0) NULL,
 CONSTRAINT [PK_MucPhat] PRIMARY KEY CLUSTERED 
(
	[maLoi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 8/16/2021 6:34:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[maSo] [int] IDENTITY(1,1) NOT NULL,
	[hoTen] [nvarchar](100) NULL,
	[gioiTinh] [bit] NULL,
	[ngaySinh] [date] NULL,
	[soCMND] [char](9) NULL,
	[soDienThoai] [char](10) NULL,
	[email] [nvarchar](100) NULL,
	[donVi] [nvarchar](100) NULL,
	[diaChi] [nvarchar](200) NULL,
	[taiKhoan] [varchar](50) NOT NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[maSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 8/16/2021 6:34:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[tenTaiKhoan] [varchar](50) NOT NULL,
	[matKhau] [varchar](50) NULL,
	[quyen] [int] NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[tenTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThongTinTangVatTamGiu]    Script Date: 8/16/2021 6:34:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongTinTangVatTamGiu](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[maBienBan] [varchar](5) NOT NULL,
	[tinhTrangHoanTra] [bit] NULL,
	[ngayHoanTra] [date] NULL,
 CONSTRAINT [PK_ThongTinTangVatTamGiu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TTBienLai]    Script Date: 8/16/2021 6:34:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTBienLai](
	[maBienLai] [int] IDENTITY(1,1) NOT NULL,
	[ngayXuat] [date] NULL,
	[maBienBan] [varchar](5) NULL,
	[tinhTrangNopPhat] [nvarchar](10) NULL,
 CONSTRAINT [PK_TTBienLai] PRIMARY KEY CLUSTERED 
(
	[maBienLai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[MucPhat] ([maLoi], [tenLoi], [soTienPhat]) VALUES (N'L1   ', N'Không đội mũ bảo hiểm', CAST(200000 AS Decimal(18, 0)))
INSERT [dbo].[MucPhat] ([maLoi], [tenLoi], [soTienPhat]) VALUES (N'L2   ', N'Vượt tốc độ', CAST(500000 AS Decimal(18, 0)))
INSERT [dbo].[MucPhat] ([maLoi], [tenLoi], [soTienPhat]) VALUES (N'L3   ', N'Vượt đèn đỏ', CAST(300000 AS Decimal(18, 0)))
INSERT [dbo].[MucPhat] ([maLoi], [tenLoi], [soTienPhat]) VALUES (N'L4   ', N'Không mang giấy tờ xe', CAST(1000000 AS Decimal(18, 0)))
GO
INSERT [dbo].[NguoiViPham] ([soCMND], [hoTen], [gioiTinh], [ngaySinh], [soDienThoai], [diaChi], [quocTich]) VALUES (N'131238764', N'A', 1, CAST(N'2021-08-07' AS Date), N'1231231231', N'abc', N'1231312')
INSERT [dbo].[NguoiViPham] ([soCMND], [hoTen], [gioiTinh], [ngaySinh], [soDienThoai], [diaChi], [quocTich]) VALUES (N'152648554', N'Ngô Thuỵ Vân', 0, CAST(N'1999-10-08' AS Date), N'0955254648', N'Đà Nẵng', N'Việt Nam')
INSERT [dbo].[NguoiViPham] ([soCMND], [hoTen], [gioiTinh], [ngaySinh], [soDienThoai], [diaChi], [quocTich]) VALUES (N'155682547', N'Hồ Văn Hưng', 1, CAST(N'1998-11-05' AS Date), N'0561656556', N'Quảng Trị', N'Việt Nam')
INSERT [dbo].[NguoiViPham] ([soCMND], [hoTen], [gioiTinh], [ngaySinh], [soDienThoai], [diaChi], [quocTich]) VALUES (N'156584997', N'Lê Thị Tuyết', 0, CAST(N'2000-08-13' AS Date), N'0565896546', N'Bình Định', N'Việt Nam')
INSERT [dbo].[NguoiViPham] ([soCMND], [hoTen], [gioiTinh], [ngaySinh], [soDienThoai], [diaChi], [quocTich]) VALUES (N'178274738', N'Ngô Lê Tuấn', 1, CAST(N'1993-07-16' AS Date), N'0996775841', N'Quảng Bình', N'Việt Nam')
INSERT [dbo].[NguoiViPham] ([soCMND], [hoTen], [gioiTinh], [ngaySinh], [soDienThoai], [diaChi], [quocTich]) VALUES (N'178289012', N'Mai Anh Tài', 1, CAST(N'2000-02-17' AS Date), N'0973892901', N'Thừa Thiên Huế', N'Việt Nam')
GO
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([maSo], [hoTen], [gioiTinh], [ngaySinh], [soCMND], [soDienThoai], [email], [donVi], [diaChi], [taiKhoan]) VALUES (1, N'Nguyễn Anh Tài', 1, CAST(N'1987-02-19' AS Date), N'122654574', N'0255654614', N'duyanh@gmail.com', N'Công an quận Ngũ Hành Sơn', N'Đà Nẵng', N'anhtai')
INSERT [dbo].[NhanVien] ([maSo], [hoTen], [gioiTinh], [ngaySinh], [soCMND], [soDienThoai], [email], [donVi], [diaChi], [taiKhoan]) VALUES (3, N'Huỳnh Thị Linh', 0, CAST(N'1989-08-12' AS Date), N'128615466', N'0168484846', N'huynhanh@gmail.com', N'Kho bạc quận Sơn Trà', N'Đà Nẵng', N'linhhuynh')
INSERT [dbo].[NhanVien] ([maSo], [hoTen], [gioiTinh], [ngaySinh], [soCMND], [soDienThoai], [email], [donVi], [diaChi], [taiKhoan]) VALUES (5, N'Nguyễn Mai Anh', 0, CAST(N'1988-11-20' AS Date), N'125489686', N'0548454156', N'maianh@gmail.com', N'Công an quận Nam Vang', N'Huế', N'maianh')
INSERT [dbo].[NhanVien] ([maSo], [hoTen], [gioiTinh], [ngaySinh], [soCMND], [soDienThoai], [email], [donVi], [diaChi], [taiKhoan]) VALUES (7, N'Lê Duy Mỹ', 1, CAST(N'1990-12-05' AS Date), N'124564652', N'0156481688', N'duymy@gmail.com', N'Công an quận Hải Châu', N'Quảng Trị', N'myduy')
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
GO
INSERT [dbo].[TaiKhoan] ([tenTaiKhoan], [matKhau], [quyen]) VALUES (N'anhtai', N'HUoV/kfVVFCoHkdsmMtnYQ==', 1)
INSERT [dbo].[TaiKhoan] ([tenTaiKhoan], [matKhau], [quyen]) VALUES (N'linhhuynh', N'HUoV/kfVVFCoHkdsmMtnYQ==', 0)
INSERT [dbo].[TaiKhoan] ([tenTaiKhoan], [matKhau], [quyen]) VALUES (N'maianh', N'HUoV/kfVVFCoHkdsmMtnYQ==', 2)
INSERT [dbo].[TaiKhoan] ([tenTaiKhoan], [matKhau], [quyen]) VALUES (N'myduy', N'HUoV/kfVVFCoHkdsmMtnYQ==', 1)
GO
INSERT [dbo].[ThongTinBienBan] ([maBienBan], [soCMND], [bienSoXe], [giayPhepLaiXe], [maLoiViPham], [diaDiemViPham], [ngayViPham], [maThanhTra], [tangVatTamGiu]) VALUES (N'BB1', N'152648554', N'LH-32 254.18', N'123123123', N'L1   ', N'Đường CMT8, Hải Châu', CAST(N'2021-10-09' AS Date), 1, N'Xe máy màu đen, trắng')
INSERT [dbo].[ThongTinBienBan] ([maBienBan], [soCMND], [bienSoXe], [giayPhepLaiXe], [maLoiViPham], [diaDiemViPham], [ngayViPham], [maThanhTra], [tangVatTamGiu]) VALUES (N'BB2', N'155682547', N'LB-12 782.12', N'Không có', N'L2   ', N'Đường Thanh Hải, Hải Châu', CAST(N'2021-10-09' AS Date), 5, N'Xe máy màu hồng, cam')
INSERT [dbo].[ThongTinBienBan] ([maBienBan], [soCMND], [bienSoXe], [giayPhepLaiXe], [maLoiViPham], [diaDiemViPham], [ngayViPham], [maThanhTra], [tangVatTamGiu]) VALUES (N'BB3', N'156584997', N'HN-34 902.34', N'Không có', N'L3   ', N'Đường Ông Ích Khiêm, Hải Chau', CAST(N'2021-09-12' AS Date), 7, N'Xe máy màu xanh')
INSERT [dbo].[ThongTinBienBan] ([maBienBan], [soCMND], [bienSoXe], [giayPhepLaiXe], [maLoiViPham], [diaDiemViPham], [ngayViPham], [maThanhTra], [tangVatTamGiu]) VALUES (N'BB4', N'178289012', N'LP-32 781.12', N'Không có', N'L1   ', N'Đường 3/2, Hải Châu', CAST(N'2021-05-09' AS Date), 5, N'Xe máy màu trắng, xám')
GO
SET IDENTITY_INSERT [dbo].[ThongTinTangVatTamGiu] ON 

INSERT [dbo].[ThongTinTangVatTamGiu] ([id], [maBienBan], [tinhTrangHoanTra], [ngayHoanTra]) VALUES (1, N'BB1', 0, CAST(N'2021-08-21' AS Date))
SET IDENTITY_INSERT [dbo].[ThongTinTangVatTamGiu] OFF
GO
SET IDENTITY_INSERT [dbo].[TTBienLai] ON 

INSERT [dbo].[TTBienLai] ([maBienLai], [ngayXuat], [maBienBan], [tinhTrangNopPhat]) VALUES (1, CAST(N'2021-08-18' AS Date), N'BB1', N'Đã nộp')
INSERT [dbo].[TTBienLai] ([maBienLai], [ngayXuat], [maBienBan], [tinhTrangNopPhat]) VALUES (6, CAST(N'2021-08-16' AS Date), N'BB2', N'Đã nộp')
INSERT [dbo].[TTBienLai] ([maBienLai], [ngayXuat], [maBienBan], [tinhTrangNopPhat]) VALUES (7, CAST(N'2021-08-16' AS Date), N'BB3', N'Đã nộp')
INSERT [dbo].[TTBienLai] ([maBienLai], [ngayXuat], [maBienBan], [tinhTrangNopPhat]) VALUES (8, NULL, N'BB4', NULL)
SET IDENTITY_INSERT [dbo].[TTBienLai] OFF
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_TaiKhoan] FOREIGN KEY([taiKhoan])
REFERENCES [dbo].[TaiKhoan] ([tenTaiKhoan])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_TaiKhoan]
GO
ALTER TABLE [dbo].[ThongTinBienBan]  WITH CHECK ADD  CONSTRAINT [FK_ThongTinBienBan_MucPhat] FOREIGN KEY([maLoiViPham])
REFERENCES [dbo].[MucPhat] ([maLoi])
GO
ALTER TABLE [dbo].[ThongTinBienBan] CHECK CONSTRAINT [FK_ThongTinBienBan_MucPhat]
GO
ALTER TABLE [dbo].[ThongTinBienBan]  WITH CHECK ADD  CONSTRAINT [FK_ThongTinBienBan_NguoiViPham] FOREIGN KEY([soCMND])
REFERENCES [dbo].[NguoiViPham] ([soCMND])
GO
ALTER TABLE [dbo].[ThongTinBienBan] CHECK CONSTRAINT [FK_ThongTinBienBan_NguoiViPham]
GO
ALTER TABLE [dbo].[ThongTinBienBan]  WITH CHECK ADD  CONSTRAINT [FK_ThongTinBienBan_NhanVien] FOREIGN KEY([maThanhTra])
REFERENCES [dbo].[NhanVien] ([maSo])
GO
ALTER TABLE [dbo].[ThongTinBienBan] CHECK CONSTRAINT [FK_ThongTinBienBan_NhanVien]
GO
ALTER TABLE [dbo].[ThongTinTangVatTamGiu]  WITH CHECK ADD  CONSTRAINT [FK_ThongTinTangVatTamGiu_ThongTinBienBan] FOREIGN KEY([maBienBan])
REFERENCES [dbo].[ThongTinBienBan] ([maBienBan])
GO
ALTER TABLE [dbo].[ThongTinTangVatTamGiu] CHECK CONSTRAINT [FK_ThongTinTangVatTamGiu_ThongTinBienBan]
GO
ALTER TABLE [dbo].[TTBienLai]  WITH CHECK ADD  CONSTRAINT [FK_TTBienLai_ThongTinBienBan] FOREIGN KEY([maBienBan])
REFERENCES [dbo].[ThongTinBienBan] ([maBienBan])
GO
ALTER TABLE [dbo].[TTBienLai] CHECK CONSTRAINT [FK_TTBienLai_ThongTinBienBan]
GO
/****** Object:  StoredProcedure [dbo].[LayNguoiViPham]    Script Date: 8/16/2021 6:34:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[LayNguoiViPham]
as
begin
SET NOCOUNT ON;
select * from LayNguoiViPhamView
end

GO
/****** Object:  StoredProcedure [dbo].[LayThongTinBienLai]    Script Date: 8/16/2021 6:34:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[LayThongTinBienLai]
@maBienBan int
as
begin
SET NOCOUNT ON;
select * from TTBienLai
left join ThongTinBienBan on ThongTinBienBan.maBienBan = TTBienLai.maBienBan
where TTBienLai.maBienBan = @maBienBan
end
GO
/****** Object:  StoredProcedure [dbo].[LayThongTinCaNhan]    Script Date: 8/16/2021 6:34:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[LayThongTinCaNhan]
@taikhoan varchar(50)
as
begin
SET NOCOUNT ON;
select * from NhanVien
left join TaiKhoan on TaiKhoan.tenTaiKhoan = NhanVien.taiKhoan
where NhanVien.taiKhoan = @taikhoan
end
GO
/****** Object:  StoredProcedure [dbo].[LayTTBienBan]    Script Date: 8/16/2021 6:34:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[LayTTBienBan]
as
begin
SET NOCOUNT ON;
select * from LayTTBienBanView
end
GO
/****** Object:  StoredProcedure [dbo].[pro_BienBanTangVatDaHoanTra]    Script Date: 8/16/2021 6:34:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[pro_BienBanTangVatDaHoanTra]
@tinhTrangHoanTra bit
as 
begin 
	select bd.maBienBan,nvp.hoTen,bd.soCMND
	from dbo.ThongTinBienBan  bd
	inner join dbo.ThongTinTangVatTamGiu tv
	on bd.maBienBan = tv.maBienBan
	inner join dbo.NguoiViPham nvp
	on bd.soCMND = nvp.soCMND
	where tv.tinhTrangHoanTra = 1
end

GO
/****** Object:  StoredProcedure [dbo].[pro_DSBienBanNgay]    Script Date: 8/16/2021 6:34:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[pro_DSBienBanNgay]
@ngayvipham date
as
begin
	select *
	from dbo.ThongTinBienBan
	where ngayViPham = @ngayvipham
end

GO
/****** Object:  StoredProcedure [dbo].[pro_TTNhanVienTheoDV]    Script Date: 8/16/2021 6:34:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[pro_TTNhanVienTheoDV]
@donvi nvarchar(100)
as 
begin 
	select *
	from dbo.NhanVien
	where donvi=@donvi
end
GO
/****** Object:  StoredProcedure [dbo].[proc_DSTangVatTheoTG]    Script Date: 8/16/2021 6:34:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[proc_DSTangVatTheoTG]
@thoiGian date
as
begin
	select T.maBienBan, T.ngayHoanTra, B.tangVatTamGiu
	from [dbo].[ThongTinTangVatTamGiu]  as T, [dbo].[ThongTinBienBan] as B
	where T.ngayHoanTra = @thoiGian and B.maBienBan = T.maBienBan
end
GO
/****** Object:  StoredProcedure [dbo].[proc_TTNguoiVPTheoLoi]    Script Date: 8/16/2021 6:34:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[proc_TTNguoiVPTheoLoi]
@maloi char(5)
as
begin
	select N.*, T.maLoiViPham
	from  [dbo].[NguoiViPham] as N, [dbo].[ThongTinBienBan] as T
	where T.maLoiViPham = @maloi and N.soCMND = T.soCMND	
end
GO
/****** Object:  StoredProcedure [dbo].[proc_TTNhanVienTheoDV]    Script Date: 8/16/2021 6:34:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[proc_TTNhanVienTheoDV]
@donvi nvarchar(100)
as 
begin 
	select *
	from dbo.NhanVien
	where donvi=@donvi
end
GO
/****** Object:  StoredProcedure [dbo].[SuaNguoiViPham]    Script Date: 8/16/2021 6:34:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SuaNguoiViPham]
@CMND char(9),
@hoTen nvarchar(200),
@gioiTinh bit,
@ngaySinh date,
@sdt char(10),
@diaChi nvarchar(200),
@quocTich nvarchar(100)
as
begin
SET NOCOUNT ON;
update NguoiViPham set
hoTen=@hoTen,
gioiTinh=@gioiTinh,
ngaySinh=@ngaySinh,
soDienThoai=@sdt,
diaChi=@diaChi,
quocTich=@quocTich
where
soCMND=@CMND
end

GO
/****** Object:  StoredProcedure [dbo].[SuaThongTinCaNhan]    Script Date: 8/16/2021 6:34:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SuaThongTinCaNhan]
@CMND char(9),
@hoTen nvarchar(100),
@gioiTinh bit,
@ngaySinh date,
@email nvarchar(100),
@sdt char(10),
@diaChi nvarchar(200),
@donVi nvarchar(100),
@taiKhoan varchar(50)
as
begin
SET NOCOUNT ON;
update NhanVien set
hoTen=@hoTen,
gioiTinh=@gioiTinh,
ngaySinh=@ngaySinh,
soCMND=@CMND,
email=@email,
soDienThoai=@sdt,
diaChi=@diaChi,
donVi=@donVi
where
taiKhoan=@taiKhoan
end

GO
/****** Object:  StoredProcedure [dbo].[TimBienBan]    Script Date: 8/16/2021 6:34:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Tìm biên bản
create proc [dbo].[TimBienBan]
@bienSoXe varchar(100)
as
begin
select * from ThongTinBienBan where bienSoXe like '%' +@bienSoXe+'%'
end

GO
/****** Object:  StoredProcedure [dbo].[TimBienBanCMND]    Script Date: 8/16/2021 6:34:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Tìm biên bản với số chứng minh nhân dân
create proc [dbo].[TimBienBanCMND]
@soCMND char(9)
as
begin
select * from ThongTinBienBan where soCMND like '%' +@soCMND+'%'
end

GO
/****** Object:  StoredProcedure [dbo].[TimNguoiViPham]    Script Date: 8/16/2021 6:34:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[TimNguoiViPham]
@CMND char(9)
as
begin
select * from NguoiViPham where soCMND like '%' +@CMND+'%'
end

GO
/****** Object:  StoredProcedure [dbo].[XacNhanBienLai]    Script Date: 8/16/2021 6:34:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[XacNhanBienLai]
@maBienBan varchar(5)
as
begin
SET NOCOUNT ON;
update TTBienLai set
ngayXuat=GETDATE(),
tinhTrangNopPhat=N'Đã nộp'
where
maBienBan=@maBienBan
end

GO
/****** Object:  StoredProcedure [dbo].[XemChiTietBienBan]    Script Date: 8/16/2021 6:34:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[XemChiTietBienBan]
@maBienBan char(5)
as
begin
SET NOCOUNT ON;
select * from ThongTinBienBan where maBienBan = @maBienBan
end
GO
/****** Object:  StoredProcedure [dbo].[XoaNguoiViPham]    Script Date: 8/16/2021 6:34:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[XoaNguoiViPham]
@CMND char(9)
as
begin
SET NOCOUNT ON;
delete from NguoiViPham
where soCMND=@CMND
end

GO
/****** Object:  StoredProcedure [dbo].[XoaTTBienBan]    Script Date: 8/16/2021 6:34:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[XoaTTBienBan]
@maBienBan char(5)
as
begin
SET NOCOUNT ON;
delete from ThongTinBienBan where maBienBan=@maBienBan
end
GO
USE [master]
GO
ALTER DATABASE [ViPhamHanhChinh] SET  READ_WRITE 
GO
