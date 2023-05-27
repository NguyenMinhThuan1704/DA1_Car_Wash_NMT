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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            openChildForm(new frmSlider());
        }

        private void btnbangdieukhien_Click(object sender, EventArgs e)
        {
            panelSlide.Height = btnbangdieukhien.Height;
            panelSlide.Top = btnbangdieukhien.Top;
            openChildForm(new frmSlider());
        }

        private void btnnhanvien_Click(object sender, EventArgs e)
        {
            panelSlide.Height = btnnhanvien.Height;
            panelSlide.Top = btnnhanvien.Top;
            openChildForm(new frmNhanVien());
        }

        private void btnkhachhang_Click(object sender, EventArgs e)
        {
            panelSlide.Height = btnkhachhang.Height;
            panelSlide.Top = btnkhachhang.Top;
            openChildForm(new frmKhachHang());
        }
        private void btndichvu_Click(object sender, EventArgs e)
        {
            panelSlide.Height = btndichvu.Height;
            panelSlide.Top = btndichvu.Top;
            openChildForm(new frmDichVu());
        }
        private void btntinhtien_Click(object sender, EventArgs e)
        {
            panelSlide.Height = btntinhtien.Height;
            panelSlide.Top = btntinhtien.Top;
            openChildForm(new frmHoaDon());
        }
        private void btnbaocao_Click(object sender, EventArgs e)
        {
            panelSlide.Height = btnbaocao.Height;
            panelSlide.Top = btnbaocao.Top;
            openChildForm(new frmBaoCao());
        }

        private void btnKho_Click(object sender, EventArgs e)
        {
            panelSlide.Height = btnKho.Height;
            panelSlide.Top = btnKho.Top;
            openChildForm(new frmKho());
        }
        private void btnNcc_Click(object sender, EventArgs e)
        {
            panelSlide.Height = btnNcc.Height;
            panelSlide.Top = btnNcc.Top;
            openChildForm(new frmNhaCungCap());
        }
        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            panelSlide.Height = btnTaiKhoan.Height;
            panelSlide.Top = btnTaiKhoan.Top;
            openChildForm(new frmTaiKhoan());
        }
        private void btncaidat_Click(object sender, EventArgs e)
        {
            panelSlide.Height = btncaidat.Height;
            panelSlide.Top = btncaidat.Top;
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // tạo một hàm bất kỳ dạng nào cho pancelChild trên Fmain
        private Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChild.Controls.Add(childForm);
            panelChild.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
}
