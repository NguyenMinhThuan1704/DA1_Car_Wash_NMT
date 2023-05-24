using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IDonNhapKhoDAL
    {
        int Insert(int madnk, int manv, int mancc, DateTime ngaynhap, int tongsoluong);
        int Insert(DonNhapKhoDTO pro);

        int Delete(int madnk);
        int Update(int madnk, int manv, int mancc, DateTime ngaynhap, int tongsoluong);
        DataTable getAll();
        int checkDonNhapKho_ID(int madnk);
    }
}
