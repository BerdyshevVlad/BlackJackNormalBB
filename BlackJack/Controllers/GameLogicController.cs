using BlackJack.BLL.Services;
using BlackJack.DAL.Repositories;
using BlackJack.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BlackJack.Controllers
{
    public class GameLogicController : Controller
    {

        PlayerRepository _playerRepository;
        CardRepository _cardRepository;
        PlayerCardRepository _playerCardRepository;
        GameSetService _gameSetService;

        GameLogicService _gameLogicService;//

        public GameLogicController()
        {
            _playerRepository = new PlayerRepository(new DAL.BlackJackContext());
            _cardRepository = new CardRepository(new DAL.BlackJackContext());
            _playerCardRepository = new PlayerCardRepository(new DAL.BlackJackContext());
            _gameSetService = new GameSetService();


            _gameLogicService = new GameLogicService();
        }



        public async Task<ActionResult> HandOverCards()
        {
            var playerModelList = await _gameLogicService.HandOverCards();
            List<PlayerCardsViewModel> model = new List<PlayerCardsViewModel>();
            foreach (var item in playerModelList)
            {
                var tmp = new PlayerCardsViewModel();
                tmp.Player = item.Key;
                tmp.Cards = item.Value;
                model.Add(tmp);
            }
            return View(model);
        }



        public async Task<ActionResult> PlayAgain(bool takeCard)
        {
            var test = await _gameLogicService.PlayAgain(takeCard);      //?????????????????

            List<PlayerCardsViewModel> model = new List<PlayerCardsViewModel>();
            foreach (var item in test)
            {
                var tmp = new PlayerCardsViewModel();
                tmp.Player = Mappers.Mapp.MappPlayerModel(item.Key);
                tmp.Cards = item.Value;
                model.Add(tmp);
            }

            return View("HandOverCards", model);      //??????????????
        }


        public async Task<ActionResult> StartNewRound()
        {
            var tmp = await _gameLogicService.StartNewRound();

            List<PlayerCardsViewModel> model = new List<PlayerCardsViewModel>();
            foreach (var item in tmp)
            {
                var test = new PlayerCardsViewModel();
                test.Player = Mappers.Mapp.MappPlayerModel(item.Key);
                test.Cards = item.Value;
                model.Add(test);
            }

            return View("HandOverCards", model);      //??????????????
        }
    }
}