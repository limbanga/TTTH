create PROCEDURE [dbo].[update_class]
	@id int,
	@name nvarchar(100),
	@start date,
	@maxCapacity int,
	@shift int,
	@roomId int
AS
if(exists(select * from TTTH_class where _class_name = @name and _id != @id))
return 1 -- trùng tên lớp học

if(@maxCapacity <= 0)
return 2 -- số lượng học viên tối đa phải > 0

if(@shift not between 1 and 5)
return 3 -- ca học phải nằm trong khoảng 1 và 5

if(not exists(select * from TTTH_room where _id = @roomId))
return 4 -- room id khhông tồn tại

if((select max(_capacity) from TTTH_room where _id = @roomId) < @maxCapacity)
return 5 -- room có thể không đủ chổ cho lớp học

if(exists(select * from 
TTTH_class cl join TTTH_room r 
on cl._room_id = r._id
where cl._shift = @shift and _room_id = @roomId and cl._id != @id))
return 6 -- phòng học đã có lớp khác sử dụng

update TTTH_class
set _class_name = @name,
_capacity = @maxCapacity,
_shift = @shift,
_room_id = @roomId,
_start_day = @start
where _id = @id

return 0