using BlackJack.EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DAL.Dapper.Interfaces
{
    public interface ICardRepository
    {
        Task Insert(Card card);
        Task Delete(int id);
        IEnumerable<Card> Find(Func<Card, bool> predicate);
        Task<Card> GetById(int id);
        Task<IEnumerable<Card>> GetAll();
        bool IsExist();
    }
}
