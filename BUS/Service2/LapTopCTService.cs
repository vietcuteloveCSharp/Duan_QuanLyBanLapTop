using DAL.DomainClass;
using DAL.Respository2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service2
{
    public class LapTopCTService
    {
        LapTopCTRespository _respo = new LapTopCTRespository();
        public LapTopCTService()
        {
            
        }
        public List<Laptopchitiet> GetAll() { return _respo.GetAll(); }
        

       
        public List<Laptopchitiet> GetByString(string name)
        {
            return _respo.GetByString(name);
        }
        public List<Laptopchitiet> GetByInt(int name, string key)
        {
            return _respo.GetByInt(name, key);
        }
        public List<Laptopchitiet> GetByDateTime(DateTime Tu, DateTime Den)
        {
            return _respo.GetByDateTime(Tu, Den);
        }
        public bool AddNew(Laptopchitiet NHCT)
        {

            return _respo.Create(NHCT);
        }
        public bool Update(Laptopchitiet NHCT)
        {
            return _respo.Update(NHCT);
        }
        public Laptopchitiet Getone(string imel)
        {
            return _respo.GetOne(imel);
        }
    }
}
