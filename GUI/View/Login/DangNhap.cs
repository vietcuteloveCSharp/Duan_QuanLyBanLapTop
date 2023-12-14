using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BUS.Service;
using BUS.LoginService;
using DAL.DomainClass;
using GUI.View.viewslogin;


namespace GUI.View
{
    public partial class DangNhap : Form
    {
        LoginService loginService;
        public DangNhap()
        {
            InitializeComponent();
            loginService = new LoginService();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            try
            {
                var result = loginService.CheckLogin(txt_UseName.Text, txt_Password.Text);
                if (result == null)
                {
                    MessageBox.Show("Tài khoản không tồn tại", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (result.TrangThai == true)
                    {
                        if (result.IdPhanquyen == 1)
                        {
                            MessageBox.Show("Bạn đang sử dụng tài khoản admin", "Thông báo", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Bạn đang sử dụng tài khoản nhân viên", "Thông báo", MessageBoxButtons.OK);
                        }
                        Menu menu = new Menu(result);
                        menu.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản này đã ngừng hoạt động", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        private void chk_ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txt_Password.UseSystemPasswordChar = !chk_ShowPassword.Checked;

        }

        // Trong phương thức khởi tạo hoặc sự kiện Load của form
        private void Form_Load(object sender, EventArgs e)
        {
            // Mặc định ẩn mật khẩu khi form được tải
            txt_Password.UseSystemPasswordChar = true;

        }

        private void btn_username_Click(object sender, EventArgs e)
        {

            EmailVerifyForm emailVerifyForm = new EmailVerifyForm();
            emailVerifyForm.Show();
        }
    }
}
