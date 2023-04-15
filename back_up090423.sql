USE [master]
GO
/****** Object:  Database [TTTH]    Script Date: 09/04/2023 22:16:26 ******/
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
/****** Object:  UserDefinedFunction [dbo].[check]    Script Date: 09/04/2023 22:16:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE FUNCTION [dbo].[check]
(
	@roomID int,
	@shift int
)
RETURNS INT
AS
BEGIN
	declare @num1 int, @num2 int

	select @num1 = count(distinct _date), @num2 = count(*) from TTTH_class cl
	join TTTH_class_date cd
	on cl._id = cd._class_id
	join TTTH_room r
	on r._id = cl._room_id
	where _shift = @shift and _room_id = @roomID

	if (@num1  = @num2)
	return 0 -- no conflict
	-- else
	return 1 -- confict
END
GO
/****** Object:  UserDefinedFunction [dbo].[check_confict_in_room]    Script Date: 09/04/2023 22:16:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[check_confict_in_room]
(
	@roomID int,
	@shift int
)
RETURNS INT
AS
BEGIN
	declare @num1 int, @num2 int

	select @num1 = count(distinct _date), @num2 = count(*) from TTTH_class cl
	join TTTH_class_date cd
	on cl._id = cd._class_id
	join TTTH_room r
	on r._id = cl._room_id
	where _shift = @shift and _room_id = @roomID

	if (@num1  = @num2)
	return 0 -- no conflict
	-- else
	return 1 -- confict
END
GO
/****** Object:  UserDefinedFunction [dbo].[get_next_class_date]    Script Date: 09/04/2023 22:16:26 ******/
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
/****** Object:  Table [dbo].[TTTH_class]    Script Date: 09/04/2023 22:16:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTTH_class](
	[_id] [int] IDENTITY(1,1) NOT NULL,
	[_class_name] [nvarchar](100) NULL,
	[_start_day] [date] NULL,
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
/****** Object:  Table [dbo].[TTTH_course]    Script Date: 09/04/2023 22:16:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTTH_course](
	[_id] [int] IDENTITY(1,1) NOT NULL,
	[_course_name] [nvarchar](50) NOT NULL,
	[_fee] [float] NOT NULL,
	[_duration] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[_course_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TTTH_room]    Script Date: 09/04/2023 22:16:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTTH_room](
	[_id] [int] IDENTITY(1,1) NOT NULL,
	[_room_name] [nvarchar](50) NULL,
	[_capacity] [int] NOT NULL,
	[_room_type] [nchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[get_class]    Script Date: 09/04/2023 22:16:26 ******/
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
			-- c._end_day, 
			c._capacity 
			from TTTH_class c 
			)
