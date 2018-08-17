using BlackJack.DAL.Entities;
using BlackJack.DAL.Enum;
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
    public class GameSetService
    {
        private CardRepository _cardRepository;
        private PlayerRepository _playerRepository;


        public GameSetService()
        {
            _cardRepository = new CardRepository(new DAL.BlackJackContext());
            _playerRepository = new PlayerRepository(new DAL.BlackJackContext());
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
            List<PlayerViewModel> gamePlayerViewModelList;
            List<Player> gamePlayer = new List<Player>();

            try
            {
                var playersList = await _playerRepository.GetAll();
                foreach (var player in playersList)
                {
                    gamePlayer.Add(player);
                }

                gamePlayerViewModelList =Mapp.MappPlayer(gamePlayer);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return gamePlayerViewModelList;
        }


        public async Task<List<CardViewModel>> GetDeck()
        {
            List<Card> cardsList = new List<Card>();
            List<CardViewModel> cardsViewModel;
            try
            {
                var cardsListCollection = await _cardRepository.GetAll();
                foreach (var card in cardsListCollection)
                {

                    cardsList.Add(card);
                }
                cardsViewModel = Mapp.MappCard((cardsList.ToList()));
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
            dealer.PlayerType = "Dealer";
            var playerPerson = new Player();
            playerPerson.Name = "You";
            playerPerson.PlayerType = "Person";

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
            List<Card> cardsList = new List<Card>();
            Card card = null;
            var enumValuesList = Enum.GetValues(typeof(Rank));

            try
            {
                foreach (var suit in Enum.GetNames(typeof(Suit)))
                {
                    for (int value = 2, rankValue = 0; value <= 14 && rankValue <= 12; value++, rankValue++)
                    {
                        if (value == 11 || value == 12 || value == 13)
                        {
                            card = new Card { Value = 10, Suit = suit, Rank = enumValuesList.GetValue(rankValue).ToString() };
                        }
                        if (value == 14)
                        {
                            card = new Card { Value = 11, Suit = suit, Rank = enumValuesList.GetValue(rankValue).ToString() };
                        }
                        else
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
