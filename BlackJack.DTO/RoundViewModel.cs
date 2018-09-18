using System.Collections.Generic;

namespace BlackJack.DTO
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
