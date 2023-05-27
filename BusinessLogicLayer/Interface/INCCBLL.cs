using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interface
{
    public interface INCCBLL
    {
        int Insert(NCCDTO cls);
        int Delete(int mancc);
        int Update(NCCDTO cls);
        IList<NCCDTO> getAll();
        int checkNCC_ID(int mancc);
        IList<NCCDTO> SearchLinq(string value);
        void KetXuatWord(string templatePath, string exportPath);
    }
}
