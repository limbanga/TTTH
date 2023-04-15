using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTH.Models.DAO
{
    public static class DAOAttendance
    {

        #region Select
        public static List<RelationShipAttendance> GetAttendanceInClass(int classID, int dateNumber)
        {
            string query = @"select s._id, s._student_name, s._phone_number, a._status from TTTH_attend a
join TTTH_student s on s._id = a._student_id
where _date_number = @dateNumber and _class_id = @classID;";

            List<RelationShipAttendance> list = new List<RelationShipAttendance>();

            using (SqlConnection connection = new SqlConnection(BUS.stringConnect))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@classID", classID);
                        cmd.Parameters.AddWithValue("@dateNumber", dateNumber);

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            // parse
                            int studentID = reader.GetInt32(0);
                            string studentName = reader.GetString(1);
                            string studentPhoneNumber = reader.GetString(2);
                            char status = reader.GetString(3)[0];

                            ModelStudent st = new ModelStudent(studentID, studentName, studentPhoneNumber);
                            DTOCLass c = new DTOCLass(classID);

                            RelationShipAttendance relationShipAttendance = new RelationShipAttendance(st, c, status, dateNumber);

                            // assign
                            list.Add(relationShipAttendance);

                        }
                        reader.Close();
                        cmd.Dispose();
                    }
                    connection.Close();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("GetAttendanceInClass" + e.Message);
                    //throw;
                }
            }
            return list;
        }

        #endregion

        #region update

        public static void TakeAttendance(int classID, int studentID, int dateNumber, char status)
        {
            string query = @"update TTTH_attend
set _status = @status
where _class_id = @classID and _student_id = @studentID and _date_number = @dateNumber;";
            using (SqlConnection connection = new SqlConnection(BUS.stringConnect))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@classID", classID);
                        cmd.Parameters.AddWithValue("@studentID", studentID);
                        cmd.Parameters.AddWithValue("@dateNumber", dateNumber);
                        cmd.Parameters.AddWithValue("@status", status);

                        int rowAffected = cmd.ExecuteNonQuery();
                        if (rowAffected <= 0)
                        {
                            throw new Exception(studentID.ToString());
                        }
                        cmd.Dispose();
                    }
                    connection.Close();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("TakeAttendance" + e.Message);
                    //throw;
                }
            }
        }
        #endregion
    }
}
