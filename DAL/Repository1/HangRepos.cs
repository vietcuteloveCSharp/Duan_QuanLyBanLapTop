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
    public class HangRepos : IHangRepos
    {
        DBContext _context = new DBContext();

        public HangRepos()
        {
        }

        public HangRepos(DBContext context)
        {
            _context = context;
        }

        public bool CreateHang(Hang hang)
        {
            try
            {
                _context.Hangs.Add(hang);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteHang(int Id)
        {
            try
            {
                var deleteItem = _context.Hangs.Find(Id);
                _context.Hangs.Remove(deleteItem);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Hang> GetAllHang()
        {
            return _context.Hangs.ToList();
        }

        public List<Hang> GetHangByAll(string name)
        {
            return _context.Hangs.Where(p => p.Tenhang.Contains(name) || p.Trangthai.Contains(name)).ToList();
        }

        public bool UpdateHang(Hang hang)
        {
            try
            {
                var updateHang = _context.Hangs.Find(hang.IdHang);
                updateHang.Tenhang = hang.Tenhang;
                updateHang.Trangthai = hang.Trangthai;
                _context.Hangs.Update(updateHang);
                _context.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        public Hang GetOne(int ID)
        {
            return _context.Hangs.FirstOrDefault(x => x.IdHang == ID);
        }
    }
}
