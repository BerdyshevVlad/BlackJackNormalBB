using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels
{
    public class StartGameView
    {
        public List<PlayerGameViewItem> Players { get; set; }

        public StartGameView()
        {
            Players=new List<PlayerGameViewItem>();
        }
    }

    public class PlayerGameViewItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PlayerType { get; set; }
        public int GameNumber { get; set; }
        public List<CardViewItem> Cards { get; set; }
        public int Score { get; set; }
        public int Round { get; set; }
        public PlayerGameViewItem()
        {
            Cards = new List<CardViewItem>();
        }
    }


    public class CardViewItem
    {
        public int Id { get; set; }
        public int Value { get; set; }
    }
}
