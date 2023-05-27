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
    public class ChiTietHoaDonBLL : IChiTietHoaDonBLL
    {
        private readonly IChiTietHoaDonDAL dal = new ChiTietHoaDonDAL();
        IDIchVuBLL dvBLL = new DichVuBLL();
        public int checkChitiet_ID(int macthd)
        {
            return dal.checkChitiet_ID(macthd);
        }

        public int Delete(int macthd)
        {
            if (checkChitiet_ID(macthd) != 0)
                return dal.Delete(macthd);
            else return -1;
        }

        public IList<ChiTietHoaDonDTO> getAll()
        {
            System.Data.DataTable table = dal.getAll();
            IList<ChiTietHoaDonDTO> list = new List<ChiTietHoaDonDTO>();
            foreach (DataRow row in table.Rows)
            {
                ChiTietHoaDonDTO cls = new ChiTietHoaDonDTO();
                cls.Macthd = row.Field<int>(0);
                cls.Mahd = row.Field<int>(1);
                cls.Madv = row.Field<int>(2);
                cls.Giadv = row.Field<float>(3);
                cls.Solansd = row.Field<int>(4);
                list.Add(cls);
            }
            return list;
        }

        public int Insert(ChiTietHoaDonDTO cls)
        {
            if (checkChitiet_ID(cls.Macthd) == 0)
                return dal.Insert(cls.Mahd, cls.Madv, cls.Giadv, cls.Solansd, cls.Mucgiangia);
            else return -1;
        }

        public void KetXuatWord(string name, int mahd, float tongtien, string tenv, string templatePath, string exportPath)
        {
            IChiTietHoaDonBLL chitiet = new ChiTietHoaDonBLL();
            IList<ChiTietHoaDonDTO> list = chitiet.getAll();
            IList<ChiTietHoaDonDTO> newList = list.Where(ct => ct.Mahd == mahd).ToList();
            Dictionary<string, string> dictionaryData = new Dictionary<string, string>();
            dictionaryData.Add("tenkhachhang", name);
            dictionaryData.Add("tongtien", tongtien.ToString());
            dictionaryData.Add("nhanvien", tenv);
            System.IO.File.Copy(templatePath, exportPath, true);
            ExportDocx.CreateChiTietTemplate(exportPath, dictionaryData, newList);
        }

        public int Update(ChiTietHoaDonDTO cls)
        {
            if (checkChitiet_ID(cls.Macthd) != 0)
                return dal.Update(cls.Macthd, cls.Mahd, cls.Madv, cls.Giadv, cls.Solansd, cls.Mucgiangia);
            else return -1;
        }
    }
}
