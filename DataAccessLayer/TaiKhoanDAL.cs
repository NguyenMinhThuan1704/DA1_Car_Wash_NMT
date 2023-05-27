using DataAccessLayer.Interface;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class TaiKhoanDAL : ITaiKhoanDAL
    {
        private const string PARM_MANV = "@Manv";
        private const string PARM_MATK = "@MaTK";
        private const string PARM_TENTK = "@TaiKhoan";
        private const string PARM_MATKHAU = "@MatKhau";
        public int checkTaiKhoan_ID(int matk)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MATK,SqlDbType.Int)
            };
            parm[0].Value = matk;
            return (int)SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_TaiKhoan_Check", parm);
        }

        public int Delete(int matk)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MATK,SqlDbType.Int)
            };
            parm[0].Value = matk;

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_TaiKhoan_Del", parm);
        }

        public DataTable getAll()
        {
            SqlDataReader dra = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_TaiKhoan_Sel_All", null);
            DataTable table = new DataTable();
            table.Columns.Add("MaNV", typeof(int));
            table.Columns.Add("MaTK", typeof(int));
            table.Columns.Add("TaiKhoan", typeof(string));
            table.Columns.Add("MatKhau", typeof(string));
            while (dra.Read())
            {
                table.Rows.Add(int.Parse(dra["MaNV"].ToString()), int.Parse(dra["MaTK"].ToString()), dra["TaiKhoan"].ToString(), dra["MatKhau"].ToString());
            }
            dra.Dispose();
            return table;
        }

        public int Insert(int manhanvien, int matk, string taikhoan, string matkhau)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MANV,SqlDbType.Int),
                new SqlParameter(PARM_MATK,SqlDbType.Int),
                new SqlParameter(PARM_TENTK,SqlDbType.VarChar,50),
                new SqlParameter(PARM_MATKHAU,SqlDbType.VarChar,100),
            };
            parm[0].Value = manhanvien;
            parm[1].Value = matk;
            parm[2].Value = taikhoan;
            parm[3].Value = matkhau;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_TaiKhoan_Ins", parm);
        }

        public int Update(int manhanvien, int matk, string taikhoan, string matkhau)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MANV,SqlDbType.Int),
                new SqlParameter(PARM_MATK,SqlDbType.Int),
                new SqlParameter(PARM_TENTK,SqlDbType.VarChar,50),
                new SqlParameter(PARM_MATKHAU,SqlDbType.VarChar,100),
            };
            parm[0].Value = manhanvien;
            parm[1].Value = matk;
            parm[2].Value = taikhoan;
            parm[3].Value = matkhau;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_TaiKhoan_Upd", parm);
        }
    }
}
