/*
select * from ttth_class;

declare @id int, @className nvarchar(100)
set @className = 'ggg'
select @id = _id from ttth_class where _class_name = @className;
-- xoa date in week
delete from TTTH_class_date_in_week where _class_id = @id;
-- xoa date
delete from TTTH_class_date where _class_id = @id;
-- xoa class
delete from ttth_class where _class_name = @className;

drop table temp_date_to_check_conflict
*/

-- delete from TTTH_course


