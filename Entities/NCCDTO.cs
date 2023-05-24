using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class NCCDTO
    {
        private int mancc;
        protected string tenncc;
        protected string diachi;
        protected string dienthoai;

        public int Mancc { get => mancc; set => mancc = value; }
        public string Tenncc { get => tenncc; set => tenncc = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Dienthoai { get => dienthoai; set => dienthoai = value; }

        public NCCDTO()
        {

        }
        public NCCDTO(string tenncc, string diachi, string dienthoai)
        {
            this.tenncc = tenncc;
            this.diachi = diachi;
            this.dienthoai = dienthoai;
        }
        public NCCDTO(NCCDTO x)
        {
            this.tenncc = x.tenncc;
            this.diachi = x.diachi;
            this.dienthoai = x.dienthoai;
        }
        public NCCDTO(int mancc, string tenncc, string diachi, string dienthoai)
        {
            this.mancc = mancc;
            this.tenncc = tenncc;
            this.diachi = diachi;
            this.dienthoai = dienthoai;
        }
    }
}
