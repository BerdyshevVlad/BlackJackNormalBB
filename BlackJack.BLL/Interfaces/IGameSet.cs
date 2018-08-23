using BlackJack.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.BLL.Interfaces
{
    public interface IGameSet
    {
        Task<int> DefineCurrentGame();
        Task SetBotCount(int botsCount);
        Task<List<PlayerViewModel>> GetPlayers();
        Task<List<CardViewModel>> GetDeck();
        Task InitializePlayers(int game);
        Task<bool> SetDeck();
    }
}
