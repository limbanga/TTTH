-- check date
-- romID, start_date, shift, date_in_week

declare @roomID int,@shift int, @start date

select @roomID = 2, @start = '2023-03-27', @shift = 1

select d._date from 
TTTH_room r join TTTH_class c
on r._id = c._room_id
join TTTH_class_date d
on c._id = d._class_id
where
r._id = @roomID and
d._date >= @start and
c._shift = 1 and
d._date not in (
select _date from temp_date_to_check
)

insert into temp_date_to_check values(1, '2023-03-27')
