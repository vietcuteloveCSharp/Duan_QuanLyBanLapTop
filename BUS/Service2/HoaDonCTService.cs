using BUS.Service;
using DAL.DomainClass;
using DAL.Respository2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service2
{
    public class HoaDonCTService
    {
        HoaDonCTRespository _repos = new HoaDonCTRespository();
        LapTopCTService _reslapct = new LapTopCTService();
        LaptopServices _resLap = new LaptopServices();
        public HoaDonCTService()
        {
        }
        public List<Hoadonct> GetAll()
        {
            return _repos.GetAll().ToList();
        }
        public List<Hoadonct> GetByString(string name)
        {
            return _repos.GetByString(name);
        }
        public List<Hoadonct> GetByInt(int name, string key)
        {
            return _repos.GetByInt(name, key);
        }
        public List<Hoadonct> GetByDateTime(DateTime Tu, DateTime Den)
        {
            return _repos.GetByDateTime(Tu, Den);
        }
        public bool AddNew(Hoadonct NHCT)
        {

            return _repos.Create(NHCT);
        }
        public bool Update(Hoadonct NHCT)
        {
            return _repos.Update(NHCT);
        }
        public bool Delete(int k) { return _repos.Delete(k); }
        public string GetLapTopName(string Imel)
        {
            int c = (int)_reslapct.Getone(Imel).IdLaptop;
            return _resLap.GetOne(c).Tenlaptop;
        }
    }
}
