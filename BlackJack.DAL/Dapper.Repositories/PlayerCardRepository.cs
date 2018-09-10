using BlackJack.DAL.Dapper.Interfaces;
using BlackJack.EntitiesLayer.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DAL.Dapper.Repositories
{
    public class PlayerCardRepository: IPlayerCardRepository
    {
        string _connectionString = null;

        public PlayerCardRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task AddCard(Player player, Card card, int currentRound)
        {
            Player tmpPlayer;
            Card tmpCard;

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                tmpPlayer = db.Query<Player>("SELECT * FROM Players WHERE Id = @id", new { player.Id }).FirstOrDefault();
                tmpCard = db.Query<Card>("SELECT * FROM Cards WHERE Id = @id", new { card.Id }).FirstOrDefault();

                var tmpPlayerCard = new PlayerCard();
                tmpPlayerCard.CardId = tmpCard.Id;
                tmpPlayerCard.PlayerId = tmpPlayer.Id;
                tmpPlayerCard.CurrentRound = currentRound;

                var sqlQuery = "INSERT INTO PlayersCards (CardId,PlayerId,CurrentRound) VALUES( @CardId, @PlayerId, @CurrentRound)";
                db.Execute(sqlQuery, tmpPlayerCard);
            }
        }

        public List<PlayerCard> GetAll()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<PlayerCard>("SELECT * FROM PlayersCards").ToList();
            }
        }
    }
}
