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

        ICTNKBLL ctnk = new CTNKBLL();
        IDIchVuBLL dv = new DichVuBLL();
        public frmKho()
        {
            InitializeComponent();
        }
        private void frmKho_Load(object sender, EventArgs e)
        {
            //DonNhapKho
            var dnk_ncc = dnk.getAllJoin();
            dgvDNKho.AutoGenerateColumns = false;
            dgvDNKho.DataSource = dnk_ncc;
            cbNcc_DNK.DataSource = provider.getAll();
            SetDisplayCbb(cbNcc_DNK, "MaNCC", "TenNCC");
            cbNhanVien_DNK.DataSource = nv.getAll();
            SetDisplayCbb(cbNhanVien_DNK, "MaNV", "TenNV");

            //CTDNK
            dgvCTDNKho.AutoGenerateColumns = false;
            LoadDataCTNK();
            cbDichVu_CTDNK.DataSource = dv.getAll();
            SetDisplayCbb(cbDichVu_CTDNK, "MaDV", "TenDV");
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
            LoadDataDNK();
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
            saveFileDialog.Title = "Lưu thông tin đơn nhập kho";
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
        public void LoadDataCTNK()
        {
            dgvCTDNKho.DataSource = ctnk.getAllJoin();
        }

        private void ResetFormCTNK()
        {
            txtMaDNK_CTDNK.Text = "";
            txtGiaNhap_CTDNK.Text = "";
            txtSoLuongNhap_CTDNK.Text = "";
            LoadDataCTNK();
        }
        private void btnAdd_CTDNK_Click(object sender, EventArgs e)
        {
            if (txtMaDNK_CTDNK.Text == "" || txtGiaNhap_CTDNK.Text == "" || txtSoLuongNhap_CTDNK.Text == "")
                MessageBox.Show("Dữ liệu chưa đủ, xin hãy nhập lại!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    int val = ctnk.Insert(new CTNKDTO(int.Parse(txtMaCTNK_CTDNK.Text), int.Parse(txtMaDNK_CTDNK.Text), ((int)cbDichVu_CTDNK.SelectedValue), int.Parse(txtGiaNhap_CTDNK.Text), int.Parse(txtSoLuongNhap_CTDNK.Text)));
                    if (val == -1)
                        MessageBox.Show("Thêm dữ liệu không thành công, hãy kiểm tra lại!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        MessageBox.Show("Đã thêm dữ liệu thành công!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnAdd_CTDNK.Text = "Thêm mới";
                    }
                    ResetFormCTNK();
                }
                catch
                {
                    MessageBox.Show("Không thêm được dữ liệu, có thể do lỗi CSDL!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnUpdate_CTDNK_Click(object sender, EventArgs e)
        {
            CTNKDTO ctdnk = new CTNKDTO();
            ctdnk.Mactnk = int.Parse(txtMaCTNK_CTDNK.Text);
            ctdnk.Madnk = int.Parse(txtMaDNK_CTDNK.Text);
            ctdnk.Madv = (int)cbDichVu_CTDNK.SelectedValue;
            ctdnk.Gianhap = int.Parse(txtGiaNhap_CTDNK.Text);
            ctdnk.Soluongnhap = int.Parse(txtSoLuongNhap_CTDNK.Text);
            try
            {
                int val = ctnk.Update(ctdnk);
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

        private void btnDelete_CTDNK_Click(object sender, EventArgs e)
        {
            try
            {
                int val = ctnk.Delete(int.Parse(txtMaCTNK_CTDNK.Text));
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

        private void btnWord_CTDNK_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Microsoft Word | *.docx";
            saveFileDialog.Title = "Lưu thông tin chi tiết đơn nhập kho";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                try
                {
                    ctnk.KetXuatWord(@"Template\CTNK.docx", saveFileDialog.FileName);
                    MessageBox.Show("Kết xuất thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo lỗi");
                }
            }
        }

        private void btnReset_CTDNK_Click(object sender, EventArgs e)
        {
            ResetFormDNK();
            LoadDataCTNK();
        }
        private void dgvCTDNKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaCTNK_CTDNK.Text = dgvCTDNKho[0, dgvCTDNKho.CurrentCell.RowIndex].Value.ToString();
            txtMaDNK_CTDNK.Text = dgvCTDNKho[1, dgvCTDNKho.CurrentCell.RowIndex].Value.ToString();
            cbDichVu_CTDNK.Text = dgvCTDNKho[2, dgvCTDNKho.CurrentCell.RowIndex].Value.ToString();
            txtGiaNhap_CTDNK.Text = dgvCTDNKho[3, dgvCTDNKho.CurrentCell.RowIndex].Value.ToString();
            txtSoLuongNhap_CTDNK.Text = dgvCTDNKho[4, dgvCTDNKho.CurrentCell.RowIndex].Value.ToString();
        }
        private void btnSearch_CTDNK_Click(object sender, EventArgs e)
        {
            dgvCTDNKho.DataSource = ctnk.SearchLinq(txtSearch_CTDNK.Text);
        }
        #endregion ChiTietDonNhapKho
    }
}
