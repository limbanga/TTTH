using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTH.Models.DAO
{
    public static class DAOCourse
    {
        
        #region Select
        public static List<ModelCourse> GetAll()
        {
            string query = @"select * from TTTH_course";

            List<ModelCourse> list = new List<ModelCourse>();

            using (SqlConnection connection = new SqlConnection(BUS.stringConnect))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            // parse
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            double fee = reader.GetDouble(2);
                            int duration = reader.GetInt32(3);
                            // innit
                            ModelCourse modelCourse =
                                new ModelCourse(id, name, fee, duration);
                            // assign
                            list.Add(modelCourse);
                        }
                        reader.Close();
                        cmd.Dispose();
                    }
                    connection.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("48+couersdkah " + e.Message);
                    //throw;
                }
            }
            return list;
        }
        public static bool CheckCourseBegin(int id)
        {
            string query = @"select COUNT(*) from TTTH_class where _course_id = @id;";

            using (SqlConnection connection = new SqlConnection(BUS.stringConnect))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            return reader.GetInt32(0) > 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("CheckCourseBegin " + ex.Message);
                    throw;
                }
            }
            return false;
        }
        #endregion

        #region Insert
        public static void Insert(string name, double fee, int duration)
        {
            string query = @"[dbo].[insert_course]";

            using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@fee", fee);
                cmd.Parameters.AddWithValue("@duration", duration);

                DataTable dt = DataBase.ExcuteQuery(cmd);

                string error = (string) dt.Rows[0][0];
                // no erorr -> return
                if (string.IsNullOrEmpty(error)) { return; }

                throw new Exception(error);
            }
        }

        public static void Insert(ModelCourse c)
        {
            Insert(c.Name, c.Fee, c.Duration);
        }

        #endregion

        #region Update

        public static void Update(int id, string name, double fee, int duration)
        {
            if (id == -1)
            {
                throw new Exception("Không thể tìm thấy ID khóa học.");
            }

            string query = @"[dbo].[update_course]";

            using (SqlConnection connection = new SqlConnection(BUS.stringConnect))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@fee", fee);
                        cmd.Parameters.AddWithValue("@duration", duration);
                        cmd.Parameters.AddWithValue("@id", id);

                        SqlParameter returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                        returnParameter.Direction = ParameterDirection.ReturnValue;

                        cmd.ExecuteNonQuery();

                        int returnValue = (int) returnParameter.Value;
                        MessageBox.Show("DAOcourse-Update-> return value=" + returnValue);
                        cmd.Dispose();
                        if (returnValue == 1)
                        {
                            throw new Exception("Tên khóa học bị trùng lặp. Vui lòng chọn một tên khác!");
                        }
                        if (returnValue == 2)
                        {
                            throw new Exception("Học phí không thể là một số âm!. Vui lòng nhập lại.");
                        }
                        if (returnValue == 3)
                        {
                            throw new Exception("Thời lượng phải là một số nguyên dương. Vui lòng nhập lại.");
                        }
                        if (returnValue == 4)
                        {
                            throw new Exception("Khóa học đã mở lớp. Không thể điều chỉnh thông tin thời lượng khóa học");
                        }
                    }
                    connection.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static void Update(ModelCourse c)
        {
            Update(c.Id, c.Name, c.Fee, c.Duration);
        }
        #endregion

        #region Delete

        public static void Delete(int courseID) 
        {
            string query = @"delete from TTTH_course where _id = @courseID";

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
