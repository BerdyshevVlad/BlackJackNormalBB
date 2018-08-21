﻿using BlackJack.DAL.Enums;
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
            var gamePlayerViewModelList = new List<PlayerViewModel>();

            try
            {
                IEnumerable<Player> playersList = await _playerRepository.GetAll();
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
            List<Card> cardsList = new List<Card>();
            List<CardViewModel> cardsViewModel;
            try
            {
                var cardsListCollection = await _cardRepository.GetAll();
                foreach (var card in cardsListCollection)
                {

                    cardsList.Add(card);    //rewrite
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
