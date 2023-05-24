using BusinessLogicLayer.Interface;
using DataAccessLayer;
using DataAccessLayer.Interface;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class LoaiXeBLL : ILoaiXeBLL
    {
        private readonly ILoaiXeDAL dal = new LoaiXeDAL();
        public IList<LoaiXeDTO> getAll()
        {
            System.Data.DataTable table = dal.getAll();
            IList<LoaiXeDTO> list = new List<LoaiXeDTO>();
            foreach (DataRow row in table.Rows)
            {
                LoaiXeDTO cls = new LoaiXeDTO();
                cls.MaLoaiXe = row.Field<int>(0);
                cls.TenLoaiXe = row.Field<string>(1);
                list.Add(cls);
            }
            return list;
        }
    }
}
