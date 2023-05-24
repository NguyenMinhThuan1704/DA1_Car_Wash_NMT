using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class KhachHangDTO
    {
        protected int Makh;
        protected string Tenkh;
        protected int Maloaixe;
        protected string Diachi;
        protected string Dienthoai;
        
        public KhachHangDTO()
        {

        }
        public KhachHangDTO(KhachHangDTO kh)
        {
            this.Makh = kh.Makh;
            this.Tenkh = kh.Tenkh;
            this.Maloaixe = kh.Maloaixe;
            this.Diachi = kh.Diachi;
            this.Dienthoai = kh.Dienthoai;
        }
        public KhachHangDTO(int makh, string tenkh, int maloaixe, string diachi, string dienthoai)
        {
            this.Makh = makh;
            this.Tenkh = tenkh;
            this.Maloaixe = maloaixe;
            this.Diachi = diachi;
            this.Dienthoai = dienthoai;
        }
        public int makh
        {
            get { return Makh; }
            set { Makh = value; }
        }
        public string tenkh
        {
            get { return Tenkh; }
            set { Tenkh = value; }
        }
        public int maloaixe
        {
            get { return Maloaixe; }
            set { Maloaixe = value; }
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
    }
}
