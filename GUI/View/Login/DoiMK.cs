using BUS.Service;
using BUS.LoginService;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.View
{
    public partial class DoiMK : Form
    {
        private string _username;
        LoginService loginService;

        public DoiMK(string username)
        {
            InitializeComponent();
            _username = username;
            loginService = new LoginService();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string oldPassword = txt_MKCu.Text;
            string newPassword = txt_MKMoi.Text;
            string confirmPassword = txt_MKMoi2.Text;

            if (string.IsNullOrWhiteSpace(oldPassword) || string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra độ dài của mật khẩu mới
            if (newPassword.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu mới không khớp nhau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool success = loginService.ChangePassword(_username, oldPassword, newPassword);

            if (success)
            {
                MessageBox.Show("Đổi mật khẩu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Đóng form đổi mật khẩu sau khi thành công
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu thất bại. Kiểm tra lại mật khẩu cũ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chk_ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txt_MKCu.UseSystemPasswordChar = !chk_ShowPassword.Checked;
            txt_MKMoi.UseSystemPasswordChar = !chk_ShowPassword.Checked;
            txt_MKMoi2.UseSystemPasswordChar = !chk_ShowPassword.Checked;
        }

        private void DoiMK_Load(object sender, EventArgs e)
        {
            txt_MKCu.UseSystemPasswordChar = true;
            txt_MKMoi.UseSystemPasswordChar = true;
            txt_MKMoi2.UseSystemPasswordChar = true;
        }
    }
}
