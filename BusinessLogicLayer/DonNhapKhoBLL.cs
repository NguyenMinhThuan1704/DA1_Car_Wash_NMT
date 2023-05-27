using BusinessLogicLayer.Interface;
using DataAccessLayer;
using DataAccessLayer.Interface;
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
    public class DonNhapKhoBLL : IDonNhapKhoBLL
    {
        private readonly IDonNhapKhoDAL dal = new DonNhapKhoDAL();
        INCCBLL provider = new NCCBLL();
        INhanVIenBLL nv = new NhanVienBLL();
        public int checkDonNhapKho_ID(int madnk)
        {
            return dal.checkDonNhapKho_ID(madnk);
        }

        public int Delete(int madnk)
        {
            if (checkDonNhapKho_ID(madnk) != 0)
                return dal.Delete(madnk);
            else return -1;
        }

        public IList<DonNhapKhoDTO> getAll()
        {
            System.Data.DataTable table = dal.getAll();
            IList<DonNhapKhoDTO> list = new List<DonNhapKhoDTO>();
            foreach (DataRow row in table.Rows)
            {
                DonNhapKhoDTO cls = new DonNhapKhoDTO();
                cls.Madnk = row.Field<int>(0);
                cls.Manv = row.Field<int>(1);
                cls.Mancc = row.Field<int>(2);
                cls.Ngaynhap = row.Field<DateTime>(3);
                cls.Tongsoluong = row.Field<int>(4);
                list.Add(cls);
            }
            return list;
        }

        public List<dynamic> getAllJoin()
        {
            var DNK_NCC = (from dnk in getAll()
                           join pv in provider.getAll() on dnk.Mancc equals pv.Mancc
                           join nv in nv.getAll() on dnk.Manv equals nv.manv
                           select new { Madnk = dnk.Madnk, Manv = dnk.Manv, Mancc = dnk.Mancc, Ngaynhap = dnk.Ngaynhap, Soluong = dnk.Tongsoluong, Nhanvien = dnk.Manv, Tenncc = pv.Tenncc, Tennv = nv.tennv });
            return DNK_NCC.Cast<dynamic>().ToList();
        }

        public int Insert(DonNhapKhoDTO pro)
        {
            if (checkDonNhapKho_ID(pro.Madnk) == 0)
                return dal.Insert(pro.Madnk, pro.Manv, pro.Mancc, pro.Ngaynhap, pro.Tongsoluong);
            else return -1;
        }

        public void KetXuatWord(string templatePath, string exportPath)
        {
            IList<DonNhapKhoDTO> list = getAll();
            Dictionary<string, string> dictionaryData = new Dictionary<string, string>();
            System.IO.File.Copy(templatePath, exportPath, true);
            ExportDocx.CreateDonNhapKhoTemplate(exportPath, dictionaryData, list);
        }

        public List<dynamic> SearchLinq(string value)
        {
            return getAllJoin().Where(x => (string.IsNullOrEmpty(value) || x.Madnk.ToString().Contains(value) ||
               (string.IsNullOrEmpty(value) || x.Tennv.Contains(value)) ||
               (string.IsNullOrEmpty(value) || x.Tenncc.Contains(value)))).ToList();
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
                    DonNhapKhoDTO nv = new DonNhapKhoDTO();
                    nv.Madnk = int.Parse(row.Field<string>("MaDNK"));
                    nv.Manv = int.Parse(row.Field<string>("MaNV"));
                    nv.Mancc = int.Parse(row.Field<string>("MaNCC"));
                    nv.Ngaynhap = DateTime.ParseExact(row.Field<string>("NgayNhap"), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    nv.Tongsoluong = int.Parse(row.Field<string>("TongSoLuong"));
                    dal.Insert(nv);
                }
            }
            else throw new Exception(messageError);
        }

        public int Update(DonNhapKhoDTO pro)
        {
            if (checkDonNhapKho_ID(pro.Madnk) != 0)
                return dal.Update(pro.Madnk, pro.Manv, pro.Mancc, pro.Ngaynhap, pro.Tongsoluong);
            else return -1;
        }
    }
}
