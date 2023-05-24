using BusinessLogicLayer.Interface;
using DataAccessLayer;
using DataAccessLayer.Interface;
using DocumentFormat.OpenXml.Bibliography;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class DichVuBLL : IDIchVuBLL
    {
        private readonly IDichVuDAL dal = new DichVuDAL();
        public int checkDichVu_ID(int madv)
        {
            return dal.checkDichVu_ID(madv);
        }

        public int Delete(int madv)
        {
            if (checkDichVu_ID(madv) != 0)
                return dal.Delete(madv);
            else return -1;
        }

        public IList<DichVuDTO> getAll()
        {
            System.Data.DataTable table = dal.getAll();
            IList<DichVuDTO> list = new List<DichVuDTO>();
            foreach (DataRow row in table.Rows)
            {
                DichVuDTO cls = new DichVuDTO();
                cls.madv = row.Field<int>(0);
                cls.tendv = row.Field<string>(1);
                cls.maloaidv = row.Field<int>(2);
                cls.giadv = row.Field<int>(3);
                cls.soluong = row.Field<int>(4);
                list.Add(cls);
            }
            return list;
        }

        public int Insert(DichVuDTO dv)
        {
            if (checkDichVu_ID(dv.madv) == 0)
                return dal.Insert(dv.madv, dv.tendv, dv.maloaidv, dv.giadv, dv.soluong);
            else return -1;
        }

        public void KetXuatWord(string templatePath, string exportPath)
        {
            IList<DichVuDTO> list = getAll();
            Dictionary<string, string> dictionaryData = new Dictionary<string, string>();
            System.IO.File.Copy(templatePath, exportPath, true);
            ExportDocx.CreateDichVuTemplate(exportPath, dictionaryData, list);
        }

        public IList<DichVuDTO> SearchLinq(string value)
        {
            return getAll().Where(x => string.IsNullOrEmpty(value) || x.tendv.Contains(value) ||
                (x.madv.ToString().Contains(value)) || (x.giadv.ToString().Contains(value)) || 
                (x.soluong.ToString().Contains(value))).ToList();
        }

        public void ThemTuExcel(string filePath)
        {
            var messageError = "";
            var data = ExcelHelper.ReadFromExcelFile(filePath, 1, out messageError);
            Console.Write(data);
            if (string.IsNullOrEmpty(messageError))
            {
                foreach (DataRow row in data.Rows)
                {
                    DichVuDTO nv = new DichVuDTO();
                    nv.madv = int.Parse(row.Field<string>("Madv"));
                    nv.tendv = row.Field<string>("Tendv");
                    nv.maloaidv = int.Parse(row.Field<string>("Maloaidv"));
                    nv.giadv = int.Parse(row.Field<string>("Giadv"));
                    nv.soluong = int.Parse(row.Field<string>("Soluong"));
                    dal.Insert(nv);
                }
            }
            else throw new Exception(messageError);
        }

        public int Update(DichVuDTO dv)
        {
            if (checkDichVu_ID(dv.madv) != 0)
                return dal.Update(dv.madv, dv.tendv, dv.maloaidv, dv.giadv, dv.soluong);
            else return -1;
        }
        public List<dynamic> getAllJoin(ILoaiDichVuBLL loaidv)
        {
            var dv_loaidv = (from dv in getAll()
                             join pd in loaidv.getAll() on dv.maloaidv equals pd.MaLoaiDV
                             select new { MaDv = dv.madv, TenDv = dv.tendv, MaLoaiXe = dv.maloaidv, GiaDv = dv.giadv, SoLuong = dv.soluong, TenLoaiDV = pd.TenLoaiDV });
            return dv_loaidv.Cast<dynamic>().ToList();
        }
    }
}
