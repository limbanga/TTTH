select * from 
TTTH_class cl join TTTH_room r 
on cl._room_id = r._id
join TTTH_class_date cd 
on cd._class_id = cl._id
where cl._shift = 1 and _room_id = 1 and _date > cl._start_day