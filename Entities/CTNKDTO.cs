using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CTNKDTO
    {
        protected int mactnk;
        protected int madnk;
        protected int madv;
        protected int gianhap;
        protected int soluongnhap;

        public int Mactnk { get => mactnk; set => mactnk = value; }
        public int Madnk { get => madnk; set => madnk = value; }
        public int Madv { get => madv; set => madv = value; }
        public int Gianhap { get => gianhap; set => gianhap = value; }
        public int Soluongnhap { get => soluongnhap; set => soluongnhap = value; }

        public CTNKDTO()
        {

        }
        public CTNKDTO(CTNKDTO cls)
        {
            this.mactnk = cls.mactnk;
            this.madnk = cls.madnk;
            this.madv = cls.madv;
            this.gianhap = cls.gianhap;
            this.soluongnhap = cls.soluongnhap;
        }
        public CTNKDTO(int mactnk, int madnk, int madv, int gianhap, int soluongnhap)
        {
            this.mactnk = mactnk;
            this.madnk = madnk;
            this.madv = madv;
            this.gianhap = gianhap;
            this.soluongnhap = soluongnhap;
        }
    }
}
