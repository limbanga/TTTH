using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TTTH.Models.DTO;
using static System.Windows.Forms.AxHost;

namespace TTTH.Models.DAO
{
    public static class ModelClass
    {
        #region Select
        public static List<DTOClass> GetAll()
        {

            List<DTOClass> list = new List<DTOClass>();
            
            string query = @"
                            SELECT 
                            cl._id,
                            cl._class_name,
                            (SELECT c._course_name FROM TTTH_course c WHERE _id = cl._course_id) as _course_name,
                            cl._start_day,
                            (SELECT MAX(_date) FROM TTTH_class_date WHERE _class_id = cl._id) as _end_day,
                            cl._capacity,
                            cl._shift,
                            (SELECT COUNT(*) FROM ttth_register WHERE _class_id = cl._id) as _number_of_student_register,
							cl._room_id,
							(SELECT r._room_name FROM TTTH_room r WHERE _id = cl._room_id) as _room_name,
							cl._teacher_id,
							(SELECT u._show_name FROM TTTH_user u WHERE _id = cl._teacher_id) as _teacher_name,
                            (
                            (SELECT c._fee FROM TTTH_course c WHERE _id = cl._course_id) * 
                            (SELECT COUNT(*) FROM ttth_register WHERE _class_id = cl._id)
                            ) as _in_come
                            FROM TTTH_class cl;";

            int userPermissionID = BUS.user.PermissionID;

            if (userPermissionID == 2)
            {
                int userID = BUS.user.Id;
                query = @"
                            SELECT 
                            cl._id,
                            cl._class_name,
                            (SELECT c._course_name FROM TTTH_course c WHERE _id = cl._course_id) as _course_name,
                            cl._start_day,
                            (SELECT MAX(_date) FROM TTTH_class_date WHERE _class_id = cl._id) as _end_day,
                            cl._capacity,
                            cl._shift,
                            (SELECT COUNT(*) FROM ttth_register WHERE _class_id = cl._id) as _number_of_student_register,
							cl._room_id,
							(SELECT r._room_name FROM TTTH_room r WHERE _id = cl._room_id) as _room_name,
							cl._teacher_id,
							(SELECT u._show_name FROM TTTH_user u WHERE _id = cl._teacher_id) as _teacher_name
                            FROM TTTH_class cl 
                            WHERE cl._teacher_id = " + userID + ";";
            }

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DTOClass dTOClass = new DTOClass();

                        dTOClass.Id = reader.GetInt32(0);
                        dTOClass.Name = reader.GetString(1);
                        dTOClass.CourseName = reader.GetString(2);
                        dTOClass.Start = reader.GetDateTime(3);
                        dTOClass.End = reader.IsDBNull(4)? DateTime.MinValue: reader.GetDateTime(4);
                        dTOClass.MaxCapacity = reader.GetInt32(5);
                        dTOClass.Shift = reader.GetInt32(6);
                        dTOClass.NumberOfStudent = reader.GetInt32(7);
                        dTOClass.RoomID = reader.IsDBNull(8)? -1: reader.GetInt32(8);
                        dTOClass.RoomName = reader.IsDBNull(9) ? "-" : reader.GetString(9);
                        dTOClass.TeacherID = reader.IsDBNull(10) ? -1 : reader.GetInt32(10);
                        dTOClass.TeacherName = reader.IsDBNull(11) ? "-" : reader.GetString(11);
                        if (userPermissionID == 1)
                        {
                            dTOClass.Income = reader.IsDBNull(12) ? -1 : reader.GetDouble(12);
                        }
                        // assign
                        list.Add(dTOClass);
                    }
                    reader.Close();
                    cmd.Dispose();
                    DataBase.CloseConectionIfOpen();
                }
            }
            catch (Exception)
            {
                throw;
            }
            
            return list;
        }

        public static List<string> GetClassNameByCourseID(int courseID, int maxRecord)
        {
            List<string> list = new List<string>();
            string query = $"SELECT TOP { maxRecord } _class_name FROM TTTH_class WHERE _course_id = @courseID;";
            using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@courseID", courseID);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader.GetString(0)); 
                }
                reader.Close();
                cmd.Dispose();
                DataBase.CloseConectionIfOpen();
            }
            return list;
        }
        #endregion

        #region Insert
        public static void Insert(string name, DateTime start, int maxCapacity,
            int shift, int courseID, int roomID, int teacherID, List<Int32> datesInWeek)
        {
            string array = "(" + string.Join(",", datesInWeek) + ")";
            string query = @"
                            IF(NOT EXISTS(SELECT * FROM TTTH_course WHERE _id = @courseID))
                            BEGIN
	                            SELECT N'Khóa học bạn muốn mở lớp không tồn tại hoặc đã bị xóa.'
	                            RETURN
                            END

                            IF(EXISTS(SELECT * FROM TTTH_class WHERE _class_name = @name))
                            BEGIN
	                            SELECT N'Tên lớp học trùng lặp.'
	                            RETURN
                            END

                            INSERT INTO TTTH_class VALUES 
                            (@name, @startDate, @capacity, @courseID, @teacherID, @shift, @roomID)

                            DECLARE @classID int
                            SELECT @classID = IDENT_CURRENT('TTTH_class') 
                           

                            DECLARE @i int, @duration int, @tempDate date

                            SELECT @i = 1, @duration = _duration FROM TTTH_course WHERE _id = @courseID
                            SELECT @tempDate = @startDate

                            WHILE @i <= @duration
                            BEGIN
	                            -- skip invalid day in week
	                            WHILE DATEPART(dw, @tempDate) not in " + array + @"
		                            SELECT @tempDate = DATEADD(D, 1, @tempDate)
	                            -- insert 
	                            INSERT INTO TTTH_class_date VALUES (@classID, @i, @tempDate, @roomID, @shift, @teacherID, 0)
	                            -- update var
	                            SET @i = @i + 1
	                            SELECT @tempDate = DATEADD(D, 1, @tempDate) -- get next date
                            END
                            ";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@startDate", start);
                    cmd.Parameters.AddWithValue("@capacity", maxCapacity);
                    cmd.Parameters.AddWithValue("@shift", shift);
                    cmd.Parameters.AddWithValue("@courseID", courseID);
                    cmd.Parameters.AddWithValue("@teacherID", teacherID != -1? teacherID: DBNull.Value);
                    cmd.Parameters.AddWithValue("@roomID", roomID != -1 ? roomID : DBNull.Value);

                    string errorMsg = (string) cmd.ExecuteScalar();
                    cmd.Dispose();
                    DataBase.CloseConectionIfOpen();

                    if (!string.IsNullOrEmpty(errorMsg))
                    {
                        throw new DataBaseException(errorMsg);
                    }
                }
            }
            catch (DataBaseException)
            {
                throw;
            }
            catch (Exception) {
                throw new Exception("Lỗi không xác định.");
            }
        }

        public static void Insert(DTOClass c, List<Int32> datesInWeek)
        {
            Insert(c.Name, c.Start, c.MaxCapacity, c.Shift, c.CourseID, c.RoomID, c.TeacherID, datesInWeek);
        }

        #endregion

        #region Update
        public static void Update(DTOClass c)
        {
            Update(c.Id, c.RoomID, c.TeacherID, c.Name, c.MaxCapacity, c.Shift);    
        }

        private static void Update(int id, int roomID, int teacherID, string name, int maxCapacity, int shift)
        {
            if (id == -1)
            {
                throw new DataBaseException("Lớp học không tồn tại hoặc đã bị xóa.");
            }

            string query = @"
                            IF(NOT EXISTS (SELECT * FROM TTTH_class WHERE _id = @ID))
                            BEGIN
	                            SELECT N'Lớp học không tồn tại hoặc đã bị xóa.'
	                            RETURN
                            END

                            IF(EXISTS (SELECT * FROM TTTH_class WHERE _id != @ID AND _class_name = @name))
                            BEGIN
	                            SELECT N'Tên lớp học bị trùng lặp.'
	                            RETURN
                            END

                            IF(NOT EXISTS(SELECT * FROM TTTH_room WHERE _id = @roomID) AND @roomID IS NOT NULL)
                            BEGIN
	                            SELECT N'Phòng học bạn chọn không tồn tại hoặc đã bị xóa.'
	                            RETURN
                            END

                            IF(NOT EXISTS(SELECT * FROM TTTH_user WHERE _id = @teacherID) AND @teacherID IS NOT NULL)
                            BEGIN
	                            SELECT N'Giảng viên bạn chọn không tồn tại.'
	                            RETURN
                            END

                            UPDATE TTTH_class
                            SET 
                            _class_name = @name,
                            _capacity = @capacity,
                            _teacher_id = @teacherID,
                            _room_id = @roomID,
                            _shift = @shift
                            WHERE 
                            _id = @ID

                            UPDATE TTTH_class_date
                            SET 
                            _teacher_id = @teacherID,
                            _room_id = @roomID,
                            _shift = @shift
                            WHERE 
                            _class_id = @ID AND _is_done = 0";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@capacity", maxCapacity);
                    cmd.Parameters.AddWithValue("@shift", shift);
                    cmd.Parameters.AddWithValue("@teacherID", teacherID != -1 ? teacherID : DBNull.Value);
                    cmd.Parameters.AddWithValue("@roomID", roomID != -1 ? roomID : DBNull.Value);

                    string errorMsg = (string)cmd.ExecuteScalar();
                    cmd.Dispose();
                    DataBase.CloseConectionIfOpen();

                    if (!string.IsNullOrEmpty(errorMsg))
                    {
                        throw new DataBaseException(errorMsg);
                    }
                }
            }
            catch (DataBaseException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new Exception("Lỗi không xác định.");
            }
        }

        #endregion

        #region Delete
        public static void DeleteClass(int id)
        {
            string query = $"DELETE FROM TTTH_class WHERE _id = @id;";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    if (cmd.ExecuteNonQuery() <= 0)
                    {
                        throw new DataBaseException("Lớp học không tồn tại hoặc đã bị xóa.");
                    }
                }
            }
            catch (DataBaseException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new Exception("Lỗi không xác định");
            }
        }
        #endregion

    }
}
