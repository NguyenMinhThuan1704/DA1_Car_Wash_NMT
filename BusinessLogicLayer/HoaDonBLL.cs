using BusinessLogicLayer.Interface;
using DataAccessLayer.Interface;
using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BusinessLogicLayer
{
    public class HoaDonBLL : IHoaDonBLL
    {
        private readonly IHoaDonDAL dal = new HoaDonDAL();
        public int checkHoaDon_ID(int mahd)
        {
            return dal.checkHoaDon_ID(mahd);
        }

        public int Delete(int mahd)
        {
            if (checkHoaDon_ID(mahd) != 0)
                return dal.Delete(mahd);
            else return -1;
        }

        public IList<HoaDonDTO> getAll()
        {
            System.Data.DataTable table = dal.getAll();
            IList<HoaDonDTO> list = new List<HoaDonDTO>();
            foreach (DataRow row in table.Rows)
            {
                HoaDonDTO cls = new HoaDonDTO();
                cls.Mahd = row.Field<int>(0);
                cls.Manv = row.Field<int>(1);
                cls.Makh = row.Field<int?>(2).GetValueOrDefault();
                cls.Ngaylap = row.Field<DateTime>(3);
                cls.Tongtien = row.Field<float>(4);
                list.Add(cls);
            }
            return list;
        }
        public IList<dynamic> allhd()
        {
            var list = getAll();
            return list.Cast<dynamic>().ToList();
        }

        public HoaDonDTO GetLastHD()
        {
            return getAll().OrderByDescending(hd => hd.Mahd).FirstOrDefault();
        }

        public int Insert(HoaDonDTO hd)
        {
            if (checkHoaDon_ID(hd.Mahd) == 0)
                return dal.Insert(hd.Manv, hd.Makh, hd.Ngaylap, hd.Tongtien);
            else return -1;
        }

        public IList<HoaDonDTO> SearchLinq(HoaDonDTO cls)
        {
            return getAll().Where(x => (string.IsNullOrEmpty(cls.Mahd.ToString()) || x.Mahd.ToString().Contains(cls.Mahd.ToString()))).ToList();
        }

        public int Update(HoaDonDTO cls)
        {
            if (checkHoaDon_ID(cls.Mahd) != 0)
                return dal.Update(cls.Mahd, cls.Manv, cls.Makh, cls.Ngaylap, cls.Tongtien);
            else return -1;
        }
    }
}
