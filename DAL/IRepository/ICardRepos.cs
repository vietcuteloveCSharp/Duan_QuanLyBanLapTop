using DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    internal interface ICardRepos
    {
        List<Carddohoa> GetAllCard();
        List<Carddohoa> GetCardByAll(string name);
        bool CreateCard(Carddohoa card);
        bool UpdateCard(Carddohoa card);
    }
}
