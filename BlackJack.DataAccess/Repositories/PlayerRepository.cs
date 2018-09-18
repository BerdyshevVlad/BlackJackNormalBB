using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.DataAccess.Context.MVC;
using BlackJack.DataAccess.Interfaces;
using BlackJack.Entities;

namespace BlackJack.DataAccess.Repositories
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(BlackJackContext context):base(new Context.MVC.BlackJackContext())
        {
        }

        public async Task<List<PlayerCard>> GetPlayerByIdAndByRound(int id, int round)
        {
            List<PlayerCard> playerList = _dbContext.PlayersCards.Where(x => x.PlayerId == id && x.CurrentRound == round).ToList();

            return playerList;
        }


        public async Task<List<PlayerCard>> GetPlayersByRound(int round)
        {
            List<PlayerCard> playerList = _dbContext.PlayersCards.Where(x => x.CurrentRound == round).ToList();
            var playerList1 = playerList.GroupBy(x => x.PlayerId).Select(gr => gr.SingleOrDefault()).ToList();
            return playerList1;
        }


        public async Task<IEnumerable<Card>> GetAllCardsFromPlayer(int id, int round)
        {
            List<PlayerCard> playerList = await GetPlayerByIdAndByRound(id, round);

            List<Card> cardsList = new List<Card>();
            foreach (var playerCard in playerList)
            {
                Card card = _dbContext.Cards.Find(playerCard.CardId);
                cardsList.Add(card);
            }

            return cardsList;

        }


        public async Task<Dictionary<Player, List<Card>>> GetAllCardsFromAllPlayers(int round)
        {
            IEnumerable<Player> playerList = await GetAllAsync();

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
