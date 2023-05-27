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
    public class KhachHangBLL : IKhachHangBLL
    {
        private readonly IKhachHangDAL dal = new KhachHangDAL();
        public int checkKhachHang_ID(int makh)
        {
            return dal.checkKhachHang_ID(makh);
        }
        public int Delete(int makh)
        {
            if (checkKhachHang_ID(makh) != 0)
                return dal.Delete(makh);
            else return -1;
        }

        public IList<KhachHangDTO> getAll()
        {
            System.Data.DataTable table = dal.getAll();
            IList<KhachHangDTO> list = new List<KhachHangDTO>();
            foreach (DataRow row in table.Rows)
            {
                KhachHangDTO cls = new KhachHangDTO();
                cls.makh = row.Field<int>(0);
                cls.tenkh = row.Field<string>(1);
                cls.maloaixe = row.Field<int>(2);
                cls.diachi = row.Field<string>(3);
                cls.dienthoai = row.Field<string>(4);
                list.Add(cls);
            }
            return list;
        }

        public List<dynamic> getAllJoin(ILoaiXeBLL loaixe)
        {
            var kh_loaixe = (from kh in getAll()
                             join pd in loaixe.getAll() on kh.maloaixe equals pd.MaLoaiXe
                             select new { MaKh = kh.makh, TenKh = kh.tenkh, MaLoaiXe = kh.maloaixe, DiaChi = kh.diachi, SDT = kh.dienthoai, TenLoaiXe = pd.TenLoaiXe });
            return kh_loaixe.Cast<dynamic>().ToList();
        }

        public int Insert(KhachHangDTO kh)
        {
            return dal.Insert(kh.makh, kh.tenkh, kh.maloaixe, kh.diachi, kh.dienthoai);
        }

        public void KetXuatWord(string templatePath, string exportPath)
        {
            IList<KhachHangDTO> list = getAll();
            Dictionary<string, string> dictionaryData = new Dictionary<string, string>();
            System.IO.File.Copy(templatePath, exportPath, true);
            ExportDocx.CreateKhachHangTemplate(exportPath, dictionaryData, list);
        }

        public IList<KhachHangDTO> SearchLinq(string value)
        {
            return getAll().Where(x => string.IsNullOrEmpty(value) || x.tenkh.Contains(value) ||
                (x.makh.ToString() == value) ||
                (string.IsNullOrEmpty(value) || x.dienthoai.Contains(value)) ||
                (string.IsNullOrEmpty(value) || x.diachi.Contains(value))).ToList();
        }

        public int Update(KhachHangDTO kh)
        {
            if (checkKhachHang_ID(kh.makh) != 0)
                return dal.Update(kh.makh, kh.tenkh, kh.maloaixe, kh.diachi, kh.dienthoai);
            else return -1;
        }
    }
}
