using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTH.Models.DAO
{
    public class DAOCourse
    {
        private DAOCourse() { }

        public static List<ModelCourse> GetAll()
        {
            string query = @"select * from TTTH_course";

            List<ModelCourse> list = new List<ModelCourse>();

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
                            string name = reader.GetString(1);
                            double fee = reader.GetDouble(2);
                            int duration = reader.GetInt32(3);
                            // innit
                            ModelCourse modelCourse =
                                new ModelCourse(id, name, fee, duration);
                            // assign
                            list.Add(modelCourse);
                        }
                        reader.Close();
                        cmd.Dispose();
                    }
                    connection.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("48+couersdkah "+e.Message);
                    //throw;
                }
            }
            return list;
        }
    }
}
