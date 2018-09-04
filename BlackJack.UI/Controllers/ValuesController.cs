using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.BLL.Interfaces;
using BlackJack.BLL.Services;
using BlackJack.Mappers;
using BlackJack.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.UI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ValuesController : ControllerBase
  {
    private readonly IGameSet _gameSetService;

    public ValuesController(IGameSet gameSetService)
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

   

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
