using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class HoaDonDTO
    {
        private int mahd;
        private int manv;
        private int makh;
        private DateTime ngaylap;
        private float tongtien;

        public int Mahd { get => mahd; set => mahd = value; }
        public DateTime Ngaylap { get => ngaylap; set => ngaylap = value; }
        public float Tongtien { get => tongtien; set => tongtien = value; }
        public int Makh { get => makh; set => makh = value; }
        public int Manv { get => manv; set => manv = value; }

        public HoaDonDTO()
        {

        }
        public HoaDonDTO(HoaDonDTO cls)
        {
            this.mahd = cls.mahd;
            this.ngaylap = cls.ngaylap;
            this.tongtien = cls.tongtien;
            this.makh = cls.makh;
            this.manv = cls.manv;
        }
        public HoaDonDTO(int mahd, int manv, int makh, DateTime ngaylap, float tongtien)
        {
            this.mahd = mahd;
            this.manv = manv;
            this.makh = makh;
            this.ngaylap = ngaylap;
            this.tongtien = tongtien;
        }
        public HoaDonDTO(int manv, int makh, DateTime ngaylap, float tongtien)
        {
            this.manv = manv;
            this.makh = makh;
            this.ngaylap = ngaylap;
            this.tongtien = tongtien;
        }
    }
}
