using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.BLL.Interfaces;
using BlackJack.BLL.Services;
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
    public async Task<ActionResult<IEnumerable<CardViewModel>>> GetAsync()
    //public ActionResult<IEnumerable<string>> Get()
    {

      bool isWork = await _gameSetService.SetDeck();
      List<CardViewModel> cardModelList = await _gameSetService.GetDeck();


      return cardModelList;
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<IEnumerable<string>> Get(int id)
    {
      return new string[] { "a", "b", "c" };
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody] string value)
    {
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
