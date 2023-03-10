using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTH.Models.DAO
{
    public static class DAORoom
    {

        #region Select
        public static List<ModelRoom> GetAll()
        {
            string query = @"select * from TTTH_room";

            List<ModelRoom> list = new List<ModelRoom>();

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
                            int capacity = reader.GetInt32(2);
                            string type = reader.GetString(3);

                            // innit
                            ModelRoom modelRoom = new ModelRoom(id, name, type, capacity);
                            // assign
                            list.Add(modelRoom);
                        }
                        reader.Close();
                        cmd.Dispose();
                    }
                    connection.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("DAOroom 46" + e.Message);
                    //throw;
                }
            }
            return list;
        }
        #endregion

        #region Insert
        public static bool Insert(string name, string type, int capacity)
        {
            int rowsAffect = 0;
            string query = @"insert into TTTH_room(_room_name, _room_type, _capacity) values (@name, @type, @capacity);";

            using (SqlConnection connection = new SqlConnection(Env.stringConnect))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@type", type);
                        cmd.Parameters.AddWithValue("@capacity", capacity);

                        rowsAffect = cmd.ExecuteNonQuery();

                        cmd.Dispose();
                    }
                    connection.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    // if - else bắt lỗi cụ thể rồi ném ra ngoai
                    // tạm thời hard code
                    throw new Exception("Tên trùng lặp");
                }
            }

            return rowsAffect > 0;
        }

        public static bool Insert(ModelRoom r)
        {
            return Insert(r.Name, r.Type, r.Capacity);
        }

        #endregion



        #region Update

        public static bool Update(int id, string name, string type, int capacity)
        {
            int rowsAffect = 0;
            string query = @"update TTTH_room set _room_name = @name, _capacity = @capacity, _room_type = @type where _id = @id;";

            using (SqlConnection connection = new SqlConnection(Env.stringConnect))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@type", type);
                        cmd.Parameters.AddWithValue("@capacity", capacity);
                        cmd.Parameters.AddWithValue("@id", id);

                        rowsAffect = cmd.ExecuteNonQuery();

                        cmd.Dispose();
                    }
                    connection.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    throw new Exception("Nem thong diep ra ngoai ne`.");
                }
            }

            return rowsAffect > 0;
        }

        public static bool Update(ModelRoom r)
        {
            if (r.Id == -1)
            {
                throw new Exception("Phòng học chưa được tạo hoặc đã bị xóa!");
            }
            return Update(r.Id, r.Name, r.Type, r.Capacity);
        }
        #endregion
    }
}
