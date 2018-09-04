using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.BLL.Interfaces;
using BlackJack.Mappers;
using BlackJack.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.UI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class GameLogicController : ControllerBase
  {

    private readonly IGameLogic _gameLogicService;

    public GameLogicController(IGameLogic gameLogicService)
    {
      _gameLogicService = gameLogicService;
    }

    [HttpGet]
    public async Task<List<PlayerCardsViewModel>> HandOverCards()
    {
      Dictionary<PlayerViewModel, List<CardViewModel>> playerModelDictionary = await _gameLogicService.HandOverCards();
      List<PlayerCardsViewModel> model = Mapp.MappPlayerCards(playerModelDictionary);

      return model;
    }
  }
}
