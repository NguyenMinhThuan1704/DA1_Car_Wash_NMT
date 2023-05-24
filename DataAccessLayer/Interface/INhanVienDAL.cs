using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface INhanVienDAL
    {
        int Insert(NhanVienDTO nv);
        int Delete(int manv);
        DataTable getAll();
        int checkNhanVien_ID(int manv);
        int Update(int manv, string tennv, bool gioitinh, string diachi, string dienthoai, DateTime ngaysinh);
        int Insert(int manv, string tennv, bool gioitinh, string diachi, string dienthoai, DateTime ngaysinh);
    }
}
