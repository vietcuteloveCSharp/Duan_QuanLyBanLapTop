using DAL.DomainClass;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace BUS.LoginService
{
    public class LoginService
    {
        private Dictionary<string, DateTime> _otpDictionary = new Dictionary<string, DateTime>();
        string _otp;
        TaikhoanRepo _taiKhoanRepo;
        PhanquyenRepo _phanQuyenRepo = new PhanquyenRepo();
        List<Taikhoan> _lstTaiKhoan;
        List<Phanquyen> _lstPhanQuyen;
        public LoginService()
        {
            _taiKhoanRepo = new TaikhoanRepo();
            _lstTaiKhoan = _taiKhoanRepo.GetTaiKhoan();
            _lstPhanQuyen = _phanQuyenRepo.GetPhanQuyen();
        }
        public Taikhoan CheckLogin(string username, string password)
        {
            try
            {
                var result = _lstTaiKhoan.FirstOrDefault(tk => tk.Username == username && tk.Password == password);
                if (result != null)
                {
                    return result;
                }
                return result;
            }
            catch (Exception)
            {
                throw;

            }
        }
        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            return _taiKhoanRepo.ChangePassword(username, oldPassword, newPassword);
        }
        public Taikhoan GetTaiKhoanByUsername(string username)
        {
            return _taiKhoanRepo.GetTaiKhoanByUsername(username);
        }
        public bool CheckEmail(string email)
        {
            try
            {
                var result = _lstTaiKhoan.FirstOrDefault(x => x.Email == email);
                if (result != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public string CreateOTP()
        {
            Random random = new Random();
            string otp = "";
            for (int i = 0; i < 6; i++)
            {
                otp += random.Next(10).ToString() + "";
            }
            return otp;
        }
        public bool SendMail(string otp, string email)
        {
            try
            {
                //thông tin email gửi otp
                string senderEmail = "vuvietanh123qazdf@gmail.com";
                string senderPassword = "bvbekvnjhsedcqix";
                // email nhận mã otp 
                string receiverEmail = email;
                // Tạo đối tượng MailMessage
                MailMessage mail = new MailMessage(senderEmail, receiverEmail);
                // Tiêu đề email
                mail.Subject = "Yêu cầu xác minh tài khoản";
                // Nội dung email
                mail.Body = $"Mã OTP của bạn là: {otp}";
                // Thiết lập định dạng nội dung email là text
                mail.IsBodyHtml = false;
                // Tạo đối tượng SmtpClient
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.EnableSsl = true;
                smtpClient.Port = 587;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
                smtpClient.Send(mail);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public void Get_VeriCode(string email)
        {
            _otp = CreateOTP();
            _otpDictionary[email] = DateTime.Now;
            SendMail(_otp, email);
        }
        //public bool VerifyOTP(string userOTP)
        //{
        //    try
        //    {
        //        if (!string.IsNullOrEmpty(userOTP)) {
        //            return userOTP == _otp.ToString();
        //        }
        //        return false;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        public bool checkTimeout(int min, int seconds)
        {
            if (min == 0 && seconds == 0)
            {
                return true;
            }
            return false;
        }
        public bool VerifyOTP(string userOTP, string userMail)
        {
            try
            {
                if (string.IsNullOrEmpty(userOTP)) { return false; }

                if (_otpDictionary.TryGetValue(userMail, out DateTime otpCreationTime))
                {
                    // Kiểm tra thời gian hết hạn của mã OTP (ví dụ: 5 phút)
                    if (DateTime.Now.Subtract(otpCreationTime).TotalMinutes <= 3)
                    {
                        // Mã OTP hợp lệ
                        _otpDictionary.Remove(userMail); // Xóa mã OTP sau khi đã sử dụng
                        return userOTP == _otp.ToString(); // Kiểm tra mã OTP nhập vào
                    }
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public bool UpdatePass(string newPass, string email)
        {
            try
            {

                var lstTaiKhoan = _lstTaiKhoan.FirstOrDefault(x => x.Email == email);
                Taikhoan taikhoan = lstTaiKhoan;
                taikhoan.Password = newPass;
                return _taiKhoanRepo.UpdateTaiKhoan(taikhoan);
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
