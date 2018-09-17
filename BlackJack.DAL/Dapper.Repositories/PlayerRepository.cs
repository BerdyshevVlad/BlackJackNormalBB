﻿using BlackJack.DAL.Dapper.Interfaces;
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
    public class PlayerRepository : IPlayerRepository
    {

        private readonly string _connectionString;

        public PlayerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task AddCard(Player player, Card card, int currentRound)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                Player tmpPlayer = await GetById(player.Id);
                Card tmpCard = db.Query<Card>("SELECT * FROM Cards WHERE Id = @id", new { card.Id }).SingleOrDefault();

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
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<PlayerCard>("SELECT * FROM PlayersCards WHERE PlayerId = @id AND CurrentRound=@round", new { id, round }).ToList();
            }
        }


        public async Task<List<PlayerCard>> GetPlayersByRound(int round)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                List<PlayerCard> playerListTmp = db.Query<PlayerCard>("SELECT * FROM PlayersCards WHERE CurrentRound=@round", new { round }).ToList();
                var playerList = playerListTmp.GroupBy(x => x.PlayerId).Select(gr => gr.FirstOrDefault()).ToList();
                return playerList;
            }
        }


        public async Task<IEnumerable<Card>> GetAllCardsFromPlayer(int id, int round)
        {

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                List<PlayerCard> playerList = await GetPlayerByIdAndByRound(id, round);
                var cardsList = new List<Card>();

                foreach (var playerCard in playerList)
                {
                    Card card = db.Query<Card>("SELECT * FROM Cards  WHERE Id=@CardId", new { playerCard.CardId }).SingleOrDefault();
                    cardsList.Add(card);
                }

                return cardsList;
            }
        }


        public async Task<Dictionary<Player, List<Card>>> GetAllCardsFromAllPlayers(int round)
        {
            IEnumerable<Player> playerList = await GetAll();

            var playerCardsDictionary = new Dictionary<Player, List<Card>>();

            foreach (var player in playerList.ToList())
            {
                IEnumerable<Card> cardsList = await GetAllCardsFromPlayer(player.Id, round);
                playerCardsDictionary.Add(player, cardsList.ToList());
            }

            return playerCardsDictionary;
        }


        public async Task Insert(Player player)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO Players (Name, PlayerType,GameNumber) VALUES(@Name, @PlayerType,@GameNumber)";
                db.Execute(sqlQuery, player);
            }
        }


        public async Task Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "DELETE FROM Players WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }


        public IEnumerable<Player> Find(Func<Player, bool> predicate)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                IEnumerable<Player> players = db.Query<Player>("SELECT * FROM Players").Where(predicate).ToList();
                return players;
            }
        }


        public async Task<Player> GetById(int id)
        {

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var palyer = db.Query<Player>("SELECT * FROM Players WHERE Id = @id", new { id }).SingleOrDefault();
                return palyer;
            }
        }


        public async Task<IEnumerable<Player>> GetAll()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Player>("SELECT * FROM Players").ToList();
            }
        }

        public async Task Update(Player player)
        {

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "UPDATE Cards SET Name=@Name, PlayerType=@PlayerType,GameNumber=@GameNumber WHERE Id = @Id";
                db.Execute(sqlQuery, player);
            }

        }
    }
}
