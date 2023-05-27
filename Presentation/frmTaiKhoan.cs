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
using System.Xml.Linq;

namespace Presentation
{
    public partial class frmTaiKhoan : Form
    {
        INhanVIenBLL nv = new NhanVienBLL();
        ITaiKhoanBLL tk = new TaiKhoanBLL();
        public frmTaiKhoan()
        {
            InitializeComponent();
        }
        private void SetDisplayCbb(System.Windows.Forms.ComboBox cbb, string value, string name)
        {
            cbb.ValueMember = value;
            cbb.DisplayMember = name;
            cbb.Enabled = true;
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            dgvTaiKhoan.AutoGenerateColumns = false;
            LoadData();
            cbManv.DataSource = nv.getAll();
            SetDisplayCbb(cbManv, "MaNV", "TenNV");
        }
        private void ResetForm()
        {
            txtMatk.Text = "";
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            LoadData();
        }
        public void LoadData()
        {
            dgvTaiKhoan.DataSource = tk.getAllJoin();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string password = txtMatKhau.Text;
            if (txtTaiKhoan.Text == "" || txtMatKhau.Text == "")
                MessageBox.Show("Dữ liệu chưa đủ, xin hãy nhập lại!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    int val = tk.Insert(new TaiKhoanDTO(((int)cbManv.SelectedValue), int.Parse(txtMatk.Text), txtTaiKhoan.Text, txtMatKhau.Text));
                    LoadData();
                    if (val == -1)
                        MessageBox.Show("Thêm dữ liệu không thành công, hãy kiểm tra lại!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        MessageBox.Show("Đã thêm dữ liệu thành công!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnAdd.Text = "Thêm mới";
                        ResetForm();
                    }
                }
                catch
                {
                    MessageBox.Show("Không thêm được dữ liệu, có thể do lỗi CSDL!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            TaiKhoanDTO cls = new TaiKhoanDTO();
            cls.Manhanvien = (int)cbManv.SelectedValue;
            cls.Matk = int.Parse(txtMatk.Text);
            cls.Taikhoan = txtTaiKhoan.Text;
            cls.Matkhau = txtMatKhau.Text;
            try
            {
                int val = tk.Update(cls);
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
                int val = tk.Delete(int.Parse(txtMatk.Text));
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

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbManv.Text = dgvTaiKhoan[0, dgvTaiKhoan.CurrentCell.RowIndex].Value.ToString();
            txtMatk.Text = dgvTaiKhoan[1, dgvTaiKhoan.CurrentCell.RowIndex].Value.ToString();
            txtTaiKhoan.Text = dgvTaiKhoan[2, dgvTaiKhoan.CurrentCell.RowIndex].Value.ToString();
            txtMatKhau.Text = dgvTaiKhoan[3, dgvTaiKhoan.CurrentCell.RowIndex].Value.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvTaiKhoan.DataSource = tk.SearchLinq(txtSearch.Text);
        }
    }
}
