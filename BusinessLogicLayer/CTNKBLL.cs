using BusinessLogicLayer.Interface;
using DataAccessLayer;
using DataAccessLayer.Interface;
using DocumentFormat.OpenXml.VariantTypes;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class CTNKBLL : ICTNKBLL
    {
        private readonly ICTNKDAL dal = new CTNKDAL();
        IDIchVuBLL dv = new DichVuBLL();
        public int checkChiTietNK_ID(int mactnk)
        {
            return dal.checkChiTietNK_ID(mactnk);
        }

        public int Delete(int mactnk)
        {
            if (checkChiTietNK_ID(mactnk) != 0)
                return dal.Delete(mactnk);
            else return -1;
        }

        public IList<CTNKDTO> getAll()
        {
            System.Data.DataTable table = dal.getAll();
            Console.WriteLine(table);
            IList<CTNKDTO> list = new List<CTNKDTO>();
            foreach (DataRow row in table.Rows)
            {
                CTNKDTO cls = new CTNKDTO();
                cls.Mactnk = row.Field<int>(0);
                cls.Madnk = row.Field<int>(1);
                cls.Madv = row.Field<int>(2);
                cls.Gianhap = row.Field<int>(3);
                cls.Soluongnhap = row.Field<int>(4);
                list.Add(cls);
            }
            return list;
        }

        public List<dynamic> getAllJoin()
        {
            var ctnk_dichvu = (from ctnk in getAll()
                             join dv in dv.getAll() on ctnk.Madv equals dv.madv
                             select new { MaCTNK = ctnk.Mactnk, MaDNK = ctnk.Madnk, MaDV = ctnk.Madv, GiaNhap = ctnk.Gianhap, SoLuongNhap = ctnk.Soluongnhap, TenDichVu = dv.tendv });
            return ctnk_dichvu.Cast<dynamic>().ToList();
        }

        public int Insert(CTNKDTO cls)
        {
            if (checkChiTietNK_ID(cls.Mactnk) == 0)
                return dal.Insert(cls.Mactnk, cls.Madnk, cls.Madv, cls.Gianhap, cls.Soluongnhap);
            else return -1;
        }

        public void KetXuatWord(string templatePath, string exportPath)
        {
            IList<CTNKDTO> list = getAll();
            Dictionary<string, string> dictionaryData = new Dictionary<string, string>();
            System.IO.File.Copy(templatePath, exportPath, true);
            ExportDocx.CreateCTDNKTemplate(exportPath, dictionaryData, list);
        }

        public IList<CTNKDTO> SearchLinq(string value)
        {
            return getAll().Where(x => (string.IsNullOrEmpty(value) || x.Mactnk.ToString().Contains(value) ||
               (string.IsNullOrEmpty(value) || x.Madv.ToString().Contains(value)))).ToList();
        }

        public int Update(CTNKDTO cls)
        {
            if (checkChiTietNK_ID(cls.Mactnk) != 0)
                return dal.Update(cls.Mactnk, cls.Madnk, cls.Madv, cls.Gianhap, cls.Soluongnhap);
            else return -1;
        }
    }
}
