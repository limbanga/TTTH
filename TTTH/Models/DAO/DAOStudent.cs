using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTH.Models.DAO
{
    public static class DAOStudent
    {

        #region Select
        public static List<ModelStudent> GetAll()
        {
            string query = @"select * from TTTH_student";
            List<ModelStudent> list = new List<ModelStudent>();

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
                            string phoneNumber = reader.GetString(1);
                            string name = reader.GetString(2);

                            // innit
                            ModelStudent modelStudent = new ModelStudent(id, name, phoneNumber);
                            // assign
                            list.Add(modelStudent);
                        }
                        reader.Close();
                        cmd.Dispose();
                    }
                    connection.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("DAOstudent 45" + e.Message);
                    //throw;
                }
            }
            return list;
        }
        #endregion


        #region Insert
        public static bool Insert(string name,  string phoneNumber)
        {
            int rowsAffect = 0;
            string query = @"insert into TTTH_student (_student_name, _phone_number) values (@name, @phoneNumber);";

            using (SqlConnection connection = new SqlConnection(Env.stringConnect))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);

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

        public static bool Insert(ModelStudent s)
        {
            return Insert(s.Name, s.PhoneNumber);
        }

        #endregion

        #region Update

        public static bool Update(int id, string name, string phoneNumber)
        {
            int rowsAffect = 0;
            string query = @"update TTTH_student set _student_name = @name, _phone_number = @phoneNumber where _id = @id";

            using (SqlConnection connection = new SqlConnection(Env.stringConnect))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
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

        public static bool Update(ModelStudent s)
        {
            if (s.Id == -1)
            {
                MessageBox.Show("id = -1 sinh viên không hợp lệ.");
                return false;
            }
            return Update(s.Id, s.Name, s.PhoneNumber);
        }
        #endregion


















    }
}