GO
/****** Object:  Table [dbo].[TTTH_attend]    Script Date: 09/04/2023 22:16:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTTH_attend](
	[_class_id] [int] NOT NULL,
	[_date_number] [int] NOT NULL,
	[_student_id] [int] NOT NULL,
	[_status] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[_class_id] ASC,
	[_student_id] ASC,
	[_date_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TTTH_student]    Script Date: 09/04/2023 22:16:26 ******/
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
/****** Object:  Table [dbo].[TTTH_register]    Script Date: 09/04/2023 22:16:26 ******/
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
/****** Object:  View [dbo].[student_attendance]    Script Date: 09/04/2023 22:16:26 ******/
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
/****** Object:  UserDefinedFunction [dbo].[get_attendance]    Script Date: 09/04/2023 22:16:26 ******/
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
/****** Object:  Table [dbo].[temp_date_to_check]    Script Date: 09/04/2023 22:16:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[temp_date_to_check](
	[_class_id] [int] NULL,
	[_date] [date] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TTTH_class_date]    Script Date: 09/04/2023 22:16:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTTH_class_date](
	[_class_id] [int] NOT NULL,
	[_date_number] [int] NOT NULL,
	[_date] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[_class_id] ASC,
	[_date_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[_class_id] ASC,
	[_date_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TTTH_class_date_in_week]    Script Date: 09/04/2023 22:16:26 ******/
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
/****** Object:  Table [dbo].[TTTH_exam]    Script Date: 09/04/2023 22:16:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTTH_exam](
	[_exam_number] [int] NOT NULL,
	[_class_id] [int] NOT NULL,
	[_student_id] [int] NOT NULL,
	[_score] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[_class_id] ASC,
	[_exam_number] ASC,
	[_student_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TTTH_notification]    Script Date: 09/04/2023 22:16:26 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[_topic] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TTTH_permission]    Script Date: 09/04/2023 22:16:26 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[_detail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TTTH_permission_group]    Script Date: 09/04/2023 22:16:26 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[_permission_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TTTH_user]    Script Date: 09/04/2023 22:16:26 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[_user_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TTTH_attend] ADD  DEFAULT ('a') FOR [_status]
GO
ALTER TABLE [dbo].[TTTH_class] ADD  DEFAULT (getdate()) FOR [_start_day]
GO
ALTER TABLE [dbo].[TTTH_class_date_in_week] ADD  DEFAULT ((1)) FOR [_date_in_week]
GO
ALTER TABLE [dbo].[TTTH_course] ADD  DEFAULT ((0)) FOR [_fee]
GO
ALTER TABLE [dbo].[TTTH_course] ADD  DEFAULT ((0)) FOR [_duration]
GO
ALTER TABLE [dbo].[TTTH_exam] ADD  DEFAULT ((-1)) FOR [_score]
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
ALTER TABLE [dbo].[TTTH_class_date]  WITH CHECK ADD FOREIGN KEY([_class_id])
REFERENCES [dbo].[TTTH_class] ([_id])
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
ALTER TABLE [dbo].[TTTH_exam]  WITH CHECK ADD CHECK  (([_score]>=(0) AND [_score]<=(10)))
GO
ALTER TABLE [dbo].[TTTH_room]  WITH CHECK ADD CHECK  (([_capacity]>(0)))
GO
/****** Object:  StoredProcedure [dbo].[create_new_exam]    Script Date: 09/04/2023 22:16:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[create_new_exam]
	@classID int
AS
BEGIN
	declare @nextExamNumber int

	select @nextExamNumber = 
	case 
	when max(_exam_number) is null then 0
	else max(_exam_number)
	end
	+ 1 from TTTH_exam where _class_id = @classID

	insert into TTTH_exam (_exam_number, _class_id,_student_id, _score)
	select
	@nextExamNumber,
	r._class_id,
	s._id,
	0
	from TTTH_student s join TTTH_register r on s._id = r._student_id 
	where _class_id =@classID
	and(
		not exists (
			select * from TTTH_exam where 
			_exam_number = @nextExamNumber and
			_class_id = @classID and
			_student_id = s._id
		) 
	); 
	RETURN @nextExamNumber
END
GO
/****** Object:  StoredProcedure [dbo].[insert_class]    Script Date: 09/04/2023 22:16:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insert_class]
	@name nvarchar(100),
	@start date,
	@maxCapacity int,
	@shift int,
	@courseId int,
	@roomId int
AS
if(exists(select * from TTTH_class where _class_name = @name))
return 1 -- trùng tên lớp học

if(@maxCapacity <= 0)
return 2 -- số lượng học viên tối đa phải > 0

if(@shift not between 1 and 5)
return 3 -- ca học phải nằm trong khoảng 1 và 5

if(not exists(select * from TTTH_course where _id = @courseId))
return 4 -- course id khhông tồn tại

if(not exists(select * from TTTH_room where _id = @roomId))
return 5 -- room id khhông tồn tại

if((select max(_capacity) from TTTH_room where _id = @roomId) < @maxCapacity)
return 6 -- room có thể không đủ chổ cho lớp học

insert into TTTH_class (_class_name, _start_day, _capacity, _shift, _course_id, _room_id)
values (@name, @start, @maxCapacity, @shift, @courseId, @roomId)
return 0
GO
/****** Object:  StoredProcedure [dbo].[insert_course]    Script Date: 09/04/2023 22:16:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insert_course]
	@name nvarchar(50),
	@fee float,
	@duration int
AS
if (exists(select * from TTTH_course where _course_name = @name))
return 1 -- trùng tên khóa học

if (@fee < 0 )
return 2 -- học phí không thể âm

if (@duration <= 0)
return 3 -- thời lượng phải là số dương

insert into TTTH_course (_course_name, _fee, _duration)
values (@name, @fee, @duration)

return 0
GO
/****** Object:  StoredProcedure [dbo].[update_course]    Script Date: 09/04/2023 22:16:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[update_course]
	@id int,
	@name nvarchar(100),
	@fee float,
	@duration int
AS

if (
exists (select * from TTTH_course where _id !=  @id and _course_name = @name)
)
return 1 -- trùng tên khóa học

if (
 @fee < 0
)
return 2 -- học phí không thể âm

if (
 @duration <= 0
)
return 3 -- thời lượng phải là số dương


if (
exists (select * from ttth_course where _duration != @duration and _id = @id) and
(exists (select * from ttth_class where _course_id = @id))
)
return 4 -- Khóa học đã mở lớp, không thể chỉnh sửa thông tin thời lượng

update TTTH_course
set 
_course_name = @name, 
_fee = @fee, 
_duration = @duration
where _id = @id;
return 0
GO
/****** Object:  Trigger [dbo].[create_class_date_auto]    Script Date: 09/04/2023 22:16:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[create_class_date_auto]
	ON [dbo].[TTTH_class_date_in_week]
	AFTER INSERT, UPDATE, DELETE
	AS
	BEGIN
		--------------------------------------------
		declare @classID int
		select @classID = _class_id from inserted;
		--------------------------------------------

		--------------------------------------------
		declare @nextDate date, @duration int, @i int
		select @nextDate = _start_day from TTTH_class where _id = @classID
		select @duration = co._duration from TTTH_course co where co._id = (select top 1 c._course_id from TTTH_class c where c._id = @classID)
		set @i = 1
		
		declare @dateList table (d int)
		insert into @dateList select _date_in_week from TTTH_class_date_in_week where _class_id = @classID
		------------------>
		-- prevent infinite loop --
		if (not exists(select * from @dateList))
		begin
			return
		end
		------------------>
		--------------------------------------------

		--------------------------------------------
		while (@i <= @duration)
		begin
			-- skip the date if not chosen date 
			while (DATEPART(WEEKDAY, @nextDate) not in (select * from @dateList))
			begin
				-- date add 1 
				set @nextDate = DATEADD(day, 1, @nextDate)
			end
			----------------------------------------->>
			delete from TTTH_class_date where _class_id = @classID and _date_number = @i;
			insert into TTTH_class_date(_class_id, _date_number, _date) values(@classID, @i, @nextDate);
			----------------------------------------->>
			set @i = @i + 1
			set @nextDate = DATEADD(day, 1, @nextDate)
		end
		--------------------------------------------
		SET NOCOUNT ON
	END
GO
ALTER TABLE [dbo].[TTTH_class_date_in_week] ENABLE TRIGGER [create_class_date_auto]
GO
/****** Object:  Trigger [dbo].[create_attend_auto]    Script Date: 09/04/2023 22:16:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[create_attend_auto]
	ON [dbo].[TTTH_register]
	FOR INSERT, UPDATE
	AS
	BEGIN
	declare @classID int, @studentID int, @duration int,@i int 
	-------------------------------------------------------------------
	select @classID = _class_id, @studentID = _student_id from inserted
	select @duration = co._duration from TTTH_course co where co._id = (select top 1 c._course_id from TTTH_class c where c._id = @classID)
	--------------------------------------------------------------------

	--------------------------------------------------------------------x
	set @i = 1
	while @i <= @duration
	begin
		if (not exists(select * from TTTH_attend where
		_class_id = @classID and
		_date_number = @i and
		_student_id = @studentID))
		begin
			insert into TTTH_attend values (@classID, @i, @studentID, 'p')
		end
		set @i = @i + 1
	end
	--------------------------------------------------------------------x

		SET NOCOUNT ON
	END
GO
ALTER TABLE [dbo].[TTTH_register] ENABLE TRIGGER [create_attend_auto]
GO
USE [master]
GO
ALTER DATABASE [TTTH] SET  READ_WRITE 
GO
