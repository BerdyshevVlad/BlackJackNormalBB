using BlackJack.DAL.Entities;
using BlackJack.DAL.Repositories;
using BlackJack.DTO;
using BlackJack.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.BLL.Services
{
    public class GameLogicService
    {
        CardRepository _cardRepository;
        PlayerRepository _playerRepository;
        PlayerCardRepository _playerCardRepository;
        List<int> _drawnedCardId = new List<int>();
        int _round;
        public GameLogicService()
        {
            _cardRepository = new CardRepository(new DAL.BlackJackContext());
            _playerRepository = new PlayerRepository(new DAL.BlackJackContext());
            _playerCardRepository = new PlayerCardRepository(new DAL.BlackJackContext());
            _round = DefineCurrentRound();
        }


        public async Task<CardViewModel> DrawCard()
        {

            var randomValue = GenerateRandomValue();
            bool isCurrentCardDrawned = IsCardAlreadyDrawned(randomValue);

            for (;isCurrentCardDrawned == true;)
            {
                randomValue = GenerateRandomValue();
                isCurrentCardDrawned = isCurrentCardDrawned = IsCardAlreadyDrawned(randomValue);
            }

            _drawnedCardId.Add(randomValue);
            Card card = await _cardRepository.GetById(randomValue);
            CardViewModel cardModel = Mapp.MappCard(card);

            return cardModel;
        }


        public bool IsCardAlreadyDrawned(int randomValue)
        {
            bool isCurrentCardDrawned = _drawnedCardId.Any(x => x == randomValue);
            return isCurrentCardDrawned;
        }


        public int GenerateRandomValue()
        {
            int minDeckValue = 1;
            int maxDeckValue = 52;
            Random random = new Random();

            var randomValue = random.Next(minDeckValue, maxDeckValue);
            return randomValue;
        }

        public async Task<PlayerViewModel> GiveCardToPlayer(Player player, Card Card)
        {
            Player playerTmp = await _playerRepository.GetById(player.Id);
            Card cardTmp = await _cardRepository.GetById(Card.Id);

            
            await _playerCardRepository.AddCard(playerTmp, cardTmp,_round);   //?????????????????????

            PlayerViewModel playerModel = Mapp.MappPlayer(playerTmp);

            return playerModel;
        }


        public int DefineCurrentRound()
        {
            int _currentRound = 0;
            try
            {
                var gamePlayersList = _playerCardRepository.GetAll();
                var maxRound = gamePlayersList.Max(x => x.CurrentRound);
                if (maxRound> 0)
                {
                    _currentRound = maxRound + 1;
                }
            }
            catch
            {

                _currentRound=1;
            }

            return _currentRound;
        }


        public async Task<List<PlayerViewModel>> GiveCardToEachPlayer()
        {
            var playersList = await _playerRepository.GetAll();

            List<PlayerViewModel> playerModelList=new List<PlayerViewModel>();

            foreach (var player in playersList.ToList())
            {
                CardViewModel drawnedCard = await DrawCard();
                Card card = Mapp.MappCardModel(drawnedCard);
                PlayerViewModel playerModel = await GiveCardToPlayer(player, card);
                playerModelList.Add(playerModel);
            }

            return playerModelList;
        }


        //public async Task<List<PlayerViewModel>> HandOverCards()
        public async Task<Dictionary<Player,List<Card>>> HandOverCards()
        {
            int handOverCount = 2;

            List<PlayerViewModel> playerModelList=null;

            for (int i = 0; i < handOverCount; i++)
            {
                playerModelList = await GiveCardToEachPlayer();
            }

            var playerModelDictionary=await _playerRepository.GetAllCardsFromAllPlayers();

            return playerModelDictionary;

            //return playerModelList;
        }


        public async Task<Dictionary<PlayerViewModel, int>> GetScoreCount()
        {

            var playerCards= await _playerRepository.GetAllCardsFromAllPlayers();
            Dictionary<PlayerViewModel, int> playerScore = new Dictionary<PlayerViewModel, int>();
            foreach (var player in playerCards.Keys)
            {
                var cardsList = await _playerRepository.GetAllCardsFromPlayer(player.Id);
                int score = cardsList.ToList().Sum(card => card.Value);
                PlayerViewModel playerModel = Mapp.MappPlayer(player);
                playerScore.Add(playerModel, score);
            }

            return playerScore;
        }


        public async Task<Dictionary<PlayerViewModel, List<Card>>> TakeCardIfNotEnough(bool takeCard)      //?????????
        {
            var playerScore = await GetScoreCount();
            foreach (var ps in playerScore)
            {
                if (ps.Value < 17 && ps.Key.PlayerType!="Person")
                {
                    Player player = await _playerRepository.GetById(ps.Key.Id);
                    CardViewModel cardModel = await DrawCard();
                    Card card=Mapp.MappCardModel(cardModel);
                    await GiveCardToPlayer(player, card);
                }
                if(ps.Key.PlayerType == "Person" && takeCard == true)
                {
                    Player player = await _playerRepository.GetById(ps.Key.Id);
                    CardViewModel cardModel = await DrawCard();
                    Card card = Mapp.MappCardModel(cardModel);
                    await GiveCardToPlayer(player, card);
                }
            }

            var playerCards = await _playerRepository.GetAllCardsFromAllPlayers();
            Dictionary < PlayerViewModel, List < Card >> playerCardsModel = Mapp.MappPlayerModel(playerCards);

            return playerCardsModel;
        }


        public async Task<bool> PlayAgain(bool takeCard)
        {
            bool isGameEnded = false;

            isGameEnded = await IsGameEnded();
            for (; isGameEnded == false;)
            {
                await TakeCardIfNotEnough(takeCard);           //??????????????
                isGameEnded = await IsGameEnded();
            }

            //_round++;   //??????

            return true;
        }


        public async Task<bool> IsGameEnded()
        {
            var scors = await GetScoreCount();
            bool isGameEnded = false;
            List<int> cardCount = new List<int>();


            foreach (var playerScore in scors.Where(x=>x.Key.PlayerType!="Person"))
            {
                int scoreValue = playerScore.Value;
                cardCount.Add(scoreValue); 
            }

            isGameEnded = cardCount.TrueForAll(c => c >= 17);

            return isGameEnded;
        }
    }
}
