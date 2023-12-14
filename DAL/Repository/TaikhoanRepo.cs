using DAL.Context;
using DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class TaikhoanRepo
    {
        DBContext db;
        public TaikhoanRepo()
        {
                db = new DBContext();
        }
        public List<Taikhoan> GetTaiKhoan()
        {
            return db.Taikhoans.ToList();
        }
        public bool AddTaikhoan (Taikhoan taikhoan)
        {
            try
            {
                db.Taikhoans.Add(taikhoan);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

               return false;
            }
        }
        public bool UpdateTaiKhoan( Taikhoan taikhoan)
        {
            try
            {
                db.Taikhoans.Update(taikhoan);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

               return false;
            }
        }
        public bool UpdateTaikhoan(Taikhoan taikhoan)
        {
            try
            {
                var updateTk = db.Taikhoans.Find(taikhoan.IdTaikhoan);
                updateTk.Diachi = taikhoan.Diachi;
                updateTk.Dienthoai = taikhoan.Dienthoai;
                updateTk.Hinhanh = taikhoan.Hinhanh;
                updateTk.TrangThai = taikhoan.TrangThai;
                updateTk.Email = taikhoan.Email;
                db.Taikhoans.Update(updateTk);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool IsEmailExists(string email, string user)
        {
            return db.Taikhoans.Any(x => x.Email == email|| x.Username == user);
            //db.Taikhoans.Any(x => x.Username == user);
            

        }
        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            try
            {
                var user = db.Taikhoans.FirstOrDefault(tk => tk.Username == username && tk.Password == oldPassword);
                if (user != null)
                {
                    user.Password = newPassword;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false; // Tài khoản hoặc mật khẩu cũ không chính xác
                }
            }
            catch (Exception)
            {
                return false; // Xử lý ngoại lệ nếu có
            }
        }
        public Taikhoan GetTaiKhoanByUsername(string username)
        {
            return db.Taikhoans.FirstOrDefault(tk => tk.Username == username);
        }
        
        public List<Taikhoan> GetTKBYAll(string name)
        {
            return db.Taikhoans.Where(p => p.Hoten.Contains(name) || p.Username.Contains(name) || p.Dienthoai.Contains(name) || p.Email.Contains(name)).ToList();
        }
    }
}
