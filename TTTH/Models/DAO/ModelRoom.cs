using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TTTH.Models.DAO
{
    public static class ModelRoom
    {

        #region Select
        public static List<DTOroom> GetAll()
        {
            string query = @"select * from TTTH_room";

            List<DTOroom> list = new List<DTOroom>();


                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            // parse
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            int capacity = reader.GetInt32(2);
                            string type = reader.GetString(3);

                            // innit
                            DTOroom modelRoom = new DTOroom(id, name, type, capacity);
                            // assign
                            list.Add(modelRoom);
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

        public static bool CheckRoomBeforeDelete(int id)
        {
            string query = @"SELECT COUNT(*) FROM TTTH_class_date WHERE _room_id = @roomID;";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("roomID", id);

                    int isUsed = (int) cmd.ExecuteScalar();
                    cmd.Dispose();

                    return isUsed > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region Insert
        public static void Insert(string name, string type, int capacity)
        {
            string query = @"
                            IF (EXISTS(SELECT * FROM TTTH_room WHERE _room_name = @name))
                            BEGIN
	                            SELECT N'Tên phòng đã được sử dụng.'
	                            RETURN
                            END

                            IF (@capacity <= 0)
                            BEGIN
	                            SELECT N'Số lượng chỗ ngồi phải lớn hơn 0.'
	                            RETURN
                            END

                            INSERT INTO TTTH_room(_room_name, _room_type, _capacity) 
                            VALUES (@name, @type, @capacity);";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@capacity", capacity);

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
            catch (Exception ex)
            {
                throw new Exception("Lỗi không xác định."+ex.Message);
            }
        }

        public static void Insert(DTOroom r)
        {
            Insert(r.Name, r.Type, r.Capacity);
        }

        #endregion

        #region Update

        public static void Update(int id, string name, string type, int capacity)
        {
            if (id == -1)
            {
                throw new DataBaseException("Phòng học không tồn tại");
            }

            string query = @"
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
                            WHERE _id = @ID;";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@capacity", capacity);
                    cmd.Parameters.AddWithValue("@ID", id);

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
            catch (Exception)
            {
                throw new Exception("Lỗi không xác định.");
            }
        }

        public static void Update(DTOroom r)
        {
            Update(r.Id, r.Name, r.Type, r.Capacity);
        }

        #endregion

        #region Delete
        internal static void Delete(int roomID)
        {
            string query = @"DELETE FROM TTTH_room WHERE _id = @ID;;";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@ID", roomID);
;
                    if(cmd.ExecuteNonQuery() <= 0)
                    {
                        throw new DataBaseException("Phòng học không tồn tại hoặc đã bị xóa.");
                    }
                    cmd.Dispose();
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
