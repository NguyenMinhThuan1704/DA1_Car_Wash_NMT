using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class LoaiDichVuDTO
    {
        protected int maloaidv;
        protected string tenloaidv;
        public int MaLoaiDV
        {
            get { return maloaidv; }
            set { maloaidv = value; }
        }
        public string TenLoaiDV
        {
            get { return tenloaidv; }
            set { tenloaidv = value; }
        }
    }
}
