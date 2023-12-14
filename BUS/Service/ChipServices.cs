using DAL.DomainClass;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service
{
    public class ChipServices
    {
        ChipRepos _repos = new ChipRepos();

        public ChipServices()
        {
        }

        public ChipServices(ChipRepos repos)
        {
            _repos = repos;
        }
        public List<Chip> GetAllChip()
        {
            return _repos.GetAllChip().ToList();
        }
        public List<Chip> GetChipByAll(string name)
        {
            return _repos.GetChipByAll(name).ToList();
        }
        public bool AddNewChip(string name, string trangThai)
        {
            var chip = new Chip()
            {
                Tenchip = name,
                Trangthai = trangThai
            };
           return _repos.CreateChip(chip);
        }
        public bool DeleteChip(int Id)
        {
            return _repos.DeleteChip(Id);
        }
        public bool UpdateChip(int Id, string name, string trangThai)
        {
            Chip chip = new Chip()
            {
                IdChip = Id,
                Tenchip = name,
                Trangthai = trangThai
            };
            return _repos.UpdateChip(chip);
        }
        public Chip GetOne(int ID)
        {
            return _repos.GetOne(ID);
        }
    }
}
