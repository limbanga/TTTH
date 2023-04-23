using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTTH.Models.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TTTH.Models.DAO
{
    public static class ModelAttendance
    {

        #region Select
        public static List<DTOAttendance> GetAttendanceInClass(int classID, int dateNumber)
        {
            string query = @"
                            INSERT INTO TTTH_attend (_class_id, _date_number, _student_id)
                            SELECT
                            r._class_id,
                            @dateNumber,
                            r._student_id
                            FROM TTTH_register r
                            WHERE r._class_id = @classID AND
                            NOT EXISTS (
                            SELECT * FROM TTTH_attend a
                            WHERE a._class_id = r._class_id AND
                            a._student_id = r._student_id AND
                            a._date_number = @dateNumber
                            )

                            SELECT
                            s._id,
                            s._student_name,
                            s._phone_number, 
                            a._status FROM TTTH_attend a
                            JOIN TTTH_student s ON s._id = a._student_id
                            WHERE _date_number = @dateNumber AND _class_id = @classID;";

            List<DTOAttendance> list = new List<DTOAttendance>();

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
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

                        DTOStudent st = new DTOStudent(studentID, studentName, studentPhoneNumber);
                        DTOClass c = new DTOClass();
                        c.Id = classID;

                        DTOAttendance relationShipAttendance = new DTOAttendance(st, c, status, dateNumber);

                        // assign
                        list.Add(relationShipAttendance);

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

        #endregion

        #region Update

        public static void TakeAttendance(int classID, int studentID, int dateNumber, char status)
        {
            string query = @"
                            UPDATE TTTH_attend
                            SET _status = @status
                            WHERE 
                            _class_id = @classID AND
                            _student_id = @studentID AND
                            _date_number = @dateNumber;";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@classID", classID);
                    cmd.Parameters.AddWithValue("@studentID", studentID);
                    cmd.Parameters.AddWithValue("@dateNumber", dateNumber);
                    cmd.Parameters.AddWithValue("@status", status);

                    int rowAffected = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    DataBase.CloseConectionIfOpen();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string GetStatus(int classID, int studentID, int dateNumber)
        {
            string query = @"
                            SELECT _status
                            FROM TTTH_attend
                            WHERE 
                            _class_id = @classID AND
                            _student_id = @studentID AND
                            _date_number = @dateNumber;";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@classID", classID);
                    cmd.Parameters.AddWithValue("@studentID", studentID);
                    cmd.Parameters.AddWithValue("@dateNumber", dateNumber);

                    string r = (string) cmd.ExecuteScalar();
                    cmd.Dispose();
                    DataBase.CloseConectionIfOpen();
                    if (string.IsNullOrEmpty(r))
                    {
                        return "p";
                    }
                    return r;
                }
            }
            catch (Exception)
            {
                return "p";
            }
        }
        #endregion
    }
}
