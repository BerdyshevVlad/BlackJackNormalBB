using BlackJack.DAL.Interfaces;
using BlackJack.EntitiesLayer.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DAL.Repositories
{
    public class PlayerRepository : IPlayerRepository<Player>
    {

        string connectionString = null;

        public PlayerRepository(string conn)
        {
            connectionString = conn;
        }

        //private readonly BlackJackContext _db;

        //public PlayerRepository(BlackJackContext context)
        //{
        //    _db = context; 
        //}

        public async Task AddCard(Player player, Card card, int currentRound)
        {
            //Player tmpPlayer = await GetById(player.Id);
            //Card tmpCard = await _db.Cards.FindAsync(card.Id);

            //var tmpPlayersCards = new PlayerCard();
            //tmpPlayersCards.Card = tmpCard;
            //tmpPlayersCards.Player = tmpPlayer;
            //tmpPlayersCards.CurrentRound = currentRound;

            //_db.PlayersCards.Add(tmpPlayersCards);
            //await _db.SaveChangesAsync();


            Player tmpPlayer = await GetById(player.Id);
            Card tmpCard = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                tmpCard = db.Query<Card>("SELECT * FROM Cards WHERE Id = @id", new { card.Id }).FirstOrDefault();

                var tmpPlayersCards = new PlayerCard();
                tmpPlayersCards.Card = tmpCard;
                tmpPlayersCards.Player = tmpPlayer;
                tmpPlayersCards.CurrentRound = currentRound;

                var sqlQuery = "INSERT INTO PlayersCards (CardId, Card,PlayerId,Player,CurrentRound) VALUES(@CardId, @Card,@PlayerId,@Player,@CurrentRound)";
                db.Execute(sqlQuery, tmpPlayersCards);
            }
        }


        public async Task<List<PlayerCard>> GetPlayerByIdAndByRound(int id, int round)
        {
            //List<PlayerCard> playerList =  _db.PlayersCards.Where(x => x.PlayerId == id && x.CurrentRound == round).ToList();    //////async

            //return playerList;

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<PlayerCard>("SELECT * FROM PlayersCards WHERE PlayerId = @id AND CurrentRound=@round", new { id, round }).ToList();
            }
        }


        public async Task<List<PlayerCard>> GetPlayersByRound(int round)
        {
            //List<PlayerCard> playerList =_db.PlayersCards.Where(x => x.CurrentRound == round).ToList();
            //var playerList1 = playerList.GroupBy(x => x.PlayerId).Select(gr=>gr.FirstOrDefault()).ToList();
            //return playerList1;


            using (IDbConnection db = new SqlConnection(connectionString))
            {
                List<PlayerCard> playerList = db.Query<PlayerCard>("SELECT * FROM PlayersCards WHERE CurrentRound=@round", new { round }).ToList();
                var playerList1 = playerList.GroupBy(x => x.PlayerId).Select(gr => gr.FirstOrDefault()).ToList();
                return playerList1;
            }
        }


        public async Task<IEnumerable<Card>> GetAllCardsFromPlayer(int id, int round)
        {
            //List<PlayerCard> playerList = await GetPlayerByIdAndByRound(id, round);        ///async

            //List<Card> cardsList = new List<Card>();
            //foreach (var playerCard in playerList)
            //{
            //    Card card =  _db.Cards.Find(playerCard.CardId);           //async
            //    cardsList.Add(card);
            //}

            //return cardsList;



            List<PlayerCard> playerList = await GetPlayerByIdAndByRound(id, round);
            List<Card> cardsList = new List<Card>();
            foreach (var playerCard in playerList)
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    Card card = db.Query<Card>("SELECT * FROM Cards  WHERE Id=@CardId", new { playerCard.CardId }).FirstOrDefault();
                    cardsList.Add(card);
                }
            }

            return cardsList;
        }


        public async Task<Dictionary<Player, List<Card>>> GetAllCardsFromAllPlayers(int round)
        {
            IEnumerable<Player> playerList = await GetAll();

            Dictionary<Player, List<Card>> playerCardsDictionary = new Dictionary<Player, List<Card>>();

            foreach (var player in playerList.ToList())
            {
                IEnumerable<Card> cardsList = await GetAllCardsFromPlayer(player.Id, round);
                playerCardsDictionary.Add(player, cardsList.ToList());
            }

            return playerCardsDictionary;
        }


        public async Task Insert(Player player)
        {
            //_db.Players.Add(player);
            //await _db.SaveChangesAsync();

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Players (Name, PlayerType,GameNumber) VALUES(@Name, @PlayerType,@GameNumber)";
                db.Execute(sqlQuery, player);
            }
        }

        public async Task Delete(int id)
        {
            //Player player = _db.Players.Find(id);

            //if(player != null)
            //{
            //    _db.Players.Remove(player);
            //    await _db.SaveChangesAsync();
            //}


            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Players WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public IEnumerable<Player> Find(Func<Player, bool> predicate)
        {
            //IEnumerable<Player> playersList = _db.Players.Where(predicate);
            //return playersList;

            IEnumerable<Player> players = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                players = db.Query<Player>("SELECT * FROM Players").Where(predicate).ToList();
            }
            return players;
        }

        public async Task<Player> GetById(int id)
        {
            //Player player = await _db.Players.FindAsync(id);

            //return player;

            Player palyer = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                palyer = db.Query<Player>("SELECT * FROM Players WHERE Id = @id", new { id }).FirstOrDefault();
            }
            return palyer;
        }


        public async Task<IEnumerable<Player>> GetAll()
        {

            //List<Player> playersList = _db.Players.ToList();
            //return playersList;


            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Player>("SELECT * FROM Players").ToList();
            }
        }

        public async Task Update(Player player)
        {
            ////_db.Entry(player).State = EntityState.Modified;
            //await _db.SaveChangesAsync();

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Cards SET Name=@Name, PlayerType=@PlayerType,GameNumber=@GameNumber WHERE Id = @Id";
                db.Execute(sqlQuery, player);
            }

        }

    }
}
