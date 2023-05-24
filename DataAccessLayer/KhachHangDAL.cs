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
    public class KhachHangDAL : IKhachHangDAL
    {
        private const string PARM_KHACHHANGID = "@Makh";
        private const string PARM_TENKH = "@Tenkh";
        private const string PARM_MALOAIXE = "@Maloaixe";
        private const string PARM_DIACHI = "@Diachi";
        private const string PARM_DIENTHOAI = "@Dienthoai";
        public int checkKhachHang_ID(int makh)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
                new SqlParameter(PARM_KHACHHANGID,SqlDbType.Int)
           };
            parm[0].Value = makh;
            return (int)SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_KhachHang_Check", parm);
        }

        public int Delete(int makh)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_KHACHHANGID,SqlDbType.Int)
            };
            parm[0].Value = makh;
            Console.WriteLine(makh);

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_KhachHang_Del", parm);
        }

        public DataTable getAll()
        {
            SqlDataReader dra = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_KhachHang_Sel_All", null);
            DataTable table = new DataTable();
            table.Columns.Add("MaKh", typeof(int));
            table.Columns.Add("TenKh", typeof(string));
            table.Columns.Add("MaLoaiXe", typeof(int));
            table.Columns.Add("DiaChi", typeof(string));
            table.Columns.Add("DienThoai", typeof(string));
            while (dra.Read())
            {
                table.Rows.Add(int.Parse(dra["MaKh"].ToString()), dra["TenKh"].ToString(), int.Parse(dra["MaLoaiXe"].ToString()), dra["DiaChi"].ToString(), dra["DienThoai"].ToString());
            }
            dra.Dispose();
            Console.WriteLine(table);
            return table;
        }

        public int Insert(int makh, string tenkh, int maloaixe, string diachi, string dienthoai)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_KHACHHANGID,SqlDbType.Int),
                new SqlParameter(PARM_TENKH,SqlDbType.NVarChar,50),
                new SqlParameter(PARM_MALOAIXE,SqlDbType.Int),
                new SqlParameter(PARM_DIACHI,SqlDbType.NVarChar,50),
                new SqlParameter(PARM_DIENTHOAI,SqlDbType.NVarChar,50),
            };
            parm[0].Value = makh;
            parm[1].Value = tenkh;
            parm[2].Value = maloaixe;
            parm[3].Value = diachi;
            parm[4].Value = dienthoai;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_KhachHang_Ins", parm);
        }

        public int Insert(KhachHangDTO kh)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
                new SqlParameter(PARM_KHACHHANGID,SqlDbType.Int),
                new SqlParameter(PARM_TENKH,SqlDbType.NVarChar,50),
                new SqlParameter(PARM_MALOAIXE,SqlDbType.Int),
                new SqlParameter(PARM_DIACHI,SqlDbType.NVarChar,50),
                new SqlParameter(PARM_DIENTHOAI,SqlDbType.NVarChar,50),
           };
            if (string.IsNullOrEmpty(kh.makh.ToString()))
                parm[0].Value = DBNull.Value;
            else
                parm[0].Value = kh.makh;

            if (kh.tenkh == null)
                parm[1].Value = DBNull.Value;
            else
                parm[1].Value = kh.tenkh;

            if (string.IsNullOrEmpty(kh.maloaixe.ToString()))
                parm[2].Value = DBNull.Value;
            else
                parm[2].Value = kh.maloaixe;

            if (string.IsNullOrEmpty(kh.diachi))
                parm[3].Value = DBNull.Value;
            else
                parm[3].Value = kh.diachi;

            if (string.IsNullOrEmpty(kh.dienthoai))
                parm[4].Value = DBNull.Value;
            else
                parm[4].Value = kh.dienthoai;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_KhachHang_Ins", parm);
        }

        public int Update(int makh, string tenkh, int maloaixe, string diachi, string dienthoai)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_KHACHHANGID,SqlDbType.Int),
                new SqlParameter(PARM_TENKH,SqlDbType.NVarChar,50),
                new SqlParameter(PARM_MALOAIXE,SqlDbType.Int),
                new SqlParameter(PARM_DIACHI,SqlDbType.NVarChar,50),
                new SqlParameter(PARM_DIENTHOAI,SqlDbType.NVarChar,50),
            };
            parm[0].Value = makh;
            parm[1].Value = tenkh;
            parm[2].Value = maloaixe;
            parm[3].Value = diachi;
            parm[4].Value = dienthoai;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_KhachHang_Upd", parm);
        }
    }
}
