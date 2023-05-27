using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interface
{
    public interface ICTNKBLL
    {
        int Insert(CTNKDTO cls);
        int Delete(int mactnk);
        int Update(CTNKDTO cls);
        IList<CTNKDTO> getAll();
        List<dynamic> getAllJoin();
        IList<CTNKDTO> SearchLinq(string value);

        int checkChiTietNK_ID(int mactnk);

        void KetXuatWord(string templatePath, string exportPath);
    }
}
