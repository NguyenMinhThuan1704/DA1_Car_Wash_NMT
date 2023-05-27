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
    public partial class frmLogin : Form
    {
        ITaiKhoanBLL tk = new TaiKhoanBLL();
        public frmLogin()
        {
            InitializeComponent();
            txtTaiKhoan.Focus();
        }

        private void chk1_CheckedChanged(object sender, EventArgs e)
        {
            if (chk1.Checked)
                txtMatKhau.UseSystemPasswordChar = false;
            else
                txtMatKhau.UseSystemPasswordChar = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.Text.Trim() != "" && txtTaiKhoan.Text.Trim() != "")
            {
                // Kiểm tra mật khẩu
                bool isAccountExist = tk.checkTaiKhoan_IsExist(txtTaiKhoan.Text, txtMatKhau.Text);
                if (isAccountExist)
                {
                    int manvLogin = tk.TaiKhoanLogin(txtTaiKhoan.Text, txtMatKhau.Text).Manhanvien;
                    NhanVienDTO nvLogin = tk.GetNhanVien(manvLogin);
                    Bien.manhanvien = manvLogin;
                    Bien.username = nvLogin.tennv;
                    MessageBox.Show("Đăng nhập thành công");
                    frmMain frm = new frmMain();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Tài khoản của bạn không tồn tại");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin tài khoản");
            }
        }
    }
}
