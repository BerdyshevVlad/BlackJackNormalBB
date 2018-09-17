using System.Collections.Generic;
using System.Threading.Tasks;
using BlackJack.Entities;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IPlayerRepository : IBaseRepository<Player>
    {
        Task<IEnumerable<Card>> GetAllCardsFromPlayer(int id, int round);
        Task<Dictionary<Player, List<Card>>> GetAllCardsFromAllPlayers(int round);
        Task<List<PlayerCard>> GetPlayerByIdAndByRound(int id, int round);
        Task<List<PlayerCard>> GetPlayersByRound(int round);
    }
}
