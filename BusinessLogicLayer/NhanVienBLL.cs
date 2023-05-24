using BusinessLogicLayer.Interface;
using DataAccessLayer.Interface;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Utility;
using System.Data;
using System.Globalization;

namespace BusinessLogicLayer
{
    public class NhanVienBLL : INhanVIenBLL
    {
        private readonly INhanVienDAL dal = new NhanVienDAL();

        public int Delete(int manv)
        {
            if (checkNhanVien_ID(manv) != 0)
                return dal.Delete(manv);
            else return -1;
        }
        public int checkNhanVien_ID(int manv)
        {
            return dal.checkNhanVien_ID(manv);
        }

        public IList<NhanVienDTO> getAll()
        {
            System.Data.DataTable table = dal.getAll();
            IList<NhanVienDTO> list = new List<NhanVienDTO>();
            foreach (DataRow row in table.Rows)
            {
                NhanVienDTO nv = new NhanVienDTO();
                nv.manv = row.Field<int>(0);
                nv.tennv = row.Field<string>(1);
                nv.gioitinh = row.Field<bool>(2);
                nv.diachi = row.Field<string>(3);
                nv.dienthoai = row.Field<string>(4);
                nv.ngaysinh = row.Field<DateTime>(5);
                list.Add(nv);
            }
            return list;
        }

        public int Insert(NhanVienDTO nv)
        {
            return dal.Insert(nv.manv, nv.tennv, nv.gioitinh, nv.diachi, nv.dienthoai, nv.ngaysinh);
        }

        public void KetXuatWord(string templatePath, string exportPath)
        {
            INhanVIenBLL nv = new NhanVienBLL();
            IList<NhanVienDTO> listData = nv.getAll();
            Dictionary<string, string> dictionaryData = new Dictionary<string, string>();
            System.IO.File.Copy(templatePath, exportPath, true);
            ExportDocx.CreateNhanVienTemplate(exportPath, dictionaryData, listData);
        }

        public IList<NhanVienDTO> SearchLinq(string value)
        {
            return getAll().Where(x => string.IsNullOrEmpty(value) || x.tennv.Contains(value) ||
                (x.manv.ToString().Contains(value)) || /*(x.manv.ToString() == value)*/
                (string.IsNullOrEmpty(value) || x.gioitinh.ToString().Contains(value)) ||
                (string.IsNullOrEmpty(value) || x.dienthoai.Contains(value)) ||
                (string.IsNullOrEmpty(value) || x.diachi.Contains(value)) ||
                (x.ngaysinh.ToString().Contains(value))).ToList();
        }

        public void ThemTuExcel(string filePath)
        {
            var messageError = "";
            var data = ExcelHelper.ReadFromExcelFile(filePath, 1, out messageError);
            if (string.IsNullOrEmpty(messageError))
            {
                foreach (DataRow row in data.Rows)
                {
                    NhanVienDTO nv = new NhanVienDTO();
                    nv.manv = row.Field<int>("");
                    nv.tennv = row.Field<string>("tennv");
                    nv.gioitinh = row.Field<bool>("gioitinh");
                    nv.diachi = row.Field<string>("diachi");
                    nv.dienthoai = row.Field<string>("dienthoai");
                    nv.ngaysinh = DateTime.ParseExact(row.Field<string>("ngaysinh"), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    dal.Insert(nv);
                }
            }
            else throw new Exception(messageError);
        }

        public int Update(NhanVienDTO nv)
        {
            if (checkNhanVien_ID(nv.manv) != 0)
                return dal.Update(nv.manv, nv.tennv, nv.gioitinh, nv.diachi, nv.dienthoai, nv.ngaysinh);
            else return -1;
        }
    }
}
