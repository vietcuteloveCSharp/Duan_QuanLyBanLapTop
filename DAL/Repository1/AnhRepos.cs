
using DAL.Context;
using DAL.IRepository;
using DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class AnhRepos:IAnhRepos
    {
        DBContext _context = new DBContext();

        public AnhRepos()
        {
        }

        public AnhRepos(DBContext context)
        {
            _context = context;
        }

        public bool CreateAnh(Hinhanh anh)
        {
            try
            {
                _context.Hinhanhs.Add(anh);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Hinhanh> GetAllAnh()
        {
            return _context.Hinhanhs.ToList();
        }

        public bool UpdateAnh(Hinhanh anh)
        {
            try
            {
                var updateAnh = _context.Hinhanhs.Find(anh.IdHinhanh);
                if (updateAnh != null)
                {
                    updateAnh.Src = anh.Src;
                    updateAnh.Nguoitao = anh.Nguoitao;
                    updateAnh.Ngaytao = anh.Ngaytao;
                    updateAnh.Idlaptop = anh.Idlaptop;
                    _context.Hinhanhs.Update(updateAnh);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
