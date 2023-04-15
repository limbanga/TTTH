select s._id,
s._student_name,
s._phone_number, 
(select count(*) from TTTH_attend where _student_id = s._id and _class_id = @classID and _status = 'a') as '_total_absence',
(select count(*) from TTTH_attend where _student_id = s._id and _class_id = @classID and _status = 'l') as '_total_late',
(select AVG(_score) from TTTH_exam where _student_id = s._id and _class_id = @classID) as '_avg_score'
from TTTH_student s inner join TTTH_register r on s._id = r._student_id 
where r._class_id = @classID


