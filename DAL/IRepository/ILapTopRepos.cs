using DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    internal interface ILapTopRepos
    {
        List<Laptop> GetAllLaptop();
        List<Laptop> GetLaptopByAll(string name);
        bool CreateLaptop(Laptop laptop);
        bool DeleteLaptop(int Id);
        bool UpdateLaptop(Laptop laptop);
    }
}
