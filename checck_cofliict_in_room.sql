





CREATE FUNCTION [dbo].[check]
(
	@roomID int,
	@shift int
)
RETURNS INT
AS
BEGIN
	declare @num1 int, @num2 int

	select @num1 = count(distinct _date), @num2 = count(*) from TTTH_class cl
	join TTTH_class_date cd
	on cl._id = cd._class_id
	join TTTH_room r
	on r._id = cl._room_id
	where _shift = @shift and _room_id = @roomID

	if (@num1  = @num2)
	return 0 -- no conflict
	-- else
	return 1 -- confict
END



select [dbo].[check_confict_in_room](1,1)