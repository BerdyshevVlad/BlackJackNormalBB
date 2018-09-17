using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.DataAccess.Interfaces;
using BlackJack.Entities;

namespace BlackJack.DataAccess.Dapper.Repositories
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(string connectionString) : base(connectionString)
        {

        }

        public Task<Dictionary<Player, List<Card>>> GetAllCardsFromAllPlayers(int round)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Card>> GetAllCardsFromPlayer(int id, int round)
        {
            throw new NotImplementedException();
        }

        public Task<List<PlayerCard>> GetPlayerByIdAndByRound(int id, int round)
        {
            throw new NotImplementedException();
        }

        public Task<List<PlayerCard>> GetPlayersByRound(int round)
        {
            throw new NotImplementedException();
        }
    }
}
