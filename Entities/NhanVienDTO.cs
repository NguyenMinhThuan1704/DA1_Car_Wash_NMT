using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class NhanVienDTO
    {
        protected int Manv;
        protected string Tennv;
        protected bool Gioitinh;
        protected string Diachi;
        protected string Dienthoai;
        protected DateTime Ngaysinh;

        public NhanVienDTO()
        {

        }
        public NhanVienDTO(NhanVienDTO nv)
        {
            this.Manv = nv.Manv;
            this.Tennv = nv.Tennv;
            this.Gioitinh = nv.Gioitinh;
            this.Diachi = nv.Diachi;
            this.Dienthoai = nv.Dienthoai;
            this.Ngaysinh = nv.Ngaysinh;
        }
        public NhanVienDTO(int manv, string tennv, bool gioitinh, string diachi, string dienthoai, DateTime ngaysinh)
        {
            this.Manv = manv;
            this.Tennv = tennv;
            this.Gioitinh = gioitinh;
            this.Diachi = diachi;
            this.Dienthoai = dienthoai;
            this.Ngaysinh = ngaysinh;
        }

        public int manv
        {
            get { return Manv; }
            set { Manv = value; }
        }
        public string tennv
        {
            get { return Tennv; }
            set { Tennv = value; }
        }
        public bool gioitinh
        {
            get { return Gioitinh; }
            set { Gioitinh = value; }
        }
        public string diachi
        {
            get { return Diachi; }
            set { Diachi = value; }
        }
        public string dienthoai
        {
            get { return Dienthoai; }
            set { Dienthoai = value; }
        }
        public DateTime ngaysinh
        {
            get { return Ngaysinh; }
            set { Ngaysinh = value; }
        }
    }
}
