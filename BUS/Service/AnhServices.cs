using DAL.DomainClass;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BUS.Service
{
    public class AnhServices
    {
        AnhRepos _repos = new AnhRepos();

        public AnhServices()
        {
        }

        public AnhServices(AnhRepos repos)
        {
            _repos = repos;
        }
        public List<Hinhanh> GetAnhByIDLT(int id) { 
        return _repos.GetAllAnh().Where(x => x.Idlaptop ==  id).ToList();
        }
        public List<Hinhanh> GetAllAnh()
        {
            return _repos.GetAllAnh().ToList();
        }
        public bool AddNewAnh(string name, string nguoiTao, DateTime ngayTao, int idLap)
        {
            var anh = new Hinhanh()
            {
                Src = name,
                Nguoitao = nguoiTao,
                Ngaytao = ngayTao,
                Idlaptop = idLap,
                
            };
            return _repos.CreateAnh(anh);
        }
        public bool UpdateAnh(int Id, string name, string nguoiTao, DateTime ngayTao, int idLap)
        {
            Hinhanh anh = new Hinhanh()
            {
                IdHinhanh = Id,
                Src = name,
                Nguoitao = nguoiTao,
                Ngaytao = ngayTao,
                Idlaptop = idLap,
            };
            return _repos.UpdateAnh(anh);
        }
    }
}
