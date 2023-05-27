using DataAccessLayer;
using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class DoanhThuBLL
    {
        private DoanhThuDAL dt;

        public DoanhThuBLL()
        {
            dt = new DoanhThuDAL();
        }

        public System.Data.DataTable GetHoaDonByDateRange(DateTime fromDate, DateTime toDate)
        {
            return dt.GetHoaDonByDateRange(fromDate, toDate);
        }
    }
}
