IF (EXISTS(SELECT * FROM TTTH_room WHERE _room_name = @name AND _id != @ID))
BEGIN
	SELECT N'Tên phòng đã được sử dụng.'
	RETURN
END

IF (@capacity <= 0)
BEGIN
	SELECT N'Số lượng chỗ ngồi phải lớn hơn 0.'
	RETURN
END

UPDATE TTTH_room 
SET _room_name = @name,
_capacity = @capacity,
_room_type = @type
WHERE _id = @id