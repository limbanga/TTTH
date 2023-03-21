using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TTTH.Models.DAO
{
    internal class DAOUser
    {
        private DAOUser() {}
        public static ModelUser? CheckLogin(string username, string password)
        {
            string query = @"
select top 1 * from TTTH_user 
where _user_name = @username and _pass_word = @password";

            ModelUser? user = null;

            using (SqlConnection connection = new SqlConnection(Env.stringConnect))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string showName = reader.GetString(3);
                            string email = reader.GetString(4);
                            string phoneNumber = reader.GetString(5);
                            string address = reader.GetString(6);
                            int permitsGroup = reader.GetInt32(7);

                            user = new ModelUser(id, showName, email, phoneNumber, address, permitsGroup);
                        }
                        reader.Close();
                        cmd.Dispose();
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("CheckLogin"+ ex.Message);
                    //throw;
                }
            }
            return user;
        }   
    }
}
