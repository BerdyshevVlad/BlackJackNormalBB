using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.DataAccess.Context.Core;
using BlackJack.DataAccess.Interfaces;
using BlackJack.Entities;

namespace BlackJack.DataAccess.Repositories
{
    public class PlayerCardRepository : IPlayerCardRepository
    {
        private readonly BlackJackContext _db;

        public PlayerCardRepository(BlackJackContext context)
        {
            _db = context;
        }



        public async Task AddCardAsync(Player player, Card card, int currentRound)
        {
            Player tmpPlayer = await _db.Players.FindAsync(player.Id);
            Card tmpCard = await _db.Cards.FindAsync(card.Id);

            var tmpPlayersCards = new PlayerCard();
            tmpPlayersCards.Card = tmpCard;
            tmpPlayersCards.Player = tmpPlayer;
            tmpPlayersCards.CurrentRound = currentRound;

            await _db.PlayersCards.AddAsync(tmpPlayersCards);
            await _db.SaveChangesAsync();
        }


        public List<PlayerCard> GetAll()
        {
            List<PlayerCard> playerCardsList = _db.PlayersCards.ToList();
            return playerCardsList;
        }
    }
}
