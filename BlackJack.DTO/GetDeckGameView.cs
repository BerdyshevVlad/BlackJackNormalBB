using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DTO
{
    public class GetDeckGameView
    {
        public List<DeckViewItem> Cards { get; set; }
    }

    public class DeckViewItem
    {
        public int Id { get; set; }
        public int Value { get; set; }
    }
}
