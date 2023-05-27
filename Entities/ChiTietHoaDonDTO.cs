using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ChiTietHoaDonDTO
    {
        private int macthd;
        private int mahd;
        private int madv;
        private float giadv;
        private int solansd;
        private float mucgiamgia;

        public int Macthd { get => macthd; set => macthd = value; }
        public int Mahd { get => mahd; set => mahd = value; }
        public float Giadv { get => giadv; set => giadv = value; }
        public int Madv { get => madv; set => madv = value; }
        public int Solansd { get => solansd; set => solansd = value; }
        public float Mucgiangia { get => mucgiamgia; set => mucgiamgia = value; }
        public ChiTietHoaDonDTO()
        {
        }
        public ChiTietHoaDonDTO(ChiTietHoaDonDTO cls)
        {
            this.Macthd = cls.Macthd;
            this.Mahd = cls.Mahd;
            this.Madv = cls.Madv;
            this.Giadv = cls.Giadv;
            this.Solansd = cls.Solansd;
            this.Mucgiangia = cls.Mucgiangia;
        }
        public ChiTietHoaDonDTO(int macthd, int mahd, int madv, float giadv, int solansd)
        {
            this.Macthd = macthd;
            this.Mahd = mahd;
            this.Madv = madv;
            this.Giadv = giadv;
            this.Solansd = solansd;
            this.Mucgiangia = mucgiamgia;
        }
        public ChiTietHoaDonDTO(int mahd, int madv, float giadv, int solansd)
        {
            this.Mahd = mahd;
            this.Madv = madv;
            this.Giadv = giadv;
            this.Solansd = solansd;
        }
    }
}
