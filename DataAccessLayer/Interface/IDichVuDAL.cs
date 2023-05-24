using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IDichVuDAL
    {
        int Insert(DichVuDTO dv);
        int Delete(int madv);
        DataTable getAll();
        int checkDichVu_ID(int madv);
        int Update(int madv, string tendv, int maloaidv, int giadv, int soluong);
        int Insert(int madv, string tendv, int maloaidv, int giadv, int soluong);
    }
}
