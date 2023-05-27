using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class frmBaoCao : Form
    {
        private GiaVonBLL gvbll;
        private DoanhThuBLL dtbll;

        public frmBaoCao()
        {
            InitializeComponent();
            gvbll = new GiaVonBLL();
            dgvGiaVon.DataSourceChanged += dgvGiaVon_DataSourceChanged;
            dtbll = new DoanhThuBLL();
            dgvDoanhThu.DataSourceChanged += dgvGiaVon_DataSourceChanged;
        }

        #region GiaVon
        private void btnSearch_GV_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date;

            DataTable dataTable = gvbll.GetNhapKhoByDateRange(startDate, endDate);
            dgvGiaVon.DataSource = dataTable;
        }
        private decimal CalculateTotalAmount_GV()
        {
            decimal totalAmount = 0;

            foreach (DataGridViewRow row in dgvGiaVon.Rows)
            {
                decimal amount = Convert.ToDecimal(row.Cells["TongTien"].Value);
                totalAmount += amount;
            }

            return totalAmount;
        }

        private void dgvGiaVon_DataSourceChanged(object sender, EventArgs e)
        {
            decimal totalAmount = CalculateTotalAmount_GV();
            lblTongTien_GV.Text = totalAmount.ToString();
        }
        #endregion GiaVon

        #region DoanhThu
        private void btnSearch_DT_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dtpFromDate.Value.Date;
            DateTime toDate = dtpToDate.Value.Date;

            DataTable dataTable = dtbll.GetHoaDonByDateRange(fromDate, toDate);
            dgvDoanhThu.DataSource = dataTable;
        }
        private decimal CalculateTotalAmount_DT()
        {
            decimal totalAmount = 0;

            foreach (DataGridViewRow row in dgvDoanhThu.Rows)
            {
                decimal amount = Convert.ToDecimal(row.Cells["TongTien1"].Value);
                totalAmount += amount;
            }

            return totalAmount;
        }
        private void dgvDoanhThu_DataSourceChanged(object sender, EventArgs e)
        {
            decimal totalAmount = CalculateTotalAmount_DT();
            lblTongTien_DT.Text = totalAmount.ToString();
        }

        #endregion DoanhThu

    }
}
