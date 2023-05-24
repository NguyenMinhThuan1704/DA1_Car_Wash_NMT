using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interface;

namespace DataAccessLayer
{
    public class LoaiXeDAL : ILoaiXeDAL
    {
        public DataTable getAll()
        {
            SqlDataReader dra = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_LoaiXe_Sel_All", null);
            DataTable table = new DataTable();
            table.Columns.Add("MaLoaiXe", typeof(int));
            table.Columns.Add("TenLoaiXe", typeof(string));
            while (dra.Read())
            {
                table.Rows.Add(int.Parse(dra["MaLoaiXe"].ToString()), dra["TenLoaiXe"].ToString());
            }
            dra.Dispose();
            return table;
        }
    }
}
