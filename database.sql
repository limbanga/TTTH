USE [master]
GO
/****** Object:  Database [TTTH]    Script Date: 19/03/2023 16:38:44 ******/
CREATE DATABASE [TTTH]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TTTH', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TTTH.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TTTH_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TTTH_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
/****** Object:  UserDefinedFunction [dbo].[get_next_class_date]    Script Date: 19/03/2023 16:38:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[get_next_class_date]
(
	@class_id int
)
RETURNS INT
AS
begin
	declare @nextDate int
	select @nextDate = max(_date_number) + 1 from TTTH_attend where _class_id = @class_id
	if (@nextDate is null)
		return 1;
	
	return @nextDate
end
GO
/****** Object:  Table [dbo].[TTTH_class]    Script Date: 19/03/2023 16:38:44 ******/
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
/****** Object:  Table [dbo].[TTTH_course]    Script Date: 19/03/2023 16:38:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTTH_course](
	[_id] [int] IDENTITY(1,1) NOT NULL,
	[_course_name] [nvarchar](50) NULL,
	[_fee] [float] NULL,
	[_duration] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TTTH_room]    Script Date: 19/03/2023 16:38:44 ******/
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
/****** Object:  UserDefinedFunction [dbo].[get_class]    Script Date: 19/03/2023 16:38:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[get_class]
()
RETURNS TABLE
AS
	RETURN (
	select 
			c._class_name,
			(select co._course_name from TTTH_course co where co._id = c._course_id) as '_course_name',
			c._shift,
			case
				when c._room_id is null then '-'
				else ( select top 1 r._room_name from TTTH_room r where _id = c._room_id)
			end
			as '_room_name',
			c._start_day,
			c._end_day, 
			c._capacity 
			from TTTH_class c 
			)
GO
/****** Object:  Table [dbo].[TTTH_student]    Script Date: 19/03/2023 16:38:44 ******/
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
/****** Object:  Table [dbo].[TTTH_register]    Script Date: 19/03/2023 16:38:44 ******/
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
/****** Object:  Table [dbo].[TTTH_attend]    Script Date: 19/03/2023 16:38:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTTH_attend](
	[_class_id] [int] NOT NULL,
	[_student_id] [int] NOT NULL,
	[_date_number] [int] NOT NULL,
	[_date] [date] NULL,
	[_status] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[_class_id] ASC,
	[_student_id] ASC,
	[_date_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[student_attendance]    Script Date: 19/03/2023 16:38:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[student_attendance]
as
select s._id, s._student_name, s._phone_number, 
case
when a._status is null then 'v'
else a._status
end
as '_status'
from TTTH_student s
inner join TTTH_register r 
on s._id = r._student_id
left join TTTH_attend a
on s._id = a._student_id
GO
/****** Object:  UserDefinedFunction [dbo].[get_attendance]    Script Date: 19/03/2023 16:38:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[get_attendance]
(
	@_class_id int,
	@_date_number int
)
RETURNS TABLE
AS

	RETURN 
	(select s._id, s._student_name, s._phone_number, 
		case
		when a._status is null then 'a'
		else a._status
		end
		as '_status'

		from TTTH_student s
		inner join TTTH_register r 
		on s._id = r._student_id
		left join TTTH_attend a
		on s._id = a._student_id
		where r._class_id = @_class_id and (a._date_number = @_date_number or a._date_number is null)
)
GO
/****** Object:  Table [dbo].[TTTH_class_date_in_week]    Script Date: 19/03/2023 16:38:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTTH_class_date_in_week](
	[_class_id] [int] NOT NULL,
	[_date_in_week] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[_class_id] ASC,
	[_date_in_week] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TTTH_notification]    Script Date: 19/03/2023 16:38:44 ******/
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
/****** Object:  Table [dbo].[TTTH_permission]    Script Date: 19/03/2023 16:38:44 ******/
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
/****** Object:  Table [dbo].[TTTH_permission_group]    Script Date: 19/03/2023 16:38:44 ******/
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
/****** Object:  Table [dbo].[TTTH_user]    Script Date: 19/03/2023 16:38:44 ******/
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
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 1, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 2, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 3, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 4, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 5, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 6, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 7, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 8, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 9, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 10, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 11, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 12, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 13, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 14, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 15, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 16, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 17, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 18, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 19, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 20, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 21, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 22, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 23, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 24, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 25, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 26, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 27, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 28, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 29, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 30, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 31, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 32, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 33, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 34, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 35, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 36, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 37, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 38, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 39, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 40, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 41, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 42, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 43, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 44, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (1, 1, 45, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 1, CAST(N'2000-01-01' AS Date), N'p')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 2, CAST(N'2000-01-01' AS Date), N'p')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 3, CAST(N'2000-01-01' AS Date), N'p')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 4, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 5, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 6, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 7, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 8, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 9, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 10, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 11, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 12, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 13, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 14, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 15, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 16, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 17, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 18, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 19, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 20, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 21, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 22, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 23, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 24, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 25, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 26, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 27, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 28, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 29, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 30, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 31, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 32, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 33, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 34, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 35, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 36, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 37, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 38, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 39, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 40, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 41, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 42, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 43, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 44, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 1, 45, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 1, CAST(N'2000-01-01' AS Date), N'p')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 2, CAST(N'2000-01-01' AS Date), N'p')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 3, CAST(N'2000-01-01' AS Date), N'l')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 4, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 5, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 6, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 7, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 8, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 9, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 10, CAST(N'2000-01-01' AS Date), N'a')
GO
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 11, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 12, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 13, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 14, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 15, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 16, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 17, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 18, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 19, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 20, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 21, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 22, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 23, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 24, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 25, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 26, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 27, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 28, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 29, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 30, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 31, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 32, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 33, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 34, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 35, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 36, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 37, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 38, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 39, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 40, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 41, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 42, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 43, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 44, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 2, 45, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 1, CAST(N'2000-01-01' AS Date), N'p')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 2, CAST(N'2000-01-01' AS Date), N'p')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 3, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 4, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 5, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 6, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 7, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 8, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 9, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 10, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 11, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 12, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 13, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 14, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 15, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 16, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 17, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 18, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 19, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 20, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 21, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 22, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 23, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 24, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 25, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 26, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 27, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 28, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 29, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 30, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 31, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 32, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 33, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 34, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 35, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 36, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 37, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 38, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 39, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 40, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 41, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 42, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 43, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 44, CAST(N'2000-01-01' AS Date), N'a')
INSERT [dbo].[TTTH_attend] ([_class_id], [_student_id], [_date_number], [_date], [_status]) VALUES (2, 3, 45, CAST(N'2000-01-01' AS Date), N'a')
GO
SET IDENTITY_INSERT [dbo].[TTTH_class] ON 

