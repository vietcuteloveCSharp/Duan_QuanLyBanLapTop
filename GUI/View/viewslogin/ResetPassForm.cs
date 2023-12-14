using BUS.Service;
using DAL.DomainClass;
using BUS.LoginService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GUI.View.viewslogin
{
    public partial class ResetPassForm : Form
    {
        LoginService LoginService;
        string _email;
        List<Taikhoan> _lstTaiKhoan;
        public ResetPassForm(string email)
        {
            InitializeComponent();
            LoginService = new LoginService();
            _email = email;

        }
        //public ResetPassForm(string email)
        //{

        //    LoginService = new LoginService();
        //    _email = email;
        //}
        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            // childForm.Dock = DockStyle.Fill;
            pn_ResetPass.Controls.Add(childForm);
            // pnlBody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        public bool CheckPass()
        {
            if(txt_newpass.Text.Length < 6)
{
                MessageBox.Show("Mật khẩu phải có độ dài lớn hơn 6", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true; //"Mật khẩu phải có ít nhất 1 ký tự!";
            }
            if (txt_newpass.Text.Contains(" "))
            {
                MessageBox.Show("Mật khẩu không được có khoảng trắng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (txt_newpass.Text != txt_passagain.Text)
            {
                MessageBox.Show("Mật khẩu phải giống nhau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }

        private void btn_Continue_Click(object sender, EventArgs e)
        {
            string checkPass = CheckPass().ToString();
            if (CheckPass() != false)
            {
                MessageBox.Show("" + checkPass);
                return;
            }

            try
            {
                var result = LoginService.UpdatePass(txt_newpass.Text.ToString(), _email);
                OpenChildForm(new DangNhap());
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn muốn trở lại đăng nhập", "Trở lại", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                OpenChildForm(new DangNhap());
            }
        }

        private void checkPassReset_CheckedChanged(object sender, EventArgs e)
        {
            txt_newpass.UseSystemPasswordChar = !checkPassReset.Checked;
            txt_passagain.UseSystemPasswordChar = !checkPassReset.Checked;
        }



        private void ResetPassForm_Load(object sender, EventArgs e)
        {
            txt_newpass.UseSystemPasswordChar = true;
            txt_passagain.UseSystemPasswordChar = true;
        }
    }
}
