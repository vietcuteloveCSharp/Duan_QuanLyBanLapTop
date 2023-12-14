using DAL.DomainClass;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service
{
    public class CardServices
    {
        CardRepos _repos = new CardRepos();

        public CardServices()
        {
        }

        public CardServices(CardRepos repos)
        {
            _repos = repos;
        }
        public List<Carddohoa> GetAllCard()
        {
            return _repos.GetAllCard().ToList();
        }
        public List<Carddohoa> GetCardByAll(string name)
        {
            return _repos.GetCardByAll(name).ToList();
        }
        public bool AddNewCard(string name, int dungLuong, string trangThai)
        {
            var card = new Carddohoa()
            {
                Tencard = name,
                Dungluong = dungLuong,
                Trangthai = trangThai
            };
            return _repos.CreateCard(card);
        }
        public bool UpdateCard(int Id, string name,int dungLuong, string trangThai)
        {
            Carddohoa card = new Carddohoa()
            {
                IdCarddohoa = Id,
                Tencard = name,
                Dungluong = dungLuong,
                Trangthai = trangThai
            };
            return _repos.UpdateCard(card);
        }
        public Carddohoa GetOne(int ID)
        {
            return _repos.GetOne(ID);
        }
    }
}
