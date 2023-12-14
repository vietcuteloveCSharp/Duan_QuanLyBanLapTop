using DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    internal interface IPinRepos
    {
        List<Pin> GetAllPin();
        List<Pin> GetPinByAll(string name);
        bool CreatePin(Pin pin);
        bool UpdatePin(Pin pin);
    }
}
