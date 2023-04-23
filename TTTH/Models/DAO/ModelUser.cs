using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TTTH.Models.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
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
                            IF(NOT EXISTS (SELECT * FROM TTTH_user WHERE _user_name = @username))
                            BEGIN
	                            SELECT N'Tài khoản của bạn hiện đã bị xóa.'
	                            RETURN
                            END

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
                throw new Exception("Lỗi không xác định");
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
                            _permission_group_id = 2;";

            using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DTOUser teacher = new DTOUser();

                    teacher.Id = reader.GetInt32(0);
                    teacher.ShowName = reader.GetString(1);

                    list.Add(teacher);
                }
                reader.Close();
                cmd.Dispose();
                DataBase.CloseConectionIfOpen();

                return list;
            }
        }

        public static List<DTOUser> GetAllAccount()
        {
            List<DTOUser> list = new List<DTOUser>();
            string query = @"
                        SELECT
                        _id,
                        _user_name,
                        _show_name,
                        _email,
                        _phone_number,
                        _address,
                        _permission_group_id
                        FROM TTTH_user";

            using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DTOUser account = new DTOUser();
                    account.Id = reader.GetInt32(0);
                    account.LoginName = reader.GetString(1);
                    account.ShowName = reader.GetString(2);
                    account.Email = reader.GetString(3);
                    account.PhoneNumber = reader.GetString(4);
                    account.Address = reader.GetString(5);
                    account.PermissionID = reader.GetInt32(6);

                    list.Add(account);
                }
                reader.Close();
                cmd.Dispose();
                DataBase.CloseConectionIfOpen();

                return list;
            }
        }

        public static void Insert(DTOUser u)
        {
            Insert(u.ShowName, u.LoginName, u.Email, 
                u.PhoneNumber, u.Address, u.PassWord);
        }

        private static void Insert(string showName, string loginName, string email,
            string phoneNumber, string address, string hashedPass)
        {
            string query = @"
                            IF(EXISTS (SELECT * FROM TTTH_user WHERE _user_name = @userName))
                            BEGIN
	                            SELECT N'Tên tài khoản đã được sử dụng.'
	                            RETURN
                            END

                            IF(EXISTS (SELECT * FROM TTTH_user WHERE _show_name = @showName))
                            BEGIN
	                            SELECT N'Tên hiển thị đã được sử dụng.'
	                            RETURN
                            END

                            IF(EXISTS (SELECT * FROM TTTH_user WHERE _phone_number = @phoneNumber))
                            BEGIN
	                            SELECT N'Số điện thoại đã được sử dụng.'
	                            RETURN
                            END

                            IF(EXISTS (SELECT * FROM TTTH_user WHERE _email = @email))
                            BEGIN
	                            SELECT N'Email đã được sử dụng.'
	                            RETURN
                            END

                            INSERT INTO TTTH_user 
                            VALUES(@userName, @passWord, @showName, @email, @phoneNumber, @address, 2)";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@showName", showName);
                    cmd.Parameters.AddWithValue("@userName", loginName);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@passWord", hashedPass);

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
                throw new Exception("Lỗi không xác định");
            }
        }

        public static void Delete(int id)
        {
            if (id == -1)
            {
                throw new DataBaseException("Tài khoản không tồn tại hoặc đã bị xóa.");
            }

            string query = @"
                            IF(NOT EXISTS (SELECT * FROM TTTH_user WHERE _id = @ID))
                            BEGIN
	                            SELECT N'Tài khoản không tồn tại hoặc đã bị xóa.'
	                            RETURN
                            END

                            DELETE FROM TTTH_user WHERE _id = @ID";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

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
                throw new Exception("Lỗi không xác định");
            }
        }

        public static void Update(DTOUser u)
        {
            Update(u.Id, u.ShowName, u.LoginName, u.Email, u.PhoneNumber, u.Address);
        }

        private static void Update(int id, string showName, string loginName, string email,
            string phoneNumber, string address)
        {
            if (id == -1)
            {
                throw new DataBaseException("Tài khoản không tồn tại hoặc đã bị xóa.");
            }

            string query = @"
                            IF(NOT EXISTS (SELECT * FROM TTTH_user WHERE _id = @ID))
                            BEGIN
	                            SELECT N'Tài khoản không tồn tại hoặc đã bị xóa.'
	                            RETURN
                            END

                            IF(EXISTS (SELECT * FROM TTTH_user WHERE _id != @ID AND _user_name = @userName))
                            BEGIN
	                            SELECT N'Tên đăng nhập trùng lặp.'
	                            RETURN
                            END

                            IF(EXISTS (SELECT * FROM TTTH_user WHERE _id != @ID AND _show_name = @showName))
                            BEGIN
	                            SELECT N'Tên hiển thị trùng lặp.'
	                            RETURN
                            END

                            IF(EXISTS (SELECT * FROM TTTH_user WHERE _id != @ID AND _email = @email))
                            BEGIN
	                            SELECT N'Email trùng lặp.'
	                            RETURN
                            END

                            IF(EXISTS (SELECT * FROM TTTH_user WHERE _id != @ID AND _phone_number = @phoneNumber))
                            BEGIN
	                            SELECT N'Số điện thoại trùng lặp.'
	                            RETURN
                            END

                            UPDATE TTTH_user
                            SET
                            _user_name = @userName,
                            _show_name = @showName,
                            _email = @email,
                            _phone_number = @phoneNumber,
                            _address = @address
                            WHERE _id = @ID";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@showName", showName);
                    cmd.Parameters.AddWithValue("@userName", loginName);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                    cmd.Parameters.AddWithValue("@address", address);

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
                throw;// new Exception("Lỗi không xác định");
            }
        }
    }
}
