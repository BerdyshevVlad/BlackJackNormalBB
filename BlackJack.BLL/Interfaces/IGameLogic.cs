using BlackJack.EntitiesLayer.Entities;
using BlackJack.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.BLL.Interfaces
{
    public interface IGameLogic
    {
        Task<CardViewModel> DrawCard();
        bool IsCardAlreadyDrawned(int randomValue);
        int GenerateRandomValue();
        Task<PlayerViewModel> GiveCardToPlayer(Player player, Card Card);
        int DefineCurrentRound();
        Task<IEnumerable<KeyValuePair<Player, List<Card>>>> DefinePlayersFromLastGame();
        Task<List<PlayerViewModel>> GiveCardToEachPlayer();
        Task<Dictionary<PlayerViewModel, List<CardViewModel>>> HandOverCards();
        Task<Dictionary<PlayerViewModel, int>> GetScoreCount();
        Task<Dictionary<PlayerViewModel, List<CardViewModel>>> TakeCardIfNotEnough(bool takeCard);
        Task<Dictionary<PlayerViewModel, List<CardViewModel>>> PlayAgain(bool takeCard = false);
        Task<bool> IsGameEnded(bool takeCard);
        Task<bool> IsUserBusted();
        Task<Dictionary<PlayerViewModel, List<CardViewModel>>> StartNewRound();
        void CountSum(ref Dictionary<PlayerViewModel, List<CardViewModel>> playerCardsModelDictionary);
        Task<List<PlayerCardsViewModel>> GetHistory();
        //Task<List<RoundViewModel>> GetHistory();
        //Task<Dictionary<int, RoundViewModel>> GetHistory();
    }
}
