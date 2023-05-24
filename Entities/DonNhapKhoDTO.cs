using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entities
{
    public class DonNhapKhoDTO
    {
        protected int madnk;
        protected int manv;
        protected int mancc;
        protected DateTime ngaynhap;
        protected int tongsoluong;

        public DonNhapKhoDTO()
        {
        }
        //public DonNhapKhoDTO(DonNhapKhoDTO pro)
        //{
        //    this.madnk = pro.madnk;
        //    this.manv = pro.manv;
        //    this.mancc = pro.mancc;
        //    this.ngaynhap = pro.ngaynhap;
        //    this.tongsoluong = pro.tongsoluong;
        //}
        public DonNhapKhoDTO(int madnk, int manv, int mancc, DateTime ngaynhap, int tongsoluong)
        {
            this.madnk = madnk;
            this.manv = manv;
            this.mancc = mancc;
            this.ngaynhap = ngaynhap;
            this.tongsoluong = tongsoluong;
        }
        public int Madnk
        {
            get { return this.madnk; }
            set { this.madnk = value; }
        }
        public int Manv
        {
            get { return this.manv; }
            set { this.manv = value; }
        }
        public int Mancc
        {
            get { return this.mancc; }
            set { this.mancc = value; }
        }
        public DateTime Ngaynhap
        {
            get { return ngaynhap; }
            set
            {
                ngaynhap = value;
            }
        }
        public int Tongsoluong
        {
            get { return tongsoluong; }
            set { tongsoluong = value; }
        }
    }
}