INSERT [dbo].[TTTH_class] ([_id], [_class_name], [_start_day], [_end_day], [_capacity], [_course_id], [_room_id], [_shift]) VALUES (1, N'Tin học văn phòng 1', CAST(N'2023-03-18' AS Date), CAST(N'2023-03-18' AS Date), 45, 1, 1, 1)
INSERT [dbo].[TTTH_class] ([_id], [_class_name], [_start_day], [_end_day], [_capacity], [_course_id], [_room_id], [_shift]) VALUES (2, N'Tin học văn phòng 2', CAST(N'2023-03-18' AS Date), CAST(N'2023-03-18' AS Date), 45, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[TTTH_class] OFF
GO
INSERT [dbo].[TTTH_class_date_in_week] ([_class_id], [_date_in_week]) VALUES (1, 1)
INSERT [dbo].[TTTH_class_date_in_week] ([_class_id], [_date_in_week]) VALUES (1, 3)
INSERT [dbo].[TTTH_class_date_in_week] ([_class_id], [_date_in_week]) VALUES (1, 5)
GO
SET IDENTITY_INSERT [dbo].[TTTH_course] ON 

INSERT [dbo].[TTTH_course] ([_id], [_course_name], [_fee], [_duration]) VALUES (1, N'Tin học văn phòng', 60000, 45)
INSERT [dbo].[TTTH_course] ([_id], [_course_name], [_fee], [_duration]) VALUES (2, N'Lập trình python', 15000, 20)
INSERT [dbo].[TTTH_course] ([_id], [_course_name], [_fee], [_duration]) VALUES (3, N'Lập trình python cho trẻ', 15000, 20)
SET IDENTITY_INSERT [dbo].[TTTH_course] OFF
GO
SET IDENTITY_INSERT [dbo].[TTTH_notification] ON 

INSERT [dbo].[TTTH_notification] ([_id], [_topic], [_content], [_created_date], [_user_id]) VALUES (1, N'Mất ví', N'Học viên ''abc'' làm mất ví phòng a. ai nhặt dc chả lại', CAST(N'2023-03-19' AS Date), 1)
SET IDENTITY_INSERT [dbo].[TTTH_notification] OFF
GO
SET IDENTITY_INSERT [dbo].[TTTH_permission_group] ON 

INSERT [dbo].[TTTH_permission_group] ([_id], [_permission_name]) VALUES (2, N'admin')
INSERT [dbo].[TTTH_permission_group] ([_id], [_permission_name]) VALUES (1, N'owner')
INSERT [dbo].[TTTH_permission_group] ([_id], [_permission_name]) VALUES (3, N'staff')
SET IDENTITY_INSERT [dbo].[TTTH_permission_group] OFF
GO
INSERT [dbo].[TTTH_register] ([_student_id], [_class_id]) VALUES (1, 1)
INSERT [dbo].[TTTH_register] ([_student_id], [_class_id]) VALUES (1, 2)
INSERT [dbo].[TTTH_register] ([_student_id], [_class_id]) VALUES (2, 1)
INSERT [dbo].[TTTH_register] ([_student_id], [_class_id]) VALUES (2, 2)
INSERT [dbo].[TTTH_register] ([_student_id], [_class_id]) VALUES (3, 2)
GO
SET IDENTITY_INSERT [dbo].[TTTH_room] ON 

INSERT [dbo].[TTTH_room] ([_id], [_room_name], [_capacity], [_room_type]) VALUES (1, N'Phòng học online 1', 110, N'online                        ')
SET IDENTITY_INSERT [dbo].[TTTH_room] OFF
GO
SET IDENTITY_INSERT [dbo].[TTTH_student] ON 

INSERT [dbo].[TTTH_student] ([_id], [_phone_number], [_student_name]) VALUES (1, N'09432435123', N'Huỳnh Thanh Liêm')
INSERT [dbo].[TTTH_student] ([_id], [_phone_number], [_student_name]) VALUES (2, N'0214125214252', N'Đặng Thị Minh Thư')
INSERT [dbo].[TTTH_student] ([_id], [_phone_number], [_student_name]) VALUES (3, N'099237823149', N'Nguyễn Trần Duy')
SET IDENTITY_INSERT [dbo].[TTTH_student] OFF
GO
SET IDENTITY_INSERT [dbo].[TTTH_user] ON 

INSERT [dbo].[TTTH_user] ([_id], [_user_name], [_pass_word], [_show_name], [_email], [_phone_number], [_address], [_permission_group_id]) VALUES (1, N'a', N'a', N'Huỳnh Thanh Liêm', N'meomeomeo@gmeo.com', N'0909990009', N'việt nam', 2)
SET IDENTITY_INSERT [dbo].[TTTH_user] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__TTTH_not__D089E5659CA55707]    Script Date: 19/03/2023 16:38:44 ******/
ALTER TABLE [dbo].[TTTH_notification] ADD UNIQUE NONCLUSTERED 
(
	[_topic] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__TTTH_per__179942FDC3ECFEB3]    Script Date: 19/03/2023 16:38:44 ******/
