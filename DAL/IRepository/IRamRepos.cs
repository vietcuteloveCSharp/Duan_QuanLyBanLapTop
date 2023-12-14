using DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    internal interface IRamRepos
    {
        List<Ram> GetAllRam();
        List<Ram> GetRamByAll(string name);
        bool CreateRam(Ram ram);
        bool DeleteRam(int Id);
        bool UpdateRam(Ram ram);
    }
}
