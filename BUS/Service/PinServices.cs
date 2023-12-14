using DAL.DomainClass;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service
{
    public class PinServices
    {
        PinRepos _repos = new PinRepos();

        public PinServices()
        {
        }

        public PinServices(PinRepos repos)
        {
            _repos = repos;
        }
        public List<Pin> GetAllPin()
        {
            return _repos.GetAllPin().ToList();
        }
        public List<Pin> GetPinByAll(string name)
        {
            return _repos.GetPinByAll(name).ToList();
        }
        public bool AddNewPin(string name, int dungLuong,string loaiPin, int han, string trangThai)
        {
            var pin = new Pin()
            {
                Tenpin = name,
                Dungluong = dungLuong,
                Loaipin = loaiPin,
                Thoigiansd = han,
                Trangthai = trangThai
            };
            return _repos.CreatePin(pin);
        }
        public bool UpdatePin(int Id, string name, int dungLuong, string loaiPin, int han, string trangThai)
        {
            Pin pin = new Pin()
            {
                IdPin = Id,
                Tenpin = name,
                Dungluong = dungLuong,
                Loaipin = loaiPin,
                Thoigiansd = han,
                Trangthai = trangThai
            };
            return _repos.UpdatePin(pin);
        }
        public Pin GetOne(int ID)
        {
            return _repos.GetOne(ID);
        }
    }
}
