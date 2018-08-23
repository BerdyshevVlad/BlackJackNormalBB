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
        public PlayerViewModel Player { get; set; }
        public List<CardViewModel> Cards { get; set; }

        public PlayerCardsViewModel()
        {
            Cards = new List<CardViewModel>();
        }
    }
}
