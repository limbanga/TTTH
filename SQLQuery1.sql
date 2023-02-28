update TTTH_course
set _course_name = N'Teen suauw bang lenh', _price = 99, _length = 99
where _id = 3



select cl.*, co._course_name, r._room_name from TTTH_class cl 
inner join TTTH_course co
on cl._course_id = co._id
left join TTTH_room r
on cl._room_id = r._id

insert into TTTH_class (_class_name, _start_day, _end_day, _capacity, _shift, _course_id, _room_id)
values ('xxx', '2020-02-22', '2020-02-22', 222, 5, 10, 8)