using DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    internal interface IKhachHangRepos
    {
        List<Khachhang> GetAllKH();
        List<Khachhang> GetKHBYAll(string name);
        bool CreateKH(Khachhang khachHang);
        bool DeleteKH(int Id);
        bool UpdateKH(Khachhang khachHang);
    }
}
