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
        GameSetService _gameSetService;

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
