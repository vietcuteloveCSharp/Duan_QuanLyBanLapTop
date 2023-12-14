using BUS.Service;
using BUS.LoginService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GUI.View.viewslogin
{
    public partial class EmailVerifyForm : Form
    {
        int min = 0, seconds = 0, countOTPFail = 0;
        Form currentFormChild;
        LoginService loginService;
        bool timeOut = false;
        public EmailVerifyForm()
        {
            InitializeComponent();
            loginService = new LoginService();
        }
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            pn_Emailvery.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }
        private void btn_Back_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DangNhap());
        }
        private void UpdateTimeLabel()
        {
            lb_timeOTP.Text = $"{min}:{seconds}";
        }
        private void lb_OTP_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_emailvery.Text))
            {
                MessageBox.Show("không được bỏ trống email", "cảnh báo", MessageBoxButtons.OK ,MessageBoxIcon.Warning);
                return;
            }
            timeOut = false;
            min = 1; seconds = 0;
            if (timer == null)
            {
                timer = new System.Windows.Forms.Timer();
                timer.Tick += timer_Tick;
                timer.Interval = 1000; // Thiết lập khoảng thời gian giữa các sự kiện Tick là 1000 ms (1 giây)
                timer.Tag = new { Min = min, Seconds = seconds };
            }
            timer.Start();
            lb_timeOTP.Visible = true;
            lb_timeOTP.Text = min.ToString() + ":" + seconds.ToString();
            lb_OTP.Enabled = false;
            if (loginService.CheckEmail(txt_emailvery.Text))
            {
                loginService.Get_VeriCode(txt_emailvery.Text);
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {

            if (min == 0 && seconds == 0)
            {
                lb_OTP.Enabled = true;
                lb_timeOTP.Visible = false;
                timer.Stop();
                timeOut = true;
            }
            else
            {
                if (seconds == 0)
                {
                    seconds = 59;
                    min--;
                }
                else
                {
                    seconds--;
                }
                UpdateTimeLabel();
            }
        }

        private void btn_Continue_Click(object sender, EventArgs e)
        {
            if (timeOut)
            {
                MessageBox.Show("Mã OTP hết hạn", "Thông báo", MessageBoxButtons.OK ,MessageBoxIcon.Error);
                return;
            }
            if (txt_emailvery.Text == null)
            {
                MessageBox.Show("Không được bỏ trống ô email", "thông báo", MessageBoxButtons.OK ,MessageBoxIcon.Warning);
            }
            if (loginService.VerifyOTP(txtEmailOTP.Text, txt_emailvery.Text))
            {
                //mở form reset pass
               OpenChildForm(new ResetPassForm(txt_emailvery.Text));
            }
            else
            {
                countOTPFail++;
                MessageBox.Show("Vui lòng kiểm tra email hoặc mã của bạn");
                if (countOTPFail >= 3)
                {
                    MessageBox.Show("Tài khoản của bạn bị khóa tạm thời, vui lòng thử lại sau");
                }
            }
        }
        public bool IsValid(string emailaddress)
        {
            try
            {
                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

                // Create Regex object
                Regex regex = new Regex(pattern);

                // Check if the email matches the pattern
                return regex.IsMatch(emailaddress);
            }
            catch (FormatException)
            {
                return false;
            }
        }
        private void txt_emailvery_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (min != 0 && seconds != 0)
                {
                    return;
                }
                if (IsValid(txt_emailvery.Text))
                {

                    lb_OTP.Enabled = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void lb_timeOTP_Click(object sender, EventArgs e)
        {

        }
    }
}
