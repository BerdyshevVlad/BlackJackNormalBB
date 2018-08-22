using BlackJack.DAL.Interfaces;
using BlackJack.DAL.Repositories;
using BlackJack.EntitiesLayer.Entities;
using BlackJack.Mappers;
using BlackJack.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.BLL.Services
{
    public class GameLogicService
    {
        private readonly ICardRepository<Card> _cardRepository;
        private readonly IPlayerRepository<Player> _playerRepository;
        private readonly IPlayerCardRepository _playerCardRepository;


        private int _round;
        private string _personPlayerType = "Person";
        private List<int> __drawnedCardId;


        public GameLogicService()
        {
            _cardRepository = new CardRepository(new DAL.BlackJackContext());
            _playerRepository = new PlayerRepository(new DAL.BlackJackContext());
            _playerCardRepository = new PlayerCardRepository(new DAL.BlackJackContext());
            _round = DefineCurrentRound();
            __drawnedCardId = new List<int>();
        }


        public async Task<CardViewModel> DrawCard()
        {

            int randomValue = GenerateRandomValue();
            bool isCurrentCardDrawned = IsCardAlreadyDrawned(randomValue);

            for (; isCurrentCardDrawned == true;)
            {
                randomValue = GenerateRandomValue();
                isCurrentCardDrawned = IsCardAlreadyDrawned(randomValue);
            }

            __drawnedCardId.Add(randomValue);
            Card card = await _cardRepository.GetById(randomValue);
            CardViewModel cardModel = Mapp.MappCard(card);

            return cardModel;
        }


        public bool IsCardAlreadyDrawned(int randomValue)
        {
            bool isCurrentCardDrawned = __drawnedCardId.Any(x => x == randomValue);
            return isCurrentCardDrawned;
        }


        public int GenerateRandomValue()
        {
            int minDeckValue = 1;
            int maxDeckValue = 52;
            var random = new Random();

            int randomValue = random.Next(minDeckValue, maxDeckValue);
            return randomValue;
        }

        public async Task<PlayerViewModel> GiveCardToPlayer(Player player, Card Card)
        {
            Player playerTmp = await _playerRepository.GetById(player.Id);
            Card cardTmp = await _cardRepository.GetById(Card.Id);


            await _playerCardRepository.AddCard(playerTmp, cardTmp, _round);

            PlayerViewModel playerModel = Mapp.MappPlayer(playerTmp);

            return playerModel;
        }


        public int DefineCurrentRound()
        {
            int _currentRound = 0;
            try
            {
                List<PlayerCard> gamePlayersList = _playerCardRepository.GetAll();
                int maxRound = gamePlayersList.Max(x => x.CurrentRound);
                if (maxRound > 0)
                {
                    _currentRound = maxRound;
                }
            }
            catch
            {

                _currentRound = 0;
            }

            return _currentRound;
        }


        public async Task<List<PlayerViewModel>> GiveCardToEachPlayer()
        {
            List<Player> playersList = await _playerRepository.GetAll();

            var playerModelList = new List<PlayerViewModel>();

            foreach (var player in playersList.ToList())
            {
                CardViewModel drawnedCard = await DrawCard();
                Card card = Mapp.MappCardModel(drawnedCard);
                PlayerViewModel playerModel = await GiveCardToPlayer(player, card);
                playerModelList.Add(playerModel);
            }

            return playerModelList;
        }


        public async Task<Dictionary<PlayerViewModel, List<CardViewModel>>> HandOverCards()
        {
            int handOverCount = 2;

            List<PlayerViewModel> playerModelList = null;

            for (int i = 0; i < handOverCount; i++)
            {
                playerModelList = await GiveCardToEachPlayer();
            }

            Dictionary < Player, List<Card>> playerCardsDictionary = await _playerRepository.GetAllCardsFromAllPlayers(_round);
            Dictionary<PlayerViewModel, List<CardViewModel>> playerCardsModelDictionary = Mapp.MappPlayerModel(playerCardsDictionary);

            CountSum(ref playerCardsModelDictionary);

            return playerCardsModelDictionary;
        }


        public async Task<Dictionary<PlayerViewModel, int>> GetScoreCount()
        {

            Dictionary < Player, List<Card>> playerCards = await _playerRepository.GetAllCardsFromAllPlayers(_round);
            var playerScore = new Dictionary<PlayerViewModel, int>();
            foreach (var player in playerCards.Keys)
            {
                IEnumerable<Card> cardsList = await _playerRepository.GetAllCardsFromPlayer(player.Id, _round);
                int score = cardsList.ToList().Sum(card => card.Value);
                PlayerViewModel playerModel = Mapp.MappPlayer(player);
                playerScore.Add(playerModel, score);
            }

            return playerScore;
        }


        public async Task<Dictionary<PlayerViewModel, List<CardViewModel>>> TakeCardIfNotEnough(bool takeCard)
        {
             Dictionary<PlayerViewModel, int> playerScore = await GetScoreCount();
            foreach (var ps in playerScore)
            {
                if (ps.Value < 17 && ps.Key.PlayerType != _personPlayerType)
                {
                    Player player = await _playerRepository.GetById(ps.Key.Id);
                    CardViewModel cardModel = await DrawCard();
                    Card card = Mapp.MappCardModel(cardModel);
                    await GiveCardToPlayer(player, card);
                }
                if (ps.Key.PlayerType == _personPlayerType && takeCard == true)
                {
                    Player player = await _playerRepository.GetById(ps.Key.Id);
                    CardViewModel cardModel = await DrawCard();
                    Card card = Mapp.MappCardModel(cardModel);
                    await GiveCardToPlayer(player, card);
                }
            }

            Dictionary<Player, List<Card>> playerCards = await _playerRepository.GetAllCardsFromAllPlayers(_round);
            Dictionary<PlayerViewModel, List<CardViewModel>> playerCardsModelDictionary = Mapp.MappPlayerModel(playerCards);

            return playerCardsModelDictionary;
        }


        public async Task<Dictionary<PlayerViewModel, List<CardViewModel>>> PlayAgain(bool takeCard=false)
        {
            bool isGameEnded = false;

            isGameEnded = await IsGameEnded(takeCard);
            for (; isGameEnded == false;)
            {
                if (takeCard == true && await IsUserBusted()==false)
                {
                    await TakeCardIfNotEnough(takeCard);
                    isGameEnded = await IsGameEnded(takeCard);
                    if (await IsUserBusted() == false)
                    {
                        break;
                    }
                    if(await IsUserBusted() == true)
                    {
                        takeCard = false;
                    }
                }
                if (takeCard == false)
                {
                    await TakeCardIfNotEnough(takeCard);
                    isGameEnded = await IsGameEnded(takeCard);
                }
            }

            Dictionary<Player, List<Card>> playerCards = await _playerRepository.GetAllCardsFromAllPlayers(_round);
            Dictionary<PlayerViewModel, List<CardViewModel>> playerCardsModel = Mapp.MappPlayerModel(playerCards);

            CountSum(ref playerCardsModel);

            return playerCardsModel;
        }


        public async Task<bool> IsGameEnded(bool takeCard)
        {
            Dictionary<PlayerViewModel,int> scors = await GetScoreCount();
            bool isGameEnded = false;
            var cardCount = new List<int>();

            foreach (var playerScore in scors.Where(x => x.Key.PlayerType != _personPlayerType))
            {
                int scoreValue = playerScore.Value;
                cardCount.Add(scoreValue);
            }

            isGameEnded = cardCount.TrueForAll(c => c >= 17);
            int personPlayerScorsSum = scors.Where(x => x.Key.PlayerType == _personPlayerType).Sum(x => x.Value);
            if (personPlayerScorsSum < 21 && takeCard!=false)
            {
                isGameEnded = false;
            }

            return isGameEnded;
        }


        public async Task<bool> IsUserBusted()
        {
            int scorMaxMalue = 21;

            Dictionary<PlayerViewModel, int> scors = await GetScoreCount();
            int personPlayerScorsSum = scors.Where(x => x.Key.PlayerType == _personPlayerType).Sum(x => x.Value);
            if (personPlayerScorsSum >= scorMaxMalue)
            {
                return true;
            }

            return false;
        }


        public async Task<Dictionary<PlayerViewModel, List<CardViewModel>>> StartNewRound()
        {
            _round++;
            await HandOverCards();

            Dictionary<Player, List<Card>> playerCards = await _playerRepository.GetAllCardsFromAllPlayers(_round);
            Dictionary<PlayerViewModel, List<CardViewModel>> playerCardsModel = Mapp.MappPlayerModel(playerCards);

            CountSum(ref playerCardsModel);

            return playerCardsModel;
        }


        public void CountSum(ref Dictionary<PlayerViewModel, List<CardViewModel>> playerCardsModelDictionary)
        {
            foreach (var playerCards in playerCardsModelDictionary)
            {
                playerCards.Key.Score = playerCards.Value.Sum(cardModel => cardModel.Value);
            }
        }
    }
}
