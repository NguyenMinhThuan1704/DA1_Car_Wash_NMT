using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer.Interface;
using BusinessLogicLayer;
using Entities;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;

namespace Presentation
{
    public partial class frmNhanVien : Form
    {
        INhanVIenBLL NV = new NhanVienBLL();
        NhanVienDTO NVDTO = new NhanVienDTO();
        SqlDataReader dr;
        public frmNhanVien()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            dgvEmployer.DataSource = NV.getAll();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
            ResetForm();
        }

        private void ResetForm()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            //txtBd.Text = "";
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "" || txtName.Text == "" || txtPhone.Text == "" || txtAddress.Text == ""/* || txtBd.Text == ""*/)
                MessageBox.Show("Dữ liệu chưa đủ, xin hãy nhập lại!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    int val = NV.Insert(new NhanVienDTO(int.Parse(txtId.Text), txtName.Text, rdMale.Checked, txtAddress.Text, txtPhone.Text, dtBd.Value/*DateTime.Parse(txtBd.Text)*/));
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
            NhanVienDTO nv1 = new NhanVienDTO();
            nv1.manv = int.Parse(txtId.Text);
            nv1.tennv = txtName.Text;
            nv1.gioitinh = rdMale.Checked;
            nv1.diachi = txtAddress.Text;
            nv1.dienthoai = txtPhone.Text;
            nv1.ngaysinh = dtBd.Value;
            //nv1.ngaysinh = DateTime.Parse(txtBd.Text);

            try
            {
                int val = NV.Update(nv1);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int val = NV.Delete(int.Parse(txtId.Text));
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

        private void dgvEmployer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvEmployer[0, dgvEmployer.CurrentCell.RowIndex].Value.ToString();
            txtName.Text = dgvEmployer[1, dgvEmployer.CurrentCell.RowIndex].Value.ToString();
            string gender = dgvEmployer[2, dgvEmployer.CurrentCell.RowIndex].Value.ToString();
            if (gender == "True")
            {
                rdMale.Checked = true;
            }
            else if (gender == "False")
            {
                rdFemale.Checked = true;
            }
            txtAddress.Text = dgvEmployer[3, dgvEmployer.CurrentCell.RowIndex].Value.ToString();
            txtPhone.Text = dgvEmployer[4, dgvEmployer.CurrentCell.RowIndex].Value.ToString();
            dtBd.Text = dgvEmployer[5, dgvEmployer.CurrentCell.RowIndex].Value.ToString();
            //txtBd.Text = Utility.Tools.CatXauDate(dgvEmployer[5, dgvEmployer.CurrentCell.RowIndex].Value.ToString());
        }

        private void dgvEmployer_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvEmployer.Columns[e.ColumnIndex].Name == "clgioitinh")
            {
                bool gioiTinh = (bool)e.Value;
                if (gioiTinh == false)
                {
                    e.Value = "Nữ";
                }
                else if (gioiTinh == true)
                {
                    e.Value = "Nam";
                }
                e.FormattingApplied = true;

            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvEmployer.DataSource = NV.SearchLinq(txtSearch.Text);
        }
    }
}
