

while DATENAME(DW, GETDATE()) = 'Sunday' 
begin
print 1
end

declare @nextDate date, @duration int, @i int
set @nextDate = GETDATE()
set @duration = 15
set @i = 1

while (@i <= @duration)
begin
	-- skip the date if not chosen date 
	while (DATEPART(WEEKDAY, @nextDate) not in (1,3,5))
	begin
		-- date add 1 
		set @nextDate = DATEADD(day, 1, @nextDate)
	end
	print @nextDate
	set @i = @i + 1
	set @nextDate = DATEADD(day, 1, @nextDate)
end


CREATE TABLE [dbo].[TTTH_class_date] (
    [_class_id]    INT      NOT NULL,
    [_date_number] INT      NOT NULL,
    [_date]        DATE     NULL,
    PRIMARY KEY CLUSTERED ([_class_id] ASC, [_date_number] ASC),
    FOREIGN KEY ([_class_id]) REFERENCES [dbo].[TTTH_class] ([_id]),
);


CREATE TRIGGER [create_class_date]
	ON [dbo].[ttth_register]
	FOR INSERT
	AS
	BEGIN
		--------------------------------------------
		declare @classID int, @studentID int;
		select @classID = _class_id, @studentID = _student_id from inserted;
		--------------------------------------------

		--------------------------------------------
		declare @nextDate date, @duration int, @i int
		select @nextDate = _start_day from TTTH_class where _id = @classID
		select @duration = co._duration from TTTH_course co where co._id = (select top 1 c._course_id from TTTH_class c where c._id = @classID)
		set @i = 1
		
		declare @dateList table (d int)
		insert into @dateList select _date_in_week from TTTH_class_date_in_week where _class_id = @classID
		------------------
		-- prevent infinite loop --
		if (not exists(select * from @dateList))
		begin
			return
		end
		------------------
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
			insert into TTTH_class_date(_class_id, _date_number, _date) values(@classID, @i, @nextDate);
			set @i = @i + 1
			set @nextDate = DATEADD(day, 1, @nextDate)
		end
		--------------------------------------------
		SET NOCOUNT ON
	END