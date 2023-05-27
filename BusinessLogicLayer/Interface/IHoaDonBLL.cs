using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interface
{
    public interface IHoaDonBLL
    {
        int Insert(HoaDonDTO hd);
        int Delete(int mahd);
        int Update(HoaDonDTO cls);
        IList<HoaDonDTO> getAll();
        IList<HoaDonDTO> SearchLinq(HoaDonDTO cls);
        int checkHoaDon_ID(int mahd);

        HoaDonDTO GetLastHD();
    }
}
