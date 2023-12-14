using DAL.IRepository;
using DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Context;

namespace DAL.Repository
{
    public class OcungRepos:IOCungRepos
    {
        DBContext _context = new DBContext();

        public OcungRepos()
        {
        }

        public OcungRepos(DBContext context)
        {
            _context = context;
        }

        public bool CreateOcung(Ocung ocung)
        {
            try
            {
                _context.Ocungs.Add(ocung);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Ocung> GetAllOcung()
        {
            return _context.Ocungs.ToList();
        }

        public List<Ocung> GetOcungByAll(string name)
        {
            return _context.Ocungs.Where(p => p.Tenocung.Contains(name) || p.Loai.Contains(name)).ToList();
        }

        public bool UpdateOcung(Ocung ocung)
        {
            try
            {
                var updateOcung = _context.Ocungs.Find(ocung.IdOcung);
                if (updateOcung != null)
                {
                    updateOcung.Dungluong = ocung.Dungluong;
                    updateOcung.Tenocung = ocung.Tenocung;
                    updateOcung.Loai = ocung.Loai;
                    _context.Ocungs.Update(updateOcung);
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
        public Ocung GetOne(int ID)
        {
            return _context.Ocungs.FirstOrDefault(x => x.IdOcung == ID);
        }
    }
}
