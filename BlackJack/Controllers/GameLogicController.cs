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
        private GameService _gameLogicService;

        public GameLogicController(GameService gameLogicService)
        {
            _gameLogicService = gameLogicService;
        }


        [ExceptionLogger]
        public async Task<ActionResult> HandOverCards()
        {
            StartGameView model = await _gameLogicService.Start();

            return View(model.Players);
        }


        [ExceptionLogger]
        public async Task<ActionResult> PlayAgain(bool takeCard)
        {
            MoreOrEnoughGameView model = await _gameLogicService.MoreOrEnough(takeCard);

            return PartialView("PlayAgain", model.Players);
        }


        [ExceptionLogger]
        public async Task<ActionResult> StartNewRound()
        {
            StartGameView model = await _gameLogicService.Start();

            return PartialView("StartNewRound", model);
        }
    }
}