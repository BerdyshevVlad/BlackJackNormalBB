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


    [HttpGet("PlayAgain/{takeCard}")]
    [ActionName("PlayAgain")]
    public async Task<List<PlayerCardsViewModel>> PlayAgain(bool takeCard)
    {
      Dictionary<PlayerViewModel, List<CardViewModel>> playerModelDictionary = await _gameLogicService.PlayAgain(takeCard);
      List<PlayerCardsViewModel> model = Mapp.MappPlayerCards(playerModelDictionary);

      return model;
    }


    [HttpGet("StartNewRound")]
    [ActionName("StartNewRound")]
    public async Task<List<PlayerCardsViewModel>> StartNewRound()
    {
      Dictionary<PlayerViewModel, List<CardViewModel>> playerModelDictionary = await _gameLogicService.StartNewRound();
      List<PlayerCardsViewModel> model = Mapp.MappPlayerCards(playerModelDictionary);

      return model;
    }


    [HttpGet("GetHistory")]
    [ActionName("GetHistory")]
    public async Task<List<RoundViewModel>> GetHistory()
    {

      List<RoundViewModel> history =await _gameLogicService.GetHistory();
      return history;
    }

  }
}
