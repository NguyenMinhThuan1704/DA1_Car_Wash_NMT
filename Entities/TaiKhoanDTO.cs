using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TaiKhoanDTO
    {
        private int manhanvien;
        private int matk;
        private string taikhoan;
        private string matkhau;

        public int Matk { get => matk; set => matk = value; }
        public string Taikhoan { get => taikhoan; set => taikhoan = value; }
        public string Matkhau { get => matkhau; set => matkhau = value; }
        public int Manhanvien { get => manhanvien; set => manhanvien = value; }

        public TaiKhoanDTO()
        {
        }
        public TaiKhoanDTO(TaiKhoanDTO cls)
        {
            this.Matk = cls.Matk;
            this.Taikhoan = cls.Taikhoan;
            this.Matkhau = cls.Matkhau;
            this.Manhanvien = cls.Manhanvien;
        }
        public TaiKhoanDTO(int manhanvien, int matk, string taikhoan, string matkhau)
        {
            this.Matk = matk;
            this.Taikhoan = taikhoan;
            this.Matkhau = matkhau;
            this.Manhanvien = manhanvien;
        }
    }
}

