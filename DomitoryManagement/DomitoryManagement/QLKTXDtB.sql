USE [master]
GO
/****** Object:  Database [QLKTX]    Script Date: 01/01/2020 23:12:46 ******/
CREATE DATABASE [QLKTX]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLKTX', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QLKTX.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLKTX_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QLKTX_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QLKTX] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLKTX].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLKTX] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLKTX] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLKTX] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLKTX] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLKTX] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLKTX] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QLKTX] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QLKTX] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLKTX] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLKTX] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLKTX] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLKTX] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLKTX] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLKTX] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLKTX] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLKTX] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QLKTX] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLKTX] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLKTX] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLKTX] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLKTX] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLKTX] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLKTX] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLKTX] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLKTX] SET  MULTI_USER 
GO
ALTER DATABASE [QLKTX] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLKTX] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLKTX] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLKTX] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QLKTX]
GO
/****** Object:  Table [dbo].[BIENLAIHOANTRAPHONG]    Script Date: 01/01/2020 23:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BIENLAIHOANTRAPHONG](
	[IDBL] [int] IDENTITY(1,1) NOT NULL,
	[IDSINHVIEN] [int] NOT NULL,
	[IDHOCKI] [int] NOT NULL,
	[NGAYTRAPHONG] [nvarchar](30) NOT NULL,
	[TIENHOANTRA] [money] NOT NULL,
	[NGUOITHUNGAN] [nvarchar](max) NULL,
	[TENSINHVIEN] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDBL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BIENLAITHUEPHONG]    Script Date: 01/01/2020 23:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BIENLAITHUEPHONG](
	[IDVL] [int] IDENTITY(1,1) NOT NULL,
	[IDSINHVIEN] [int] NULL,
	[IDPHONG] [int] NULL,
	[TRANGTHAI] [bit] NULL,
	[TENNHAPHONG] [nvarchar](max) NULL,
	[LOAIPHONG] [int] NULL,
	[DADONGTIENPHONG] [bit] NULL,
	[IDHOCKI] [int] NULL,
	[TENHOCKI] [nvarchar](max) NULL,
	[NGAYVAO] [nvarchar](max) NULL,
	[NGAYTRAPHONG] [nvarchar](max) NULL,
	[GHICHU] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDVL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BIENLAITIENPHONG]    Script Date: 01/01/2020 23:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BIENLAITIENPHONG](
	[IDBL] [int] IDENTITY(1,1) NOT NULL,
	[IDSINHVIEN] [int] NULL,
	[ID_DSSV_TIENPHONG] [int] NULL,
	[IDHOCKI] [int] NULL,
	[IDPHONG] [int] NULL,
	[NGAYINBL] [varchar](30) NULL,
	[TENNGUOITHU] [nvarchar](max) NULL,
	[DONGTIENPHONG] [bit] NULL,
	[DONGTIENBHYT] [bit] NULL,
	[DONGTIENBHTN] [bit] NULL,
	[TONGTIEN] [money] NULL,
	[TIENPHONGDADONG] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDBL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CANBO]    Script Date: 01/01/2020 23:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CANBO](
	[IDCANBO] [int] IDENTITY(1,1) NOT NULL,
	[MSCB] [int] NULL,
	[HOTEN] [nvarchar](max) NULL,
	[NGAYSINH] [nvarchar](max) NULL,
	[DIACHI] [nvarchar](max) NULL,
	[CMND] [nvarchar](max) NULL,
	[SDT] [nvarchar](max) NULL,
	[GIOITINH] [bit] NULL,
	[QUOCTICH] [nvarchar](max) NULL,
	[DANTOC] [nvarchar](max) NULL,
	[NGAYVAOLAM] [nvarchar](max) NULL,
	[CHUCVU] [nvarchar](max) NULL,
	[IDUSER] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDCANBO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DANHSACHSV_PHONG]    Script Date: 01/01/2020 23:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DANHSACHSV_PHONG](
	[IDSINHVIEN] [int] NOT NULL,
	[IDPHONG] [int] NOT NULL,
	[NGAYVAO] [varchar](max) NULL,
	[NGAYRA] [varchar](max) NULL,
 CONSTRAINT [PK_DANHSACHSV_PHONG] PRIMARY KEY CLUSTERED 
(
	[IDPHONG] ASC,
	[IDSINHVIEN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DANHSACHSV_TIENPHONG]    Script Date: 01/01/2020 23:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DANHSACHSV_TIENPHONG](
	[IDSV_TIENPHONG] [int] IDENTITY(1,1) NOT NULL,
	[IDSINHVIEN] [int] NULL,
	[IDPHONG] [int] NULL,
	[TIENPHAIDONG] [money] NULL,
	[NGAYVAO] [varchar](max) NULL,
	[DADONGTIENPHONG] [bit] NULL,
	[DADONGBHYT] [bit] NULL,
	[DADONGBHTN] [bit] NULL,
	[IDHOCKI] [int] NULL,
	[TIENBHYT] [money] NULL,
	[TIENBHTN] [money] NULL,
 CONSTRAINT [PK_DANHSACHSV_TIENPHONG] PRIMARY KEY CLUSTERED 
(
	[IDSV_TIENPHONG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GIADIEN]    Script Date: 01/01/2020 23:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GIADIEN](
	[ID] [int] NOT NULL,
	[GIADIEN] [money] NOT NULL,
	[CHITIETGIA] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GIANUOC]    Script Date: 01/01/2020 23:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GIANUOC](
	[ID] [int] NOT NULL,
	[GIANUOC] [money] NOT NULL,
	[CHITIETGIA] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HOCKI]    Script Date: 01/01/2020 23:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HOCKI](
	[TENHOCKI] [nvarchar](max) NULL,
	[IDHOCKI] [int] IDENTITY(1,1) NOT NULL,
	[NGAYBATDAU] [varchar](max) NULL,
	[NGAYKETHUC] [varchar](max) NULL,
	[TENNAMHOC] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDHOCKI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PHONG]    Script Date: 01/01/2020 23:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHONG](
	[TENPHONG] [nvarchar](30) NOT NULL,
	[IDTOA] [int] NOT NULL,
	[SOLUONGNGUOI] [int] NULL,
	[LOAIPHONG] [int] NULL,
	[SOLUONGTRONG] [int] NULL,
	[IDPHONG] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_PHONG_IDPHONG] PRIMARY KEY CLUSTERED 
(
	[IDPHONG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SINHVIEN]    Script Date: 01/01/2020 23:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SINHVIEN](
	[NGAYSINH] [nvarchar](max) NULL,
	[HOTEN] [nvarchar](max) NULL,
	[CMND] [nvarchar](max) NULL,
	[SDT] [nvarchar](max) NULL,
	[MSSV] [nvarchar](max) NULL,
	[TENTRUONG] [nvarchar](max) NULL,
	[GIOITINH] [bit] NULL,
	[DIACHI] [nvarchar](max) NULL,
	[QUOCTICH] [nvarchar](20) NULL,
	[DANTOC] [nvarchar](20) NULL,
	[NGAYVAOKTX] [nvarchar](20) NULL,
	[NGAYRAKTX] [nvarchar](20) NULL,
	[SINHVIENNAM] [nvarchar](max) NULL,
	[KHOA] [nvarchar](50) NULL,
	[DATHUE] [bit] NULL,
	[IDSINHVIEN] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_SINHVIEN] PRIMARY KEY CLUSTERED 
(
	[IDSINHVIEN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIENDIENNUOC]    Script Date: 01/01/2020 23:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TIENDIENNUOC](
	[IDPHONG] [int] NOT NULL,
	[THOIGIAN] [datetime] NOT NULL,
	[CHISODIEN] [int] NOT NULL,
	[CHISONUOC] [int] NOT NULL,
	[THANHTIEN] [money] NOT NULL,
	[TINHTRANG] [bit] NULL,
	[NGAYTHU] [varchar](max) NULL,
	[IDBL] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_TIENDIENNUOC] PRIMARY KEY CLUSTERED 
(
	[THOIGIAN] ASC,
	[IDPHONG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TIENTHUEPHONG]    Script Date: 01/01/2020 23:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIENTHUEPHONG](
	[LOAIPHONG] [int] NOT NULL,
	[TIENTHUE] [money] NOT NULL,
	[SOGIUONG] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[LOAIPHONG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TOA]    Script Date: 01/01/2020 23:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TOA](
	[TENTOA] [nvarchar](30) NOT NULL,
	[SOLUONGPHONG] [varchar](4) NOT NULL,
	[TOANAM] [bit] NULL,
	[TSGIUONGTRONG] [int] NULL,
	[TSGIUONG] [int] NULL,
	[TONGDATHUE] [int] NULL,
	[IDTOA] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_TOA] PRIMARY KEY CLUSTERED 
(
	[IDTOA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 01/01/2020 23:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 01/01/2020 23:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
	[UserName] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[IdRole] [int] NOT NULL,
	[TENUSER] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[BIENLAITHUEPHONG] ADD  DEFAULT ((1)) FOR [TRANGTHAI]
GO
ALTER TABLE [dbo].[BIENLAITHUEPHONG] ADD  DEFAULT ((0)) FOR [DADONGTIENPHONG]
GO
ALTER TABLE [dbo].[BIENLAITIENPHONG] ADD  DEFAULT ((0)) FOR [DONGTIENPHONG]
GO
ALTER TABLE [dbo].[BIENLAITIENPHONG] ADD  DEFAULT ((0)) FOR [DONGTIENBHYT]
GO
ALTER TABLE [dbo].[BIENLAITIENPHONG] ADD  DEFAULT ((0)) FOR [DONGTIENBHTN]
GO
ALTER TABLE [dbo].[DANHSACHSV_TIENPHONG] ADD  DEFAULT ((0)) FOR [DADONGTIENPHONG]
GO
ALTER TABLE [dbo].[DANHSACHSV_TIENPHONG] ADD  DEFAULT ((0)) FOR [DADONGBHYT]
GO
ALTER TABLE [dbo].[DANHSACHSV_TIENPHONG] ADD  DEFAULT ((0)) FOR [DADONGBHTN]
GO
ALTER TABLE [dbo].[DANHSACHSV_TIENPHONG] ADD  DEFAULT ((457380)) FOR [TIENBHYT]
GO
ALTER TABLE [dbo].[DANHSACHSV_TIENPHONG] ADD  DEFAULT ((40000)) FOR [TIENBHTN]
GO
ALTER TABLE [dbo].[SINHVIEN] ADD  DEFAULT ((0)) FOR [DATHUE]
GO
ALTER TABLE [dbo].[BIENLAIHOANTRAPHONG]  WITH CHECK ADD  CONSTRAINT [FK_BIENLAIHOANTRAPHONG_HOCKI] FOREIGN KEY([IDHOCKI])
REFERENCES [dbo].[HOCKI] ([IDHOCKI])
GO
ALTER TABLE [dbo].[BIENLAIHOANTRAPHONG] CHECK CONSTRAINT [FK_BIENLAIHOANTRAPHONG_HOCKI]
GO
ALTER TABLE [dbo].[BIENLAIHOANTRAPHONG]  WITH CHECK ADD  CONSTRAINT [FK_BIENLAIHOANTRAPHONG_SINHVIEN] FOREIGN KEY([IDSINHVIEN])
REFERENCES [dbo].[SINHVIEN] ([IDSINHVIEN])
GO
ALTER TABLE [dbo].[BIENLAIHOANTRAPHONG] CHECK CONSTRAINT [FK_BIENLAIHOANTRAPHONG_SINHVIEN]
GO
ALTER TABLE [dbo].[BIENLAITHUEPHONG]  WITH CHECK ADD  CONSTRAINT [FK_BIENLAITHUEPHONG_HOCKI_ID] FOREIGN KEY([IDHOCKI])
REFERENCES [dbo].[HOCKI] ([IDHOCKI])
GO
ALTER TABLE [dbo].[BIENLAITHUEPHONG] CHECK CONSTRAINT [FK_BIENLAITHUEPHONG_HOCKI_ID]
GO
ALTER TABLE [dbo].[BIENLAITHUEPHONG]  WITH CHECK ADD  CONSTRAINT [FK_BIENLAITHUEPHONG_PHONG] FOREIGN KEY([IDPHONG])
REFERENCES [dbo].[PHONG] ([IDPHONG])
GO
ALTER TABLE [dbo].[BIENLAITHUEPHONG] CHECK CONSTRAINT [FK_BIENLAITHUEPHONG_PHONG]
GO
ALTER TABLE [dbo].[BIENLAITHUEPHONG]  WITH CHECK ADD  CONSTRAINT [FK_BIENLAITHUEPHONG_SINHVIEN] FOREIGN KEY([IDSINHVIEN])
REFERENCES [dbo].[SINHVIEN] ([IDSINHVIEN])
GO
ALTER TABLE [dbo].[BIENLAITHUEPHONG] CHECK CONSTRAINT [FK_BIENLAITHUEPHONG_SINHVIEN]
GO
ALTER TABLE [dbo].[BIENLAITIENPHONG]  WITH CHECK ADD  CONSTRAINT [FK_BIENLAITIENPHONG_DSSV_TIENPHONG] FOREIGN KEY([ID_DSSV_TIENPHONG])
REFERENCES [dbo].[DANHSACHSV_TIENPHONG] ([IDSV_TIENPHONG])
GO
ALTER TABLE [dbo].[BIENLAITIENPHONG] CHECK CONSTRAINT [FK_BIENLAITIENPHONG_DSSV_TIENPHONG]
GO
ALTER TABLE [dbo].[BIENLAITIENPHONG]  WITH CHECK ADD  CONSTRAINT [FK_BIENLAITIENPHONG_HOCKI] FOREIGN KEY([IDHOCKI])
REFERENCES [dbo].[HOCKI] ([IDHOCKI])
GO
ALTER TABLE [dbo].[BIENLAITIENPHONG] CHECK CONSTRAINT [FK_BIENLAITIENPHONG_HOCKI]
GO
ALTER TABLE [dbo].[BIENLAITIENPHONG]  WITH CHECK ADD  CONSTRAINT [FK_BIENLAITIENPHONG_PHONG] FOREIGN KEY([IDPHONG])
REFERENCES [dbo].[PHONG] ([IDPHONG])
GO
ALTER TABLE [dbo].[BIENLAITIENPHONG] CHECK CONSTRAINT [FK_BIENLAITIENPHONG_PHONG]
GO
ALTER TABLE [dbo].[BIENLAITIENPHONG]  WITH CHECK ADD  CONSTRAINT [FK_BIENLAITIENPHONG_SINHVIEN] FOREIGN KEY([IDSINHVIEN])
REFERENCES [dbo].[SINHVIEN] ([IDSINHVIEN])
GO
ALTER TABLE [dbo].[BIENLAITIENPHONG] CHECK CONSTRAINT [FK_BIENLAITIENPHONG_SINHVIEN]
GO
ALTER TABLE [dbo].[CANBO]  WITH CHECK ADD  CONSTRAINT [FK_CANBO_USERS] FOREIGN KEY([IDUSER])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[CANBO] CHECK CONSTRAINT [FK_CANBO_USERS]
GO
ALTER TABLE [dbo].[DANHSACHSV_PHONG]  WITH CHECK ADD  CONSTRAINT [FK_DANHSACHSV_PHONG_PHONG] FOREIGN KEY([IDPHONG])
REFERENCES [dbo].[PHONG] ([IDPHONG])
GO
ALTER TABLE [dbo].[DANHSACHSV_PHONG] CHECK CONSTRAINT [FK_DANHSACHSV_PHONG_PHONG]
GO
ALTER TABLE [dbo].[DANHSACHSV_PHONG]  WITH CHECK ADD  CONSTRAINT [FK_DANHSACHSV_PHONG_SINHVIEN] FOREIGN KEY([IDSINHVIEN])
REFERENCES [dbo].[SINHVIEN] ([IDSINHVIEN])
GO
ALTER TABLE [dbo].[DANHSACHSV_PHONG] CHECK CONSTRAINT [FK_DANHSACHSV_PHONG_SINHVIEN]
GO
ALTER TABLE [dbo].[DANHSACHSV_TIENPHONG]  WITH CHECK ADD  CONSTRAINT [FK_DANHSACHSV_TIENPHONG_DANHSACHSV_PHONG_IDPHONG] FOREIGN KEY([IDPHONG])
REFERENCES [dbo].[PHONG] ([IDPHONG])
GO
ALTER TABLE [dbo].[DANHSACHSV_TIENPHONG] CHECK CONSTRAINT [FK_DANHSACHSV_TIENPHONG_DANHSACHSV_PHONG_IDPHONG]
GO
ALTER TABLE [dbo].[DANHSACHSV_TIENPHONG]  WITH CHECK ADD  CONSTRAINT [FK_DANHSACHSV_TIENPHONG_SINHVIEN] FOREIGN KEY([IDSINHVIEN])
REFERENCES [dbo].[SINHVIEN] ([IDSINHVIEN])
GO
ALTER TABLE [dbo].[DANHSACHSV_TIENPHONG] CHECK CONSTRAINT [FK_DANHSACHSV_TIENPHONG_SINHVIEN]
GO
ALTER TABLE [dbo].[DANHSACHSV_TIENPHONG]  WITH CHECK ADD  CONSTRAINT [FK_DSSV_TIENPHONG_HOCKI] FOREIGN KEY([IDHOCKI])
REFERENCES [dbo].[HOCKI] ([IDHOCKI])
GO
ALTER TABLE [dbo].[DANHSACHSV_TIENPHONG] CHECK CONSTRAINT [FK_DSSV_TIENPHONG_HOCKI]
GO
ALTER TABLE [dbo].[PHONG]  WITH CHECK ADD  CONSTRAINT [FK_PHONG_TIENTHUEPHONG] FOREIGN KEY([LOAIPHONG])
REFERENCES [dbo].[TIENTHUEPHONG] ([LOAIPHONG])
GO
ALTER TABLE [dbo].[PHONG] CHECK CONSTRAINT [FK_PHONG_TIENTHUEPHONG]
GO
ALTER TABLE [dbo].[PHONG]  WITH CHECK ADD  CONSTRAINT [FK_PHONG_TOA] FOREIGN KEY([IDTOA])
REFERENCES [dbo].[TOA] ([IDTOA])
GO
ALTER TABLE [dbo].[PHONG] CHECK CONSTRAINT [FK_PHONG_TOA]
GO
ALTER TABLE [dbo].[TIENDIENNUOC]  WITH CHECK ADD  CONSTRAINT [FK_TIENDIENNUOC_PHONG] FOREIGN KEY([IDPHONG])
REFERENCES [dbo].[PHONG] ([IDPHONG])
GO
ALTER TABLE [dbo].[TIENDIENNUOC] CHECK CONSTRAINT [FK_TIENDIENNUOC_PHONG]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [fr_IdRow_users] FOREIGN KEY([IdRole])
REFERENCES [dbo].[UserRole] ([id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [fr_IdRow_users]
GO
USE [master]
GO
ALTER DATABASE [QLKTX] SET  READ_WRITE 
GO
