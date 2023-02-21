select n.*, u._show_name from TTTH_notification n
inner join TTTH_user u
on n._user_id = u._id