ALTER TABLE [dbo].[TTTH_permission] ADD UNIQUE NONCLUSTERED 
(
	[_detail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__TTTH_per__6B6FC9404AD8BEAC]    Script Date: 19/03/2023 16:38:44 ******/
ALTER TABLE [dbo].[TTTH_permission_group] ADD UNIQUE NONCLUSTERED 
(
	[_permission_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__TTTH_use__91E46836C6AE0935]    Script Date: 19/03/2023 16:38:44 ******/
ALTER TABLE [dbo].[TTTH_user] ADD UNIQUE NONCLUSTERED 
(
	[_user_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TTTH_attend] ADD  DEFAULT ('a') FOR [_status]
GO
ALTER TABLE [dbo].[TTTH_class] ADD  DEFAULT (getdate()) FOR [_start_day]
GO
ALTER TABLE [dbo].[TTTH_class] ADD  DEFAULT (getdate()) FOR [_end_day]
GO
ALTER TABLE [dbo].[TTTH_class_date_in_week] ADD  DEFAULT ((1)) FOR [_date_in_week]
GO
ALTER TABLE [dbo].[TTTH_course] ADD  DEFAULT ((0)) FOR [_fee]
GO
ALTER TABLE [dbo].[TTTH_course] ADD  DEFAULT ((0)) FOR [_duration]
GO
ALTER TABLE [dbo].[TTTH_notification] ADD  DEFAULT (getdate()) FOR [_created_date]
GO
ALTER TABLE [dbo].[TTTH_attend]  WITH CHECK ADD FOREIGN KEY([_class_id])
REFERENCES [dbo].[TTTH_class] ([_id])
GO
ALTER TABLE [dbo].[TTTH_attend]  WITH CHECK ADD FOREIGN KEY([_student_id])
REFERENCES [dbo].[TTTH_student] ([_id])
GO
ALTER TABLE [dbo].[TTTH_class]  WITH CHECK ADD FOREIGN KEY([_course_id])
REFERENCES [dbo].[TTTH_course] ([_id])
GO
ALTER TABLE [dbo].[TTTH_class]  WITH CHECK ADD FOREIGN KEY([_room_id])
REFERENCES [dbo].[TTTH_room] ([_id])
GO
ALTER TABLE [dbo].[TTTH_class_date_in_week]  WITH CHECK ADD FOREIGN KEY([_class_id])
REFERENCES [dbo].[TTTH_class] ([_id])
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
ALTER TABLE [dbo].[TTTH_course]  WITH CHECK ADD CHECK  (([_duration]>(0)))
GO
ALTER TABLE [dbo].[TTTH_course]  WITH CHECK ADD CHECK  (([_fee]>=(0)))
GO
ALTER TABLE [dbo].[TTTH_room]  WITH CHECK ADD CHECK  (([_capacity]>(0)))
GO
USE [master]
GO
ALTER DATABASE [TTTH] SET  READ_WRITE 
GO
