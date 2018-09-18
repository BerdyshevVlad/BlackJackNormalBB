using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels
{
    public class MoreOrEnoughGameView
    {
        public List<PlayerGameViewItem> Players { get; set; }

        public MoreOrEnoughGameView()
        {
            Players=new List<PlayerGameViewItem>();
        }
    }
}
