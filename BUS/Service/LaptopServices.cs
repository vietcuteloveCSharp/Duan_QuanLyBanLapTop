using DAL.DomainClass;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service
{
    public class LaptopServices
    {
        LaptopRepos _repos = new LaptopRepos();

        public LaptopServices()
        {
        }

        public LaptopServices(LaptopRepos repos)
        {
            _repos = repos;
        }
        public List<Laptop> GetAllLaptop()
        {
            return _repos.GetAllLaptop().ToList();
        }
        public List<Laptop> GetLaptopByAll(string name)
        {
            return _repos.GetLaptopByAll(name).ToList();
        }
        public Laptop GetOne(int id)
        {
            return _repos.Getone(id);
        }
        public bool AddNewLaptop(string name, double canNang, string mota, string trangThai, int Idhang)
        {
            var laptop = new Laptop()
            {
                Tenlaptop = name,
                Cannang = canNang,
                Mota = mota,
                Trangthai = trangThai,
                Idhang = Idhang
            };
            return _repos.CreateLaptop(laptop);
        }
        public bool DeleteLaptop(int Id)
        {
            return _repos.DeleteLaptop(Id);
        }
        public bool UpdateLaptop(int Id, string name, double canNang, string mota, string trangThai, int Idhang)
        {
            Laptop laptop = new Laptop()
            {
                IdLt = Id,
                Tenlaptop = name,
                Cannang = canNang,
                Mota = mota,
                Trangthai = trangThai  ,
                Idhang = Idhang
                
            };
            return _repos.UpdateLaptop(laptop);
        }
    }
}
