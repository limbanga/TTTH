using System.Data.SqlClient;
using TTTH.Models.DTO;

namespace TTTH.Models.DAO
{
    public static class ModelScore
    {
        #region Select
        public static List<DTOScore> GetScoreByClassID(int classID, int examNumber)
        {
            List<DTOScore> list = new List<DTOScore>();
            string query = @"
                        SELECT
                        s._id,
                        s._student_name,
                        s._phone_number,
                        e._score 
                        FROM
                        ttth_exam e JOIN TTTH_student s
                        ON e._student_id = s._id
                        WHERE 
                        e._class_id = @classID AND
                        e._exam_number = @examNumber;";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@classID", classID);
                    cmd.Parameters.AddWithValue("@examNumber", examNumber);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DTOStudent st = new DTOStudent();
                        // student
                        st.Id = reader.GetInt32(0);
                        st.Name = reader.GetString(1);
                        st.PhoneNumber = reader.GetString(2);
                        // score
                        DTOScore sc = new DTOScore();
                        sc.DTOStudent = st;
                        sc.Score = reader.GetDouble(3);

                        // assign
                        list.Add(sc);

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

        public static int GetLastExamNumber(int classID)
        {
            int r = -1;
            string query = @"
                            SELECT 
                            CASE
                            WHEN max(_exam_number) IS NULL THEN -1 
                            ELSE max(_exam_number)
                            END
                            FROM ttth_exam WHERE _class_id = @classID;";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@classID", classID);

                    r = (int) cmd.ExecuteScalar();
                    cmd.Dispose();
                    DataBase.CloseConectionIfOpen();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return r;
        }
        #endregion

        #region insert
        public static int MakeNewExam(int classID)
        {
            int nextExamNumber = -1;
            string query = @"	
                        declare @nextExamNumber int
                        -- get next exam number
	                    select @nextExamNumber = 
	                    case 
	                    when max(_exam_number) is null then 0
	                    else max(_exam_number)
	                    end
	                    + 1 from TTTH_exam where _class_id = @classID

	                    insert into TTTH_exam (_exam_number, _class_id,_student_id, _score)
	                    select
	                    @nextExamNumber,
	                    r._class_id,
	                    s._id,
	                    0
	                    from TTTH_student s join TTTH_register r on s._id = r._student_id 
	                    where _class_id = @classID
	                    and (
		                    not exists (
			                    select * from TTTH_exam where 
			                    _exam_number = @nextExamNumber and
			                    _class_id = @classID and
			                    _student_id = s._id
		                    ) 
	                    ) 
	                    SELECT @nextExamNumber";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@classID", classID);

                    nextExamNumber = (int) cmd.ExecuteScalar();

                    if (nextExamNumber == -1)
                    {
                        throw new Exception("Lỗi không xác định. Không thể tạo bảng điểm cho bài kiểm tra mới");
                    }

                    cmd.Dispose();
                    DataBase.CloseConectionIfOpen();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return nextExamNumber;
        }
        #endregion

        #region update
        public static void UpdateScore(int examNumber, int classID, int studentID, double score)
        {
            int rowsAffect = 0;
            string query = @"
                            UPDATE TTTH_exam
                            SET _score = @score
                            WHERE _class_id = @classID AND
                            _exam_number = @examNumber AND 
                            _student_id = @studentID;";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, DataBase.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@examNumber", examNumber);
                    cmd.Parameters.AddWithValue("@classID", classID);
                    cmd.Parameters.AddWithValue("@studentID", studentID);
                    cmd.Parameters.AddWithValue("@score", score);


                    rowsAffect = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    DataBase.CloseConectionIfOpen();
                    if (rowsAffect <= 0)
                    {
                        throw new Exception("Không thể tìm thấy thông tin.");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
