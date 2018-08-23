using BlackJack.BLL.Interfaces;
using BlackJack.DAL.Enums;
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
    public class GameSetService:IGameSet
    {
        private readonly ICardRepository<Card> _cardRepository;
        private readonly IPlayerRepository<Player> _playerRepository;

        private readonly string _dealerPlayerType;
        private readonly string _personPlayerType;
        private int _gameNumber;

        public GameSetService(ICardRepository<Card> cardRepository,IPlayerRepository<Player> playerRepository)
        {
            _cardRepository = cardRepository;
            _playerRepository = playerRepository;
            _dealerPlayerType = "Dealer";
            _personPlayerType = "Person";
        }


        public async Task<int> DefineCurrentGame()
        {
            int _currentRound = 0;
            try
            {
                var gamePlayersList =await _playerRepository.GetAll();
                int maxGame = gamePlayersList.Max(x => x.GameNumber);
                if (maxGame > 0)
                {
                    _currentRound = maxGame+1;
                }
            }
            catch
            {

                _currentRound = 1;
            }

            return _currentRound;
        }


        public async Task SetBotCount(int botsCount)
        {
            _gameNumber = await DefineCurrentGame();
            await InitializePlayers(_gameNumber);
            try
            {
                for (int i = 0; i < botsCount; i++)
                {
                    await _playerRepository.Insert(new Player { Name = $"Bot{i}", PlayerType = "Bot" ,GameNumber= _gameNumber });
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        public async Task<List<PlayerViewModel>> GetPlayers()
        {
            var gamePlayerViewModelList = new List<PlayerViewModel>();

            try
            {
                List<Player> playersList = await _playerRepository.GetAll();
                gamePlayerViewModelList = Mapp.MappPlayer(playersList.ToList());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return gamePlayerViewModelList;
        }


        public async Task<List<CardViewModel>> GetDeck()   
        {
            var cardsViewModel=new List<CardViewModel>();
            try
            {
                List<Card> cardsListCollection = await _cardRepository.GetAll();
                cardsViewModel = Mapp.MappCard((cardsListCollection.ToList()));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return cardsViewModel;
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
                    await _playerRepository.Insert(dealer);
                    await _playerRepository.Insert(playerPerson);
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
            int AceValue=11;
            int enumAceVlue = 14;

            try
            {
                foreach (var suit in Enum.GetNames(typeof(Suit)))
                {
                    for (int value = cardMinValue, rankValue = rankMinValue; value <= cardMaxValue && rankValue <= rankMaxValue; value++, rankValue++)
                    {
                        if (value>= enumJackValue && value<= enumKingValue)
                        {
                            card = new Card { Value = JackQueenKingValues, Suit = suit, Rank = enumValuesList.GetValue(rankValue).ToString() };
                        }
                        if (value == enumAceVlue)
                        {
                            card = new Card { Value = AceValue, Suit = suit, Rank = enumValuesList.GetValue(rankValue).ToString() };
                        }
                        if(value < enumJackValue)
                        {
                            card = new Card { Value = value, Suit = suit, Rank = enumValuesList.GetValue(rankValue).ToString() };
                        }

                        cardsList.Add(card);
                    }
                }

                foreach (var cardItem in cardsList)
                {
                    await _cardRepository.Insert(cardItem);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return true;
        }
    }
}
