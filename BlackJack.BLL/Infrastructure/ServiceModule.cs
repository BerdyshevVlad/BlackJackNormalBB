using BlackJack.DAL;
using BlackJack.DAL.Interfaces;
using BlackJack.DAL.Repositories;
using BlackJack.EntitiesLayer.Entities;
using Ninject.Modules;

namespace BlackJack.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICardRepository<Card>>().To<CardRepository>().WithConstructorArgument(new BlackJackContext());
            Bind<IPlayerRepository<Player>>().To<PlayerRepository>().WithConstructorArgument(new BlackJackContext());
            Bind<IPlayerCardRepository>().To<PlayerCardRepository>().WithConstructorArgument(new BlackJackContext());
        }
    }
}
