select cl._id,
cl._class_name,
cl._start_day,
cl._end_day,
cl._capacity,
cl._shift,

cl._course_id,
co._course_name,
co._fee,
co._duration,

cl._room_id,
r._room_name,
r._capacity,
r._room_type

from TTTH_class cl 
inner join TTTH_course co
on cl._course_id = co._id
left join TTTH_room r
on cl._room_id = r._id