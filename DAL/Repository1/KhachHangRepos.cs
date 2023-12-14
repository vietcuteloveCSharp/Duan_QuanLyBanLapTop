using DAL.IRepository;
using DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Context;

namespace DAL.Repository
{
    public class KhachHangRepos:IKhachHangRepos
    {
        DBContext _context = new DBContext();

        public KhachHangRepos()
        {
        }

        public KhachHangRepos(DBContext context)
        {
            _context = context;
        }

        public bool CreateKH(Khachhang khachHang)
        {
            try
            {
                _context.Khachhangs.Add(khachHang);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteKH(int Id)
        {
            try
            {
                var deleteItem = _context.Khachhangs.Find(Id);
                _context.Khachhangs.Remove(deleteItem);
                _context.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public List<Khachhang> GetAllKH()
        {
           return _context.Khachhangs.ToList();
        }

        public List<Khachhang> GetKHBYAll(string name)
        {
          return _context.Khachhangs.Where(p=>p.Tenkh.Contains(name) || p.Diachi.Contains(name) || p.Dienthoai.Contains(name) || p.Email.Contains(name)).ToList();
        }

        public bool UpdateKH(Khachhang khachHang)
        {
            try
            {
                var updateKH = _context.Khachhangs.Find(khachHang.IdKhachhang);
                updateKH.Tenkh = khachHang.Tenkh;
                updateKH.Diachi = khachHang.Diachi;
                updateKH.Dienthoai = khachHang.Dienthoai;
                updateKH.Email = khachHang.Email;
                _context.Khachhangs.Update(updateKH);
                _context.SaveChanges();
                return true;
            }
            catch {  return false; }
        }
    }
}
