﻿using BlackJack.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels
{
    public class GameHistory
    {
        public List<RoundViewModel> Game { get; set; }

        public GameHistory()
        {
            Game = new List<RoundViewModel>();
        }
    }
}
