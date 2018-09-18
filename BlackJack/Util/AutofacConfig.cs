using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.BusinessLogic.Services;
using BlackJack.DataAccess.Context.MVC;
using BlackJack.DataAccess.Repositories;
using BlackJack.DataAccess.Interfaces;

namespace BlackJack.Util
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            // получаем экземпляр контейнера
            var builder = new ContainerBuilder();

            // регистрируем контроллер в текущей сборке
            builder.RegisterControllers(typeof(WebApiApplication).Assembly);

            var connectionString =System.Configuration.ConfigurationManager.ConnectionStrings["BlackJackContext"].ConnectionString;

            // регистрируем споставление типов
            //builder.RegisterType<CardRepository>().As<ICardRepository>().WithParameter("connectionString", connectionString);
            //builder.RegisterType<PlayerCardRepository>().As<IPlayerCardRepository>().WithParameter("connectionString", connectionString);
            //builder.RegisterType<PlayerRepository>().As<IPlayerRepository>().WithParameter("connectionString", connectionString);
            //builder.RegisterType<GameService>().As<GameService>();

            builder.RegisterType<GameService>().As<GameService>();
            builder.RegisterType<CardRepository>().As<ICardRepository>().WithParameter("context", new BlackJackContext());
            builder.RegisterType<PlayerCardRepository>().As<IPlayerCardRepository>().WithParameter("context", new BlackJackContext());
            builder.RegisterType<PlayerRepository>().As<IPlayerRepository>().WithParameter("context", new BlackJackContext());

            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            // установка сопоставителя зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}