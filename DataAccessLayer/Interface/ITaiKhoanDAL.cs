using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface ITaiKhoanDAL
    {
        int Insert(int manhanvien, int matk, string taikhoan, string matkhau);
        int Delete(int matk);
        int Update(int manhanvien, int matk, string taikhoan, string matkhau);
        DataTable getAll();
        int checkTaiKhoan_ID(int matk);
    }
}
