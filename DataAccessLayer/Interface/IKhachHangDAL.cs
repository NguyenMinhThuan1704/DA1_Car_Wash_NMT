using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IKhachHangDAL
    {
        int Insert(int makh, string tenkh, int maloaixe, string diachi, string dienthoai);
        int Insert(KhachHangDTO kh);
        int Delete(int makh);
        int Update(int makh, string tenkh, int maloaixe, string diachi, string dienthoai);
        DataTable getAll();
        int checkKhachHang_ID(int makh);
    }
}
