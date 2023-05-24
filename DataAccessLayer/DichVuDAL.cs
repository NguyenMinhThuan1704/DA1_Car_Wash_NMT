using DataAccessLayer.Interface;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DichVuDAL : IDichVuDAL
    {
        private const string PARM_MADV = "@Madv";
        private const string PARM_TENDV = "@Tendv";
        private const string PARM_MALOAIDV = "@Maloaidv";
        private const string PARM_GIADV = "@Giadv";
        private const string PARM_SOLUONG = "@Soluong";

        public int checkDichVu_ID(int madv)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MADV,SqlDbType.Int)
            };
            parm[0].Value = madv;
            return (int)SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_DichVu_Check", parm);
        }

        public int Delete(int madv)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MADV,SqlDbType.Int)
            };
            parm[0].Value = madv;

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_DichVu_Del", parm);
        }

        public DataTable getAll()
        {
            SqlDataReader dra = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_DichVu_Sel_All", null);
            DataTable table = new DataTable();
            table.Columns.Add("Madv", typeof(int));
            table.Columns.Add("Tendv", typeof(string));
            table.Columns.Add("Maloaidv", typeof(int));
            table.Columns.Add("Giadv", typeof(int));
            table.Columns.Add("Soluong", typeof(int));

            while (dra.Read())
            {
                table.Rows.Add(int.Parse(dra["Madv"].ToString()), dra["Tendv"].ToString(), int.Parse(dra["Maloaidv"].ToString()), int.Parse(dra["Giadv"].ToString()), int.Parse(dra["Soluong"].ToString()));
            }
            dra.Dispose();
            return table;
        }

        public int Insert(DichVuDTO dv)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MADV,SqlDbType.Int),
                new SqlParameter(PARM_TENDV,SqlDbType.NVarChar,100),
                new SqlParameter(PARM_MALOAIDV,SqlDbType.Int),
                new SqlParameter(PARM_GIADV,SqlDbType.Int),
                new SqlParameter(PARM_SOLUONG,SqlDbType.Int),
            };
            if (string.IsNullOrEmpty(dv.madv.ToString()))
                parm[0].Value = DBNull.Value;
            else
                parm[0].Value = dv.madv;

            if (dv.tendv == null)
                parm[1].Value = DBNull.Value;
            else
                parm[1].Value = dv.tendv;

            if (string.IsNullOrEmpty(dv.maloaidv.ToString()))
                parm[2].Value = DBNull.Value;
            else
                parm[2].Value = dv.maloaidv;

            if (string.IsNullOrEmpty(dv.giadv.ToString()))
                parm[3].Value = DBNull.Value;
            else
                parm[3].Value = dv.giadv;

            if (string.IsNullOrEmpty(dv.soluong.ToString()))
                parm[4].Value = DBNull.Value;
            else
                parm[4].Value = dv.soluong;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_DichVu_Ins", parm);
        }

        public int Insert(int madv, string tendv, int maloaidv, int giadv, int soluong)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MADV,SqlDbType.Int),
                new SqlParameter(PARM_TENDV,SqlDbType.NVarChar,100),
                new SqlParameter(PARM_MALOAIDV,SqlDbType.Int),
                new SqlParameter(PARM_GIADV,SqlDbType.Int),
                new SqlParameter(PARM_SOLUONG,SqlDbType.Int),
            };
            parm[0].Value = madv;
            parm[1].Value = tendv;
            parm[2].Value = maloaidv;
            parm[3].Value = giadv;
            parm[4].Value = soluong;

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_DichVu_Ins", parm);
        }

        public int Update(int madv, string tendv, int maloaidv, int giadv, int soluong)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MADV,SqlDbType.Int),
                new SqlParameter(PARM_TENDV,SqlDbType.NVarChar,100),
                new SqlParameter(PARM_MALOAIDV,SqlDbType.Int),
                new SqlParameter(PARM_GIADV,SqlDbType.Int),
                new SqlParameter(PARM_SOLUONG,SqlDbType.Int),
            };
            parm[0].Value = madv;
            parm[1].Value = tendv;
            parm[2].Value = maloaidv;
            parm[3].Value = giadv;
            parm[4].Value = soluong;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_DichVu_Upd", parm);
        }
    }
}
