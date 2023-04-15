using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TTTH.Models.DAO
{
    public static class DAORegister
    {
        public static bool RegisterToClass(int studentID, int classID)
        {
            int rowsAffect = 0;
            string query = @"insert into TTTH_register (_student_id, _class_id) values (@studentID, @classID);";

            using (SqlConnection connection = new SqlConnection(BUS.stringConnect))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@studentID", studentID);
                        cmd.Parameters.AddWithValue("@classID", classID);

                        rowsAffect = cmd.ExecuteNonQuery();

                        cmd.Dispose();
                    }
                    connection.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    // if - else bắt lỗi cụ thể rồi ném ra ngoai
                    // tạm thời hard code
                    throw new Exception("Tên trùng lặp");
                }
            }

            return rowsAffect > 0;
        }

        public static bool UnRegisterFromClass(int studentID, int classID)
        {
            int rowsAffect = 0;
            string query = @"delete from TTTH_register where _student_id = @studentID and _class_id = @classID;";

            using (SqlConnection connection = new SqlConnection(BUS.stringConnect))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@studentID", studentID);
                        cmd.Parameters.AddWithValue("@classID", classID);

                        rowsAffect = cmd.ExecuteNonQuery();

                        cmd.Dispose();
                    }
                    connection.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    // if - else bắt lỗi cụ thể rồi ném ra ngoai
                    // tạm thời hard code
                    throw new Exception("Không xóa được");
                }
            }

            return rowsAffect > 0;
        }
    }
}
