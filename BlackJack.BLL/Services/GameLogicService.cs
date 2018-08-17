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
        int _currentRound=0;
        public GameLogicService()
        {
            _cardRepository = new CardRepository(new DAL.BlackJackContext());
            _playerRepository = new PlayerRepository(new DAL.BlackJackContext());
            _playerCardRepository = new PlayerCardRepository(new DAL.BlackJackContext());
        }


        public async Task<CardViewModel> DrawCard()
        {

            var randomValue = GenerateRandomValue();
            bool isCurrentCardDrawned = IsCardAlreadyDrawned(randomValue);

            while (isCurrentCardDrawned == true)
            {
                randomValue= GenerateRandomValue();
                isCurrentCardDrawned = IsCardAlreadyDrawned(randomValue);
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

            int round=DefineCurrentRound();
            await _playerCardRepository.AddCard(playerTmp, cardTmp,round);

            PlayerViewModel playerModel = Mapp.MappPlayer(playerTmp);

            return playerModel;
        }


        public int DefineCurrentRound()
        {
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
    }
}
