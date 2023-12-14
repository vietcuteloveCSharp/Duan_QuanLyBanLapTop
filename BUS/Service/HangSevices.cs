using DAL.DomainClass;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service
{
    public class HangSevices
    {
        HangRepos _repos = new HangRepos();

        public HangSevices()
        {
        }

        public HangSevices(HangRepos repos)
        {
            _repos = repos;
        }
        public List<Hang> GetAllHang()
        {
            return _repos.GetAllHang();
        }
        public List<Hang> GetHangByAll(string name)
        {
            return _repos.GetHangByAll(name).ToList();
        }
        public bool AddNewHang(string name, string trangThai)
        {
            var hang = new Hang()
            {
                Tenhang = name,
                Trangthai = trangThai
            };
            return _repos.CreateHang(hang);     
        }
        public bool DeleteHang(int Id)
        {
            return _repos.DeleteHang(Id);
        }
        public bool UpdateHang(int Id,  string name, string trangThai)
        {
            Hang hang = new Hang()
            {
                IdHang = Id,
                Tenhang = name,
                Trangthai = trangThai
            };
            return _repos.UpdateHang(hang);
        }
        public Hang GetOne(int ID)
        {
            return _repos.GetOne(ID);
        }
    }
}
