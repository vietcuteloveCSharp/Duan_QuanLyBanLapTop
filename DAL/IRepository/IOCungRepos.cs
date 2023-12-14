using DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    internal interface IOCungRepos
    {
        List<Ocung> GetAllOcung();
        List<Ocung> GetOcungByAll(string name);
        bool CreateOcung(Ocung ocung);
        bool UpdateOcung(Ocung ocung);
    }
}
