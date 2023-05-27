using BusinessLogicLayer;
using BusinessLogicLayer.Interface;
using Entities;
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
    public partial class frmHoaDon : Form
    {
        IDIchVuBLL product = new DichVuBLL();
        IChiTietHoaDonBLL chitiethd = new ChiTietHoaDonBLL();
        IHoaDonBLL hoadon = new HoaDonBLL();
        public void InsertChiTietHoaDon()
        {
            foreach (DataGridViewRow row in dgvhoadon.Rows)
            {
                int soluong = int.Parse(row.Cells[3].Value.ToString());
                int madv = int.Parse(row.Cells[0].Value.ToString());
                int priceProduct = int.Parse(row.Cells[2].Value.ToString());
                int mahoadon = hoadon.GetLastHD().Mahd;
                chitiethd.Insert(new ChiTietHoaDonDTO(mahoadon, madv, priceProduct, soluong));
            }
        }
        public void ResetDgv()
        {
            dgvhoadon.Rows.Clear();
            dgvhoadon.DataSource = null;
            lbPrice.Text = "0";
        }
        public frmHoaDon()
        {
            InitializeComponent();
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            dgvDichVu.AutoGenerateColumns = false;
            dgvDichVu.DataSource = product.getAll();
            btnPay.Enabled = false;
            btnDestroy.Enabled = false;
        }

        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowIndex = e.RowIndex;
            if (e.RowIndex >= 0 && e.RowIndex < dgvDichVu.RowCount)
            {
                if (selectedRowIndex >= 0)
                {
                    DataGridViewRow selectedRow = dgvDichVu.Rows[selectedRowIndex];
                    int soLuong = product.getAll()
                        .Where(t => t.madv == int.Parse(selectedRow.Cells["clmadv"].Value.ToString()))
                        .Select(t => t.soluong)
                        .FirstOrDefault();
                    if (soLuong == 0)
                    {
                        MessageBox.Show("Số lượng dịch vụ không đủ để cung cấp");
                    }
                    else
                    {
                        DataGridViewRow newRow = (DataGridViewRow)selectedRow.Clone();
                        for (int i = 0; i < selectedRow.Cells.Count; i++)
                        {
                            newRow.Cells[i].Value = selectedRow.Cells[i].Value;
                        }
                        // Thêm hàng mới vào DataGridView mới
                        AddRowIfNotExist(dgvhoadon, newRow);
                        foreach (DataGridViewRow row in dgvhoadon.Rows)
                        {
                            DataGridViewButtonCell quantityCell = new DataGridViewButtonCell();
                            quantityCell.Value = "+";
                            DataGridViewButtonCell quantityCell2 = new DataGridViewButtonCell();
                            quantityCell2.Value = "-";
                            row.Cells["btnIncrease"] = quantityCell;
                            row.Cells["btnDecrement"] = quantityCell2;
                            row.Cells["clsl"].Value = 1;
                        }
                        CheckSateBtn();
                        CaculatorPrice();
                    }
                }
            }
        }
        private bool IsRowExist(DataGridView dataGridView, DataGridViewRow newRow)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                bool isExist = true;

                for (int i = 0; i < 2; i++)
                {
                    // So sánh giá trị của ô trong hai dòng
                    if (row.Cells[i].Value != null && !row.Cells[i].Value.Equals(newRow.Cells[i].Value))
                    {
                        isExist = false;
                        break;
                    }
                }
                if (isExist)
                {
                    // Dòng đã tồn tại trong DataGridView
                    return true;
                }
            }
            // Dòng chưa tồn tại trong DataGridView
            return false;
        }
        private void AddRowIfNotExist(DataGridView dataGridView, DataGridViewRow newRow)
        {
            if (!IsRowExist(dataGridView, newRow))
            {
                dataGridView.Rows.Add(newRow);

            }
        }

        private void dgvhoadon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvhoadon.Rows[e.RowIndex];
            int currentValue = Convert.ToInt32(row.Cells["clsl"].Value);
            int madv = int.Parse(row.Cells["clma"].Value.ToString());
            int soLuong = product.GetSoluong(madv);
            if (dgvhoadon.Columns[e.ColumnIndex] is DataGridViewButtonColumn && dgvhoadon.Columns[e.ColumnIndex].Name == "btnIncrease")
            {
                currentValue++;
            }
            else if (dgvhoadon.Columns[e.ColumnIndex] is DataGridViewButtonColumn && dgvhoadon.Columns[e.ColumnIndex].Name == "btnDecrement")
            {
                if (currentValue > 0)
                {
                    currentValue--;
                }
            }
            row.Cells["clsl"].Value = currentValue.ToString();
            CaculatorPrice();
            if (currentValue == 0)
            {
                int selectedIndex = dgvhoadon.CurrentCell.RowIndex;
                dgvhoadon.Rows.RemoveAt(selectedIndex);
                CheckSateBtn();
            }
            if (soLuong == 0 || soLuong < currentValue)
            {
                MessageBox.Show("Số lượng dịch vụ không đủ để cung cấp");
                btnPay.Enabled = false;
            }
        }

        private void btnDestroy_Click(object sender, EventArgs e)
        {
            dgvhoadon.Rows.Clear();
            dgvhoadon.DataSource = null;
            lbPrice.Text = "0";
        }
        public void CheckSateBtn()
        {
            if (dgvhoadon.RowCount > 0)
            {
                btnPay.Enabled = true;
                btnDestroy.Enabled = true;
            }
            else
            {
                btnPay.Enabled = false;
                btnDestroy.Enabled = false;
            }
        }
        public void CaculatorPrice()
        {
            float sumPrice = 0;
            foreach (DataGridViewRow row in dgvhoadon.Rows)
            {
                string soluong = row.Cells["clsl"].Value?.ToString();
                string gia = row.Cells["cldongia"].Value?.ToString();
                sumPrice += float.Parse(soluong) * float.Parse(gia);
            }
            lbPrice.Text = sumPrice.ToString("#,##0 VND");
            Bien.tonghoadon = sumPrice;
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            frmImportHoaDon frm = new frmImportHoaDon(this);
            frm.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string value = txtSearch.Text;
            dgvDichVu.DataSource = product.SearchLinq(value);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dgvDichVu.AutoGenerateColumns = false;
            dgvDichVu.DataSource = product.getAll();
        }
    }
}
