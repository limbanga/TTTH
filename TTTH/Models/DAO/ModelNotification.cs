using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTTH.Models.DTO;

namespace TTTH.Models.DAO
{
    public class ModelNotification
    {
        public static List<DTONotification> GetAll()
        {
            string query = @"
                            SELECT n.*,
                            u._show_name 
                            FROM TTTH_notification n
                            INNER JOIN TTTH_user u
                            ON n._user_id = u._id
                            ORDER BY n._created_date DESC;";

            List<DTONotification> list = new List<DTONotification>();

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string topic = reader.GetString(1);
                        string content = reader.GetString(2);
                        DateTime created_date = reader.GetDateTime(3);
                        string userPostName = reader.GetString(5);

                        DTONotification modelNotification =
                            new DTONotification(id, topic, content, userPostName, created_date);

                        list.Add(modelNotification);
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

        public static void Insert(string topic, string content, int user_id)
        {
            string query = @"
                        INSERT INTO TTTH_notification (_topic, _content, _user_id)
                        VALUES (@topic, @content, @user_id)";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@topic", topic);
                    cmd.Parameters.AddWithValue("@content", content);
                    cmd.Parameters.AddWithValue("@user_id", user_id);

                    cmd.ExecuteNonQuery();

                    cmd.Dispose();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
