using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTH.Models.DAO
{
    public class DAONotification
    {

        public static List<ModelNotification> GetAll()
        {
            string query = @"select n.*, u._show_name from TTTH_notification n
inner join TTTH_user u
on n._user_id = u._id";

            List<ModelNotification> list = new List<ModelNotification>();

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
                            int id = reader.GetInt32(0);
                            string topic = reader.GetString(1);
                            string content = reader.GetString(2);
                            DateTime created_date = reader.GetDateTime(3);
                            string userPostName = reader.GetString(5);

                            ModelNotification modelNotification =
                                new ModelNotification(id, topic, content, userPostName, created_date);

                            list.Add(modelNotification);
                        }
                        reader.Close();
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
            return list;
        }

        public static bool Insert(string topic, string content, int user_id)
        {
            int rowsAffect = 0;
            string query = @"insert into TTTH_notification(_topic, _content, _user_id)
values (@topic, @content, @user_id)";

            using (SqlConnection connection = new SqlConnection(Env.stringConnect))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@topic", topic);
                        cmd.Parameters.AddWithValue("@content", content);
                        cmd.Parameters.AddWithValue("@user_id", user_id);

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
    }
}
