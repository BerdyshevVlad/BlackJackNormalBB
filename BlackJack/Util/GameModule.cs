using BlackJack.BLL.Interfaces;
using BlackJack.BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackJack.Util
{
    public class GameModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IGameLogic>().To<GameLogicService>();
            Bind<IGameSet>().To<GameSetService>();
        }
    }
}