using System.Collections.Generic;

namespace BlackJack.ViewModels
{
    public class RoundViewModel
    {
        public List<PlayerCardsViewModel> roundModelList { get; set; }

        public RoundViewModel()
        {
            roundModelList = new List<PlayerCardsViewModel>();
        }
    }
}
