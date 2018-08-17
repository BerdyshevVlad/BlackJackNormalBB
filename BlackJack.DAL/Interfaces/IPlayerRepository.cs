using BlackJack.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DAL.Interfaces
{
    public interface IPlayerRepository<T> : IRepository<T> where T : class
    {
        Task AddCard(Player player, Card card, int currentRound);
        Task<IEnumerable<Card>> GetAllCardsFromPlayer(int id);
    }
    
}
