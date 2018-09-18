using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DTO
{
    public class StartGameView
    {
        private List<PlayerGameViewItem> Players { get; set; }
    }

    public class PlayerGameViewItem
    {
        public string Name { get; set; }
        public string PlayerType { get; set; }
        public int GameNumber { get; set; }
        public List<CardViewItem> Cards { get; set; }

        public PlayerGameViewItem()
        {
            Cards=new List<CardViewItem>();
        }
    }


    public class CardViewItem
    {
        public int Id { get; set; }
        public int Value { get; set; }
    }
}
