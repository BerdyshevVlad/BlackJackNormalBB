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
        public List<RoundViewModel> GamesList { get; set; }
        public Dictionary<int, RoundViewModel> MyPropertyTest { get; set; }

        public GameHistory()
        {
            GamesList = new List<RoundViewModel>();
            MyPropertyTest = new Dictionary<int, RoundViewModel>();
        }
    }
}
