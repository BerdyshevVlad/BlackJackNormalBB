using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IPlayerCardRepository
    {
        Task AddCardAsync(Player player, Card card, int currentRound);
        IEnumerable<PlayerCard> GetAll();
    }
}
