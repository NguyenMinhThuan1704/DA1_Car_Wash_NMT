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
    public class HoaDonDAL : IHoaDonDAL
    {
        private const string PARM_HOADONID = "@MaHD";
        private const string PARM_MANHANVIEN = "@MaNV";
        private const string PARM_MAKHACHHANG = "@MaKH";
        private const string PARM_NGAYLAP = "@NgayLap";
        private const string PARM_TONGTIEN = "@TongTien";
        public int checkHoaDon_ID(int mahd)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_HOADONID,SqlDbType.Int)
            };
            parm[0].Value = mahd;
            return (int)SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_HoaDon_Check", parm);
        }

        public int Delete(int mahd)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_HOADONID,SqlDbType.Int)
            };
            parm[0].Value = mahd;

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_HoaDon_Del", parm);
        }

        public DataTable getAll()
        {
            SqlDataReader dra = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_HoaDon_Sel_All", null);
            DataTable table = new DataTable();
            table.Columns.Add("MaHD", typeof(int));
            table.Columns.Add("MaNV", typeof(int));
            table.Columns.Add("MaKH", typeof(int));
            table.Columns.Add("NgayLap", typeof(DateTime));
            table.Columns.Add("TongTien", typeof(float));
            while (dra.Read())
            {
                table.Rows.Add(int.Parse(dra["MaHD"].ToString()), dra["MaNV"].ToString(), dra["MaKH"].ToString(), dra["NgayLap"].ToString(), dra["TongTien"].ToString());
            }
            dra.Dispose();
            return table;
        }

        public int Insert(int manv, int makh, DateTime ngaylap, float tongtien)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MANHANVIEN,SqlDbType.Int),
                new SqlParameter(PARM_MAKHACHHANG,SqlDbType.Int),
                new SqlParameter(PARM_NGAYLAP,SqlDbType.DateTime),
                new SqlParameter(PARM_TONGTIEN,SqlDbType.Float),
            };
            parm[0].Value = manv;
            parm[1].Value = makh;
            parm[2].Value = ngaylap;
            parm[3].Value = tongtien;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_HoaDon_Ins", parm);
        }

        public int Update(int mahd, int manv, int makh, DateTime ngaylap, float tongtien)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_HOADONID,SqlDbType.Int),
                new SqlParameter(PARM_MANHANVIEN,SqlDbType.Int),
                new SqlParameter(PARM_MAKHACHHANG,SqlDbType.Int),
                new SqlParameter(PARM_NGAYLAP,SqlDbType.DateTime),
                new SqlParameter(PARM_TONGTIEN,SqlDbType.Float),
            };
            parm[0].Value = mahd;
            parm[1].Value = manv;
            parm[2].Value = makh;
            parm[3].Value = ngaylap;
            parm[4].Value = tongtien;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_HoaDon_Upd", parm);
        }
    }
}
