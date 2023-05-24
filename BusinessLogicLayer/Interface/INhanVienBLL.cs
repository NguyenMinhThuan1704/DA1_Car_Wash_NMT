using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interface
{
    public interface INhanVIenBLL
    {
        int Insert(NhanVienDTO nv);
        int Delete(int manv);
        int Update(NhanVienDTO nv);
        IList<NhanVienDTO> getAll();
        IList<NhanVienDTO> SearchLinq(string value);
        void ThemTuExcel(string filePath);
        void KetXuatWord(string templatePath, string exportPath);
    }
}
