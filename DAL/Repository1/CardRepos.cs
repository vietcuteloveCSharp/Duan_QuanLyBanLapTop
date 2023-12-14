using DAL.IRepository;
using DAL.Context;
using DAL.DomainClass;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class CardRepos : ICardRepos
    {
        DBContext _context = new DBContext();

        public CardRepos()
        {
        }

        public CardRepos(DBContext context)
        {
            _context = context;
        }

        public bool CreateCard(Carddohoa card)
        {

            try
            {
                _context.Carddohoas.Add(card);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Carddohoa> GetAllCard()
        {
            return _context.Carddohoas.ToList();
        }

        public List<Carddohoa> GetCardByAll(string name)
        {
            return _context.Carddohoas.Where(p => p.Tencard.Contains(name) || p.Trangthai.Contains(name)).ToList();
        }

        public bool UpdateCard(Carddohoa card)
        {
            try
            {
                var updateCard = _context.Carddohoas.Find(card.IdCarddohoa);
                if (updateCard != null)
                {
                    updateCard.Tencard = card.Tencard;
                    updateCard.Dungluong = card.Dungluong;
                    updateCard.Trangthai = card.Trangthai;
                    _context.Carddohoas.Update(updateCard);
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
        public Carddohoa GetOne(int ID)
        {
            return _context.Carddohoas.FirstOrDefault(x => x.IdCarddohoa == ID);
        }
    }
}
