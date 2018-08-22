using BlackJack.BLL.Services;
using BlackJack.DAL.Enums;
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
    public class GameSetController : Controller
    {
        private GameSetService _gameSetService;

        public GameSetController()
        {
            _gameSetService = new GameSetService();
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
