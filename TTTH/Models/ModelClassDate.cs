using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTTH.Models.DAO;

namespace TTTH.Models
{
    public static class ModelClassDate
    {
        #region Select

        public static List<DTOClassDate> GetClassDatesByClassID (int classID)
        {
            List<DTOClassDate> list = new List<DTOClassDate> ();
            string query = @"SELECT * FROM views_class_date WHERE _class_id = @classID;";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("classID", classID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string className = reader.IsDBNull(2) ? "-": reader.GetString(2);
                        int dateNumber = reader.GetInt32(3);
                        DateTime date = reader.GetDateTime(4);
                        int roomID = reader.IsDBNull(5)? -1 : reader.GetInt32(5);
                        string roomName = reader.IsDBNull(6) ? "-" : reader.GetString(6);
                        int shift = reader.GetInt32(7);
                        int teacherID = reader.IsDBNull(8)? -1 : reader.GetInt32(8);
                        string teacherName = reader.IsDBNull(9) ? "-" : reader.GetString(9);    

                        DTOClassDate dTOClassDate = new DTOClassDate(id, classID, roomID, teacherID, dateNumber,date, shift, roomName, teacherName);

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

        #endregion

        #region Update
        public static void Update(DTOClassDate cd)
        {
            Update(cd.Id, cd.RoomID, cd.TeacherID, cd.Date, cd.Shift);
        }

        public static void Update(int id, int roomID, int teacherID, DateTime date, int shift)
        {
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
	                            _teacher_id = @teacherID
	                            WHERE _id = @ID
                            END";
            
            
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@roomID", roomID != -1? roomID: DBNull.Value);
                    cmd.Parameters.AddWithValue("@teacherID", teacherID != -1 ? teacherID : DBNull.Value);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@shift", shift);

                    SqlDataReader reader = cmd.ExecuteReader();
                    string errorMsg = "";
                    if (reader.Read())
                    {
                        errorMsg = reader.GetString(0);
                    }
                    reader.Close();

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
