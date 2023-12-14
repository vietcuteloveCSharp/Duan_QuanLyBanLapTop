using DAL.DomainClass;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service
{
    public class KhachHangServices
    {
        KhachHangRepos _repos = new KhachHangRepos();

        public KhachHangServices()
        {
        }

        public KhachHangServices(KhachHangRepos repos)
        {
            _repos = repos;
        }
        public List<Khachhang> GetAllKH()
        {
            return _repos.GetAllKH().ToList();
        }
        public List<Khachhang> GetKHByAll(string name)
        {
            return _repos.GetKHBYAll(name).ToList();
        }
        public bool AddNewKH(string name, string diaChi, string sdt, string email)
        {
            var khachHang = new Khachhang()
            {
                Tenkh = name,
                Diachi = diaChi,
                Dienthoai = sdt,
                Email = email
            };
            return _repos.CreateKH(khachHang);
        }
        public bool DeleteKH(int Id)
        {
            return _repos.DeleteKH(Id);
        }
        public bool UpdateKH(int Id, string name, string diaChi, string sdt, string email)
        {
            Khachhang khachhang = new Khachhang()
            {
                IdKhachhang = Id,
                Tenkh = name,
                Diachi = diaChi,    
                Dienthoai = sdt,
                Email = email
            };
            return _repos.UpdateKH(khachhang);
        }
        public Khachhang GetOne(int id)
        {
            return _repos.GetAllKH().FirstOrDefault(x => x.IdKhachhang == id);
        }
    }
}
