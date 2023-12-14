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
    public class HoaDonCTRespository : iRespo<Hoadonct, bool, string, int, Decimal, DateTime, int, string>
    {
        DBContext _context;
        public HoaDonCTRespository()
        {
            
            _context = new DBContext();
        }
        public bool Create(Hoadonct t)
        {
            try
            {
                _context.Hoadoncts.Add(t);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int k)
        {
            if (k == null)
            {
                return false;
            }
            var NHCT = GetAll().FirstOrDefault(x => x.IdHdct == k);
            _context.Remove(NHCT);
            _context.SaveChanges(); return true;
        }

        public List<Hoadonct> GetAll()
        {
            return _context.Hoadoncts.ToList();
        }

        public List<Hoadonct> GetByBit(bool b)
        {
            return null;
        }

        public List<Hoadonct> GetByDateTime(DateTime Tu, DateTime Den)
        {
            return null;
        }

        public List<Hoadonct> GetByDecimal(decimal name)
        {
            return _context.Hoadoncts.Where(x => x.Gia == name).ToList();
        }

        public List<Hoadonct> GetByInt(int name, string key)
        {
            if (key.Equals("PK"))
            {
                return _context.Hoadoncts.Where(x => x.IdHdct == name).ToList();
            }
            else if (key.Equals("FK"))
            {
                return _context.Hoadoncts.Where(x => x.IdHoadon == name).ToList();
            }
            return null;
        }

        public List<Hoadonct> GetByString(string name)
        {
            return _context.Hoadoncts.Where(x => x.Imel.Equals(name)).ToList();
        }

        public Hoadonct GetOne(string o)
        {
            return null;
        }

        public bool Update(Hoadonct t)
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
