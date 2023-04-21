USE [KHOMIPHAM]
GO
/****** Object:  Table [dbo].[ChiTietHD]    Script Date: 4/21/2023 5:43:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHD](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaHD] [nchar](10) NOT NULL,
	[MaSP] [nvarchar](50) NOT NULL,
	[SLuong] [int] NOT NULL,
	[TongTien] [money] NOT NULL,
	[TrangThai] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ChiTietHD] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhSachSPh]    Script Date: 4/21/2023 5:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhSachSPh](
	[MaSP] [nvarchar](50) NOT NULL,
	[MaPhanLoai] [nvarchar](50) NOT NULL,
	[TenSP] [nvarchar](max) NOT NULL,
	[DonGia] [money] NOT NULL,
	[KhoiLuong] [nvarchar](50) NULL,
	[SoLuong] [int] NULL,
	[GioiThieu] [nvarchar](max) NULL,
	[MaThuongHieu] [nchar](10) NOT NULL,
 CONSTRAINT [PK_dbo.DanhSachSPh] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DSHoaDon]    Script Date: 4/21/2023 5:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DSHoaDon](
	[MaHD] [nchar](10) NOT NULL,
	[NgayLap] [datetime] NULL,
	[MaKH] [nchar](10) NULL,
 CONSTRAINT [PK_dbo.DSHoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DSKhachHang]    Script Date: 4/21/2023 5:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DSKhachHang](
	[MaKH] [nchar](10) NOT NULL,
	[TenKH] [nvarchar](max) NOT NULL,
	[GioiTinh] [char](1) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[SDT] [nvarchar](50) NOT NULL,
	[NgaySinh] [date] NULL,
 CONSTRAINT [PK_dbo.DSKhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DSThuongHieu]    Script Date: 4/21/2023 5:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DSThuongHieu](
	[MaThuongHieu] [nchar](10) NOT NULL,
	[TenTh] [nvarchar](max) NOT NULL,
	[XuatXu] [nvarchar](max) NOT NULL,
	[DanhGia] [nchar](10) NULL,
 CONSTRAINT [PK_dbo.DSThuongHieu] PRIMARY KEY CLUSTERED 
(
	[MaThuongHieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanLoai]    Script Date: 4/21/2023 5:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanLoai](
	[MaPhanLoai] [nvarchar](50) NOT NULL,
	[LoaiSP] [nvarchar](max) NOT NULL,
	[KhaiQuat] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.PhanLoai] PRIMARY KEY CLUSTERED 
(
	[MaPhanLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sysdiagrams]    Script Date: 4/21/2023 5:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sysdiagrams](
	[diagram_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](128) NOT NULL,
	[principal_id] [int] NOT NULL,
	[version] [int] NULL,
	[definition] [varbinary](max) NULL,
 CONSTRAINT [PK_dbo.sysdiagrams] PRIMARY KEY CLUSTERED 
(
	[diagram_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[ChiTietHD]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ChiTietHD_dbo.DSHoaDon_MaHD] FOREIGN KEY([MaHD])
REFERENCES [dbo].[DSHoaDon] ([MaHD])
GO
ALTER TABLE [dbo].[ChiTietHD] CHECK CONSTRAINT [FK_dbo.ChiTietHD_dbo.DSHoaDon_MaHD]
GO
ALTER TABLE [dbo].[DanhSachSPh]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DanhSachSPh_dbo.DSThuongHieu_MaThuongHieu] FOREIGN KEY([MaThuongHieu])
REFERENCES [dbo].[DSThuongHieu] ([MaThuongHieu])
GO
ALTER TABLE [dbo].[DanhSachSPh] CHECK CONSTRAINT [FK_dbo.DanhSachSPh_dbo.DSThuongHieu_MaThuongHieu]
GO
ALTER TABLE [dbo].[DanhSachSPh]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DanhSachSPh_dbo.PhanLoai_MaPhanLoai] FOREIGN KEY([MaPhanLoai])
REFERENCES [dbo].[PhanLoai] ([MaPhanLoai])
GO
ALTER TABLE [dbo].[DanhSachSPh] CHECK CONSTRAINT [FK_dbo.DanhSachSPh_dbo.PhanLoai_MaPhanLoai]
GO
ALTER TABLE [dbo].[DSHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DSHoaDon_dbo.DSKhachHang_MaKH] FOREIGN KEY([MaKH])
REFERENCES [dbo].[DSKhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[DSHoaDon] CHECK CONSTRAINT [FK_dbo.DSHoaDon_dbo.DSKhachHang_MaKH]
GO
