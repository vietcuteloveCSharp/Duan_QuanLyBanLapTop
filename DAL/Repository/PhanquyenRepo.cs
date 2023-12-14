
using DAL.Context;
using DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    
    public class PhanquyenRepo
    {
        DBContext db;
        public PhanquyenRepo()
        {
            db = new DBContext();
        }
        public List<Phanquyen> GetPhanQuyen()
        {
             return db.Phanquyens.ToList();
            
        }
    }
}
