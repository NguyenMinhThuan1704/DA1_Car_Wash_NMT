using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interface
{
    public interface IDIchVuBLL
    {
        int Insert(DichVuDTO dv);
        int Delete(int madv);
        int Update(DichVuDTO dv);

        IList<DichVuDTO> getAll();

        int checkDichVu_ID(int madv);
        IList<DichVuDTO> SearchLinq(string value);
        void ThemTuExcel(string filePath);

        void KetXuatWord(string templatePath, string exportPath);

        List<dynamic> getAllJoin(ILoaiDichVuBLL loaidv);
    }
}
