using BusinessLogicLayer.Interface;
using DataAccessLayer.Interface;
using DataAccessLayer;
using DocumentFormat.OpenXml.Bibliography;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BusinessLogicLayer
{
    public class TaiKhoanBLL : ITaiKhoanBLL
    {
        private readonly ITaiKhoanDAL dal = new TaiKhoanDAL();
        public INhanVIenBLL nv = new NhanVienBLL();
        public int checkTaiKhoan_ID(int Matk)
        {
            return dal.checkTaiKhoan_ID(Matk);
        }

        public bool checkTaiKhoan_IsExist(string tk, string mk)
        {
            bool isAccountExist = getAll().Any(account =>
            {
                return account.Taikhoan == tk && mk == account.Matkhau;
            });
            return isAccountExist;
        }

        public int Delete(int matk)
        {
            if (checkTaiKhoan_ID(matk) != 0)
                return dal.Delete(matk);
            else return -1;
        }

        public IList<TaiKhoanDTO> getAll()
        {
            System.Data.DataTable table = dal.getAll();
            IList<TaiKhoanDTO> list = new List<TaiKhoanDTO>();
            foreach (DataRow row in table.Rows)
            {
                TaiKhoanDTO cls = new TaiKhoanDTO();
                cls.Manhanvien = row.Field<int>(0);
                cls.Matk = row.Field<int>(1);
                cls.Taikhoan = row.Field<string>(2);
                cls.Matkhau = row.Field<string>(3);
                list.Add(cls);
            }
            return list;
        }

        public List<dynamic> getAllJoin()
        {
            var tk_nhanvien = (from tk in getAll()
                             join nv in nv.getAll() on tk.Manhanvien equals nv.manv
                             select new {NhanVien = tk.Manhanvien, Matk = tk.Matk, TaiKhoan = tk.Taikhoan, MatKhau = tk.Matkhau, TenNhanVien = nv.tennv });
            return tk_nhanvien.Cast<dynamic>().ToList();
        }

        public NhanVienDTO GetNhanVien(int manv)
        {
            NhanVienDTO thongtinnv = nv.getAll().FirstOrDefault(t => t.manv == manv);
            return thongtinnv;
        }

        public int Insert(TaiKhoanDTO cls)
        {
            if (checkTaiKhoan_ID(cls.Matk) == 0)
                return dal.Insert(cls.Manhanvien, cls.Matk, cls.Taikhoan, cls.Matkhau);
            else return -1;
        }

        public IList<TaiKhoanDTO> SearchLinq(string value)
        {
            return getAll().Where(x => string.IsNullOrEmpty(value) || x.Taikhoan.Contains(value) ||
                (x.Manhanvien.ToString() == value)).ToList();
        }

        public TaiKhoanDTO TaiKhoanLogin(string tk, string mk)
        {
            if (checkTaiKhoan_IsExist(tk, mk))
            {
                TaiKhoanDTO taiKhoanTimThay = getAll().FirstOrDefault(t => t.Taikhoan == tk && t.Matkhau == mk);
                return taiKhoanTimThay;
            }
            else
            {
                return null;
            }
        }

        public int Update(TaiKhoanDTO cls)
        {
            if (checkTaiKhoan_ID(cls.Matk) != 0)
                return dal.Update(cls.Manhanvien, cls.Matk, cls.Taikhoan, cls.Matkhau);
            else return -1;
        }
    }
}
