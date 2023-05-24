using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class LoaiXeDTO
    {
        protected int maLoaixe;
        protected string tenLoaixe;
        public int MaLoaiXe
        {
            get { return maLoaixe; }
            set { maLoaixe = value; }
        }
        public string TenLoaiXe
        {
            get { return tenLoaixe; }
            set { tenLoaixe = value; }
        }
    }
}
