using BlackJack.EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DAL.Dapper.Interfaces
{
    public interface IPlayerCardRepository
    {
        Task AddCard(Player player, Card card, int currentRound);
        List<PlayerCard> GetAll();
    }
}
