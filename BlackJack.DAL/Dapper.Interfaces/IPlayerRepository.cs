using BlackJack.EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DAL.Dapper.Interfaces
{
    public interface IPlayerRepository
    {
        Task AddCard(Player player, Card card, int currentRound);
        Task<List<PlayerCard>> GetPlayerByIdAndByRound(int id, int round);
        Task<List<PlayerCard>> GetPlayersByRound(int round);
        Task<IEnumerable<Card>> GetAllCardsFromPlayer(int id, int round);
        Task<Dictionary<Player, List<Card>>> GetAllCardsFromAllPlayers(int round);
        Task Insert(Player player);
        Task Delete(int id);
        IEnumerable<Player> Find(Func<Player, bool> predicate);
        Task<Player> GetById(int id);
        Task<IEnumerable<Player>> GetAll();
        Task Update(Player player);
    }
}
