declare @studentID int, @classID int, @duration int, @i int
set @studentID = 1
set @classID = 3
select @duration = co._duration from TTTH_course co where co._id = (select top 1 c._course_id from TTTH_class c where c._id = @classID)
set @i = 1

while (@i <= @duration)
	begin
		----------------------------------------->>
		delete from TTTH_attend where _class_id = @classID and _date_number = @i and _student_id = @studentID;
		insert into TTTH_attend(_class_id, _date_number, _student_id, _status) values(@classID, @i, @studentID, 'a');
		----------------------------------------->>
		set @i = @i + 1
	end


CREATE TRIGGER [create_atendance_auto]
	ON [dbo].[ttth_register]
	AFTER INSERT, UPDATE
	AS
	BEGIN
		declare @studentID int, @classID int, @duration int, @i int
		select @studentID = _student_id, @classID = _class_id from inserted
		select @duration = co._duration from TTTH_course co where co._id = (select top 1 c._course_id from TTTH_class c where c._id = @classID)
		set @i = 1

		while (@i <= @duration)
			begin
				----------------------------------------->>
				delete from TTTH_attend where _class_id = @classID and _date_number = @i and _student_id = @studentID;
				insert into TTTH_attend(_class_id, _date_number, _student_id, _status) values(@classID, @i, @studentID, 'a');
				----------------------------------------->>
				set @i = @i + 1
			end

		SET NOCOUNT ON
	END
