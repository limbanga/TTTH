using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTH.Models
{
    public static class DataBase
    {
        private static SqlConnection _connection = new SqlConnection(BUS.stringConnect);
        public static SqlConnection GetConnection ()
        {
            if (_connection is null) 
            {
                _connection = new SqlConnection(BUS.stringConnect);
            }

            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
            return _connection;
        }

        public static DataTable ExcuteQuery(SqlCommand cmd)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
    }
}
