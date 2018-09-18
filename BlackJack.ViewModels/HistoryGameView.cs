using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels
{
    public class HistoryGameView
    {
        public List<PlayerGameViewItem> Players { get; set; }

        public HistoryGameView()
        {
            Players = new List<PlayerGameViewItem>();
        }
    }
}
