using DataAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class NCCDAL : INCCDAL
    {
        private const string PARM_MANCC = "@MaNCC";
        private const string PARM_TENNCC = "@TenNCC";
        private const string PARM_DIACHI = "@DiaChi";
        private const string PARM_DIENTHOAI = "@DienThoai";
        public int checkNCC_ID(int mancc)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MANCC,SqlDbType.Int)
            };
            parm[0].Value = mancc;
            return (int)SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_NCC_Check", parm);
        }

        public int Delete(int mancc)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MANCC,SqlDbType.Int)
            };
            parm[0].Value = mancc;

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_NCC_Del", parm);
        }

        public DataTable getAll()
        {
            SqlDataReader dra = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_NCC_Sel_All", null);
            DataTable table = new DataTable();
            table.Columns.Add("MaNCC", typeof(int));
            table.Columns.Add("TenNCC", typeof(string));
            table.Columns.Add("DiaChi", typeof(string));
            table.Columns.Add("DienThoai", typeof(string));
            while (dra.Read())
            {
                table.Rows.Add(int.Parse(dra["MaNCC"].ToString()), dra["TenNCC"].ToString(), dra["DiaChi"].ToString(), dra["DienThoai"].ToString());
            }
            dra.Dispose();
            return table;
        }

        public int Insert(int mancc, string tenncc, string diachi, string dienthoai)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
                new SqlParameter(PARM_MANCC, SqlDbType.Int),
                new SqlParameter(PARM_TENNCC,SqlDbType.NVarChar,100),
                new SqlParameter(PARM_DIACHI,SqlDbType.NVarChar,50),
                new SqlParameter(PARM_DIENTHOAI,SqlDbType.VarChar,20),
           };
            parm[0].Value = mancc;
            parm[1].Value = tenncc;
            parm[2].Value = diachi;
            parm[3].Value = dienthoai;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_NCC_Ins", parm);
        }

        public int Update(int mancc, string tenncc, string diachi, string dienthoai)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
                new SqlParameter(PARM_MANCC, SqlDbType.Int),
                new SqlParameter(PARM_TENNCC,SqlDbType.NVarChar,100),
                new SqlParameter(PARM_DIACHI,SqlDbType.NVarChar,50),
                new SqlParameter(PARM_DIENTHOAI,SqlDbType.VarChar,20),
           };
            parm[0].Value = mancc;
            parm[1].Value = tenncc;
            parm[2].Value = diachi;
            parm[3].Value = dienthoai;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_NCC_Upd", parm);
        }
    }
}
