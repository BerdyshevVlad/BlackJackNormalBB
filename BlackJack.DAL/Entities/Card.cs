using System.ComponentModel.DataAnnotations;

namespace BlackJack.DAL.Entities
{
    public class Card
    {
        [Key]
        public int Id { get; set; }
        public int Value { get; set; }
        public string Suit { get; set; }
        public string Rank { get; set; }


    }
}
