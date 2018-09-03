using BlackJack.DAL.Interfaces;
using BlackJack.EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DAL.Repositories
{
    public class CardRepository:ICardRepository<Card>
    {
        private readonly BlackJackContext _db;

        public CardRepository(BlackJackContext context)
        {
            _db = context;
        }

        public async Task Insert(Card card)
        {
            _db.Cards.Add(card);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Card card = await _db.Cards.FindAsync(id);

            if (card != null)
            {
                _db.Cards.Remove(card);
                await _db.SaveChangesAsync();
            }
        }

        public IEnumerable<Card> Find(Func<Card, bool> predicate)
        {
            IEnumerable<Card> cardsList = _db.Cards.Where(predicate);
            return cardsList;
        }

        public async Task<Card> GetById(int id)
        {
            Card card = await _db.Cards.FindAsync(id);

            return card;
        }


        public async Task<List<Card>> GetAll()
        {

            List<Card> cardsList = _db.Cards.ToList();
            return cardsList;
        }

        public async Task Update(Card card)
        {
            //_db.Entry(card).State = EntityState.Modified;
            await _db.SaveChangesAsync();

        }
    }
}
