using BlackJack.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels
{
    public class GameHistory
    {
        public List<RoundViewModel> Games { get; set; }
        public Dictionary<int, RoundViewModel> MyPropertyTest { get; set; }

        public GameHistory()
        {
            Games = new List<RoundViewModel>();
            MyPropertyTest = new Dictionary<int, RoundViewModel>();
        }
    }
}
