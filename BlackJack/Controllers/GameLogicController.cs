using BlackJack.BLL.Services;
using BlackJack.DAL.Repositories;
using BlackJack.Mappers;
using BlackJack.ViewModels;
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
        private GameLogicService _gameLogicService;

        public GameLogicController(GameLogicService gameLogicService)
        {
            _gameLogicService = gameLogicService;
        }



        public async Task<ActionResult> HandOverCards()
        {
            //Dictionary<PlayerViewModel, List<CardViewModel>> playerModelDictionary = await _gameLogicService.HandOverCards();
            //List<PlayerCardsViewModel> model = Mapp.MappPlayerCards(playerModelDictionary);

            await _gameLogicService.GetHistory();

            //return View(model);
            return null;
        }



        public async Task<ActionResult> PlayAgain(bool takeCard)
        {
            Dictionary<PlayerViewModel, List<CardViewModel>> playerModelDictionary = await _gameLogicService.PlayAgain(takeCard);
            List<PlayerCardsViewModel> model = Mapp.MappPlayerCards(playerModelDictionary);

            return PartialView("PlayAgain", model);
        }


        public async Task<ActionResult> StartNewRound()
        {
            Dictionary<PlayerViewModel, List<CardViewModel>> playerModelDictionary = await _gameLogicService.StartNewRound();
            List<PlayerCardsViewModel> model = Mapp.MappPlayerCards(playerModelDictionary);

            return PartialView("StartNewRound", model);
        }
    }
}