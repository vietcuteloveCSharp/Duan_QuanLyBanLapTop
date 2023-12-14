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
    public class RamRepos : IRamRepos
    {
        DBContext _context = new DBContext();

        public RamRepos()
        {
        }

        public RamRepos(DBContext context)
        {
            _context = context;
        }

        public bool CreateRam(Ram ram)
        {
            try
            {
                _context.Rams.Add(ram);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteRam(int Id)
        {
            try
            {
                var deleteItem = _context.Rams.Find(Id);
                _context.Rams.Remove(deleteItem);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Ram> GetAllRam()
        {
            return _context.Rams.ToList();
        }

        public List<Ram> GetRamByAll(string name)
        {
            return _context.Rams.Where(p => p.Tenram.Contains(name) || p.Trangthai.Contains(name)).ToList();
        }

        public bool UpdateRam(Ram ram)
        {
            try
            {
                var updateRam = _context.Rams.Find(ram.IdRam);
                updateRam.Tenram = ram.Tenram;
                updateRam.Bus = ram.Bus;    
                updateRam.Trangthai = ram.Trangthai;
                _context.Rams.Update(updateRam);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Ram GetOne(int ID)
        {
            return _context.Rams.FirstOrDefault(x => x.IdRam == ID);
        }
    }
}
