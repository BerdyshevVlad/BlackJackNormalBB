using BlackJack.BLL.Services;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Enum;
using BlackJack.DAL.Repositories;
using BlackJack.DTO;
using BlackJack.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace BlackJack.Controllers
{
    public class GameSetController : Controller
    {
        PlayerRepository _playerRepository;
        CardRepository _cardRepository;
        PlayerCardRepository _playerCardRepository;
        GameSetService _gameSetService;

        GameLogicService _gameLogicService;//

        public GameSetController()
        {
            _playerRepository = new PlayerRepository(new DAL.BlackJackContext());
            _cardRepository = new CardRepository(new DAL.BlackJackContext());
            _playerCardRepository = new PlayerCardRepository(new DAL.BlackJackContext());
            _gameSetService = new GameSetService();


            _gameLogicService = new GameLogicService();
        }


        public async Task<ActionResult> GetDeck()
        {
            //bool isWork=await _gameSetService.SetDeck();
            //List<CardViewModel> cardModelList = await _gameSetService.GetDeck();

            //return View(cardModelList);


            bool isWork = await _gameSetService.SetDeck();
            await _gameSetService.InitializePlayers();
            await _gameSetService.SetBotCount(3);

            CardViewModel cardModel=await _gameLogicService.DrawCard();
            Card card= Mapp.MappCardModel(cardModel);
            PlayerViewModel playerModel=await _gameLogicService.GiveCardToPlayer(await _playerRepository.GetById(1), card);
            cardModel = await _gameLogicService.DrawCard();
            card = Mapp.MappCardModel(cardModel);
            await _gameLogicService.GiveCardToPlayer(await _playerRepository.GetById(1), card);
            var cardList = await _playerRepository.GetAllCardsFromPlayer(1);

            var t = cardList.ToList();

            return View();
        }


        public async Task<ActionResult> SetBotCount()
        {
            try
            {
                await _gameSetService.InitializePlayers();
                await _gameSetService.SetBotCount(3);
            }
            catch (Exception ex)
            {
                return View("Error", new string[] { ex.Message });
            }
            return View();
        }
    }
}
