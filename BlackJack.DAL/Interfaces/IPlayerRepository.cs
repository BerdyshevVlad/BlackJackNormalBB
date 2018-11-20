﻿using BlackJack.EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DAL.Interfaces
{
    public interface IPlayerRepository:IBaseRepository<Player>
    {
        Task AddCard(Player player, Card card, int currentRound);
        Task<IEnumerable<Card>> GetAllCardsFromPlayer(int id, int round);
        Task<Dictionary<Player, List<Card>>> GetAllCardsFromAllPlayers(int round);
        Task<List<PlayerCard>> GetPlayerByIdAndByRound(int id, int round);
        Task<List<PlayerCard>> GetPlayersByRound(int round);
    }
}