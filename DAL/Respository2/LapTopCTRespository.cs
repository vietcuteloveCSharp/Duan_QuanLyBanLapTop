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
    public class LapTopCTRespository : iRespo<Laptopchitiet,bool, string, int, Decimal, DateTime, int,string>

    {
        DBContext _context = new DBContext();
        public LapTopCTRespository()
        {
            
        }

        public bool Create(Laptopchitiet t)
        {
            try
            {
                _context.Laptopchitiets.Add(t);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Laptopchitiet> GetByBit(bool b)
        {
            return _context.Laptopchitiets.Where(x => x.TrangThai == b).ToList();
        }
        public bool Delete(int k)
        {
            return false;
        }

        public List<Laptopchitiet> GetAll()
        {
            return _context.Laptopchitiets.ToList();
        }

        public List<Laptopchitiet> GetByDateTime(DateTime Tu, DateTime Den)
        {
            return null;
        }

        public List<Laptopchitiet> GetByDecimal(decimal name)
        {
            return _context.Laptopchitiets.Where(x => x.Gianhap ==  name).ToList();
        }

        public List<Laptopchitiet> GetByInt(int name, string key)
        {
            throw new NotImplementedException();
        }

        public List<Laptopchitiet> GetByString(string name)
        {
            return _context.Laptopchitiets.Where(x => x.Imel.Equals(name)).ToList();
        }


        public bool Update(Laptopchitiet t)
        {
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
        public Laptopchitiet GetOne(String s)
        {
            return _context.Laptopchitiets.FirstOrDefault(x => x.Imel == s);
        }

    }
}
