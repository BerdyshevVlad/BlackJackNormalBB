using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels
{
    public class GetDeckGameView
    {
        public List<DeckViewItem> Cards { get; set; }

        public GetDeckGameView()
        {
            Cards=new List<DeckViewItem>();
        }
    }

    public class DeckViewItem
    {
        public int Id { get; set; }
        public int Value { get; set; }
    }
}
