using DAL.DomainClass;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service
{
    public class OcungServices
    {
        OcungRepos _repos = new OcungRepos();

        public OcungServices()
        {
        }

        public OcungServices(OcungRepos repos)
        {
            _repos = repos;
        }
        public List<Ocung> GetAllOcung()
        {
            return _repos.GetAllOcung().ToList();
        }
        public List<Ocung> GetOcungByAll(string name)
        {
            return _repos.GetOcungByAll(name).ToList();
        }
        public bool AddNewOcung(int dungLuong, string name, string loai)
        {
            var ocung = new Ocung()
            {
                Dungluong = dungLuong,
                Tenocung = name,
                Loai = loai
            };
            return _repos.CreateOcung(ocung);
        }
        public bool UpdateOcung(int Id, int dungLuong, string name, string loai)
        {
            Ocung ocung = new Ocung()
            {
                IdOcung = Id,
                Dungluong = dungLuong,
                Tenocung = name,
                Loai = loai
            };
            return _repos.UpdateOcung(ocung);
        }
        public Ocung GetOne(int ID)
        {
            return _repos.GetOne(ID);
        }
    }
}
