using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interface
{
    public interface IKhachHangBLL
    {
        int Insert(KhachHangDTO kh);
        int Delete(int makh);
        int Update(KhachHangDTO kh);
        IList<KhachHangDTO> getAll();
        IList<KhachHangDTO> SearchLinq(string value);

        List<dynamic> getAllJoin(ILoaiXeBLL loaixe);
    }
}
