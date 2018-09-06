using BlackJack.DAL.Interfaces;
using BlackJack.EntitiesLayer.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DAL.Repositories
{
    public class PlayerCardRepository : IPlayerCardRepository
    {

        string connectionString = null;

        public PlayerCardRepository(string conn)
        {
            connectionString = conn;
        }


        //private readonly BlackJackContext _db;

        //public PlayerCardRepository(BlackJackContext context)
        //{
        //    _db = context;
        //}



        public async Task AddCard(Player player, Card card, int currentRound)
        {
            //Player tmpPlayer = await _db.Players.FindAsync(player.Id);
            //Card tmpCard = await _db.Cards.FindAsync(card.Id);

            //var tmpPlayersCards = new PlayerCard();
            //tmpPlayersCards.Card = tmpCard;
            //tmpPlayersCards.Player = tmpPlayer;
            //tmpPlayersCards.CurrentRound = currentRound;

            //await _db.PlayersCards.AddAsync(tmpPlayersCards);
            //await _db.SaveChangesAsync();


            Player tmpPlayer;
            Card tmpCard;

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                tmpPlayer = db.Query<Player>("SELECT * FROM Players WHERE Id = @id", new { player.Id }).FirstOrDefault();
                tmpCard = db.Query<Card>("SELECT * FROM Cards WHERE Id = @id", new { card.Id }).FirstOrDefault();

                var tmpPlayerCard = new PlayerCard();
                tmpPlayerCard.CardId = tmpCard.Id;
                //tmpPlayerCard.Card = tmpCard;
                //tmpPlayerCard.Player = tmpPlayer;
                tmpPlayerCard.PlayerId = tmpPlayer.Id;
                tmpPlayerCard.CurrentRound = currentRound;

                var sqlQuery = "INSERT INTO PlayersCards (CardId,PlayerId,CurrentRound) VALUES( @CardId, @PlayerId, @CurrentRound)";
                db.Execute(sqlQuery, tmpPlayerCard);
            }
        }


        public List<PlayerCard> GetAll()
        {
            //List<PlayerCard> playerCardsList=_db.PlayersCards.ToList();
            //return playerCardsList;


            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<PlayerCard>("SELECT * FROM PlayersCards").ToList();
            }
        }
    }
}
