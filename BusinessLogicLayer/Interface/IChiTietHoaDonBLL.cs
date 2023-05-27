using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interface
{
    public interface IChiTietHoaDonBLL
    {
        int Insert(ChiTietHoaDonDTO cls);
        int Delete(int macthd);
        int Update(ChiTietHoaDonDTO cls);
        IList<ChiTietHoaDonDTO> getAll();
        int checkChitiet_ID(int macthd);

        void KetXuatWord(string name, int mahd, float tongtien, string tenv, string templatePath, string exportPath);
    }
}
