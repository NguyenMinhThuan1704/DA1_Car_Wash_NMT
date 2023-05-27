using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DoanhThuDAL
    {
        private string connectionString = @"Data Source=ADMIN\SQLEXPRESS;DataBase=DA1_Car_Wash;Integrated Security=true;";

        public System.Data.DataTable GetHoaDonByDateRange(DateTime fromDate, DateTime toDate)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("Get_HoaDon_ByDateRange", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FromDate", fromDate);
                    command.Parameters.AddWithValue("@ToDate", toDate);

                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        
                        dataAdapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }
    }
}
