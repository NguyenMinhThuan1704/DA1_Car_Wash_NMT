using BusinessLogicLayer.Interface;
using DataAccessLayer.Interface;
using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class LoaiDichVuBLL : ILoaiDichVuBLL
    {
        private readonly ILoaiDichVuDAL dal = new LoaiDichVuDAL();
        public IList<LoaiDichVuDTO> getAll()
        {
            System.Data.DataTable table = dal.getAll();
            IList<LoaiDichVuDTO> list = new List<LoaiDichVuDTO>();
            foreach (DataRow row in table.Rows)
            {
                LoaiDichVuDTO cls = new LoaiDichVuDTO();
                cls.MaLoaiDV = row.Field<int>(0);
                cls.TenLoaiDV = row.Field<string>(1);
                list.Add(cls);
            }
            return list;
        }
    }
}
