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
    public class ChiTietHoaDonDAL : IChiTietHoaDonDAL
    {
        private const string PARM_MACHITIET = "@MaCTHD";
        private const string PARM_MAHOADON = "@MaHD";
        private const string PARM_MADV = "@MaDV";
        private const string PARM_DONGIA = "@GiaSD";
        private const string PARM_SOLANSD = "@SoLanSD";
        public int checkChitiet_ID(int macthd)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MACHITIET,SqlDbType.Int)
            };
            parm[0].Value = macthd;
            return (int)SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_CTHD_Check", parm);
        }

        public int Delete(int macthd)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MACHITIET,SqlDbType.Int)
            };
            parm[0].Value = macthd;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_CTHD_Del", parm);
        }

        public DataTable getAll()
        {
            SqlDataReader dra = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_CTHD_Sel_All", null);
            DataTable table = new DataTable();
            table.Columns.Add("MaCTHD", typeof(int));
            table.Columns.Add("MaHD", typeof(int));
            table.Columns.Add("MaDV", typeof(int));
            table.Columns.Add("GiaSD", typeof(float));
            table.Columns.Add("SoLanSD", typeof(int));
            while (dra.Read())
            {
                table.Rows.Add(int.Parse(dra["MaCTHD"].ToString()), dra["MaHD"].ToString(), dra["MaDV"].ToString(), dra["GiaSD"].ToString(), dra["SoLanSD"].ToString());
            }
            dra.Dispose();
            return table;
        }

        public int Insert(int mahd, int madv, float giadv, int solansd, float mucgiamgia)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MAHOADON,SqlDbType.Int),
                new SqlParameter(PARM_MADV,SqlDbType.Int),
                new SqlParameter(PARM_DONGIA,SqlDbType.Float),
                new SqlParameter(PARM_SOLANSD,SqlDbType.Int),
            };
            parm[0].Value = mahd;
            parm[1].Value = madv;
            parm[2].Value = giadv;
            parm[3].Value = solansd;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_CTHD_Ins", parm);
        }

        public int Update(int macthd, int mahd, int madv, float giadv, int solansd, float mucgiamgia)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MACHITIET,SqlDbType.Int),
                new SqlParameter(PARM_MAHOADON,SqlDbType.Int),
                new SqlParameter(PARM_MADV,SqlDbType.Int),
                new SqlParameter(PARM_DONGIA,SqlDbType.Float),
                new SqlParameter(PARM_SOLANSD,SqlDbType.Int),
            };
            parm[0].Value = macthd;
            parm[1].Value = mahd;
            parm[2].Value = madv;
            parm[3].Value = giadv;
            parm[4].Value = solansd;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_CTHD_Upd", parm);
        }
    }
}
