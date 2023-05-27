using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IChiTietHoaDonDAL
    {
        int Insert(int mahd, int madv, float giadv, int solansd, float mucgiamgia);
        int Delete(int macthd);
        int Update(int macthd, int mahd, int madv, float giadv, int solansd, float mucgiamgia);
        DataTable getAll();
        int checkChitiet_ID(int macthd);
    }
}
