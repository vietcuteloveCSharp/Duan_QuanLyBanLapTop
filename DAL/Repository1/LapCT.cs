using DAL.Context;
using DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Repository1
{
    internal class LapCT
    {
        DBContext _context;
        public LapCT()
        {
            _context = new DBContext();
        }
        public Laptopchitiet GetLapCT(string Imel)
        {
            return _context.Laptopchitiets.FirstOrDefault(x => x.Imel == Imel);
        }
    }
}
