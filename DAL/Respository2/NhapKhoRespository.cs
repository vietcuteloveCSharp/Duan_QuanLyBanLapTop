using DAL.Context;
using DAL.DomainClass;
using DAL.IRepository;
using DAL.Respository2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Respository2
{
    public class NhapKhoRespository : iRespo<Nhaphang, bool, string, int, Decimal, DateTime, int,int>
    {
        DBContext _context;
        public NhapKhoRespository()
        {
            _context = new DBContext();
        }
        public bool Create(Nhaphang t)
        {
            try
            {
                _context.Nhaphangs.Add(t);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Nhaphang GetOne(int s)
        {
            return _context.Nhaphangs.FirstOrDefault(x => x.IdNhaphang == s);
        }
        public List<Nhaphang> GetByBit(bool b)
        {
            return null;
        }

        public bool Delete(int k)
        {
            if (k == null)
            {
                return false;
            }
            var NHCT = _context.Nhaphangs.ToList().FirstOrDefault(x => x.IdNhaphang == k);
            _context.Remove(NHCT);
            _context.SaveChanges(); return true;
        }

        public List<Nhaphang> GetAll()
        {
            return _context.Nhaphangs.ToList();
        }

        public List<Nhaphang> GetByDateTime(DateTime Tu, DateTime Den)
        {
            return _context.Nhaphangs.Where(x => x.Ngaynhap < Den && x.Ngaynhap > Tu).ToList();
        }

        public List<Nhaphang> GetByDecimal(Decimal name)
        {
            return null;
        }

        public List<Nhaphang> GetByInt(int name, string key)
        {
            if (key.Equals("PK"))
            {
                return _context.Nhaphangs.Where(x => x.IdNhaphang == name).ToList();
            }
            else if (key.Equals("FK"))
            {
                return _context.Nhaphangs.Where(x => x.IdTaikhoan == name).ToList();
            }
            return _context.Nhaphangs.Where(x => x.Soluongnhhap == name).ToList();
        }

        public List<Nhaphang> GetByString(string name)
        {
            return _context.Nhaphangs.Where(x => x.Nhacungcap.Equals(name)).ToList();
        }

        public bool Update(Nhaphang t)
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

//DBContext _context;
//public NhapKho()
//{
//    _context = new DBContext();
//}
//public bool Create(Nhaphang t)
//{
//    try
//    {
//        _context.Nhaphangs.Add(t);
//        _context.SaveChanges();
//        return true;
//    }
//    catch
//    {
//        return false;
//    }
//}

//public bool Delete(int k)
//{
//    return false;
//}

//public List<Nhaphang> GetByNameOrAll(string name)
//{
//    if (name == null)
//    {
//        var data = _context.Nhaphangs.ToList();
//        return data;
//    }
//    return _context.Nhaphangs.Where(h => h.IdNhaphang.Equals(name)).ToList();
//}

//public bool Update(Nhaphang t)
//{
//    throw new NotImplementedException();
//}
///
