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
    public partial class frmNhaCungCap : Form
    {
        INCCBLL provider = new NCCBLL();
        public frmNhaCungCap()
        {
            InitializeComponent();
        }
        private void ResetForm()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
        }
        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            dgvNCC.DataSource = provider.getAll();
            LoadData();
            ResetForm();
        }
        public void LoadData()
        {
            dgvNCC.DataSource = provider.getAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "" || txtName.Text == "" || txtAddress.Text == "" || txtPhone.Text == "")
                MessageBox.Show("Dữ liệu chưa đủ, xin hãy nhập lại!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    int val = provider.Insert(new NCCDTO(int.Parse(txtId.Text), txtName.Text, txtAddress.Text, txtPhone.Text));
                    LoadData();
                    if (val == -1)
                        MessageBox.Show("Thêm dữ liệu không thành công, hãy kiểm tra lại!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        MessageBox.Show("Đã thêm dữ liệu thành công!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnAdd.Text = "Thêm mới";
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
            NCCDTO cl = new NCCDTO();
            cl.Mancc = int.Parse(txtId.Text);
            cl.Tenncc = txtName.Text;
            cl.Diachi = txtAddress.Text;
            cl.Dienthoai = txtPhone.Text;
            try
            {
                int val = provider.Update(cl);
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
                int val = provider.Delete(int.Parse(txtId.Text));
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
            LoadData();
            ResetForm();
        }

        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvNCC[0, dgvNCC.CurrentCell.RowIndex].Value.ToString();
            txtName.Text = dgvNCC[1, dgvNCC.CurrentCell.RowIndex].Value.ToString();
            txtAddress.Text = dgvNCC[2, dgvNCC.CurrentCell.RowIndex].Value.ToString();
            txtPhone.Text = dgvNCC[3, dgvNCC.CurrentCell.RowIndex].Value.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvNCC.DataSource = provider.SearchLinq(txtSearch.Text);
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Microsoft Word | *.docx";
            saveFileDialog.Title = "Lưu thông tin nhà cung cấp";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                try
                {
                    provider.KetXuatWord(@"Template\NCC.docx", saveFileDialog.FileName);
                    MessageBox.Show("Kết xuất thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo lỗi");
                }
            }
        }
    }
}
