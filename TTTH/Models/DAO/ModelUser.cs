using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TTTH.Models.DAO
{
    public class ModelUser
    {
        private ModelUser() {}
        public static DTOUser CheckLogin(string userName, string password)
        {
            string query = @"
                            SELECT TOP 1 
                            _id, 
                            _show_name,
                            _email,
                            _phone_number,
                            _address,
                            _permission_group_id
                            from TTTH_user 
                            WHERE 
                            _user_name = @username AND
                            _pass_word = @password;
                            ";
            SqlDataReader reader;

            using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@username", userName);
                cmd.Parameters.AddWithValue("@password", password);

                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string showName = reader.GetString(1);
                    string email = reader.GetString(2);
                    string phoneNumber = reader.GetString(3);
                    string address = reader.GetString(4);
                    int perID = reader.GetInt32(5);

                    reader.Close();
                    return new DTOUser(id, userName, showName, email, phoneNumber, address, perID);
                }
                else
                {
                    reader.Close();
                    throw new Exception("Tên tài khoản hoặc mật khẩu không chính xác.");
                }
            } 
        }

        public static void ChangePassWord(string userName, string oldPass, string newPass)
        {
            string query = @"
                            IF(NOT EXISTS (SELECT * FROM TTTH_user WHERE _user_name = @username AND _pass_word = @oldPass))
                            BEGIN
	                            SELECT N'Mật khẩu cũ không chính xác.'
	                            RETURN
                            END

                            UPDATE TTTH_user
                            SET 
                            _pass_word = @newPass
                            WHERE 
                            _user_name = @username AND
                            _pass_word = @oldPass;";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@username", userName);
                    cmd.Parameters.AddWithValue("@oldPass", oldPass);
                    cmd.Parameters.AddWithValue("@newPass", newPass);

                    string errorMsg = (string) cmd.ExecuteScalar();

                    if (!string.IsNullOrEmpty(errorMsg)) 
                    { 
                        throw new DataBaseException(errorMsg);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static List<DTOUser> GetAllTeacher()
        {
            List<DTOUser> list = new List<DTOUser>();
            string query = @"SELECT
                            _id, 
                            _show_name
                            FROM TTTH_user 
                            WHERE 
                            _permission_group_id = 3;";

            using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string showName = reader.GetString(1);

                    DTOUser teacher = new DTOUser(id, showName);
                    list.Add(teacher);
                }
                reader.Close();
                return list;
            }
        }


    }
}
