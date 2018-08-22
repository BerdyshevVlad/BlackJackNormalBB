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

        public GameLogicController()
        {
            _gameLogicService = new GameLogicService();
        }



        public async Task<ActionResult> HandOverCards()
        {
            Dictionary<PlayerViewModel,List<CardViewModel>> playerModelDictionary = await _gameLogicService.HandOverCards();
            List<PlayerCardsViewModel> model = Mapp.MappPlayerCards(playerModelDictionary);

            return View(model);
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

            return View("HandOverCards", model);
        }
    }
}