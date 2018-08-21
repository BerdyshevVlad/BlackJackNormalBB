using BlackJack.EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels
{
    public class PlayerCardsViewModel
    {
        public Player Player { get; set; }
        public List<Card> Cards { get; set; }
    }
}
