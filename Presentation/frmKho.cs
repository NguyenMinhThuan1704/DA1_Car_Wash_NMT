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
    public partial class frmKho : Form
    {
        IDonNhapKhoBLL dnk = new DonNhapKhoBLL();
        INCCBLL provider = new NCCBLL();
        INhanVIenBLL nv = new NhanVienBLL();
        public frmKho()
        {
            InitializeComponent();
        }
        private void frmKho_Load(object sender, EventArgs e)
        {
            var dnk_ncc = dnk.getAllJoin();
            dgvDNKho.AutoGenerateColumns = false;
            dgvDNKho.DataSource = dnk_ncc;
            cbNcc_DNK.DataSource = provider.getAll();
            SetDisplayCbb(cbNcc_DNK, "MaNCC", "TenNCC");
            cbNhanVien_DNK.DataSource = nv.getAll();
            SetDisplayCbb(cbNhanVien_DNK, "MaNV", "TenNV");
        }
        private void SetDisplayCbb(System.Windows.Forms.ComboBox cbb, string value, string name)
        {
            cbb.ValueMember = value;
            cbb.DisplayMember = name;
            cbb.Enabled = true;
        }

        #region DonNhapKho
        private void ResetFormDNK()
        {
            txtMaDNK_DNK.Text = "";
            cbNhanVien_DNK.DataSource = nv.getAll();
            cbNhanVien_DNK.DataSource = nv.getAll();
            txtSoluong_DNK.Text = "";
        }
        public void LoadDataDNK()
        {
            var dnk_ncc = dnk.getAllJoin();
            dgvDNKho.DataSource = dnk_ncc;
            cbNhanVien_DNK.DataSource = nv.getAll();
            cbNcc_DNK.DataSource = provider.getAll();
        }
        private void btnAdd_DNK_Click(object sender, EventArgs e)
        {
            if (txtMaDNK_DNK.Text == "" || txtSoluong_DNK.Text == "")
                MessageBox.Show("Dữ liệu chưa đủ, xin hãy nhập lại!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    int val = dnk.Insert(new DonNhapKhoDTO(int.Parse(txtMaDNK_DNK.Text), ((int)cbNhanVien_DNK.SelectedValue), ((int)cbNcc_DNK.SelectedValue), dtDate_DNK.Value, int.Parse(txtSoluong_DNK.Text)));
                    if (val == -1)
                        MessageBox.Show("Thêm dữ liệu không thành công, hãy kiểm tra lại!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        MessageBox.Show("Đã thêm dữ liệu thành công!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnAdd_DNK.Text = "Thêm mới";
                    }
                    ResetFormDNK();
                    LoadDataDNK();
                }
                catch
                {
                    MessageBox.Show("Không thêm được dữ liệu, có thể do lỗi CSDL!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void btnUpdate_DNK_Click(object sender, EventArgs e)
        {
            DonNhapKhoDTO pro = new DonNhapKhoDTO();
            pro.Madnk = int.Parse(txtMaDNK_DNK.Text);
            pro.Manv = (int)cbNhanVien_DNK.SelectedValue;
            pro.Mancc = (int)cbNcc_DNK.SelectedValue;
            pro.Ngaynhap = dtDate_DNK.Value;
            pro.Tongsoluong = int.Parse(txtSoluong_DNK.Text);
            try
            {
                int val = dnk.Update(pro);
                LoadDataDNK();
                if (val == -1)
                    MessageBox.Show("Sửa dữ liệu không thành công, hãy kiểm tra lại!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    MessageBox.Show("Đã sửa dữ liệu thành công!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetFormDNK();
                }
            }
            catch
            {
                MessageBox.Show("Không sửa được dữ liệu, có thể do lỗi CSDL!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_DNK_Click(object sender, EventArgs e)
        {
            try
            {
                int val = dnk.Delete(int.Parse(txtMaDNK_DNK.Text));
                LoadDataDNK();
                if (val == -1)
                    MessageBox.Show("Xóa dữ liệu không thành công, hãy kiểm tra lại!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    MessageBox.Show("Đã xóa dữ liệu thành công!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetFormDNK();
                }
            }
            catch
            {
                MessageBox.Show("Không xóa được dữ liệu, có thể do lỗi CSDL!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnReset_DNK_Click(object sender, EventArgs e)
        {
            LoadDataDNK();
            ResetFormDNK();
        }
        private void dgvDNKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaDNK_DNK.Text = dgvDNKho[0, dgvDNKho.CurrentCell.RowIndex].Value.ToString();
            cbNhanVien_DNK.Text = dgvDNKho[1, dgvDNKho.CurrentCell.RowIndex].Value.ToString();
            cbNcc_DNK.Text = dgvDNKho[2, dgvDNKho.CurrentCell.RowIndex].Value.ToString();
            dtDate_DNK.Text = dgvDNKho[3, dgvDNKho.CurrentCell.RowIndex].Value.ToString();
            txtSoluong_DNK.Text = dgvDNKho[4, dgvDNKho.CurrentCell.RowIndex].Value.ToString();
        }
        private void btnSearch_DNK_Click(object sender, EventArgs e)
        {
            dgvDNKho.DataSource = dnk.SearchLinq(txtSearch_DNK.Text);
        }
        private void btnWord_DNK_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Microsoft Word | *.docx";
            saveFileDialog.Title = "Lưu thông tin lớp";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                try
                {
                    dnk.KetXuatWord(@"Template\DonNhapKho.docx", saveFileDialog.FileName);
                    MessageBox.Show("Kết xuất thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo lỗi");
                }
            }
        }


        #endregion DonNhapKho

        #region ChiTietDonNhapKho

        #endregion ChiTietDonNhapKho

    }
}
