using DataAccessLayer.Interface;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class NhanVienDAL : INhanVienDAL
    {
        private const string PARM_MANV = "@manv";
        private const string PARM_HOTEN = "@tennv";
        private const string PARM_GIOITINH = "@gioitinh";
        private const string PARM_DIACHI = "@diachi";
        private const string PARM_SDT = "@dienthoai";
        private const string PARM_NGAYSINH = "@ngaysinh";
        public int Insert(NhanVienDTO nv)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MANV,SqlDbType.Int),
                new SqlParameter(PARM_HOTEN,SqlDbType.NVarChar,50),
                new SqlParameter(PARM_GIOITINH,SqlDbType.Bit),
                new SqlParameter(PARM_DIACHI,SqlDbType.NVarChar,50),
                new SqlParameter(PARM_SDT,SqlDbType.NVarChar,50),
                new SqlParameter(PARM_NGAYSINH,SqlDbType.DateTime)
            };
            if (string.IsNullOrEmpty(nv.manv.ToString()))
                parm[0].Value = DBNull.Value;
            else
                parm[0].Value = nv.manv;

            if (nv.tennv == null)
                parm[1].Value = DBNull.Value;
            else
                parm[1].Value = nv.tennv;

            if (string.IsNullOrEmpty(nv.gioitinh.ToString()))
                parm[2].Value = DBNull.Value;
            else
                parm[2].Value = nv.gioitinh;

            if (string.IsNullOrEmpty(nv.diachi))
                parm[3].Value = DBNull.Value;
            else
                parm[3].Value = nv.diachi;

            if (string.IsNullOrEmpty(nv.dienthoai.ToString()))
                parm[4].Value = DBNull.Value;
            else
                parm[4].Value = nv.dienthoai;

            if (string.IsNullOrEmpty(nv.ngaysinh.ToString()))
                parm[5].Value = DBNull.Value;
            else
                parm[5].Value = nv.ngaysinh;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_ThemNV", parm);
        }
        
        public int Delete(int manv)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MANV,SqlDbType.Int)
            };
            parm[0].Value = manv;
            Console.WriteLine(manv);

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_XoaNV", parm);
        }

        public DataTable getAll()
        {
            SqlDataReader dra = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_NV_Sel_All", null);
            DataTable table = new DataTable();
            table.Columns.Add("manv", typeof(int));
            table.Columns.Add("tennv", typeof(string));
            table.Columns.Add("gioitinh", typeof(Boolean));
            table.Columns.Add("diachi", typeof(string));
            table.Columns.Add("dienthoai", typeof(string));
            table.Columns.Add("ngaysinh", typeof(DateTime));
            while (dra.Read())
            {
                table.Rows.Add(int.Parse(dra["manv"].ToString()), dra["tennv"].ToString(), dra["gioitinh"].ToString(), dra["diachi"].ToString(), dra["dienthoai"].ToString(), dra["ngaysinh"].ToString());
            }
            dra.Dispose();
            Console.WriteLine(table);
            return table;
        }

        public int checkNhanVien_ID(int manv)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MANV,SqlDbType.Int)
            };
            parm[0].Value = manv;
            return (int)SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_check_NV", parm);
        }

        public int Update(int manv, string tennv, bool gioitinh, string diachi, string dienthoai, DateTime ngaysinh)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MANV,SqlDbType.Int),
                new SqlParameter(PARM_HOTEN,SqlDbType.NVarChar,50),
                new SqlParameter(PARM_GIOITINH,SqlDbType.Bit),
                new SqlParameter(PARM_DIACHI,SqlDbType.NVarChar,50),
                new SqlParameter(PARM_SDT,SqlDbType.NVarChar,50),
                new SqlParameter(PARM_NGAYSINH,SqlDbType.DateTime),
            };
            parm[0].Value = manv;
            parm[1].Value = tennv;
            parm[2].Value = gioitinh;
            parm[3].Value = diachi;
            parm[4].Value = dienthoai;
            parm[5].Value = ngaysinh;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_SuaNV", parm);
        }

        public int Insert(int manv, string tennv, bool gioitinh, string diachi, string dienthoai, DateTime ngaysinh)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter(PARM_MANV,SqlDbType.Int),
                new SqlParameter(PARM_HOTEN,SqlDbType.NVarChar,50),
                new SqlParameter(PARM_GIOITINH,SqlDbType.Bit),
                new SqlParameter(PARM_DIACHI,SqlDbType.NVarChar,50),
                new SqlParameter(PARM_SDT,SqlDbType.NVarChar,50),
                new SqlParameter(PARM_NGAYSINH,SqlDbType.DateTime)
            };
            parm[0].Value = manv;
            parm[1].Value = tennv;
            parm[2].Value = gioitinh;
            parm[3].Value = diachi;
            parm[4].Value = dienthoai;
            parm[5].Value = ngaysinh;
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, "sp_ThemNV", parm);
        }
    }
}
