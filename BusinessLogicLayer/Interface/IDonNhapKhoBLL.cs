using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interface
{
    public interface IDonNhapKhoBLL
    {
        int Insert(DonNhapKhoDTO pro);
        int Delete(int madnk);
        int Update(DonNhapKhoDTO pro);

        IList<DonNhapKhoDTO> getAll();

        int checkDonNhapKho_ID(int madnk);
        List<dynamic> SearchLinq(string value);
        void ThemTuExcel(string filePath);

        List<dynamic> getAllJoin();

        void KetXuatWord(string templatePath, string exportPath);
    }
}
