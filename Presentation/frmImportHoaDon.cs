using BusinessLogicLayer;
using BusinessLogicLayer.Interface;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class frmImportHoaDon : Form
    {
        IKhachHangBLL kh = new KhachHangBLL();
        IHoaDonBLL hoadon = new HoaDonBLL();
        IChiTietHoaDonBLL chitiet = new ChiTietHoaDonBLL();
        frmHoaDon frm;
        public frmImportHoaDon(frmHoaDon frm1)
        {
            InitializeComponent();
            frm = frm1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmImportHoaDon_Load(object sender, EventArgs e)
        {
            lbprice.Text = Bien.tonghoadon.ToString("#,##0 VND");
            btnPay.Enabled = false;
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (!cbIsExit.Checked)
            {
                kh.Insert(new Entities.KhachHangDTO(txtName.Text, 0, "",txtPhone.Text));
            }
            string sdt = txtPhone.Text;
            int makh;
            if (!cbIsExit.Checked)
            {
                makh = kh.getAll().LastOrDefault().makh;
            }
            else
            {
                makh = kh.SearchLinq(sdt)[0].makh;
            }
            DateTime today = DateTime.Today;
            float tongtien = Bien.tonghoadon;
            int manv = Bien.manhanvien;
            hoadon.Insert(new HoaDonDTO(manv, makh, today, tongtien));
            List<HoaDonDTO> danhSachSapXep = hoadon.getAll().OrderByDescending(hd => hd.Mahd).ToList();
            // Lấy mã hóa đơn mới nhất
            int maHoaDonMoiNhat = danhSachSapXep.First().Mahd;
            frm.InsertChiTietHoaDon();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Microsoft Word | *.docx";
            saveFileDialog.Title = "Lưu thông tin lớp";
            string filePath = "C:\\Users\\nqtha\\OneDrive\\Documents\\Project\\Đồ án 1\\Hóa Đơn\\" + "Hóa đơn " + maHoaDonMoiNhat + " " + Bien.username + "-" + txtName.Text + ".docx";
            FileInfo fi = new FileInfo(filePath);
            fi.Create().Close();
            if (fi.FullName != "")
            {
                //try
                //{
                    chitiet.KetXuatWord(txtName.Text, maHoaDonMoiNhat, tongtien, Bien.username, @"Template\Chitiethoadon_Template.docx", fi.FullName);
                    MessageBox.Show("Kết xuất thành công!");
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message, "Thông báo lỗi");
                //}

            }
            frm.ResetDgv();
            this.Close();
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            string value = txtPhone.Text.Trim();
            cbIsExit.ForeColor = Color.Transparent;
            if (value != "" && kh.SearchLinq(value).Count > 0)
            {
                cbIsExit.Checked = true;
                cbIsExit.ForeColor = Color.Green;
                txtName.Text = kh.SearchLinq(value)[0].tenkh;
            }
            else
            {
                cbIsExit.Checked = false;
                cbIsExit.ForeColor = Color.Transparent;
                txtName.Text = "";
            }
        }

        private void txtbuy_TextChanged(object sender, EventArgs e)
        {
            if (txtbuy.Text != "" && Bien.tonghoadon <= float.Parse(txtbuy.Text))
            {
                btnPay.Enabled = true;
                float priceBack = float.Parse(txtbuy.Text) - Bien.tonghoadon;
                lbRest.Text = priceBack.ToString("#,##0 VND");
            }
            else
            {
                btnPay.Enabled = false;
                lbRest.Text = "";
            }
        }

        private void btnDestroy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
