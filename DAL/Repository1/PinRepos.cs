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
    public class PinRepos:IPinRepos
    {
        DBContext _context = new DBContext();

        public PinRepos()
        {
        }

        public PinRepos(DBContext context)
        {
            _context = context;
        }

        public bool CreatePin(Pin pin)
        {
            try
            {
                _context.Pins.Add(pin);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Pin> GetAllPin()
        {
            return _context.Pins.ToList();
        }

        public List<Pin> GetPinByAll(string name)
        {
            return _context.Pins.Where(p => p.Tenpin.Contains(name)|| p.Loaipin.Contains(name) || p.Trangthai.Contains(name)).ToList();
        }

        public bool UpdatePin(Pin pin)
        {
            try
            {
                var updatePin = _context.Pins.Find(pin.IdPin);
                if (updatePin != null)
                {
                    updatePin.Tenpin = pin.Tenpin;
                    updatePin.Dungluong = pin.Dungluong;
                    updatePin.Loaipin = pin.Loaipin;
                    updatePin.Thoigiansd = pin.Thoigiansd;
                    updatePin.Trangthai = pin.Trangthai;
                    
                    _context.Pins.Update(updatePin);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public Pin GetOne(int ID)
        {
            return _context.Pins.FirstOrDefault(x => x.IdPin == ID);
        }
    }
}
