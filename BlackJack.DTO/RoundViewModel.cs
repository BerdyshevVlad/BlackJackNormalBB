using BlackJack.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
