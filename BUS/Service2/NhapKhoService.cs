using DAL.DomainClass;
using DAL.Respository2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service2
{
    public class NhapKhoService
    {
        NhapKhoRespository _repos = new NhapKhoRespository();
        NhapKhoCTRespository service = new NhapKhoCTRespository();
        public NhapKhoService()
        {

        }
        public NhapKhoService(NhapKhoRespository repos)
        {
            _repos = repos;
        }
        public Nhaphang GetOne(int id)
        {
            return _repos.GetOne(id);
        }
        public List<Nhaphang> GetAll()
        {
            return _repos.GetAll().ToList();
        }
        public List<Nhaphang> GetByString(string name)
        {
            return _repos.GetByString(name);
        }
        public List<Nhaphang> GetByInt(int name, string key)
        {
            return _repos.GetByInt(name, key);
        }
        public List<Nhaphang> GetByDateTime(DateTime Tu, DateTime Den)
        {
            return _repos.GetByDateTime(Tu, Den);
        }
        public bool AddNew(Nhaphang NhapHang)
        {
            return _repos.Create(NhapHang);
        }
        public bool Update(Nhaphang NhapHang)
        {
            return _repos.Update(NhapHang);
        }
        public bool delete(int id)
        {
            return _repos.Delete(id);
        }
        public decimal MoneySum(int id_kho)
        {
            decimal TT = 0;
            foreach (var item in service.GetByInt(id_kho,"FK"))
            {
                TT += item.Gianhap;
            }
            return TT;
        }
    }
}
