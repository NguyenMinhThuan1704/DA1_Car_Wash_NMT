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
    public partial class frmKhachHang : Form
    {
        IKhachHangBLL KH = new KhachHangBLL();
        ILoaiXeBLL loaixe = new LoaiXeBLL();
        public frmKhachHang()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            dgvCustomer.DataSource = KH.getAllJoin(loaixe);
        }
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            dgvCustomer.AutoGenerateColumns = false;
            LoadData();
            cbCarType.DataSource = loaixe.getAll();
            SetDisplayCbb(cbCarType, "MaLoaiXe", "TenLoaiXe");
        }
        private void SetDisplayCbb(System.Windows.Forms.ComboBox cbb, string value, string name)
        {
            cbb.ValueMember = value;
            cbb.DisplayMember = name;
            cbb.Enabled = true;
        }
        private void ResetForm()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            LoadData();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "" || txtName.Text == "" || txtPhone.Text == "" || txtAddress.Text == "" || txtPhone.Text == "")
                MessageBox.Show("Dữ liệu chưa đủ, xin hãy nhập lại!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    int val = KH.Insert(new KhachHangDTO(int.Parse(txtId.Text), txtName.Text, ((int)cbCarType.SelectedValue), txtAddress.Text, txtPhone.Text));
                    if (val == -1)
                        MessageBox.Show("Thêm dữ liệu không thành công, hãy kiểm tra lại!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        MessageBox.Show("Đã thêm dữ liệu thành công!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnAdd.Text = "Thêm mới";
                    }
                    ResetForm();
                }
                catch
                {
                    MessageBox.Show("Không thêm được dữ liệu, có thể do lỗi CSDL!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            KhachHangDTO kh = new KhachHangDTO();
            kh.makh = int.Parse(txtId.Text);
            kh.tenkh = txtName.Text;
            kh.maloaixe = (int)cbCarType.SelectedValue;
            kh.diachi = txtAddress.Text;
            kh.dienthoai = txtPhone.Text;
            try
            {
                int val = KH.Update(kh);
                LoadData();
                if (val == -1)
                    MessageBox.Show("Sửa dữ liệu không thành công, hãy kiểm tra lại!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    MessageBox.Show("Đã sửa dữ liệu thành công!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetForm();
                }
            }
            catch
            {
                MessageBox.Show("Không sửa được dữ liệu, có thể do lỗi CSDL!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvCustomer[0, dgvCustomer.CurrentCell.RowIndex].Value.ToString();
            txtName.Text = dgvCustomer[1, dgvCustomer.CurrentCell.RowIndex].Value.ToString();
            cbCarType.Text = dgvCustomer[2, dgvCustomer.CurrentCell.RowIndex].Value.ToString();
            txtAddress.Text = dgvCustomer[3, dgvCustomer.CurrentCell.RowIndex].Value.ToString();
            txtPhone.Text = dgvCustomer[4, dgvCustomer.CurrentCell.RowIndex].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int val = KH.Delete(int.Parse(txtId.Text));
                LoadData();
                if (val == -1)
                    MessageBox.Show("Xóa dữ liệu không thành công, hãy kiểm tra lại!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    MessageBox.Show("Đã xóa dữ liệu thành công!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetForm();
                }
            }
            catch
            {
                MessageBox.Show("Không xóa được dữ liệu, có thể do lỗi CSDL!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvCustomer.DataSource = KH.SearchLinq(txtSearch.Text);
        }
    }
}
