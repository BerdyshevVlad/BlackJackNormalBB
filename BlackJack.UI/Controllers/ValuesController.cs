using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<CardViewModel>> Get()
        //public ActionResult<IEnumerable<string>> Get()
        {
            List<CardViewModel> cardModelList = new List<CardViewModel>();
            cardModelList.Add(new CardViewModel { Id = 1, Rank = "1", Suit = "1", Value = 1 });
            cardModelList.Add(new CardViewModel { Id = 2, Rank = "2", Suit = "2", Value = 2 });



            return cardModelList;
            //return new string[] { "1", "2", "3" };
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
