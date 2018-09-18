using BlackJack.BusinessLogic.Services;
using ExceptionLoggers;
using System.Threading.Tasks;
using System.Web.Mvc;
using BlackJack.DataAccess.Interfaces;
using BlackJack.ViewModels;


namespace BlackJack.Controllers
{
    public class GameSetController : Controller
    {
        private GameService _gameSetService;

        public GameSetController(GameService gameSetService)
        {
            _gameSetService = gameSetService;
        }


        [ExceptionLogger]
        [HttpGet]
        public async Task<ActionResult> GetDeck()
        {

            bool isWork = await _gameSetService.SetDeck();
            GetDeckGameView cardModelList = await _gameSetService.GetDeck();

            return View(cardModelList.Cards);
        }


        [ExceptionLogger]
        public async Task<ActionResult> SetBotCount()
        {
            //try
            //{
                await _gameSetService.SetBotCount(3);
            //}
            //catch (Exception ex)
            //{
            //    return View("Error", new string[] { ex.Message });
            //}
            return View();
        }
    }
}
