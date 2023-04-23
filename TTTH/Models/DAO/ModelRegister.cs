using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TTTH.Models.DAO
{
    public static class ModelRegister
    {
        public static void RegisterToClass(int studentID, int classID)
        {
            string query = @"
                            IF (NOT EXISTS(SELECT * FROM TTTH_register WHERE _student_id = @studentID AND _class_id = @classID))
                            BEGIN
	                            INSERT INTO TTTH_register (_student_id, _class_id) VALUES (@studentID, @classID)
                            END;";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@studentID", studentID);
                    cmd.Parameters.AddWithValue("@classID", classID);

                    cmd.ExecuteNonQuery();

                    cmd.Dispose();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static void UnRegisterFromClass(int studentID, int classID)
        {
            string query = @"
                            IF (EXISTS(SELECT * FROM TTTH_register WHERE _student_id = @studentID AND _class_id = @classID))
                            BEGIN
	                            DELETE FROM TTTH_register WHERE _student_id = @studentID AND _class_id = @classID
                                DELETE FROM TTTH_attend WHERE _student_id = @studentID AND _class_id = @classID
                            END";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@studentID", studentID);
                    cmd.Parameters.AddWithValue("@classID", classID);

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
