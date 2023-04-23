using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTTH.Models.DTO;

namespace TTTH.Models.DAO
{
    public static class ModelClassDate
    {
        #region Select

        public static List<DTOClassDate> GetClassDatesByClassID(int classID)
        {
            List<DTOClassDate> list = new List<DTOClassDate>();
            string query = @"SELECT * FROM views_class_date WHERE _class_id = @classID;";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("classID", classID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DTOClassDate dTOClassDate = new DTOClassDate();

                        dTOClassDate.Id = reader.GetInt32(0);
                        dTOClassDate.ClassID = classID;
                        dTOClassDate.ClassName = reader.IsDBNull(2) ? "-" : reader.GetString(2);
                        dTOClassDate.DateNumber = reader.GetInt32(3);
                        dTOClassDate.Date = reader.GetDateTime(4);
                        dTOClassDate.RoomID = reader.IsDBNull(5) ? -1 : reader.GetInt32(5);
                        dTOClassDate.RoomName = reader.IsDBNull(6) ? "-" : reader.GetString(6);
                        dTOClassDate.Shift = reader.GetInt32(7);
                        dTOClassDate.TeacherID = reader.IsDBNull(8) ? -1 : reader.GetInt32(8);
                        dTOClassDate.TeacherName = reader.IsDBNull(9) ? "-" : reader.GetString(9);
                        dTOClassDate.IsHappend = reader.IsDBNull(10)? false: reader.GetBoolean(10);

                        list.Add(dTOClassDate);
                    }

                    reader.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return list;
        }

        public static DTOClassDate GetClassDate(DateTime tempDate, int teacherID, int shift)
        {
            DTOClassDate classDate = new DTOClassDate();
            string query = @"
                            SELECT *
                            FROM views_class_date 
                            WHERE
                            _date = @tempDate AND
                            _teacher_id = @teacherID AND
                            _shift = @shift";


            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@teacherID", teacherID);
                    cmd.Parameters.AddWithValue("@shift", shift);
                    cmd.Parameters.Add("@tempDate", System.Data.SqlDbType.Date).Value = tempDate;


                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        classDate.Id = reader.GetInt32(0);
                        classDate.ClassID = reader.GetInt32(1);
                        classDate.ClassName = reader.IsDBNull(2) ? "-" : reader.GetString(2);
                        classDate.DateNumber = reader.GetInt32(3);
                        classDate.Date = reader.GetDateTime(4);
                        classDate.RoomID = reader.IsDBNull(5) ? -1 : reader.GetInt32(5);
                        classDate.RoomName = reader.IsDBNull(6) ? "-" : reader.GetString(6);
                        classDate.TeacherID = reader.IsDBNull(8) ? -1 : reader.GetInt32(8);
                        classDate.TeacherName = reader.IsDBNull(9) ? "-" : reader.GetString(9);
                        classDate.Shift = shift;
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

            return classDate;
        }

        #endregion

        #region Update
        public static void Update(DTOClassDate cd)
        {
            Update(cd.Id, cd.RoomID, cd.TeacherID, cd.Date, cd.Shift, cd.IsHappend);
        }

        public static void Update(int id, int roomID, int teacherID, DateTime date, int shift, bool isHappen)
        {
            if (id == -1)
            {
                throw new DataBaseException("Buổi học không tồn tại.");
            }

            string query = @"
                            -- check room
                            IF(EXISTS (SELECT * FROM TTTH_class_date WHERE _date = @date AND _room_id = @roomID AND _shift = @shift AND _id != @ID))
                            BEGIN
	                            SELECT N'Phòng học đã được sử dụng bởi lớp khác.'
	                            RETURN
                            END
                            -- check teacher
                            IF(EXISTS (SELECT * FROM TTTH_class_date WHERE _date = @date AND _teacher_id = @teacherID AND _shift = @shift AND _id != @ID))
                            BEGIN
	                            SELECT N'Giảng viên bị trùng lịch dạy.'
	                            RETURN
                            END

                            BEGIN
	                            UPDATE TTTH_class_date
	                            SET
	                            _date = @date,
	                            _shift = @shift,
	                            _room_id = @roomID,
	                            _teacher_id = @teacherID,
                                _is_done = @isHappen
	                            WHERE _id = @ID
                            END";


            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@roomID", roomID != -1 ? roomID : DBNull.Value);
                    cmd.Parameters.AddWithValue("@teacherID", teacherID != -1 ? teacherID : DBNull.Value);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@shift", shift);
                    cmd.Parameters.AddWithValue("@isHappen", isHappen);

                    string errorMsg = (string) cmd.ExecuteScalar();
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
    }
}
