using DAL.Context;
using DAL.DomainClass;
using DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Respository2
{
    public class NhapKhoCTRespository : iRespo<Nhaphangchitiet,bool, string, int, Decimal, DateTime, int,string>
    {
        DBContext _context;
        public NhapKhoCTRespository()
        {
            _context = new DBContext();
        }
        public bool Create(Nhaphangchitiet t)
        {
            try
            {
                _context.Nhaphangchitiets.Add(t);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Nhaphangchitiet GetOne(string s)
        {
            return null;
        }
        public List<Nhaphangchitiet> GetByBit(bool b)
        {
            return null;
        }

        public bool Delete(int k)
        {
            if (k == null)
            {
                return false;
            }
            var NHCT = _context.Nhaphangchitiets.ToList().FirstOrDefault(x => x.IdNhct == k);
            _context.Remove(NHCT);
            _context.SaveChanges(); return true;
        }

        public List<Nhaphangchitiet> GetAll()
        {
            return _context.Nhaphangchitiets.ToList();
        }

        public List<Nhaphangchitiet> GetByDateTime(DateTime Tu, DateTime Den)
        {
            return null;
        }

        public List<Nhaphangchitiet> GetByDecimal(decimal name)
        {
            return _context.Nhaphangchitiets.Where(x => x.Gianhap == name).ToList();
        }

        public List<Nhaphangchitiet> GetByInt(int name, string key)
        {
            if (key.Equals("PK"))
            {
                return _context.Nhaphangchitiets.Where(x => x.IdNhct == name).ToList();
            }
            else if (key.Equals("FK"))
            {
                return _context.Nhaphangchitiets.Where(x => x.IdNhaphang == name).ToList();
            }
            return null;
        }

        public List<Nhaphangchitiet> GetByString(string name)
        {
            return _context.Nhaphangchitiets.Where(x => x.Imel.Equals(name)).ToList();
        }

        public bool Update(Nhaphangchitiet t)
        {
            if (t == null)
            {
                return false;
            }
            _context.Update(t);
            _context.SaveChanges();
            return true;
        }
        
    }
}
