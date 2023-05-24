using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DichVuDTO
    {
        protected int Madv;
        protected string Tendv;
        protected int Maloaidv;
        protected int Giadv;
        protected int Soluong;

        public DichVuDTO()
        {

        }
        public DichVuDTO(DichVuDTO dv)
        {
            this.Madv = dv.Madv;
            this.Tendv = dv.Tendv;
            this.Maloaidv = dv.Maloaidv;
            this.Giadv = dv.Giadv;
            this.Soluong = dv.Soluong;
        }
        public DichVuDTO(int madv, string tendv, int maloaidv, int giadv, int soluong)
        {
            this.Madv = madv;
            this.Tendv = tendv;
            this.Maloaidv = maloaidv;
            this.Giadv = giadv;
            this.Soluong = soluong;
        }
        public int madv
        {
            get { return Madv; }
            set { Madv = value; }
        }

        public string tendv
        {
            get { return Tendv; }
            set { Tendv = value; }
        }
        public int maloaidv
        {
            get { return Maloaidv; }
            set { Maloaidv = value; }
        }
        public int giadv
        {
            get { return Giadv; }
            set { Giadv = value; }
        }
        public int soluong
        {
            get { return Soluong; }
            set { Soluong = value; }
        }
    }
}
