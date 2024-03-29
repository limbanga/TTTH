USE [master]
GO
/****** Object:  Database [ttth_test]    Script Date: 24/04/2023 00:18:50 ******/
CREATE DATABASE [ttth_test]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ttth_test', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ttth_test.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ttth_test_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ttth_test_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ttth_test] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ttth_test].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ttth_test] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ttth_test] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ttth_test] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ttth_test] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ttth_test] SET ARITHABORT OFF 
GO
ALTER DATABASE [ttth_test] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ttth_test] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ttth_test] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ttth_test] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ttth_test] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ttth_test] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ttth_test] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ttth_test] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ttth_test] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ttth_test] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ttth_test] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ttth_test] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ttth_test] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ttth_test] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ttth_test] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ttth_test] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ttth_test] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ttth_test] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ttth_test] SET  MULTI_USER 
GO
ALTER DATABASE [ttth_test] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ttth_test] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ttth_test] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ttth_test] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ttth_test] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ttth_test] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ttth_test] SET QUERY_STORE = OFF
GO
USE [ttth_test]
GO
/****** Object:  UserDefinedFunction [dbo].[get_next_class_date]    Script Date: 24/04/2023 00:18:50 ******/
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
/****** Object:  Table [dbo].[TTTH_class]    Script Date: 24/04/2023 00:18:50 ******/
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
	[_teacher_id] [int] NULL,
	[_shift] [int] NULL,
	[_room_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TTTH_room]    Script Date: 24/04/2023 00:18:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTTH_room](
	[_id] [int] IDENTITY(1,1) NOT NULL,
	[_room_name] [nvarchar](50) NULL,
	[_capacity] [int] NOT NULL,
	[_room_type] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TTTH_class_date]    Script Date: 24/04/2023 00:18:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTTH_class_date](
	[_id] [int] IDENTITY(1,1) NOT NULL,
	[_class_id] [int] NOT NULL,
	[_date_number] [int] NOT NULL,
	[_date] [date] NULL,
	[_room_id] [int] NULL,
	[_shift] [int] NULL,
	[_teacher_id] [int] NULL,
	[_is_done] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[_class_id] ASC,
	[_date_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TTTH_user]    Script Date: 24/04/2023 00:18:50 ******/
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
/****** Object:  View [dbo].[views_class_date]    Script Date: 24/04/2023 00:18:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE View [dbo].[views_class_date]
as
SELECT 
cd._id,
cd._class_id,
(SELECT _class_name FROM TTTH_class WHERE _id = cd._class_id) as _class_name,
cd._date_number,
cd._date,
cd._room_id,
(SELECT _room_name FROM TTTH_room WHERE _id = cd._room_id) as _room_name,
cd._shift,
cd._teacher_id,
(SELECT _show_name FROM TTTH_user WHERE _id = cd._teacher_id) as _teacher_name,
cd._is_done
FROM TTTH_class_date cd
GO
/****** Object:  Table [dbo].[TTTH_attend]    Script Date: 24/04/2023 00:18:50 ******/
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
/****** Object:  Table [dbo].[TTTH_student]    Script Date: 24/04/2023 00:18:50 ******/
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
/****** Object:  Table [dbo].[TTTH_register]    Script Date: 24/04/2023 00:18:50 ******/
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
/****** Object:  View [dbo].[student_attendance]    Script Date: 24/04/2023 00:18:50 ******/
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
/****** Object:  UserDefinedFunction [dbo].[get_attendance]    Script Date: 24/04/2023 00:18:50 ******/
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
/****** Object:  Table [dbo].[TTTH_course]    Script Date: 24/04/2023 00:18:50 ******/
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
/****** Object:  Table [dbo].[TTTH_exam]    Script Date: 24/04/2023 00:18:50 ******/
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
/****** Object:  Table [dbo].[TTTH_notification]    Script Date: 24/04/2023 00:18:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TTTH_notification](
	[_id] [int] IDENTITY(1,1) NOT NULL,
	[_topic] [nvarchar](100) NOT NULL,
	[_content] [text] NULL,
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
ALTER TABLE [dbo].[TTTH_attend] ADD  DEFAULT ('p') FOR [_status]
GO
ALTER TABLE [dbo].[TTTH_class] ADD  DEFAULT (getdate()) FOR [_start_day]
GO
ALTER TABLE [dbo].[TTTH_course] ADD  DEFAULT ((0)) FOR [_fee]
GO
ALTER TABLE [dbo].[TTTH_course] ADD  DEFAULT ((0)) FOR [_duration]
GO
ALTER TABLE [dbo].[TTTH_exam] ADD  DEFAULT ((-1)) FOR [_score]
GO
ALTER TABLE [dbo].[TTTH_notification] ADD  DEFAULT (getdate()) FOR [_created_date]
GO
ALTER TABLE [dbo].[TTTH_attend]  WITH CHECK ADD  CONSTRAINT [FK__TTTH_atte___stud__4F7CD00D] FOREIGN KEY([_student_id])
REFERENCES [dbo].[TTTH_student] ([_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TTTH_attend] CHECK CONSTRAINT [FK__TTTH_atte___stud__4F7CD00D]
GO
ALTER TABLE [dbo].[TTTH_attend]  WITH CHECK ADD  CONSTRAINT [FK_TTTH_attend_TTTH_class_date] FOREIGN KEY([_class_id], [_date_number])
REFERENCES [dbo].[TTTH_class_date] ([_class_id], [_date_number])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TTTH_attend] CHECK CONSTRAINT [FK_TTTH_attend_TTTH_class_date]
GO
ALTER TABLE [dbo].[TTTH_class]  WITH CHECK ADD  CONSTRAINT [FK__TTTH_clas___cour__5070F446] FOREIGN KEY([_course_id])
REFERENCES [dbo].[TTTH_course] ([_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TTTH_class] CHECK CONSTRAINT [FK__TTTH_clas___cour__5070F446]
GO
ALTER TABLE [dbo].[TTTH_class]  WITH CHECK ADD  CONSTRAINT [FK_TTTH_class_TTTH_room] FOREIGN KEY([_room_id])
REFERENCES [dbo].[TTTH_room] ([_id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[TTTH_class] CHECK CONSTRAINT [FK_TTTH_class_TTTH_room]
GO
ALTER TABLE [dbo].[TTTH_class]  WITH CHECK ADD  CONSTRAINT [FK_TTTH_class_TTTH_user] FOREIGN KEY([_teacher_id])
REFERENCES [dbo].[TTTH_user] ([_id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[TTTH_class] CHECK CONSTRAINT [FK_TTTH_class_TTTH_user]
GO
ALTER TABLE [dbo].[TTTH_class_date]  WITH CHECK ADD  CONSTRAINT [FK__TTTH_clas___clas__52593CB8] FOREIGN KEY([_class_id])
REFERENCES [dbo].[TTTH_class] ([_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TTTH_class_date] CHECK CONSTRAINT [FK__TTTH_clas___clas__52593CB8]
GO
ALTER TABLE [dbo].[TTTH_class_date]  WITH CHECK ADD  CONSTRAINT [FK_TTTH_class_date_TTTH_room] FOREIGN KEY([_room_id])
REFERENCES [dbo].[TTTH_room] ([_id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[TTTH_class_date] CHECK CONSTRAINT [FK_TTTH_class_date_TTTH_room]
GO
ALTER TABLE [dbo].[TTTH_exam]  WITH CHECK ADD  CONSTRAINT [FK_TTTH_exam_TTTH_class1] FOREIGN KEY([_class_id])
REFERENCES [dbo].[TTTH_class] ([_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TTTH_exam] CHECK CONSTRAINT [FK_TTTH_exam_TTTH_class1]
GO
ALTER TABLE [dbo].[TTTH_exam]  WITH CHECK ADD  CONSTRAINT [FK_TTTH_exam_TTTH_student] FOREIGN KEY([_student_id])
REFERENCES [dbo].[TTTH_student] ([_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TTTH_exam] CHECK CONSTRAINT [FK_TTTH_exam_TTTH_student]
GO
ALTER TABLE [dbo].[TTTH_notification]  WITH CHECK ADD FOREIGN KEY([_user_id])
REFERENCES [dbo].[TTTH_user] ([_id])
GO
ALTER TABLE [dbo].[TTTH_register]  WITH CHECK ADD  CONSTRAINT [FK__TTTH_regi___clas__5535A963] FOREIGN KEY([_class_id])
REFERENCES [dbo].[TTTH_class] ([_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TTTH_register] CHECK CONSTRAINT [FK__TTTH_regi___clas__5535A963]
GO
ALTER TABLE [dbo].[TTTH_register]  WITH CHECK ADD  CONSTRAINT [FK__TTTH_regi___stud__5629CD9C] FOREIGN KEY([_student_id])
REFERENCES [dbo].[TTTH_student] ([_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TTTH_register] CHECK CONSTRAINT [FK__TTTH_regi___stud__5629CD9C]
GO
ALTER TABLE [dbo].[TTTH_class]  WITH CHECK ADD CHECK  (([_capacity]>(0)))
GO
ALTER TABLE [dbo].[TTTH_course]  WITH CHECK ADD CHECK  (([_duration]>(0)))
GO
ALTER TABLE [dbo].[TTTH_course]  WITH CHECK ADD CHECK  (([_fee]>=(0)))
GO
ALTER TABLE [dbo].[TTTH_exam]  WITH CHECK ADD CHECK  (([_score]>=(0) AND [_score]<=(10)))
GO
ALTER TABLE [dbo].[TTTH_room]  WITH CHECK ADD CHECK  (([_capacity]>(0)))
GO
/****** Object:  StoredProcedure [dbo].[insert_course]    Script Date: 24/04/2023 00:18:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insert_course]
	@name NVARCHAR(50),
	@fee FLOAT,
	@duration INT
AS
IF (EXISTS(SELECT * FROM TTTH_course WHERE _course_name = @name))
BEGIN
	SELECT N'Tên khóa học trùng lặp.'
	RETURN 1 -- trùng tên khóa học
END

IF (@fee < 0 )
BEGIN
	SELECT N'Học phí không thể âm.'
	RETURN 2 -- học phí không thể âm
END

IF (@duration <= 0)
BEGIN
	SELECT N'Số buổi học phải lớn hơn 0.'
	RETURN 3 
END

INSERT INTO TTTH_course (_course_name, _fee, _duration)
VALUES (@name, @fee, @duration)

SELECT N''
RETURN 0 -- thành công, không có lỗi
GO
/****** Object:  StoredProcedure [dbo].[update_course]    Script Date: 24/04/2023 00:18:50 ******/
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
/****** Object:  Trigger [dbo].[check_conflict_room_on_insert]    Script Date: 24/04/2023 00:18:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[check_conflict_room_on_insert]
ON [dbo].[TTTH_class_date]
FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @id int, @date date, @roomID int, @shift int
	SELECT @id = _id, @date =_date, @roomID = _room_id, @shift = _shift FROM inserted
	IF((SELECT COUNT(*) FROM TTTH_class_date WHERE _date = @date AND _room_id = @roomID AND _shift = @shift) > 1)
	BEGIN
		UPDATE TTTH_class_date
		SET _room_id = NULL
		WHERE _id = @id
	END
END
GO
ALTER TABLE [dbo].[TTTH_class_date] ENABLE TRIGGER [check_conflict_room_on_insert]
GO
USE [master]
GO
ALTER DATABASE [ttth_test] SET  READ_WRITE 
GO

USE [ttth_test]
GO
INSERT INTO TTTH_user VALUES ('admin', 'letmein123', N'Quản trị viên', 'email@gmail.com', '' ,'' , 1);

