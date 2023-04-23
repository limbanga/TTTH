using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTTH.Models.DTO;

namespace TTTH.Models.DAO
{
    public static class ModelCourse
    {
        
        #region Select
        public static List<DTOCourse> GetAll()
        {
            string query = @"SELECT * FROM TTTH_course";

            List<DTOCourse> list = new List<DTOCourse>();
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DTOCourse c = new DTOCourse();
                        // parse
                        c.Id = reader.GetInt32(0);
                        c.Name = reader.GetString(1);
                        c.Fee = reader.GetDouble(2);
                        c.Duration = reader.GetInt32(3);
                        // assign
                        list.Add(c);
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

        public static bool CheckCourseBegin(int id)
        {
            string query = @"SELECT COUNT(*) FROM TTTH_class WHERE _course_id = @id;";
            bool result = false;
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    result = ((int) cmd.ExecuteScalar()) > 0;
                    cmd.Dispose();
                    DataBase.CloseConectionIfOpen();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return result;
        }
        #endregion

        #region Insert

        public static void Insert(string name, double fee, int duration)
        {
            string query = @"
                            IF (EXISTS(SELECT * FROM TTTH_course WHERE _course_name = @name))
                            BEGIN
	                            SELECT N'Tên khóa học trùng lặp.'
	                            RETURN
                            END

                            IF (@fee < 0 )
                            BEGIN
	                            SELECT N'Học phí không thể âm.'
	                            RETURN
                            END

                            IF (@duration <= 0)
                            BEGIN
	                            SELECT N'Số buổi học phải lớn hơn 0.'
	                            RETURN
                            END

                            INSERT INTO TTTH_course (_course_name, _fee, _duration)
                            VALUES (@name, @fee, @duration);";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@fee", fee);
                    cmd.Parameters.AddWithValue("@duration", duration);

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

        public static void Insert(DTOCourse c)
        {
            Insert(c.Name, c.Fee, c.Duration);
        }

        #endregion

        #region Update

        public static void Update(int id, string name, double fee, int duration)
        {
            if (id == -1)
            {
                throw new DataBaseException("Khóa học không tồn tại hoặc đã bị xóa.");
            }

            string query = @"
                        IF (NOT EXISTS (SELECT * FROM TTTH_course WHERE _id =  @id ))
                        BEGIN
	                        SELECT N'Khóa học không tồn tại hoặc đã bị xóa.'
	                        RETURN
                        END

                        IF (EXISTS (SELECT * FROM TTTH_course WHERE _id !=  @id AND _course_name = @name))
                        BEGIN
	                        SELECT N'Tên khóa học trùng lặp.'
	                        RETURN
                        END

                        IF (@fee < 0)
                        BEGIN
	                        SELECT N'Học phí không thể âm.'
	                        RETURN
                        END

                        IF (@duration <= 0)
                        BEGIN
	                        SELECT N'Số buổi học phải lớn hơn 0.'
	                        RETURN
                        END


                        IF (
                        EXISTS (SELECT * FROM ttth_course WHERE _duration != @duration AND _id = @id) AND
                        EXISTS (SELECT * FROM ttth_class WHERE _course_id = @id)
                        )
                        BEGIN
	                        SELECT N'Khóa học đã được mở lớp. Không thể chỉnh sửa thông tin thời lượng.'
	                        RETURN
                        END

                        UPDATE TTTH_course
                        SET 
                        _course_name = @name, 
                        _fee = @fee, 
                        _duration = @duration
                        WHERE _id = @id";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@fee", fee);
                    cmd.Parameters.AddWithValue("@duration", duration);
                    cmd.Parameters.AddWithValue("@id", id);

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
            catch (Exception)
            {
                throw new Exception("Lỗi không xác định.");
            }
        }

        public static void Update(DTOCourse c)
        {
            Update(c.Id, c.Name, c.Fee, c.Duration);
        }
        #endregion

        #region Delete

        public static void Delete(int courseID) 
        {
            string query = @"DELETE FROM TTTH_course WHERE _id = @courseID";

            using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@courseID", courseID);

                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        throw new DataBaseException("Khóa học không tồn tại hoặc đã bị xóa.");
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
        }

        #endregion

    }
}
