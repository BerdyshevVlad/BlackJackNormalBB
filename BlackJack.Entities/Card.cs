﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Entities
{
    public class Card : BaseEntity
    {
        public int Value { get; set; }
        public string Suit { get; set; }
        public string Rank { get; set; }
    }
}
