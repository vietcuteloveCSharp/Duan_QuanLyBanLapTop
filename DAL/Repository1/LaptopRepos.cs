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
    public class LaptopRepos : ILapTopRepos
    {
        DBContext _context = new DBContext();

        public LaptopRepos()
        {
        }

        public LaptopRepos(DBContext context)
        {
            _context = context;
        }

        public bool CreateLaptop(Laptop laptop)
        {
            try
            {
                _context.Laptops.Add(laptop);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteLaptop(int Id)
        {
            try
            {
                var deleteItem = _context.Laptops.Find(Id);
                _context.Laptops.Remove(deleteItem);
                _context.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public List<Laptop> GetAllLaptop()
        {
            return _context.Laptops.ToList();
        }

        public List<Laptop> GetLaptopByAll(string name)
        {
            return _context.Laptops.Where(p=>p.Tenlaptop.Contains(name) || p.Mota.Contains(name) || p.Trangthai.Contains(name)).ToList();
        }
        public Laptop Getone(int Id)
        {
            return _context.Laptops.FirstOrDefault(x => x.IdLt == Id);
        }
        public bool UpdateLaptop(Laptop laptop)
        {
            try
            {
                var updateLP = _context.Laptops.Find(laptop.IdLt);
                updateLP.Tenlaptop = laptop.Tenlaptop;
                updateLP.Cannang = laptop.Cannang;
                updateLP.Mota = laptop.Mota;
                updateLP.Trangthai = laptop.Trangthai;
                updateLP.Idhang = laptop.Idhang;
                _context.Laptops.Update(updateLP);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
