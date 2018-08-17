using BlackJack.BLL.Services;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Enum;
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
    public class GameSetController : Controller
    {
        PlayerRepository _playerRepository;
        CardRepository _cardRepository;
        PlayerCardRepository _playerCardRepository;
        GameSetService _gameSetService;
        public GameSetController()
        {
            _playerRepository = new PlayerRepository(new DAL.BlackJackContext());
            _cardRepository = new CardRepository(new DAL.BlackJackContext());
            _playerCardRepository = new PlayerCardRepository(new DAL.BlackJackContext());
            _gameSetService = new GameSetService();
        }


        public async Task<ActionResult> GetDeck()
        {
            bool isWork=await _gameSetService.SetDeck();
            List<CardViewModel> cardModelList = await _gameSetService.GetDeck();

            return View(cardModelList);
        }
    }
}
