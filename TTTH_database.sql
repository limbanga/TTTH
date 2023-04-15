USE [master]
GO
/****** Object:  Database [TTTH]    Script Date: 11/03/2023 19:54:12 ******/
CREATE DATABASE [TTTH]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TTTH', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TTTH.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TTTH_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TTTH_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TTTH] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TTTH].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TTTH] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TTTH] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TTTH] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TTTH] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TTTH] SET ARITHABORT OFF 
GO
ALTER DATABASE [TTTH] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [TTTH] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TTTH] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TTTH] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TTTH] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TTTH] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TTTH] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TTTH] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TTTH] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TTTH] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TTTH] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TTTH] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TTTH] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TTTH] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TTTH] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TTTH] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TTTH] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TTTH] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TTTH] SET  MULTI_USER 
GO
ALTER DATABASE [TTTH] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TTTH] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TTTH] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TTTH] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TTTH] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TTTH] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TTTH] SET QUERY_STORE = OFF
GO
USE [TTTH]
GO
/****** Object:  Table [dbo].[TTTH_class]    Script Date: 11/03/2023 19:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTTH_class](
	[_id] [int] IDENTITY(1,1) NOT NULL,
	[_class_name] [nvarchar](100) NULL,
	[_start_day] [date] NULL,
	[_end_day] [date] NULL,
	[_capacity] [int] NULL,
	[_course_id] [int] NULL,
	[_room_id] [int] NULL,
	[_shift] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TTTH_course]    Script Date: 11/03/2023 19:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTTH_course](
	[_id] [int] IDENTITY(1,1) NOT NULL,
	[_course_name] [nvarchar](50) NULL,
	[_price] [float] NULL,
	[_length] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TTTH_notification]    Script Date: 11/03/2023 19:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTTH_notification](
	[_id] [int] IDENTITY(1,1) NOT NULL,
	[_topic] [nvarchar](100) NOT NULL,
	[_content] [nvarchar](max) NULL,
	[_created_date] [date] NULL,
	[_user_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TTTH_permission]    Script Date: 11/03/2023 19:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTTH_permission](
	[_id] [int] IDENTITY(1,1) NOT NULL,
	[_detail] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TTTH_permission_group]    Script Date: 11/03/2023 19:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTTH_permission_group](
	[_id] [int] IDENTITY(1,1) NOT NULL,
	[_permission_name] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TTTH_register]    Script Date: 11/03/2023 19:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTTH_register](
	[_student_id] [int] NOT NULL,
	[_class_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[_student_id] ASC,
	[_class_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TTTH_room]    Script Date: 11/03/2023 19:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTTH_room](
	[_id] [int] IDENTITY(1,1) NOT NULL,
	[_room_name] [nvarchar](50) NULL,
	[_capacity] [int] NULL,
	[_room_type] [nchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TTTH_student]    Script Date: 11/03/2023 19:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTTH_student](
	[_id] [int] IDENTITY(1,1) NOT NULL,
	[_phone_number] [varchar](20) NULL,
	[_student_name] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TTTH_user]    Script Date: 11/03/2023 19:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTTH_user](
	[_id] [int] IDENTITY(1,1) NOT NULL,
	[_user_name] [varchar](30) NOT NULL,
	[_pass_word] [varchar](50) NOT NULL,
	[_show_name] [nvarchar](50) NOT NULL,
	[_email] [varchar](50) NULL,
	[_phone_number] [varchar](15) NULL,
	[_address] [nvarchar](200) NULL,
	[_permission_group_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TTTH_class] ON 

INSERT [dbo].[TTTH_class] ([_id], [_class_name], [_start_day], [_end_day], [_capacity], [_course_id], [_room_id], [_shift]) VALUES (14, N'a', CAST(N'2022-11-03' AS Date), CAST(N'2023-11-03' AS Date), 23, 3, 4, 3)
INSERT [dbo].[TTTH_class] ([_id], [_class_name], [_start_day], [_end_day], [_capacity], [_course_id], [_room_id], [_shift]) VALUES (15, N'dfg', CAST(N'2001-12-12' AS Date), CAST(N'2003-03-03' AS Date), 50, 3, NULL, 5)
INSERT [dbo].[TTTH_class] ([_id], [_class_name], [_start_day], [_end_day], [_capacity], [_course_id], [_room_id], [_shift]) VALUES (16, N'teen lop ne', CAST(N'2002-02-20' AS Date), CAST(N'2003-03-14' AS Date), 56, 3, NULL, 1)
INSERT [dbo].[TTTH_class] ([_id], [_class_name], [_start_day], [_end_day], [_capacity], [_course_id], [_room_id], [_shift]) VALUES (17, N'sửa lại tên nè', CAST(N'2023-02-25' AS Date), CAST(N'2023-02-25' AS Date), 46, 3, 13, 4)
INSERT [dbo].[TTTH_class] ([_id], [_class_name], [_start_day], [_end_day], [_capacity], [_course_id], [_room_id], [_shift]) VALUES (18, N'Tên lớp', CAST(N'2023-02-26' AS Date), CAST(N'2023-02-26' AS Date), 45, 8, NULL, 1)
INSERT [dbo].[TTTH_class] ([_id], [_class_name], [_start_day], [_end_day], [_capacity], [_course_id], [_room_id], [_shift]) VALUES (20, N'Tên lớp móadfà', CAST(N'2023-02-26' AS Date), CAST(N'2023-02-26' AS Date), 45, 3, NULL, 1)
INSERT [dbo].[TTTH_class] ([_id], [_class_name], [_start_day], [_end_day], [_capacity], [_course_id], [_room_id], [_shift]) VALUES (22, N'Tên lớp', CAST(N'2023-02-27' AS Date), CAST(N'2023-02-27' AS Date), 45, 3, NULL, 1)
INSERT [dbo].[TTTH_class] ([_id], [_class_name], [_start_day], [_end_day], [_capacity], [_course_id], [_room_id], [_shift]) VALUES (23, N'nhìn đây nè', CAST(N'2023-02-28' AS Date), CAST(N'2023-02-28' AS Date), 60, 3, NULL, 1)
INSERT [dbo].[TTTH_class] ([_id], [_class_name], [_start_day], [_end_day], [_capacity], [_course_id], [_room_id], [_shift]) VALUES (24, N'Học phôtshop cung lim', CAST(N'2023-02-28' AS Date), CAST(N'2023-02-28' AS Date), 45, 13, NULL, 2)
INSERT [dbo].[TTTH_class] ([_id], [_class_name], [_start_day], [_end_day], [_capacity], [_course_id], [_room_id], [_shift]) VALUES (25, N'Tên lớp moi tao bang form', CAST(N'2023-02-25' AS Date), CAST(N'2023-02-25' AS Date), 45, 3, NULL, 1)
INSERT [dbo].[TTTH_class] ([_id], [_class_name], [_start_day], [_end_day], [_capacity], [_course_id], [_room_id], [_shift]) VALUES (26, N'Tên lớp moi tao bang form', CAST(N'2023-02-25' AS Date), CAST(N'2023-02-25' AS Date), 45, 23, NULL, 1)
INSERT [dbo].[TTTH_class] ([_id], [_class_name], [_start_day], [_end_day], [_capacity], [_course_id], [_room_id], [_shift]) VALUES (27, N'Tên lớp móadfà', CAST(N'2023-02-26' AS Date), CAST(N'2023-02-26' AS Date), 45, 24, NULL, 1)
INSERT [dbo].[TTTH_class] ([_id], [_class_name], [_start_day], [_end_day], [_capacity], [_course_id], [_room_id], [_shift]) VALUES (28, N'Tên lớp moi tao bang form', CAST(N'2023-02-25' AS Date), CAST(N'2023-02-25' AS Date), 45, 25, NULL, 1)
INSERT [dbo].[TTTH_class] ([_id], [_class_name], [_start_day], [_end_day], [_capacity], [_course_id], [_room_id], [_shift]) VALUES (29, N'Tên lớp moi tao bang form', CAST(N'2023-02-25' AS Date), CAST(N'2023-02-25' AS Date), 45, 26, NULL, 1)
INSERT [dbo].[TTTH_class] ([_id], [_class_name], [_start_day], [_end_day], [_capacity], [_course_id], [_room_id], [_shift]) VALUES (36, N'xxx', CAST(N'2020-02-22' AS Date), CAST(N'2020-02-22' AS Date), 222, 10, 8, 5)
INSERT [dbo].[TTTH_class] ([_id], [_class_name], [_start_day], [_end_day], [_capacity], [_course_id], [_room_id], [_shift]) VALUES (37, N'xxx', CAST(N'2020-02-22' AS Date), CAST(N'2020-02-22' AS Date), 222, 10, 8, 5)
INSERT [dbo].[TTTH_class] ([_id], [_class_name], [_start_day], [_end_day], [_capacity], [_course_id], [_room_id], [_shift]) VALUES (40, N'Tên lớp', CAST(N'2023-02-28' AS Date), CAST(N'2023-02-28' AS Date), 45, 8, 7, 2)
INSERT [dbo].[TTTH_class] ([_id], [_class_name], [_start_day], [_end_day], [_capacity], [_course_id], [_room_id], [_shift]) VALUES (42, N'sua roi ne', CAST(N'2023-03-08' AS Date), CAST(N'2023-03-08' AS Date), 42, 8, 4, 5)
INSERT [dbo].[TTTH_class] ([_id], [_class_name], [_start_day], [_end_day], [_capacity], [_course_id], [_room_id], [_shift]) VALUES (43, N'liemm33', CAST(N'2023-03-08' AS Date), CAST(N'2023-03-08' AS Date), 45, 10, 12, 2)
INSERT [dbo].[TTTH_class] ([_id], [_class_name], [_start_day], [_end_day], [_capacity], [_course_id], [_room_id], [_shift]) VALUES (44, N'Tên lớp1a', CAST(N'2023-03-10' AS Date), CAST(N'2023-03-10' AS Date), 45, 7, 4, 1)
INSERT [dbo].[TTTH_class] ([_id], [_class_name], [_start_day], [_end_day], [_capacity], [_course_id], [_room_id], [_shift]) VALUES (45, N'lop hoc moi chat', CAST(N'2023-03-10' AS Date), CAST(N'2023-03-10' AS Date), 45, 3, 4, 1)
SET IDENTITY_INSERT [dbo].[TTTH_class] OFF
GO
SET IDENTITY_INSERT [dbo].[TTTH_course] ON 

INSERT [dbo].[TTTH_course] ([_id], [_course_name], [_price], [_length]) VALUES (3, N'a', 995555551, 991)
INSERT [dbo].[TTTH_course] ([_id], [_course_name], [_price], [_length]) VALUES (7, N'1fdg', 3, 99)
INSERT [dbo].[TTTH_course] ([_id], [_course_name], [_price], [_length]) VALUES (8, N'khóa học mới nè', 231, 17)
INSERT [dbo].[TTTH_course] ([_id], [_course_name], [_price], [_length]) VALUES (9, N'1', 4, 1)
INSERT [dbo].[TTTH_course] ([_id], [_course_name], [_price], [_length]) VALUES (10, N'Tin học cho trẻ', 30000, 30)
INSERT [dbo].[TTTH_course] ([_id], [_course_name], [_price], [_length]) VALUES (11, N'Tin học văn phòng', 40000, 45)
INSERT [dbo].[TTTH_course] ([_id], [_course_name], [_price], [_length]) VALUES (12, N'Thiết kế powerpoint', 40000, 60)
INSERT [dbo].[TTTH_course] ([_id], [_course_name], [_price], [_length]) VALUES (13, N'Photoshop', 49000, 60)
INSERT [dbo].[TTTH_course] ([_id], [_course_name], [_price], [_length]) VALUES (14, N'Sửa chửa máy tính', 50000, 75)
INSERT [dbo].[TTTH_course] ([_id], [_course_name], [_price], [_length]) VALUES (15, N'Excel nâng cao', 50000, 40)
INSERT [dbo].[TTTH_course] ([_id], [_course_name], [_price], [_length]) VALUES (16, N'Lập trình cơ bản', 30000, 60)
INSERT [dbo].[TTTH_course] ([_id], [_course_name], [_price], [_length]) VALUES (17, N'Khoa hoc them tu form432', 324, 21)
INSERT [dbo].[TTTH_course] ([_id], [_course_name], [_price], [_length]) VALUES (18, N'test chức năng thêm khóa học', 234124, 3245)
INSERT [dbo].[TTTH_course] ([_id], [_course_name], [_price], [_length]) VALUES (19, N'áđac', 34, 34)
INSERT [dbo].[TTTH_course] ([_id], [_course_name], [_price], [_length]) VALUES (20, N'sdkhkjlkjlkl88888', 88888, 8888)
INSERT [dbo].[TTTH_course] ([_id], [_course_name], [_price], [_length]) VALUES (21, N'dsggfdsgefg------', 99, 23124)
INSERT [dbo].[TTTH_course] ([_id], [_course_name], [_price], [_length]) VALUES (22, N'avc', 99, 993333)
INSERT [dbo].[TTTH_course] ([_id], [_course_name], [_price], [_length]) VALUES (23, N'khoa hoc moi them 2222', 222, 22)
INSERT [dbo].[TTTH_course] ([_id], [_course_name], [_price], [_length]) VALUES (24, N'a', 1, 1)
INSERT [dbo].[TTTH_course] ([_id], [_course_name], [_price], [_length]) VALUES (25, N'khoa hocj moi neeee', 1002, 23)
INSERT [dbo].[TTTH_course] ([_id], [_course_name], [_price], [_length]) VALUES (26, N'g', 5, 5)
SET IDENTITY_INSERT [dbo].[TTTH_course] OFF
GO
SET IDENTITY_INSERT [dbo].[TTTH_notification] ON 

INSERT [dbo].[TTTH_notification] ([_id], [_topic], [_content], [_created_date], [_user_id]) VALUES (1, N'Mở thêm chi nhánh ở Hà Nam', N'Ngayf 14 tháng 3 năm 2003, với số tiền tài trợ khổng lồ từ  ba má, chủ tịch quyết định mở thêm chi nhánh mới', CAST(N'2023-02-19' AS Date), 4)
INSERT [dbo].[TTTH_notification] ([_id], [_topic], [_content], [_created_date], [_user_id]) VALUES (2, N'Thông báo thứ 2', N'chả có gì cả', CAST(N'2023-02-19' AS Date), 2)
INSERT [dbo].[TTTH_notification] ([_id], [_topic], [_content], [_created_date], [_user_id]) VALUES (7, N'Lim lượm được 10k', N'nhưng làm mất 20k', CAST(N'2023-02-22' AS Date), 4)
INSERT [dbo].[TTTH_notification] ([_id], [_topic], [_content], [_created_date], [_user_id]) VALUES (8, N'sfjhsfg', N'dfhàdhahfdhdf', CAST(N'2023-02-22' AS Date), 4)
INSERT [dbo].[TTTH_notification] ([_id], [_topic], [_content], [_created_date], [_user_id]) VALUES (9, N':"3', N':)', CAST(N'2023-02-22' AS Date), 4)
INSERT [dbo].[TTTH_notification] ([_id], [_topic], [_content], [_created_date], [_user_id]) VALUES (10, N'gdfg', N'gdfshds', CAST(N'2023-02-22' AS Date), 4)
INSERT [dbo].[TTTH_notification] ([_id], [_topic], [_content], [_created_date], [_user_id]) VALUES (11, N'kjgjk', N'kiu', CAST(N'2023-02-27' AS Date), 4)
INSERT [dbo].[TTTH_notification] ([_id], [_topic], [_content], [_created_date], [_user_id]) VALUES (12, N'Thông báo này do một người đẹp chai tạo lúc 22 giờ 51 phút', N'với nội dung lè chả có gì hết á', CAST(N'2023-02-27' AS Date), 4)
INSERT [dbo].[TTTH_notification] ([_id], [_topic], [_content], [_created_date], [_user_id]) VALUES (13, N'sàhjgạu hem bviết nucẵ', N'khem biet gfì hết, tui vpp can
', CAST(N'2023-03-10' AS Date), 4)
SET IDENTITY_INSERT [dbo].[TTTH_notification] OFF
GO
SET IDENTITY_INSERT [dbo].[TTTH_permission_group] ON 

INSERT [dbo].[TTTH_permission_group] ([_id], [_permission_name]) VALUES (2, N'Giang vien')
INSERT [dbo].[TTTH_permission_group] ([_id], [_permission_name]) VALUES (1, N'Quan tri')
SET IDENTITY_INSERT [dbo].[TTTH_permission_group] OFF
GO
INSERT [dbo].[TTTH_register] ([_student_id], [_class_id]) VALUES (1, 15)
INSERT [dbo].[TTTH_register] ([_student_id], [_class_id]) VALUES (1, 16)
INSERT [dbo].[TTTH_register] ([_student_id], [_class_id]) VALUES (1, 20)
INSERT [dbo].[TTTH_register] ([_student_id], [_class_id]) VALUES (1, 22)
INSERT [dbo].[TTTH_register] ([_student_id], [_class_id]) VALUES (2, 14)
INSERT [dbo].[TTTH_register] ([_student_id], [_class_id]) VALUES (2, 15)
INSERT [dbo].[TTTH_register] ([_student_id], [_class_id]) VALUES (2, 16)
INSERT [dbo].[TTTH_register] ([_student_id], [_class_id]) VALUES (3, 14)
INSERT [dbo].[TTTH_register] ([_student_id], [_class_id]) VALUES (3, 15)
INSERT [dbo].[TTTH_register] ([_student_id], [_class_id]) VALUES (3, 16)
INSERT [dbo].[TTTH_register] ([_student_id], [_class_id]) VALUES (3, 20)
INSERT [dbo].[TTTH_register] ([_student_id], [_class_id]) VALUES (4, 14)
INSERT [dbo].[TTTH_register] ([_student_id], [_class_id]) VALUES (4, 15)
INSERT [dbo].[TTTH_register] ([_student_id], [_class_id]) VALUES (4, 16)
INSERT [dbo].[TTTH_register] ([_student_id], [_class_id]) VALUES (4, 22)
INSERT [dbo].[TTTH_register] ([_student_id], [_class_id]) VALUES (5, 14)
INSERT [dbo].[TTTH_register] ([_student_id], [_class_id]) VALUES (5, 15)
INSERT [dbo].[TTTH_register] ([_student_id], [_class_id]) VALUES (5, 20)
INSERT [dbo].[TTTH_register] ([_student_id], [_class_id]) VALUES (6, 14)
INSERT [dbo].[TTTH_register] ([_student_id], [_class_id]) VALUES (6, 15)
INSERT [dbo].[TTTH_register] ([_student_id], [_class_id]) VALUES (6, 22)
INSERT [dbo].[TTTH_register] ([_student_id], [_class_id]) VALUES (7, 14)
INSERT [dbo].[TTTH_register] ([_student_id], [_class_id]) VALUES (7, 15)
INSERT [dbo].[TTTH_register] ([_student_id], [_class_id]) VALUES (7, 20)
INSERT [dbo].[TTTH_register] ([_student_id], [_class_id]) VALUES (7, 22)
INSERT [dbo].[TTTH_register] ([_student_id], [_class_id]) VALUES (8, 14)
INSERT [dbo].[TTTH_register] ([_student_id], [_class_id]) VALUES (8, 15)
INSERT [dbo].[TTTH_register] ([_student_id], [_class_id]) VALUES (8, 22)
INSERT [dbo].[TTTH_register] ([_student_id], [_class_id]) VALUES (9, 14)
INSERT [dbo].[TTTH_register] ([_student_id], [_class_id]) VALUES (9, 15)
INSERT [dbo].[TTTH_register] ([_student_id], [_class_id]) VALUES (9, 20)
INSERT [dbo].[TTTH_register] ([_student_id], [_class_id]) VALUES (9, 22)
GO
SET IDENTITY_INSERT [dbo].[TTTH_room] ON 

INSERT [dbo].[TTTH_room] ([_id], [_room_name], [_capacity], [_room_type]) VALUES (4, N'Zoom meeting', 100, N'online                        ')
INSERT [dbo].[TTTH_room] ([_id], [_room_name], [_capacity], [_room_type]) VALUES (5, N'P001', 75, N'offline                       ')
INSERT [dbo].[TTTH_room] ([_id], [_room_name], [_capacity], [_room_type]) VALUES (6, N'A001', 50, N'offline                       ')
INSERT [dbo].[TTTH_room] ([_id], [_room_name], [_capacity], [_room_type]) VALUES (7, N'A002', 50, N'offline                       ')
INSERT [dbo].[TTTH_room] ([_id], [_room_name], [_capacity], [_room_type]) VALUES (8, N'A003', 50, N'offline                       ')
INSERT [dbo].[TTTH_room] ([_id], [_room_name], [_capacity], [_room_type]) VALUES (9, N'A004', 50, N'offline                       ')
INSERT [dbo].[TTTH_room] ([_id], [_room_name], [_capacity], [_room_type]) VALUES (10, N'P002', 75, N'offline                       ')
INSERT [dbo].[TTTH_room] ([_id], [_room_name], [_capacity], [_room_type]) VALUES (11, N'P003', 75, N'offline                       ')
INSERT [dbo].[TTTH_room] ([_id], [_room_name], [_capacity], [_room_type]) VALUES (12, N'P004', 75, N'offlinez                      ')
INSERT [dbo].[TTTH_room] ([_id], [_room_name], [_capacity], [_room_type]) VALUES (13, N'Thí nghiệm 1', 75, N'offline                       ')
INSERT [dbo].[TTTH_room] ([_id], [_room_name], [_capacity], [_room_type]) VALUES (14, N'Thí nghiệm 14444444444444444444444444444444444', 75, N'offline                       ')
INSERT [dbo].[TTTH_room] ([_id], [_room_name], [_capacity], [_room_type]) VALUES (16, N'zôm 12', 110, N'online                        ')
INSERT [dbo].[TTTH_room] ([_id], [_room_name], [_capacity], [_room_type]) VALUES (17, N'zoom 12', 110, N'online                        ')
INSERT [dbo].[TTTH_room] ([_id], [_room_name], [_capacity], [_room_type]) VALUES (18, N'zom', 33, N'22                            ')
INSERT [dbo].[TTTH_room] ([_id], [_room_name], [_capacity], [_room_type]) VALUES (19, N'lam gi co', 43, N'214                           ')
INSERT [dbo].[TTTH_room] ([_id], [_room_name], [_capacity], [_room_type]) VALUES (20, N'phong hoc moi', 23, N'khong co khoang cach          ')
INSERT [dbo].[TTTH_room] ([_id], [_room_name], [_capacity], [_room_type]) VALUES (21, N'avc', 45, N'34c                           ')
INSERT [dbo].[TTTH_room] ([_id], [_room_name], [_capacity], [_room_type]) VALUES (22, N'sửa lại tên nè thư', 143, N'online                        ')
SET IDENTITY_INSERT [dbo].[TTTH_room] OFF
GO
SET IDENTITY_INSERT [dbo].[TTTH_student] ON 

INSERT [dbo].[TTTH_student] ([_id], [_phone_number], [_student_name]) VALUES (1, N'09234645', N'Huynhf Thanh Liem')
INSERT [dbo].[TTTH_student] ([_id], [_phone_number], [_student_name]) VALUES (2, N'8630465', N'Tran huu tai')
INSERT [dbo].[TTTH_student] ([_id], [_phone_number], [_student_name]) VALUES (3, N'634634634123333333', N'nguyen tran diaaaa')
INSERT [dbo].[TTTH_student] ([_id], [_phone_number], [_student_name]) VALUES (4, N'tfhf', N'thu ga')
INSERT [dbo].[TTTH_student] ([_id], [_phone_number], [_student_name]) VALUES (5, N'09234645', N'Huynhf Thanh Liem')
INSERT [dbo].[TTTH_student] ([_id], [_phone_number], [_student_name]) VALUES (6, N'09234645', N'Huynhf Thanh Liem')
INSERT [dbo].[TTTH_student] ([_id], [_phone_number], [_student_name]) VALUES (7, N'gf', N'tewt')
INSERT [dbo].[TTTH_student] ([_id], [_phone_number], [_student_name]) VALUES (8, N'0999999333', N'duy da')
INSERT [dbo].[TTTH_student] ([_id], [_phone_number], [_student_name]) VALUES (9, N' 308472305', N'Đặng Thị Minh Thư')
SET IDENTITY_INSERT [dbo].[TTTH_student] OFF
GO
SET IDENTITY_INSERT [dbo].[TTTH_user] ON 

INSERT [dbo].[TTTH_user] ([_id], [_user_name], [_pass_word], [_show_name], [_email], [_phone_number], [_address], [_permission_group_id]) VALUES (1, N'u1', N'u1', N'liêm', N'lim@gmail.com', N'123', N'123, dskhá, sdhfk', 2)
INSERT [dbo].[TTTH_user] ([_id], [_user_name], [_pass_word], [_show_name], [_email], [_phone_number], [_address], [_permission_group_id]) VALUES (2, N'u2', N'u2', N'userBinhThuong', N'userbinhthuongAgmail.com', N'015646', N'1131,465,46,312654,153', 2)
INSERT [dbo].[TTTH_user] ([_id], [_user_name], [_pass_word], [_show_name], [_email], [_phone_number], [_address], [_permission_group_id]) VALUES (4, N'a', N'a', N'admin ne', N'ad@gmail.com', N'a', N'a', 1)
INSERT [dbo].[TTTH_user] ([_id], [_user_name], [_pass_word], [_show_name], [_email], [_phone_number], [_address], [_permission_group_id]) VALUES (6, N'a1', N'a2', N'acc cua admin', N'q', N'q', N'q', 2)
SET IDENTITY_INSERT [dbo].[TTTH_user] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__TTTH_not__4AB209A6BBC34778]    Script Date: 11/03/2023 19:54:13 ******/
ALTER TABLE [dbo].[TTTH_notification] ADD UNIQUE NONCLUSTERED 
(
	[_topic] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__TTTH_per__179942FDB11F40E4]    Script Date: 11/03/2023 19:54:13 ******/
