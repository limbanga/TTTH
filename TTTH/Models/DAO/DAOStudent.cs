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
    }
}
