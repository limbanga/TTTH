using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTH.Models.DAO
{
    public static class DAOClass
    {
        public static List<ModelClass> GetAll()
        {
            string query = @"select cl.*, co._course_name, r._room_name from TTTH_class cl 
                            inner join TTTH_course co
                            on cl._course_id = co._id
                            left join TTTH_room r
                            on cl._room_id = r._id";

            List<ModelClass> list = new List<ModelClass>();

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
                            DateTime start = reader.GetDateTime(2);
                            DateTime end = reader.GetDateTime(3);
                            int maxCapacity = reader.GetInt32(4);
                            int shift = reader.GetInt32(7);
                            string courseName = reader.GetString(8);
                            string roomName = reader.IsDBNull(9)? "Chưa có phòng": reader.GetString(9);

                            // innit
                            ModelClass modelClass = new ModelClass(id, name, start, end, maxCapacity, shift, courseName, roomName);

                            // assign
                            list.Add(modelClass);

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

        public static bool Insert(string name, DateTime start, DateTime end, int maxCapacity, int shift, int courseId, int roomId)
        {

            int rowsAffect = 0;
            string query = @"insert into TTTH_class (_class_name, _start_day, _end_day, _capacity, _shift, _course_id, _room_id)
values (@name, @start, @end, @maxCapacity, @shift, @courseId, @roomId)";

            using (SqlConnection connection = new SqlConnection(Env.stringConnect))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@start", start);
                        cmd.Parameters.AddWithValue("@end", end);
                        cmd.Parameters.AddWithValue("@maxCapacity", maxCapacity);
                        cmd.Parameters.AddWithValue("@shift", shift);
                        cmd.Parameters.AddWithValue("@courseId", courseId != -1? courseId: DBNull.Value);
                        cmd.Parameters.AddWithValue("@roomId", roomId != -1? roomId: DBNull.Value);

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
        public static bool Insert(ModelClass c)
        {
            return Insert(c.Name, c.Start, c.End, c.MaxCapacity, c.Shift, c.CourseId, c.RoomId);
        }
    }
}
