using DAL.DomainClass;
using DAL.Respository2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service2
{
    public class HoaDonService
    {
        HoaDonRespository _repos = new HoaDonRespository();
        //NhapKhoCTRespository service = new NhapKhoCTRespository();
        public HoaDonService()
        {

        }
        public HoaDonService(HoaDonRespository repos)
        {
            _repos = repos;
        }
        public Hoadon GetOne(int id)
        {
            return _repos.GetOne(id);
        }
        public List<Hoadon> GetAll()
        {
            return _repos.GetAll().ToList();
        }
        public List<Hoadon> GetByString(string name)
        {
            return _repos.GetByString(name);
        }
        public List<Hoadon> GetByDecimal(decimal name)
        {
            return _repos.GetByDecimal(name);
        }
        public List<Hoadon> GetByBool(bool name)
        {
            return _repos.GetByBit(name);
        }
        public List<Hoadon> GetByInt(int name, string key)
        {
            return _repos.GetByInt(name, key);
        }
        public List<Hoadon> GetByDateTime(DateTime Tu, DateTime Den)
        {
            return _repos.GetByDateTime(Tu, Den);
        }
        public bool AddNew(Hoadon hoadon)
        {
            return _repos.Create(hoadon);
        }
        public bool Update(Hoadon hd)
        {

            return _repos.Update(hd);
        }
        public bool delete(int t) { return _repos.Delete(t); }
        //public decimal MoneySum(int id_kho)
        //{
        //    decimal TT = 0;
        //    foreach (var item in service.GetByInt(id_kho, "FK"))
        //    {
        //        TT += item.Gianhap;
        //    }
        //    return TT;
        //}
    }
}
