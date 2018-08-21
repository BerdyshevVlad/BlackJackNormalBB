﻿using BlackJack.DAL.Interfaces;
using BlackJack.EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DAL.Repositories
{
    public class PlayerRepository : IPlayerRepository<Player>
    {
        private BlackJackContext _db;

        public PlayerRepository(BlackJackContext context)
        {
            _db = context; 
        }

        public async Task AddCard(Player player, Card card,int currentRound)
        {
            var tmpPlayer = await GetById(player.Id);
            var tmpCard = await _db.Cards.FindAsync(card.Id);

            var tmpPlayersCards = new PlayerCard();
            tmpPlayersCards.Card = tmpCard;
            tmpPlayersCards.Player = tmpPlayer;
            tmpPlayersCards.CurrentRound = currentRound;

            _db.PlayersCards.Add(tmpPlayersCards);
            await _db.SaveChangesAsync();
        }


        public async Task<IEnumerable<PlayerCard>> GetPlayerByIdAndByRound(int id, int round)
        {
            var playerList = await _db.PlayersCards.Where(x => x.PlayerId == id && x.CurrentRound == round).ToListAsync();

            return playerList;
        }


        public async Task<IEnumerable<Card>> GetAllCardsFromPlayer(int id,int round)
        {
            var playerList = await GetPlayerByIdAndByRound(id, round);

            List<Card> cardsList = new List<Card>();
            foreach (var playerCard in playerList)
            {
                Card card = await _db.Cards.FindAsync(playerCard.CardId);
                cardsList.Add(card);
            }

            return cardsList;
        }


        public async Task<Dictionary<Player, List<Card>>> GetAllCardsFromAllPlayers(int round)
        {
            var playerList = await GetAll();

            Dictionary<Player, List<Card>> playerCardsDictionary = new Dictionary<Player, List<Card>>();

            foreach (var player in playerList.ToList())
            {
                var cardsList= await GetAllCardsFromPlayer(player.Id,round);
                playerCardsDictionary.Add(player,cardsList.ToList());
            }
            

            return playerCardsDictionary;
        }


        public async Task Insert(Player player)
        {
            _db.Players.Add(player);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var player = _db.Players.Find(id);

            if(player != null)
            {
                _db.Players.Remove(player);
                await _db.SaveChangesAsync();
            }
        }

        public IEnumerable<Player> Find(Func<Player, bool> predicate)
        {
            var playersList = _db.Players.Where(predicate);
            return playersList;
        }

        public async Task <Player> GetById(int id)
        {
            var player = await _db.Players.FindAsync(id);

            return player;
        }
    

        public async Task<IEnumerable<Player>> GetAll()
        {

            var playersList = await _db.Players.ToListAsync();
            return playersList;
        }

        public async Task Update(Player player)
        {
            _db.Entry(player).State = EntityState.Modified;
            await _db.SaveChangesAsync();

        }
    }
}
