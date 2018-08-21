using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.EntitiesLayer.Entities
{
    public class PlayerCard
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Player")]
        public  int PlayerId { get; set; }
        public  Player Player { get; set; }
        [ForeignKey("Card")]
        public  int CardId { get; set; }
        public  Card Card { get; set; }
        public int CurrentRound { get; set; }

    }
}
