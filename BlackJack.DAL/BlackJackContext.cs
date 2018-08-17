using BlackJack.DAL.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BlackJack.DAL
{
    public class BlackJackContext : DbContext
    {

        static BlackJackContext()
        {
            Database.SetInitializer<BlackJackContext>(new ContextInitializer());
        }

        public BlackJackContext() : base("BlackJackContext")
        { }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerCard> PlayersCards { get; set; }


    }

    public class ContextInitializer : DropCreateDatabaseAlways<BlackJackContext>
    {
        protected override void Seed(BlackJackContext context)
        {
           
        }
    }
}
