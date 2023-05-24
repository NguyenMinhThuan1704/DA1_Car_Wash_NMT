using DataAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class LoaiDichVuDAL : ILoaiDichVuDAL
    {
        public DataTable getAll()
        {
            SqlDataReader dra = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_LoaiDichVu_Sel_All", null);
            DataTable table = new DataTable();
            table.Columns.Add("MaLoaiDV", typeof(int));
            table.Columns.Add("TenLoaiDV", typeof(string));
            while (dra.Read())
            {
                table.Rows.Add(int.Parse(dra["MaLoaiDV"].ToString()), dra["TenLoaiDV"].ToString());
            }
            dra.Dispose();
            return table;
        }
    }
}
