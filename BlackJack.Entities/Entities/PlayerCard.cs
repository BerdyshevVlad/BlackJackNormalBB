﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.EntitiesLayer.Entities
{
    public class PlayerCard:Entity
    {
        [ForeignKey("Player")]
        public  int PlayerId { get; set; }

        public virtual Player Player { get; set; }
        [ForeignKey("Card")]
        public  int CardId { get; set; }
        public virtual Card Card { get; set; }
        public int CurrentRound { get; set; }

    }
}