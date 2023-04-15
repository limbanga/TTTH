insert into TTTH_exam (_exam_number, _class_id, _date_number,_student_id, _score)
select
1, -- parameter
r._class_id,
1, -- parameter
s._id,
0
from TTTH_student s join TTTH_register r on s._id = r._student_id 
where _class_id = 3 -- parameter
and(
not exists (
	select * from TTTH_exam where 
	_exam_number = 1 and
	_class_id = 3 and
	_student_id = s._id
)
); 


----- Bang pro hon ------

insert into TTTH_exam (_exam_number, _class_id, _date_number,_student_id, _score)
select
1, -- parameter
r._class_id,
1, -- parameter
s._id,
0
from TTTH_student s join TTTH_register r on s._id = r._student_id 
where _class_id = 3 -- parameter
and(
not exists (
	select * from TTTH_exam where 
	_exam_number = 1 and
	_class_id = 3 and
	_student_id = s._id
)
); 


