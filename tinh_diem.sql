select * from ttth_exam where _class_id = @classID and _exam_number = @examNumber

select s._id,
s._student_name,
s._phone_number,
e._score, 
e._date_number 
from ttth_exam e join TTTH_student s on e._student_id = s._id
where e._class_id = @classID and e._exam_number = @examNumber

select max(_exam_number) from ttth_exam where _class_id = @classID;

select * from ttth_exam where _class_id = 3 and _student_id = 1