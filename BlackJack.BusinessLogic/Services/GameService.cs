using BlackJack.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.Entities;
using BlackJack.ViewModels;
using BlackJack.DataAccess.Enums;

namespace BlackJack.BusinessLogic.Services
{
    public class GameService : IGameService
    {

        public readonly ICardRepository _cardRepository;
        public readonly IPlayerRepository _playerRepository;
        public readonly IPlayerCardRepository _playerCardRepository;

        public int _round;
        public readonly string _personPlayerType = "Person";
        public readonly string _dealerPlayerType = "Dealer";

        public GameService(ICardRepository cardRepository, IPlayerRepository playerRepository,IPlayerCardRepository playerCardRepository)
        {
            _cardRepository = cardRepository;
            _playerRepository = playerRepository;
            _playerCardRepository = playerCardRepository;
            _round = DefineCurrentRound();
        }


        public async Task<int> DefineCurrentGame()
        {
            int currentRound = 0;
            try
            {
                var gamePlayersList = await _playerRepository.GetAllAsync();
                int maxGame = gamePlayersList.Max(x => x.GameNumber);
                if (maxGame > 0)
                {
                    currentRound = maxGame + 1;
                }
            }
            catch
            {
                currentRound = 1;
            }

            return currentRound;
        }


        public  int DefineCurrentRound()
        {
            int _currentRound = 0;
            try
            {
                IEnumerable<PlayerCard> gamePlayersList =_playerCardRepository.GetAll();
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


        public async Task InitializePlayers(int game)
        {
            var dealer = new Player();
            dealer.Name = "Dealer";
            dealer.PlayerType = _dealerPlayerType;
            dealer.GameNumber = game;
            var playerPerson = new Player();
            playerPerson.Name = "You";
            playerPerson.PlayerType = _personPlayerType;
            playerPerson.GameNumber = game;

            try
            {
                await _playerRepository.InsertAsync(dealer);
                await _playerRepository.InsertAsync(playerPerson);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<bool> SetDeck()
        {
            var cardsList = new List<Card>();
            Card card = null;
            Array enumValuesList = Enum.GetValues(typeof(Rank));

            int cardMinValue = 2;
            int cardMaxValue = 14;
            int rankMinValue = 0;
            int rankMaxValue = 14;
            int enumJackValue = 11;
            int enumKingValue = 13;
            int JackQueenKingValues = 10;
            int AceValue = 11;
            int enumAceVlue = 14;

            try
            {
                foreach (var suit in Enum.GetNames(typeof(Suit)))
                {
                    for (int value = cardMinValue, rankValue = rankMinValue;
                        value <= cardMaxValue && rankValue <= rankMaxValue;
                        value++, rankValue++)
                    {
                        if (value >= enumJackValue && value <= enumKingValue)
                        {
                            card = new Card
                            {
                                Value = JackQueenKingValues,
                                Suit = suit,
                                Rank = enumValuesList.GetValue(rankValue).ToString()
                            };
                        }

                        if (value == enumAceVlue)
                        {
                            card = new Card
                            { Value = AceValue, Suit = suit, Rank = enumValuesList.GetValue(rankValue).ToString() };
                        }

                        if (value < enumJackValue)
                        {
                            card = new Card
                            { Value = value, Suit = suit, Rank = enumValuesList.GetValue(rankValue).ToString() };
                        }

                        cardsList.Add(card);
                    }
                }

                var isCardsAlreadyExist = _cardRepository.IsExistAsync();
                if (isCardsAlreadyExist == false)
                {
                    foreach (var cardItem in cardsList)
                    {

                        await _cardRepository.InsertAsync(cardItem);
                    }
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return true;
        }


        public async Task<GetDeckGameView> GetDeck()
        {
            var cardsViewModel = new GetDeckGameView();
            try
            {
                IEnumerable<Card> cardListCollection = await _cardRepository.GetAllAsync();
                foreach (var card in cardListCollection)
                {
                    cardsViewModel.Cards.Add(new DeckViewItem
                    {
                        Id = card.Id,
                        Value = card.Value
                    });
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return cardsViewModel;
        }


        public async Task SetBotCount(int botsCount)
        {
            int gameNumber = await DefineCurrentGame();
            await InitializePlayers(gameNumber);
            try
            {
                for (int i = 0; i < botsCount; i++)
                {
                    await _playerRepository.InsertAsync(new Player
                    { Name = $"Bot{i}", PlayerType = "Bot", GameNumber = gameNumber });
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        public async Task<Dictionary<Player, List<Card>>> DefinePlayersFromLastGame()
        {
            Dictionary<Player, List<Card>> playerCardsDictionary =
                await _playerRepository.GetAllCardsFromAllPlayers(_round);

            int max = playerCardsDictionary.Max(x => x.Key.GameNumber);
            var playersLastGame = playerCardsDictionary.Where(x => x.Key.GameNumber == max)
                .ToDictionary(x => x.Key, x => x.Value);
            return playersLastGame;
        }


        public int GenerateRandomValue()
        {
            int minDeckValue = 1;
            int maxDeckValue = 52;
            var random = new Random();

            int randomValue = random.Next(minDeckValue, maxDeckValue);
            return randomValue;
        }


        public async Task<bool> IsCardAlreadyDrawned(int randomValue)
        {
            IEnumerable<PlayerCard> playersCards = _playerCardRepository.GetAll();
            List<PlayerCard> playersOfCurrentRound = playersCards.Where(x => x.CurrentRound == _round).ToList();
            foreach (var pc in playersOfCurrentRound)
            {
                if (pc.CardId == randomValue)
                {
                    return true;
                }
            }

            return false;
        }


        public async Task<Card> DrawCard()
        {

            int randomValue = GenerateRandomValue();
            bool isCurrentCardDrawned = await IsCardAlreadyDrawned(randomValue);

            for (; isCurrentCardDrawned == true;)
            {
                randomValue = GenerateRandomValue();
                isCurrentCardDrawned = await IsCardAlreadyDrawned(randomValue);
            }

            Card card = await _cardRepository.GetByIdAsync(randomValue);

            return card;
        }


        public async Task GiveCardToPlayer(Player player, Card Card)
        {
            Player playerTmp = await _playerRepository.GetByIdAsync(player.Id);
            Card cardTmp = await _cardRepository.GetByIdAsync(Card.Id);
            await _playerCardRepository.AddCardAsync(playerTmp, cardTmp, _round);
        }


        public async Task GiveCardToEachPlayer()
        {
            IEnumerable<Player> playersList = await _playerRepository.GetAllAsync();

            int max = playersList.Max(x => x.GameNumber);
            IEnumerable<Player> playerList = playersList.ToList().Where(x => x.GameNumber == max);

            foreach (var player in playerList)
            {
                Card drawnedCard = await DrawCard();
                await GiveCardToPlayer(player, drawnedCard);
            }
        }


        public void CountSum(ref List<PlayerGameViewItem> playerViewItemList)
        {
            foreach (var playerCards in playerViewItemList)
            {
                playerCards.Score = playerCards.Cards.Sum(cardModel => cardModel.Value);
            }
        }


        public async Task<StartGameView> Start()
        {
            
            int handOverCount = 2;
            _round++;

            for (int i = 0; i < handOverCount; i++)
            {
                await GiveCardToEachPlayer();
            }

            Dictionary<Player, List<Card>> playerCardsLastGame = await DefinePlayersFromLastGame();
            List<PlayerGameViewItem> playerViewItemList = new List<PlayerGameViewItem>();

            foreach (var player in playerCardsLastGame)
            {
                PlayerGameViewItem playerViewItem = new PlayerGameViewItem();
                playerViewItem.Id = player.Key.Id;
                playerViewItem.Name = player.Key.Name;
                playerViewItem.GameNumber = player.Key.GameNumber;
                playerViewItem.PlayerType = player.Key.PlayerType;
                foreach (var card in player.Value)
                {
                    playerViewItem.Cards.Add(new CardViewItem { Id = card.Id, Value = card.Value });
                }

                playerViewItemList.Add(playerViewItem);
            }

            CountSum(ref playerViewItemList);

            StartGameView startViewModel = new StartGameView();
            startViewModel.Players = playerViewItemList;

            return startViewModel;
        }


        public async Task<List<PlayerGameViewItem>> GetScoreCount()
        {
            Dictionary<Player, List<Card>> playerCardsLastGame = await DefinePlayersFromLastGame();

            var playerViewItemList = new List<PlayerGameViewItem>();
            foreach (var player in playerCardsLastGame)
            {
                IEnumerable<Card> cardsList = await _playerRepository.GetAllCardsFromPlayer(player.Key.Id, _round);
                int score = cardsList.ToList().Sum(card => card.Value);
                PlayerGameViewItem playerViewItem = new PlayerGameViewItem();
                playerViewItem.Id = player.Key.Id;
                playerViewItem.Name = player.Key.Name;
                playerViewItem.GameNumber = player.Key.GameNumber;
                playerViewItem.PlayerType = player.Key.PlayerType;
                foreach (var card in player.Value)
                {
                    playerViewItem.Cards.Add(new CardViewItem { Id = card.Id, Value = card.Value });
                }

                playerViewItemList.Add(playerViewItem);
            }

            return playerViewItemList;
        }


        public async Task TakeCardIfNotEnough(bool takeCard)
        {
            List<PlayerGameViewItem> playerViewItemList = await GetScoreCount();

            foreach (var playerView in playerViewItemList)
            {
                if (playerView.Score < 17 && playerView.PlayerType != _personPlayerType)
                {
                    Player player = await _playerRepository.GetByIdAsync(playerView.Id);
                    Card card = await DrawCard();
                    await GiveCardToPlayer(player, card);
                }

                if (playerView.PlayerType == _personPlayerType && takeCard)
                {
                    Player player = await _playerRepository.GetByIdAsync(playerView.Id);
                    Card card = await DrawCard();
                    await GiveCardToPlayer(player, card);
                }
            }
        }


        public async Task<MoreOrEnoughGameView> MoreOrEnough(bool takeCard = false)
        {
            bool isGameEnded = await IsGameEnded(takeCard);


            for (; isGameEnded == false;)
            {
                var isUserBusted = await IsUserBusted();
                if (takeCard && !isUserBusted)
                {
                    await TakeCardIfNotEnough(takeCard);
                    isGameEnded = await IsGameEnded(takeCard);
                    isUserBusted = await IsUserBusted();
                    if (!isUserBusted)
                    {
                        break;
                    }

                    takeCard = false;
                }

                if (!takeCard)
                {
                    await TakeCardIfNotEnough(takeCard);
                    isGameEnded = await IsGameEnded(takeCard);
                }
            }

            Dictionary<Player, List<Card>> playerCardsLastGame = await DefinePlayersFromLastGame();

            List<PlayerGameViewItem> playerViewItemList = new List<PlayerGameViewItem>();

            foreach (var player in playerCardsLastGame)
            {
                PlayerGameViewItem playerViewItem = new PlayerGameViewItem();
                playerViewItem.Id = player.Key.Id;
                playerViewItem.Name = player.Key.Name;
                playerViewItem.GameNumber = player.Key.GameNumber;
                playerViewItem.PlayerType = player.Key.PlayerType;
                foreach (var card in player.Value)
                {
                    playerViewItem.Cards.Add(new CardViewItem { Id = card.Id, Value = card.Value });
                }

                playerViewItemList.Add(playerViewItem);
            }

            CountSum(ref playerViewItemList);

            MoreOrEnoughGameView moreOrEnoughViewModel = new MoreOrEnoughGameView();
            moreOrEnoughViewModel.Players = playerViewItemList;

            return moreOrEnoughViewModel;
        }





        public async Task<bool> IsGameEnded(bool takeCard)
        {
            List<PlayerGameViewItem> playerViewItemList = await GetScoreCount();
            bool isGameEnded = false;
            var cardCount = new List<int>();

            foreach (var playerScore in playerViewItemList.Where(x => x.PlayerType != _personPlayerType))
            {
                int scoreValue = playerScore.Score;
                cardCount.Add(scoreValue);
            }

            isGameEnded = cardCount.TrueForAll(c => c >= 17);
            PlayerGameViewItem playerViewItem =
                playerViewItemList.SingleOrDefault(x => x.PlayerType == _personPlayerType);
            int cardSum = playerViewItem.Cards.Sum(c => c.Value);
            if (cardSum < 21 && takeCard != false)
            {
                isGameEnded = false;
            }

            return isGameEnded;
        }


        public async Task<bool> IsUserBusted()
        {
            int scoreMaxValue = 21;

            List<PlayerGameViewItem> playerViewItemList = await GetScoreCount();
            PlayerGameViewItem playerViewItem =
                playerViewItemList.SingleOrDefault(x => x.PlayerType == _personPlayerType);
            int cardSum = playerViewItem.Cards.Sum(x => x.Value);
            if (cardSum >= scoreMaxValue)
            {
                return true;
            }

            return false;
        }


        public async Task<List<PlayerGameViewItem>> DefineTheWinner()
        {
            List<PlayerGameViewItem> playerViewItemList = await GetScoreCount();
            var max = playerViewItemList.Where(x => x.Score <= 21).Max(x => x.Score);

            foreach (var playerViewItem in playerViewItemList)
            {
                playerViewItem.Score = playerViewItem.Score;
            }

            List<PlayerGameViewItem> winners = playerViewItemList.Where(x => x.Score == max).ToList();

            return winners;
        }


        public async Task<HistoryGameView> GetHistory()
        {
            IEnumerable<PlayerCard> gamePlayersList = _playerCardRepository.GetAll();
            int maxRound = gamePlayersList.Max(r => r.CurrentRound);

            var history = new HistoryGameView();
            for (int i = 1; i <= maxRound; i++)
            {

                List<PlayerCard> playersList = await _playerRepository.GetPlayersByRound(i);
                foreach (var item in playersList)
                {
                    IEnumerable<Card> cardList = await _playerRepository.GetAllCardsFromPlayer(item.PlayerId, i);
                    Player player = await _playerRepository.GetByIdAsync(item.PlayerId);

                    PlayerGameViewItem playerModel = new PlayerGameViewItem();
                    playerModel.Id = player.Id;
                    playerModel.Name = player.Name;
                    playerModel.GameNumber = player.GameNumber;
                    playerModel.PlayerType = player.PlayerType;
                    playerModel.Score = cardList.Sum(x => x.Value);
                    playerModel.Round = i;
                    foreach (var card in cardList)
                    {
                        playerModel.Cards.Add(new CardViewItem
                        {
                            Id = card.Id,
                            Value = card.Value
                        });
                    }


                    history.Players.Add(playerModel);
                }
            }

            return history;
        }

    }
}