ALTER TABLE [dbo].[TTTH_permission] ADD UNIQUE NONCLUSTERED 
(
	[_detail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ___user_au__6B6FC940DCCC0F6B]    Script Date: 11/03/2023 19:54:13 ******/
ALTER TABLE [dbo].[TTTH_permission_group] ADD UNIQUE NONCLUSTERED 
(
	[_permission_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__TTTH_use__91E468367AFEED5A]    Script Date: 11/03/2023 19:54:13 ******/
ALTER TABLE [dbo].[TTTH_user] ADD UNIQUE NONCLUSTERED 
(
	[_user_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TTTH_class] ADD  DEFAULT (getdate()) FOR [_start_day]
GO
ALTER TABLE [dbo].[TTTH_class] ADD  DEFAULT (getdate()) FOR [_end_day]
GO
ALTER TABLE [dbo].[TTTH_notification] ADD  DEFAULT (getdate()) FOR [_created_date]
GO
ALTER TABLE [dbo].[TTTH_class]  WITH CHECK ADD FOREIGN KEY([_course_id])
REFERENCES [dbo].[TTTH_course] ([_id])
GO
ALTER TABLE [dbo].[TTTH_class]  WITH CHECK ADD FOREIGN KEY([_room_id])
REFERENCES [dbo].[TTTH_room] ([_id])
GO
ALTER TABLE [dbo].[TTTH_notification]  WITH CHECK ADD FOREIGN KEY([_user_id])
REFERENCES [dbo].[TTTH_user] ([_id])
GO
ALTER TABLE [dbo].[TTTH_register]  WITH CHECK ADD FOREIGN KEY([_class_id])
REFERENCES [dbo].[TTTH_class] ([_id])
GO
ALTER TABLE [dbo].[TTTH_register]  WITH CHECK ADD FOREIGN KEY([_student_id])
REFERENCES [dbo].[TTTH_student] ([_id])
GO
ALTER TABLE [dbo].[TTTH_user]  WITH CHECK ADD  CONSTRAINT [FK_TTTH_permission_group] FOREIGN KEY([_permission_group_id])
REFERENCES [dbo].[TTTH_permission_group] ([_id])
GO
ALTER TABLE [dbo].[TTTH_user] CHECK CONSTRAINT [FK_TTTH_permission_group]
GO
ALTER TABLE [dbo].[TTTH_class]  WITH CHECK ADD CHECK  (([_capacity]>(0)))
GO
ALTER TABLE [dbo].[TTTH_class]  WITH CHECK ADD CHECK  (([_shift]>=(1) AND [_shift]<=(5)))
GO
ALTER TABLE [dbo].[TTTH_course]  WITH CHECK ADD CHECK  (([_length]>(0)))
GO
ALTER TABLE [dbo].[TTTH_course]  WITH CHECK ADD CHECK  (([_price]>=(0)))
GO
ALTER TABLE [dbo].[TTTH_room]  WITH CHECK ADD CHECK  (([_capacity]>(0)))
GO
USE [master]
GO
ALTER DATABASE [TTTH] SET  READ_WRITE 
GO
