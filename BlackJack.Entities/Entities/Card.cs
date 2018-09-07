using System.ComponentModel.DataAnnotations;

namespace BlackJack.EntitiesLayer.Entities
{
    public class Card:Entity
    {
        public int Value { get; set; }
        public string Suit { get; set; }
        public string Rank { get; set; }


    }
}
