using BusinessLogicLayer.Interface;
using DataAccessLayer;
using DataAccessLayer.Interface;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class NCCBLL : INCCBLL
    {
        private readonly INCCDAL dal = new NCCDAL();

        public int checkNCC_ID(int mancc)
        {
            return dal.checkNCC_ID(mancc);
        }

        public int Delete(int mancc)
        {
            if (checkNCC_ID(mancc) != 0)
                return dal.Delete(mancc);
            else return -1;
        }

        public IList<NCCDTO> getAll()
        {
            System.Data.DataTable table = dal.getAll();
            IList<NCCDTO> list = new List<NCCDTO>();
            foreach (DataRow row in table.Rows)
            {
                NCCDTO cls = new NCCDTO();
                cls.Mancc = row.Field<int>(0);
                cls.Tenncc = row.Field<string>(1);
                cls.Diachi = row.Field<string>(2);
                cls.Dienthoai = row.Field<string>(3);
                list.Add(cls);
            }
            return list;
        }

        public int Insert(NCCDTO cls)
        {
            if (checkNCC_ID(cls.Mancc) == 0)
                return dal.Insert(cls.Mancc, cls.Tenncc, cls.Diachi, cls.Dienthoai);
            else return -1;
        }

        public IList<NCCDTO> SearchLinq(NCCDTO cls)
        {
            return getAll().Where(x => (string.IsNullOrEmpty(cls.Mancc.ToString()) || x.Mancc.ToString().Contains(cls.Mancc.ToString()))).ToList();
        }

        public int Update(NCCDTO cls)
        {
            if (checkNCC_ID(cls.Mancc) != 0)
                return dal.Update(cls.Mancc, cls.Tenncc, cls.Diachi, cls.Dienthoai);
            else return -1;
        }
    }
}
