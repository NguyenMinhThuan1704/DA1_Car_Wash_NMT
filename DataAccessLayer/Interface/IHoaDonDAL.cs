using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IHoaDonDAL
    {
        int Insert(int manv, int makh, DateTime ngaylap, float tongtien);
        int Delete(int mahd);
        int Update(int mahd, int manv, int makh, DateTime ngaylap, float tongtien);
        DataTable getAll();
        int checkHoaDon_ID(int mahd);
    }
}
