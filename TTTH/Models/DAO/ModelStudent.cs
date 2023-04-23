using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TTTH.Models.DTO;

namespace TTTH.Models.DAO
{
    public static class ModelStudent
    {

        #region Select
        public static List<DTOStudent> GetAll()
        {
            string query = @"select * from TTTH_student";
            List<DTOStudent> list = new List<DTOStudent>();

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
                            DTOStudent modelStudent = new DTOStudent(id, name, phoneNumber);
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

        public static List<DTOStudent> GetStudentsInClass(int classID)
        {
            string query = @"
                            SELECT 
                            s._id,
                            s._student_name,
                            s._phone_number, 
                            (SELECT COUNT(*) FROM TTTH_attend WHERE _student_id = s._id and _class_id = @classID and _status = 'a') AS '_total_absence',
                            (SELECT count(*) FROM TTTH_attend WHERE _student_id = s._id and _class_id = @classID and _status = 'l') AS '_total_late',
                            (SELECT AVG(_score) FROM TTTH_exam WHERE _student_id = s._id and _class_id = @classID) AS '_avg_score'
                            FROM TTTH_student s INNER JOIN TTTH_register r on s._id = r._student_id 
                            where r._class_id = @classID;";

            List<DTOStudent> list = new List<DTOStudent>();
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@classID", classID);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DTOStudent st = new DTOStudent();
                        // parse
                        st.Id = reader.GetInt32(0);
                        st.Name = reader.GetString(1);
                        st.PhoneNumber = reader.GetString(2);
                        st.TotalAbsence = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                        st.TotalLate = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
                        st.AvgScore = reader.IsDBNull(5) ? 0 : reader.GetDouble(5);

                        // assign
                        list.Add(st);
                    }
                    reader.Close();
                    cmd.Dispose();
                    DataBase.CloseConectionIfOpen();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public static List<DTOStudent> GetStudentsToRegister(int classID)
        {
            string query = @"
                            SELECT
                            s.*,

                            CASE
	                            WHEN s._id IN (SELECT _student_id FROM TTTH_register WHERE _class_id = @classID) THEN 1 ELSE 0
                            END
                            AS _in_class,

                            CASE
	                            WHEN
		                            (SELECT COUNT(*) FROM
		                            (
		                            -- Lich hoc cua hs
		                            SELECT cd._date, cd._shift
		                            FROM
		                            TTTH_class_date cd join TTTH_register r
		                            on cd._class_id = r._class_id
		                            WHERE r._student_id = s._id AND cd._class_id != @classID

		                            INTERSECT

		                            -- Lich cua lop
		                            SELECT cd._date, cd._shift
		                            FROM
		                            TTTH_class_date cd 
		                            WHERE cd._class_id = @classID
		                            ) I ) > 0 THEN 1 
		                            ELSE 0
                            END
                            AS _is_conflict

                            FROM TTTH_student s";
            List<DTOStudent> list = new List<DTOStudent>();

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@classID", classID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        // parse
                        int id = reader.GetInt32(0);
                        string phoneNumber = reader.GetString(1);
                        string name = reader.GetString(2);
                        bool isInClass = reader.GetInt32(3) != 0;
                        bool isConficlt = reader.GetInt32(4) != 0;

                        // innit
                        DTOStudent student = new DTOStudent(id, name, phoneNumber, isInClass, isConficlt);
                        // assign
                        list.Add(student);
                    }

                    reader.Close();
                    cmd.Dispose();
                }
            }
            catch (DataBaseException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public static List<DTOStudent> GetAllStudentsAndCheckIfInClass(int classID)
        {
            string query = @"select * ,
case 
when _id in (
select _student_id from TTTH_register where _class_id = @classID
) then 1
else 0
end as 'is_in_class' from TTTH_student;";
            List<DTOStudent> list = new List<DTOStudent>();

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
                            DTOStudent modelStudent = new DTOStudent(id, name, phoneNumber, isInClass, false);
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

        public static bool CheckStudentJoinAnyClass(int studentID)
        {
            string query = @"SELECT COUNT(*) FROM TTTH_register WHERE _student_id = @studentID;";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@studentID", studentID);

                    int numberOfDependency = (int) cmd.ExecuteScalar();
                    cmd.Dispose();

                    return numberOfDependency > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region Insert
        public static void Insert(string name,  string phoneNumber)
        {
            string query = @"
                            IF (EXISTS(SELECT * FROM TTTH_student WHERE _phone_number = @phoneNumber))
                            BEGIN
	                            SELECT N'Số điện thoại trùng lặp.'
	                            RETURN
                            END

                            INSERT INTO TTTH_student (_student_name, _phone_number) values (@name, @phoneNumber);";
            
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);

                    string errorMsg = (string) cmd.ExecuteScalar();
                    cmd.Dispose();
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

        public static void Insert(DTOStudent s)
        {
            Insert(s.Name, s.PhoneNumber);
        }

        #endregion

        #region Update

        public static void Update(int id, string name, string phoneNumber)
        {
            if (id == -1)
            {
                throw new DataBaseException("Học viên không tồn tại hoặc đã bị xóa.");
            }
            string query = @"
                            IF (NOT EXISTS(SELECT * FROM TTTH_student WHERE _id = @id))
                            BEGIN
	                            SELECT N'Học viên không tồn tại hoặc đã bị xóa.'
	                            RETURN
                            END


                            IF (EXISTS(SELECT * FROM TTTH_student WHERE _phone_number = @phoneNumber AND _id != @id))
                            BEGIN
	                            SELECT N'Số điện thoại trùng lặp.'
	                            RETURN
                            END

                            UPDATE TTTH_student 
                            SET
                            _student_name = @name,
                            _phone_number = @phoneNumber 
                            WHERE
                            _id = @id";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                    cmd.Parameters.AddWithValue("@id", id);

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
                throw new Exception("Lỗi không xác định.");
            }
        }

        public static void Update(DTOStudent s)
        {
            Update(s.Id, s.Name, s.PhoneNumber);
        }

        #endregion




        public static void Delete(int studentID)
        {
            if (studentID == -1)
            {
                throw new DataBaseException("Học viên không tồn tại hoặc đã bị xóa trước đó.");
            }

            string query = @"
                            IF (NOT EXISTS(SELECT * FROM TTTH_student WHERE _id = @studentID))
                            BEGIN
	                            SELECT N'Học viên không tồn tại hoặc đã bị xóa trước đó.'
	                            RETURN
                            END

                            DELETE FROM TTTH_student WHERE _id = @studentID;";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@studentID", studentID);

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
                throw new Exception("Lỗi không xác định.");
            }
        }












    }
}
