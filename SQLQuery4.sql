﻿select count(case when _status = 'a' then 1 else 0 end) from TTTH_attend where _class_id = 3 and _student_id = 1