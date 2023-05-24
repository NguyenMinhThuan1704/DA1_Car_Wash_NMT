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
    public partial class frmDichVu : Form
    {
        IDIchVuBLL DV = new DichVuBLL();
        ILoaiDichVuBLL loaidv = new LoaiDichVuBLL();
        public frmDichVu()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            dgvService.DataSource = DV.getAllJoin(loaidv);
        }

        private void ResetForm()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtPrice.Text = "";
            txtSoluong.Text = "";
        }
        private void frmDichVu_Load(object sender, EventArgs e)
        {
            dgvService.AutoGenerateColumns = false;
            LoadData();
            cbLoaidv.DataSource = loaidv.getAll();
            SetDisplayCbb(cbLoaidv, "MaLoaiDV", "TenLoaiDV");
            ResetForm();
        }
        private void SetDisplayCbb(System.Windows.Forms.ComboBox cbb, string value, string name)
        {
            cbb.ValueMember = value;
            cbb.DisplayMember = name;
            cbb.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "" || txtName.Text == "" || txtPrice.Text == "" || txtSoluong.Text == "")
                MessageBox.Show("Dữ liệu chưa đủ, xin hãy nhập lại!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    int val = DV.Insert(new DichVuDTO(int.Parse(txtId.Text), txtName.Text, ((int)cbLoaidv.SelectedValue), int.Parse(txtPrice.Text), int.Parse(txtSoluong.Text)));
                    if (val == -1)
                        MessageBox.Show("Thêm dữ liệu không thành công, hãy kiểm tra lại!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        MessageBox.Show("Đã thêm dữ liệu thành công!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnAdd.Text = "Thêm mới";
                    }
                    ResetForm();
                    LoadData();
                }
                catch
                {
                    MessageBox.Show("Không thêm được dữ liệu, có thể do lỗi CSDL!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DichVuDTO dv = new DichVuDTO();
            dv.madv = int.Parse(txtId.Text);
            dv.tendv = txtName.Text;
            dv.maloaidv = (int)cbLoaidv.SelectedValue;
            dv.giadv = int.Parse(txtPrice.Text);
            dv.soluong = int.Parse(txtSoluong.Text);

            try
            {
                int val = DV.Update(dv);
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
                int val = DV.Delete(int.Parse(txtId.Text));
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
            LoadData();
        }

        private void dgvService_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvService[0, dgvService.CurrentCell.RowIndex].Value.ToString();
            txtName.Text = dgvService[1, dgvService.CurrentCell.RowIndex].Value.ToString();
            cbLoaidv.Text = dgvService[2, dgvService.CurrentCell.RowIndex].Value.ToString();
            txtPrice.Text = dgvService[3, dgvService.CurrentCell.RowIndex].Value.ToString();
            txtSoluong.Text = dgvService[4, dgvService.CurrentCell.RowIndex].Value.ToString();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvService.DataSource = DV.SearchLinq(txtSearch.Text);
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Microsoft Word | *.docx";
            saveFileDialog.Title = "Lưu thông tin dịch vụ";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                try
                {
                    DV.KetXuatWord(@"Template\DichVu.docx", saveFileDialog.FileName);
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
