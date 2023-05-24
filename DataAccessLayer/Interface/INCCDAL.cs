using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface INCCDAL
    {
        int Insert(int mancc, string tenncc, string diachi, string dienthoai);
        int Delete(int mancc);
        int Update(int mancc, string tenncc, string diachi, string dienthoai);
        DataTable getAll();
        int checkNCC_ID(int mancc);
    }
}
