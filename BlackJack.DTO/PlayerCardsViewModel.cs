using BlackJack.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DTO
{
    public class PlayerCardsViewModel
    {
        public Player Player { get; set; }
        public List<Card> Cards { get; set; }
    }
}
