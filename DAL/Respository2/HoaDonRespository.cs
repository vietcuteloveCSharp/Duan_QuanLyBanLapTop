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
    public class HoaDonRespository : iRespo<Hoadon, bool, string, int, Decimal, DateTime, int, int>
    {
        DBContext _context;
        public HoaDonRespository()
        {
            _context = new DBContext();
        }
        public bool Create(Hoadon t)
        {
            try
            {
                _context.Hoadons.Add(t);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex) 
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
            var NHCT = GetAll().FirstOrDefault(x => x.IdHoadon == k);
            _context.Remove(NHCT);
            _context.SaveChanges(); return true;
        }

        public List<Hoadon> GetAll()
        {
            return _context.Hoadons.ToList();
        }

        public List<Hoadon> GetByBit(bool b)
        {
            return _context.Hoadons.Where(x => x.Trangthai == b).ToList();
        }

        public List<Hoadon> GetByDateTime(DateTime Tu, DateTime Den)
        {
            return _context.Hoadons.Where(x => x.Ngaymua < Den && x.Ngaymua > Tu).ToList();
        }

        public List<Hoadon> GetByDecimal(decimal name)
        {
            return _context.Hoadons.Where(x => x.Tongtien == name).ToList();
        }

        public List<Hoadon> GetByInt(int name, string key)
        {
            if (key.Equals("PK"))
            {
                return _context.Hoadons.Where(x => x.IdHoadon == name).ToList();
            }
            else if (key.Equals("FK_TK"))
            {
                return _context.Hoadons.Where(x => x.IdTaikhoan == name).ToList();
            }
            return _context.Hoadons.Where(x => x.IdKhachhang == name).ToList();
        }

        public List<Hoadon> GetByString(string name)
        {
            return _context.Hoadons.Where(x => x.Chuthich.Equals(name)).ToList();
        }

        public Hoadon GetOne(int o)
        {
            return _context.Hoadons.FirstOrDefault(x => x.IdHoadon == o);
        }

        public bool Update(Hoadon t)
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
