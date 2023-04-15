CREATE TRIGGER [create_attend_auto]
	ON [dbo].[ttth_register]
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