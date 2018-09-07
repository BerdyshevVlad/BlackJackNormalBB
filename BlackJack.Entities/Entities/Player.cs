﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.EntitiesLayer.Entities
{
    public class Player : Entity
    {
        public string Name { get; set; }
        public string PlayerType { get; set; }
        public int GameNumber { get; set; }

    }
}
