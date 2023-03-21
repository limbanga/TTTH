using System;
using System.Collections.Generic;
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

            using (SqlConnection connection = new SqlConnection(Env.stringConnect))
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
        #endregion

        #region Insert
        public static bool Insert(string name, double fee, int duration)
        {
            int rowsAffect = 0;
            string query = @"insert into TTTH_course (_course_name, _duration, _fee)
                                values (@name, @duration, @fee)";

            using (SqlConnection connection = new SqlConnection(Env.stringConnect))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@fee", fee);
                        cmd.Parameters.AddWithValue("@duration", duration);

                        rowsAffect = cmd.ExecuteNonQuery();

                        cmd.Dispose();
                    }
                    connection.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    //throw;
                }
            }

            return rowsAffect > 0;
        }

        public static bool Insert(ModelCourse c)
        {
            return Insert(c.Name, c.Fee, c.Duration);
        }

        #endregion

        #region Update

        public static bool Update(int id, string name, double fee, int duration)
        {
            int rowsAffect = 0;
            string query = @"update TTTH_course
                            set _course_name = @name, 
                            _price = @fee, 
                            _length = @duration
                            where _id = @id";

            using (SqlConnection connection = new SqlConnection(Env.stringConnect))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@fee", fee);
                        cmd.Parameters.AddWithValue("@duration", duration);
                        cmd.Parameters.AddWithValue("@id", id);

                        rowsAffect = cmd.ExecuteNonQuery();

                        cmd.Dispose();
                    }
                    connection.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    //throw;
                }
            }

            return rowsAffect > 0;
        }

        public static bool Update(ModelCourse c)
        {
            if(c.Id == -1)
            {
                MessageBox.Show("Id = -1, Khóa học chưa được tạo, không thể sửa.");
                return false;
            }
            return Update(c.Id, c.Name, c.Fee, c.Duration);
        }
        #endregion

    }
}
