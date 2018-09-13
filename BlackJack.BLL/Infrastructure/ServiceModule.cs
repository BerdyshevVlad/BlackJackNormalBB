using BlackJack.DAL.Context.MVC;
using BlackJack.DAL.Dapper.Interfaces;  //
using BlackJack.DAL.Dapper.Repositories;  //
using Ninject.Modules;
using System.Configuration;

namespace BlackJack.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BlackJackContext"].ConnectionString;
            Bind<ICardRepository>().To<CardRepository>().WithConstructorArgument(connectionString);
            Bind<IPlayerRepository>().To<PlayerRepository>().WithConstructorArgument(connectionString);
            Bind<IPlayerCardRepository>().To<PlayerCardRepository>().WithConstructorArgument(connectionString);



            //Bind<ICardRepository>().To<CardRepository>().WithConstructorArgument(new BlackJackContext());
            //Bind<IPlayerRepository>().To<PlayerRepository>().WithConstructorArgument(new BlackJackContext());
            //Bind<IPlayerCardRepository>().To<PlayerCardRepository>().WithConstructorArgument(new BlackJackContext());
        }
    }
}
