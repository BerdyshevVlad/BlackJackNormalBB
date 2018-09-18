using BlackJack.Mappers;
using BlackJack.ViewModels;
using ExceptionLoggers;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using BlackJack.BusinessLogic.Services;

namespace BlackJack.Controllers
{
    public class GameLogicController : Controller
    {
        private GameLogicService _gameLogicService;

        public GameLogicController(GameLogicService gameLogicService)
        {
            _gameLogicService = gameLogicService;
        }


        [ExceptionLogger]
        public async Task<ActionResult> HandOverCards()
        {
            Dictionary<PlayerViewModel, List<CardViewModel>> playerModelDictionary = await _gameLogicService.HandOverCards();
            List<PlayerCardsViewModel> model = Mapp.MappPlayerCards(playerModelDictionary);


            return View(model);
        }


        [ExceptionLogger]
        public async Task<ActionResult> PlayAgain(bool takeCard)
        {
            Dictionary<PlayerViewModel, List<CardViewModel>> playerModelDictionary = await _gameLogicService.PlayAgain(takeCard);
            List<PlayerCardsViewModel> model = Mapp.MappPlayerCards(playerModelDictionary);

            return PartialView("PlayAgain", model);
        }


        [ExceptionLogger]
        public async Task<ActionResult> StartNewRound()
        {
            Dictionary<PlayerViewModel, List<CardViewModel>> playerModelDictionary = await _gameLogicService.StartNewRound();
            List<PlayerCardsViewModel> model = Mapp.MappPlayerCards(playerModelDictionary);

            return PartialView("StartNewRound", model);
        }
    }
}