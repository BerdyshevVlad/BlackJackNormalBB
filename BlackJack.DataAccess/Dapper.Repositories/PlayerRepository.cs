using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.DataAccess.Interfaces;
using BlackJack.Entities;
using Dapper.Contrib.Extensions;

namespace BlackJack.DataAccess.Dapper.Repositories
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(string connectionString) : base(connectionString)
        {
        }

        public async Task<Dictionary<Player, List<Card>>> GetAllCardsFromAllPlayers(int round)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                IEnumerable<Player> playerList = await db.GetAllAsync<Player>();

                Dictionary<Player, List<Card>> playerCardsDictionary = new Dictionary<Player, List<Card>>();

                foreach (var player in playerList.ToList())
                {
                    IEnumerable<Card> cardsList = await GetAllCardsFromPlayer(player.Id, round);
                    playerCardsDictionary.Add(player, cardsList.ToList());
                }

                return playerCardsDictionary;
            }
        }


        public async Task<IEnumerable<Card>> GetAllCardsFromPlayer(int id, int round)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                List<PlayerCard> playerList = await GetPlayerByIdAndByRound(id, round);

                List<Card> cardsList = new List<Card>();
                foreach (var playerCard in playerList)
                {
                    Card card = await db.GetAsync<Card>(playerCard.CardId);
                    cardsList.Add(card);
                }

                return cardsList;
            }
        }

        public async Task<List<PlayerCard>> GetPlayerByIdAndByRound(int id, int round)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                List<PlayerCard> playerList = db.GetAllAsync<PlayerCard>().Result.Where(x => x.PlayerId == id && x.CurrentRound == round).ToList();

                return playerList;
            }
        }

        public async Task<List<PlayerCard>> GetPlayersByRound(int round)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                List<PlayerCard> playerList = db.GetAllAsync<PlayerCard>().Result.Where(x => x.CurrentRound == round).ToList();
                List<PlayerCard> playerListGrouped = playerList.GroupBy(x => x.PlayerId).Select(gr => gr.SingleOrDefault()).ToList();
                return playerListGrouped;
            }
        }
    }
}
