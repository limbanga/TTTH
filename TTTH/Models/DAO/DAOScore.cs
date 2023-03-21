using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTH.Models.DAO
{
    public static class DAOScore
    {
        public static List<ModelScore> GetAll(int classID, int examNumber)
        {
            List<ModelScore> list = new List<ModelScore>();
            string query = @"select s._id,
s._student_name,
s._phone_number,
e._score, 
e._date_number 
from ttth_exam e join TTTH_student s on e._student_id = s._id
where e._class_id = @classID and e._exam_number = @examNumber;";

            using (SqlConnection connection = new SqlConnection(Env.stringConnect))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@classID", classID);
                        cmd.Parameters.AddWithValue("@examNumber", examNumber);

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            // student
                            int studentID = reader.GetInt32(0);
                            string studentName = reader.GetString(1);
                            string studentPhoneNumber = reader.GetString(2);

                            ModelStudent st = new ModelStudent(studentID, studentName, studentPhoneNumber);
                            
                            // score
                            double score = reader.GetDouble(3);
                            // date number
                            int dateNumber = reader.GetInt32(4);

                            ModelClass c = new ModelClass();

                            ModelScore modelScore = new ModelScore(examNumber, dateNumber, c, st, score);

                            // assign
                            list.Add(modelScore);

                        }
                        reader.Close();
                        cmd.Dispose();
                    }
                    connection.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("DAOScore GetAll" + ex.Message);
                    //throw;
                }
            }
            return list;
        }

        public static int GetLastExamNumber(int classID)
        {
            int lastExamNumber = 0;
            string query = @"select max(_exam_number) from ttth_exam where _class_id = @classID;";

            using (SqlConnection connection = new SqlConnection(Env.stringConnect))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@classID", classID);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read() && !reader.IsDBNull(0))
                        {
                            lastExamNumber = reader.GetInt32(0);
                        }
                       
                        reader.Close();
                        cmd.Dispose();
                    }
                    connection.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("GetLastExamNumber" + ex.Message);
                    //throw;
                }
            }
            return lastExamNumber;
        }
    }
}
