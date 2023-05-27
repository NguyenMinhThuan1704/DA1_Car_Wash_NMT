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
    public class CTNKDAL : ICTNKDAL
    {
        private const string PARM_CTNK = "@MaCTNK";
        private const string PARM_MADNK = "@MaDNK";
        private const string PARM_DICHVU = "@MaDV";
        private const string PARM_GIANHAP = "@GiaNhap";
        private const string PARM_SOLUONGNHAP = "@SoluongNhap";
        public int checkChiTietNK_ID(int mactnk)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_CTNK,SqlDbType.Int)
            };
            parm[0].Value = mactnk;
            return (int)SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_CTNK_Check", parm);
        }

        public int Delete(int mactnk)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_CTNK,SqlDbType.Int)
            };
            parm[0].Value = mactnk;

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_CTNK_Del", parm);
        }

        public DataTable getAll()
        {
            SqlDataReader dra = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_CTNK_Sel_All", null);
            DataTable table = new DataTable();
            table.Columns.Add("Mactnk", typeof(int));
            table.Columns.Add("Madnk", typeof(int));
            table.Columns.Add("Madv", typeof(int));
            table.Columns.Add("Gianhap", typeof(int));
            table.Columns.Add("Soluongnhap", typeof(int));
            while (dra.Read())
            {
                table.Rows.Add(int.Parse(dra["Mactnk"].ToString()), dra["Madnk"].ToString(), dra["Madv"].ToString(), dra["Gianhap"].ToString(), dra["Soluongnhap"].ToString());
            }
            dra.Dispose();
            return table;
        }

        public int Insert(int mactnk, int madnk, int madv, int gianhap, int soluongnhap)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
                new SqlParameter(PARM_CTNK,SqlDbType.Int),
                new SqlParameter(PARM_MADNK,SqlDbType.Int),
                new SqlParameter(PARM_DICHVU,SqlDbType.Int),
                new SqlParameter(PARM_GIANHAP,SqlDbType.Int),
                new SqlParameter(PARM_SOLUONGNHAP,SqlDbType.Int),
           };
            parm[0].Value = mactnk;
            parm[1].Value = madnk;
            parm[2].Value = madv;
            parm[3].Value = gianhap;
            parm[4].Value = soluongnhap;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_CTNK_Ins", parm);
        }

        public int Update(int mactnk, int madnk, int madv, int gianhap, int soluongnhap)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
                new SqlParameter(PARM_CTNK,SqlDbType.Int),
                new SqlParameter(PARM_MADNK,SqlDbType.Int),
                new SqlParameter(PARM_DICHVU,SqlDbType.Int),
                new SqlParameter(PARM_GIANHAP,SqlDbType.Int),
                new SqlParameter(PARM_SOLUONGNHAP,SqlDbType.Int),
           };
            parm[0].Value = mactnk;
            parm[1].Value = madnk;
            parm[2].Value = madv;
            parm[3].Value = gianhap;
            parm[4].Value = soluongnhap;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_CTNK_Upd", parm);
        }
    }
}
