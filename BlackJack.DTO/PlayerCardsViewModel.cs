using System.Collections.Generic;

namespace BlackJack.ViewModels
{
    public class PlayerCardsViewModel
    {
        public PlayerViewModel Player { get; set; }
        public List<CardViewModel> Cards { get; set; }
        public int Round{ get; set; }
        public PlayerCardsViewModel()
        {
            Cards = new List<CardViewModel>();
        }
    }
}
