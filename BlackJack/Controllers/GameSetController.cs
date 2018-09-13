using BlackJack.BLL.Services;
using BlackJack.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace BlackJack.Controllers
{
    public class GameSetController : Controller
    {
        private GameSetService _gameSetService;

        public GameSetController(GameSetService gameSetService)
        {
            _gameSetService = gameSetService;
        }


        [HttpGet]
        public async Task<ActionResult> GetDeck()
        {

            bool isWork = await _gameSetService.SetDeck();
            List<CardViewModel> cardModelList = await _gameSetService.GetDeck();

            return View(cardModelList);
        }


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
