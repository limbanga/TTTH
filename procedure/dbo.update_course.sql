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