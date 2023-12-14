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
    public class NhapKhoCTService
    {
        NhapKhoCTRespository _repos = new NhapKhoCTRespository();
        LapTopCTService _reslapct = new LapTopCTService();
        LaptopServices _resLap = new LaptopServices();
        public NhapKhoCTService()
        {           
        }
        public List<Nhaphangchitiet> GetAll()
        {
            return _repos.GetAll().ToList();
        }
        public List<Nhaphangchitiet> GetByString(string name)
        {
            return _repos.GetByString(name);
        }
        public List<Nhaphangchitiet> GetByInt(int name, string key)
        {
            return _repos.GetByInt(name, key);
        }
        public List<Nhaphangchitiet> GetByDateTime(DateTime Tu, DateTime Den)
        {
            return _repos.GetByDateTime(Tu, Den);
        }
        public bool AddNew(Nhaphangchitiet NHCT)
        {
            
            return _repos.Create(NHCT);
        }
        public bool Update(Nhaphangchitiet NHCT)
        {
            return _repos.Update(NHCT);
        }
        public bool Delete(int k) {  return _repos.Delete(k); }
        public string GetLapTopName(string Imel)
        {
            int c = (int)_reslapct.Getone(Imel).IdLaptop;
            return _resLap.GetOne(c).Tenlaptop;
        }
    }
}
