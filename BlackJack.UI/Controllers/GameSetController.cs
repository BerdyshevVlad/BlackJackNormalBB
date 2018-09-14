using System.Collections.Generic;
using System.Threading.Tasks;
using BlackJack.BLL.Interfaces;
using BlackJack.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.UI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class GameSetController : ControllerBase
  {
    private readonly IGameSet _gameSetService;

    public GameSetController(IGameSet gameSetService)
    {
      _gameSetService = gameSetService;
    }

    // GET api/values
    [HttpGet]
    [ActionName("api/[controller]")]
    public async Task<ActionResult<IEnumerable<CardViewModel>>> GetDeckAsync()
    {

      bool isWork = await _gameSetService.SetDeck();
      List<CardViewModel> cardModelList = await _gameSetService.GetDeck();


      return cardModelList;
    }

    //// GET api/values/5
    [HttpGet("{count}")]
    public async Task<ActionResult<List<PlayerViewModel>>> SetBotCountAsync(int count)
    {
      await _gameSetService.SetBotCount(count);
      List<PlayerViewModel> playersModelList = await _gameSetService.GetPlayers();

      return playersModelList;
    }

  }
}
