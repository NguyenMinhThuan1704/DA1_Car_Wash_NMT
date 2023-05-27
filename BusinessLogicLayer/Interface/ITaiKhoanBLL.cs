using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interface
{
    public interface ITaiKhoanBLL
    {
        int Insert(TaiKhoanDTO cls);
        int Delete(int matk);
        int Update(TaiKhoanDTO cls);
        IList<TaiKhoanDTO> getAll();
        int checkTaiKhoan_ID(int Matk);

        bool checkTaiKhoan_IsExist(string tk, string mk);

        TaiKhoanDTO TaiKhoanLogin(string tk, string mk);
        NhanVienDTO GetNhanVien(int manv);
        List<dynamic> getAllJoin();
        IList<TaiKhoanDTO> SearchLinq(string value);
    }
}
