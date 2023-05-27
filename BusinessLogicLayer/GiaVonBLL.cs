using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class GiaVonBLL
    {
        private GiaVonDAL gv;

        public GiaVonBLL()
        {
            gv = new GiaVonDAL();
        }

        public System.Data.DataTable GetNhapKhoByDateRange(DateTime startDate, DateTime endDate)
        {
            return gv.GetNhapKhoByDateRange(startDate, endDate);
        }
    }
}
