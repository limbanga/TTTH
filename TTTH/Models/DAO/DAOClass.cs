using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTH.Models.DAO
{
    public static class DAOClass
    {
        #region Select
        public static List<DTOCLass> GetAll()
        {
            List<DTOCLass> list = new List<DTOCLass>();

            string query = @"SELECT 
                            cl._id,
                            cl._class_name,
                            (SELECT c._course_name FROM TTTH_course c WHERE _id = cl._course_id) as _course_name,
                            cl._start_day,
                            (SELECT MAX(_date) FROM TTTH_class_date WHERE _class_id = cl._id) as _end_day,
                            cl._capacity,
                            cl._shift,
                            (SELECT COUNT(*) FROM ttth_register WHERE _class_id = cl._id) as _number_of_student_register
                            FROM TTTH_class cl;";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int classID = reader.GetInt32(0);
                        string className = reader.GetString(1);
                        string courseName = reader.GetString(2);
                        DateTime startDate = reader.GetDateTime(3);
                        DateTime endDate = reader.GetDateTime(4);
                        int classCapacity = reader.GetInt32(5);
                        int shift = reader.GetInt32(6);
                        int numberOfStudent = reader.GetInt32(7);

                        // innit
                        DTOCLass modelClass = new DTOCLass(classID, className, startDate, endDate,
                            classCapacity, shift, courseName, numberOfStudent);

                        // assign
                        list.Add(modelClass);

                    }
                    reader.Close();
                    cmd.Dispose();
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
            string query = $"select top { maxRecord } _class_name from TTTH_class where _course_id = @courseID;";
            using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@courseID", courseID);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader.GetString(0)); 
                }
                reader.Close();
            }
            return list;
        }

        #endregion

        #region Insert
        public static void Insert(string name, DateTime start, int maxCapacity,
            int shift, int courseID, int roomID, int teacherID, List<Int32> datesInWeek)
        {
            string sub = "";
            foreach (var d in datesInWeek)
            {
                sub += $"INSERT INTO TTTH_class_date_in_week VALUES (@classID, { d });\n";
            }
            string array = "(" + string.Join(",", datesInWeek) + ")";
            string query = @"
                            IF(NOT EXISTS(SELECT * FROM TTTH_course WHERE _id = @courseID))
                            BEGIN
	                            SELECT N'Khóa học bạn muốn mở lớp không tồn tại hoặc đã bị xóa.'
	                            RETURN
                            END

                            IF((SELECT _capacity FROM TTTH_room WHERE _id = @roomID) < @capacity)
                            BEGIN
	                            SELECT N'Phòng học bạn chọn không có đủ chổ cho lớp.'
	                            RETURN
                            END

                            INSERT INTO TTTH_class VALUES 
                            (@name, @startDate, @capacity, @courseID, @teacherID, @shift, @roomID)

                            DECLARE @classID int
                            SELECT @classID = IDENT_CURRENT('TTTH_class') 
                            -- insert dates in week
                            " +
                            sub +
                           @"DECLARE @i int, @duration int, @tempDate date

                            SELECT @i = 1, @duration = _duration FROM TTTH_course WHERE _id = @courseID
                            SELECT @tempDate = @startDate

                            WHILE @i <= @duration
                            BEGIN
	                            -- skip invalid day in week
	                            WHILE DATEPART(dw, @tempDate) not in "+ array + @"
		                            SELECT @tempDate = DATEADD(D, 1, @tempDate)
	                            -- insert 
	                            INSERT INTO TTTH_class_date VALUES (@classID, @i, @tempDate, @roomID, @shift, @teacherID, 0)
	                            -- update var
	                            SET @i = @i + 1
	                            SELECT @tempDate = DATEADD(D, 1, @tempDate) -- get next date
                            END";
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

        public static void Insert(DTOCLass c, List<Int32> datesInWeek)
        {
            Insert(c.Name, c.Start, c.MaxCapacity, c.Shift, c.CourseID, c.RoomID, c.TeacherID, datesInWeek);
        }

        #endregion

        #region Update


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
