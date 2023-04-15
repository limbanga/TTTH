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

            using (SqlConnection connection = new SqlConnection(BUS.stringConnect))
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

        public static List<ModelStudent> GetStudentsInClass(int classID)
        {
            string query = @"select s._id,
s._student_name,
s._phone_number, 
(select count(*) from TTTH_attend where _student_id = s._id and _class_id = @classID and _status = 'a') as '_total_absence',
(select count(*) from TTTH_attend where _student_id = s._id and _class_id = @classID and _status = 'l') as '_total_late',
(select AVG(_score) from TTTH_exam where _student_id = s._id and _class_id = @classID) as '_avg_score'
from TTTH_student s inner join TTTH_register r on s._id = r._student_id 
where r._class_id = @classID;";

            List<ModelStudent> list = new List<ModelStudent>();

            using (SqlConnection connection = new SqlConnection(BUS.stringConnect))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@classID", classID);

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            // parse
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string phoneNumber = reader.GetString(2);
                            int totalAbsence = reader.IsDBNull(3) ? 0: reader.GetInt32(3);
                            int totalLate = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
                            double s = reader.IsDBNull(5) ? 0 : reader.GetDouble(5);


                            // innit
                            ModelStudent modelStudent = new ModelStudent(id, name, phoneNumber, totalAbsence, totalLate, s);
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
                    MessageBox.Show("DAOstudent" + e.Message);
                    //throw;
                }
            }
            return list;
        }

        public static List<ModelStudent> GetStudentsNotInClass(int classID)
        {
            string query = @"select * from TTTH_student where _id not in (select _id from TTTH_student s 
inner join TTTH_register r 
on s._id = r._student_id 
where r._class_id = @classID);";
            List<ModelStudent> list = new List<ModelStudent>();

            using (SqlConnection connection = new SqlConnection(BUS.stringConnect))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@classID", classID);

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            // parse
                            int id = reader.GetInt32(0);
                            string phoneNumber = reader.GetString(1);
                            string name = reader.GetString(2);
                            bool isInClass = false;

                            // innit
                            ModelStudent modelStudent = new ModelStudent(id, name, phoneNumber, isInClass);
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
                    MessageBox.Show("DAOstudent" + e.Message);
                    //throw;
                }
            }
            return list;
        }

        public static List<ModelStudent> GetAllStudentsAndCheckIfInClass(int classID)
        {
            string query = @"select * ,
case 
when _id in (
select _student_id from TTTH_register where _class_id = @classID
) then 1
else 0
end as 'is_in_class' from TTTH_student;";
            List<ModelStudent> list = new List<ModelStudent>();

            using (SqlConnection connection = new SqlConnection(BUS.stringConnect))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@classID", classID);

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            // parse
                            int id = reader.GetInt32(0);
                            string phoneNumber = reader.GetString(1);
                            string name = reader.GetString(2);
                            bool isInClass = Convert.ToBoolean(reader.GetInt32(3));

                            // innit
                            ModelStudent modelStudent = new ModelStudent(id, name, phoneNumber, isInClass);
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
                    MessageBox.Show("DAOstudent" + e.Message);
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

            using (SqlConnection connection = new SqlConnection(BUS.stringConnect))
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

            using (SqlConnection connection = new SqlConnection(BUS.stringConnect))
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
