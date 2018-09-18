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
    public class PlayerCardRepository :BaseRepository<PlayerCard>, IPlayerCardRepository
    {
        public PlayerCardRepository(string connectionString) : base(connectionString)
        {

        }

        public async Task AddCardAsync(Player player, Card card, int currentRound)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                Player tmpPlayer = await db.GetAsync<Player>(player.Id);
                Card tmpCard = await db.GetAsync<Card>(card.Id);

                var tmpPlayersCards = new PlayerCard();
                tmpPlayersCards.Card = tmpCard;
                tmpPlayersCards.Player = tmpPlayer;
                tmpPlayersCards.CurrentRound = currentRound;

                await db.InsertAsync(tmpPlayersCards);
            }
        }

        public IEnumerable<PlayerCard> GetAll()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                try
                {
                    IEnumerable<PlayerCard> playerCardsList =db.GetAll<PlayerCard>();
                    return playerCardsList;
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    return null;
                }
            }
        }
    }
}
