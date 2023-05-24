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
    public class DonNhapKhoDAL : IDonNhapKhoDAL
    {
        private const string PARM_MADNK = "@MaDNK";
        private const string PARM_MANV = "@MaNV";
        private const string PARM_MANCC = "@MaNCC";
        private const string PARM_NGAYNHAP = "@NgayNhap";
        private const string PARM_TONGSOLUONG = "@TongSoLuong";

        public int checkDonNhapKho_ID(int madnk)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MADNK,SqlDbType.Int)
            };
            parm[0].Value = madnk;
            return (int)SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_DonNhapKho_Check", parm);
        }

        public int Delete(int madnk)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MADNK,SqlDbType.Int)
            };
            parm[0].Value = madnk;

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_DonNhapKho_Del", parm);
        }

        public DataTable getAll()
        {
            SqlDataReader dra = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_DonNhapKho_Sel_All", null);
            DataTable table = new DataTable();
            table.Columns.Add("MaDNK", typeof(int));
            table.Columns.Add("MaNV", typeof(int));
            table.Columns.Add("MaNCC", typeof(int));
            table.Columns.Add("NgayNhap", typeof(DateTime));
            table.Columns.Add("TongSoLuong", typeof(int));
            while (dra.Read())
            {
                table.Rows.Add(int.Parse(dra["MaDNK"].ToString()), int.Parse(dra["MaNV"].ToString()), int.Parse(dra["MaNCC"].ToString()), dra["NgayNhap"].ToString(), int.Parse(dra["TongSoLuong"].ToString()));
            }
            dra.Dispose();
            return table;
        }

        public int Insert(int madnk, int manv, int mancc, DateTime ngaynhap, int tongsoluong)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MADNK,SqlDbType.Int),
                new SqlParameter(PARM_MANV,SqlDbType.Int),
                new SqlParameter(PARM_MANCC,SqlDbType.Int),
                new SqlParameter(PARM_NGAYNHAP,SqlDbType.DateTime),
                new SqlParameter(PARM_TONGSOLUONG,SqlDbType.Int)
            };
            parm[0].Value = madnk;
            parm[1].Value = manv;
            parm[2].Value = mancc;
            parm[3].Value = ngaynhap;
            parm[4].Value = tongsoluong;

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_DonNhapKho_Ins", parm);
        }

        public int Insert(DonNhapKhoDTO pro)
        {
            return Insert(pro.Madnk, pro.Manv, pro.Mancc, pro.Ngaynhap, pro.Tongsoluong);
        }

        public int Update(int madnk, int manv, int mancc, DateTime ngaynhap, int tongsoluong)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
                new SqlParameter(PARM_MADNK,SqlDbType.Int),
                new SqlParameter(PARM_MANV,SqlDbType.Int),
                new SqlParameter(PARM_MANCC,SqlDbType.Int),
                new SqlParameter(PARM_NGAYNHAP,SqlDbType.DateTime),
                new SqlParameter(PARM_TONGSOLUONG,SqlDbType.Int)
           };
            parm[0].Value = madnk;
            parm[1].Value = manv;
            parm[2].Value = mancc;
            parm[3].Value = ngaynhap;
            parm[4].Value = tongsoluong;

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_DonNhapKho_Upd", parm);
        }
    }
}
