

declare @nextExamNumber int, @classID int, @dateNumber int
set @classID = 3
set @dateNumber = 1

select @nextExamNumber =  max(_exam_number) + 1 from TTTH_exam where _class_id = @classID

insert into TTTH_exam (_exam_number, _class_id, _date_number,_student_id, _score)
select
@nextExamNumber,
r._class_id,
@dateNumber, 
s._id,
0
from TTTH_student s join TTTH_register r on s._id = r._student_id 
where _class_id =@classID
and(
not exists (
	select * from TTTH_exam where 
	_exam_number = @nextExamNumber and
	_class_id = @classID and
	_student_id = s._id
) 
); 