using DAL.DomainClass;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service
{
    public class RamServices
    {
        RamRepos _repos = new RamRepos();

        public RamServices()
        {
        }

        public RamServices(RamRepos repos)
        {
            _repos = repos;
        }
        public List<Ram> GetAllRam()
        {
            return _repos.GetAllRam().ToList();
        }
        public List<Ram> GetRamByAll(string name)
        {
            return _repos.GetRamByAll(name).ToList();
        }
        public bool AddNewRam(string name,int bus, string trangThai)
        {
            var ram = new Ram()
            {
                Tenram = name,
                Bus = bus,
                Trangthai = trangThai
            };
            return _repos.CreateRam(ram);
        }
        public bool DeleteRam(int Id)
        {
            return _repos.DeleteRam(Id);
        }
        public bool UpdateRam(int Id, string name, int bus, string trangThai)
        {
            Ram ram = new Ram()
            {
                IdRam = Id,
                Tenram = name,
                Bus = bus,
                Trangthai = trangThai
            };
            return _repos.UpdateRam(ram);
        }
        public Ram GetOne(int ID)
        {
            return _repos.GetOne(ID);
        }
    }
}
