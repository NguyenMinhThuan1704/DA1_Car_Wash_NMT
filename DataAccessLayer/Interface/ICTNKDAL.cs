using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface ICTNKDAL
    {
        int Insert(int mactnk, int madnk, int madv, int gianhap, int soluongnhap);
        int Delete(int mactnk);
        int Update(int mactnk, int madnk, int madv, int gianhap, int soluongnhap);
        DataTable getAll();
        int checkChiTietNK_ID(int mactnk);
    }
}
