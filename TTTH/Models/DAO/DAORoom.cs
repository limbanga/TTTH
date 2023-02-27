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
    }
}
