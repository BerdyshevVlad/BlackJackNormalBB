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
    public class GameSetService
    {
        private readonly ICardRepository<Card> _cardRepository;
        private readonly IPlayerRepository<Player> _playerRepository;

        private readonly string _dealerPlayerType;
        private readonly string _personPlayerType;


        public GameSetService()
        {
            _cardRepository = new CardRepository(new DAL.BlackJackContext());
            _playerRepository = new PlayerRepository(new DAL.BlackJackContext());
            _dealerPlayerType = "Dealer";
            _personPlayerType = "Person";
        }


        public async Task SetBotCount(int botsCount)
        {
            try
            {
                for (int i = 0; i < botsCount; i++)
                {
                    await _playerRepository.Insert(new Player { Name = $"Bot{i}", PlayerType = "Bot" });
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


        public async Task InitializePlayers()
        {
            var dealer = new Player();
            dealer.Name = "Dealer";
            dealer.PlayerType = _dealerPlayerType;
            var playerPerson = new Player();
            playerPerson.Name = "You";
            playerPerson.PlayerType = _personPlayerType;

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
