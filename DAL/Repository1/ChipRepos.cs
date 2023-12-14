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
    public class ChipRepos:IChipRepos
    {
        DBContext _context = new DBContext();

        public ChipRepos()
        {
        }

        public ChipRepos(DBContext context)
        {
            _context = context;
        }

        public bool CreateChip(Chip chip)
        {
            try
            {
                _context.Chips.Add(chip);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteChip(int Id)
        {
            try
            {
                var deleteItem = _context.Chips.Find(Id);
                _context.Chips.Remove(deleteItem);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Chip> GetAllChip()
        {
            return _context.Chips.ToList();
        }

        public List<Chip> GetChipByAll(string name)
        {
            return _context.Chips.Where(p => p.Tenchip.Contains(name) || p.Trangthai.Contains(name)).ToList();
        }
        public bool UpdateChip(Chip chip)
        {
            try
            {
                var updateChip = _context.Chips.Find(chip.IdChip);
                updateChip.Tenchip = chip.Tenchip;
                updateChip.Trangthai = chip.Trangthai;
                _context.Chips.Update(updateChip);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Chip GetOne(int ID)
        {
            return _context.Chips.FirstOrDefault(x => x.IdChip == ID);
        }
    }
}
