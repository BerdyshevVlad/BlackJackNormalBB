using BlackJack.DAL.Interfaces;
using BlackJack.EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DAL.Repositories
{
    public class PlayerCardRepository: IPlayerCardRepository
    {
        private BlackJackContext _db;

        public PlayerCardRepository(BlackJackContext context)
        {
            _db = context;
        }

        public async Task AddCard(Player player, Card card, int currentRound)
        {
            var tmpPlayer = await _db.Players.FindAsync(player.Id);
            var tmpCard = await _db.Cards.FindAsync(card.Id);

            var tmpPlayersCards = new PlayerCard();
            tmpPlayersCards.Card = tmpCard;
            tmpPlayersCards.Player = tmpPlayer;
            tmpPlayersCards.CurrentRound = currentRound;

            _db.PlayersCards.Add(tmpPlayersCards);
            await _db.SaveChangesAsync();
        }


        public IEnumerable<PlayerCard> GetAll()
        {
            var playerCardsList=_db.PlayersCards.ToList();
            return playerCardsList;
        }
    }
}
