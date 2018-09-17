using System.ComponentModel.DataAnnotations.Schema;

namespace BlackJack.Entities
{
    public class PlayerCard:BaseEntity
    {
        [ForeignKey("Player")]
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }
        [ForeignKey("Card")]
        public int CardId { get; set; }
        public virtual Card Card { get; set; }
        public int CurrentRound { get; set; }
    }
}
