using BlackJack.DAL.Interfaces;
using BlackJack.EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DAL.Repositories
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {

        public PlayerRepository(BlackJackContext context):base(context)
        {

        }


        public async Task AddCard(Player player, Card card, int currentRound)
        {
            Player tmpPlayer = await GetById(player.Id);
            Card tmpCard = await _dbContext.Cards.FindAsync(card.Id);

            var tmpPlayersCards = new PlayerCard();
            tmpPlayersCards.Card = tmpCard;
            tmpPlayersCards.Player = tmpPlayer;
            tmpPlayersCards.CurrentRound = currentRound;

            _dbContext.PlayersCards.Add(tmpPlayersCards);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<List<PlayerCard>> GetPlayerByIdAndByRound(int id, int round)
        {
            List<PlayerCard> playerList = _dbContext.PlayersCards.Where(x => x.PlayerId == id && x.CurrentRound == round).ToList();    //////async

            return playerList;
        }


        public async Task<List<PlayerCard>> GetPlayersByRound(int round)
        {
            List<PlayerCard> playerList = _dbContext.PlayersCards.Where(x => x.CurrentRound == round).ToList();
            var playerList1 = playerList.GroupBy(x => x.PlayerId).Select(gr => gr.FirstOrDefault()).ToList();
            return playerList1;
        }


        public async Task<IEnumerable<Card>> GetAllCardsFromPlayer(int id, int round)
        {
            List<PlayerCard> playerList = await GetPlayerByIdAndByRound(id, round);        ///async

            List<Card> cardsList = new List<Card>();
            foreach (var playerCard in playerList)
            {
                Card card = _dbContext.Cards.Find(playerCard.CardId);           //async
                cardsList.Add(card);
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
    }
}
